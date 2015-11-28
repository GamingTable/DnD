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
        public uint ui1d { get; set; }
        [DataMember]
        public uint uid2 { get; set; }
        [DataMember]
        public uint uid3 { get; set; }

    }
}