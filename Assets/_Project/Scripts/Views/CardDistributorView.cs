﻿using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class CardDistributorView : View
	{
		[SerializeField] private GameObject cardPrefab;
		[SerializeField] private Transform playerHand;
		[SerializeField] private Transform botHand;
		[SerializeField] private Transform tableCards;
		[SerializeField] private Transform deck;

		internal Signal onWonCardsMovementCompleted = new Signal(); 

		internal void DistributeCard(Card card, CardOwner cardOwner, bool isVisible)
		{
			GameObject cardToDistribute = Instantiate(cardPrefab, deck.transform.position, cardPrefab.transform.rotation);
			cardToDistribute.transform.SetParent(deck);
			CardView cardToDistributeCardView = cardToDistribute.GetComponent<CardView>();
			cardToDistributeCardView.InitializeCardView(card);

			Transform cardTargetTransform = null;

			switch (cardOwner)
			{
				case CardOwner.Player:
					cardTargetTransform = playerHand;
					break;
				case CardOwner.Bot:
					cardTargetTransform = botHand;
					break;
				case CardOwner.Table:
					cardTargetTransform = tableCards;
					break;
			}

			cardToDistributeCardView.MoveToTheHand(cardTargetTransform);
			cardToDistributeCardView.SetVisibility(isVisible);
			cardToDistributeCardView.SetCardInteractability(cardOwner);
		}

		internal void SendCardToTable(CardView cardView)
		{
			cardView.MoveToTheTable(tableCards);
		}

		internal void SendWonCardsToPlayer(CardOwner wonPlayer)
		{
			Transform target = wonPlayer == CardOwner.Player ? playerHand : botHand;

			foreach (Transform card in tableCards)
			{
				card.GetComponent<CardView>().MoveToWonPoint(target);
			}

			StartCoroutine(OnCardsCollected());
		}

		private IEnumerator OnCardsCollected()
		{
			yield return new WaitForSeconds(Constants.wonCardMoveDuration);

			onWonCardsMovementCompleted.Dispatch();
		}
	}
}