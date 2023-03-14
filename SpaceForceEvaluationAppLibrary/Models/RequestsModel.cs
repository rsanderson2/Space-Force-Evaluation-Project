namespace SpaceForceEvaluationAppLibrary.Models;

public class RequestsModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string requestTarget { get; set; }
    public string requestInitiator { get; set; }
    public string type { get; set; }
    public string value { get; set; }
}