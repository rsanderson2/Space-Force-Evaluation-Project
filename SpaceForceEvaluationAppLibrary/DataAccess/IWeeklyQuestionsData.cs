// ================================================================================================
// This is the interface for the WeeklyQuestions data access file.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IWeeklyQuestionsData
    {
        Task<WeeklyQuestionsModel> GetWeeklyQuestion(int Id);
        Task<WeeklyQuestionsModel> GetWeeklyQuestionsByCategory(string category);
    }
}