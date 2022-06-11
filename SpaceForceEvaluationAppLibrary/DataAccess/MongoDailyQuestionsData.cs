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

    public async Task<DailyQuestionsModel> GetDailyQuestion(string id)
    {
        var returned = await _questions.FindAsync(q => q.Id == id);
        return returned.FirstOrDefault();
    }
}
