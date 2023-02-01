// ================================================================================================
// This file contains all tasks that read and write data to the WeeklyQuestions collection in
// the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess;

public class MongoWeeklyQuestionsData : IWeeklyQuestionsData
{
    private readonly IDbConnection _db;
    private readonly IMongoCollection<WeeklyQuestionsModel> _questions;

    // here is the constructor for the database connection which initializes a connection
    // to the WeeklyQuestions collection in the database.
    public MongoWeeklyQuestionsData(IDbConnection db)
    {
        _db = db;
        _questions = db.WeeklyQuestionsCollection;
    }

    // here is the task that returns a single question asyncronously from the WeeklyQuestions
    // collection by the interger variable QuestionID.
    public async Task<WeeklyQuestionsModel> GetWeeklyQuestion(int Id)
    {
        var returned = await _questions.FindAsync(q => q.QuestionID == Id);
        return returned.FirstOrDefault();

    }

    // here is the task that returns a single question asyncronously from the WeeklyQuestions
    // collection by the string variable Category.
    public async Task<WeeklyQuestionsModel> GetWeeklyQuestionsByCategory(string category)
    {
        var returned = await _questions.FindAsync(q => q.category == category);
        return returned.FirstOrDefault();
    }
}
