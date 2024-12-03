using System.Collections.Generic;

namespace Pisti
{
	public class DeckModel : IDeckModel
	{
		public List<Card> Cards { get; set; } = new List<Card>();
	}
}