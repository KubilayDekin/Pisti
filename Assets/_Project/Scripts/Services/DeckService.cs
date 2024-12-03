using UnityEngine;

namespace Pisti
{
	public class DeckService : IDeckService
	{
		[Inject] public ICardVisualsModel CardVisualsModel { get; set; }
		[Inject] public IDeckModel DeckModel { get; set; }

		public void CreateDeck()
		{
			foreach (var suit in Constants.suits)
			{
				foreach (var value in Constants.values)
				{
					Sprite cardSprite = CardVisualsModel.GetCardSprite(suit);
					string cardValueText = CardVisualsModel.GetCardValueText(value);

					DeckModel.Cards.Add(new Card(value, suit, cardSprite, cardValueText));
				}
			}
		}

		public void ShuffleDeck()
		{
			for (int i = 0; i < DeckModel.Cards.Count; i++)
			{
				Card temp = DeckModel.Cards[i];
				int randomIndex = Random.Range(i, DeckModel.Cards.Count);
				DeckModel.Cards[i] = DeckModel.Cards[randomIndex];
				DeckModel.Cards[randomIndex] = temp;
			}
		}

		public Card DrawCard()
		{
			Card card = DeckModel.Cards[0];
			DeckModel.Cards.RemoveAt(0);
			return card;
		}
	}
}