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
using Viking_Jump;

namespace Viking_Jump
{
    public class Character
    {
       
        /// Variabler  
        
        // Font
        static SpriteFont pericles36Font;

        static Texture2D texture, textureIdle, textureCharge, textureFullChargeRed, textureFullChargeGreen, textureFullChargeBlue, textureShoot, textureFall;
        private static Rectangle collisionBox;
        public static Vector2 position;
        public static Vector2 velocity;
        public static int textureAnimation;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public static float timer = 0;

        public float Timer
        {
            get { return timer; }
            set { timer = value; }
        }
            float charge = 0;

        public static bool hasJumped;
        public bool HasJumped
        {
            get { return hasJumped; }
            set { hasJumped = value; }
        }


        // Character

        public Character(Texture2D idle, Texture2D charge, Texture2D shoot, Texture2D fall, Texture2D red, Texture2D green, Texture2D blue, Vector2 newPosition, SpriteFont font)
        {
            textureIdle = idle;
            textureCharge = charge;
            textureFall = fall;
            textureShoot = shoot;
            texture = textureIdle;

            textureFullChargeRed = red;
            textureFullChargeGreen = green;
            textureFullChargeBlue = blue;

            position = newPosition;
            hasJumped = false;
            pericles36Font = font;
        }

       
        
        // Update
        public void Update(GameTime gameTime)
        {
            position += velocity;
                      
            // Has jumped false
            if ((hasJumped == false))
            {
                // If space is down, a timer will start to tic down
                if ((Keyboard.GetState().IsKeyDown(Keys.Space)) && timer <= 1000)
                {
                    timer += (int)gameTime.ElapsedGameTime.Milliseconds;

                    // If the timer reaches 2000, then the timer will be static at 2000 and make charge true
                    if (timer >= 2000)
                    charge = 1;
                   

                }            
                       
                    // If space is down and the timer is bigger than 1, then it will jump according to 
                    // how long you have been holding down the space button
                    if ((Keyboard.GetState().IsKeyUp(Keys.Space)) && timer >= 1 && charge == 0 )
                    {
                        position.Y -= 10f;
                        velocity.Y = -0.03f * timer;
                        hasJumped = true;
                        charge = 0;
                        timer = 0;
                    }







                // If charge is at 1, and you let go of space, the jump will be 1,6 times larger 
                // than than the highest jump possible

                if (charge == 1 && Keyboard.GetState().IsKeyUp(Keys.Space))
                {
                    position.Y -= 10f;
                    velocity.Y = -70;
                    hasJumped = true;
                    charge = 0;
                    timer = 0;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right)) { velocity.X = +4f; }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))velocity.X = -4f;
            else velocity.X = 0;
          


            if (hasJumped == true)
            {
                float i = 1;
                velocity.Y += 0.5f * i;

            }
            

            if (hasJumped == false)
            {
                velocity.Y = 0f;
                velocity.X = 0f;
            }

            // AnimationLogic

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false && timer < 1000)
            {
                texture = textureCharge;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false && timer >= 1000)
            {

                textureAnimation++;
                if (textureAnimation > 2)
                    textureAnimation = 0;

                if (textureAnimation == 0)
                texture = textureFullChargeRed;
                if (textureAnimation == 1)
                    texture = textureFullChargeGreen;
                if (textureAnimation == 2)
                    texture = textureFullChargeBlue;


            }
            else if (velocity.Y < 0)
            {
                texture = textureShoot;
            }
            else if (velocity.Y > 0)
            {
                texture = textureFall;
            }
            else
            {
                texture = textureIdle;
            }
          
        }

        public void Draw(SpriteBatch spriteBatch)
        {
          
            spriteBatch.Draw(texture, position, Color.White);
            //spriteBatch.DrawString(pericles36Font, timer.ToString(), new Vector2(0, 0), Color.White);
           
        }

        public static void Collision(Rectangle platformRectangle, int leftBorder, int rightBorder, int topBorder, int bottomBorder)
        {
           collisionBox = new Rectangle((int)position.X + 30, (int)position.Y + texture.Height - Variables.PlayerCollisionMargin, texture.Width - 30*2, Variables.PlayerCollisionMargin);

                // If playerCollisionRectangle touch on the top of TileRectangle | Julius 18-12-03
            if (    // Checks the player's underside of the rectangle is above the platforms top | Julius 19-02-12
                collisionBox.Bottom >= platformRectangle.Top - 0 &&
                // AND Checks if the players underside is under the platform | Julius 19-02-12
                collisionBox.Bottom <= platformRectangle.Top + (platformRectangle.Height / 4) &&
                collisionBox.Right >= platformRectangle.Left &&
                collisionBox.Left <= platformRectangle.Right && Character.velocity.Y >= 0)
            {
                hasJumped = false;
                // Changes Position which makes the player stop from walking through the tile | Julius 18-12-03
                position.Y = platformRectangle.Y - texture.Height;
                               
            }

            if (collisionBox.Intersects(platformRectangle) && hasJumped == false)
                position.Y--;



            ////            // Four if-states which declares that the playerCollisionRectangle shall stay within these assigned borders | Julius 18-12-03
            if (position.X < leftBorder) position.X = leftBorder;
            if (position.X > rightBorder - collisionBox.Width) position.X = rightBorder - collisionBox.Width;

            if (position.Y + texture.Height - texture.Width < topBorder)
            {
                position.Y = topBorder - texture.Height + texture.Width;
                
            }
            if (position.Y > bottomBorder - collisionBox.Height)
            {
                position.Y = bottomBorder - collisionBox.Width;
                velocity.Y = -1;
            }

        }


    }


    }


