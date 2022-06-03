using SpaceForceEvaluationAppLibrary.DataAccess;

namespace SpaceForceEvaluations;

public static class RegisterServices
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        // adds services to the container
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddMemoryCache();

        //builder.Services.AddSingleton<IDbConnection, DbConnection>();
        builder.Services.AddSingleton<IMongoSurveyData, MongoSurveyData>();
        builder.Services.AddSingleton<IUserData, MongoUserData>();
    }
}
