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
    public class GameStateManager
    {
        Stack<State> gameStates = new Stack<State>();
        State currentState;
        private Game _game;

        public void Initialize(Game game)
        {
            _game = game;
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
            currentState = (State)gameStates.Peek();
            currentState.LoadContent(_game.Content);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch);
        }
    }
}
