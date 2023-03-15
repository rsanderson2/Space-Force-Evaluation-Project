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
        Task<RequestsModel> GetRecievedRequests(string userID);
        Task<RequestsModel> GetSentRequests(string userID);
    }
}