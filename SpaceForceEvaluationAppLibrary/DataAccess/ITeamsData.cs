// ================================================================================================
// This is the file that contains the connections to the User collection in the database, and
// contains the task necessary to get and set users in the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface ITeamsData
    {
        Task CreateTeam(TeamsModel team);

        Task<TeamsModel> GetTeam(string ObjectID);

        Task UpdateTeam(TeamsModel team);

        Task RemoveTeam(string ObjectID);

        Task<List<TeamsModel>> GetTeamsByLeader(string leaderID);

        Task<List<TeamsModel>> GetTeamsByMember(string memberID);


        Task<List<TeamsModel>> GetTeamsByName(string name);

        Task RemoveAllTeams();

        Task<List<TeamsModel>> GetTeamsByCreator(string creatorID);

    }
}