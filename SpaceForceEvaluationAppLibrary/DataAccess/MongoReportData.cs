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
    
    public MongoReportData (IDbConnection db, IUserData userData, ISurveyData surveyData, IMemoryCache memoryCache)
    {
        _db = db;
        _userData = userData;
        _surveyData = surveyData;
        _memoryCache = memoryCache;
        _reports = db.ReportsCollection;
    }


}
