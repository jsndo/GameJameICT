using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameJameICT.States
{
    class Play : State
    {
        SpriteFont font;
       
        public void LoadContent(ContentManager content)//Load all sprites, fonts,scenes, etc... 
        {
            font = content.Load<SpriteFont>("FontText");//SpriteFont is just for fonts needs to be changed for other types of content 
        }

        public void Update(GameTime gameTime, GameStateManager gsm)//Called once a frame (where Key inputs get updated)
        {

        }

        public void Draw(SpriteBatch spriteBatch)//Sets initial position 
        {
            spriteBatch.DrawString(font, "Play State", new Vector2(100, 100), Color.Red);//Test text Drawl string is for fonts only 
        }

    }
}
