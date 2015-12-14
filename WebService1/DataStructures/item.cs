using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnDService.DataStructures
{
    [DataContract]
    public class item
    {
        [DataMember]
        public uint uid { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public item_category category { get; set; }

        [DataMember]
        public template template { get; set; }
        [DataMember]
        public spell spell { get; set; }

        [DataMember]
        public bool equipped { get; set; }
        [DataMember]
        public short_entity language { get; set; }
        [DataMember]
        public attack attack { get; set; }

        [DataMember]
        public Tuple<uint,category> height { get; set; }
        [DataMember]
        public Tuple<uint, category> weight { get; set; }
    }
}