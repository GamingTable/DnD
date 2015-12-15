using DnDService.DataStructures;
using System.Collections.Generic;
using System;

namespace DnDService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        DAO db;
        private void Initialize()
        {
            db = new DAO();
        }
        public Service1()
        {
            Initialize();
        }

        //Test username & password and return account_id;
        public uint AccountConnection(string user, string pass)
        {

            return db.AccountConnection(user, pass);
        }

        //Create a new account and return account_id;
        public uint AccountCreate(string user, string pass, string mail)
        {
            return db.AccountCreate(user, pass, mail);
        }

        //Try to delete each character of an account and then delete account. Return true if succeed, false if not;
        public bool AccountDelete(int account_id)
        {
            return db.AccountDelete(account_id);
        }

        //Create a new character and return character_id;
        public int CharacterCreate(character player)
        {
            return db.CharacterCreate(player);
        }

        //Try to delete character. Return true if succeed, false if not;
        public bool CharacterDelete(uint character_id)
        {
            return db.CharacterDelete(character_id);
        }

        //Pass the updated character to the DAO and update this character if id exists
        public bool CharacterUpdate(character player)
        {
            return db.CharacterUpdate(player);
        }

        //Return the selected character based on is character_id
        public character GetCharacter(uint character_id)
        {
            return db.GetCharacter(character_id);
        }

        //Return the list of playable characters for this account
        public List<short_character> GetCharacters(uint id_account)
        {
            return db.GetCharacters(id_account);
        }
        //Return a brief list of every race
        public List<short_entity> GetRaceShortList()
        {
            return db.GetRaceShortList();
        }
        //Return a brief list of every class
        public List<short_entity> GetClassShortList()
        {
            return db.GetClassShortList();
        }
        //Return a brief list of every characteristic
        public List<short_entity> GetCharacteristicShortList()
        {
            return db.GetCharacteristicShortList();
        }
        //Return the templates and characteristics
        public template GetTemplate(uint id_template)
        {
            return db.GetTemplate(id_template);
        }
        //Return the list of languages
        public List<short_entity> GetLanguageList()
        {
            return db.GetLanguageList();
        }
        //Return native languages handled by a given race
        public List<short_entity> GetRaceLanguage(uint id_race)
        {
            return db.GetRaceLanguage(id_race);
        }
        //Return the languages spoken by the caracter
        public List<short_entity> GetCharacterLanguage(uint id_character)
        {
            return db.GetCharacterLanguage(id_character);
        }
        //Return the selected class complete information
        public complete_class GetClass(uint id_class)
        {
            return db.GetClass(id_class);
        }
        //Return the selected race complete information
        public complete_race GetRace(uint id_race)
        {
            return db.GetRace(id_race);
        }
        //Return the characteristics corresponding to a template. characteristic type is optionnal
        public List<characteristic> GetCharacteristics(uint id_template, uint id_type = 0)
        {
            return db.GetCharacteristics(id_template, id_type);
        }
        //Return the characteristics corresponding to a character. characteristic type is optionnal
        public List<characteristic> GetCharacterCharacteristics(uint id_character, uint id_type = 0)
        {
            return db.GetCharacterCharacteristics(id_character, id_type);
        }
        //Return the character classes and levels
        public multiclass GetMulticlass(uint id_character)
        {
            return db.GetMulticlass(id_character);
        }
        //Return the list of gods
        public List<short_entity> GetDeities()
        {
            return db.GetDeities();
        }
        //Return the god corresponding to this id
        public short_entity GetDeity(uint deity_id)
        {
            return db.GetDeity(deity_id);
        }
    }
}
