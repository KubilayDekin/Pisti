using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class DistributeCardSignalData
	{
		public Card Card { get; set; }
		public CardOwner CardOwner { get; set; }

		public DistributeCardSignalData(Card card, CardOwner cardOwner)
		{
			Card = card;
			CardOwner = cardOwner;
		}
	}

	public enum CardOwner
	{
		Player,
		Bot,
		Table
	}
}