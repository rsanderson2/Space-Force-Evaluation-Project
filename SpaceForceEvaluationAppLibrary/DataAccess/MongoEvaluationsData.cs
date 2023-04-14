// ================================================================================================
// This is the file that contains the connections to the User collection in the database, and
// contains the task necessary to get and set users in the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess;

public class MongoEvaluationsData : IEvaluationsData
{
    private readonly IMongoCollection<EvaluationsModel> _evaluations;
    // here is the constructor that establishes the connections to the
    // Uses collection.
    public MongoEvaluationsData(IDbConnection db)
    {
        _evaluations = db.EvaluationsCollection;
    }
    

    public Task CreateEvaluation(EvaluationsModel evaluation)
    {
        return _evaluations.InsertOneAsync(evaluation);
    }

    public async Task<EvaluationsModel> GetEvaluation(string id)
    {
        var results = await _evaluations.FindAsync(u => u.ObjectIdentifier == id);
        return results.FirstOrDefault();
    }

    public async Task<List<EvaluationsModel>> GetByEvaluator(string userID)
    {
        var results = await _evaluations.FindAsync(u => u.evaluatorId == userID);
        return results.ToList();
    }

    public async Task<List<EvaluationsModel>> GetByUserBeingEvaluated(string userID)
    {
        var results = await _evaluations.FindAsync(u => u.userBeingEvaluatedId == userID);
        return results.ToList();
    }

    public async Task<EvaluationsModel> GetByEvaluatorAndUserBeingEvaluated(string evaluatorID, string userBeingEvaluatedID)
    {
        var results = await _evaluations.FindAsync(u => u.userBeingEvaluatedId == userBeingEvaluatedID &&
                                                        u.evaluatorId == evaluatorID);
        return results.FirstOrDefault();
    }

    public Task UpdateEvaluation(EvaluationsModel evaluation)
    {
        var filter = Builders<EvaluationsModel>.Filter.Eq("ObjectIdentifier", evaluation.ObjectIdentifier);
        return _evaluations.ReplaceOneAsync(filter, evaluation, new ReplaceOptions { IsUpsert = true });
    }

    public async Task<List<EvaluationsModel>> GetAllEvaluations()
    {
        var results = await _evaluations.FindAsync(u => u.userBeingEvaluatedId != "");
        return results.ToList();
    }

    public async Task RemoveEvaluation(string ObjectID)
    {
        var filter = Builders<EvaluationsModel>.Filter.Eq("ObjectID", ObjectID);
        var result = await _evaluations.DeleteOneAsync(filter);
    }

    public async Task RemoveAllEvaluations()
    {
        var filter = Builders<EvaluationsModel>.Filter.Empty;
        var result = await _evaluations.DeleteManyAsync(filter);
    }

    public async Task<bool> CheckIfEvaluationExist(EvaluationsModel evaluation)
    {
        var queryResponse = await _evaluations.FindAsync(u =>
                                                        u.userBeingEvaluatedId == evaluation.userBeingEvaluatedId &&
                                                        u.evaluatorId == evaluation.evaluatorId);
        var results = queryResponse.ToList();

        return (results.Count > 0);
    }

    public async Task<List<String>> GetSelfAllAssignedEvaluatorsIDs(string userID)
    {
        var results = await _evaluations.FindAsync(u => u.userBeingEvaluatedId == userID && 
                                                        u.superiorAssigned == false);

        var resultsList = results.ToList();

        List<String> evaluatorsIDs = new();

        foreach (var evaluation in resultsList)
        {
            evaluatorsIDs.Add(evaluation.evaluatorId);
        }
        return evaluatorsIDs;
    }

}
