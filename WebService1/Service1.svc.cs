using DnDService.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WebService1.DataStructures;

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
    }
}
