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
		private Dictionary<string, SoundEffect> soundEffects;

		public SoundManager(Game game)
			: base(game)
		{
			soundEffects = new Dictionary<string, SoundEffect>();
			soundEffects.Add("click", Game.Content.Load<SoundEffect>("Sounds/click"));
			soundEffects.Add("ding", Game.Content.Load<SoundEffect>("Sounds/ding"));
			soundEffects.Add("applause", Game.Content.Load<SoundEffect>("Sounds/applause1"));
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


		public void PlaySound(string sound)
		{
			//Play the selected sound
			soundEffects[sound].Play();
		}
	}
}
