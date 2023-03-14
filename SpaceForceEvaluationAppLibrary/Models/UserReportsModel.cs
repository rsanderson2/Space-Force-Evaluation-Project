namespace SpaceForceEvaluationAppLibrary.Models;

public class UserReportModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string userReportID { get; set; }
    public string category { get; set; }
    public int score { get; set; }
}
