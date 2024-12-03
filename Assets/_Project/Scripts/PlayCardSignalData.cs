namespace Pisti
{
	public class PlayCardSignalData
	{
		public CardView CardView { get; set; }
		public CardOwner CardOwner { get; set; }

		public PlayCardSignalData(CardView cardView, CardOwner cardOwner)
		{
			CardView = cardView;
			CardOwner = cardOwner;
		}
	}
}