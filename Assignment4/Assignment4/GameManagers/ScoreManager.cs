/* Project: Assignment4 - ScoreManager.cs
 * Purpose: Keeps track of both players' scores
 * 
 * Revision history:
 *  Nov 19, 2015 : Created, Doug Epp
*/

using Microsoft.Xna.Framework;


namespace Assignment4
{
    /// <summary>
    /// An abstract class to keep track of players' scores
    /// </summary>
    public abstract class ScoreManager : GameComponent
    {
        private static int player1Score;
        public static int Player1Score
        {
            get { return player1Score; }
            set { player1Score = value; }
        }

        private static int player2Score;
        public static int Player2Score
        {
            get { return player2Score; }
            set { player2Score = value; }
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
