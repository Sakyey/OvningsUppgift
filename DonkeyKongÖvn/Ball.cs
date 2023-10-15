using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyKongÖvn
{
    internal class Ball
    {
        SpriteBatch spriteBatch;
        public Texture2D boll;
        public Vector2 bollPos = new Vector2(150, 150);
        public Ball(SpriteBatch _spriteBatch, Texture2D bollTex)
        {
            this.spriteBatch = _spriteBatch;
            this.boll = bollTex;

        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(boll, bollPos, Color.Yellow);

            spriteBatch.End();
        }
    }
}
