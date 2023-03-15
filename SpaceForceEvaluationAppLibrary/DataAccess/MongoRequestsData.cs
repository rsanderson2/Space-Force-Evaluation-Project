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


    public async Task<RequestsModel> GetRecievedRequests(string userID)
    {
        var results = await _requests.FindAsync(u => u.requestInitiator == userID);
        return results.FirstOrDefault();
    }


    public async Task<RequestsModel> GetSentRequests(string userID)
    {
        var results = await _requests.FindAsync(u => u.requestTarget == userID);
        return results.FirstOrDefault();
    }

}
