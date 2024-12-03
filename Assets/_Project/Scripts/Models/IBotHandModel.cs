using System.Collections.Generic;

namespace Pisti
{
	public interface IBotHandModel
	{
		public List<Card> CardsToPlay { get; set; }
		public List<Card> WonCards { get; set; }
		public int Points { get; set; }
		public void AddCard(Card card);
		public void RemoveCard(Card card);
	}
}