namespace SpaceForceEvaluationAppLibrary.Models;

public class RequestsModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string requestTarget1 { get; set; }
    public string requestTarget2 { get; set; }
    public string requestInitiator { get; set; }
    public string type { get; set; }
    public string value { get; set; }
    public string status { get; set; }
    public string ObjectID { get; set; }
}