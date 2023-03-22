namespace SpaceForceEvaluationAppLibrary.Models;

public class NewSurveyModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string takerID { get; set; }
    public string subjectID { get; set; }
    public string name { get; set; }
    public string teamID { get; set; }
    public int surveyID { get; set; }
    public string surveyType { get; set; } // Daily, Weekly, Monthly
    public List<string> category { get; set; }
    public DateTime date { get; set; } = DateTime.UtcNow;
    public List<string> question { get; set; }
    public int response { get; set; }
    public List<string> freeResponseText { get; set; }
    public string questionType { get; set; }
    public DateTime date_administered { get; set; }
    public DateTime date_taken { get; set; }
}

