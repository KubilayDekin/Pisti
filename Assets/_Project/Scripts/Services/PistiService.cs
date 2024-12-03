using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
		[Inject] public GameOverSignal GameOverSignal { get; set; }

		public void HandleCardPlayed(Card playedCard)
		{
			if (CheckPisti(playedCard) || CheckMatch(playedCard))
			{
				CollectCards(playedCard, CheckPisti(playedCard));
			}
			else
			{
				TableCardsModel.AddCard(playedCard);
				ChangeGameState(false, playedCard);
			}
		}

		private bool CheckPisti(Card playedCard)
		{
			var cardOnTop = TableCardsModel.GetCardOnTop();
			return cardOnTop != null &&
				   playedCard.CardValue == cardOnTop.CardValue &&
				   TableCardsModel.CardsOnTable.Count == 1;
		}

		private bool CheckMatch(Card playedCard)
		{
			var cardOnTop = TableCardsModel.GetCardOnTop();
			return cardOnTop != null &&
				   (playedCard.CardValue == cardOnTop.CardValue || playedCard.CardValue == 11);
		}

		private void CollectCards(Card playedCard, bool isPisti)
		{
			TableCardsModel.AddCard(playedCard);

			if (isPisti)
			{
				AddPoints(10);
			}
			else
			{
				AddPoints(CalculatePointsOnTable());
			}

			ChangeGameState(true, playedCard);
		}

		private async void ChangeGameState(bool isMatched, Card playedCard)
		{
			var isPlayerTurn = GameStateModel.LastPlayerState == GameState.PlayerTurn;
			bool shouldWait = isMatched;

			if (isMatched)
			{
				CollectCardsSignal.Dispatch(isPlayerTurn ? CardOwner.Player : CardOwner.Bot);
				CardsCollectedSignal.AddOnce(() => shouldWait = false);
			}

			await WaitForCondition(() => !shouldWait);

			if (isPlayerTurn)
			{
				PlayerHandModel.RemoveCard(playedCard);
			}
			else
			{
				BotHandModel.RemoveCard(playedCard);
			}

			if (!DealCards())
			{
				ChangeGameStateSignal.Dispatch(isPlayerTurn ? GameState.BotTurn : GameState.PlayerTurn);
			}
		}

		private async Task WaitForCondition(Func<bool> condition)
		{
			while (!condition())
			{
				await Task.Delay(250);
			}
		}

		private bool DealCards()
		{
			if (PlayerHandModel.CardsToPlay.Count == 0 && BotHandModel.CardsToPlay.Count == 0)
			{
				if (DeckModel.Cards.Count == 0)
				{
					EndGame();
				}
				else
				{
					DealCardsSignal.Dispatch();
				}

				return true;
			}

			return false;
		}

		private void EndGame()
		{
			GiveCardsOnTableToTheLastCollector();
			AwardPointsToPlayerWithMostCards();
			GameOverSignal.Dispatch(new GameOverSignalData(PlayerHandModel.Points, BotHandModel.Points));
		}

		private void AddPoints(int points)
		{
			if (GameStateModel.LastPlayerState == GameState.PlayerTurn)
			{
				PlayerHandModel.Points += points;
			}
			else
			{
				BotHandModel.Points += points;
			}
		}

		private int CalculatePointsOnTable()
		{
			int points = 0;

			foreach (var card in TableCardsModel.CardsOnTable)
			{
				points += card.CardValue switch
				{
					1 => 1,
					2 when card.CardSuit == Constants.Clubs => 2,
					10 when card.CardSuit == Constants.Diamonds => 3,
					11 => 1,
					_ => 0
				};
			}

			return points;
		}

		private void GiveCardsOnTableToTheLastCollector()
		{
			if (TableCardsModel.CardsOnTable.Count > 0)
			{
				CollectCardsSignal.Dispatch(GameStateModel.LastCardCollector);
			}
		}

		private void AwardPointsToPlayerWithMostCards()
		{
			if (PlayerHandModel.WonCards.Count > BotHandModel.WonCards.Count)
			{
				PlayerHandModel.Points += 3;
			}
			else if (PlayerHandModel.WonCards.Count < BotHandModel.WonCards.Count)
			{
				BotHandModel.Points += 3;
			}
		}

	}
}