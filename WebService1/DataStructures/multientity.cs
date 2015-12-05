using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnDService.DataStructures
{
    [DataContract]
    public class multientity
    {
        [DataMember]
        public uint uid { get; set; }
        [DataMember]
        public List<Tuple<uint, short_entity>> values_entities { get; set; }
    }
}