using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reeksamen.Scripts.Containers;
using Reeksamen.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.Scenes
{
    public class SceneManager
    {
        #region Singleton
        private static SceneManager instant;

        public static SceneManager Instant
        {
            get
            {
                if (instant == null)
                {
                    instant = new SceneManager();
                }
                return instant;
            }
        }




        #endregion


        private Scene currentScene;
        private SceneContainers sceneContainer = new SceneContainers();

        public SceneContainers SceneContainer { get => sceneContainer; private set => sceneContainer = value; }

        public Scene CurrentScene
        {
            get
            {
                return currentScene;
            }
            set
            {
                if (currentScene != value)
                {
                    if (currentScene != null)
                    {
                        currentScene.OnSwitchAwayFromThisScene();
                    }
                    currentScene = value;
                    currentScene.OnSwitchToThisScene();
                }
            }
        }
        public void Initialize()
        {
            sceneContainer.Initialize();
            CurrentScene = sceneContainer.Scenes[0];
        }
        public void UpdateScenes(GameTime gameTime)
        {
            currentScene.Update(gameTime);
        }
        public void DrawScenes(SpriteBatch spriteBatch)
        {
            currentScene.Draw(spriteBatch);
        }
        public void ChangeScene(SceneEnumNames name)
        {
            Scene tmp = sceneContainer.ReturnScene(name);
            if (tmp != null)
            {
                CurrentScene = tmp;
            }
        }
    }
}
