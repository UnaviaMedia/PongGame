using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Assignment4
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class WinnerString : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private string message;
        private int delay;
        private int delayCounter;
        private bool flag;
        private Vector2 position;

        public WinnerString(Game game, SpriteBatch spriteBatch, SpriteFont font, string message)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.message = message + " Wins!";

            delay = 50;
            position = new Vector2(Settings.stage.X / 2, Settings.stage.Y / 2);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            delayCounter++;
            if (delayCounter > delay)
            {
                flag = !flag;
                delayCounter = 0;
            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            if (!flag)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font, message, position, Color.Red);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
