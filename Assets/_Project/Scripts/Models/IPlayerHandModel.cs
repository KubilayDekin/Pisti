using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pisti
{
	public interface IPlayerHandModel
	{
		public List<Card> Cards { get; set; }
		public void AddCard(Card card);
		public void RemoveCard(Card card);
	}
}