using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnDService.DataStructures
{
    [DataContract]
    public class inventory
    {
        [DataMember]
        uint uid { get; set; }
        [DataMember]
        uint character { get; set; }

        [DataMember]
        multiitem items { get; set; }
        [DataMember]
        List<spellbook> spellbooks { get; set; }
        [DataMember]
        multimoney purse { get; set; }
    }
}