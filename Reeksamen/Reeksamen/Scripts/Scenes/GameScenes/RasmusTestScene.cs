using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reeksamen.Scripts.Components;
using Reeksamen.Scripts.Containers;
using Reeksamen.Scripts.Enums;
using Reeksamen.Scripts.PlayerComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
//Rasmus Scene
namespace Reeksamen.Scripts.Scenes.GameScenes
{
    public class RasmusTestScene : Scene
    {
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Initialize()
        {
            RasmusTestHalloj();
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

        public void RasmusTestHalloj()
        {
            //Creating the player
            GameObject playerGameObject = new GameObject();
            playerGameObject.Transform.Position = new Vector2(100, 100);
            SpriteRenderer spriteRenderer = new SpriteRenderer(SpriteContainer.Instant.PlayerSprite);
            Player player = new Player();
            playerGameObject.AddComponent(spriteRenderer);
            playerGameObject.AddComponent(player);
            player.playerHitBox = spriteRenderer.sprite.Bounds;
            playerGameObject.Tag = "Player";
            playerGameObject.AddComponent(new Collision(spriteRenderer){ CollisionEvents = true });
            Console.WriteLine("Rasmus Test");
            Instantiate(playerGameObject);

            //Creating Wall
            GameObject wallGameObject = new GameObject();
            wallGameObject.Transform.Position = new Vector2(150, 150);
            spriteRenderer = new SpriteRenderer(SpriteContainer.Instant.WallSprite);
            wallGameObject.AddComponent(spriteRenderer);
            wallGameObject.AddComponent(new Collision(spriteRenderer));
            wallGameObject.Tag = "Terrain";
            Instantiate(wallGameObject);

            //Creating Wall
            GameObject wallGameObject1 = new GameObject();
            wallGameObject1.Transform.Position = new Vector2(173, 150);
            spriteRenderer = new SpriteRenderer(SpriteContainer.Instant.WallSprite);
            wallGameObject1.AddComponent(spriteRenderer);
            wallGameObject1.AddComponent(new Collision(spriteRenderer));
            wallGameObject1.Tag = "Terrain";
            Instantiate(wallGameObject1);


        }
        //Shows how to use GetComponent
        public void ColliderEksempel(GameObject collidedGameObject)
        {
            if (collidedGameObject.GetComponent<Player>() != null)
            {
                Player player = collidedGameObject.GetComponent<Player>();
                player.TakeDmg(5);
                
            }
        }
    }
}
