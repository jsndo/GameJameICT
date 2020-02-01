using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameJameICT.Common;
using GameJameICT.Models;
using GameJameICT.Sprites;

namespace GameJameICT.Entities
{
    class Player
    {
        private List<Sprite> _sprites;
        private Rectangle _rectangle;
        public void LoadContent(ContentManager content)
        {
            
            var animations = new Dictionary<string, Animation>()
            {
                {"WalkUp", new Animation(content.Load<Texture2D>("DrWalkingBack"),3)},
                 {"WalkDown", new Animation(content.Load<Texture2D>("DrWalkingFront"),3)},
                 {"WalkLeft", new Animation(content.Load<Texture2D>("DrWalkingLeft"),3)},
                 {"WalkRight", new Animation(content.Load<Texture2D>("DrWalkingRight"),3)},

            };
            _sprites = new List<Sprite>()
            {
                new Sprite(animations)
                {
                    Position = new Vector2(100,100),
                    Input = new Input()
                    {
                        Up = Keys.W,
                        Down = Keys.S,
                        Left = Keys.A,
                        Right = Keys.D,

                    },
                },
            };


        }

        public void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites)
                sprite.Update(gameTime, _sprites);


            //Console.WriteLine(GetRect);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);
        }


        public Vector2 Position
        {
            get { return _sprites.Last().Position; }
        }

        public Vector2 Dimensions
        {
            get { return _sprites.Last().Dimensions; }
        }

        public Rectangle GetRect
        {
            get { return _sprites.Last().GetRect; }
        }
    }
}
