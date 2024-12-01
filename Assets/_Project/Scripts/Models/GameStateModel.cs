using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class GameStateModel : IGameStateModel
	{
		public GameState GameState { get; set; }
		public GameState LastPlayerState { get; set; }
	}
}