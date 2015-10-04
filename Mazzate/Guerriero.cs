using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mazzate
{
    public class Guerriero
    {
        public Guerriero(int mor, int hp)
        {
            morale = mor;
            puntiVita = hp;

            abilitaTipoDanno = new int[3];
            abilitaTipoArma = new int[6];

            Array.Clear(abilitaTipoArma,0,abilitaTipoArma.Length);
            Array.Clear(abilitaTipoDanno, 0, abilitaTipoDanno.Length);
        }




        public int morale { get; set; }
        public int puntiVita { get; set; }

        public int[] abilitaTipoDanno; // Taglio Perforazione Impatto
        public int[] abilitaTipoArma; // 1mano 2mani Lunghe Lancio Tiro Scudi

    }
}
