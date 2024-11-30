using System.Collections;
using UnityEngine;

namespace Pisti
{
	[CreateAssetMenu(fileName = "CardSprites", menuName = "CardSprites", order = 1)]
	public class CardSprites : ScriptableObject
	{
		[Header("Suits")]
		public Sprite SpadesSprite;
		public Sprite HeartsSprite;
		public Sprite DiamondsSprite;
		public Sprite ClubsSprite;

		[Header("Jacks")]
		public Sprite SpadesJackSprite;
		public Sprite HeartsJackSprite;
		public Sprite DiamondsJackSprite;
		public Sprite ClubsJackSprite;

		[Header("Queens")]
		public Sprite SpadesQueenSprite;
		public Sprite HeartsQueenSprite;
		public Sprite DiamondsQueenSprite;
		public Sprite ClubsQueenSprite;

		[Header("Kings")]
		public Sprite SpadesKingSprite;
		public Sprite HeartsKingSprite;
		public Sprite DiamondsKingSprite;
		public Sprite ClubsKingSprite;
	}
}