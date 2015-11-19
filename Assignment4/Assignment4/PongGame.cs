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
	/// This is the main type for your game
	/// </summary>
	public class PongGame : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;

		private SpriteFont gameFont;
		private List<Paddle> playerList;
		private Paddle player1;
		private Paddle player2;
		private Ball ball;

		public PongGame()
		{
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = 1000;
			graphics.PreferredBackBufferHeight = 750;

			Settings.stage = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			playerList = new List<Paddle>();

			Texture2D paddleTexture = Content.Load<Texture2D>("Images/Paddle");

			Vector2 paddle1Position = new Vector2(25, 50);
			player1 = new Paddle(this, spriteBatch, paddleTexture, paddle1Position, Keys.A, Keys.Z);
			playerList.Add(player1);

			Vector2 paddle2Position = new Vector2(Settings.stage.X - paddleTexture.Width - 25, 50);
			player2 = new Paddle(this, spriteBatch, paddleTexture, paddle2Position, Keys.Up, Keys.Down);
			playerList.Add(player2);

			Texture2D ballTexture = Content.Load<Texture2D>("Images/Ball");
			ball = new Ball(this, spriteBatch, ballTexture);
			this.Components.Add(ball);

			foreach (Paddle paddle in playerList)
			{
				this.Components.Add(paddle);
			}

			CollisionManager collisionManager = new CollisionManager(this, playerList, ball);
			this.Components.Add(collisionManager);
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{

		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				this.Exit();
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
			

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			base.Draw(gameTime);
		}
	}
}
