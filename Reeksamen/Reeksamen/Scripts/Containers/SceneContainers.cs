using Microsoft.Xna.Framework;
using Reeksamen.Scripts.Enums;
using Reeksamen.Scripts.Scenes;
using Reeksamen.Scripts.Scenes.GameScenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//HERE LIES ALL THE DIFFERENT SCENES IN OUR PROJECT
namespace Reeksamen.Scripts.Containers
{
    public class SceneContainers
    {

        private List<Scene> scenes = new List<Scene>();
        public List<Scene> Scenes { get => scenes; set => scenes = value; }


        public void Initialize()
        {
            MakeScenes();
        }
        private void MakeScenes()
        {
            GameScene gameScene = new GameScene()
            {
                Name = SceneEnumNames.GameScene.ToString()
            };
            Scenes.Add(gameScene);
            
            PickScene pickScene = new PickScene()
            {
                Name = SceneEnumNames.ScenePick.ToString()
            };
            Scenes.Add(pickScene);

            RasmusTestScene rasmus = new RasmusTestScene()
            {
                Name = SceneEnumNames.RasmusTest.ToString()
            };
            Scenes.Add(rasmus);

            LauTestScene lau = new LauTestScene()
            {
                Name = SceneEnumNames.LauTest.ToString()
            };
            Scenes.Add(lau);

            AndreasScene andreas = new AndreasScene()
            {
                Name = SceneEnumNames.AndreasTest.ToString()
            };
            Scenes.Add(andreas);
        }
        public Scene ReturnScene(SceneEnumNames name)
        {
            foreach (Scene item in scenes)
            {
                if (item.Name == name.ToString())
                {
                    return item;
                }
            }
            return null;
        }
    }
}
