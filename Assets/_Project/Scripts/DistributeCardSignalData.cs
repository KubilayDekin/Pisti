using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class DistributeCardSignalData
	{
		public Card Card { get; set; }
		public CardOwner CardOwner { get; set; }
		public bool IsVisible { get; set; }

		public DistributeCardSignalData(Card card, CardOwner cardOwner, bool isVisible)
		{
			Card = card;
			CardOwner = cardOwner;
			IsVisible = isVisible;
		}
	}

	public enum CardOwner
	{
		Player,
		Bot,
		Table
	}
}