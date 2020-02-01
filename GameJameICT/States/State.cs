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
    public interface State
    {
        void LoadContent(ContentManager content);
        void Update(GameTime gameTime, GameStateManager gsm);
        void Draw(SpriteBatch spriteBatch);
    }
}
