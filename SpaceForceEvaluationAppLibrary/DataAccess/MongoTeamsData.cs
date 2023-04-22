// ================================================================================================
// This is the file that contains the connections to the User collection in the database, and
// contains the task necessary to get and set users in the database.
// ================================================================================================
using MongoDB.Bson;

namespace SpaceForceEvaluationAppLibrary.DataAccess;

public class MongoTeamsData : ITeamsData
{
    private readonly IMongoCollection<TeamsModel> _teams;
    // here is the constructor that establishes the connections to the
    // Uses collection.
    public MongoTeamsData(IDbConnection db)
    {
        _teams = db.TeamsCollection;
    }
    

    public Task CreateTeam(TeamsModel team)
    {
        return _teams.InsertOneAsync(team);
    }

    public async Task<TeamsModel> GetTeam(string ObjectID)
    {
        var results = await _teams.FindAsync(u => u.ObjectId == ObjectID);
        return results.FirstOrDefault();
    }

    public async Task<List<TeamsModel>> GetTeamsByName(string name)
    {
        var results = await _teams.FindAsync(u => u.name == name);
        return results.ToList();
    }

    public async Task<List<TeamsModel>> GetTeamsByLeader(string leaderID)
    {
        var results = await _teams.FindAsync(u => u.leader == leaderID);
        return results.ToList();
    }

    public async Task<List<TeamsModel>> GetTeamsByCreator(string creatorID)
    {
        var results = await _teams.FindAsync(u => u.creator == creatorID);
        return results.ToList();
    }


    public async Task<List<TeamsModel>> GetTeamsByMember(string memberID)
    {
        var results = await _teams.FindAsync(u => u.members != null && u.members.Contains(memberID));
        return results.ToList();
    }


    public Task UpdateTeam(TeamsModel team)
    {
        var filter = Builders<TeamsModel>.Filter.Eq("ObjectId", team.ObjectId);
        return _teams.ReplaceOneAsync(filter, team, new ReplaceOptions { IsUpsert = true });
    }

    public async Task RemoveTeam(string ObjectID)
    {
        var filter = Builders<TeamsModel>.Filter.Eq("ObjectID", ObjectID);
        var result = await _teams.DeleteOneAsync(filter);
    }

    public async Task RemoveAllTeams()
    {
        await _teams.DeleteManyAsync(new BsonDocument());
    }

}
