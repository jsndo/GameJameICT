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

namespace GameJameICT.States
{
    class Intro : State
    {
        private SpriteFont _font;

        public void LoadContent(ContentManager content)
        {
            _font = content.Load<SpriteFont>("FontText");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, "TEST", new Vector2(50, 50), Color.White);
        }

       

        public void Update(GameTime gameTime, GameStateManager gsm)
        {
            if(Key.Down(Keys.Enter))
            {
                gsm.SetState(new Play());
            }            
        }

    }
}
