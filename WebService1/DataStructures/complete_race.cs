using DnDService.DataStructures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnDService.DataStructures
{
    [DataContract]
    public class complete_race
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
        public List<short_entity> innates_languages { get; set; }
        [DataMember]
        public template template { get; set; }
        [DataMember]
        public List<short_entity> effects { get; set; }
    }
}