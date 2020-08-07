using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Reeksamen.Scripts.FactoryPattern;
using Reeksamen.Scripts.Scenes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts
{
    class MakeWorld
    {
        private Scene myScene;

        //The size of the sprites filling 1 spot in the grid
        private int sizeOfGrid = 25;



        private List<Tile> tiles = new List<Tile>();

        Tile[,] tileGrid;

        /// <summary>
        /// The Map
        /// 0 = floor
        /// 1 = wall
        /// 2 = enemies
        /// 3 = player
        /// </summary>
        int[,] worldGrid = new int[,]
        {
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            { 1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,2,0,0,0,2,0,0,0,2,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        };

        internal List<Tile> Tiles { get => tiles; set => tiles = value; }

        public void MakeNewWorld(Scene myScene)
        {
            this.myScene = myScene;
            tileGrid = new Tile[worldGrid.GetLength(0), worldGrid.GetLength(1)];

            for (int x = 0; x < worldGrid.GetLength(0); x++)
            {
                for (int y = 0; y < worldGrid.GetLength(1); y++)
                {
                    Vector2 pos = new Vector2(x, y);
                    int numberfromGrid = worldGrid[x, y];

                    FillTiles(numberfromGrid, pos);
                }
            }
            AStar.Instance.TileGrid = tileGrid;
        }
        private void FillTiles(int numberFromGrid, Vector2 _pos)
        {
            Vector2 pos = _pos * sizeOfGrid;
            Tile tileTMP = new Tile(sizeOfGrid);
            GameObject go;

            switch (numberFromGrid)
            {
                //Floor
                case 0:
                    MakeWallsAndFloor(false, tileTMP, _pos);
                    break;
                
                //Wall
                case 1:
                    MakeWallsAndFloor(true, tileTMP, _pos);
                    break;

                //Enemy
                case 2:
                    MakeWallsAndFloor(false, tileTMP, _pos);
                    go = EnemyFactory.Instance.Create("Zombie");
                    go.Transform.Position = pos;
                    myScene.Instantiate(go);
                    break;

                //Player
                case 3:
                    MakeWallsAndFloor(false, tileTMP, _pos);
                    go = PlayerFactory.Instance.Create("Player");
                    go.Transform.Position = pos;
                    myScene.Instantiate(go);
                    break;

                default:
                    break;
            }
        }
        private void MakeWallsAndFloor(bool isWall, Tile tile, Vector2 _pos)
        {

            GameObject go;
            Vector2 pos = _pos * sizeOfGrid;
            //if it is a wall make a wall if its not a wall make floor this makes it so there is floor below the player and enemies too
            if (isWall == true)
            {
                tile.TileType = Enums.TileTypeEnums.wall;
                go = EnviormentFactory.Instance.Create("Wall");
            }
            else
            {
                tile.TileType = Enums.TileTypeEnums.floor;
                go = EnviormentFactory.Instance.Create("Floor");
            }

            go.Transform.Position = pos;
            tile.GameObject = go;
            tiles.Add(tile);
            tileGrid[(int)_pos.X, (int)_pos.Y] = tile;
            myScene.Instantiate(go);
        }
    }
}
