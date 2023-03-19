// ================================================================================================
// This is the file that contains the connections to the User collection in the database, and
// contains the task necessary to get and set users in the database.
// ================================================================================================
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
        var results = await _requests.FindAsync(u => u.requestTarget1 == userID ||
                                                     u.requestTarget2 == userID);
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


    public async Task<bool> CheckIfRequestExist(RequestsModel request)
    {
        // var results = await _requests.FindAsync(u => u.requestInitiator != "");
        var queryResponse = await _requests.FindAsync(u => 
                                                    u.requestInitiator == request.requestInitiator && 
                                                    u.requestTarget == request.requestTarget &&
                                                    u.value == request.value &&
                                                    u.type == request.type &&
                                                    u.status == "Pending"); 
        var results = queryResponse.ToList();

        return (results.Count > 0);
    }
}
