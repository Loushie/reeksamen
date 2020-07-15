using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//What All Other Scenes Inherit
namespace Reeksamen.Scripts.Scenes
{
    public class Scene
    {
        protected string name;
        protected bool isInitialized = false;

        private List<GameObject> gameObjectsToBeCreated = new List<GameObject>();
        private List<GameObject> gameObjectsToBeDestroyed = new List<GameObject>();

        protected List<GameObject> gameObjects = new List<GameObject>();
        public string Name { get => name; set => name = value; }


        public virtual void Initialize()
        {
            isInitialized = true;
        }
        public virtual void OnSwitchToThisScene()
        {
            if (isInitialized == false)
            {
                Initialize();
            }
        }
        public virtual void OnSwitchAwayFromThisScene()
        {

        }
        public virtual void Update(GameTime gameTime)
        {
            foreach (GameObject go in gameObjects)
            {
                go.Update(gameTime);
            }

            CallDestroyGameObjects();
            CallInstantiate();
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            

            foreach (GameObject go in gameObjects)
            {
                go.Draw(spriteBatch);
            }


            spriteBatch.End();
        }
        #region Instantiate And Destroy
        /// <summary>
        /// This will Instantiate a new gameobject to the scene
        /// </summary>
        /// <param name="gameObject">the game object to be added to the game</param>
        public void Instantiate(GameObject gameObject)
        {
            this.gameObjectsToBeCreated.Add(gameObject);
        }
        /// <summary>
        /// This will destroy this gameobject
        /// </summary>
        /// <param name="gameObject">the game object to be destroyed</param>
        public void Destroy(GameObject gameObject)
        {
            this.gameObjectsToBeDestroyed.Add(gameObject);
        }

        private void CallInstantiate()
        {
            if (this.gameObjectsToBeCreated.Count > 0)
            {
                List<GameObject> awakeCall = new List<GameObject>();

                awakeCall.AddRange(this.gameObjectsToBeCreated);

                this.gameObjectsToBeCreated.Clear();

                foreach (GameObject go in awakeCall)
                {
                    go.MyScene = this;
                    go.Awake();
                    gameObjects.Add(go);
                }
            }
        }
        private void CallDestroyGameObjects()
        {
            if (this.gameObjectsToBeDestroyed.Count > 0)
            {
                List<GameObject> destroyCall = new List<GameObject>();

                destroyCall.AddRange(this.gameObjectsToBeCreated);

                this.gameObjectsToBeDestroyed.Clear();

                foreach (GameObject go in destroyCall)
                {
                    if (gameObjects.Contains(go))
                    {
                        gameObjects.Remove(go);
                    }
                    go.Destroy();

                }
            }
        }
        #endregion
    }
}
