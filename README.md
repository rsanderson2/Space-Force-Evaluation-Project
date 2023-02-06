 Space-Force-Evaluation-Project
 NuGet Packages required:
 SpaceForceEvaluations requires:
   1. Microsoft.Identity.Web (using version 1.24.1)
   2. Microsoft.Identity.Web.UI (using version 1.24.1)
 SpaceForceEvaluationAppLibrary requires:
   1. Microsoft.Extensions.Caching.Memory (using version 6.0.0)
   2. Microsoft.Extensions.Configuration.Abstractions (using version 6.0.0)
   3. MongoDB.Driver (using version 2.15.1)


#DB

## DailyQuestions

| Field | Type |
|-------|------|
| `_id` | object |
| `QuestionID` | integer |
| `text` | string |
| `category` | string |
| `questionWeight` | integer |
| `questionPriority` | integer |

# Feedback

| Property | Type |
|---------|--------|
| `_id` | object |
| `feedbackID` | string |
| `userID` | string |
| `name` | string |
| `teamID` | string |
| `supervisor` | boolean |
| `manager` | boolean |
| `accolades` | object |
| `overallScore` | number |
| `leadership` | number |
| `teamplayer` | number |
| `technicalDepth` | number |
| `reviewWeight` | number |

# Surveys

| Field | Type |
| ----- | ---- |
| _id | object |
| takerID | string |
| subjectID | string |
| name | string |
| teamID | string |
| surveyID | integer |
| surveyType | string |
| category | string |
| date | string |
| question | string |
| response | integer |
| freeResponseText | string |

# MonthlyQuestions

| Field | Type |
|-------|-------|
| _id | object |
| QuestionID | integer |
| text | string |
| category | string |
| questionWeight | integer |
| questionPriority | integer |

## Users

| Field name        | Type            |
|-------------------|-----------------|
| _id               | object          |
| ObjectIdentifier  | string          |
| userID            | string          |
| firstName         | string          |
| lastName          | string          |
| email             | string          |
| password          | string          |
| rank              | string          |
| teamID            | string          |
| job               | string          |
| dailyDate         | array of dates  |
| weeklyDate        | array of dates  |
| monthlyDate       | array of dates  |
| surveyHistory     | array of strings|
| reportHistory     | array of strings|
| feedbackTableID   | string          |
| surveyCounter     | integer         |
| flags             | string          |
| subordinates      | array of userIDs|
| superiors         | array of userIDs|

## climateQuestions

| Field | Type | 
| ----- | ---- | 
| `_id` | object | 
| `QuestionID` | integer | 
| `text` | string | 
| `category` | string | 
| `questionWeight` | integer | 
| `questionPriority` | integer |

# Reports

| Field Name | Data Type |
|------------|-----------|
| _id       | object    |
| reportID  | string    |
| reportType | string    |
| reportResult | Array of Strings |

# WeeklyQuestions

| Field         | Type      |
| ------------- |-----------|
| _id           | object    |
| QuestionID    | integer   |
| text          | string    |
| category      | string    |
| questionWeight| integer   |
| questionPriority| integer |

# Accolades

| Field | Type |
|-------|-------|
| _id | object |
| subjectID | string |
| subjectName | string |
| takerID | string |
| takerName | string |
| teamID | string |
| dateReceived | string |
| text | string |
