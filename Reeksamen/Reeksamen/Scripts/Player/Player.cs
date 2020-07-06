using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts
{
    class Player
    {
        private Texture2D sprite;
        Rectangle rectangle;

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Player");
            rectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, rectangle, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0);
        }
    }
}
