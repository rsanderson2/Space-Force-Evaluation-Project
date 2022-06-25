// ================================================================================================
// This file is contains the constructor that makes a connection to the reports colllection in
// the database as well as the task associated with the reports collection.
// ================================================================================================
// TODO: Add tasks for report get and set.
using Microsoft.Extensions.Caching.Memory;
namespace SpaceForceEvaluationAppLibrary.DataAccess;

public class MongoReportData
{
    private readonly IMongoCollection<ReportModel> _reports;
    private readonly IUserData _userData;
    private readonly ISurveyData _surveyData;
    private readonly IDbConnection _db;
    private readonly IMemoryCache _memoryCache;
    private const string CacheName = "ReportData";
    
    // here is the constructor for the database connection and intializes a connection to the
    // reports collection in the database.
    public MongoReportData (IDbConnection db, IUserData userData, ISurveyData surveyData, IMemoryCache memoryCache)
    {
        _db = db;
        _userData = userData;
        _surveyData = surveyData;
        _memoryCache = memoryCache;
        _reports = db.ReportsCollection;
    }

    public Task CreateReport(ReportModel report)
    {
        var results = _reports.InsertOneAsync(report);
        return results;
    }

}
