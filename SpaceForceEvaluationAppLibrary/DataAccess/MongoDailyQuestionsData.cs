// ================================================================================================
// This file contains all tasks that read and write data to the dailyQuestions collection in
// the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess;

public class MongoDailyQuestionsData : IDailyQuestionsData
{
    private readonly IDbConnection _db;
    private readonly IMongoCollection<DailyQuestionsModel> _questions;

    // here is the constructor for the database connection which initializes a connection
    // to the dailyQuestions collection in the database.
    public MongoDailyQuestionsData(IDbConnection db)
    {
        _db = db;
        _questions = db.DailyQuestionsCollection;
    }

    // here is the task that returns a single question asyncronously from the dailyQuestions
    // collection by the interger variable QuestionID.
    public async Task<DailyQuestionsModel> GetDailyQuestion(int Id)
    {
        var returned = await _questions.FindAsync(q => q.QuestionID == Id);
        return returned.FirstOrDefault();

    }

    public async Task<DailyQuestionsModel> GetDailyQuestionsByCategory(string category)
    {
        var returned = await _questions.FindAsync(q => q.category == category);
        return returned.FirstOrDefault();
    }
}
