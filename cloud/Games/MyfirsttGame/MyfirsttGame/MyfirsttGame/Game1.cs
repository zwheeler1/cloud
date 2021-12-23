using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MyfirsttGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        byte redIntensity = 0;
        byte greenIntensity = 0;
        byte blueIntensity = 0;




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
            // TODO: Add your initialization logic here

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

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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

            GamePadState pad1 = GamePad.GetState(PlayerIndex.One);
            GamePadState pad2 = GamePad.GetState(PlayerIndex.Two);
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                GamePad.SetVibration(PlayerIndex.One, 0, 0);
                GamePad.SetVibration(PlayerIndex.Two, 0, 0);
                this.Exit();
            }

            //Update each color in turn
            //Red
            
            if (pad1.Buttons.B == ButtonState.Pressed) redIntensity++;
            if (pad1.Buttons.X == ButtonState.Pressed) blueIntensity++;
            if (pad1.Buttons.A == ButtonState.Pressed) greenIntensity++;
            if (pad1.Buttons.Y == ButtonState.Pressed)
            {
                redIntensity++;
                greenIntensity++;
            }

            if (redIntensity > 220 || greenIntensity > 220 || blueIntensity > 220)
            {
                GamePad.SetVibration(PlayerIndex.One, 0, 1);
                //Note: Low-Frequency Motor Vibration
                //GamePad.SetVibration(PlayerIndex.One,1,0);
            }
            else
            {
                GamePad.SetVibration(PlayerIndex.One, 0, 0);
            }
           

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            Color backgroundColor;

            backgroundColor = new Color(redIntensity, greenIntensity, blueIntensity);
            graphics.GraphicsDevice.Clear(backgroundColor);
            base.Draw(gameTime);
        }
    }
}
