/* Project: Assignment4 - Scordboard.cs
 * Purpose: Models the string to display players' scores
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
	/// This is a class to display players' scores
	/// </summary>
	public class Scoreboard : DrawableGameComponent
	{
		private SpriteBatch spriteBatch;
		private SpriteFont font;
		private Vector2 position;
		private string name;
		private int score;
		private bool isPlayer1;

		/// <summary>
		/// Constructor for each players scoreboard
		/// </summary>
		/// <param name="game">Game reference</param>
		/// <param name="spriteBatch">Spritebatch reference for drawing the scoreboard</param>
		/// <param name="font">Font for the scoreboard</param>
		/// <param name="position">Position to draw the scoreboard at</param>
		/// <param name="name">Player's name</param>
		/// <param name="isPlayer1">Whether or not the player is player 1</param>
		public Scoreboard(Game game, SpriteBatch spriteBatch, SpriteFont font, Vector2 position, string name, bool isPlayer1)
			: base(game)
		{
			this.spriteBatch = spriteBatch;
			this.font = font;
			this.name = name;
			this.isPlayer1 = isPlayer1;
			this.position = position;
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
			if (isPlayer1)
			{
				score = ScoreManager.Player1Score;
			}
			else
			{
				score = ScoreManager.Player2Score;
			}

			base.Update(gameTime);
		}
		/// <summary>
		/// Called when the score string needs to be drawn
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Draw(GameTime gameTime)
		{
			spriteBatch.Begin();
			spriteBatch.DrawString(font, name + "\n" + score, position, Color.Wheat);
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
