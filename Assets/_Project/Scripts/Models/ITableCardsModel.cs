using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pisti
{
	public interface ITableCardsModel
	{
		public List<Card> CardsOnTable { get; set; }
		public Card GetCardOnTop();
		public void AddCard(Card card);
	}
}