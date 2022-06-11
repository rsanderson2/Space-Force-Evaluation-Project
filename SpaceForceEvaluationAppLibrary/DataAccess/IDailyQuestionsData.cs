namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IDailyQuestionsData
    {
        Task<DailyQuestionsModel> GetDailyQuestion(int Id);
    }
}