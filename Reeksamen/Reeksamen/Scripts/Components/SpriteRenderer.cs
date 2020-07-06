using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.Components
{
    public class SpriteRenderer : Component
    {
        private Texture2D sprite;
        private Color color = Color.White;
        private float layerDepth = 0;
        private Rectangle rectangle;
        private SpriteEffects spriteEffects = SpriteEffects.None;

        public SpriteRenderer(Texture2D sprite)
        {
            this.sprite = sprite;
            rectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
        }

        public float LayerDepth { get => layerDepth; set => layerDepth = value; }

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
            spriteBatch.Draw(
                //texture2D
                sprite,
                //Position
                GameObject.Transform.Position,
                //SourceRectangle
                rectangle,
                //Color
                color,
                //Rotation
                MathHelper.ToRadians(GameObject.Transform.Rotation),
                //Origin
                GameObject.Transform.Origin,
                //Scale
                GameObject.Transform.Scale,
                //SpriteEffect
                spriteEffects,
                //LayerDepths
                LayerDepth
                );

        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
