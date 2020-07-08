using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Reeksamen.Scripts.CommandPattern;
using Reeksamen.Scripts.Components;
using Reeksamen.Scripts.Containers;
using Reeksamen.Scripts.PlayerComponents;
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

        InputHandler playerInput;
        private Player player;


        public void Initialize()
        {
            SceneManager.Instant.Initialize();

            GameObject go = new GameObject();
            player = new Player();

            go.AddComponent(player);

            go.AddComponent(new SpriteRenderer());

            gameObjects.Add(go);

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Awake();
            }
        }
        public void LoadContent(ContentManager content)
        {
            SpriteContainer.Instant.LoadContent(content);

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Start();
            }
        }

        public void Update(GameTime gametime)
        {
            SceneManager.Instant.UpdateScenes(gametime);
            InputHandler.Instance.Execute(player);


            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update(gametime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SceneManager.Instant.DrawScenes(spriteBatch);

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }

        }
    }
}
