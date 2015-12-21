using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnDService.DataStructures
{
    [DataContract]
    public class multiskill
    {
        [DataMember]
        public uint id_character { get; set; }
        [DataMember]
        public List<Tuple<uint, skill>> md_skill { get; set; }
    }
}