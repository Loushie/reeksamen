using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Reeksamen.Scripts.CommandPattern;
using Reeksamen.Scripts.Components;
using Reeksamen.Scripts.Containers;
using Reeksamen.Scripts.ObserverPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
//The Player Component Add Everything A Player Should Be Able To Here
namespace Reeksamen.Scripts.PlayerComponents
{
    public class Player : Component, IGameListener
    {
        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; private set; }
        
        public float speed;

        private Transform transform;
        //private CanShoot canshoot;
        public Rectangle playerHitBox;

        public Player(Rectangle playerHitBox)
        {
            this.playerHitBox = playerHitBox;
        }

        public Player()
        {
            
            InputHandler.Instance.entity = this;
            LoadDatabaseStats();
        }

        public override void Awake()
        {
            //canshoot = GameObject.GetComponent<CanShoot>();
            base.Awake();
            
        }

        public void Playershoots()
        {
            //if (canshoot != null)
            //{
            //    canshoot.Shoot();
            //}
            
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Start()
        {
            base.Start();
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        private void LoadDatabaseStats()
        {
            //TODO Load Database Stats to Player
            float tmpMaxHealth = 0;
            float tmpSpeed = 0;

            //Used ref since im unsure how to return 2 floats
            SQLlite.SQLite_Database.Instance.GetPlayerData(ref tmpMaxHealth, ref tmpSpeed);
            MaxHealth = tmpMaxHealth;
            CurrentHealth = MaxHealth;
            this.speed = tmpSpeed;

            Console.WriteLine(MaxHealth);
        }
        public void TakeDmg(int dmg)
        {
            CurrentHealth -= dmg;
            if (CurrentHealth <= 0)
            {
                PlayerDeath();
            }
        }
        private void PlayerDeath()
        {
            //TODO level restart?
        }
        public void Move(Vector2 velocity)
        {
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            velocity *= speed;
            //Console.WriteLine(velocity);
            //Console.WriteLine(GameObject.Transform.Position);

            GameObject.Transform.Translate(velocity * GameWorld.Instance.DeltaTime);
        }

        public void Notify(GameEvent gameEvent, Component component)
        {
            Console.WriteLine("Notify Went off on player component");




        }
    }
}
