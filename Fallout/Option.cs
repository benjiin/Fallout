using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Option 
    {
        public string MenuChoice{ get; set; }
        public char Index { get; set; }

        public Option(char number, string content)
        {
            this.Index = number;
            this.MenuChoice = content;
        }
    }
}
