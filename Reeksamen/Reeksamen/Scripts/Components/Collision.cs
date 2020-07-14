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
        SpriteBatch Rectangle;

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
            base.Update(gameTime);
        }
        public void GroundCollisionDetection(GameObject other)
        {
            //t = terrain | this = player/enemy
            if (other.Tag == "Terrain" && other.Tag != "Terrain")
                {
                    //Bottom Player Collision //(this.spriteRect.Top + this.velocity.Y < t.spriteRect.Bottom && this.spriteRect.Bottom > t.spriteRect.Bottom && this.spriteRect.Right > t.spriteRect.Left && this.spriteRect.Left < t.spriteRect.Right)
                    if (this.rectangle.Bottom + actualVelocity.Y > other.spriteRect.Top && this.spriteRect.Top < other.spriteRect.Top && this.spriteRect.Right > other.spriteRect.Left && this.spriteRect.Left < other.spriteRect.Right /*&& isGrounded == false*/)
                    {
                        gamePosition.Y = other.gamePosition.Y - (spriteRect.Height + other.spriteRect.Height) / 2;
                        if (velocity.Y < 0) velocity.Y = 0;
                        isGrounded = true;
                        standingOn = other;
                    }
                    //Top Player Collision //(this.spriteRect.Bottom + this.velocity.Y > t.spriteRect.Top && this.spriteRect.Top < t.spriteRect.Top && this.spriteRect.Right > t.spriteRect.Left && this.spriteRect.Left < t.spriteRect.Right /*&& isGrounded == false*/)
                    if (this.spriteRect.Top + actualVelocity.Y < other.spriteRect.Bottom && this.spriteRect.Bottom > other.spriteRect.Bottom && this.spriteRect.Right > other.spriteRect.Left && this.spriteRect.Left < other.spriteRect.Right)
                    {
                        if (velocity.Y > 0) velocity.Y = 0;
                    }
                    //Right Player Collision
                    if (this.spriteRect.Left + actualVelocity.X < other.spriteRect.Right && this.spriteRect.Right > other.spriteRect.Right && this.spriteRect.Bottom > other.spriteRect.Top && this.spriteRect.Top < other.spriteRect.Bottom /*&& isGrounded == false*/)
                    {
                        gamePosition.X = other.gamePosition.X + (spriteRect.Width + other.spriteRect.Width) / 2;
                        velocity.X = 0;
                    }
                    //Left Player Collision
                    if (spriteRect.Right + actualVelocity.X > other.spriteRect.Left && spriteRect.Left < other.spriteRect.Left && this.spriteRect.Bottom > other.spriteRect.Top && this.spriteRect.Top < other.spriteRect.Bottom /*&&                                              isGrounded == false*/)
                    {
                        gamePosition.X = other.gamePosition.X - (spriteRect.Width + other.spriteRect.Width) / 2;
                        velocity.X = 0;
                    }
                }
            }
        }
    }
