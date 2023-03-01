// ================================================================================================
// This is the file that contains the connections to each of the collections that are necessary 
// to generate and store surveys in the database. This file also contains the tasks necessary,
// to generate and store surveys in the database.
// ================================================================================================
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
namespace SpaceForceEvaluationAppLibrary.DataAccess;

public class MongoTransferRequest : ITransferRequests
{
    private readonly IMongoCollection<TransferRequestModel> _transferRequest;
    private readonly IDbConnection _db;

    // here is the constructor that makes the connection to the database and makes
    // and initializes a connection to the SurveyCollection in the database.
    public MongoTransferRequest(IDbConnection db)
    {
        _transferRequest = db.TransferRequest;
    }

    public async Task<TransferRequestModel> GetRequest(string id)
    {
        var results = await _transferRequest.FindAsync(u => u.Id == id);
        return results.FirstOrDefault();
    }


}
