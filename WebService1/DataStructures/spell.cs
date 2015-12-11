using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnDService.DataStructures
{
    [DataContract]
    public class spell
    {
        [DataMember]
        public uint uid { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }

        [DataMember]
        public bool magic_resist { get; set; }
        [DataMember]
        public string duration { get; set; }
        [DataMember]
        public uint target { get; set; }
        [DataMember]
        public string range { get; set; }
        [DataMember]
        public string casting_time { get; set; }
        [DataMember]
        public string component { get; set; }
        [DataMember]
        public string incantation { get; set; }

        [DataMember]
        public Tuple<uint,complete_class> spellLevel_class { get; set; }
        [DataMember]
        public characteristic saving_throw { get; set; }
        [DataMember]
        public wizardry wizardry { get; set; }
        [DataMember]
        public List<template> modifiers { get; set; }
        [DataMember]
        public List<short_entity> effects { get; set; }

    }
}