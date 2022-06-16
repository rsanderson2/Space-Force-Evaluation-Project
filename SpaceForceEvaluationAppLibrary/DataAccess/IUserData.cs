// ================================================================================================
// This is the interface for the MongoUserData data access file.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IUserData
    {
        Task CreateUser(UserModel user);
        Task<UserModel> GetUser(string id);
        Task<UserModel> GetUserFromAuthentication(string objectId);
        Task<List<UserModel>> GetUsersAsync();
        Task<List<string>> GetUsersSurveys(string objectId);
        Task UpdateUser(UserModel user);
    }
}