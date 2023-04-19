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

        Task EmptyAllTeamIDs();

        Task<UserModel> GetUserByEmail(String email);

        Task<List<UserModel>> GetUsersAsync();

        Task<List<UserModel>> GetUsersFromTeam(string teamId);

        Task<List<UserModel>> getAllUsers();

        Task UpdateUser(UserModel user);

        Task EmptyAllSupordinatesAndSuperiorsList();
    }
}