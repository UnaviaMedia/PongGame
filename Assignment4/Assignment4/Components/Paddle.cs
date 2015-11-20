/* Project: Assignment4 - Paddle.cs
 * Purpose: Models the paddles for a game of pong
 * 
 * Revision history:
 *  Nov 19, 2015 : Created, Kendall Roth
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
	/// A class to model a paddle in a game of Pong
	/// </summary>
	public class Paddle : DrawableGameComponent
	{
		private SpriteBatch spriteBatch;
		private Texture2D texture;
		private Vector2 position;
		private Vector2 origin;
		private Vector2 speed;
		private Rectangle collisionBounds;
		private Keys upKey;
		private Keys downKey;

		public const int PADDLE_SPEED = 5;

		public Vector2 Position
		{
			get { return position; }
			set { position = value; }
		}

		public Vector2 Origin
		{
			get { return origin; }
			set { origin = value; }
		}

		public Vector2 Speed
		{
			get { return speed; }
			set { speed = value; }
		}

		public Rectangle CollisionBounds
		{
			get
			{
				collisionBounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
				return collisionBounds;
			}
		}

		/// <summary>
		/// Create a new Paddle object
		/// </summary>
		/// <param name="game">Game reference for the component</param>
		/// <param name="spriteBatch">SpriteBatch reference for drawing the component</param>
		/// <param name="texture">Texture for drawing the component</param>
		/// <param name="position">Position of the component</param>
		/// <param name="upKey">Key that moves the component up</param>
		/// <param name="downKey">Key that moves the component down</param>
		public Paddle(Game game, SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Keys upKey, Keys downKey)
			: base(game)
		{
			this.spriteBatch = spriteBatch;
			this.texture = texture;
			this.position = position;
			this.speed = new Vector2(0, PADDLE_SPEED);
			this.upKey = upKey;
			this.downKey = downKey;

			origin = new Vector2(texture.Width / 2, texture.Height / 2);
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
			//Get the current keyboard state
			KeyboardState keyboardState = Keyboard.GetState();

			if (keyboardState.IsKeyDown(upKey))
			{
				//Move the paddle up if possible.
				if (position.Y > 0)
				{
					position -= speed;
				}
				else
				{
					position.Y = 0;
				}
			}
			else if (keyboardState.IsKeyDown(downKey))
			{
				//Move the paddle down if possible
				if (position.Y + texture.Height < PongGame.stage.Y)
				{
					position += speed;
				}
				else
				{
					position.Y = PongGame.stage.Y - texture.Height;
				}
			}

			base.Update(gameTime);
		}
		
		/// <summary>
		/// Draw the game component
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values</param>
		public override void Draw(GameTime gameTime)
		{
			spriteBatch.Begin();
			spriteBatch.Draw(texture, position, Color.White);
			spriteBatch.End();

			base.Draw(gameTime);
		}

		/// <summary>
		/// Update the position of the paddle (after a point is won)
		/// </summary>
		public void Reset()
		{
			position = new Vector2(position.X, PongGame.stage.Y / 2 - texture.Height / 2);
		}
	}
}
