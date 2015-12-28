using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace DnDService.DataStructures
{
    [DataContract]
    public class complete_class
    {
        [DataMember]
        public uint uid { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public byte[] illustration { get; set; }

        [DataMember]
        public string health_progression { get; set; }
        [DataMember]
        public List<short_entity> effects { get; set; }
        [DataMember]
        public List<spell> spells { get; set; }
        [DataMember]
        public bool magical { get; set; }
    }
}