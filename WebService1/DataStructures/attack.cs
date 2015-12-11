using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnDService.DataStructures
{
    [DataContract]
    public class attack
    {
        [DataMember]
        public uint uid { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string damage { get; set; }
        [DataMember]
        public string bonus { get; set; }
        [DataMember]
        public string critic { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public uint ammo { get; set; }
        [DataMember]
        public uint range { get; set; }

    }
}