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
			mediationBinder.Bind<BotHandView>().To<BotHandMediator>();
			mediationBinder.Bind<CardDistributorView>().To<CardDistributorMediator>();
		}

		private void BindModels()
		{
			injectionBinder.Bind<IPlayerHandModel>().To<PlayerHandModel>().ToSingleton();
			injectionBinder.Bind<IBotHandModel>().To<BotHandModel>().ToSingleton();
			injectionBinder.Bind<ITableCardsModel>().To<TableCardsModel>().ToSingleton();

			injectionBinder.Bind<ICardVisualsModel>().To<CardVisualsModel>().ToSingleton();
			injectionBinder.Bind<ICard>().To<Card>().ToSingleton();
			injectionBinder.Bind<IDeckModel>().To<DeckModel>().ToSingleton();
			injectionBinder.Bind<IGameStateModel>().To<GameStateModel>().ToSingleton();
		}

		private void BindServices()
		{
			injectionBinder.Bind<IDeckService>().To<DeckService>().ToSingleton();
			injectionBinder.Bind<IPistiService>().To<PistiService>().ToSingleton();
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
			injectionBinder.Bind<ChangeGameStateSignal>().ToSingleton().CrossContext();
			commandBinder.Bind<ChangeGameStateSignal>().To<ChangeGameStateCommand>();

			commandBinder.Bind<PlayCardSignal>().To<PlayCardCommand>();

			injectionBinder.Bind<SendCardToTableSignal>().ToSingleton();
			injectionBinder.Bind<CardReachedToTableSignal>().ToSingleton();

			injectionBinder.Bind<CollectCardsSignal>().ToSingleton();
			commandBinder.Bind<CollectCardsSignal>().To<CollectCardsCommand>();

			injectionBinder.Bind<MoveCollectedCardsSignal>().ToSingleton();

			injectionBinder.Bind<BotPlayCardSignal>().ToSingleton();
			commandBinder.Bind<BotPlayCardSignal>().To<BotCardPlayCommand>();

			commandBinder.Bind<DealCardsSignal>().To<DealCardsCommand>();

			injectionBinder.Bind<CardsCollectedSignal>().ToSingleton();

			injectionBinder.Bind<GameOverSignal>().ToSingleton().CrossContext();
		}
	}
}

