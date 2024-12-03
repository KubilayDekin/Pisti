using System.Collections.Generic;

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