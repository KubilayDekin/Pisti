using strange.extensions.command.impl;

namespace Pisti
{
	public class PlayCardCommand : Command
	{
		[Inject] public PlayCardSignalData Data { get; set; }
		[Inject] public IGameStateModel GameStateModel { get; set; }
		[Inject] public ChangeGameStateSignal ChangeGameStateSignal { get; set; }
		[Inject] public IPistiService PistiService { get; set; }
		[Inject] public SendCardToTableSignal SendCardToTableSignal { get; set; }
		[Inject] public CardReachedToTableSignal CardReachedToTableSignal { get; set; }
		[Inject] public ITableCardsModel TableCardsModel { get; set; }
		[Inject] public IPlayerHandModel PlayerHandModel { get; set; }
		[Inject] public IBotHandModel BotHandModel { get; set; }

		public override void Execute()
		{
			if (IsValidState(Data.CardOwner, GameStateModel.GameState))
			{
				ProcessCardPlay(Data.CardView, Data.CardOwner);
			}
		}

		private bool IsValidState(CardOwner cardOwner, GameState gameState)
		{
			return (cardOwner == CardOwner.Player && gameState == GameState.PlayerTurn) ||
				   (cardOwner == CardOwner.Bot && gameState == GameState.BotTurn);
		}

		private void ProcessCardPlay(CardView cardView, CardOwner cardOwner)
		{
			Retain();

			GameStateModel.LastPlayerState = cardOwner == CardOwner.Player ? GameState.PlayerTurn : GameState.BotTurn;
			ChangeGameStateSignal.Dispatch(GameState.OnHold);

			SendCardToTableSignal.Dispatch(cardView);
			CardReachedToTableSignal.AddListener(OnCardReachedToTable);
		}

		private void OnCardReachedToTable()
		{
			PistiService.HandleCardPlayed(Data.CardView.cardData);
			CardReachedToTableSignal.RemoveListener(OnCardReachedToTable);
			Release();
		}
	}
}