using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class GameOverSignalData : MonoBehaviour
	{
		public int PlayerPoints { get; set; }
		public int BotPoints { get; set; }

		public GameOverSignalData(int playerPoints, int botPoints)
		{
			PlayerPoints = playerPoints;
			BotPoints = botPoints;
		}
	}
}