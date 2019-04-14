using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Viking_Jump
{
    class PlatformManager
    {

        public static List<Platforms> platforms = new List<Platforms>();
        public static List<Texture2D> texture = new List<Texture2D>();
        
        // How many platforms shall spawn?
        private static int spawn = Variables.PlatformSpawnRate;

        // Where shall they spawn?
        private static Rectangle spawnRectangle = new Rectangle(0, -Variables.PlatformSpawnGap, Variables.ScreenSize.Width, 0);

        // How many textures do we have for the platforms?
        private static int textureTotal = Variables.TotalPlatformTextures;
        

        public static void Reset()
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                platforms.RemoveAt(i);
                i--;
            }
            SpawnIntroPlatforms();

        }


        public static void LoadContent(ContentManager Content)
        {
            for (int i = 0; i < textureTotal; i++)
            {
                texture.Add(Content.Load<Texture2D>(@"Textures/Platform_" + i));                
            }

        }

        public static void SpawnPlatforms()
        {
            {
                Random random = new Random();

                for (int i = 0; i < spawn; i++)
                {
                    int randomTexture = random.Next(1, textureTotal) - 1;
                    platforms.Add(new Platforms(texture[randomTexture],
                        new Vector2(random.Next(spawnRectangle.X, spawnRectangle.Width - texture[randomTexture].Width), random.Next(spawnRectangle.Y, spawnRectangle.Height - texture[randomTexture].Height))));
                    
                }

            }

            

            for (int i = 0; i < platforms.Count; i++)
            {
                if (!platforms[i].isVisible)
                {
                    platforms.RemoveAt(i);
                    i--;
                }
            }
        }

        public static void SpawnIntroPlatforms()
        {
            for (int i = 0; i < 5; i++)
            {
                
              platforms.Add(new Platforms(texture[0],
                new Vector2(
                    spawnRectangle.X - texture[1].Width + i* texture[1].Width, Character.position.Y + 100)));

              platforms.Add(new Platforms(texture[3], new Vector2(350 - texture[3].Width/2, Character.position.Y - 700)));
            }

        }



        
        public static void Update(GameTime gameTime)
        {
            foreach (Platforms platform in platforms)
            {
                platform.Update(gameTime);
                Character.Collision(new Rectangle((int)platform.position.X, (int)platform.position.Y, platform.texture.Width, platform.texture.Height), 0, Variables.ScreenSize.Width, 500, Variables.ScreenSize.Height*2);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Platforms platform in platforms)
            {
                platform.Draw(spriteBatch);
            }
        }


    }
}
