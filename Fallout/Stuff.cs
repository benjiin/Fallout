using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    [Serializable()]
    class Stuff
    {
        public string  Name { get; set; }
        public double Value { get; set; }
        public double Weight { get; set; }
        public int DropChance { get; set; }
        public int Amount { get; set; }
        public int ID { get; set; }
        public int HealthRestore { get; set; }
        public int Radiation { get; set; }
        public int RadiationRestore { get; set; }

        public const int POTION = 4;
    }
}
