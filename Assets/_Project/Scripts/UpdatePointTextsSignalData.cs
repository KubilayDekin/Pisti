using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class UpdatePointTextsSignalData
	{
		public CardOwner CardOwner { get; set; }
		public int Points { get; set; }

		public UpdatePointTextsSignalData(CardOwner cardOwner, int points)
		{		
			CardOwner = cardOwner;
			Points = points;
		}
	}
}