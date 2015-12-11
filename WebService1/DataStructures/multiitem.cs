using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnDService.DataStructures
{
    [DataContract]
    public class multiitem
    {
        [DataMember]
        public uint inventory_id { get; set; }
        [DataMember]
        public List<Tuple<uint, item>> quantity_item { get; set; }
    }
}