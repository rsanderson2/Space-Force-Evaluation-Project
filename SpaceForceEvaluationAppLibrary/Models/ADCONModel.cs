namespace SpaceForceEvaluationAppLibrary.Models;
public class ADCONModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string ObjectIdentifier { get; set; }
    public string subordinateID { get; set; }
    public string superiorID { get; set; }

}