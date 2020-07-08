using Microsoft.Xna.Framework;
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
        private float playerSpeed;

        private InputHandler inputHandler;

        private Transform transform;

        public Player()
        {
            this.playerSpeed = 100;
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

        public override string ToString()
        {
            return "Player";
        }

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
            base.Update(gameTime);
            InputHandler.Instance.Execute(player);
        }
        public void Move(Player player, Vector2 playerSpeed)
        {


            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            velocity *= speed;

            GameObject.Transform.Translate(velocity * GameWorld.Instance.Deltatime);
            /*Vector2 NewMove = new Vector2(0,0);
            // Poll for current keyboard state
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A))
            {
                NewMove += new Vector2(-1, 0);
            }
            if (state.IsKeyDown(Keys.S))
            {
                NewMove += new Vector2(0, 1);
            }
            if (state.IsKeyDown(Keys.D))
            {
                NewMove += new Vector2(1, 0);
            }
            if (state.IsKeyDown(Keys.W))
            {
                NewMove += new Vector2(0, -1);
            }
            //TODO Fix later
            GameObject.Transform.Position += playerSpeed * NewMove * (float)gameTime.ElapsedGameTime.TotalSeconds;

            Console.WriteLine(GameObject.Transform.Position);*/
        }
    }
}
