// ================================================================================================
// This file contains all tasks that read and write data to the uestions collection in
// the database.
// ================================================================================================

namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IQuestionsData
    {
        Task<List<QuestionsModel>> GetQuestionsByCategory(string category);
    }
}