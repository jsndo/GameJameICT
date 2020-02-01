using GameJameICT.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJameICT.Common;
using GameJameICT.Managers;

namespace GameJameICT.Sprites
{
    class Sprite
    {
        #region Fields
        protected AnimationManager _animationManager;
        protected Dictionary<string, Animation> _animations;
        protected Vector2 _position;
        protected Texture2D _texture;
        #endregion
        #region Properties
        public Input Input;
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value;
                if (_animationManager != null)
                    _animationManager.Position = _position;
            }
        }
        public float Speed = 1f;
        public Vector2 Velocity;
        #endregion
        #region Method 
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
                spriteBatch.Draw(_texture, Position, Color.White);
            else if (_animationManager != null)
                _animationManager.Draw(spriteBatch);
            else throw new Exception("You messed up ");
        }
        public virtual void Move()
        {
            if (Key.Down(Input.Up))
                Velocity.Y = -Speed;
            else if (Key.Down(Input.Down))
                Velocity.Y = Speed;
            else if (Key.Down(Input.Left))
                Velocity.X = -Speed;
            else if (Key.Down(Input.Right))
                Velocity.X = Speed;
        }
        public Sprite(Dictionary<string,Animation> animations)
        {
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }
        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }
        protected virtual void SetAnimation()
        {
            if (Velocity.X > 0)
                _animationManager.Play(_animations["WalkRight"]);
            else if (Velocity.X < 0)
                _animationManager.Play(_animations["WalkLeft"]);
            else if (Velocity.Y > 0)
                _animationManager.Play(_animations["WalkDown"]);
            else if (Velocity.Y < 0)
                _animationManager.Play(_animations["WalkUp"]);
            else
                _animationManager.Stop();

        }
        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();
            SetAnimation();
            _animationManager.Update(gameTime);
            Position += Velocity;
            Velocity = Vector2.Zero;
        }
      
        #endregion

    }
}
