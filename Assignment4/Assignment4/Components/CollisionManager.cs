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
	public class CollisionManager : GameComponent
	{
		private List<Paddle> playerList;
		private Ball ball;

		public CollisionManager(Game game, List<Paddle> playerList, Ball ball)
			: base(game)
		{
			this.playerList = playerList;
			this.ball = ball;
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
			foreach (Paddle paddle in playerList)
			{
				Rectangle paddleBounds = paddle.CollisionBounds;
				Rectangle ballBounds = ball.CollisionBounds;

				if (ballBounds.Intersects(paddleBounds))
				{
					ball.Speed = new Vector2(ball.Speed.X * -1, ball.Speed.Y);
				}
			}

			base.Update(gameTime);
		}
	}
}
