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
		private Game game;
		private List<Paddle> playerList;
		private Ball ball;

		public CollisionManager(Game game, List<Paddle> playerList, Ball ball)
			: base(game)
		{
			this.game = game;
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
				//Get the collision boundaries of the paddle and ball
				Rectangle paddleBounds = paddle.CollisionBounds;
				Rectangle ballBounds = ball.CollisionBounds;

				//Find the intersection of the ball and paddle
				Rectangle collisionRectangle = Rectangle.Intersect(paddleBounds, ballBounds);

				//Store the post-collision position of the ball
				Vector2 collisionPosition = ball.Position;

				if (ballBounds.Intersects(paddleBounds))
				{
					if (collisionRectangle.Height > collisionRectangle.Width)
					{
						//Right/Left collision
						if (collisionRectangle.X > ball.Position.X)
						{
							//Left-paddle collision
							collisionPosition.X = paddleBounds.X - ballBounds.Width;
						}
						else
						{
							//Right-paddle collision
							collisionPosition.X = paddleBounds.X + paddleBounds.Width;
						}

						//Reverse the X-speed
						ball.Speed = new Vector2(ball.Speed.X * -1, ball.Speed.Y);
					}
					else
					{
						//Top/Bottom collision
						if (collisionRectangle.Y > ball.Position.Y)
						{
							//Top-paddle collision
							collisionPosition.Y = paddleBounds.Y - ballBounds.Height;
						}
						else
						{
							//Bottom-paddle collision
							collisionPosition.Y = paddleBounds.Y + paddleBounds.Height;
						}

						//Reverse the Y-speed
						ball.Speed = new Vector2(ball.Speed.X, ball.Speed.Y * -1);
					}

					//Update the position of the ball to the post-collision position
					ball.Position = collisionPosition;

					//Play a sound
					//SoundManager.PlaySound(game, "click");
				}
			}

			base.Update(gameTime);
		}
	}
}