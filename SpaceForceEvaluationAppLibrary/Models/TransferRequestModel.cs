namespace SpaceForceEvaluationAppLibrary.Models;

public class TransferRequestModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string userID { get; set; }
    public string old_Superior { get; set; }
    public string new_Superior { get; set; }
}
