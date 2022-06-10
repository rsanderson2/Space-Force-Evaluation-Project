using Microsoft.Extensions.Caching.Memory;
namespace SpaceForceEvaluationAppLibrary.DataAccess;

public class MongoSurveyData : ISurveyData
{
    private readonly IMongoCollection<SurveyModel> _surveys;
    private readonly IUserData _userData;
    private readonly IDbConnection _db;
    private readonly IMemoryCache _cache;
    private const string CacheName = "SurveyData";

    public MongoSurveyData(IDbConnection db, IUserData userData, IMemoryCache cache)
    {
        _userData = userData;
        _db = db;
        _cache = cache;
        _surveys = db.SurveyCollection;
    }

    public async Task<List<SurveyModel>> GetTodaysSurveys()
    {
        var output = _cache.Get<List<SurveyModel>>(CacheName);
        if (output is null)
        {
            var results = await _surveys.FindAsync(s => s.isArchived == false);
            output = results.ToList();

            _cache.Set(CacheName, output, TimeSpan.FromMinutes(3));
        }
        return output;
    }

    public async Task<List<SurveyModel>> GetAllPastSurveys()
    {
        var output = _cache.Get<List<SurveyModel>>(CacheName);
        if (output is null)
        {
            var results = await _surveys.FindAsync(s => s.isArchived == true);
            output = results.ToList();

            _cache.Set(CacheName, output, TimeSpan.FromMinutes(5));
        }
        return output;
    }

    public async Task<SurveyModel> GetSurvey(string id)
    {
        var results = await _surveys.FindAsync(s => s.Id == id);
        return results.FirstOrDefault();
    }

    public async Task UpdateSurvey(SurveyModel survey)
    {
        await _surveys.ReplaceOneAsync(s => s.Id == survey.Id, survey);
        _cache.Remove(CacheName);
    }

    // this is the big one update later to add all functionality
    public Task CreateSurvey(SurveyModel survey)
    {
        return _surveys.InsertOneAsync(survey);
    }
}
