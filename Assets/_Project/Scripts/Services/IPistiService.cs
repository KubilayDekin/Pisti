using System.Collections;
using UnityEngine;

namespace Pisti
{
	public interface IPistiService
	{
		public void HandleCardPlayed(Card playedCard);
		public bool CheckPisti(Card playedCard);
		public bool CheckMatch(Card playedCard);
	}
}