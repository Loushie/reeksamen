using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Reeksamen.Scripts.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.PlayerComponents
{
    public class Player : Component
    {
        private float playerSpeed = 50;
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
            InputCheck(gameTime);
            base.Update(gameTime);
        }
        public void InputCheck(GameTime gameTime)
        {
            Vector2 NewMove = new Vector2(0,0);
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

            Console.WriteLine(GameObject.Transform.Position);
        }
    }
}
