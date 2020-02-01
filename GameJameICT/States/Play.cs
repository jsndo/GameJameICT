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
       
        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("FontText");
        }

        public void Update(GameTime gameTime, GameStateManager gsm)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Play State", new Vector2(100, 100), Color.Red);
        }

    }
}
