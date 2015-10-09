using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mazzate
{
    public class ManagerGuerrieri: GameComponent
    {
        static Random rand = new Random();
        Guerriero[] guerrieri;

        public ManagerGuerrieri(Game game ): base (game)
        {
            guerrieri = new Guerriero[0];
        }

        public override void Initialize()
        {

        }

        public void CreaGuerrieri (Giocatore giocatore, int numero)
        {
            var nuovi =
                // Creo una sequenza intera che va da 0 a "numero"
                Enumerable.Range(0, numero)
                // Costruisco per ciascun elemento della sequenza un nuovo guerriero (Select in realtà è l'Array.map() di js)
                .Select(n => new Guerriero(giocatore, 100 * n, 100 * n))
                // Esporto la sequenza come array
                .ToArray();

            guerrieri = guerrieri.Concat(nuovi).ToArray();
        }

        public void SpawnaGuerrieri ()
        {
            foreach (var guerriero in guerrieri)
            {
                int rnd = rand.Next(0, (Game.Window.ClientBounds.Right - 64));
                int xSpawn = 64 ; //*(rnd / 64)
                int ySpawn;

                if (guerriero.Colore == Colore.rosso) ySpawn = 0;
                else ySpawn = Game.Window.ClientBounds.Bottom - 64;

                guerriero.Spawn(new Vector2(xSpawn, ySpawn));
            }

            
        }

        public void sistemaCollisioni()
        {
            for (int idPrimo = guerrieri.Length-1; idPrimo > 0; idPrimo--)
            {
                Guerriero primo = guerrieri[idPrimo];

                for (int idAltro = idPrimo - 1; idAltro > 0; idAltro--)
                {
                    Guerriero altro = guerrieri[idAltro];
                    
                    if (altro.Bounds.Intersects(primo.Bounds))
                    {
                   
                        primo.CorpoACorpo = true;
                        altro.CorpoACorpo = true;
                    }

                }
            }
        }
        
        public void impedisciUscitaSchermo(List<Guerriero> listGuer, Game1 game)
        {
            foreach (Guerriero guerDaCheck in listGuer)
            {
                //if (guerDaCheck.nuovaPosizione.Y > game.Window.ClientBounds.Bottom - 64 || guerDaCheck.nuovaPosizione.Y < game.Window.ClientBounds.Top)
                //{
                //    guerDaCheck.nuovaPosizione = guerDaCheck.posizione;
                //}

            }
        }

        public override void Update(GameTime gameTime)
        {
            sistemaCollisioni();

            foreach (var guerriero in guerrieri)
                guerriero.Update(gameTime);

        }

        public void Draw(Texture2D spriteSheet, SpriteBatch spriteBatch)
        {
            foreach (var g in guerrieri)
                g.Draw(spriteSheet, spriteBatch);
        }
        
    }
}
