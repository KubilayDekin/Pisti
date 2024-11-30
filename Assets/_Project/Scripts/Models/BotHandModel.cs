using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pisti
{
	public class BotHandModel : IBotHandModel
	{
		public List<Card> Cards { get; set; } = new List<Card>();

		public void AddCard(Card card)
		{
			Cards.Add(card);
		}

		public void RemoveCard(Card card)
		{
			Cards.Remove(card);
		}
	}
}