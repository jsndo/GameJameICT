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
using GameJameICT.States;

namespace GameJameICT.Entities
{
    public class HealthBar
    {
        private const int HEALTH = 2;
        private int currentHealth = HEALTH;

        //Health will go down one point for every unit of time; adjust as needed
        //This one is the one that will not change, only used for resetting back to the original rate 
        //When masks run out
        private const float HEALTH_DEPLETION_RATE = 2.0f;

        //exposed to other entities such as masks to set the value of
        private float _exposedHealthDepletionRate = 2.0f;
        private float _timeElapsed = 0.0f;
        private SpriteFont _font;

        public void LoadContent(ContentManager content)
        {
            _font = content.Load<SpriteFont>("FontText");
        }

        public void Update(GameTime gameTime, GameStateManager gsm)
        {
            if(currentHealth > 0)
            {
                if (_timeElapsed < _exposedHealthDepletionRate)
                {
                    _timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    currentHealth -= 1;
                    _timeElapsed = 0.0f;
                }
            }
            else
            {
                gsm.PopAndSetState(new GameOver());
            }
                  
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, $"HP: {currentHealth}", new Vector2(Screen.Width - 150, 50), Color.Red);
        }


        public int GetHP
        {
            get { return currentHealth; }
        }

        public float DepletionRate
        {
            get { return _exposedHealthDepletionRate; }
            set { _exposedHealthDepletionRate = value; }
        }

        public float OriginalDepletionRate
        {
            get { return HEALTH_DEPLETION_RATE; }
        }

    }
}
