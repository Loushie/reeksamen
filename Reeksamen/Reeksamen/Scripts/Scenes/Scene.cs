using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reeksamen.Scripts.Components;
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

        public List<GameObject> gameObjects = new List<GameObject>();
        public List<Collision> collisions { get; set; } = new List<Collision>();
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
                if (go.FirstUpdate == true)
                {
                    go.Start();
                    go.FirstUpdate = false;
                }
                go.Update(gameTime);
            }

            CollisionCheck();
            CallDestroyGameObjects();
            CallInstantiate();
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack,BlendState.AlphaBlend);
            

            foreach (GameObject go in gameObjects)
            {
                go.Draw(spriteBatch);
            }


            spriteBatch.End();
        }

        private void CollisionCheck()
        {
            Collision[] tmpCollision = collisions.ToArray();

            for (int i = 0; i < tmpCollision.Length; i++)
            {
                for (int j = 0; j < tmpCollision.Length; j++)
                {
                    tmpCollision[i].OnCollisionEnter(tmpCollision[j]);
                }
            }
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
            //Here we have the list of gameobjects that are to be created and if its not empty we continue
            if (this.gameObjectsToBeCreated.Count > 0)
            {
                //Here we add a new List and add all the gameobjects from the old list to the new one the reason for this is if something were to be added to the old list while we were using
                //it, it could create crashes or other problems 
                List<GameObject> awakeCall = new List<GameObject>();

                awakeCall.AddRange(this.gameObjectsToBeCreated);

                this.gameObjectsToBeCreated.Clear();

                foreach (GameObject go in awakeCall)
                {
                    go.MyScene = this;
                    go.Awake();
                    gameObjects.Add(go);
                    
                    if(go.GetComponent<Collision>() != null)
                    {
                        collisions.Add(go.GetComponent<Collision>());
                    }
                }
            }
        }
        private void CallDestroyGameObjects()
        {
            //Here we have the list of gameobjects that are to be created and if its not empty we continue
    
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
