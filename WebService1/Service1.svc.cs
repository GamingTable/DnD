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
        public bool AccountDelete(uint account_id)
        {
            return db.AccountDelete(account_id);
        }

        //Return the selected username
        public string GetAccountName(uint account_id)
        {
            return db.GetAccountName(account_id);
        }

        //Return the selected user email
        public string GetAccountEmail(uint account_id)
        {
            return db.GetAccountEmail(account_id);
        }

        //Update the current account
        public uint UpdateAccount(uint uid, string name = null, string pass = null, string email = null)
        {
            return db.UpdateAccount(uid, name, pass, email);
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
        //Return the default lvl1 template
        public template GetDefaultTemplate()
        {
            return db.GetDefaultTemplate();
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
        //Return the selected class in a short_entity
        public short_entity GetShortClass(uint id_class)
        {
            return db.GetShortClass(id_class);
        }
        //Return the selected race in a short_entity
        public short_entity GetShortRace(uint id_race)
        {
            return db.GetShortRace(id_race);
        }
        //Return the characteristics corresponding to a template. characteristic type is optionnal
        public List<characteristic> GetTemplateCharacteristics(uint id_template, uint id_type = 0)
        {
            return db.GetTemplateCharacteristics(id_template, id_type);
        }
        //Return the characteristics corresponding to a character. characteristic type is optionnal
        public List<characteristic> GetCharacterCharacteristics(uint id_character, uint id_type = 0)
        {
            return db.GetCharacterCharacteristics(id_character, id_type);
        }
        //Return the type of characteristic corresponding to a certain id
        public short_entity GetCharacteristicType(uint id_type)
        {
            return db.GetCharacteristicType(id_type);
        }
        //Return the list of all types of characteristics
        public List<short_entity> GetCharacteristicTypes()
        {
            return db.GetCharacteristicTypes();
        }
        //Return the characteristic corresponding to a certain id
        public characteristic GetCharacteristic(uint id_characteristic)
        {
            return db.GetCharacteristic(id_characteristic);
        }
        //Return the list of all characteristics, filtered or not by type
        public List<characteristic> GetCharacteristics(uint id_type = 0)
        {
            return db.GetCharacteristics(id_type);
        }
        //Return the aptitude corresponding to a certain id
        public aptitude GetAptitude(uint id_aptitude)
        {
            return db.GetAptitude(id_aptitude);
        }
        //Return the list of all aptitudes, filtered or not by class
        public List<short_entity> GetAptitudes(uint id_class = 0)
        {
            return db.GetAptitudes(id_class);
        }
        //Return the list of all aptitudes corresponding to a certain character
        public List<aptitude> GetCharacterAptitudes(uint id_character)
        {
            return db.GetCharacterAptitudes(id_character);
        }
        //Return the character classes and levels
        public multiclass GetMulticlass(uint id_character)
        {
            return db.GetMulticlass(id_character);
        }
        //A multiclass with short_entities instead of complete_classes
        public multientity GetShortMulticlass(uint id_character)
        {
            return db.GetShortMulticlass(id_character);
        }
        //Return the template corresponding to a level of class
        public template GetClassTemplate(uint id_class, uint level)
        {
            return db.GetClassTemplate(id_class, level);
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
        //Return the age and its category corresponding to this character
        public Tuple<uint, category> GetCharacterAge(uint id_character)
        {
            return db.GetCharacterAge(id_character);
        }
        //Return the weight and its category corresponding to this character
        public Tuple<uint, category> GetCharacterWeight(uint id_character)
        {
            return db.GetCharacterWeight(id_character);
        }
        //Return the height and its category corresponding to this character
        public Tuple<uint, category> GetCharacterHeight(uint id_character)
        {
            return db.GetCharacterHeight(id_character);
        }
        //Return the age category corresponding to this id
        public category GetAgeCategory(uint id_age_category)
        {
            return db.GetAgeCategory(id_age_category);
        }
        //Return the weight category corresponding to this id
        public category GetWeightCategory(uint id_weight_category)
        {
            return db.GetWeightCategory(id_weight_category);
        }
        //Return the height category corresponding to this id
        public category GetHeightCategory(uint id_height_category)
        {
            return db.GetHeightCategory(id_height_category);
        }
        //Return the list of every gift corresponding to a character
        public List<short_entity> GetCharacterGifts(uint id_character)
        {
            return db.GetCharacterGifts(id_character);
        }
        //Return the actual gift object
        public gift GetGift(uint id_gift)
        {
            return db.GetGift(id_gift);
        }
        //Return the full list of every gift
        public List<short_entity> GetGifts()
        {
            return db.GetGifts();
        }

        public short_entity GetEffect(uint id_effect)
        {
            return db.GetEffect(id_effect);
        }

        public List<short_entity> GetEffects()
        {
            return db.GetEffects();
        }

        public List<short_entity> GetCharacterEffects(uint id_character)
        {
            return db.GetCharacterEffects(id_character);
        }
        public List<short_entity> GetSkillEffects(uint id_skill)
        {
            return db.GetSkillEffects(id_skill);
        }

        public List<short_entity> GetSkillConditions(uint id_skill)
        {
            return db.GetSkillConditions(id_skill);
        }

        public List<short_entity> GetClassEffects(uint id_class)
        {
            return db.GetClassEffects(id_class);
        }

        public List<short_entity> GetRaceEffects(uint id_race)
        {
            return db.GetRaceEffects(id_race);
        }
        public skill GetSkill(uint id_skill)
        {
            return db.GetSkill(id_skill);
        }
        public List<short_entity> GetSkills()
        {
            return db.GetSkills();
        }
        public multiskill GetCharacterSkills(uint id_character)
        {
            return db.GetCharacterSkills(id_character);
        }
    }
}
