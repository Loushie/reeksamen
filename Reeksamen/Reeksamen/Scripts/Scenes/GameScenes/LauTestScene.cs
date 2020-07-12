using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reeksamen.Scripts.Components;
using Reeksamen.Scripts.Containers;
using Reeksamen.Scripts.PlayerComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Lau Scene
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
            GameObject playergameobject = new GameObject();
            GameObject enemygameobject = new GameObject();


            SpriteRenderer spriteRenderer = new SpriteRenderer(SpriteContainer.Instant.playerSprite);
            Player player = new Player();
            CanShoot canShoot = new CanShoot();

            playergameobject.AddComponent(spriteRenderer);
            playergameobject.AddComponent(player);
            playergameobject.AddComponent(canShoot);
            
            enemygameobject.AddComponent(canShoot);



            Instantiate(playergameobject);

        }
    }
}
