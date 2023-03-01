// ================================================================================================
// This is the file that contains the connections to the User collection in the database, and
// contains the task necessary to get and set users in the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface ITransferRequests
    {
        // Task CreateTransferReqeust(TransferRequestModel request);
        Task<TransferRequestModel> GetRequest(string id);
    }
}