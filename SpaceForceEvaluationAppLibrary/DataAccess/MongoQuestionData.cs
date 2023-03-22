// ================================================================================================
// This file contains all tasks that read and write data to the uestions collection in
// the database.
// ================================================================================================

namespace SpaceForceEvaluationAppLibrary.DataAccess;
public class MongoQuestionsData : IQuestionsData
{
    private readonly IDbConnection _db;
    private readonly IMongoCollection<QuestionsModel> _questions;

    public MongoQuestionsData(IDbConnection db)
    {
        _db = db;
        _questions = db.QuestionCollection;
    }
    public async Task<List<QuestionsModel>> GetQuestionsByCategory(string category)
    {
        var returned = await _questions.FindAsync(q => q.category == category);
        return returned.ToList();
    }
}

