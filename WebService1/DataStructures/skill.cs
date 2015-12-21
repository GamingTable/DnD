using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnDService.DataStructures
{
    [DataContract]
    public class skill
    {
        [DataMember]
        public uint uid { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }

        [DataMember]
        public bool innate { get; set; }
        [DataMember]
        public bool teachable { get; set; }

        [DataMember]
        public characteristic key_ability { get; set; }
        [DataMember]
        public List<short_entity> classes { get; set; }

        [DataMember]
        public template modifiers { get; set; }
        [DataMember]
        public List<short_entity> conditions { get; set; }
        [DataMember]
        public List<short_entity> effects { get; set; }
    }
}