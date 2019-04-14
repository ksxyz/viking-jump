using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Viking_Jump
{
    public class Background
    {
        public static List<Texture2D> backgroundTextures = new List<Texture2D>();
        // How many levelsTextures there are
        private static int levelAmount = Variables.TotalBackgroundTextures;
        // How many times a texture shall repeat
        private static int levelGap = Variables.BackgroundLevelLeangth;

        public static void LoadContent(ContentManager Content)
        {
            for (int i = 0; i < levelAmount; i++)
            {
                 backgroundTextures.Add(Content.Load<Texture2D>("Textures/Background_"+ i));
            }
        }


        public static void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(backgroundTextures[0], new Rectangle(0, (int)InGame.WorldHeight-800 + backgroundTextures[0].Height, Variables.ScreenSize.Width, backgroundTextures[0].Height), Color.White);

            for (int k = 0; k < Variables.BackgroundLevelRepeat; k++)
            {
                for (int i = 1; i < levelAmount; i++)
                {
                    for (int j = 0; j < levelGap; j++)
                    {

                        spriteBatch.Draw(backgroundTextures[i],
                            new Rectangle(0, (int)InGame.WorldHeight - 800 - ((((levelAmount-1)*levelGap * k) + levelGap * (i - 1) + j) * backgroundTextures[i].Height),
                                Variables.ScreenSize.Width, backgroundTextures[i].Height), Color.White);

                    }
                }
            }
        }
    }
}
