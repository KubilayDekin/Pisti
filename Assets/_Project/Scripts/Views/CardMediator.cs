using strange.extensions.mediation.impl;
using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class CardMediator : Mediator
	{		
		[Inject] public CardView View { get; set; }
		[Inject] public PlayCardSignal PlayCardSignal { get; set; }
		[Inject] public CardReachedToTableSignal CardReachedToTableSignal { get; set; }
		
		public override void OnRegister()
		{
			base.OnRegister();

			View.onCardTapped.AddListener(TryPlayCard);
			View.cardReachedToTableSignal.AddListener(OnCardReachedToTable);
		}

		public override void OnRemove()
		{
			base.OnRemove();

			View.onCardTapped.RemoveListener(TryPlayCard);
			View.cardReachedToTableSignal.RemoveListener(OnCardReachedToTable);
		}

		private void TryPlayCard()
		{
			PlayCardSignal.Dispatch(new PlayCardSignalData(View, CardOwner.Player));
		}

		private void OnCardReachedToTable()
		{
			CardReachedToTableSignal.Dispatch();
		}
	}
}