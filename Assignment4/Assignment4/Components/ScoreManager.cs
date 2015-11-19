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
    public class ScoreManager : Microsoft.Xna.Framework.GameComponent
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

        private static bool player1WonLastGame;

        public static bool Player1WonLastGame
        {
            get { return player1WonLastGame; }
            set { player1WonLastGame = value; }
        }

        public ScoreManager(Game game)
            : base(game)
        {
            player1Score = 0;
            player2Score = 0;
            player1WonLastGame = false;
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
            base.Update(gameTime);
        }
    }
}
