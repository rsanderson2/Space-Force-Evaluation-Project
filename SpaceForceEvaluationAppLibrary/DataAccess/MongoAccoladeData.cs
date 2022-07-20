namespace SpaceForceEvaluationAppLibrary.DataAccess;

public class MongoAccoladeData : IAccoladeData
{
    private readonly IMongoCollection<AccoladeModel> _accolades;

    public MongoAccoladeData(IDbConnection db)
    {
        _accolades = db.AccoladesCollection;
    }

    public async Task<List<AccoladeModel>> GetSubjectAccolades(string subjectID)
    {
        var results = await _accolades.FindAsync(a => a.subjectID == subjectID);
        return results.ToList();
    }
    
    public async Task<List<AccoladeModel>> GetTeamAccolades(string teamID)
    {
        var results = await _accolades.FindAsync(a => a.teamID == teamID);
        return results.ToList();
    }

    public Task CreateAccolade(AccoladeModel accolade)
    {
        return _accolades.InsertOneAsync(accolade);
    }
}
