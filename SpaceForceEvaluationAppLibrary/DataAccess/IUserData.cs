// ================================================================================================
// This is the file that contains the connections to the User collection in the database, and
// contains the task necessary to get and set users in the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IUserData
    {
        Task CreateUser(UserModel user);
        Task<UserModel> GetUser(string id);
        Task<UserModel> GetUserFromAuthentication(string objectId);
        Task<UserModel> GetUserFromFirstName(string firstName);

        Task<UserModel> GetClosestCommander(string userID);

        /*
        Task<List<UserModel>> GetUsersFromIdList(List<string> userIds);
        Task<List<UserModel>> GetAllSubordinates(string ObjectIdentifier);
        Task<UserModel> GetDirectSuperior(string id);
        Task<UserModel> GetClosestCommander(string id);
        */
        Task<bool> ADCONTransfer(String currentUserID, String subordinateID);

        Task<bool> addUserToSelfAssignedEvaluators(String currentUserID, String newEvaluatorID);

        Task<List<UserModel>> GetUsersAsync();
        Task<List<UserModel>> GetUsersFromTeam(string teamId);
        Task<List<UserModel>> getAllUsers();
        Task UpdateUser(UserModel user);

        Task<List<UserModel>> GetDirectSubordinates(UserModel user);

        Task EmptyAllSupordinatesAndSuperiorsList();

        Task removeSelfAssignedEvaluatorFromUser(String evaluatorID, String userID);

    }
}