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

    public async Task<List<UserModel>> GetDirectSubordinates(UserModel user)
    {
        var subordinates = new List<UserModel>();
        if (user.subordinates != null)
        {
            System.Diagnostics.Debug.WriteLine("Number of subordinates = " + user.subordinates.Count);
            for (int i = 0; i < user.subordinates.Count; i++)
            {
                var subordinateId = user.subordinates[i];
                var subordinate = await GetUser(subordinateId);
                if (subordinate != null)
                {
                    System.Diagnostics.Debug.WriteLine("Adding user to subordinates list");
                    System.Diagnostics.Debug.WriteLine(subordinate.firstName);
                    subordinates.Add(subordinate);
                }
            }
        }
        return subordinates;
    }



    public async Task<bool> ADCONTransfer(String currentUserID, String subordinateID)
    {
        UserModel currentUser = await GetUser(currentUserID);
        UserModel subordinate = await GetUser(subordinateID);

        //// 1. check if the subordinate is already a direct subordinate of the currentUser
        if (currentUser.subordinates != null && currentUser.subordinates.Contains(subordinate.userID))
            return false;

        if (currentUser.superiors != null && subordinate.superiors.Count > 0 && subordinate.superiors[0] == currentUser.userID)
            return false;

        // 2. remove subordinate from its old superior
        if (subordinate.superiors != null && subordinate.superiors.Count > 0)
        {
            var oldSuperiorId = subordinate.superiors[0];
            var oldSuperior = await GetUser(oldSuperiorId);
            if (oldSuperior.subordinates != null)
            {
                oldSuperior.subordinates.Remove(subordinate.userID);
                await UpdateUser(oldSuperior);
            }
        }

        // 3. add subordinate to currentUser
        if (currentUser.subordinates == null)
        {
            currentUser.subordinates = new List<string>();
        }

        currentUser.subordinates.Add(new String(subordinate.userID));

        // 4. update subordinate's superior
        subordinate.superiors = new List<string> { currentUser.userID };

        // 5. update the users
        await UpdateUser(currentUser);
        await UpdateUser(subordinate);

        return true;
    }




    public async Task<UserModel> GetClosestCommander(string userID) // TODO: test
    {
        UserModel currentUser = await GetUser(userID);

        if (currentUser.role == "Commander" || currentUser.role == "HQ")
        {
            return currentUser;
        }
        else
        {
            return await GetClosestCommander(currentUser.superiors[0]);
        }
    }



    public async Task<bool> addUserToSelfAssignedEvaluators(String currentUserID, String newEvaluatorID)
    {
        UserModel currentUser = await GetUser(currentUserID);
        // Three is the current limit for self assigned evaluators. 
        if(currentUser.selfAssignedEvaluators == null)
        {
            currentUser.selfAssignedEvaluators = new List<String>();
        }
        
        if(currentUser.superiorAssignedEvaluators == null)
        {
            currentUser.superiorAssignedEvaluators = new List<String>();
        }
        
        if (currentUser.selfAssignedEvaluators.Count < 3)
        {
            // newEvaluators is already an evaluator for this user
            bool isSuperiorAssignedEvaluator = currentUser.superiorAssignedEvaluators.Contains(newEvaluatorID);
            bool isSelfAssignedEvaluator = currentUser.selfAssignedEvaluators.Contains(newEvaluatorID);

            if(isSuperiorAssignedEvaluator || isSelfAssignedEvaluator)
            {
                return false;
            }

            currentUser.selfAssignedEvaluators.Add(newEvaluatorID);
            await UpdateUser(currentUser);
            return true;
        }
        else
        {
            return false;
        }
    }


    public async Task<bool> addUserToSuperiorAssignedEvaluators(String currentUserID, String newEvaluatorID)
    {
        UserModel currentUser = await GetUser(currentUserID);
        // Three is the current limit for self assigned evaluators. 
        if (currentUser.superiorAssignedEvaluators.Count < 3)
        {
            // newEvaluators is already an evaluator for this user
            bool isSuperiorAssignedEvaluator = currentUser.superiorAssignedEvaluators.Contains(newEvaluatorID); ;
            bool isSelfAssignedEvaluator = currentUser.selfAssignedEvaluators.Contains(newEvaluatorID);

            if (isSuperiorAssignedEvaluator || isSelfAssignedEvaluator)
            {
                return false;
            }

            currentUser.superiorAssignedEvaluators.Add(newEvaluatorID);
            await UpdateUser(currentUser);
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task removeSuperiorAssignedEvaluatorFromUser(String evaluatorID, String userID)
    {
        UserModel user = await GetUser(userID);

        user.superiorAssignedEvaluators.Remove(evaluatorID);
        await UpdateUser(user);
        return;
    }

    public async Task removeSelfAssignedEvaluatorFromUser(String evaluatorID, String userID)
    {
        UserModel user = await GetUser(userID);

        user.selfAssignedEvaluators.Remove(evaluatorID);
        await UpdateUser(user);
        return;
    }


    public bool hasDirectADCONOverUser(UserModel potentialSubordinate, UserModel potentialSuperior)
    {
        if (potentialSuperior.subordinates == null)
        {
            return false;
        }
        if (potentialSubordinate.superiors != null && potentialSubordinate.superiors.Count > 0 && potentialSubordinate.superiors[0] == potentialSuperior.userID)
        {
            return true;
        }
        return false;
    }


    public async Task<bool> hasIndirectADCONOverUser(UserModel potentialSubordinate, UserModel potentialSuperior)
    {
        if (potentialSubordinate == null)
        {
            return false;
        }

        if (potentialSubordinate.superiors != null && potentialSubordinate.superiors.Count > 0)
        {
            if (potentialSubordinate.superiors[0] == potentialSuperior.userID)
            {
                return true;
            }

            UserModel nextUser = await GetUser(potentialSubordinate.superiors[0]);

            return await hasIndirectADCONOverUser(nextUser, potentialSuperior);
        }
        return false;
    }


    public async Task<UserModel> GetUserByEmail(String email)
    {
        var results = await _users.FindAsync(u => u.email == email);
        return results.FirstOrDefault();
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


    public async Task EmptyAllEvaluators()
    {
        var users = await GetUsersAsync();
        foreach (var user in users.ToList())
        {
            user.selfAssignedEvaluators.Clear();
            user.superiorAssignedEvaluators.Clear();
            await UpdateUser(user);
        }
    }


    public async Task<List<UserModel>> GetUsersByEvaluator(String evaluatorID)
    {
        var results = await _users.FindAsync(u => (u.selfAssignedEvaluators != null
                                              && u.selfAssignedEvaluators.Contains(evaluatorID))
                                            || (u.superiorAssignedEvaluators != null && u.superiorAssignedEvaluators.Contains(evaluatorID)));
         return results.ToList();

        /*
        var users = await GetUsersAsync();
        var response = new List<UserModel>();
        foreach(var user in users)
        {
            if(user.selfAssignedEvaluators != null && user.selfAssignedEvaluators.Contains(evaluatorID))
            {
                response.Add(user);
            }
            else if (user.superiorAssignedEvaluators != null && user.superiorAssignedEvaluators.Contains(evaluatorID))
            {
                response.Add(user);
            }
        }
        return response;
        */
    }
}
