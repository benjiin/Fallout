using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout
{
    [Serializable()]
    class Dice
    {
        /* 
         * Meine erste Klasse die ich erstellt habe und von der das Spiel am meisten profiliert.
         * 
         * Anstatt jedes mal einen neuen Random Wurf zu schreiben (und sich zu verschreiben) nehme ich einfach den Würfel
         * 
         * In meiner Welt kann es so auch ungerade komplizierte Würfel geben. Mit "eyes +1" lege ich fest das der Würfel (z.B. W6) Augenzahl von 1-6 hat
         *  
         */
        Random rnd = new Random();
        public int DiceTrow(int eyes)
        {
            return rnd.Next(1, eyes+1);
        }
    }
}
