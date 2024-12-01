using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pisti
{
	public class BotPlayCardSignalData
	{
		public List<CardView> CardViews = new List<CardView>();

		public BotPlayCardSignalData(List<CardView> cardViews)
		{
			CardViews = cardViews;
		}
	}
}