namespace SpaceForceEvaluationAppLibrary.Models;

public class FeedbackModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string feedbackID { get; set; }
    public string userID { get; set; }
    public string name { get; set; }
    public string teamID { get; set; }
    public bool supervisor { get; set; } = false;
    public bool manager { get; set; } = false;
    public List<string> accolades { get; set; }
    public float overallScore { get; set; }
    public float leadership { get; set; }
    public float teamplayer { get; set; }
    public float technicalDepth { get; set; }
    public float reviewWeight { get; set; }
}
