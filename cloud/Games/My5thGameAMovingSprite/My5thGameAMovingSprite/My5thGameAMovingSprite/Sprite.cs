using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MovingWizard
{
    class Sprite
    {
        //The current position of the Sprite
        public Vector2 Position = new Vector2(0, 0);
        //The texture object used when drawing the sprite
        private Texture2D mSpriteTexture;
        //The Asset Nmae for Sorite's Texture
        public string AssetName;
        //The AssetName is a public object used to store the name of the image to be loaded from the Content Pipeline for this sprite
        //The Size of the Sprite with Scale Applied
        public Rectangle Size;
        //The amount to increase and decrease the size of the originnal sprite
        private float mScale = 1.0f;

        //Load the texture foe the Sprite using the Content Pipeline
        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            mSpriteTexture = theContentManager.Load<Texture2D>(theAssetName);
            AssetName = theAssetName;
            Size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * Scale), (int)(mSpriteTexture.Height * Scale));
        } 

        //Draw the Sprite to the screen
        public void Draw(SpriteBatch theSpriteBatch)
        {
            //theSpriteBatch.Draw(mSpriteTexture, Position, Color.White);
            theSpriteBatch.Draw(mSpriteTexture, Position, new Rectangle(0,0,mSpriteTexture.Width,mSpriteTexture.Height),Color.White,0.0f,Vector2.Zero,Scale,SpriteEffects.None,0);
        }
        
        //Update the Sprite and change it's position based on the passed in speed, direction and elapsed time.
        public void Update(GameTime theGameTime, Vector2 theSpeed, Vector2 theDirection)
        {
            //Movement is a simple calculation of taking the direction the sprite should be moving in, the speed they should be moving and 
            //multipying those by the time that has elapsed then adjusting the original position with the result.

            Position += theDirection * theSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
            //theDirection is a Vector2 object.
            //theSpeed is how fast the sprite should move in a along a given axis
            //theGameTime is used to keep how fast the sprite moves consistent across different computers
        }
        
        //When the scale is modified through the property, the Size of 
        //the Sprite is recalculated with the new scale applied.
        public float Scale
        {
            get { return mScale; }
            set
            {
                mScale = value;
                //Recalculate the Size of the Sprite with the new scale
                Size = new Rectangle(0,0,(int)(mSpriteTexture.Width*Scale),(int)(mSpriteTexture.Height *Scale));
            }
        }

    }
}
