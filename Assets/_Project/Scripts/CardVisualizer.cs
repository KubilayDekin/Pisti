using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Pisti
{
	public static class CardVisualizer
	{
		public static Sprite SpadesSprite { get; set; }
		public static Sprite HeartsSprite { get; set; }
		public static Sprite DiamondsSprite { get; set; }
		public static Sprite ClubsSprite { get; set; }

		public static Sprite GetCardSprite(string cardSuit)
		{
			switch (cardSuit)
			{
				case "Spades":
					return SpadesSprite;
				case "Hearts":
					return HeartsSprite;
				case "Diamonds":
					return DiamondsSprite;
				case "Clubs":
					return ClubsSprite;
				default:
					return null;
			}
		}

		public static string GetCardValueText(int cardValue)
		{
			switch (cardValue)
			{
				case 1:
					return "A";
				case 11:
					return "J";
				case 12:
					return "Q";
				case 13:
					return "K";
				default:
					return cardValue.ToString();
			}
		}
	}
}
