// ================================================================================================
// This is the file that contains the connections to the User collection in the database, and
// contains the task necessary to get and set users in the database.
// ================================================================================================
using MongoDB.Bson;

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

    public async Task<List<UserModel>> getAllUsers()
    {
        var results = await _users.FindAsync(u => u.firstName != "");
        return results.ToList();
    }

    
    public async Task<UserModel> GetUserFromFirstName(string firstName)
    {
        var results = await _users.FindAsync(u => u.firstName == firstName);
        return results.FirstOrDefault();
    }


    public async Task<UserModel> GetUserByEmail(String email)
    {
        var results = await _users.FindAsync(u => u.email == email);
        return results.FirstOrDefault();
    }



    // returns user record by the parameter objectId.
    public async Task<UserModel> GetUserFromAuthentication(string objectId)
    {
        var results = await _users.FindAsync(u => u.ObjectIdentifier == objectId);
        return results.FirstOrDefault();
    }

    // this task creates a new user and returns a question
    public Task CreateUser(UserModel user)
    {
        return _users.InsertOneAsync(user);
    }

    // this task update an already existing user
    public Task UpdateUser(UserModel user)
    {
        var filter = Builders<UserModel>.Filter.Eq("userID", user.userID);
        return _users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
    }

    public async Task EmptyAllSupordinatesAndSuperiorsList()
    {
        var users = await GetUsersAsync();

        foreach (var user in users)
        {
            if (user.superiors != null)
            {
                user.superiors.Clear();
            }

            if (user.subordinates != null)
            {
                user.subordinates.Clear();
            }

            await UpdateUser(user);
        }
    }


    public async Task EmptyAllTeamIDs()
    {
        var users = await GetUsersAsync();

        foreach (var user in users)
        {
            if (user.teamIDs != null)
            {
                user.teamIDs.Clear();
            }

            await UpdateUser(user);
        }
    }

}
