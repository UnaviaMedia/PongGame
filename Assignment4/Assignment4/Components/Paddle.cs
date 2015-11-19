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
	public class Paddle : DrawableGameComponent
	{
		private SpriteBatch spriteBatch;
		private Texture2D texture;
		private Vector2 position;
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

		public Paddle(Game game, SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Keys upKey, Keys downKey)
			: base(game)
		{
			this.spriteBatch = spriteBatch;
			this.texture = texture;
			this.position = position;
			this.speed = new Vector2(0, PADDLE_SPEED);

			this.upKey = upKey;
			this.downKey = downKey;
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
			KeyboardState keyboardState = Keyboard.GetState();

			if (keyboardState.IsKeyDown(upKey))
			{
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
				if (position.Y + texture.Height < Settings.stage.Y)
				{
					position += speed;
				}
				else
				{
					position.Y = Settings.stage.Y - texture.Height;
				}
			}

			base.Update(gameTime);
		}


		public override void Draw(GameTime gameTime)
		{
			spriteBatch.Begin();
			spriteBatch.Draw(texture, position, Color.White);
			spriteBatch.End();
			
			base.Draw(gameTime);
		}
	}
}
