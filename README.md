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
