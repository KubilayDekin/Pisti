using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pisti
{
	public class CardView : View
	{
		[Header("References")]
		[SerializeField] private Image cardImage;
		[SerializeField] private TextMeshProUGUI cardValueText;

		[HideInInspector] public Card cardData;

		public void InitializeCardView(Card cardData)
		{
			this.cardData = cardData;
			cardImage.sprite = cardData.CardSprite;
			cardValueText.text = cardData.CardValueText;
		}
	}
}

