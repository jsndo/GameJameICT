using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameJameICT.Common
{
    public static class Key
    {
        public static Boolean Down(Keys keys)
        {
            return Keyboard.GetState().IsKeyDown(keys);
        }

        public static Boolean Up(Keys keys)
        {
            return Keyboard.GetState().IsKeyUp(keys);
        }
    }
}
