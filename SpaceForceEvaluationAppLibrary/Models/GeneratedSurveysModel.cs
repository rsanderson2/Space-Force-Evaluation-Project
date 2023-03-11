namespace SpaceForceEvaluationAppLibrary.Models;

public class GeneratedSurveyModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public int surveyID { get; set; }
    public string surveyType { get; set; } // Daily, Weekly, Monthly
    public string takerID { get; set; }
    public DateTime date_administered { get; set; }
    public DateTime date_taken { get; set; }
    public List<string> generatedQuestions { get; set; }
    public List<string> injectedQuestions { get; set; }

    public List<string> userReportStats { get; set; }
}

