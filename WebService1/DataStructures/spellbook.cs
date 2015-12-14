using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnDService.DataStructures
{
    [DataContract]
    public class spellbook
    {
        [DataMember]
        public uint uid { get; set; }
        [DataMember]
        public List<spell> spells { get; set; }
    }
}