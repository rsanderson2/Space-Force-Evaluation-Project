namespace SpaceForceEvaluationAppLibrary.Models;

public class RequestsModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ObjectID { get; set; }


    // For ADCONTransferRequest: nearest superior commander of user being transfered 
    // For EvaluatorAssignmentRequests: new potential evaluator
    public string requestTarget1 { get; set; } 


    // For ADCONTransferReqeust: 
        // if user requesting transfer is a commander, than none
        // else closest superior commander to user reqeusting transfer
    // For EvaluationAssignmentRequests: superior of user being evaluated,
    public string requestTarget2 { get; set; }


    // For ADCONTransferRequest: userID of person who iniated the request
    // For EvaluationAssignmentRequests: user being evaluated, or their direct/indirect superior
    public string requestInitiator { get; set; }


    public string type { get; set; } // "ADCONTransferRequest", "EvaluationAssignmentRequest"

    // For ADCONTransferRequest: user being transfered
    // For EvaluationAssignmentRequest: user being evaluated
    public string value { get; set; } 


    // For ADCONTransferRequest: "Pending", "Awaiting second response", "Approved", "Denied"
    public string status { get; set; } 


    public string requestTarget { get; set; }
}