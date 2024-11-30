using strange.extensions.mediation.impl;
using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class CardDistributorMediator : Mediator
	{
		[Inject] public CardDistributorView View { get; set; }
		[Inject] public DistributeCardSignal DistributeCardSignal { get; set; }

		public override void OnRegister()
		{
			base.OnRegister();

			DistributeCardSignal.AddListener(DistributeCard);
		}

		public override void OnRemove()
		{
			base.OnRemove();

			DistributeCardSignal.RemoveListener(DistributeCard);
		}

		private void DistributeCard(DistributeCardSignalData data)
		{
			View.DistributeCard(data.Card, data.CardOwner, data.IsVisible);
		}
	}
}