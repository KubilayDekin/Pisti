using UnityEngine;

namespace Pisti
{
	public interface ICardVisualsModel
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

		public void SetCardSprites(CardSprites cardSprites);
		public Sprite GetCardSprite(string cardSuit);
		public string GetCardValueText(int cardValue);
	}
}

