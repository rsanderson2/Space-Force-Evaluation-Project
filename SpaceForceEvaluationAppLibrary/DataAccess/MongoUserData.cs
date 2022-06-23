// ================================================================================================
// This is the file that contains the connections to the User collection in the database, and
// contains the task necessary to get and set users in the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess;

public class MongoUserData : IUserData
{
    private readonly IMongoCollection<UserModel> _users;
    // here is the constructor that establishes the connections to the
    // Uses collection.
    public MongoUserData(IDbConnection db)
    {
        _users = db.UserCollection;
    }

    // returns all user records.
    public async Task<List<UserModel>> GetUsersAsync()
    {
        var results = await _users.FindAsync(_ => true);
        return results.ToList();
    }

    // returns a list of users models that contain the same teamId
    public async Task<List<UserModel>> GetUsersFromTeam(string teamId)
    {
        var results = await _users.FindAsync(u => u.teamID == teamId);
        return results.ToList();
    }

    // returns user record by the parameter id.
    public async Task<UserModel> GetUser(string id)
    {
        var results = await _users.FindAsync(u => u.userID == id);
        return results.FirstOrDefault();
    }

    // returns user record by the parameter objectId.
    public async Task<UserModel> GetUserFromAuthentication(string objectId)
    {
        var results = await _users.FindAsync(u => u.ObjectIdentifier == objectId);
        return results.FirstOrDefault();
    }

    public Task CreateUser(UserModel user)
    {
        return _users.InsertOneAsync(user);
    }

    public Task UpdateUser(UserModel user)
    {
        var filter = Builders<UserModel>.Filter.Eq("userID", user.userID);
        return _users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
    }

    public async Task<List<string>> GetUsersSurveys(string objectId)
    {
        UserModel user = (UserModel)await _users.FindAsync(u => u.ObjectIdentifier == objectId);
        var results = user.surveyHistory.ToList();

        return results;
    }
}
