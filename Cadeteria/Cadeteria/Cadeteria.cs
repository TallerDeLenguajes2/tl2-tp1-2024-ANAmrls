using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria
{
    internal class Cadeteria
    {
        private string _name;
        private string _phone;
        private List<Cadete> _cadetes;

        public Cadeteria(string name, string phone)
        {
            _name = name;
            _phone = phone;
            _cadetes = new List<Cadete>();
        }

        public string Name { get => _name; set => _name = value; }
        public string Phone { get => _phone; set => _phone = value; }
        internal List<Cadete> Cadetes { get => _cadetes; set => _cadetes = value; }
    }
}
