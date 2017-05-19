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
        /* 
         * Eine sehr schöne Methode. Diese Klasse habe ich erstellt um mein kleines Menu zu erstellen.
         * Mit dem Char übergebe ich die zu drückende Taste und mit dem string den Inhalt
         * z.B.
         * Wählen Sie Ihr Getränk:
         *          1   Cola
         *          2   Fanta
         *          3   Sprite
         *          
         */
        public Option(char number, string content)
        {
            this.Index = number;
            this.MenuChoice = content;
        }
    }
}
