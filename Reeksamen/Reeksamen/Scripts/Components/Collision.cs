using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using Reeksamen.Scripts.Containers;
using Reeksamen.Scripts.ObserverPattern;
using Reeksamen.Scripts.PlayerComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.Components
{
    public class Collision : Component
    {
        public bool CollisionEvents { get; set; }
        private GameEvent onCollisionEvent = new GameEvent("Collision");
        private Vector2 size;
        private Vector2 origin;
        private Texture2D texture;
        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle
                    (
                    (int)(GameObject.Transform.Position.X - origin.X),
                    (int)(GameObject.Transform.Position.Y - origin.Y),
                    (int)size.X,
                    (int)size.Y
                    );
            }
        }

        public override void Awake()
        {
            base.Awake();
        }

        public override void Destroy()
        {
            if(GameObject.MyScene.collisions.Contains(this))
            {
                GameObject.MyScene.collisions.Remove(this);
            }
            base.Destroy();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, CollisionBox, null, Color.Red, 0, origin, SpriteEffects.None, 0);
        }

        public override void Start()
        {

            base.Start();
        }

        public override void Update(GameTime gameTime)
        {
            //GroundCollisionDetection(GameObject);
            base.Update(gameTime);
        }
        //If the object dosent need to do anything when colliding use this
        public Collision(SpriteRenderer spriteRenderer)
        {
            this.origin = spriteRenderer.Origin;
            this.size = new Vector2(spriteRenderer.sprite.Width, spriteRenderer.sprite.Height);
            texture = SpriteContainer.Instant.PlayerSprite;
        }
        //If the object needs to do anything when colliding use this
        public Collision(SpriteRenderer spriteRenderer, IGameListener gameListener)
        {
            onCollisionEvent.Attach(gameListener);
            this.origin = spriteRenderer.Origin;
            this.size = new Vector2(spriteRenderer.sprite.Width, spriteRenderer.sprite.Height);
            texture = SpriteContainer.Instant.PlayerSprite;
        }
        public void OnCollisionEnter(Collision other)
        {   
            if (CollisionEvents)
            {
                if (other != this /*&& other.GameObject.Tag == "Terrain"*/)
                {
                    if (this.CollisionBox.Intersects(other.CollisionBox))
                    {
                        Console.WriteLine("We are now Colliding");
                        //TODO
                        //Collision stuff
                        onCollisionEvent.Notify(other);
                    }
                }
            }
        }
        //public void GroundCollisionDetection(GameObject other)
        //{
            
        //    //t = terrain | this = player/enemy
        //    if (other.Tag == "Terrain" && other.Tag != "Terrain")
        //       {
        //        Console.WriteLine("im being run ");
        ////            //Bottom Player Collision //(this.spriteRect.Top + this.velocity.Y < t.spriteRect.Bottom && this.spriteRect.Bottom > t.spriteRect.Bottom && this.spriteRect.Right > t.spriteRect.Left && this.spriteRect.Left < t.spriteRect.Right)
        //            if (this.rectangle.Bottom > other.rectangle.Top && this.rectangle.Top < other.rectangle.Top && this.rectangle.Right > other.rectangle.Left && this.rectangle.Left < other.rectangle.Right /*&& isGrounded == false*/)
        //            {
        //            //GameObject.Transform.Position.Y = other.gamePosition.Y - (spriteRect.Height + other.spriteRect.Height) / 2;
        //            //if (velocity.Y < 0) velocity.Y = 0;
        //            //isGrounded = true;
        //            //standingOn = other;
        //            Console.WriteLine("I HIT A WALL1");
        //        }
        ////            //Top Player Collision //(this.spriteRect.Bottom + this.velocity.Y > t.spriteRect.Top && this.spriteRect.Top < t.spriteRect.Top && this.spriteRect.Right > t.spriteRect.Left && this.spriteRect.Left < t.spriteRect.Right /*&& isGrounded == false*/)
        //            if (this.rectangle.Top < other.rectangle.Bottom && this.rectangle.Bottom > other.rectangle.Bottom && this.rectangle.Right > other.rectangle.Left && this.rectangle.Left < other.rectangle.Right)
        //            {
        //            //                if (velocity.Y > 0) velocity.Y = 0;
        //            Console.WriteLine("I HIT A WALL2");
        //            }
        ////            //Right Player Collision
        //            if (this.rectangle.Left < other.rectangle.Right && this.rectangle.Right > other.rectangle.Right && this.rectangle.Bottom > other.rectangle.Top && this.rectangle.Top < other.rectangle.Bottom /*&& isGrounded == false*/)
        //            {
        //            //                gamePosition.X = other.gamePosition.X + (spriteRect.Width + other.spriteRect.Width) / 2;
        //            //                velocity.X = 0;
        //            Console.WriteLine("I HIT A WALL3");
        //            }
        ////            //Left Player Collision
        //            if (rectangle.Right > other.rectangle.Left && rectangle.Left < other.rectangle.Left && this.rectangle.Bottom > other.rectangle.Top && this.rectangle.Top < other.rectangle.Bottom /*&&                                              isGrounded == false*/)
        //            {
        //            //                gamePosition.X = other.gamePosition.X - (spriteRect.Width + other.spriteRect.Width) / 2;
        //            //                velocity.X = 0;
        //            Console.WriteLine("I HIT A WALL4");
        //        }
        //        }
        //    }
        } 
    }
