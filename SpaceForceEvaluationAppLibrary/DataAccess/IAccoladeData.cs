namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IAccoladeData
    {
        Task CreateAccolade(AccoladeModel accolade);
        Task<List<AccoladeModel>> GetSubjectAccolades(string subjectID);
        Task<List<AccoladeModel>> GetTeamAccolades(string teamID);
    }
}