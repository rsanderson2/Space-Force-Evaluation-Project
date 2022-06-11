﻿namespace SpaceForceEvaluationAppLibrary.Models;

public class DailyQuestionsModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public List<Object> Questions { get; set; }

    //public string questionID { get; set; }
    //public string question { get; set; }
    //public float questionWeight { get; set; }
    //public int questionPriority { get; set; }
}

