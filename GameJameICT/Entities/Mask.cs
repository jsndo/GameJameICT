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

namespace GameJameICT.Entities
{
    public class Mask
    {
        private int numberOfMasks = 5;

        //Masks will go down one point for every unit of time; adjust as needed
        private float _maskDepletionRate = 4.0f;
        private float _timeElapsed = 0.0f;
        private SpriteFont _font;
        private HealthBar _healthBar;

        public void LoadContent(ContentManager content, HealthBar healthBar)
        {
            _font = content.Load<SpriteFont>("FontText");
            _healthBar = healthBar;
        }

        public void Update(GameTime gameTime)
        {
            if(numberOfMasks > 0)
            {
                _healthBar.DepletionRate = 6.0f;

                if (_timeElapsed < _maskDepletionRate)
                {
                    _timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {                    
                    numberOfMasks -= 1;
                    _timeElapsed = 0.0f;
                }
            }
            else
            {
                _healthBar.DepletionRate = _healthBar.OriginalDepletionRate;
            }            
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, $"Masks Count: {numberOfMasks}", new Vector2(Screen.Width - 350, 50), Color.Green);
        }
    }
}
