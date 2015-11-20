/* Project: Assignment4 - WinnerString.cs
 * Purpose: Models the string to display the winning player's name
 * 
 * Revision history:
 *  Nov 19, 2015 : Created, Doug Epp
 *                 
*/
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
    /// This is a drawable game component to model the string which displays the winner
    /// </summary>
    public class WinnerString : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private string message;
        private const int DELAY = 50;
        private int delayCounter;
        private bool flag;
        private Vector2 position;

        /// <summary>
        /// Constructor for the winner's string
        /// </summary>
        /// <param name="game">The game which calls the string</param>
        /// <param name="spriteBatch">The spritebatch to draw the string</param>
        /// <param name="font">The font for the string to use</param>
        /// <param name="message">The message to display</param>
        public WinnerString(Game game, SpriteBatch spriteBatch, SpriteFont font, string message)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.message = message + " Wins!\n(Press space to reset)";

            position = new Vector2(PongGame.stage.X / 2 - font.MeasureString(message).X, 50);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            delayCounter++;
            if (delayCounter > DELAY)
            {
                flag = !flag;
                delayCounter = 0;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Called when the string needs to be drawn
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
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
