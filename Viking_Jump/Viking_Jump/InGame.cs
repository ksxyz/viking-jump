using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Color = System.Drawing.Color;

namespace Viking_Jump
{
    public class InGame
    {
        
        public static float worldHeight = 0;
        public static float worldVelocity = 0;
        public static float currentHeight;
        public static float previousHeight;
        public static bool startGame = true;
        public static int playerScore = 0;

        public static float WorldHeight
        {
            get { return worldHeight; }
            set { worldHeight = value; }
        }

        public static float WorldVelocity
        {
            get { return worldVelocity; }
            set { worldVelocity = value; }
        }


        static Character player;
        // Font
        static SpriteFont font;



        public static void Reset()
        {
            WorldHeight = 0;
            WorldVelocity = 0;
            playerScore = 0;
            player.Position = new Vector2(300, 800);
            player.HasJumped = false;
            PlatformManager.Reset();
        }

        public static void LoadContent(ContentManager Content)
        {
            Background.LoadContent(Content);
            PlatformManager.LoadContent(Content);

            font = Content.Load<SpriteFont>(@"Font");
            
    
            player = new Character(Content.Load<Texture2D>(@"Textures/Frame_1"), 
                Content.Load<Texture2D>(@"Textures/Frame_4"), 
                Content.Load<Texture2D>(@"Textures/Frame_8"),
                Content.Load<Texture2D>(@"Textures/Frame_10"),
                Content.Load<Texture2D>(@"Textures/Charge Jump Red"),
                Content.Load<Texture2D>(@"Textures/Charge Jump Yellow"),
                Content.Load<Texture2D>(@"Textures/Charge Jump Blue"),
                new Vector2(300, 800), font);
        }

        
        public static void Update(GameTime gameTime)
        {
            if (worldVelocity > 0 && playerScore < worldHeight)
            {
                playerScore = (int)worldHeight;
            }

            previousHeight = currentHeight;
            currentHeight = worldHeight;
            worldVelocity =  currentHeight- previousHeight;

            //if (Character.position.Y <= 450 && -Character.velocity.Y > 0)
            worldHeight -= Character.velocity.Y;


            //if (Character.position.Y <= 450 && Character.velocity.Y == 0)
            //    worldVelocity = 0;


            player.Update(gameTime);
            PlatformManager.Update(gameTime);


            if (Keyboard.GetState().IsKeyDown(Keys.R))
                PlatformManager.Reset();



            if ((int)currentHeight / Variables.PlatformSpawnGap > (int)previousHeight / Variables.PlatformSpawnGap)
            {
                PlatformManager.SpawnPlatforms();
            }

            if (startGame == true)
            {
                PlatformManager.SpawnIntroPlatforms();
                startGame = false;
            }


            if (player.Position.Y > 1000)
            {
                Game1.gameState = Game1.GameStates.GameOver;
                SaveFile.PlayerScore = (float)playerScore / 50;
                SaveFile.SaveHighScore();
            }



        }



        public static void Draw(SpriteBatch spriteBatch)
        {
            Background.Draw(spriteBatch);
            PlatformManager.Draw(spriteBatch);
            player.Draw(spriteBatch);
            // Draw score background
            //spriteBatch.DrawString(font, worldHeight.ToString(), new Vector2(10, 300), Microsoft.Xna.Framework.Color.White);
            spriteBatch.DrawString(font, ((float)playerScore/50).ToString(), new Vector2(10, 400), Microsoft.Xna.Framework.Color.White);
        }

    }
}
