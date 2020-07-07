using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//HERE LIES ALL OUR SPRITES
namespace Reeksamen.Scripts.Containers
{
    public class SpriteContainer
    {
        #region Singleton
        private static SpriteContainer instant;

        public static SpriteContainer Instant
        {
            get
            {
                if (instant == null)
                {
                    instant = new SpriteContainer();
                }
                return instant;
            }
        }
        #endregion

        public Texture2D playerSprite;

        public void LoadContent(ContentManager content)
        {
            playerSprite = content.Load<Texture2D>("Player");
        }


    }
}
