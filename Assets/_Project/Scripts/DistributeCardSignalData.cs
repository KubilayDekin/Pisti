using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class DistributeCardSignalData
	{
		public Card Card { get; set; }
		public bool IsPlayerCard { get; set; }

		public DistributeCardSignalData(Card card, bool isPlayerCard)
		{
			Card = card;
			IsPlayerCard = isPlayerCard;
		}
	}
}