using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pisti
{
	public class Card : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] private TextMeshProUGUI cardValueText;
		[SerializeField] private Image cardImage; 

		public int CardValue { get; private set; }
		public string CardSuit { get; private set; }

		public Card(int cardValue, string cardSuit, Sprite cardSprite)
		{
			CardValue = cardValue;
			CardSuit = cardSuit;

			cardValueText.text = CardVisualizer.GetCardValueText(CardValue);
			cardImage.sprite = cardSprite;
		}
	}
}

