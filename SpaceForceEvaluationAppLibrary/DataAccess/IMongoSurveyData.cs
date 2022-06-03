namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IMongoSurveyData
    {
        Task CreateSurvey(SurveyModel survey);
        Task<List<SurveyModel>> GetAllPastSurveys();
        Task<List<SurveyModel>> GetTodaysSurveys();
    }
}