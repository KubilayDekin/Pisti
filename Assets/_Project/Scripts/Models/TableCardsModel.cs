using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pisti
{
	public class TableCardsModel : ITableCardsModel
	{
		public List<Card> CardsOnTable { get; set; } = new List<Card>();

		public Card GetCardOnTop()
		{
			if(CardsOnTable.Count > 0)
			{
				return CardsOnTable[^1];
			}

			return null;
		}

		public void AddCard(Card card) => CardsOnTable.Add(card);
	}
}