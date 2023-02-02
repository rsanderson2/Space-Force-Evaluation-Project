// ================================================================================================
// This file contains all tasks that read and write data to the MonthlyQuestions collection in
// the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess;

public class MongoMonthlyQuestionsData : IMonthlyQuestionsData
{
    private readonly IDbConnection _db;
    private readonly IMongoCollection<MonthlyQuestionsModel> _questions;

    // here is the constructor for the database connection which initializes a connection
    // to the MonthlyQuestions collection in the database.
    public MongoMonthlyQuestionsData(IDbConnection db)
    {
        _db = db;
        _questions = db.MonthlyQuestionsCollection;
    }

    // here is the task that returns a single question asyncronously from the MonthlyQuestions
    // collection by the interger variable QuestionID.
    public async Task<MonthlyQuestionsModel> GetMonthlyQuestion(int Id)
    {
        var returned = await _questions.FindAsync(q => q.QuestionID == Id);
        return returned.FirstOrDefault();

    }

    // here is the task that returns a single question asyncronously from the MonthlyQuestions
    // collection by the string variable Category.
    public async Task<MonthlyQuestionsModel> GetMonthlyQuestionsByCategory(string category)
    {
        var returned = await _questions.FindAsync(q => q.category == category);
        return returned.FirstOrDefault();
    }
}
