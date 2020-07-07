using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Reeksamen.Scripts.Containers;
using Reeksamen.Scripts.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//A Less Cluttered GameWorld
namespace Reeksamen.Scripts.Container
{
    public class Global
    {
        

        public void Initialize()
        {
            SceneManager.Instant.Initialize();

        }
        public void LoadContent(ContentManager content)
        {
            SpriteContainer.Instant.LoadContent(content);

        }

        public void Update(GameTime gametime)
        {
            SceneManager.Instant.UpdateScenes(gametime);


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SceneManager.Instant.DrawScenes(spriteBatch);

        }
    }
}
