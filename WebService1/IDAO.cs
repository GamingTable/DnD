﻿using DnDService.DataStructures;
using System;
using System.Collections.Generic;

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

        //Synchronize the character instance with the DB
        bool CharacterUpdate(character player);

        //Return the selected character based on the character_id
        character GetCharacter(uint character_id);

        //Return a characters list based on the account_id
        List<short_character> GetCharacters(uint account_id);

        //Return a list with all race name and description
        List<short_entity> GetRaceShortList();

        //Return a list with all class name and description
        List<short_entity> GetClassShortList();

        //Return a list with all the abilities in characteristics
        List<short_entity> GetCharacteristicShortList();

        //Return the template corresponding to a certain id
        template GetTemplate(uint id_template);

        //Return the list of all languages
        List<short_entity> GetLanguageList();

        //Return the list of all languages
        List<short_entity> GetRaceLanguage(uint id_race);

        //Return the list of all languages
        List<short_entity> GetCharacterLanguage(uint id_character);

        //Return the class corresponding to a certain id
        complete_class GetClass(uint id_class);

        //Return the race corresponding to a certain id
        complete_race GetRace(uint id_race);

        //Return the list of characteristics corresponding to a template
        List<characteristic> GetCharacteristics(uint id_template, uint id_type = 0);

        //Return the list of characteristics corresponding to a character
        List<characteristic> GetCharacterCharacteristics(uint id_account, uint id_type = 0);

        //Return the current classes of a character
        multiclass GetMulticlass(uint id_character);

        //Return the list of deities
        List<short_entity> GetDeities();
        //Return the desired deity
        short_entity GetDeity(uint deity_id);

        /// <summary>
        /// CATEGORIES HANDLING (AGE, HEIGHT, WEIGHT)
        /// </summary>
        /// <param name="id_character"></param>
        /// <returns></returns>
        //Return the tuple age and category of the character
        Tuple<uint, category> GetCharacterAge(uint id_character);
        //Return the tuple weight and category of the character
        Tuple<uint, category> GetCharacterWeight(uint id_character);
        //Return the tuple height and category of the character
        Tuple<uint, category> GetCharacterHeight(uint id_character);
        //Return the selected category of age
        category GetAgeCategory(uint id_age_category);
        //Return the selected category of weight
        category GetWeightCategory(uint id_weight_category);
        //Return the selected category of height
        category GetHeightCategory(uint id_height_category);

        /// <summary>
        /// GIFTS HANDLING
        /// </summary>
        /// <param name="id_character"></param>
        /// <returns></returns>
        //Return the list of gifts owned by a character
        List<short_entity> GetCharacterGifts(uint id_character);
        //Return the selected gift
        gift GetGift(uint id_gift);
        //Return the list of every existing gift
        List<short_entity> GetGifts();
    }
}
