using Reeksamen.Scripts.Components;
using Reeksamen.Scripts.Containers;
using Reeksamen.Scripts.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//This Is What We Are Gonna Use To Spawn Our Enemies
namespace Reeksamen.Scripts.FactoryPattern
{
    class EnemyFactory : Factory
    {
        private static EnemyFactory instance;
        //Singleton Pattern for EnviormentFactory
        public static EnemyFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemyFactory();
                }

                return instance;
            }
        }
        public override GameObject Create(string type)
        {
            GameObject go = new GameObject();
            SpriteRenderer spriteRenderer = new SpriteRenderer();
            spriteRenderer.LayerDepth = 0.2f;
            go.AddComponent(spriteRenderer);

            switch (type)
            {
                case "Zombie":
                    spriteRenderer.SetNewImage(SpriteContainer.Instant.ZombieSprite);
                    go.AddComponent(new EnemyZombie());
                    break;

                //TODO: Add boss in spritecontainer
                case "Boss":
                    spriteRenderer.SetNewImage(SpriteContainer.Instant.FloorSprite);
                    break;
            }
            return go;
        }


    }
}
