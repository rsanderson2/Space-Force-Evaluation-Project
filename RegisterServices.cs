namespace SpaceForceEvaluations;

public static class RegisterServices
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        // adds services to the container
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
    }
}
