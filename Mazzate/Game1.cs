using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Linq;

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
        List<Guerriero> tuttiGuerrieri = new List<Guerriero>();
        ManagerGuerrieri mngGuerrieri;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            mngGuerrieri = new ManagerGuerrieri(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            const int NUM_GIOCATORI = 2;
            const int GUERRIERI_PER_GIOCATORE = 5;

            for (int i = 0; i < NUM_GIOCATORI; i++)
            {
                listaGiocatori.Add(new Giocatore((Colore)i));
            }

            foreach (Giocatore giocatore in listaGiocatori)
            {
                mngGuerrieri.CreaGuerrieri(giocatore, GUERRIERI_PER_GIOCATORE);
            }

            mngGuerrieri.SpawnaGuerrieri();

            Components.Add(mngGuerrieri);

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
            Services.AddService(spriteBatch);

            spriteSheet = Content.Load<Texture2D>(@"immagini\guerrieri_1.2");

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


            mngGuerrieri.Draw(spriteSheet, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
