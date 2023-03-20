namespace SpaceForceEvaluationAppLibrary.Models;

public class TeamsModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ObjectId { get; set; }

    public String leader { get; set; }

    public List<String> members { get; set; }

    public string name { get; set; }

}