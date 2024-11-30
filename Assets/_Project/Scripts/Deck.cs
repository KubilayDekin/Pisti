using Pisti;
using System.Collections.Generic;
using UnityEngine;

namespace Pisti
{
	public class Deck : MonoBehaviour
	{
		public Sprite spadeSprite, heartSprite, clubSprite, diamondSprite;
		public Sprite jackSprite, queenSprite, kingSprite;

		private List<Card> deck = new List<Card>();

		void Start()
		{
			CreateDeck();
		}

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
				return jackSprite;
			}
			else if (cardValue == 12)
			{
				return queenSprite;
			}
			else if (cardValue == 13)
			{
				return kingSprite;
			}

			// Use CardVisualizer for other cards
			return CardVisualizer.GetCardSprite(cardSuit);
		}

		public List<Card> GetDeck()
		{
			return deck;
		}
	}
}

