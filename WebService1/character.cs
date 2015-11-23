using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DnDService
{
    [DataContract]
    public class character
    {
        [DataMember]
        private uint id_character;
        [DataMember]
        private uint id_account;
        [DataMember]
        private uint level;

        [DataMember]
        private string class_name;
        [DataMember]
        private string race_name;
        [DataMember]
        private string name;

        [DataMember]
        private int strength;
        [DataMember]
        private int constitution;
        [DataMember]
        private int dexterity;
        [DataMember]
        private int intelligence;
        [DataMember]
        private int wisdom;
        [DataMember]
        private int charisma;

        [DataMember]
        private int initiative;
        [DataMember]
        private int armor_class;
        [DataMember]
        private int fortitude;
        [DataMember]
        private int reflexe;
        [DataMember]
        private int will;
        [DataMember]
        private int speed;

        public character(uint id_character, uint id_account, uint level, string class_name, string race_name, string name, int strength, int constitution, int dexterity, int intelligence, int wisdom, int charisma, int initiative, int armor_class, int fortitude, int reflexe, int will, int speed)
        {
            this.id_character = id_character;
            this.id_account = id_account;
            this.level = level;
            this.class_name = class_name;
            this.race_name = race_name;
            this.name = name;
            this.strength = strength + (int)(level / 2);
            this.constitution = constitution + (int)(level / 2);
            this.dexterity = dexterity + (int)(level / 2);
            this.intelligence = intelligence + (int)(level / 2);
            this.wisdom = wisdom + (int)(level / 2);
            this.charisma = charisma + (int)(level / 2);
            this.initiative = initiative + (int)(level / 2);
            this.armor_class = armor_class + (int)(level / 2);
            this.fortitude = fortitude + (int)(level / 2);
            this.reflexe = reflexe + (int)(level / 2);
            this.will = will + (int)(level / 2);
            this.speed = speed;
        }
    }
}