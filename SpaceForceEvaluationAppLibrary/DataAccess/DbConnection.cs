using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace SpaceForceEvaluationAppLibrary.DataAccess;
public class DbConnection : IDbConnection
{
    private readonly IConfiguration _config;
    private readonly IMongoDatabase _db;
    private string _connectionId = "MongoDB";
    public string DbName { get; private set; }

    // TO DO: Check to see if collection names are case sensitive
    public string UserCollectionName { get; private set; } = "Users";
    public string SurveyCollectionName { get; private set; } = "Surveys";
    public string DailyQuestionsCollectionName { get; private set; } = "dailyQuestions";
    public string WeeklyQuestionsCollectionName { get; private set; } = "weeklyQuestions";
    public string MonthlyQuestionsCollectionName { get; private set; } = "monthlyQuestions";
    public string ReportsCollectionName { get; private set; } = "Reports";
    public string FeedbackCollectionName { get; private set; } = "Feedback";

    public MongoClient Client { get; private set; }
    public IMongoCollection<UserModel> UserCollection { get; private set; }
    public IMongoCollection<SurveyModel> SurveyCollection { get; private set; }
    public IMongoCollection<DailyQuestionsModel> DailyQuestionsCollection { get; private set; }
    public IMongoCollection<WeeklyQuestionsModel> WeeklyQuestionsCollection { get; private set; }
    public IMongoCollection<MonthlyQuestionsModel> MonthlyQuestionsCollection { get; private set; }
    public IMongoCollection<ReportModel> ReportsCollection { get; private set; }
    public IMongoCollection<FeedbackModel> FeedbackCollection { get; private set; }
    public DbConnection(IConfiguration config)
    {
        _config = config;
        Client = new MongoClient(_config.GetConnectionString(_connectionId));
        DbName = _config["DatabaseName"];
        _db = Client.GetDatabase(DbName);

        UserCollection = _db.GetCollection<UserModel>(UserCollectionName);
        SurveyCollection = _db.GetCollection<SurveyModel>(SurveyCollectionName);
        DailyQuestionsCollection = _db.GetCollection<DailyQuestionsModel>(DailyQuestionsCollectionName);
        WeeklyQuestionsCollection = _db.GetCollection<WeeklyQuestionsModel>(WeeklyQuestionsCollectionName);
        MonthlyQuestionsCollection = _db.GetCollection<MonthlyQuestionsModel>(MonthlyQuestionsCollectionName);
        ReportsCollection = _db.GetCollection<ReportModel>(ReportsCollectionName);
        FeedbackCollection = _db.GetCollection<FeedbackModel>(FeedbackCollectionName);
    }
}
