namespace SpaceForceEvaluationAppLibrary.Models;

public class EvaluationsModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ObjectIdentifier { get; set; }
    public string Id { get; set; }
    public string evaluatorId { get; set; }
    public string userBeingEvaluatedId { get; set; }
    public bool superiorAssigned { get; set; }
}