using strange.extensions.mediation.impl;

namespace Pisti
{
	public class ScoreboardMediator : Mediator
	{
		[Inject] public ScoreboardView View { get; set; }
		[Inject] public ChangeGameStateSignal ChangeGameStateSignal { get; set; }
		[Inject] public UpdatePointTextsSignal UpdatePointTextsSignal { get; set; }

		public override void OnRegister()
		{
			base.OnRegister();

			ChangeGameStateSignal.AddListener(OnChangeGameState);
			UpdatePointTextsSignal.AddListener(UpdatePointTexts);
		}

		public override void OnRemove()
		{
			base.OnRemove();

			ChangeGameStateSignal.RemoveListener(OnChangeGameState);
			UpdatePointTextsSignal.RemoveListener(UpdatePointTexts);
		}

		private void OnChangeGameState(GameState gameState)
		{
			View.SetTurn(gameState);
		}

		private void UpdatePointTexts(UpdatePointTextsSignalData data)
		{
			View.SetScoreText(data.CardOwner, data.Points);
		}
	}
}