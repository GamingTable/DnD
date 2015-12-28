using DnDService.DataStructures;
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
        public uint uid { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public byte[] avatar { get; set; }
        [DataMember]
        public uint account { get; set; }

        [DataMember]
        public short_entity race { get; set; }
        [DataMember]
        public multientity classes { get; set; }
        [DataMember]
        public List<characteristic> stats { get; set; }
        [DataMember]
        public List<short_entity> gifts { get; set; }
        [DataMember]
        public multiskill skills { get; set; }

        [DataMember]
        public List<short_entity> languages { get; set; }
        [DataMember]
        public List<aptitude> aptitudes { get; set; }
        [DataMember]
        public inventory inventory { get; set; }
        [DataMember]
        public List<short_entity> effects { get; set; }
        [DataMember]
        public spellbook spells_in_mind { get; set; }

        [DataMember]
        public short_entity deity { get; set; }
        [DataMember]
        public char sex { get; set; }
        [DataMember]
        public string background { get; set; }
        [DataMember]
        public string personnality { get; set; }
        [DataMember]
        public string hair { get; set; }
        [DataMember]
        public string eyes { get; set; }
        [DataMember]
        public string skin { get; set; }
        [DataMember]
        public Tuple<uint, category> height { get; set; }
        [DataMember]
        public Tuple<uint, category> weight { get; set; }
        [DataMember]
        public Tuple<uint, category> age { get; set; }

    }
}