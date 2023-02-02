// ================================================================================================
// This file contains all tasks that read and write data to the climateQuestions collection in
// the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess;

public class MongoClimateQuestionsData : IClimateQuestionsData
{
    private readonly IDbConnection _db;
    private readonly IMongoCollection<ClimateQuestionsModel> _questions;

    // here is the constructor for the database connection which initializes a connection
    // to the climateQuestions collection in the database.
    public MongoClimateQuestionsData(IDbConnection db)
    {
        _db = db;
        _questions = db.ClimateQuestionsCollection;
    }

    // here is the task that returns a single question asyncronously from the climateQuestions
    // collection by the interger variable QuestionID.
    public async Task<ClimateQuestionsModel> GetClimateQuestion(int questionID)
    {
        var returned = await _questions.FindAsync(q => q.QuestionID == questionID);
        return returned.FirstOrDefault();
    }

    // task that takes in a category and returns a list of questions asyncronously from the 
    // climateQuestions collection by the string variable Category.

    public async Task<ClimateQuestionsModel> GetClimateQuestionsByCategory(string category)
    {
        var returned = await _questions.FindAsync(q => q.category == category);
        return returned.FirstOrDefault();
    }
}