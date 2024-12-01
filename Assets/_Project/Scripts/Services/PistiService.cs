using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class PistiService : IPistiService
	{
		[Inject] public ChangeGameStateSignal ChangeGameStateSignal { get; set; }
		[Inject] public ITableCardsModel TableCardsModel { get; set; }
		[Inject] public IDeckModel DeckModel { get; set; }

		public void HandleCardPlayed(Card playedCard)
		{
			if(CheckPisti(playedCard))
			{
				/// TODO: Implement pisti
				Debug.LogError("Pişti");
				return;
			}

            if (CheckMatch(playedCard))
            {
				/// TODO: Implement match
				Debug.LogError("Match");
				return;
			}
			else
			{
				TableCardsModel.AddCard(playedCard);
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

			if (playedCard.CardValue == cardOnTop.CardValue)
				return true;

			return false;
		}
	}
}