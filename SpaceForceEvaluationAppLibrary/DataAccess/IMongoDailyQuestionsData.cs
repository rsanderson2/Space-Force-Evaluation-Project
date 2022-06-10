namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IMongoDailyQuestionsData
    {
        Task<object> GetDailyQuestion(string id);
    }
}