// ================================================================================================
// This is the file that contains the connections to the User collection in the database, and
// contains the task necessary to get and set users in the database.
// ================================================================================================
using System.Collections.Generic;

namespace SpaceForceEvaluationAppLibrary.DataAccess;

public class MongoRequestsData : IRequestsData
{
    private readonly IMongoCollection<RequestsModel> _requests;
    // here is the constructor that establishes the connections to the
    // Uses collection.
    public MongoRequestsData(IDbConnection db)
    {
        _requests = db.RequestsCollection;
    }
    

    public Task CreateRequests(RequestsModel requests)
    {
        return _requests.InsertOneAsync(requests);
    }

    public async Task<RequestsModel> GetRequests(string id)
    {
        var results = await _requests.FindAsync(u => u.ObjectID == id);
        return results.FirstOrDefault();
    }

    public async Task<List<RequestsModel>> GetRecievedRequests(string userID)
    {

        var results = await _requests.FindAsync(u => u.requestRecipiants.Contains(userID));
        return results.ToList();
    }


    public async Task<List<RequestsModel>> GetSentRequests(string userID)
    {
        var results = await _requests.FindAsync(u => u.requestInitiator == userID);
        return results.ToList();
    }


    public Task UpdateRequest(RequestsModel requests)
    {
        var filter = Builders<RequestsModel>.Filter.Eq("ObjectID", requests.ObjectID);
        return _requests.ReplaceOneAsync(filter, requests, new ReplaceOptions { IsUpsert = true });
    }


    public async Task<List<RequestsModel>> GetAllRequests()
    {
        var results = await _requests.FindAsync(u => u.requestInitiator != "");
        return results.ToList();
    }


    public async Task RemoveRequest(string ObjectID)
    {
        var filter = Builders<RequestsModel>.Filter.Eq("ObjectID", ObjectID);
        var result = await _requests.DeleteOneAsync(filter);
    }

    public async Task RemoveAllRequests()
    {
        // var results = await _requests.FindAsync(u => u.requestInitiator != "");
        var filter = Builders<RequestsModel>.Filter.Empty;
        var result = await _requests.DeleteManyAsync(filter);
    }

    public async Task RemoveAllRequestsOfType(string type)
    {
        var filter = Builders<RequestsModel>.Filter.Eq("type", type);
        var result = await _requests.DeleteOneAsync(filter);
    }


    public bool StrListEquals(List<String> list1, List<String> list2)
    {
        if(list1 == null && list2 != null)
        {
            return false;
        }

        if (list2 == null && list1 != null)
        {
            return false;
        }

        if(list1 == null && list2 == null)
        {
            return true;
        }

        if (list1.Count != list2.Count)
        {
            return false;
        }

        for(int i = 0; i < list1.Count; i++)
        {
            if (list1[i] == null && list2[i] != null)
            {
                return false;
            }

            if (list2[i] == null && list1[i] != null)
            {
                return false;
            }

            if (list1[i] == null && list2[i] == null)
            {
                return true;
            }

            if (list1[i].Equals(list2[i]) == false)
            {
                return false;
            }
        }
        return true;
    }

    public async Task<bool> CheckIfRequestExist(RequestsModel request)
    {
        // TODO: remove this after refactoring
        if(request.values == null)
        {
            var queryResponse = await _requests.FindAsync(u =>
                                                        u.requestInitiator == request.requestInitiator &&
                                                        u.requestTarget == request.requestTarget &&
                                                        u.value == request.value &&
                                                        u.type == request.type &&
                                                        u.status == "Pending");
            var results = queryResponse.ToList();

            List<RequestsModel> filteredList = results.Where(
                                                req => StrListEquals(req.requestRecipiants, request.requestRecipiants)).ToList();


            return (filteredList.Count > 0);
        }
        else // TODO: only use this after refactoring. 
        {
            
            var queryResponse = await _requests.FindAsync(u =>
                                                        u.requestInitiator == request.requestInitiator &&
                                                        u.requestTarget == request.requestTarget &&
                                                        u.values != null &&
                                                        u.type == request.type &&
                                                        u.status == "Pending");
            var results = queryResponse.ToList();

            List<RequestsModel> filteredList = results.Where(
                                                req => StrListEquals(req.values, request.values) 
                                                    && StrListEquals(req.requestRecipiants, request.requestRecipiants)).ToList();

            return (filteredList.Count > 0);
        }

        
    }
}
