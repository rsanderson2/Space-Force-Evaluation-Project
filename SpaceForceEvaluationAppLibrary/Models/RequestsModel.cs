namespace SpaceForceEvaluationAppLibrary.Models;

public class RequestsModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ObjectID { get; set; }


    // For ADCONTransferRequest: nearest superior commander of user being transfered 
    // For EvaluatorAssignmentRequests: new potential evaluator
    // For OPCONTransferRequest: direct superior (person with direct ADCON) of user being outsourced
    public string requestTarget1 { get; set; } // TODO: replace with List<string> requestTargets after demo


    // For ADCONTransferReqeust: 
        // if user requesting transfer is a commander, than none
        // else closest superior commander to user reqeusting transfer

    // For EvaluationAssignmentRequests: superior of user being evaluated,

    // For OPCONTransferRequest:
        // team ID of team that the user is being outsourced to. 
    public string requestTarget2 { get; set; } // TODO: replace with List<string> requestTargets after demo


    // For ADCONTransferRequest: userID of person who iniated the request
    // For EvaluationAssignmentRequests: user being evaluated, or their direct/indirect superior
    // For OPCONTransferRequests: leader of team user is being outsourced to                  OLD: teamID of team that the user is being outsourced to
    public string requestInitiator { get; set; }


    public string type { get; set; } // "ADCONTransferRequest", "EvaluationAssignmentRequest", "SuperiorAssignedEvaluationRequest", "OPCONOutsourceRequest"



    // For ADCONTransferRequest: user being transfered
    // For EvaluationAssignmentRequest: user being evaluated
    // For OPCONTransferRequests: user being outsourced to team. 
    public string value { get; set; } // TODO: replace with List<string> values after demo



    // For SuperiorAssignedEvaluationRequest: values[0] = userID of potential evaluator, values[1] = user being evaluated
    // For EvaluationAssignmentRequest: values[0] = userID of potential evaluator, values[1] = user being evaluated

    // For ADCONTransferRequest: values[0] = user being transfered
    // For EvaluationAssignmentRequest: values[0] = user being evaluated
    // For OPCONTransferRequests: values[0] = user being outsourced to team, values[1] = team ID of team that the user is being outsourced to. 
    public List<string> values { get; set; }


    // For ADCONTransferRequest: "Pending", "Awaiting second response", "Approved", "Denied"
    public string status { get; set; } 


    public string requestTarget { get; set; }

    public List<string> requestRecipiants { get; set; }

    public List<string> requestRespondents { get; set; }
}