using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJameICT.Models;
using GameJameICT.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameJameICT.Entities;

namespace GameJameICT.States
{
    class Play : State
    {
        private List<Sprite> _sprites;
        SpriteFont font;
       
        public void LoadContent(ContentManager content)//Load all sprites, fonts,scenes, etc... 
        {
            font = content.Load<SpriteFont>("FontText");//SpriteFont is just for fonts needs to be changed for other types of content 
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
        HealthBar healthBar;
        Mask mask;

       
        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("FontText");
            healthBar = new HealthBar();
            healthBar.LoadContent(content);

            mask = new Mask();
            mask.LoadContent(content, healthBar);
        }

        public void Update(GameTime gameTime, GameStateManager gsm)//Called once a frame (where Key inputs get updated)
        {
            foreach (var sprite in _sprites)
                sprite.Update(gameTime, _sprites);
            
            healthBar.Update(gameTime, gsm);
            mask.Update(gameTime);
            
        }

        public void Draw(SpriteBatch spriteBatch)//Sets initial position 
        {
            spriteBatch.DrawString(font, "Play State", new Vector2(100, 100), Color.Red);//Test text Drawl string is for fonts only 
      
            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);
   
            healthBar.Draw(spriteBatch);
            mask.Draw(spriteBatch);
        }

    }
}
