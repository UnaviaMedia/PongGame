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
		//Graphics components
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

		//Player list and ball
        private List<Paddle> playerList;
        private Paddle player1;
        private Paddle player2;
        private Ball ball;

		//Player score
        private SpriteFont gameFont;
        private Scoreboard player1ScoreBoard;
        private Scoreboard player2ScoreBoard;
        private bool gameOn;
        private bool gameOver;
        public bool GameOn
        {
            get { return gameOn; }
            set { gameOn = value; }
        }
        public bool GameOver
        {
            get { return gameOver; }
            set { gameOver = value; }
        }

        const int WIN_SCORE = 2;

		//Game managers
		private CollisionManager collisionManager;
		public static SoundManager soundManager;

		/// <summary>
		/// Create and initialize the PongGame
		/// </summary>
        public PongGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

			//Store the size of the game window
            Settings.stage = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            gameOn = false;
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

			//Create a new list of players
            playerList = new List<Paddle>();


            gameFont = Content.Load<SpriteFont>("Fonts/ScoreFont");
            player1ScoreBoard = new Scoreboard(this, spriteBatch, gameFont, new Vector2(0, 0), "Doug", true);
            this.Components.Add(player1ScoreBoard);

            player2ScoreBoard = new Scoreboard(this, spriteBatch, gameFont, new Vector2(Settings.stage.X - 72, 0), "Kendall", false);
            this.Components.Add(player2ScoreBoard);

			//Load the paddle texture
            Texture2D paddleTexture = Content.Load<Texture2D>("Images/Paddle");

			//Create player 1
            Vector2 paddle1Position = new Vector2(25, 50);
            player1 = new Paddle(this, spriteBatch, paddleTexture, paddle1Position, Keys.A, Keys.Z);
            playerList.Add(player1);

			//Create player 2
            Vector2 paddle2Position = new Vector2(Settings.stage.X - paddleTexture.Width - 25, 50);
            player2 = new Paddle(this, spriteBatch, paddleTexture, paddle2Position, Keys.Up, Keys.Down);
            playerList.Add(player2);

			//Create the ball
            Texture2D ballTexture = Content.Load<Texture2D>("Images/Ball");
            ball = new Ball(this, spriteBatch, ballTexture);
            this.Components.Add(ball);

			//Add each player to the GameComponents list
            foreach (Paddle paddle in playerList)
            {
                this.Components.Add(paddle);
            }

			//Create a new collision manager
            collisionManager = new CollisionManager(this, playerList, ball);
            this.Components.Add(collisionManager);

			//Create a new sound manager
			soundManager = new SoundManager(this);
			this.Components.Add(soundManager);
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

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                if(!ball.IsMoving)
                {
                    ball.Reset();
                    ScoreManager.Reset(); 
                    //TODO: reset paddles 
                }
            }

            if(keyboardState.IsKeyDown(Keys.Enter))
            {
                gameOn = true;
            }

            if (ScoreManager.Player1Wins)
            {
                //TODO: Win condition handling
                gameOn = false;
            }
            if (ScoreManager.Player2Wins)
            {
                //TODO: Win condition handling
                gameOn = false;
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
