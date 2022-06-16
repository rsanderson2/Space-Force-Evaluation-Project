// ================================================================================================
// This is the interface for the DbConnection data access file.
// ================================================================================================
using MongoDB.Driver;

namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IDbConnection
    {
        MongoClient Client { get; }
        IMongoCollection<DailyQuestionsModel> DailyQuestionsCollection { get; }
        string DailyQuestionsCollectionName { get; }
        string DbName { get; }
        IMongoCollection<FeedbackModel> FeedbackCollection { get; }
        string FeedbackCollectionName { get; }
        IMongoCollection<MonthlyQuestionsModel> MonthlyQuestionsCollection { get; }
        string MonthlyQuestionsCollectionName { get; }
        IMongoCollection<ReportModel> ReportsCollection { get; }
        string ReportsCollectionName { get; }
        IMongoCollection<SurveyModel> SurveyCollection { get; }
        string SurveyCollectionName { get; }
        IMongoCollection<UserModel> UserCollection { get; }
        string UserCollectionName { get; }
        IMongoCollection<WeeklyQuestionsModel> WeeklyQuestionsCollection { get; }
        string WeeklyQuestionsCollectionName { get; }
    }
}