using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reeksamen.Scripts.Components;
using Reeksamen.Scripts.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.Scenes.GameScenes
{
    public class LauTestScene : Scene
    {
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Initialize()
        {
            LauTestHalloj();
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
        public void LauTestHalloj()
        {
            GameObject playerGameObject = new GameObject();
            playerGameObject.Transform.Position = new Vector2(50, 50);
            SpriteRenderer spriteRenderer = new SpriteRenderer(SpriteContainer.Instant.playerSprite);
            playerGameObject.AddComponent(spriteRenderer);
            Console.WriteLine("Lau Test");
            Instantiate(playerGameObject);
        }
    }
}
