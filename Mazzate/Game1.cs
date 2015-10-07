﻿using Microsoft.Xna.Framework;
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
        ManagerGuerrieri mngGuerrieri = new ManagerGuerrieri();

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
                tuttiGuerrieri.AddRange(giocatore.listaGuerrieri);
            }
            mngGuerrieri.sistemaCollisioni(tuttiGuerrieri);

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Guerriero guerriero in tuttiGuerrieri) { if (guerriero.nuovaPosizione.X > -10 && guerriero.nuovaPosizione.Y > -10) { guerriero.posizione = guerriero.nuovaPosizione; guerriero.nuovaPosizione = new Point(-1); } };

            foreach (Guerriero guerriero in listaGiocatori[0].listaGuerrieri) { guerriero.nuovaPosizione = guerriero.posizione + new Point(0, 2); }
            foreach (Guerriero guerriero in listaGiocatori[1].listaGuerrieri) { guerriero.nuovaPosizione = guerriero.posizione + new Point(0, -2); }

            mngGuerrieri.sistemaCollisioni(tuttiGuerrieri);
            mngGuerrieri.impedisciUscitaSchermo(tuttiGuerrieri, this);

            Console.WriteLine("pos 0: " + tuttiGuerrieri[0].nuovaPosizione.Y + "pos 3: " + tuttiGuerrieri[3].nuovaPosizione.Y);

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
            SpriteEffects flip;
            int j = 0;

            foreach (Giocatore giocatore in listaGiocatori)
            {
                int i = 0;
                switch (j)
                {
                    case 0: colore = Color.DarkRed; flip = SpriteEffects.FlipVertically; break;
                    case 1: colore = Color.DarkBlue; flip = SpriteEffects.None; break;
                    default: colore = Color.White; flip = SpriteEffects.None; break;
                }
                j++;
                foreach (Guerriero guerriero in giocatore.listaGuerrieri)
                {

                    dstRect = new Rectangle(guerriero.nuovaPosizione, new Point(64, 64));
                    srcRect = new Rectangle(i * 64, 0, 64, 64);

                    spriteBatch.Draw(spriteSheet, dstRect, srcRect, colore, 0f, Vector2.Zero, flip, 0f);
                    i++;
                }
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
