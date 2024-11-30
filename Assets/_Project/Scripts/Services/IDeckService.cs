using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pisti
{
	public interface IDeckService
	{
		public void CreateDeck();
		public void ShuffleDeck();
		public Card DrawCard();
	}
}

