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
        private String[] _menuText = { "ICT 2020 GAME JAME", "Press Enter to Play" };
        private int _verticalTextOffset = 30;

        public void LoadContent(ContentManager content)
        {
            _font = content.Load<SpriteFont>("FontText");

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(_font, _menuText[0],
                    new Vector2(Screen.Width / 2 - _font.MeasureString(_menuText[0]).X / 2,
                                Screen.Height / 2 - _font.MeasureString(_menuText[0]).Y / 2), Color.White);

            spriteBatch.DrawString(_font, _menuText[1],
                    new Vector2(Screen.Width / 2 - _font.MeasureString(_menuText[1]).X / 2,
                                _verticalTextOffset + Screen.Height / 2 - _font.MeasureString(_menuText[1]).Y / 2), Color.White);

        }

       

        public void Update(GameTime gameTime, GameStateManager gsm)
        {    
            
            if(Key.Down(Keys.Enter))
            {
                gsm.PopAndSetState(new Play());
            }            
        }

    }
}
