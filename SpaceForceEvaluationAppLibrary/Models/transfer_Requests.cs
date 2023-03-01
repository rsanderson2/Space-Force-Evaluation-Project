namespace SpaceForceEvaluationAppLibrary.Models;

public class transfer_RequestsModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string requestTargetID { get; set; }
    public string requestInitiatorID { get; set; }
    public string requestType { get; set; }
    public string value { get; set; }
}
