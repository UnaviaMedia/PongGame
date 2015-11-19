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
	public class SoundManager : GameComponent
	{
		private static Game game;
		private static Dictionary<string, SoundEffect> soundEffects;

		public SoundManager(Game game)
			: base(game)
		{
			game = Game;
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


		public static void PlaySound(string sound)
		{
			if (soundEffects.ContainsKey(sound) == false)
			{
				soundEffects.Add(sound, game.Content.Load<SoundEffect>("Sounds/" + sound));
			}

			//Play the selected sound
			soundEffects[sound].Play();
		}
	}
}
