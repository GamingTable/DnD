using DnDService.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService1.DataStructures
{
    public struct complete_class
    {
        uint uid;
        string name;
        string description;

        string health_progression;
        Template template;
        List<short_entity> effects; 
    }
}