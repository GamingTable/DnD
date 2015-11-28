using System.Runtime.Serialization;

namespace DnDService.DataStructures
{
    [DataContract]
    public class Template
    {
        [DataMember]
        public uint uid { get; set; }

    }
}