// ================================================================================================
// This is the file that contains the connections to each of the collections that are necessary 
// to generate and store surveys in the database. This file also contains the tasks necessary,
// to generate and store surveys in the database.
// ================================================================================================
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
namespace SpaceForceEvaluationAppLibrary.DataAccess;

public class MongoGeneratedSurvey : IGeneratedSurveyData
{
    private readonly IMongoCollection<GeneratedSurveyModel> _generatedSurvey;
    private readonly IDbConnection _db;

    // here is the constructor that makes the connection to the database and makes
    // and initializes a connection to the SurveyCollection in the database.

    public MongoGeneratedSurvey(IDbConnection db)
    {
        _generatedSurvey = db.GeneratedSurvey;
    }

    public Task CreateGeneratedSurvey(GeneratedSurveyModel survey)
    {
        return _generatedSurvey.InsertOneAsync(survey);
        //return await GetGeneratedSurveysbyUser(survey.takerID);
    }

    public async Task<GeneratedSurveyModel> GetGeneratedSurvey(string id)
    {
        var results = await _generatedSurvey.FindAsync(u => u.ObjectID == id);
        return results.FirstOrDefault();
    }

    public async Task<List<GeneratedSurveyModel>> GetGeneratedSurveysbyUser(string takerID)
    {
        var results = await _generatedSurvey.FindAsync(u => u.takerID == takerID);
        return results.ToList();
    }
    public Task UpdateGeneratedSurvey(GeneratedSurveyModel generatedSurvey)
    {
        var filter = Builders<GeneratedSurveyModel>.Filter.Eq("ObjectID", generatedSurvey.ObjectID);
        return _generatedSurvey.ReplaceOneAsync(filter, generatedSurvey, new ReplaceOptions { IsUpsert = true });
    }
}