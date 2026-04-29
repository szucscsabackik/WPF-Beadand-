using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    public class Table
    {
        private string type;
        private string name;
        private bool isActive;
        private int spaces;

        public Table(string type, string name, bool isActive, int spaces)
        {
            this.Type = type;
            this.name = name;
            this.isActive = isActive;
            this.spaces = spaces;
        }

        public string Type { get => type; set => type = value; }
    }
}
