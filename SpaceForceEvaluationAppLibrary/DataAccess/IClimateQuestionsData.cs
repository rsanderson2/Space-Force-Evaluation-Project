// ================================================================================================
// This file contains all tasks that read and write data to the climateQuestions collection in
// the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IClimateQuestionsData
    {
        Task<ClimateQuestionsModel> GetClimateQuestion(int Id);

        Task<ClimateQuestionsModel> GetClimateQuestionsByCategory(string category);
    }
}