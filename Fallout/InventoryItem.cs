using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    class InventoryItem
    {
        public Stuff Details { get; set; }
        public int Quantity { get; set; }

        public InventoryItem(Stuff details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
