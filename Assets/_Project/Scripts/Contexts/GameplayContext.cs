using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pisti
{
	public class GameplayContext : SignalContext
	{
		public GameplayContext(MonoBehaviour view) : base(view)
		{
		}

		protected override void mapBindings()
		{
			base.mapBindings();

			injectionBinder.Bind<ICardVisualsModel>().To<CardVisualsModel>().ToSingleton().CrossContext();

			injectionBinder.Bind<InitializeGameSignal>().ToSingleton();
			commandBinder.Bind<InitializeGameSignal>().To<SetCardSpriteResourcesCommand>();
		}

		protected override void postBindings()
		{
			base.postBindings();

			InitializeGameSignal initializeGameSignal = (InitializeGameSignal)injectionBinder.GetInstance<InitializeGameSignal>();
			initializeGameSignal.Dispatch();
		}
	}
}

