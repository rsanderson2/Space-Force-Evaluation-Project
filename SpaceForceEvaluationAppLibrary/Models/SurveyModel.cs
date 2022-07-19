namespace SpaceForceEvaluationAppLibrary.Models;

public class SurveyModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string takerID { get; set; }
    public string subjectID { get; set; }
    public string name { get; set; }   
    public string teamID { get; set; }
    public int surveyID { get; set; }
    public string surveyType { get; set; }
    public string category { get; set; }
    public DateTime date { get; set; } = DateTime.UtcNow;
    public string question { get; set; }
    public int response { get; set; }
    public string freeResponseText { get; set; }
}

