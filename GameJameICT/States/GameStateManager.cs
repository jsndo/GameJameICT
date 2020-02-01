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
    class GameStateManager
    {
        Stack<State> gameStates = new Stack<State>();
        State currentState;

        public GameStateManager()
        {
            SetState(new Intro());
            currentState = (State)gameStates.Peek();
        }

        public void LoadContent(ContentManager content)
        {
            currentState.LoadContent(content);
        }
       

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime, this);
        }

        public void SetState(State state)
        {            
            if(gameStates.Count > 0)
            {
                gameStates.Pop();
            }
            
            gameStates.Push(state);            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch);
        }
    }
}
