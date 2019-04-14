using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Color = Microsoft.Xna.Framework.Color;

namespace Viking_Jump
{


    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public static Texture2D titleTexture;





        public enum GameStates
        {
            Intro,
            Menu,
            InGame,
            Highscore,
            Credits,
            GameOver
        }
        public static GameStates gameState = GameStates.Intro;



        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = Variables.ScreenSize.Width;
            graphics.PreferredBackBufferHeight = Variables.ScreenSize.Height;
            graphics.ApplyChanges();
            
            SaveFile.Initialize();

            base.Initialize();
        }
        


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Menu.LoadContent(Content, 5, new int[] {1, 4, 1, 1, 3});

            titleTexture = Content.Load<Texture2D>(@"Textures/Menu/title");
            InGame.LoadContent(Content);
            SaveFile.LoadContent(Content);
            InGame.Reset();

        }
        


        protected override void UnloadContent()
        {
        }
        


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.End) ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            


            switch (gameState)
            {
                case GameStates.Intro:
                    Menu.MenuState = 0;
                    Menu.Update(gameTime);
                    if (Menu.Select(1))
                        gameState = GameStates.Menu;

                    break;
                case GameStates.Menu:
                    Menu.MenuState = 1;
                    Menu.Update(gameTime);
                    if (Menu.Select(1))
                    {
                        InGame.Reset();
                        gameState = GameStates.InGame;
                    }
                    if (Menu.Select(2))
                        gameState = GameStates.Highscore;
                    if (Menu.Select(3))
                        gameState = GameStates.Credits;
                    if (Menu.Select(4))
                        this.Exit();

                    break;
                case GameStates.InGame:
                    InGame.Update(gameTime);
                    break;
                case GameStates.Highscore:
                    Menu.MenuState = 2;
                    Menu.Update(gameTime);
                    if (Menu.Select(1))
                        gameState = GameStates.Menu;

                    if (Keyboard.GetState().IsKeyDown(Keys.R) && Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                        SaveFile.ResetHighScore();
                        break;
                case GameStates.Credits:
                    Menu.MenuState = 3;
                    if (Menu.Select(1))
                        gameState = GameStates.Menu;
                    Menu.Update(gameTime);

                    break;
                case GameStates.GameOver:
                    Menu.MenuState = 4;
                    if (Menu.Select(1))
                    {
                        gameState = GameStates.InGame;
                    }

                    if (Menu.Select(2))
                        gameState = GameStates.Highscore;
                    if (Menu.Select(3))
                        gameState = GameStates.Menu;
                    Menu.Update(gameTime);

                    break;
            }

            base.Update(gameTime);
        }
        


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);
            switch (gameState)
            {
                case GameStates.Intro:
                    GraphicsDevice.Clear(Color.Black);
                    spriteBatch.Begin();
                    Menu.Draw(spriteBatch, 0, -500, 0);
                    spriteBatch.End();
                    break;
                case GameStates.Menu:
                    spriteBatch.Begin();
                    Menu.Draw(spriteBatch, 350 - 262/2, 250, 30);
                    spriteBatch.Draw(titleTexture, new Microsoft.Xna.Framework.Rectangle(0, 0, 700, 700), Color.White);
                    spriteBatch.End();
                    break;
                case GameStates.InGame:
                    spriteBatch.Begin();
                    Menu.Draw(spriteBatch, 0, 0, 0);
                    InGame.Draw(spriteBatch);

                    spriteBatch.End();
                    break;
                case GameStates.Highscore:
                    spriteBatch.Begin();
                    Menu.Draw(spriteBatch, 350 - 262 / 2, 770, 0);
                    SaveFile.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
                case GameStates.Credits:
                    spriteBatch.Begin();
                    Menu.Draw(spriteBatch, 350 - 262 / 2, 770, 0);

                    spriteBatch.End();
                    break;
                case GameStates.GameOver:
                    spriteBatch.Begin();
                    Menu.Draw(spriteBatch, 350 - 262 / 2, 500, 30);
                    spriteBatch.End();

                    break;
            }

            base.Draw(gameTime);
        }
    }
}
