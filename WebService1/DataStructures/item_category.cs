using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnDService.DataStructures
{
    [DataContract]
    public class item_category
    {
        [DataMember]
        public uint uid;
        [DataMember]
        public string name;
        [DataMember]
        public string description;
        [DataMember]
        item_category parent;
    }
}