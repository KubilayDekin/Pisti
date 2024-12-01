using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pisti
{
	public class BotHandModel : IBotHandModel
	{
		public List<Card> CardsToPlay { get; set; } = new List<Card>();
		public List<Card> WonCards { get; set; } = new List<Card>();
		public int Points { get; set; }

		public void AddCard(Card card)
		{
			CardsToPlay.Add(card);
		}

		public void RemoveCard(Card card)
		{
			CardsToPlay.Remove(card);
		}
	}
}