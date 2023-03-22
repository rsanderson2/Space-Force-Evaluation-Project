// ================================================================================================
// This is the file that contains the connections to the NewSurveyData collection in the database, and
// contains the task necessary to get and set survey responses in the database.
// ================================================================================================

namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface INewSurveyData
    {
        Task CreateNewSurvey(NewSurveyModel survey);
        Task<List<NewSurveyModel>> GetNewSurveysbyUser(string takerID);
    }
}