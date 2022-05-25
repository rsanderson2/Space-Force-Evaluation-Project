namespace SpaceForceEvaluationAppLibrary.Models;

public class MonthlyQuestionsModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string questionID { get; set; }
    public string question { get; set; }
    public float questionWeight { get; set; }
    public int questionPriority { get; set; }
}
