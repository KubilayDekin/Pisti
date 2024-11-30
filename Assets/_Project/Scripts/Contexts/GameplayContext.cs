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

			BindViews();
			BindModels();
			BindServices();
			BindSignalsAndCommands();
		}

		protected override void postBindings()
		{
			base.postBindings();

			InitializeGameSignal initializeGameSignal = (InitializeGameSignal)injectionBinder.GetInstance<InitializeGameSignal>();
			initializeGameSignal.Dispatch();
		}

		private void BindViews()
		{
			mediationBinder.Bind<CardView>().To<CardMediator>();
		}

		private void BindModels()
		{
			injectionBinder.Bind<ICardVisualsModel>().To<CardVisualsModel>().ToSingleton().CrossContext();
			injectionBinder.Bind<ICard>().To<Card>().ToSingleton().CrossContext();
		}

		private void BindServices()
		{
			injectionBinder.Bind<IDeckService>().ToSingleton().CrossContext();
		}

		private void BindSignalsAndCommands()
		{
			injectionBinder.Bind<InitializeGameSignal>().ToSingleton();

			commandBinder.Bind<InitializeGameSignal>()
				.To<SetCardSpriteResourcesCommand>()
				.To<CreateDeckCommand>()
				.To<DealCardsAtStartCommand>()
				.InSequence();
		}
	}
}

