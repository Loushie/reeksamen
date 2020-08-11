using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reeksamen.Scripts.SQLlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.Scenes.GameScenes
{
    class GameScene : Scene
    {
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Initialize()
        {
            //SQL
            SQLite_Database.Instance.SetupPlayerInDatabase();


            MakeWorld world = new MakeWorld();
            world.MakeNewWorld(this);
            //MakeWorld makes the world and places the player and enemies
            base.Initialize();

        }

        public override void OnSwitchAwayFromThisScene()
        {
            base.OnSwitchAwayFromThisScene();
        }

        public override void OnSwitchToThisScene()
        {
            base.OnSwitchToThisScene();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
