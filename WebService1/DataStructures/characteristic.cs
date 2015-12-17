using System.Runtime.Serialization;

namespace DnDService.DataStructures
{
    [DataContract]
    public class characteristic
    {
        [DataMember]
        public uint uid { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string abreviation { get; set; }
        [DataMember]
        public short_entity type { get; set; }

        [DataMember]
        public int value { get; set; }
        [DataMember]
        public int modifier { get; set; }
        
    }
}