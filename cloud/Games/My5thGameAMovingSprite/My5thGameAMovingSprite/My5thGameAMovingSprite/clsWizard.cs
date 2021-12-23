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
    class clsWizard:Sprite
    {

        const string WIZARD_ASSETNAME = "WizardSquare";
        const int START_POSITION_X = 125;
        const int START_POSITION_Y = 245;
        const int WIZARD_SPEED = 160;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;

        //Define the state of the wizard
        enum State
        {
            Walking
            //Dead
            //PoweredUp
            //Ducking
            //Running
            //Shooting
        }
        State mCurrentState = State.Walking;
        //
        Vector2 mDirection = Vector2.Zero;
        Vector2 mSpeed = Vector2.Zero;
        //
        GamePadState mPreviousPadState;

        //The Wizard needs to load the new Wizard image, 
        //so we're going to model after the base sprite class and add a LoadContent method to the Wizard.

        public void LoadContent(ContentManager theContentManager)
        {
            Position = new Vector2(START_POSITION_X, START_POSITION_Y);
            base.LoadContent(theContentManager, WIZARD_ASSETNAME);
        }

        //Now, we need to add an "Update" method to the Wizard class. 
        //This method will take care of checking for input and moving the sprite around..

        public void Update(GameTime theGameTime,GamePadState pad1)
        {
            
            UpdateMovement(pad1);
            mPreviousPadState = pad1;
            base.Update(theGameTime, mSpeed, mDirection);
            //base.Update(theGameTime);
        }



        private void UpdateMovement(GamePadState pad1)
        {
            if (mCurrentState == State.Walking)
            {
                mSpeed = Vector2.Zero;
                mDirection = Vector2.Zero;

                if (pad1.Buttons.B == ButtonState.Pressed)
                {
                   // mDirection.X = MOVE_RIGHT;// mSprite.Position.X + 1;
                    mDirection.X = mDirection.X + 1;
                }
                if (pad1.Buttons.X == ButtonState.Pressed)
                {
                    //mDirection.X = MOVE_LEFT;// mSprite.Position.X - 1;
                    mDirection.X = mDirection.X - 1;
                }
                //Move Y direction -1 goes up, +1 goes down
                if (pad1.Buttons.Y == ButtonState.Pressed)
                {
                   // mDirection.Y = MOVE_DOWN;// mSprite.Position.Y - 1;
                    mDirection.Y = mDirection.Y - 1;
                }
                if (pad1.Buttons.A == ButtonState.Pressed)
                {
                   // mDirection.Y = MOVE_UP;// mSprite.Position.Y + 1;
                    mDirection.Y = mDirection.Y + 1;
                }
            }
        }



    }
}
