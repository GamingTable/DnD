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
        private uint id_character;
        [DataMember]
        private uint id_account;
        [DataMember]
        private string name;
        [DataMember]
        private string class_name;
        [DataMember]
        private uint race_name;
        [DataMember]
        private uint global_level;
    }
}