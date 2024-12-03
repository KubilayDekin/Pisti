namespace Pisti
{
	public interface IDeckService
	{
		public void CreateDeck();
		public void ShuffleDeck();
		public Card DrawCard();
	}
}

