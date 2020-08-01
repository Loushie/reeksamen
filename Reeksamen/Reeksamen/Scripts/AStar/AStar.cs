using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts
{
    class AStar
    {
        private static AStar instance;
        //Singleton Pattern for AStar
        public static AStar Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AStar();
                }

                return instance;
            }
        }

        internal Tile[,] TileGrid { get => tileGrid; set => tileGrid = value; }

        private Tile start;
        private Tile goal;
        private Tile currentTile;

        public bool runAStar;

        private Stack<Tile> pathBack = new Stack<Tile>();
        private List<Tile> open = new List<Tile>();
        private List<Tile> closed = new List<Tile>();
        private List<Tile> tiles = new List<Tile>();

        private Tile[,] tileGrid;


        public Stack<Tile> DoAStar(Vector2 targetPos, Vector2 myPos)
        {
            runAStar = true;
            pathBack.Clear();
            tiles.Clear();
            open.Clear();
            closed.Clear();

            goal = FindTargetPositionOnGrid(targetPos);
            start = FindMyPositionOnTileGrid(myPos);

            MainLoop();
            runAStar = false;
            return pathBack;
        }
        private Tile FindTargetPositionOnGrid(Vector2 targetPos)
        {
            float distanceToPlayer = float.MaxValue;
            Tile playerGridPos = null;

            for (int x = 0; x < tileGrid.GetLength(0); x++)
            {
                for (int y = 0; y < tileGrid.GetLength(1); y++)
                {
                    if (tileGrid[x,y].TileType == Enums.TileTypeEnums.floor) //if a floor
                    {
                        Vector2 GridPosTMP = tileGrid[x, y].GameObject.Transform.Position;
                        float distanceTMP = Vector2.Distance(GridPosTMP, targetPos);
                        if (distanceTMP < distanceToPlayer)
                        {
                            distanceToPlayer = distanceTMP;
                            playerGridPos = tileGrid[x,y];
                        }
                    }
                }
            }
            return playerGridPos;
        }
        private Tile FindMyPositionOnTileGrid(Vector2 myPos)
        {
            float distanceToPlayer = float.MaxValue;
            Tile playerGridPos = null;

            for (int x = 0; x < tileGrid.GetLength(0); x++)
            {
                for (int y = 0; y < tileGrid.GetLength(1); y++)
                {
                    if (tileGrid[x, y].TileType == Enums.TileTypeEnums.floor) //if a floor
                    {
                        Vector2 GridPosTMP = tileGrid[x, y].GameObject.Transform.Position;
                        float distanceTMP = Vector2.Distance(GridPosTMP, myPos);
                        if (distanceTMP < distanceToPlayer)
                        {
                            distanceToPlayer = distanceTMP;
                            playerGridPos = tileGrid[x, y];
                        }
                    }
                }
            }
            AddOpen(playerGridPos, 0);
            return playerGridPos;
        }

        private void AddOpen(Tile tile, int gCost)
        {
            int y = (int)tile.GameObject.Transform.Position.Y;
            int x = (int)tile.GameObject.Transform.Position.X;

            int distance = 0;

            while (true)
            {
                if (y == goal.GameObject.Transform.Position.Y)
                {
                    break;
                }
                else
                {
                    if (goal.GameObject.Transform.Position.Y > y)
                    {
                        y += tile.Tilesize;
                    }
                    else
                    {
                        y -= tile.Tilesize;
                    }
                    distance += 10;
                }
            }

            while (true)
            {
                if (x == goal.GameObject.Transform.Position.X)
                {
                    break;
                }
                else
                {
                    if (goal.GameObject.Transform.Position.X > x)
                    {
                        x += tile.Tilesize;
                    }
                    else
                    {
                        x -= tile.Tilesize;
                    }
                    distance += 10;
                }
            }
            tile.H = distance;
            tile.G = gCost + (currentTile != null ? currentTile.G : 0); //? works as if.  : works as else
            tile.F = tile.G + tile.H;
            tile.LastTile = currentTile;

            open.Add(tile);
        }
        public void MainLoop()
        {
            while (runAStar == true)
            {
                if(open.Count == 0)
                {
                    break;
                }
                FindLowestCostTile();
                if (currentTile == goal)
                {
                    GoHome();
                    break;
                }
                TilesAroundTarget(currentTile);
            }
        }
        public void FindLowestCostTile()
        {
            currentTile = open[0];

            foreach (Tile item in open)
            {
                if (currentTile.F > item.F || currentTile.F >= item.F && currentTile.H > item.H)
                {
                    currentTile = item;
                }
            }

            open.Remove(currentTile);
            closed.Add(currentTile);
        }
        public void TilesAroundTarget(Tile target)
        {
            for (int x = 0; x < tileGrid.GetLength(0); x++)
            {
                for (int y = 0; y < tileGrid.GetLength(1); y++)
                {
                    if (TileGrid[x,y].GameObject.Transform.Position.X == target.GameObject.Transform.Position.X && TileGrid[x, y].GameObject.Transform.Position.Y + target.Tilesize == target.GameObject.Transform.Position.Y)
                    {
                        BeforeOpenAt(TileGrid[x,y],10);
                    }
                    else if (TileGrid[x, y].GameObject.Transform.Position.X == target.GameObject.Transform.Position.X && TileGrid[x, y].GameObject.Transform.Position.Y - target.Tilesize == target.GameObject.Transform.Position.Y)
                    {
                        BeforeOpenAt(TileGrid[x, y], 10);
                    }
                    else if (TileGrid[x, y].GameObject.Transform.Position.X + target.Tilesize == target.GameObject.Transform.Position.X && TileGrid[x, y].GameObject.Transform.Position.Y == target.GameObject.Transform.Position.Y)
                    {
                        BeforeOpenAt(TileGrid[x, y], 10);
                    }
                    else if (TileGrid[x, y].GameObject.Transform.Position.X - target.Tilesize == target.GameObject.Transform.Position.X && TileGrid[x, y].GameObject.Transform.Position.Y == target.GameObject.Transform.Position.Y)
                    {
                        BeforeOpenAt(TileGrid[x, y], 10);
                    }
                }
            }
        }
        public void GoHome()
        {
            while (true)
            {
                if (currentTile.LastTile == start || currentTile == start )
                {
                    break;
                }
                pathBack.Push(currentTile);
                currentTile = currentTile.LastTile;
            }
        }
        public void BeforeOpenAt(Tile tile, int gCost)
        {
            if (!closed.Contains(tile) && !open.Contains(tile) && tile.TileType == Enums.TileTypeEnums.floor)
            {
                AddOpen(tile, gCost);
            }
        }
    }
}
