using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnDService.DataStructures
{
    [DataContract]
    public class gift
    {
        [DataMember]
        public uint uid { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string category { get; set; }
        [DataMember]
        public string conditions { get; set; }
        [DataMember]
        public string advantages { get; set; }
        [DataMember]
        public string specials { get; set; }

    }
}