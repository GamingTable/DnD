using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnDService.DataStructures
{
    [DataContract]
    public class multiclass
    {
        [DataMember]
        public uint id_character { get; set; }
        [DataMember]
        public List<Tuple<uint,complete_class>> level_class { get; set; }
        [DataMember]
        public uint global_level
        {
            get
            {
                uint seum = 0;
                foreach(var lc in level_class)
                {
                    seum += lc.Item1;
                }
                return seum;
            }
        }
    }
}