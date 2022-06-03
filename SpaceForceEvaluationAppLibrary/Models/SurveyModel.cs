namespace SpaceForceEvaluationAppLibrary.Models;

public class SurveyModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string surveyID { get; set; }
    public string surveyType { get; set; }
    public DateTime date { get; set; } = DateTime.UtcNow;
    public List<string> questions { get; set; }
    public List<(string, string)> answers { get; set; }
}

