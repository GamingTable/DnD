using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnDService
{
    [DataContract]
    public class short_character
    {
        [DataMember]
        public uint id_character;
        [DataMember]
        public uint id_account;
        [DataMember]
        public string name;
        [DataMember]
        public string class_name;
        [DataMember]
        public uint race_name;
        [DataMember]
        public uint global_level;
    }
}