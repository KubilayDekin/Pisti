using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pisti
{
	public interface IPlayerHandModel
	{
		public List<Card> CardsToPlay { get; set; }
		public List<Card> WonCards { get; set; }
		public int Points { get; set; }
		public void AddCard(Card card);
		public void RemoveCard(Card card);
	}
}