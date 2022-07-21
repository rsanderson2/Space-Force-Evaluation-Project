// ================================================================================================
// This file contains the necessary tasks to access and query data from the the accolades 
// collection in the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess;

public class MongoAccoladeData : IAccoladeData
{
    private readonly IMongoCollection<AccoladeModel> _accolades;

    // constructor that creates the connection to the accolades collection
    // in the database
    public MongoAccoladeData(IDbConnection db)
    {
        _accolades = db.AccoladesCollection;
    }

    // task that returns a list of accolade models by the subjectID
    // i.e. the person that the accolade is pertaining to, not the person
    // who gave the accolade.
    public async Task<List<AccoladeModel>> GetSubjectAccolades(string subjectID)
    {
        var results = await _accolades.FindAsync(a => a.subjectID == subjectID);
        return results.ToList();
    }

    // task that returns a list of accolade models by teamID
    public async Task<List<AccoladeModel>> GetTeamAccolades(string teamID)
    {
        var results = await _accolades.FindAsync(a => a.teamID == teamID);
        return results.ToList();
    }

    // task that creates a new accolade in the accolades collection.
    public Task CreateAccolade(AccoladeModel accolade)
    {
        return _accolades.InsertOneAsync(accolade);
    }
}
