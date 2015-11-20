/* Project: Assignment4 - ScoreManager.cs
 * Purpose: Keeps track of both players' scores
 * 
 * Revision history:
 *  Nov 19, 2015 : Created, Doug Epp
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
    /// An abstract class to keep track of players' scores
    /// </summary>
    public abstract class ScoreManager : Microsoft.Xna.Framework.GameComponent
    {
        private static int player1Score;
        public static int Player1Score
        {
            get { return ScoreManager.player1Score; }
            set { ScoreManager.player1Score = value; }
        }

        private static int player2Score;
        public static int Player2Score
        {
            get { return ScoreManager.player2Score; }
            set { ScoreManager.player2Score = value; }
        }

        /// <summary>
        /// Constructor for the ScoreManager class
        /// </summary>
        /// <param name="game">The pong game which uses the score manager</param>
        public ScoreManager(Game game)
            : base(game)
        {
            player1Score = 0;
            player2Score = 0;
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
            base.Update(gameTime);
        }
        /// <summary>
        /// Resets the score manager to its initial state
        /// </summary>
        public static void Reset()
        {
            player1Score = 0;
            player2Score = 0;
        }
    }
}
