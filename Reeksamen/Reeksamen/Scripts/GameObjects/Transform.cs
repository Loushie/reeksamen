using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Our Transform What We Use To Move Our GameObjects
namespace Reeksamen.Scripts
{
    public class Transform
    {
        private Vector2 position = new Vector2(0, 0);

        private Vector2 scale = new Vector2(1, 1);

        private float rotation;

        private Vector2 origin = new Vector2(0, 0);


        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Scale { get => scale; set => scale = value; }
        public float Rotation { get => rotation; set => rotation = value; }
        public Vector2 Origin { get => origin; set => origin = value; }


        public void Translate(Vector2 translation)
        {
            if (!float.IsNaN(translation.X) && !float.IsNaN(translation.Y))
            {
                Position += translation;
            }
        }
    }
}
