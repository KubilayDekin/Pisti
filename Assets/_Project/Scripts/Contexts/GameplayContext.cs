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
			mediationBinder.Bind<PlayerHandView>().To<PlayerHandMediator>();
			mediationBinder.Bind<BotHandView>().To<BotHandMediator>();
			mediationBinder.Bind<CardDistributorView>().To<CardDistributorMediator>();
		}

		private void BindModels()
		{
			injectionBinder.Bind<IPlayerHandModel>().To<PlayerHandModel>().ToSingleton();
			injectionBinder.Bind<IBotHandModel>().To<BotHandModel>();

			injectionBinder.Bind<ICardVisualsModel>().To<CardVisualsModel>().ToSingleton().CrossContext();
			injectionBinder.Bind<ICard>().To<Card>().ToSingleton().CrossContext();
			injectionBinder.Bind<IDeckModel>().To<DeckModel>().ToSingleton().CrossContext();
			injectionBinder.Bind<IGameStateModel>().To<GameStateModel>().ToSingleton().CrossContext();
		}

		private void BindServices()
		{
			injectionBinder.Bind<IDeckService>().To<DeckService>().ToSingleton().CrossContext();
		}

		private void BindSignalsAndCommands()
		{
			injectionBinder.Bind<InitializeGameSignal>().ToSingleton();

			commandBinder.Bind<InitializeGameSignal>()
				.To<SetCardSpriteResourcesCommand>()
				.To<CreateDeckCommand>()
				.To<DealCardsAtStartCommand>()
				.InSequence();

			injectionBinder.Bind<DistributeCardSignal>().ToSingleton();
			injectionBinder.Bind<ChangeGameStateSignal>().ToSingleton();
		}
	}
}

