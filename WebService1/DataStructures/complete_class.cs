﻿using DnDService.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebService1.DataStructures
{
    [DataContract]
    public struct complete_class
    {
        [DataMember]
        public uint uid;
        [DataMember]
        public string name;
        [DataMember]
        public string description;

        [DataMember]
        public string health_progression;
        [DataMember]
        public Template template;
        [DataMember]
        public List<short_entity> effects; 
    }
}