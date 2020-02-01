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
        private Vector2 _dimensions;
        private Rectangle _rectangle;
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

        public Vector2 Dimensions
        {
            get { return _dimensions; }
        }

        public Rectangle GetRect
        {
            get { return _rectangle; }
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

            _rectangle.Width = _animations.Last().Value.Texture.Width;
            _rectangle.Height = _animations.Last().Value.Texture.Height;


            _dimensions.X = _animations.Last().Value.Texture.Width;
            _dimensions.Y = _animations.Last().Value.Texture.Height;

        }
        public Sprite(Texture2D texture)
        {
            _texture = texture;
            //_dimensions = new Vector2(_texture.Width, _texture.Height);
            _rectangle.Width = _texture.Width;
            _rectangle.Height = _texture.Height;
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
            _rectangle.X = (int)Position.X;
            _rectangle.Y = (int)Position.Y;

            Console.WriteLine(_rectangle);

            Velocity = Vector2.Zero;

        }
      
        #endregion

    }
}
