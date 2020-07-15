using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
// THIS IS THE COMPONENT THAT ALL OTHER COMPONENTS ARE GONNA INHERIT
namespace Reeksamen.Scripts.Components
{
    public abstract class Component
    {
        public GameObject GameObject { get; set; }

        public bool IsEnable { get; set; } = true;


        //Kaldes en gang når den startes
        public virtual void Awake()
        {

        }
        //Køres efter Awake
        public virtual void Start()
        {

        }
        public virtual void Update(GameTime gameTime)
        {


        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
        public virtual void Destroy()
        {

        }
        #region Instantiate And Destroy
        /// <summary>
        /// This will Instantiate a new gameobject to the scene
        /// </summary>
        /// <param name="gameObject">the game object to be added to the game</param>
        public void Instantiate(GameObject gameObject)
        {
            this.GameObject.MyScene.Instantiate(gameObject);
        }
        /// <summary>
        /// This will destroy this gameobject
        /// </summary>
        /// <param name="gameObject">the game object to be destroyed</param>
        public void Destroy(GameObject gameObject)
        {
            this.GameObject.MyScene.Destroy(gameObject);
        }
        #endregion
    }
}
