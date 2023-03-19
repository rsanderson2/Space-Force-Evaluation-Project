// ================================================================================================
// This is the interface for the dailyQuestions data access file.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IDailyQuestionsData
    {
        Task<DailyQuestionsModel> GetDailyQuestion(int Id);

        Task<DailyQuestionsModel> GetDailyQuestionsByCategory(string category);
    }
}