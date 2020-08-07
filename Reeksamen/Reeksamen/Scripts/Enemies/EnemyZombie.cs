using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reeksamen.Scripts.Components;
using Reeksamen.Scripts.PlayerComponents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Reeksamen.Scripts.Enemies
{
    class EnemyZombie : Component
    {
        private Stack<Tile> path = new Stack<Tile>();
        private GameObject target;
        private Vector2 moveToPosition;
        private float speed = 50;
        private float safeGuardMovement = 2f; //change this if the enemy gets stuck between 2 tiles
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
        //Fix this so its less performance heavy
        public override void Start()
        {
            moveToPosition = GameObject.Transform.Position;
            foreach (GameObject item in GameObject.MyScene.gameObjects)
            {
                if (item.GetComponent<Player>() != null)
                {
                    target = item;
                }
            }
            path = AStar.Instance.DoAStar(target.Transform.Position, GameObject.Transform.Position);

            base.Start();
        }

        public override void Update(GameTime gameTime)
        {
            EnemyMove();
            base.Update(gameTime);
        }
        public void EnemyMove()
        {
            if (Vector2.Distance(target.Transform.Position, GameObject.Transform.Position) > 10)
            {
                if (moveToPosition.X + safeGuardMovement > GameObject.Transform.Position.X && moveToPosition.X - safeGuardMovement < GameObject.Transform.Position.X && (moveToPosition.Y + safeGuardMovement > GameObject.Transform.Position.Y && moveToPosition.Y - safeGuardMovement < GameObject.Transform.Position.Y))
                {
                    GetNextPath();
                    /*if (moveToPosition.Y + safeGuardMovement > GameObject.Transform.Position.Y && moveToPosition.Y - safeGuardMovement < GameObject.Transform.Position.Y)
                    {
                        GetNextPath();
                    }*/
                }

                Vector2 direction = new Vector2(0, 0);

                //The moving of the Enemy
                if (moveToPosition.X > GameObject.Transform.Position.X)
                {
                    direction += new Vector2(1, 0);
                }
                else if (moveToPosition.X < GameObject.Transform.Position.X)
                {
                    direction += new Vector2(-1, 0);
                }

                if (moveToPosition.Y > GameObject.Transform.Position.Y)
                {
                    direction += new Vector2(0, 1);
                }
                else if (moveToPosition.Y < GameObject.Transform.Position.Y)
                {
                    direction += new Vector2(0, -1);
                }

                Console.WriteLine(moveToPosition);
                Console.WriteLine(path.Count);


                //GameObject.Transform.Translate(direction * speed * GameWorld.Instance.DeltaTime);
                GameObject.Transform.Position += direction * speed * GameWorld.Instance.DeltaTime;
            }
        }
        private void GetNextPath()
        {
            if (AStar.Instance.runAStar == false)
            {
            path = AStar.Instance.DoAStar(target.Transform.Position, GameObject.Transform.Position);
            }
            if (path.Count > 0)
            {
                moveToPosition = path.Pop().GameObject.Transform.Position;
            }
        }
    }
}
