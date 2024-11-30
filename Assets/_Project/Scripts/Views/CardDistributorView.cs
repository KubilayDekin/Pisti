using strange.extensions.mediation.impl;
using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class CardDistributorView : View
	{
		[SerializeField] private CardView cardPrefab;
		[SerializeField] private Transform playerHand;
		[SerializeField] private Transform botHand;
		[SerializeField] private Transform tableCards;
		[SerializeField] private Transform deck;

		internal void DistributeCard(Card card, bool isPlayerCard)
		{
			CardView cardToDistribute = Instantiate(cardPrefab, deck.transform.position, cardPrefab.transform.rotation);
		}
	}
}