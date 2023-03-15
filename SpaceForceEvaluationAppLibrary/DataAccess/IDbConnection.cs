// ================================================================================================
// This file contains the connection made to the database refrenced from the connection string
// located in "appseting.json" under the section labeled "MongoDB". This file also contains 
// the connection made to each of the collections in the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IDbConnection
    {
        MongoClient Client { get; }
        IMongoCollection<ClimateQuestionsModel> ClimateQuestionsCollection { get; }
        string ClimateQuestionsCollectionName { get; }
        IMongoCollection<DailyQuestionsModel> DailyQuestionsCollection { get; }
        string DailyQuestionsCollectionName { get; }
        string DbName { get; }
        IMongoCollection<FeedbackModel> FeedbackCollection { get; }
        string FeedbackCollectionName { get; }
        IMongoCollection<SurveyModel> SurveyCollection { get; }
        string SurveyCollectionName { get; }
        IMongoCollection<UserModel> UserCollection { get; }
        string UserCollectionName { get; }
        IMongoCollection<AccoladeModel> AccoladesCollection { get; }
        string AccoladesCollectionName { get; }
        IMongoCollection<WeeklyQuestionsModel> WeeklyQuestionsCollection { get; }
        string WeeklyQuestionsCollectionName { get; }

        IMongoCollection<MonthlyQuestionsModel> MonthlyQuestionsCollection { get; }
        string MonthlyQuestionsCollectionName { get; }

        IMongoCollection<RequestsModel> RequestsCollection { get; }
        string RequestsCollectionName { get; }

        IMongoCollection<TransferRequestModel> TransferRequest { get; }
        string TransferRequestCollectionName { get; }
    }
}