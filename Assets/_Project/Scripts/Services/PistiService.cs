using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Pisti
{
	public class PistiService : IPistiService
	{
		[Inject] public ChangeGameStateSignal ChangeGameStateSignal { get; set; }
		[Inject] public ITableCardsModel TableCardsModel { get; set; }
		[Inject] public IDeckModel DeckModel { get; set; }
		[Inject] public IGameStateModel GameStateModel { get; set; }
		[Inject] public CollectCardsSignal CollectCardsSignal { get; set; }
		[Inject] public IPlayerHandModel PlayerHandModel { get; set; }
		[Inject] public IBotHandModel BotHandModel { get; set; }
		[Inject] public DealCardsSignal DealCardsSignal { get; set; }
		[Inject] public CardsCollectedSignal CardsCollectedSignal { get; set; }

		public void HandleCardPlayed(Card playedCard)
		{
			if(CheckPisti(playedCard))
			{
				CollectCards(playedCard);
				/// TODO: Implement pisti
				Debug.LogError("Pişti");
				return;
			}

            if (CheckMatch(playedCard))
            {
				CollectCards(playedCard);
				/// TODO: Implement match
				Debug.LogError("Match");
				return;
			}
			else
			{
				TableCardsModel.AddCard(playedCard);
				ChangeGameState(false, playedCard);
			}
        }

		public bool CheckPisti(Card playedCard)
		{
			Card cardOnTop = TableCardsModel.GetCardOnTop();

			if (cardOnTop == null)
				return false;

			if(playedCard.CardValue == cardOnTop.CardValue && TableCardsModel.CardsOnTable.Count == 1)
				return true;

			return false;
		}

		public bool CheckMatch(Card playedCard)
		{
			Card cardOnTop = TableCardsModel.GetCardOnTop();

			if (cardOnTop == null)
				return false;

			if (playedCard.CardValue == cardOnTop.CardValue || playedCard.CardValue == 11)
				return true;

			return false;
		}

		private void CollectCards(Card playedCard)
		{
			TableCardsModel.AddCard(playedCard);

			ChangeGameState(true, playedCard);
		}

		private async void ChangeGameState(bool isMatched, Card playedCard)
		{
			bool shouldWait = isMatched;

			if (GameStateModel.LastPlayerState == GameState.PlayerTurn)
			{
				if (isMatched)
				{
					CollectCardsSignal.Dispatch(CardOwner.Player);
					CardsCollectedSignal.AddOnce(() => shouldWait = false);
				}

				while (shouldWait)
				{
					await Task.Delay(250);
				}

				PlayerHandModel.RemoveCard(playedCard);
				Debug.LogError("Player Card Removed");

				if (DealCards())
					return;

				ChangeGameStateSignal.Dispatch(GameState.BotTurn);
			}
			else if (GameStateModel.LastPlayerState == GameState.BotTurn)
			{
				if (isMatched)
				{
					CollectCardsSignal.Dispatch(CardOwner.Bot);
					CardsCollectedSignal.AddOnce(() => shouldWait = false);
				}

				while (shouldWait)
				{
					await Task.Delay(250);
				}

				BotHandModel.RemoveCard(playedCard);
				Debug.LogError("Bot Card Removed");

				if (DealCards())
					return;

				ChangeGameStateSignal.Dispatch(GameState.PlayerTurn);
			}
		}

		private bool DealCards()
		{
			Debug.LogError("Player Has " + PlayerHandModel.CardsToPlay.Count + " Cards To Play");
			Debug.LogError("Bot Has " + BotHandModel.CardsToPlay.Count + " Cards To Play");

			if (PlayerHandModel.CardsToPlay.Count == 0 && BotHandModel.CardsToPlay.Count == 0)
			{
				if(DeckModel.Cards.Count == 0)
				{
					Debug.LogError("Game Over");
				}
				else
				{
					Debug.LogError("Dealing Cards Both Player Hands Are Empty");
					DealCardsSignal.Dispatch();
				}

				return true;
			}

			return false;
		}
	}
}