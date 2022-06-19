// ================================================================================================
// This is the file that contains the connections to each of the collections that are necessary 
// to generate and store surveys in the database. This file also contains the tasks necessary,
// to generate and store surveys in the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface ISurveyData
    {
        Task CreateSurvey(SurveyModel survey);
        Task<SurveyModel> GetSurvey(string id);
        Task UpdateSurvey(SurveyModel survey);
    }
}