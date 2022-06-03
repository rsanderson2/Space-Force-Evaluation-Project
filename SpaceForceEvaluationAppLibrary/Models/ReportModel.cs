namespace SpaceForceEvaluationAppLibrary.Models;

public class ReportModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string reportID { get; set; }
    public string reportType { get; set; }
    public string reportResult { get; set; }
}
