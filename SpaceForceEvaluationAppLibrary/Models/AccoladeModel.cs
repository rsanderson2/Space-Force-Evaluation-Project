namespace SpaceForceEvaluationAppLibrary.Models;

public class AccoladeModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string subjectID { get; set; }
    public string subjectName { get; set; }
    public string takerID { get; set; }
    public string takerName { get; set; }
    public string teamID { get; set; }
    public DateTime dateReceived { get; set; } = DateTime.UtcNow;
    public string text { get; set; }
}
