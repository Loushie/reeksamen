using Microsoft.Xna.Framework;
using Reeksamen.Scripts.Components;
using Reeksamen.Scripts.Containers;
using Reeksamen.Scripts.PlayerComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.FactoryPattern
{
    class PlayerFactory : Factory
    {
        private static PlayerFactory instance;
        //Singleton Pattern for EnviormentFactory
        public static PlayerFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerFactory();
                }

                return instance;
            }
        }
        public override GameObject Create(string type)
        {
            //Creating the player
            GameObject playerGameObject = new GameObject();
            SpriteRenderer spriteRenderer = new SpriteRenderer(SpriteContainer.Instant.PlayerSprite);
            Player player = new Player();
            playerGameObject.AddComponent(spriteRenderer);
            playerGameObject.AddComponent(player);
            player.playerHitBox = spriteRenderer.sprite.Bounds;
            playerGameObject.Tag = "Player";
            playerGameObject.AddComponent(new Collision(spriteRenderer, player) { CollisionEvents = true });
            spriteRenderer.LayerDepth = 0.3f;
            return playerGameObject;
        }


    }
}
