//// Created this class | Julius 18-11-21
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Input;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Viking_Jump
//{
//    class Player
//    {
//        // Texture & Rectangle | Julius 18-12-03
//        private Texture2D playerSpriteSheet;
//        private int spriteWidth = 39;
//        private int spriteHeight = 69;
//        private Rectangle playerRectangle;
//        private Rectangle spriteRectangle;
//        private Rectangle collisionRectangle;

//        // Position & Speed | Julius 18-12-03
//        public Vector2 position = new Vector2(200, 200);
//        public Vector2 centerPoint = new Vector2(0,0);
//        private Vector2 velocity;
//        private int speed = 110;

//        // Animation & Keyboard | Julius 18-12-03
//        private int currentFrame = 0;
//        private float animationSpeed = 200f;
//        private float timer = 0f;
//        KeyboardState currentKBState;
//        KeyboardState previousKBState;

//        // A get/set to share players Position with other clases | Julius 18-12-03
//        public Vector2 Position
//        {
//            get { return position; }
//            set { position = value; }
//        }

//        public Vector2 CenterPoint
//        {
//            get { return centerPoint; }
//            set { centerPoint = value; }
//        }

//        public Rectangle CollisionRectangle
//        {
//            get { return collisionRectangle; }
//            set { collisionRectangle = value; }
//        }
        


//        // A function that creates a new player | Julius 18-12-03
//        public Player(Texture2D texture, int currentFrame, int spriteWidth, int spriteHeight)
//        {
//            this.playerSpriteSheet = texture;
//            this.currentFrame = currentFrame;
//            this.spriteWidth = spriteWidth;
//            this.spriteHeight = spriteHeight;
//        }






        

//        public void Update(GameTime gameTime)
//        {
//            // Update Position by adding velocity every game tic | Julius 18-12-03
//            position += velocity;
//            // A rectangle for the sprite of the player | Julius 18-12-03
//            playerRectangle = new Rectangle((int)position.X, (int)position.Y, spriteWidth, spriteHeight);
//            // A rectangle for the collision of the player, which is a little lower down and is a square | Julius 18-12-03
//            collisionRectangle = new Rectangle((int)position.X, (int)position.Y + spriteHeight - spriteWidth, spriteWidth, spriteWidth);
//            // Update playerCenter to its centerpoint of hitbox | Julius 18-12-04
//            centerPoint = new Vector2(collisionRectangle.X / 2, collisionRectangle.Y / 2);

//            Input(gameTime);
//        }






//        // Movement | Julius 18-12-03
//        private void Input(GameTime gameTime)
//        {

//            previousKBState = currentKBState;
//            currentKBState = Keyboard.GetState();

//            spriteRectangle = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
//            //Which spriteframes that are conected to each other //Carl 15/11/18
//            if (currentKBState.GetPressedKeys().Length == 0)
//            {
//                if (currentFrame > 0 && currentFrame < 4)
//                    currentFrame = 0;

//                if (currentFrame > 4 && currentFrame < 8)
//                    currentFrame = 4;

//                if (currentFrame > 8 && currentFrame < 12)
//                    currentFrame = 8;

//                if (currentFrame > 12 && currentFrame < 16)
//                    currentFrame = 12;
//            }


//            // Animate walk and change Position when going Left or Right | Julius 18-12-03
//            if (currentKBState.IsKeyDown(Keys.A) == true || currentKBState.IsKeyDown(Keys.Left) == true)
//            {
//                // Animate left | Julius 18-12-03
//                AnimateLeft(gameTime);
//                // "speed" representates how many pixels per second the player is moving | Julius 18-12-03
//                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds * speed / 1000;
//            }
//            else if (currentKBState.IsKeyDown(Keys.D) == true || currentKBState.IsKeyDown(Keys.Right) == true)
//            {
//                // Animate right | Julius 18-12-03
//                AnimateRight(gameTime);
//                // "speed" representates how many pixels per second the player is moving | Julius 18-12-03
//                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds * speed / 1000;
//            }
//            // If no button is pressed than the player shall stop moving on the X-axis | Julius 18-12-03
//            else velocity.X = 0f;

