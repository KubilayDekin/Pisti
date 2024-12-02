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
			BindSignalsAndCommands();
		}

		private void BindViews()
		{
			mediationBinder.Bind<ScoreboardView>().To<ScoreboardMediator>();
			mediationBinder.Bind<GameOverCanvasView>().To<GameOverCanvasMediator>();
		}

		private void BindSignalsAndCommands()
		{
			injectionBinder.Bind<UpdatePointTextsSignal>().ToSingleton().CrossContext();

			injectionBinder.Bind<RestartGameSignal>().ToSingleton().CrossContext();
			commandBinder.Bind<RestartGameSignal>().To<RestartGameCommand>();
		}
	}
}