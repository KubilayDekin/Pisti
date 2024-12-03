using strange.extensions.mediation.impl;

namespace Pisti
{
	public class GameOverCanvasMediator : Mediator
	{
		[Inject] public GameOverCanvasView View { get; set; }
		[Inject] public GameOverSignal GameOverSignal { get; set; }
		[Inject] public RestartGameSignal RestartGameSignal { get; set; }

		public override void OnRegister()
		{
			base.OnRegister();

			View.restartGameSignal.AddListener(RestartGame);
			GameOverSignal.AddListener(ShowGameOverCanvas);
		}

		public override void OnRemove()
		{
			base.OnRemove();

			View.restartGameSignal.RemoveListener(RestartGame);
			GameOverSignal.RemoveListener(ShowGameOverCanvas);
		}

		private void RestartGame()
		{
			RestartGameSignal.Dispatch();
		}

		private void ShowGameOverCanvas(GameOverSignalData data)
		{
			View.ShowGameOverCanvas(data.PlayerPoints, data.BotPoints);
		}
	}
}