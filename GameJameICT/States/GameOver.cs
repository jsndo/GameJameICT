using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameJameICT.Common;
using Microsoft.Xna.Framework.Input;

namespace GameJameICT.States
{
    class GameOver : State
    {
        private SpriteFont _font;
        private String[] _menuText = { "Game Over, Press Enter to Play" };
        private int _verticalTextOffset = 30;

        public void LoadContent(ContentManager content)
        {
            _font = content.Load<SpriteFont>("FontText");

        }


        public void Update(GameTime gameTime, GameStateManager gsm)
        {
            if(Key.Down(Keys.Enter))
            {
                gsm.PopAndSetState(new Play());
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(_font, _menuText[0],
                    new Vector2(Screen.Width / 2 - _font.MeasureString(_menuText[0]).X / 2,
                                Screen.Height / 2 - _font.MeasureString(_menuText[0]).Y / 2), Color.Red);            

        }

        
    }
}
