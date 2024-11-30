using System.Collections;
using UnityEngine;

namespace Pisti
{
	public interface IGameStateModel
	{
		public GameState GameState { get; set; }
	}
}

public enum GameState
{
	Beginning,
	PlayerTurn,
	BotTurn,
	DealCards,
	GameOver
}