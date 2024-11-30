using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class CardVisualsModel : ICardVisualsModel
	{
		// Suits
		public Sprite SpadesSprite { get; set; }
		public Sprite HeartsSprite { get; set; }
		public Sprite DiamondsSprite { get; set; }
		public Sprite ClubsSprite { get; set; }

		// Face cards which needs special sprites
		public Sprite SpadesJackSprite { get; set; }
		public Sprite HeartsJackSprite { get; set; }
		public Sprite DiamondsJackSprite { get; set; }
		public Sprite ClubsJackSprite { get; set; }

		public Sprite SpadesQueenSprite { get; set; }
		public Sprite HeartsQueenSprite { get; set; }
		public Sprite DiamondsQueenSprite { get; set; }
		public Sprite ClubsQueenSprite { get; set; }

		public Sprite SpadesKingSprite { get; set; }
		public Sprite HeartsKingSprite { get; set; }
		public Sprite DiamondsKingSprite { get; set; }
		public Sprite ClubsKingSprite { get; set; }

		public void SetCardSprites(CardSprites cardSprites)
		{
			SpadesSprite = cardSprites.SpadesSprite;
			HeartsSprite = cardSprites.HeartsSprite;
			DiamondsSprite = cardSprites.DiamondsSprite;
			ClubsSprite = cardSprites.ClubsSprite;

			SpadesJackSprite = cardSprites.SpadesJackSprite;
			HeartsJackSprite = cardSprites.HeartsJackSprite;
			DiamondsJackSprite = cardSprites.DiamondsJackSprite;
			ClubsJackSprite = cardSprites.ClubsJackSprite;

			SpadesQueenSprite = cardSprites.SpadesQueenSprite;
			HeartsQueenSprite = cardSprites.HeartsQueenSprite;
			DiamondsQueenSprite = cardSprites.DiamondsQueenSprite;
			ClubsQueenSprite = cardSprites.ClubsQueenSprite;

			SpadesKingSprite = cardSprites.SpadesKingSprite;
			HeartsKingSprite = cardSprites.HeartsKingSprite;
			DiamondsKingSprite = cardSprites.DiamondsKingSprite;
			ClubsKingSprite = cardSprites.ClubsKingSprite;
		}

		public Sprite GetCardSprite(string cardSuit)
		{
			switch (cardSuit)
			{
				case Constants.Spades:
					return SpadesSprite;
				case Constants.Hearts:
					return HeartsSprite;
				case Constants.Diamonds:
					return DiamondsSprite;
				case Constants.Clubs:
					return ClubsSprite;
				default:
					return null;
			}
		}

		public string GetCardValueText(int cardValue)
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