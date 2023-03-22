// ================================================================================================
// This is the file that contains the connections to the NewSurveyData collection in the database, and
// contains the task necessary to get and set survey responses in the database.
// ================================================================================================

namespace SpaceForceEvaluationAppLibrary.DataAccess;

public class MongoNewSurveyData : INewSurveyData
{
    private readonly IMongoCollection<NewSurveyModel> _newSurvey;
    private readonly IDbConnection _db;
    public MongoNewSurveyData(IDbConnection db)
    {
        _newSurvey = db.NewSurveyCollection;
    }
    public Task CreateNewSurvey(NewSurveyModel survey)
    {
        return _newSurvey.InsertOneAsync(survey);
        //return await GetGeneratedSurveysbyUser(survey.takerID);
    }
    public async Task<List<NewSurveyModel>> GetNewSurveysbyUser(string takerID)
    {
        var results = await _newSurvey.FindAsync(u => u.takerID == takerID);
        return results.ToList();
    }

}
