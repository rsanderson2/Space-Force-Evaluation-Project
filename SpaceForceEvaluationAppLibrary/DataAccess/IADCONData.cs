// ================================================================================================
// This is the file that contains the connections to the User collection in the database, and
// contains the task necessary to get and set users in the database.
// ================================================================================================
namespace SpaceForceEvaluationAppLibrary.DataAccess
{
    public interface IADCONData
    {
        Task CreateADCON(ADCONModel user);
        Task<ADCONModel> GetADCON(string id);

        Task<UserModel> GetClosestCommander(string userID);

        Task<bool> hasDirectADCONOverUser(UserModel potentialSubordinate, UserModel potentialSuperior);

        Task<bool> hasIndirectADCONOverUser(UserModel potentialSubordinate, UserModel potentialSuperior);

        Task<bool> ADCONTransfer(String currentUserID, String subordinateID);

        Task UpdateADCON(ADCONModel user);

        Task<List<UserModel>> GetDirectSubordinates(UserModel user);

        Task<ADCONModel> GetADCONBySubordinate(string subordinateID);

        Task RemoveADCON(ADCONModel ADCON);

        Task RemoveAllADCON();

        Task<UserModel> GetDirectSuperior(string userId);

        Task<List<String>> GetDirectSubordinatesIDs(String userID);
    }
}