using UnityEngine;

namespace Pisti
{
	public class Card : ICard
	{
		public int CardValue { get; set; }
		public string CardSuit { get; set; }
		public Sprite CardSprite { get; set; }
		public string CardValueText { get; set; }

		public Card(int cardValue, string cardSuit, Sprite cardSprite, string cardValueText)
		{
			CardValue = cardValue;
			CardSuit = cardSuit;
			CardSprite = cardSprite;
			CardValueText = cardValueText;
		}
	}
}