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
        public Guerriero(Giocatore proprietario, int mor, int hp)
        {
            _inGioco = false;
            Morale = mor;
            PuntiVita = hp;
            abilitaTipoDanno = new int[3];
            abilitaTipoArma = new int[6];

            Proprietario = proprietario;
        }

        [Obsolete("Usare il metodo omonimo di ManagerGuerrieri")]
        public void coordSpawnGuerriero(Colore coloreGiocatore, Game1 game)
        {
            int rnd = 0;// = rand.Next(0, (game.Window.ClientBounds.Right - 64));
            int xSpawn = 64 * (int)(rnd / 64);
            int ySpawn;

            if (coloreGiocatore == Colore.rosso) ySpawn = 0;
            else ySpawn = game.Window.ClientBounds.Bottom - 64;

            posizione = new Vector2(xSpawn, ySpawn);
        }

        public void Spawn(Vector2 posizione)
        {
            if (_inGioco) throw new Exception();
            this.posizione = posizione;
            _inGioco = true;
        }

        public void Update(GameTime gameTime)
        {
            if (!corpoAcorpo) posizione += temp_velocità;
            corpoAcorpo = false;
        }

        public void Draw(Texture2D spriteSheet, SpriteBatch spriteBatch)
        {


            spriteBatch.Draw(

                spriteSheet,
                posizione,
                sourceRectangle: new Rectangle(0, 0, 64, 64),
                color: Proprietario.SpriteColor

                );

        }

        public Rectangle Bounds {

            get
            {
                return new Rectangle(
                    (int)posizione.X, 
                    (int)posizione.Y,
                    64, 
                    64);
            }
        }

        public bool CorpoACorpo { set { corpoAcorpo = value; } }
        bool corpoAcorpo = false;

        // Cambiati i punti in vettori
        public Vector2 Posizione { get { return posizione; } }
        public Vector2 NuovaPosizione { get; set; }
        //public bool CheckCollisione { get; set; }

        public int Morale { get; set; }
        public int PuntiVita { get; set; }

        public int[] abilitaTipoDanno; // Taglio Perforazione Impatto
        public int[] abilitaTipoArma; // 1mano 2mani Lunghe Lancio Tiro Scudi

        public Colore Colore { get { return Proprietario.Colore; } }
        public Giocatore Proprietario { get; protected set; }

        Vector2 posizione, nuovaPosizione;
        bool _inGioco = false;

        Vector2 temp_velocità { get
            {
                if (Colore == Colore.rosso) return new Vector2(0, 2.1f);
                else return new Vector2(0, -2.1f);
            }
        }
    }
}
