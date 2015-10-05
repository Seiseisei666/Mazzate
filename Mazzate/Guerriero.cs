using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mazzate
{
    public class Guerriero
    {
        public Guerriero(int mor, int hp)
        {
            posizione = new Point(-1);
            morale = mor;
            puntiVita = hp;

            abilitaTipoDanno = new int[3];
            abilitaTipoArma = new int[6];

            Array.Clear(abilitaTipoArma,0,abilitaTipoArma.Length);
            Array.Clear(abilitaTipoDanno, 0, abilitaTipoDanno.Length);
        }

        public void coordSpawnGuerriero(Colore coloreGiocatore, Game1 game)
        {
            Random rand = new Random();
            int xSpawn = rand.Next(32, (game.Window.ClientBounds.Right - 32));
            int ySpawn;

            if (coloreGiocatore == Colore.rosso) ySpawn = 96;
            else ySpawn = game.Window.ClientBounds.Bottom - 64;

            posizione = new Point(xSpawn, ySpawn);
        }


        public Point posizione { get; set; }

        public int morale { get; set; }
        public int puntiVita { get; set; }

        public int[] abilitaTipoDanno; // Taglio Perforazione Impatto
        public int[] abilitaTipoArma; // 1mano 2mani Lunghe Lancio Tiro Scudi

    }
}
