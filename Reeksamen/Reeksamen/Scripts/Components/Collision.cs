using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reeksamen.Scripts.PlayerComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.Components
{
    class Collision : Component
    {
        public Rectangle rectangle;

        public override void Awake()
        {
            base.Awake();
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
            GroundCollisionDetection(GameObject);
            base.Update(gameTime);
        }
        public void GroundCollisionDetection(GameObject other)
        {

        //    //t = terrain | this = player/enemy
            if (other.Tag == "Terrain" && other.Tag != "Terrain")
               {
                Console.WriteLine("im being run ");
        //            //Bottom Player Collision //(this.spriteRect.Top + this.velocity.Y < t.spriteRect.Bottom && this.spriteRect.Bottom > t.spriteRect.Bottom && this.spriteRect.Right > t.spriteRect.Left && this.spriteRect.Left < t.spriteRect.Right)
                    if (this.rectangle.Bottom > other.rectangle.Top && this.rectangle.Top < other.rectangle.Top && this.rectangle.Right > other.rectangle.Left && this.rectangle.Left < other.rectangle.Right /*&& isGrounded == false*/)
                    {
                    //GameObject.Transform.Position.Y = other.gamePosition.Y - (spriteRect.Height + other.spriteRect.Height) / 2;
                    //if (velocity.Y < 0) velocity.Y = 0;
                    //isGrounded = true;
                    //standingOn = other;
                    Console.WriteLine("I HIT A WALL1");
                }
        //            //Top Player Collision //(this.spriteRect.Bottom + this.velocity.Y > t.spriteRect.Top && this.spriteRect.Top < t.spriteRect.Top && this.spriteRect.Right > t.spriteRect.Left && this.spriteRect.Left < t.spriteRect.Right /*&& isGrounded == false*/)
                    if (this.rectangle.Top < other.rectangle.Bottom && this.rectangle.Bottom > other.rectangle.Bottom && this.rectangle.Right > other.rectangle.Left && this.rectangle.Left < other.rectangle.Right)
                    {
                    //                if (velocity.Y > 0) velocity.Y = 0;
                    Console.WriteLine("I HIT A WALL2");
                    }
        //            //Right Player Collision
                    if (this.rectangle.Left < other.rectangle.Right && this.rectangle.Right > other.rectangle.Right && this.rectangle.Bottom > other.rectangle.Top && this.rectangle.Top < other.rectangle.Bottom /*&& isGrounded == false*/)
                    {
                    //                gamePosition.X = other.gamePosition.X + (spriteRect.Width + other.spriteRect.Width) / 2;
                    //                velocity.X = 0;
                    Console.WriteLine("I HIT A WALL3");
                    }
        //            //Left Player Collision
                    if (rectangle.Right > other.rectangle.Left && rectangle.Left < other.rectangle.Left && this.rectangle.Bottom > other.rectangle.Top && this.rectangle.Top < other.rectangle.Bottom /*&&                                              isGrounded == false*/)
                    {
                    //                gamePosition.X = other.gamePosition.X - (spriteRect.Width + other.spriteRect.Width) / 2;
                    //                velocity.X = 0;
                    Console.WriteLine("I HIT A WALL4");
                }
                }
            }
        }
    }
