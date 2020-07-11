﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Reeksamen.Scripts.CommandPattern;
using Reeksamen.Scripts.Components;
using Reeksamen.Scripts.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//The Player Component Add Everything A Player Should Be Able To Here
namespace Reeksamen.Scripts.PlayerComponents
{
    public class Player : Component
    {
        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; private set; }

        public float speed;

        private Transform transform;

        public Player()
        {
            
            InputHandler.Instance.entite = this;
            LoadDatabaseStats();
        }

        public override void Awake()
        {
            base.Awake();
            //Placerer Spilleren
            GameObject.Transform.Position = new Vector2(GameWorld.Instance.GraphicsDevice.Viewport.Width/2, GameWorld.Instance.GraphicsDevice.Viewport.Height / 2);
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
            SpriteRenderer spriteRenderer = new SpriteRenderer(SpriteContainer.Instant.playerSprite);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        private void LoadDatabaseStats()
        {
            //TODO Load Database Stats to Player
            //Midlertidig Test Stats in class

            MaxHealth = 100;
            CurrentHealth = MaxHealth;
            this.speed = 100;
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
            Console.WriteLine(velocity);
            Console.WriteLine(GameObject.Transform.Position);

            GameObject.Transform.Translate(velocity * GameWorld.Instance.DeltaTime);
        }
    }
}
