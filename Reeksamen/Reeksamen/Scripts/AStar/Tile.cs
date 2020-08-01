using Reeksamen.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts
{
    class Tile
    {

        private GameObject gameObject;
        private int f;
        private int h;
        private int g;

        private Tile lastTile;

        private TileTypeEnums tileType;

        int tilesize;
        public int G { get => g; set => g = value; }
        public int H { get => h; set => h = value; }
        public int F { get => f; set => f = value; }
        public GameObject GameObject { get => gameObject; set => gameObject = value; }
        public int Tilesize { get => tilesize; set => tilesize = value; }
        public Tile LastTile { get => lastTile; set => lastTile = value; }
        public TileTypeEnums TileType { get => tileType; set => tileType = value; }

        public Tile (int tilesize)
        {
            this.tilesize = tilesize;
        }
    }
}
