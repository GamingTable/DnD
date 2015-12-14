using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnDService.DataStructures
{
    [DataContract]
    public class multimoney
    {
        [DataMember]
        public uint inventory { get; set; }
        [DataMember]
        public List<Tuple<uint, money>> pieces_money { get; set; }
    }
}