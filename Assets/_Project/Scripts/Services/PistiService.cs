using System.Collections;
using System.Collections.Generic;
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
				AddPoints(10);
				CollectCards(playedCard);
				return;
			}

            if (CheckMatch(playedCard))
            {
				CollectCards(playedCard);
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
			AddPoints(CalculatePointsOnTable());
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

				if (DealCards())
					return;

				ChangeGameStateSignal.Dispatch(GameState.PlayerTurn);
			}
		}

		private bool DealCards()
		{
			if (PlayerHandModel.CardsToPlay.Count == 0 && BotHandModel.CardsToPlay.Count == 0)
			{
				if(DeckModel.Cards.Count == 0)
				{
					Debug.LogError("Game Over");
				}
				else
				{
					DealCardsSignal.Dispatch();
				}

				return true;
			}

			return false;
		}

		private void AddPoints(int points)
		{
			if(GameStateModel.LastPlayerState == GameState.PlayerTurn)
			{
				PlayerHandModel.Points += points;
			}
			else if(GameStateModel.LastPlayerState == GameState.BotTurn)
			{
				BotHandModel.Points += points;
			}
		}

		private int CalculatePointsOnTable()
		{
			List<Card> cards = new List<Card>();
			cards = TableCardsModel.CardsOnTable;

			int points = 0;

			foreach (var card in cards)
			{
				switch (card.CardValue)
				{
					case 1:
						points += 1;
						break;
					case 2 when card.CardSuit == Constants.Clubs:
						points += 2;
						break;
					case 10 when card.CardSuit == Constants.Diamonds:
						points += 3;
						break;
					case 11:
						points += 1;
						break;
				}
			}

			return points;
		}
	}
}