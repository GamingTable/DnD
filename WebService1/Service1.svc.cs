using DnDService.DataStructures;
using System.Collections.Generic;

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

        //Return the selected character based on is character_id
        public character GetCharacter(uint character_id)
        {
            return db.GetCharacter(character_id);
        }

        public List<short_character> GetCharacters(uint account_id)
        {
            return db.GetCharacters(account_id);
        }
        public List<short_entity> GetRaceShortList()
        {
            return db.GetRaceShortList();
        }
        public List<short_entity> GetClassShortList()
        {
            return db.GetClassShortList();
        }

        public List<short_entity> GetCharacteristicShortList()
        {
            return db.GetCharacteristicShortList();
        }
        //Return the templates and characteristics
        public template GetTemplate(uint id_template)
        {
            return db.GetTemplate(id_template);
        }

        public List<short_entity> GetLanguageList()
        {
            return db.GetLanguageList();
        }

        public List<short_entity> GetRaceLanguage(uint id_race)
        {
            return db.GetRaceLanguage(id_race);
        }

        public List<short_entity> GetCharacterLanguage(uint id_character)
        {
            return db.GetCharacterLanguage(id_character);
        }

        public complete_class GetClass(uint id_class)
        {
            return new complete_class();
        }

        public complete_race GetRace(uint id_race)
        {
            return db.GetRace(id_race);
        }
    }
}
