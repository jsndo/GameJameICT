using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJameICT.Models;
using GameJameICT.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameJameICT.Entities;
using GameJameICT.Common;

namespace GameJameICT.States
{
    class Play : State
    {
       
        SpriteFont font;
        HealthBar healthBar;
        Mask mask;
        private Stack<Mask> _stackOfMask = new Stack<Mask>();
        Player player;

        public void LoadContent(ContentManager content)//Load all sprites, fonts,scenes, etc... 
        {
            font = content.Load<SpriteFont>("FontText");//SpriteFont is just for fonts needs to be changed for other types of content 

            player = new Player();
            player.LoadContent(content);

            healthBar = new HealthBar();
            healthBar.LoadContent(content);

            mask = new Mask();
            mask.LoadContent(content, healthBar);

            mask = new Mask();
            mask.LoadContent(content, healthBar);

            _stackOfMask.Push(mask);


        }  


        public void Update(GameTime gameTime, GameStateManager gsm)//Called once a frame (where Key inputs get updated)
        {

            player.Update(gameTime);
            healthBar.Update(gameTime, gsm);
            mask.Update(gameTime);
            
            if(_stackOfMask.Any())
            {
                if (Collision.Hit(player.Position, player.Dimensions, mask.Position, mask.Dimensions))
                {
                    mask.IncrementCount++;
                    if (_stackOfMask.Any())
                    {
                        _stackOfMask.Pop();
                    }
                }
            }
            
           

            //if (Collision.Hit(player.GetRect, mask.GetRect))
            //{
            //    mask.IncrementCount++;
            //}
            
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            player.Draw(spriteBatch);
            healthBar.Draw(spriteBatch);

            foreach(var mask in _stackOfMask)
            {
                mask.Draw(spriteBatch);
            }
            
        }


    }


}
