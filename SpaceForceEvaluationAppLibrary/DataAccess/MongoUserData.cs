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

    public async Task AddUserToSubordinates(UserModel currentUser, string subordinateId)
    {
        if(currentUser.subordinates == null)
        {
            List<string> newSubordinates = new List<string>();
            newSubordinates.Add(subordinateId);
            currentUser.subordinates = newSubordinates;
        }
        else
        {
            currentUser.subordinates.Add(subordinateId);
        }

        await UpdateUser(currentUser);

    }
    /*
    public async Task<List<UserModel>> GetUsersFromIdList(List<string> userIds) // TODO: test
    {
        List<UserModel> usersFromList = new List<UserModel>();
        foreach(var id in userIds)
        {
            UserModel curUser = await GetUser(id);
            usersFromList.Add(curUser);
        }
        return usersFromList;
    }

    public async Task<List<UserModel>> GetAllSubordinates(string ObjectIdentifier) // TODO: test
    {
        UserModel user = await GetUserFromAuthentication(ObjectIdentifier);
        List<UserModel> subordinates = await GetUsersFromIdList(user.subordinates);
        return subordinates;
    }

    public async Task<UserModel> GetDirectSuperior(string id) // TODO: test
    {
        UserModel user = await GetUser(id);
        return await GetUser(user.superiors[0]);
    }

    public async Task<UserModel> GetClosestCommander(string id) // TODO: test
    {
        UserModel currentUser = await GetUser(id);

        if(currentUser.rank == "Commander" || currentUser.rank == "HQ")
        {
            return currentUser;
        }
        else
        {
            return await GetClosestCommander(currentUser.superiors[0]);
        }
    }
    */

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
}
