namespace SpaceForceEvaluationAppLibrary.Models;

public class QuestionsModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string questionID { get; set; }
    public string inputType { get; set; } // Likert, Free-response
    public string type { get; set; } // evaluation, climate. NOTE: if evaluation, then, it is a question pertaining to a certain user specified by the field subjectID
    public string subjectID { get; set; } // NOTE: if type==evaluation, then this will be the subject of the evaluation question, else null. 
    public string question { get; set; }
    public string category { get; set; }
    public string response { get; set; } // NOTE: I think that we could just use this, and then when we type="likert" we know to cast it as an int
}