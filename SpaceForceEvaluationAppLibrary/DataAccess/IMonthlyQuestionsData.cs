// ================================================================================================
// This is the interface for the MonthlyQuestions data access file.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IMonthlyQuestionsData
    {
        Task<MonthlyQuestionsModel> GetMonthlyQuestion(int Id);

        Task<MonthlyQuestionsModel> GetMonthlyQuestionsByCategory(string category);
    }
}