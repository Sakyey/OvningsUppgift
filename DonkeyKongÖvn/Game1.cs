using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace DonkeyKongÖvn
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public SpriteFont font1;
        string text;
        bool start = false;
        Texture2D bollTex;
        Ball ball1;

        List<Ball> balls;
        List<string> stringList;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            StreamReader sr = new StreamReader("MyText.txt");
            bollTex = Content.Load<Texture2D>("ball_breakout");
            ball1 = new Ball(_spriteBatch, bollTex);
            balls = new List<Ball>();
            stringList = new List<string> { text };
            font1 = Content.Load<SpriteFont>("font1");
             text = sr.ReadLine();
            while(!sr.EndOfStream)
            {
                stringList.Add(sr.ReadLine());
            }
            sr.Close();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (start)
            {
                foreach (Ball b in balls)
                {
                    b.Update();
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                start = true;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();


            if (start)
            {
                foreach(Ball b in balls)
                {
                    b.Draw(_spriteBatch);
                }
            }
            else
            {
            _spriteBatch.DrawString(font1, text, new Vector2(100, 100), Color.Black);
                for(int i = 0; i < stringList.Count; i++)
                {
                    for (int j = 0; j < stringList[i].Length; j++)
                    {
                        if (stringList[i][j] == '1')
                        {
                            _spriteBatch.Draw(bollTex, new Vector2(50 * j, 50 * i), Color.Green);
                        }
                    }
                }

            }

            // TODO: Add your drawing code here
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}