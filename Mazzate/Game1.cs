using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Mazzate
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D spriteSheet;
        List<Giocatore> listaGiocatori = new List<Giocatore>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            int numeroGiocatori = 2;
            int guerrieriPerGiocatore = 3;

            for (int i = 0; i < numeroGiocatori; i++)
            {
                listaGiocatori.Add(new Giocatore((Colore)i, new List<Guerriero>()));
            }

            foreach (Giocatore giocatore in listaGiocatori)
            {
                giocatore.creaGuerrieri(guerrieriPerGiocatore);
                foreach (Guerriero guerriero in giocatore.listaGuerrieri) {
                    guerriero.coordSpawnGuerriero(giocatore.colore, this);
                }
            }



            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteSheet = Content.Load<Texture2D>(@"immagini\guerrieri_1.1");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);
            spriteBatch.Begin();

            Rectangle dstRect;
            Rectangle srcRect;
            Color colore;
            int j = 0;

            foreach (Giocatore giocatore in listaGiocatori)
            {
                int i = 0;
                switch (j)
                {
                    case 0: colore = Color.DarkRed; break;
                    case 1: colore = Color.DarkSlateBlue; break;
                    default: colore = Color.White; break;
                }
                j++;
                foreach (Guerriero guerriero in giocatore.listaGuerrieri)
                {

                    dstRect = new Rectangle(guerriero.posizione, new Point(64, 64));
                    srcRect = new Rectangle(i * 64, 0, 64, 64);

                    spriteBatch.Draw(spriteSheet, dstRect, srcRect, Color.DarkRed);
                    i++;
                }
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
