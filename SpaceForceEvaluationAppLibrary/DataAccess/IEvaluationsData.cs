// ================================================================================================
// This is the file that contains the connections to the User collection in the database, and
// contains the task necessary to get and set users in the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IEvaluationsData
    {
        Task CreateEvaluation(EvaluationsModel requests);
        
        Task<EvaluationsModel> GetEvaluation(string id);
        
        Task<List<EvaluationsModel>> GetByEvaluator(string userID);

        
        Task<List<EvaluationsModel>> GetByUserBeingEvaluated(string userID);

        Task UpdateEvaluation(EvaluationsModel requests);

        
        Task<List<EvaluationsModel>> GetAllEvaluations();

        
        Task RemoveEvaluation(string ObjectID);
        
        Task RemoveAllEvaluations();
        
        Task<bool> CheckIfEvaluationExist(EvaluationsModel evaluation);

        Task<List<String>> GetSelfAllAssignedEvaluatorsIDs(string userID);

        Task<EvaluationsModel> GetByEvaluatorAndUserBeingEvaluated(string evaluatorID, string userBeingEvaluatedID);

    }
}