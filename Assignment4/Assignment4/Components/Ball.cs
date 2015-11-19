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
    public class Ball : DrawableGameComponent
    {
        const int MIN_SPEED = 3;
        const int MAX_SPEED = 9;
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private Vector2 position;
        private bool isMoving;
        public Vector2 Position1
        {
            get { return position; }
            set { position = value; }
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

            stage = Settings.stage;
            initialPosition = new Vector2(stage.X / 2 - texture.Width / 2, stage.Y / 2 - texture.Height / 2);
            position = initialPosition;
            speed = GetSpeed();
            isMoving = false;
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
            position.Y += speed.Y;
            position.X += speed.X;

            if (position.Y < 0)
            {
                speed.Y = Math.Abs(speed.Y);
            }
            else if (position.Y > stage.Y - texture.Height)
            {
                speed.Y = -speed.Y;
            }

            if (position.X < 0)
            {
                //TODO: player 2 wins
                Reset();
            }
            if (position.X > stage.X)
            {
                //TODO: player 1 wins
                Reset();
            }

            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Space))
            {
                Reset();
            }
            if (ks.IsKeyDown(Keys.Enter) && !isMoving)
            {
                speed = GetSpeed();
                isMoving = true;
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
        private void Reset()
        {
            position = initialPosition;
            speed = Vector2.Zero;
            isMoving = false;
        }
        private Vector2 GetSpeed()
        {
            Random rand = new Random();
            int newSpeedX = rand.Next(MIN_SPEED, MAX_SPEED);
            int newSpeedY = -rand.Next(MIN_SPEED, MAX_SPEED);

            Vector2 newSpeed = new Vector2(newSpeedX, newSpeedY);
            return newSpeed;
        }
    }
}
