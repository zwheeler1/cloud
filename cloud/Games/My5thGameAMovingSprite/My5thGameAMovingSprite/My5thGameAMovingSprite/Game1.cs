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

namespace MovingWizard
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //the asset name for the sprite's texture
        public string AssetName;
        //The size of the Sprite (with scale applied)
        public Rectangle Size;
        //The amount to increase/decrease the size of the origina sprite
        private float mScale = 1.0f;
        //
        Vector2 mPosition = new Vector2(250,100);
        Texture2D mSpriteTexture;
        //
        clsWizard mWizardSprite;
        //
        SpriteFont font;

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
            mWizardSprite = new clsWizard();
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
            mWizardSprite.LoadContent(this.Content, "Images\\SquareGuy");
            //mSpriteTexture = Content.Load<Texture2D>("Images\\SquareGuy");
            //mWizardSprite.Position = new Vector2(0, 0);
            font = Content.Load<SpriteFont>("Arial");

            //

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
            // TODO: Add your update logic here
            GamePadState pad1 = GamePad.GetState(PlayerIndex.One);
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                GamePad.SetVibration(PlayerIndex.One, 0, 0);
                this.Exit();
            }

            //Move the sprite
            //mWizardSprite.Update(gameTime, pad1); 
            MoveSprite();
           
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            DateTime nowDateTime = DateTime.Now;
            string nowString = nowDateTime.ToLongTimeString();
            Vector2 textVector2 = new Vector2(650, 25);
            Vector2 textVector = new Vector2(650, 0);
          

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            mWizardSprite.Draw(this.spriteBatch);
            spriteBatch.DrawString(font, "Player: Zachary", textVector, Color.Red);
            spriteBatch.DrawString(font, nowString, textVector2, Color.Red);
            spriteBatch.End();

            base.Draw(gameTime);

        }


        protected void MoveSprite()
        {
            GamePadState pad1 = GamePad.GetState(PlayerIndex.One);
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                GamePad.SetVibration(PlayerIndex.One, 0, 0);
                this.Exit();
            }

            //Move Sprite

            if (pad1.Buttons.B == ButtonState.Pressed)
            {
                mWizardSprite.Position.X = mWizardSprite.Position.X + 1;
            }
            if (pad1.Buttons.X == ButtonState.Pressed)
            {
                mWizardSprite.Position.X = mWizardSprite.Position.X - 1;
            }
            //Move Y direction -1 goes up, +1 goes down
            if (pad1.Buttons.Y == ButtonState.Pressed)
            {
                mWizardSprite.Position.Y = mWizardSprite.Position.Y - 1;
            }
            if (pad1.Buttons.A == ButtonState.Pressed)
            {
                mWizardSprite.Position.Y = mWizardSprite.Position.Y + 1;
            }



        }
    }
}
