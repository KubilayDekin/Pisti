using DG.Tweening;
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

		[Header("Settings")]
		[SerializeField] private Color redTextColor;
		[SerializeField] private Color blackTextColor;

		[HideInInspector] public Card cardData;

		public void InitializeCardView(Card cardData)
		{
			this.cardData = cardData;
			cardImage.sprite = cardData.CardSprite;
			cardValueText.text = cardData.CardValueText;

			if(cardData.CardSuit == Constants.Diamonds || cardData.CardSuit == Constants.Hearts)
			{
				cardValueText.color = redTextColor;
			}
			else
			{
				cardValueText.color = blackTextColor;
			}
		}

		public void MoveToTheHand(Transform hand)
		{
			transform.DOMove(hand.position, 0.5f).SetEase(Ease.Linear).OnComplete(() => transform.parent = hand);
		}
	}
}


