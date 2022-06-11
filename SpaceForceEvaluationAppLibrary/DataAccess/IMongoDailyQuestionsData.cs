namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IMongoDailyQuestionsData
    {
        Task<DailyQuestionsModel> GetDailyQuestion(string id);
    }
}