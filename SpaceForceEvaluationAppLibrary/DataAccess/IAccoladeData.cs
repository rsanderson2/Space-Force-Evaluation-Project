// ================================================================================================
// This file contains the necessary tasks to access and query data from the the accolades 
// collection in the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IAccoladeData
    {
        Task CreateAccolade(AccoladeModel accolade);
        Task<List<AccoladeModel>> GetSubjectAccolades(string subjectID);
        Task<List<AccoladeModel>> GetTeamAccolades(string teamID);
    }
}