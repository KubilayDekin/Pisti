using strange.extensions.mediation.impl;
using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class CardDistributorMediator : Mediator
	{
		[Inject] public CardDistributorView View { get; set; }
		[Inject] public DistributeCardSignal DistributeCardSignal { get; set; }
		[Inject] public SendCardToTableSignal SendCardToTableSignal { get; set; }

		public override void OnRegister()
		{
			base.OnRegister();

			DistributeCardSignal.AddListener(DistributeCard);
			SendCardToTableSignal.AddListener(SendCardToTable);
		}

		public override void OnRemove()
		{
			base.OnRemove();

			DistributeCardSignal.RemoveListener(DistributeCard);
			SendCardToTableSignal.RemoveListener(SendCardToTable);
		}

		private void DistributeCard(DistributeCardSignalData data)
		{
			View.DistributeCard(data.Card, data.CardOwner, data.IsVisible);
		}

		private void SendCardToTable(CardView cardView)
		{
			View.SendCardToTable(cardView);
		}
	}
}