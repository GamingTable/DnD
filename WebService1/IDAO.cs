using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDService
{
    interface IDAO
    {
        //Test username & password and return account_id;
        uint AccountConnection(string user, string pass);

        //Create a new account and return account_id;
        uint AccountCreate(string user, string pass, string mail);

        //Try to delete each character of an account and then delete account. Return true if succeed, false if not;
        bool AccountDelete(int account_id);

        //Create a new character and return character_id;
        int CharacterCreate(character player);

        //Try to delete character. Return true if succeed, false if not;
        bool CharacterDelete(uint character_id);

        //Return the selected character based on the character_id
        character GetCharacter(uint character_id);

        //Return a characters list based on the account_id
        List<character> GetCharacters(uint account_id);
    }
}
