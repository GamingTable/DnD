using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService1.DataStructures
{
    public struct complete_race
    {
        uint uid;
        string name;
        string description;

        List<short_entity> innates_languages;
        Template template;
        List<short_entity> effects;
    }
}