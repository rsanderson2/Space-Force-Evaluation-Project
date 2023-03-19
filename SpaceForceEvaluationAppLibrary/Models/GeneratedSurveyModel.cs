namespace SpaceForceEvaluationAppLibrary.Models;

public class GeneratedSurveyModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string ObjectID { get; set; }
    public string surveyID { get; set; }
    public string surveyType { get; set; } // Daily, Weekly, Monthly
    public string takerID { get; set; }
    public DateTime date_administered { get; set; }
    public DateTime date_taken { get; set; }
    public List<string> generatedQuestions { get; set; }
    public List<string> injectedQuestions { get; set; }

    public List<string> userReportStats { get; set; }
}



/*
     
public class QuestionsResponseModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string questionID { get; set; }

    public string surveyID { get; set; }

    public string response { get; set; } // NOTE: I think that we could just use this, and then when we type="likert" we know to cast it as an int
}

 * */