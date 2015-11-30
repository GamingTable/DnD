using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace DnDService.DataStructures
{
    [DataContract]
    public class complete_class
    {
        [DataMember]
        public uint uid;
        [DataMember]
        public string name;
        [DataMember]
        public string description;
        [DataMember]
        public byte[] illustration;
        
        [DataMember]
        public string health_progression;
        [DataMember]
        public template template;
        [DataMember]
        public List<short_entity> effects;
    }
}