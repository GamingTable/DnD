using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DnDService.DataStructures
{
    [DataContract]
    public class wizardry
    {
        [DataMember]
        public uint uid { get; set; }
        [DataMember]
        public bool profane_divine { get; set; }

        [DataMember]
        public string school { get; set; }
        [DataMember]
        public string branch { get; set; }
        [DataMember]
        public string register { get; set; }
    }
}