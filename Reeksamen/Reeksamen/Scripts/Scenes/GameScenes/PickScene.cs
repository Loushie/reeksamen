using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Reeksamen.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//The Initial Scene You Can Change To Any Other Scene With
namespace Reeksamen.Scripts.Scenes.GameScenes
{
    public class PickScene : Scene
    {
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnSwitchAwayFromThisScene()
        {
            base.OnSwitchAwayFromThisScene();
        }

        public override void OnSwitchToThisScene()
        {
            base.OnSwitchToThisScene();
        }

        public override void Update(GameTime gameTime)
        {
            InputCheck();
            base.Update(gameTime);
        }
        public void InputCheck()
        {
            // Poll for current keyboard state
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.D1))
            {
                SceneManager.Instant.ChangeScene(SceneEnumNames.RasmusTest);
            }
            if (state.IsKeyDown(Keys.D2))
            {
                SceneManager.Instant.ChangeScene(SceneEnumNames.LauTest);
            }
            if (state.IsKeyDown(Keys.D3))
            {
                SceneManager.Instant.ChangeScene(SceneEnumNames.AndreasTest);
            }
        }
    }
}
