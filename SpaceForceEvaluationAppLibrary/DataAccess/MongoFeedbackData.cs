// ================================================================================================
// This file contains the necessary tasks to access and query data from the the feedback collection
// in the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess;
public class MongoFeedbackData : IFeedbackData
{
    private readonly IMongoCollection<FeedbackModel> _feedback;
    private readonly IDbConnection _db;

    // constructor connects to the feedback collection.
    // all queries in this file use _feedback
    public MongoFeedbackData(IDbConnection db)
    {
        _feedback = db.FeedbackCollection;
    }

    // task returns one feeback model by the ID of the user
    public async Task<FeedbackModel> GetFeedbackByUser(string userID)
    {
        var results = await _feedback.FindAsync(f => f.userID == userID);
        return results.FirstOrDefault();
    }

    // task returns a list of feedback models by the teamID of the users
    public async Task<List<FeedbackModel>> GetFeedbackByTeam(string teamID)
    {
        var results = await _feedback.FindAsync(f => f.teamID == teamID);
        return results.ToList();
    }

    // task returns a single feeback model by a users whole name
    // i.e. name = firstName + " " + lastName;
    public async Task<FeedbackModel> GetFeedbackByName(string name)
    {
        var results = await _feedback.FindAsync(f => f.name == name);
        return results.FirstOrDefault();
    }

    // task updates a feedback model specified by that tables userID
    // then returns that model to function call
    public Task UpdateFeedback(FeedbackModel feedback)
    {
        var filter = Builders<FeedbackModel>.Filter.Eq("userID", feedback.userID);
        return _feedback.ReplaceOneAsync(filter, feedback, new ReplaceOptions { IsUpsert = true });
    }

    // task creates a new feedback model in the feedback collection
    // only needs to be called one per user. If the user is not new
    // then use UpdateFeedback function instead.
    public Task CreateFeedback(FeedbackModel feedback)
    {
        return _feedback.InsertOneAsync(feedback);
    }

}
