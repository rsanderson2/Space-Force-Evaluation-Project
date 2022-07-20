// ================================================================================================
// This file contains the connection made to the database refrenced from the connection string
// located in "appseting.json" under the section labeled "MongoDB". This file also contains 
// the connection made to each of the collections in the database.
// ================================================================================================
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace SpaceForceEvaluationAppLibrary.DataAccess;
public class DbConnection : IDbConnection
{
    private readonly IConfiguration _config;
    private readonly IMongoDatabase _db;
    private string _connectionId = "MongoDB";
    public string DbName { get; private set; }
    // here each of the collections is named. Each name is case sensitive and much match exactly
    // the name of the collections in the database.
    public string UserCollectionName { get; private set; } = "Users";
    public string SurveyCollectionName { get; private set; } = "Surveys";
    public string DailyQuestionsCollectionName { get; private set; } = "dailyQuestions";
    public string ClimateQuestionsCollectionName { get; private set; } = "climateQuestions";
    public string ReportsCollectionName { get; private set; } = "Reports";
    public string FeedbackCollectionName { get; private set; } = "Feedback";
    public string AccoladesCollectionName { get; private set; } = "Accolades";

    // here each of the collections is intialized as a type referencing their respective models
    // located in SpaceForceEvaluationAppLibrary/Models.
    public MongoClient Client { get; private set; }
    public IMongoCollection<UserModel> UserCollection { get; private set; }
    public IMongoCollection<SurveyModel> SurveyCollection { get; private set; }
    public IMongoCollection<DailyQuestionsModel> DailyQuestionsCollection { get; private set; }
    public IMongoCollection<ClimateQuestionsModel> ClimateQuestionsCollection { get; private set; }
    public IMongoCollection<ReportModel> ReportsCollection { get; private set; }
    public IMongoCollection<FeedbackModel> FeedbackCollection { get; private set; }
    public IMongoCollection<AccoladeModel> AccoladesCollection { get; private set; }

    // here is the constructor for the database connection. The database connection is made first, then
    // each of the collections are connected.
    public DbConnection(IConfiguration config)
    {
        _config = config;
        Client = new MongoClient(_config.GetConnectionString(_connectionId));
        DbName = _config["DatabaseName"];
        _db = Client.GetDatabase(DbName);

        UserCollection = _db.GetCollection<UserModel>(UserCollectionName);
        SurveyCollection = _db.GetCollection<SurveyModel>(SurveyCollectionName);
        DailyQuestionsCollection = _db.GetCollection<DailyQuestionsModel>(DailyQuestionsCollectionName);
        ClimateQuestionsCollection = _db.GetCollection<ClimateQuestionsModel>(ClimateQuestionsCollectionName);
        ReportsCollection = _db.GetCollection<ReportModel>(ReportsCollectionName);
        FeedbackCollection = _db.GetCollection<FeedbackModel>(FeedbackCollectionName);
        AccoladesCollection = _db.GetCollection<AccoladeModel>(AccoladesCollectionName);
    }
}
