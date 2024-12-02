using strange.extensions.mediation.impl;
using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class ScoreboardMediator : Mediator
	{
		[Inject] public ScoreboardView View { get; set; }
		[Inject] public ChangeGameStateSignal ChangeGameStateSignal { get; set; }

		public override void OnRegister()
		{
			base.OnRegister();

			ChangeGameStateSignal.AddListener(OnChangeGameState);
		}

		public override void OnRemove()
		{
			base.OnRemove();

			ChangeGameStateSignal.RemoveListener(OnChangeGameState);
		}

		private void OnChangeGameState(GameState gameState)
		{
			View.SetTurn(gameState);
		}

	}
}