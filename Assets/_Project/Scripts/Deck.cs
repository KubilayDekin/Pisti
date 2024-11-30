using Pisti;
using System.Collections.Generic;
using UnityEngine;

namespace Pisti
{
	public class Deck : MonoBehaviour
	{
		private List<Card> deck = new List<Card>();

		private void CreateDeck()
		{
			int[] values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }; // 1 is Ace, 11 is Jack, 12 is Queen, 13 is King
			string[] suits = new string[] { Constants.Spades, Constants.Hearts, Constants.Clubs, Constants.Diamonds };

			foreach (var suit in suits)
			{
				foreach (var value in values)
				{
					Sprite sprite = GetCardSprite(value, suit);
					deck.Add(new Card(value, suit, sprite));
				}
			}
		}

		private Sprite GetCardSprite(int cardValue, string cardSuit)
		{
			/// Returning the appropriate sprite for the cards with special sprites
			if (cardValue == 11)
			{
				if (cardSuit == Constants.Spades)
				{
					return CardVisualizer.SpadesJackSprite;
				}
				else if (cardSuit == Constants.Hearts)
				{
					return CardVisualizer.HeartsJackSprite;
				}
				else if (cardSuit == Constants.Clubs)
				{
					return CardVisualizer.ClubsJackSprite;
				}
				else if (cardSuit == Constants.Diamonds)
				{
					return CardVisualizer.DiamondsJackSprite;
				}
			}
			else if (cardValue == 12)
			{				
				if (cardSuit == Constants.Spades)
				{
					return CardVisualizer.SpadesQueenSprite;
				}
				else if (cardSuit == Constants.Hearts)
				{
					return CardVisualizer.HeartsQueenSprite;
				}
				else if (cardSuit == Constants.Clubs)
				{
					return CardVisualizer.ClubsQueenSprite;
				}
				else if (cardSuit == Constants.Diamonds)
				{
					return CardVisualizer.DiamondsQueenSprite;
				}
			}
			else if (cardValue == 13)
			{
				if (cardSuit == Constants.Spades)
				{
					return CardVisualizer.SpadesKingSprite;
				}
				else if (cardSuit == Constants.Hearts)
				{
					return CardVisualizer.HeartsKingSprite;
				}
				else if (cardSuit == Constants.Clubs)
				{
					return CardVisualizer.ClubsKingSprite;
				}
				else if (cardSuit == Constants.Diamonds)
				{
					return CardVisualizer.DiamondsKingSprite;
				}
			}

			// If the card is not a special card, get the sprite from the CardVisualizer class
			return CardVisualizer.GetCardSprite(cardSuit);
		}

		public List<Card> GetDeck()
		{
			return deck;
		}
	}
}

