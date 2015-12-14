using System.Runtime.Serialization;

namespace DnDService
{
    [DataContract]
    public class short_character
    {
        [DataMember]
        public uint uid { get; set; }
        [DataMember]
        public uint account { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string class_name { get; set; }
        [DataMember]
        public string race_name { get; set; }
        [DataMember]
        public uint global_level { get; set; }
        [DataMember]
        public byte[] avatar { get; set; }
    }
}