namespace SpaceForceEvaluationAppLibrary.DataAccess;

public class MongoDailyQuestionsData : IMongoDailyQuestionsData
{
    private readonly IMongoCollection<DailyQuestionsModel> _questions;
    private readonly IDbConnection _db;

    public MongoDailyQuestionsData(IDbConnection db, IMongoCollection<DailyQuestionsModel> questions)
    {
        _db = db;
        _questions = questions;
    }

    public async Task<Object> GetDailyQuestion(string id)
    {
        return await _questions.FindOneAsync(q => q.id == id);
    }
}
