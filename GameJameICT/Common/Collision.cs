using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameJameICT.States;
using Microsoft.Xna.Framework;

namespace GameJameICT.Common
{
    public static class Collision
    {
        //public static Boolean Hit(Rectangle obj1, Rectangle obj2)
        //{
        //    if(obj1.Intersects(obj2))
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        public static Boolean Hit(Vector2 obj1, Vector2 obj1Dimensions, Vector2 obj2, Vector2 obj2Dimensions)
        {
            if (((obj2.X >= obj1.X && obj2.X <= obj1.X + obj1Dimensions.X)
              || (obj2.X <= obj1.X && obj2.X + obj2Dimensions.X >= obj1.X))
              && obj2.Y >= obj1.Y && obj2.Y <= obj1.Y + obj1Dimensions.Y)
            {
                return true;
            }

            return false;
        }
    }
}