//            // Animate walk and change Position when going Up or Down | Julius 18-12-03
//            if (currentKBState.IsKeyDown(Keys.W) == true || currentKBState.IsKeyDown(Keys.Up) == true)
//            {
//                // Animate up | Julius 18-12-03
//                AnimateUp(gameTime);
//                // "speed" representates how many pixels per second the player is moving | Julius 18-12-03
//                velocity.Y = -(float)gameTime.ElapsedGameTime.TotalMilliseconds * speed / 1000;
//            }
//            else if (currentKBState.IsKeyDown(Keys.S) == true || currentKBState.IsKeyDown(Keys.Down) == true)
//            {
//                // Animate down | Julius 18-12-03
//                AnimateDown(gameTime);
//                // "speed" representates how many pixels per second the player is moving | Julius 18-12-03
//                velocity.Y = (float)gameTime.ElapsedGameTime.TotalMilliseconds * speed / 1000;
//            }
//            // If no button is pressed than the player shall stop moving on the Y-axis | Julius 18-12-03
//            else velocity.Y = 0f;

//        }

//        // Animation code by Carl | Julius 18-11-28
//        #region Animation
//        //Kod för att frame 1 till 4 används när spelaren går neråt //Carl 07/11/18
//        public void AnimateUp(GameTime gameTime)
//        {
//            if (currentKBState != previousKBState)
//            {
//                currentFrame = 9;
//            }

//            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

//            if (timer > animationSpeed)
//            {
//                currentFrame++;

//                if (currentFrame > 11)
//                {
//                    currentFrame = 8;
//                }
//                timer = 0f;
//            }
//        }
//        //Kod för att frame 5 till 8 används när spelaren går åt höger //Carl 07/11/18
//        public void AnimateRight(GameTime gameTime)
//        {
//            if (currentKBState != previousKBState)
//            {
//                currentFrame = 5;
//            }

//            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

//            if (timer > animationSpeed)
//            {
//                currentFrame++;

//                if (currentFrame > 7)
//                {
//                    currentFrame = 4;
//                }
//                timer = 0f;
//            }
//        }
//        //Kod för att frame 9 till 12 används när spelaren går uppåt //Carl 07/11/18
//        public void AnimateDown(GameTime gameTime)
//        {
//            if (currentKBState != previousKBState)
//            {
//                currentFrame = 1;
//            }

//            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

//            if (timer > animationSpeed)
//            {
//                currentFrame++;

//                if (currentFrame > 3)
//                {
//                    currentFrame = 0;
//                }
//                timer = 0f;
//            }
//        }
//        //Kod för att frame 13 till 16 används när spelaren går åt vänster //Carl 07/11/18
//        public void AnimateLeft(GameTime gameTime)
//        {
//            if (currentKBState != previousKBState)
//            {
//                currentFrame = 13;
//            }

//            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

//            if (timer > animationSpeed)
//            {
//                currentFrame++;

//                if (currentFrame > 15)
//                {
//                    currentFrame = 12;
//                }
//                timer = 0f;
//            }
//        }

//        #endregion



//        // Kollision för spelaren med tiles och gameborders, newRectangle är vad som ska kollidera med tiles och border, border skrivs i värderna x, x, y, y | Julius 18-11-21
//        // Fixade kollisionen som såg ful ut | Julius 18-12-03
//        public void Collision(Rectangle newRectangle, int leftBorder, int rightBorder, int topBorder, int bottomBorder)
//        {
//            // If playerCollisionRectangle touch on the top of TileRectangle | Julius 18-12-03
//            if (collisionRectangle.TouchTopOf(newRectangle))
//                // Changes Position which makes the player stop from walking through the tile | Julius 18-12-03
//                position.Y = newRectangle.Y - spriteRectangle.Height -1;
            

//            // Four if-states which declares that the playerCollisionRectangle shall stay within these assigned borders | Julius 18-12-03
//            if (position.X < leftBorder) position.X = leftBorder;
//            if (position.X > rightBorder - collisionRectangle.Width) position.X = rightBorder - collisionRectangle.Width;
//            if (position.Y + spriteHeight - spriteWidth < topBorder) position.Y = topBorder - spriteHeight + spriteWidth;
//            if (position.Y > bottomBorder - collisionRectangle.Height) position.Y = bottomBorder - collisionRectangle.Width;

//        }


//        public void Draw(SpriteBatch spriteBatch)
//        {
//            // Draw the player | Julius 18-12-03
//            spriteBatch.Draw(playerSpriteSheet, playerRectangle, spriteRectangle, Color.White);
//        }


//    }
//}
