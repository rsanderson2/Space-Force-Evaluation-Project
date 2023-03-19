// ================================================================================================
// This is the file that contains the connections to the User collection in the database, and
// contains the task necessary to get and set users in the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IRequestsData
    {
        Task CreateRequests(RequestsModel requests);
        Task<RequestsModel> GetRequests(string id);
        Task<List<RequestsModel>> GetRecievedRequests(string userID);
        Task<List<RequestsModel>> GetSentRequests(string userID);
        Task UpdateRequest(RequestsModel requests);
        Task<List<RequestsModel>> GetAllRequests();

        Task RemoveRequest(string ObjectID);

        Task RemoveAllRequests();
        Task<bool> CheckIfRequestExist(RequestsModel request);
    }
}