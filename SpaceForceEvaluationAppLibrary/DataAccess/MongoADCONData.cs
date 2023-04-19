
using MongoDB.Bson;
using System;

namespace SpaceForceEvaluationAppLibrary.DataAccess;


public class MongoADCONData : IADCONData
{
    private readonly IMongoCollection<ADCONModel> _ADCON;
    private readonly IMongoCollection<UserModel> _users;

    // here is the constructor that establishes the connections to the
    // Uses collection.
    public MongoADCONData(IDbConnection db)
    {
        _ADCON = db.ADCONCollection;
        _users = db.UserCollection;
    }

    public async Task<UserModel> GetUser(string id)
    {
        var results = await _users.FindAsync(u => u.userID == id);
        return results.FirstOrDefault();
    }

    // returns user record by the parameter id.
    public async Task<ADCONModel> GetADCON(string id)
    {
        
        var results = await _ADCON.FindAsync(u => u.Id == id);
        return results.FirstOrDefault();
        
    }


    public async Task<List<UserModel>> GetDirectSubordinates(UserModel user)
    {
        var results = await _ADCON.FindAsync(u => u.superiorID == user.userID);
        var resultsList = results.ToList();

        List<UserModel> subordinates = new();

        foreach(var subordinateADCON in resultsList)
        {
            subordinates.Add(await GetUser(subordinateADCON.subordinateID));
        }

        return subordinates;
    }


    public async Task<ADCONModel> GetADCONBySuperiorAndSubordinate(string superiorID, string subordinateID)
    {
        var results = await _ADCON.FindAsync(u => u.superiorID == superiorID && u.subordinateID == subordinateID);
        return results.FirstOrDefault();
    }

    public async Task<ADCONModel> GetADCONBySubordinate(string subordinateID)
    {
        var results = await _ADCON.FindAsync(u => u.subordinateID == subordinateID);
        return results.FirstOrDefault();
    }




    public async Task<bool> ADCONTransfer(String currentUserID, String subordinateID)
    {
        UserModel subordinate = await GetUser(subordinateID);
        ADCONModel checkForADCON = await GetADCONBySuperiorAndSubordinate(currentUserID, subordinateID);

        //// 1. check if the subordinate is already a direct subordinate of the currentUser
        if(checkForADCON != null)
        {
            return false;
        }

        // 2. remove subordinate from its old superior
        ADCONModel oldADCON = await GetADCONBySubordinate(subordinateID);
        if(oldADCON != null)
        {
            await RemoveADCON(oldADCON);
        }

        // 3. add subordinate to currentUser
        ADCONModel newADCON = new ADCONModel();
        newADCON.subordinateID = subordinateID;
        newADCON.superiorID = currentUserID;

        await CreateADCON(newADCON);

        return true;
    }





    public async Task<UserModel> GetClosestCommander(string userID) // TODO: test
    {
        UserModel currentUser = await GetUser(userID);

        if (currentUser.role == "Commander" || currentUser.role == "HQ")
        {
            return currentUser;
        }
        else
        {
            ADCONModel adcon = (await GetADCONBySubordinate(userID));

            return await GetClosestCommander(adcon.superiorID);
        }
        
    }


    public async Task<bool> hasDirectADCONOverUser(UserModel potentialSubordinate, UserModel potentialSuperior)
    {
        var directADCONCheck = await GetADCONBySuperiorAndSubordinate(potentialSuperior.userID, potentialSubordinate.userID);

        return directADCONCheck != null;

    }


    public async Task<bool> hasIndirectADCONOverUser(UserModel potentialSubordinate, UserModel potentialSuperior)
    {
        if (potentialSubordinate == null)
        {
            return false;
        }

        ADCONModel adcon = (await GetADCONBySubordinate(potentialSubordinate.userID));    

        if(adcon == null)
        {
            return false;
        }
        if(adcon.superiorID == potentialSuperior.userID)
        {
            return true;
        }

        UserModel nextUser = await GetUser(adcon.superiorID);

        return await hasIndirectADCONOverUser(nextUser, potentialSuperior);
    }


    public Task CreateADCON(ADCONModel ADCON)
    {
        
        return _ADCON.InsertOneAsync(ADCON);
        
    }

    public Task UpdateADCON(ADCONModel ADCON)
    {
        
        var filter = Builders<ADCONModel>.Filter.Eq("Id", ADCON.Id);
        return _ADCON.ReplaceOneAsync(filter, ADCON, new ReplaceOptions { IsUpsert = true });
        
    }
    public async Task RemoveADCON(ADCONModel ADCON)
    {
        var filter = Builders<ADCONModel>.Filter.Eq("Id", ADCON.Id);
        var result = await _ADCON.DeleteOneAsync(filter);
    }


    public async Task RemoveAllADCON()
    {
        // var results = await _requests.FindAsync(u => u.requestInitiator != "");
        var filter = Builders<ADCONModel>.Filter.Empty;
        var result = await _ADCON.DeleteManyAsync(filter);
    }
}
