using strange.extensions.mediation.impl;
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

		internal void DistributeCard(Card card, bool isPlayerCard)
		{
			GameObject cardToDistribute = Instantiate(cardPrefab, deck.transform.position, cardPrefab.transform.rotation);
			cardToDistribute.transform.SetParent(deck);
			CardView cardToDistributeCardView = cardToDistribute.GetComponent<CardView>();
			cardToDistributeCardView.InitializeCardView(card);
			cardToDistributeCardView.MoveToTheHand(isPlayerCard ? playerHand : botHand);
		}
	}
}