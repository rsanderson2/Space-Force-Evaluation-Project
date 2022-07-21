using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using SpaceForceEvaluationAppLibrary.DataAccess;

namespace SpaceForceEvaluations;

public static class RegisterServices
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        // adds services to the container
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
    }
}
