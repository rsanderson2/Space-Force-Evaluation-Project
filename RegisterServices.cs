using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using MudBlazor.Services;
using Radzen;
using SpaceForceEvaluationAppLibrary.DataAccess;

namespace SpaceForceEvaluations;

public static class RegisterServices
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        // adds services to the container
        builder.Services.AddMudServices();
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor().AddMicrosoftIdentityConsentHandler();
        builder.Services.AddMemoryCache();
        builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();
        builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));

        // adds the requirement of teamleader to certain functions of pages
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("TeamLeader", policy =>
            {
                policy.RequireClaim("jobTitle", "TeamLeader");
            });
        });
        // Establishes the connection the database and each of the collections in the 
        // database defined by the code in each of the I<>Data files
        builder.Services.AddSingleton<IDbConnection, DbConnection>();
        builder.Services.AddSingleton<ISurveyData, MongoSurveyData>();
        builder.Services.AddSingleton<IUserData, MongoUserData>();
        builder.Services.AddSingleton<IDailyQuestionsData, MongoDailyQuestionsData>();
        builder.Services.AddSingleton<IClimateQuestionsData, MongoClimateQuestionsData>();
        builder.Services.AddSingleton<IAccoladeData, MongoAccoladeData>();
        builder.Services.AddSingleton<IWeeklyQuestionsData, MongoWeeklyQuestionsData>();
        builder.Services.AddSingleton<IMonthlyQuestionsData, MongoMonthlyQuestionsData>();
        builder.Services.AddSingleton<ITransferRequests, MongoTransferRequest>();
        builder.Services.AddSingleton<IRequestsData, MongoRequestsData>();
        builder.Services.AddSingleton<ITeamsData, MongoTeamsData>();
        builder.Services.AddSingleton<IGeneratedSurveyData, MongoGeneratedSurvey>();
        builder.Services.AddSingleton<IQuestionsData, MongoQuestionsData>();
        builder.Services.AddSingleton<INewSurveyData, MongoNewSurveyData>();
        builder.Services.AddSingleton<IEvaluationsData, MongoEvaluationsData>();
        builder.Services.AddSingleton<IADCONData, MongoADCONData>();


    }
}
