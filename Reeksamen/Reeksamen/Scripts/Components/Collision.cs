using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using Reeksamen.Scripts.Containers;
using Reeksamen.Scripts.ObserverPattern;
using Reeksamen.Scripts.PlayerComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.Components
{
    public class Collision : Component
    {
        private int offset = 2; //used in the collision if charecter starts Teleporting around the objects adjusting this might fix it. Lower is better.


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
                if (other != this && other.GameObject.Tag == "Terrain")
                {
                    if (this.CollisionBox.Intersects(other.CollisionBox))
                    {
                        //Console.WriteLine("We are now Colliding");
                        //TODO
                        //Collision stuff
                        onCollisionEvent.Notify(other);

                        //Bottom of player collision
                        if (this.CollisionBox.Bottom > other.CollisionBox.Top && this.CollisionBox.Top < other.CollisionBox.Top && this.CollisionBox.Right - offset > other.CollisionBox.Left && this.CollisionBox.Left + offset < other.CollisionBox.Right) // the + & - 10 is so that side collision can take place before top or bottom
                        {
                            this.GameObject.Transform.Position.Y = other.GameObject.Transform.Position.Y - (this.CollisionBox.Height + other.CollisionBox.Height) / 1.9f ; // 1.9 makes it able to get off a block it has collided with any higher and the charecter gets stuck
                        }
                        //Top of player collision
                        if (this.CollisionBox.Top < other.CollisionBox.Bottom && this.CollisionBox.Bottom > other.CollisionBox.Bottom && this.CollisionBox.Right - offset > other.CollisionBox.Left && this.CollisionBox.Left + offset < other.CollisionBox.Right) // the + & - 10 is so that side collision can take place before top or bottom
                        {
                            this.GameObject.Transform.Position.Y = other.GameObject.Transform.Position.Y + (this.CollisionBox.Height + other.CollisionBox.Height) / 2.2f; // 2.2 makes it not bounce all over the place
                        }
                        //Right side of player collision
                        if (this.CollisionBox.Left < other.CollisionBox.Right && this.CollisionBox.Right > other.CollisionBox.Right && this.CollisionBox.Bottom - offset > other.CollisionBox.Top && this.CollisionBox.Top + offset < other.CollisionBox.Bottom)
                        {
                            this.GameObject.Transform.Position.X = other.GameObject.Transform.Position.X + (this.CollisionBox.Width + other.CollisionBox.Width) / 1.7f; // 1.7 makes it not bounce all over the place
                        }
                        if (this.CollisionBox.Right > other.CollisionBox.Left && this.CollisionBox.Left < other.CollisionBox.Left && this.CollisionBox.Bottom - offset > other.CollisionBox.Top && this.CollisionBox.Top + offset < other.CollisionBox.Bottom)
                        {
                            //gamePosition.X = other.gamePosition.X - (spriteRect.Width + other.spriteRect.Width) / 2;
                            this.GameObject.Transform.Position.X = other.GameObject.Transform.Position.X - (this.CollisionBox.Width + other.CollisionBox.Width) / 2.3f;
                                
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
            }
        } 
    }
