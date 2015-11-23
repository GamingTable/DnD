using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DnDService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    /*[ServiceContract]
    public interface IService1
    {
        /////////////// GESTION DES COMPTES ///////////////////
        [OperationContract]
        //Connect an account and return the id of the connected account. If failed, return 0
        uint ConnectAccount(string username, string password);

        [OperationContract]
        //Create an account and return the id of the created account. If failed, return 0
        uint CreateAccount(string username, string password, string email);

        [OperationContract]
        //Delete an account. Return true if succeed, false if failed
        bool DeleteAccount(uint account_id);

        [OperationContract]
        //reset the password for the given email or username. Return true if the email is found, false if not
        bool ForgottenPassword(string emailOrUsername);


        ////////////// GESTION DES PERSONNAGES /////////////////
        [OperationContract]
        //Return a structure with name, race, class and level for all characters linked to an account
        List<Struct_Player> getCharacterList(uint account_id);

        [OperationContract]
        //Select the character and return all the information
        character selectCharacter(uint character_id);

        [OperationContract]
        //Create a new character and return the id of the created character
        uint createCharacter(character c);

        [OperationContract]
        //Delete a character. Return true if succeed, false if failed
        bool deleteCharacter(uint character_id);


        ///////////////// GESTION DES SKILLS, STATS /////////////////
        [OperationContract]
        //Return all skills.
        List<Struct_Skills> getAllSkills();

        [OperationContract]
        //Return all skills of a character.
        List<Struct_Skills> getAllSkills(uint character_id);

        [OperationContract]
        //Update Stats for a given character
        character updateStats(character c);


        //////////////// GESTION DE L'INVENTAIRE /////////////////*/
    
    
    
    [ServiceContract]
    public interface IService1
    {
        /////////////// GESTION DES COMPTES ///////////////////
        [OperationContract]
        uint AccountConnection(string user, string pass);

        [OperationContract]
        uint AccountCreate(string user, string pass, string mail);

        [OperationContract]
        bool AccountDelete(int account_id);

        /*[OperationContract]
        bool ForgottenPassword(string emailOrUsername);*/


        ////////////// GESTION DES PERSONNAGES /////////////////

        [OperationContract]
        int CharacterCreate(character player);

        [OperationContract]
        bool CharacterDelete(uint character_id);

        [OperationContract]
        character GetCharacter(uint character_id);

        [OperationContract]
        List<character> GetCharacters(uint character_id);


        ////////////// AUTRES ///////////////////
        [OperationContract]
        List<short_race> GetRaceShortList();

        [OperationContract]
        List<short_class> GetClassShortList();
    }
}
