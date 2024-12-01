using strange.extensions.command.impl;
using System.Collections;
using UnityEngine;

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
			Debug.LogError("Playing Card, state => " + GameStateModel.GameState);
			Debug.LogError("Card Owner => " + Data.CardOwner);

			if(Data.CardOwner == CardOwner.Player && GameStateModel.GameState == GameState.PlayerTurn)
			{
				GameStateModel.LastPlayerState = GameState.PlayerTurn;
				ChangeGameStateSignal.Dispatch(GameState.OnHold);

				SendCardToTableSignal.Dispatch(Data.CardView);

				PlayerHandModel.RemoveCard(Data.CardView.cardData);
				CardReachedToTableSignal.AddListener(() => OnCardReachedToTable());
			}
			else if(Data.CardOwner == CardOwner.Bot && GameStateModel.GameState == GameState.BotTurn)
			{
				Debug.LogError("Bot plays");

				GameStateModel.LastPlayerState = GameState.BotTurn;
				ChangeGameStateSignal.Dispatch(GameState.OnHold);

				SendCardToTableSignal.Dispatch(Data.CardView);

				BotHandModel.RemoveCard(Data.CardView.cardData);
				CardReachedToTableSignal.AddListener(() => OnCardReachedToTable());
			}
		}

		private void OnCardReachedToTable()
		{
			PistiService.HandleCardPlayed(Data.CardView.cardData);
		}
	}
}