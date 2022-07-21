// =======================================================================================
// This helper grabs the authentication token from AzureB2C then checks the database
// for that user before returning the user model pertaining to the user
// =======================================================================================
using Microsoft.AspNetCore.Components.Authorization;
namespace SpaceForceEvaluations.Helpers;

public static class AuthenticationStateProviderHelpers
{
    public static async Task<UserModel> GetUserFromAuth(
        this AuthenticationStateProvider provider,
        IUserData userData)
    {
        var authState = await provider.GetAuthenticationStateAsync();
        string objectId = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("objectidentifier"))?.Value;
        return await userData.GetUser(objectId);
    }
}
