using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DnDService.DataStructures
{
    [DataContract]
    public class template
    {
        [DataMember]
        public uint uid { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }

        [DataMember]
        public List<characteristic> characteristics { get; set; }

    }
}