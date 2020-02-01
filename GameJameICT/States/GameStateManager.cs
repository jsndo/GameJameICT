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

        /// <summary>
        /// Adds the new state to the stack. NOTE: the previous, if any, state is still in the stack. If need to remove current state before pushing new on on, refer to PopAndSetState
        /// </summary>
        /// <param name="state"></param>
        public void SetState(State state)
        {                               
            gameStates.Push(state);
            currentState = (State)gameStates.Peek();
            currentState.LoadContent(_game.Content);
        }

        /// <summary>
        /// Removes the current state and adds the new state onto the stack
        /// </summary>
        /// <param name="state"></param>
        public void PopAndSetState(State state)
        {
            if (gameStates.Count > 0)
            {
                gameStates.Pop();
            }
            SetState(state);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch);
        }
    }
}
