using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reeksamen.Scripts.Components;
using Reeksamen.Scripts.Containers;
using Reeksamen.Scripts.PlayerComponents;
using Reeksamen.SqliteFramework;
using Reeksamen.SqliteFramework.Factories;
using Reeksamen.SqliteFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Lau Scene
namespace Reeksamen.Scripts.Scenes.GameScenes
{
    public class LauTestScene : Scene
    {
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Initialize()
        {
            LauTestHalloj();
            base.Initialize();
            SqlTesting();
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
            base.Update(gameTime);
        }
        public void LauTestHalloj()
        {
            GameObject playergameobject = new GameObject();
            GameObject enemygameobject = new GameObject();


            SpriteRenderer spriteRenderer = new SpriteRenderer(SpriteContainer.Instant.playerSprite);
            Player player = new Player();
            CanShoot canShoot = new CanShoot();

            playergameobject.AddComponent(spriteRenderer);
            playergameobject.AddComponent(player);
            playergameobject.AddComponent(canShoot);
            
            enemygameobject.AddComponent(canShoot);



            Instantiate(playergameobject);

        }
        public void SqlTesting()
        {
            AutoTable2 autoTable2 = new AutoTable2();
            autoTable2.MakeTable<Player_Table>();

            Player_TableFac player_TableFac = new Player_TableFac();

            Player_Table player01 = new Player_Table(19, 41);

            player_TableFac.Insert(player01);

            Console.WriteLine(player_TableFac.Get(1).MaxHealth);

            List<Player_Table> players = new List<Player_Table>();
            players = player_TableFac.GetAll();
            foreach (Player_Table item in players)
            {
                Console.WriteLine("ID: " + item.ID);
                Console.WriteLine("MaxHealth: " + item.MaxHealth);
                Console.WriteLine("MoveSpeed: " + item.MoveSpeed);
                Console.WriteLine();
            }

            Player_Table playerUpdate = new Player_Table(9999, 9999);
            playerUpdate.ID = 1;
            player_TableFac.Update(playerUpdate);
        }
    }
}
