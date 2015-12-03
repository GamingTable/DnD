using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDServicePlayer.Pages.Character.Creation
{
    public class property_observable
    {
        public property_observable() { this.members = new ObservableCollection<property_member>(); }
        public string name { get; set; }
        public ObservableCollection<property_member> members { get; set; }
    }
    public class property_member
    {
        public string key { get; set; }
        public List<string> values { get; set; }
    }
}
