using DnDService.DataStructures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnDService
{
    [DataContract]
    public class complete_race
    {
        [DataMember]
        public uint uid;
        [DataMember]
        public string name;
        [DataMember]
        public string description;
        [DataMember]
        public Bitmap illustration;

        [DataMember]
        public List<short_entity> innates_languages;
        [DataMember]
        public template template;
        [DataMember]
        public List<short_entity> effects;
    }
}