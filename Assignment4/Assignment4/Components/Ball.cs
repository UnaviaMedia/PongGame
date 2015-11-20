/* Project: Assignment4 - Ball.cs
 * Purpose: Models the bouncing ball in a game of Pong
 * 
 * Revision history:
 *  Nov 19, 2015 : Created, Kendall Roth
 *                 Added properties and methods, Doug Epp
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
    /// A class to represent the ball in a game of Pong
    /// </summary>
    public class Ball : DrawableGameComponent
    {
        const int MIN_SPEED = 3;
        const int MAX_SPEED = 9;
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private Vector2 position;
        private Vector2 origin;
        private bool isMoving;
        public bool IsMoving
        {
            get { return isMoving; }
            set { isMoving = value; }
        }
        private Vector2 initialPosition;
        private Vector2 speed;

        public Vector2 Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        private Vector2 stage;
        private Rectangle collisionBounds;

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

        public Rectangle CollisionBounds
        {
            get
            {
                collisionBounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
                return collisionBounds;
            }
        }

        public Ball(Game game, SpriteBatch spriteBatch, Texture2D texture)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;

            stage = PongGame.stage;
            initialPosition = new Vector2(stage.X / 2 - texture.Width / 2, stage.Y / 2 - texture.Height / 2);
            position = initialPosition;
            speed = GetSpeed();
            isMoving = false;
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
            if (isMoving)
            {
                position.Y += speed.Y;
                position.X += speed.X;
            }

            if (position.Y < 0 || position.Y > stage.Y - texture.Height)
            {
                speed.Y = -speed.Y;

                //Play a sound to indicate collision with the walls
                PongGame.soundManager.PlaySound("click");
            }

            if (position.X < -texture.Width)
            {
                ScoreManager.Player2Score++;
                ScoreManager.Player1WonLastGame = false;

                //Play a sound to indicate winning a point
                PongGame.soundManager.PlaySound("ding");
                Reset();
            }
            if (position.X > stage.X)
            {
                ScoreManager.Player1Score++;
                ScoreManager.Player1WonLastGame = true;

                //Play a sound to indicate winning a point
                PongGame.soundManager.PlaySound("ding");
                Reset();
            }

            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Enter) && !isMoving)
            {
                StartMoving();
            }

            base.Update(gameTime);
        }
        /// <summary>
        /// Called when the ball needs to be drawn
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Resets ball position and speed
        /// </summary>
        public void Reset()
        {
            position = initialPosition;
            speed = Vector2.Zero;
            isMoving = false;
        }
        /// <summary>
        /// Generates random speed
        /// </summary>
        /// <returns>A random speed between min and max speed</returns>
        private Vector2 GetSpeed()
        {
            Random rand = new Random();
            int newSpeedX = rand.Next(MIN_SPEED, MAX_SPEED);
            if (ScoreManager.Player1WonLastGame)
            {
                newSpeedX = -newSpeedX;
            }
            int newSpeedY = -rand.Next(MIN_SPEED, MAX_SPEED);

            Vector2 newSpeed = new Vector2(newSpeedX, newSpeedY);
            return newSpeed;
        }
        /// <summary>
        /// Starts ball moving
        /// </summary>
        private void StartMoving()
        {
            speed = GetSpeed();
            isMoving = true;
        }
    }
}
