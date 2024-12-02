using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class GameStatusUIContext : SignalContext
	{
		public GameStatusUIContext(MonoBehaviour view) : base(view)
		{
		}

		protected override void mapBindings()
		{
			base.mapBindings();

			BindViews();
		}

		private void BindViews()
		{
			mediationBinder.Bind<ScoreboardView>().To<ScoreboardMediator>();
		}
	}
}