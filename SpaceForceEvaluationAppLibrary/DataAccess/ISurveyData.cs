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
        Task<List<SurveyModel>> GetAllFreeResponse();
        Task<List<SurveyModel>> GetAllSurveys();
        Task<List<SurveyModel>> GetListOfSurveys(string takerID);
        Task<SurveyModel> GetSurvey(string id);
        Task<List<SurveyModel>> GetSurveysAboutUser(string subjectID);
        Task<List<SurveyModel>> GetSurveysByCategory(string category);
        Task<List<SurveyModel>> GetSurveysByTeam(string teamID);
        //Task UpdateSurvey(SurveyModel survey);
    }
}