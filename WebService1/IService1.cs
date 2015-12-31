using DnDService.DataStructures;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace DnDService
{
    [ServiceContract]
    public interface IService1
    {
        /////////////// GESTION DES COMPTES ///////////////////
        [OperationContract]
        uint AccountConnection(string user, string pass);

        [OperationContract]
        uint AccountCreate(string user, string pass, string mail);

        [OperationContract]
        bool AccountDelete(uint account_id);

        [OperationContract]
        string GetAccountName(uint account_id);

        [OperationContract]
        string GetAccountEmail(uint account_id);

        [OperationContract]
        uint UpdateAccount(uint uid, string name = null, string pass = null, string email = null);

        /*[OperationContract]
        bool ForgottenPassword(string emailOrUsername);*/


        ////////////// GESTION DES PERSONNAGES /////////////////

        [OperationContract]
        int CharacterCreate(character player);

        [OperationContract]
        bool CharacterDelete(uint character_id);

        [OperationContract]
        bool CharacterUpdate(character player);

        [OperationContract]
        character GetCharacter(uint character_id);

        [OperationContract]
        List<short_character> GetCharacters(uint id_account);


        ////////////// AUTRES ///////////////////
        [OperationContract]
        List<short_entity> GetRaceShortList();

        [OperationContract]
        List<short_entity> GetClassShortList();

        [OperationContract]
        short_entity GetShortClass(uint id_class);

        [OperationContract]
        short_entity GetShortRace(uint id_race);

        [OperationContract]
        List<short_entity> GetCharacteristicShortList();

       [OperationContract]
        template GetTemplate(uint id_template);

        [OperationContract]
        template GetDefaultTemplate();

        [OperationContract]
        List<short_entity> GetLanguageList();

        [OperationContract]
        List<short_entity> GetRaceLanguage(uint id_race);

        [OperationContract]
        List<short_entity> GetCharacterLanguage(uint id_character);

        [OperationContract]
        complete_class GetClass(uint id_class);

        [OperationContract]
        complete_race GetRace(uint id_race);

        [OperationContract]
        List<characteristic> GetTemplateCharacteristics(uint id_template, uint id_type = 0);

        [OperationContract]
        List<characteristic> GetCharacterCharacteristics(uint id_character, uint id_type = 0);

        [OperationContract]
        short_entity GetCharacteristicType(uint id_type);

        [OperationContract]
        List<short_entity> GetCharacteristicTypes();

        [OperationContract]
        characteristic GetCharacteristic(uint id_characteristic);

        [OperationContract]
        List<characteristic> GetCharacteristics(uint id_type = 0);

        [OperationContract]
        aptitude GetAptitude(uint id_aptitude);

        [OperationContract]
        List<short_entity> GetAptitudes(uint id_class = 0);

        [OperationContract]
        List<aptitude> GetCharacterAptitudes(uint id_character);

        [OperationContract]
        multiclass GetMulticlass(uint id_character);

        [OperationContract]
        multientity GetShortMulticlass(uint id_character);

        [OperationContract]
        template GetClassTemplate(uint id_class, uint level);

        [OperationContract]
        List<short_entity> GetDeities();

        [OperationContract]
        short_entity GetDeity(uint deity_id);

        [OperationContract]
        Tuple<uint, category> GetCharacterAge(uint id_character);

        [OperationContract]
        Tuple<uint, category> GetCharacterWeight(uint id_character);

        [OperationContract]
        Tuple<uint, category> GetCharacterHeight(uint id_character);

        [OperationContract]
        category GetAgeCategory(uint id_age_category);

        [OperationContract]
        category GetWeightCategory(uint id_weight_category);

        [OperationContract]
        category GetHeightCategory(uint id_height_category);

        [OperationContract]
        List<short_entity> GetCharacterGifts(uint id_character);
        [OperationContract]
        gift GetGift(uint id_gift);
        [OperationContract]
        List<short_entity> GetGifts();

        [OperationContract]
        short_entity GetEffect(uint id_effect);
        [OperationContract]
        List<short_entity> GetEffects();
        [OperationContract]
        List<short_entity> GetCharacterEffects(uint id_character);
        [OperationContract]
        List<short_entity> GetSkillEffects(uint id_skill);
        [OperationContract]
        List<short_entity> GetSkillConditions(uint id_skill);
        [OperationContract]
        List<short_entity> GetClassEffects(uint id_class);
        [OperationContract]
        List<short_entity> GetRaceEffects(uint id_race);

        [OperationContract]
        skill GetSkill(uint id_skill);
        [OperationContract]
        List<short_entity> GetSkills();
        [OperationContract]
        multiskill GetCharacterSkills(uint id_character);
    }
}
