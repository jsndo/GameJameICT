using GameJameICT.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJameICT.Sprites
{
    class Sprite
    {
        #region Fields
        protected Texture2D _texture;
        #endregion
        #region Properties
        public Input Input;
        public Vector2 Position;
        public float Speed = 1f;
        public Vector2 Velocity;
        #endregion
        #region Method 
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }
        public virtual void Move()
        {
            if(KeyNotFoundException)
        }

    }
}
