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
            nuovaPosizione = new Point(-10);
            checkCollisione = false;

            morale = mor;
            puntiVita = hp;
            abilitaTipoDanno = new int[3];
            abilitaTipoArma = new int[6];

            Array.Clear(abilitaTipoArma,0,abilitaTipoArma.Length);
            Array.Clear(abilitaTipoDanno, 0, abilitaTipoDanno.Length);
        }

        public void coordSpawnGuerriero(Colore coloreGiocatore, Game1 game)
        {
            int rnd = rand.Next(0, (game.Window.ClientBounds.Right - 64));
            int xSpawn = 64 * (int)(rnd / 64);
            int ySpawn;

            if (coloreGiocatore == Colore.rosso) ySpawn = 0;
            else ySpawn = game.Window.ClientBounds.Bottom - 64;

            posizione = new Point(xSpawn, ySpawn);
        }


        public Point posizione { get; set; }
        public Point nuovaPosizione { get; set; }
        public bool checkCollisione { get; set; }

        public int morale { get; set; }
        public int puntiVita { get; set; }

        public int[] abilitaTipoDanno; // Taglio Perforazione Impatto
        public int[] abilitaTipoArma; // 1mano 2mani Lunghe Lancio Tiro Scudi

        static Random rand = new Random();
    }
}
