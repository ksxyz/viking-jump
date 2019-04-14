using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Viking_Jump
{
    class Platforms
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;

        public bool isVisible = true;




        public Platforms(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;



        }

        public void Update(GameTime gameTime)
        {
            velocity.Y = InGame.worldVelocity;
            position += velocity;
            if (position.Y > 1200)
                isVisible = false;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
