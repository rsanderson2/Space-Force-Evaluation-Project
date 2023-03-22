// ================================================================================================
// This file contains the connection made to the database refrenced from the connection string
// located in "appseting.json" under the section labeled "MongoDB". This file also contains 
// the connection made to each of the collections in the database.
// ================================================================================================
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SpaceForceEvaluationAppLibrary.Models;

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
    public string DailyQuestionsCollectionName { get; private set; } = "DailyQuestions";
    public string ClimateQuestionsCollectionName { get; private set; } = "climateQuestions";
    public string FeedbackCollectionName { get; private set; } = "Feedback";
    public string AccoladesCollectionName { get; private set; } = "Accolades";
    public string WeeklyQuestionsCollectionName { get; private set; } = "WeeklyQuestions";

    public string MonthlyQuestionsCollectionName { get; private set; } = "MonthlyQuestions";

    public string TransferRequestCollectionName { get; private set; } = "transfer_Requests";

    public string RequestsCollectionName { get; private set; } = "Requests";

    public string GeneratedSurveyCollectionName { get; private set; } = "GeneratedSurvey";

    public string TeamsCollectionName { get; private set; } = "Teams";

    public string QuestionCollectionName { get; private set; } = "Questions";
    public string NewSurveyCollectionName { get; private set; } = "NewSurvey";


    // here each of the collections is intialized as a type referencing their respective models
    // located in SpaceForceEvaluationAppLibrary/Models.
    public MongoClient Client { get; private set; }
    public IMongoCollection<UserModel> UserCollection { get; private set; }
    public IMongoCollection<SurveyModel> SurveyCollection { get; private set; }
    public IMongoCollection<DailyQuestionsModel> DailyQuestionsCollection { get; private set; }
    public IMongoCollection<ClimateQuestionsModel> ClimateQuestionsCollection { get; private set; }
    public IMongoCollection<FeedbackModel> FeedbackCollection { get; private set; }
    public IMongoCollection<AccoladeModel> AccoladesCollection { get; private set; }

    public IMongoCollection<MonthlyQuestionsModel> MonthlyQuestionsCollection { get; private set; }

    public IMongoCollection<TransferRequestModel> TransferRequestCollection { get; private set; }

    public IMongoCollection<WeeklyQuestionsModel> WeeklyQuestionsCollection { get; private set; }
    public IMongoCollection<TransferRequestModel> TransferRequest { get; }

    public IMongoCollection<RequestsModel> RequestsCollection { get; private set; }

    public IMongoCollection<GeneratedSurveyModel> GeneratedSurvey { get; private set; }

    public IMongoCollection<TeamsModel> TeamsCollection { get; private set; }

    public IMongoCollection<QuestionsModel> QuestionCollection { get; private set; }
    public IMongoCollection<NewSurveyModel> NewSurveyCollection { get; private set; }

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
        FeedbackCollection = _db.GetCollection<FeedbackModel>(FeedbackCollectionName);
        AccoladesCollection = _db.GetCollection<AccoladeModel>(AccoladesCollectionName);
        WeeklyQuestionsCollection = _db.GetCollection<WeeklyQuestionsModel>(WeeklyQuestionsCollectionName);
        MonthlyQuestionsCollection = _db.GetCollection<MonthlyQuestionsModel>(MonthlyQuestionsCollectionName);
        TransferRequestCollection = _db.GetCollection<TransferRequestModel>(TransferRequestCollectionName);
        RequestsCollection = _db.GetCollection<RequestsModel>(RequestsCollectionName);
        GeneratedSurvey = _db.GetCollection<GeneratedSurveyModel>(GeneratedSurveyCollectionName);
        TeamsCollection = _db.GetCollection<TeamsModel>(TeamsCollectionName);
        QuestionCollection = _db.GetCollection<QuestionsModel>(QuestionCollectionName);
        NewSurveyCollection = _db.GetCollection<NewSurveyModel>(NewSurveyCollectionName);

    }
}
