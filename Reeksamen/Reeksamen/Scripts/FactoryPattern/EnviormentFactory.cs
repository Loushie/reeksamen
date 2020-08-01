using Microsoft.Xna.Framework;
using Reeksamen.Scripts.Components;
using Reeksamen.Scripts.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.FactoryPattern
{
    class EnviormentFactory : Factory
    {
        private static EnviormentFactory instance;
        //Singleton Pattern for EnviormentFactory
        public static EnviormentFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnviormentFactory();
                }

                return instance;
            }
        }
        public override GameObject Create(string type)
        {
            GameObject go = new GameObject();
            SpriteRenderer spriteRenderer = new SpriteRenderer();
            go.AddComponent(spriteRenderer);

            switch (type)
            {
                case "Wall":
                    spriteRenderer.SetNewImage(SpriteContainer.Instant.WallSprite);
                    go.AddComponent(new Collision(spriteRenderer));
                    break;

                case "Floor":

                    break;
            }

        }
    }
}
