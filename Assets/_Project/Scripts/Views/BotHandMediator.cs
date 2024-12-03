using strange.extensions.mediation.impl;
using System.Collections.Generic;
using UnityEngine;

namespace Pisti
{
	public class BotHandMediator : Mediator
	{
		[Inject] public BotHandView View { get; set; }
		[Inject] public ChangeGameStateSignal ChangeGameStateSignal { get; set; }
		[Inject] public BotPlayCardSignal BotPlayCardSignal { get; set; }

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
			if(gameState == GameState.BotTurn)
			{
				List<CardView> botCards = new List<CardView>();

				foreach(Transform card in View.transform)
				{
					botCards.Add(card.GetComponent<CardView>());
				}

				BotPlayCardSignal.Dispatch(new BotPlayCardSignalData(botCards));
			}
		}
	}
}