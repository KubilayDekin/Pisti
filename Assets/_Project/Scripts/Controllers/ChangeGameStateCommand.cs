using strange.extensions.command.impl;
using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class ChangeGameStateCommand : Command
	{
		[Inject] public GameState GameState { get; set; }
		[Inject] public IGameStateModel GameStateModel { get; set; }

		public override void Execute()
		{
			GameStateModel.GameState = GameState;
		}
	}
}