using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pisti
{
	public class DeckModel : IDeckModel
	{
		public List<Card> Cards { get; set; } = new List<Card>();
	}
}