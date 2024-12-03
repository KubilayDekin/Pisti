using strange.extensions.mediation.impl;

namespace Pisti
{
	public class CardDistributorMediator : Mediator
	{
		[Inject] public CardDistributorView View { get; set; }
		[Inject] public DistributeCardSignal DistributeCardSignal { get; set; }
		[Inject] public SendCardToTableSignal SendCardToTableSignal { get; set; }
		[Inject] public MoveCollectedCardsSignal MoveCollectedCardsSignal { get; set; }
		[Inject] public CardsCollectedSignal CardsCollectedSignal { get; set; }

		public override void OnRegister()
		{
			base.OnRegister();

			DistributeCardSignal.AddListener(DistributeCard);
			SendCardToTableSignal.AddListener(SendCardToTable);
			MoveCollectedCardsSignal.AddListener(MoveCollectedCards);
			View.onWonCardsMovementCompleted.AddListener(HandleCollectedCardsMovementCompleted);
		}

		public override void OnRemove()
		{
			base.OnRemove();

			DistributeCardSignal.RemoveListener(DistributeCard);
			SendCardToTableSignal.RemoveListener(SendCardToTable);
			MoveCollectedCardsSignal.RemoveListener(MoveCollectedCards);
			View.onWonCardsMovementCompleted.RemoveListener(HandleCollectedCardsMovementCompleted);
		}

		private void DistributeCard(DistributeCardSignalData data)
		{
			View.DistributeCard(data.Card, data.CardOwner, data.IsVisible);
		}

		private void SendCardToTable(CardView cardView)
		{
			View.SendCardToTable(cardView);
		}

		private void MoveCollectedCards(CardOwner cardOwner)
		{
			View.SendWonCardsToPlayer(cardOwner);
		}

		private void HandleCollectedCardsMovementCompleted()
		{
			CardsCollectedSignal.Dispatch();
		}
	}
}