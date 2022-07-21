// ================================================================================================
// This file contains the necessary tasks to access and query data from the the feedback collection
// in the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IFeedbackData
    {
        Task CreateFeedback(FeedbackModel feedback);
        Task<FeedbackModel> GetFeedbackByName(string name);
        Task<List<FeedbackModel>> GetFeedbackByTeam(string teamID);
        Task<FeedbackModel> GetFeedbackByUser(string userID);
        Task UpdateFeedback(FeedbackModel feedback);
    }
}