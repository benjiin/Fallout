using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class Menuitem
    {
        public string Description { get; set; }

        public Menuitem(string desc)
        {
            this.Description = desc;
        }
    }
}
