using strange.extensions.command.impl;
using System.Threading.Tasks;

namespace Pisti
{
	public class DealCardsCommand : Command
	{
		[Inject] public IDeckService DeckService { get; set; }
		[Inject] public DistributeCardSignal DistributeCardSignal { get; set; }
		[Inject] public ChangeGameStateSignal ChangeGameStateSignal { get; set; }
		[Inject] public IPlayerHandModel PlayerHandModel { get; set; }
		[Inject] public IBotHandModel BotHandModel { get; set; }

		public async override void Execute()
		{
			Retain();

			ChangeGameStateSignal.Dispatch(GameState.DealCards);

			await DistributeCards(CardOwner.Player, 4);
			await DistributeCards(CardOwner.Bot, 4);

			await Task.Delay((int)(Constants.waitBeforeTurnStart * 1000));

			ChangeGameStateSignal.Dispatch(GameState.PlayerTurn);

			Release();
		}

		private async Task DistributeCards(CardOwner owner, int count)
		{
			for (int i = 0; i < count; i++)
			{
				bool isVisible = owner == CardOwner.Player;

				Card drawedCard = DeckService.DrawCard();

				if (owner == CardOwner.Player)
					PlayerHandModel.AddCard(drawedCard);
				else if (owner == CardOwner.Bot)
					BotHandModel.AddCard(drawedCard);

				DistributeCardSignal.Dispatch(new DistributeCardSignalData(drawedCard, owner, isVisible));
				await Task.Delay((int)(Constants.cardDistributeDelay * 1000));
			}
		}
	}
}