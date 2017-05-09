using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Menuitem
    {
        public string desc { get; set; }

        public Menuitem(String desc)
        {
            this.desc = desc;
        }

        public void execute() { }

    }
}
