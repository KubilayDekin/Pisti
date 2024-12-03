using strange.extensions.command.impl;
using System.Threading.Tasks;

namespace Pisti
{
	public class CollectCardsCommand : Command
	{
		[Inject] public CardOwner CardOwner { get; set; }
		[Inject] public ITableCardsModel TableCardsModel { get; set; }
		[Inject] public IPlayerHandModel PlayerHandModel { get; set; }
		[Inject] public IBotHandModel BotHandModel { get; set; }
		[Inject] public MoveCollectedCardsSignal MoveCollectedCardsSignal { get; set; }
		[Inject] public UpdatePointTextsSignal UpdatePointTextsSignal { get; set; }
		[Inject] public IGameStateModel GameStateModel { get; set; }

		public async override void Execute()
		{
			await Task.Delay((int)(1000 * Constants.waitBeforeCollectingCards));

			if (CardOwner == CardOwner.Player)
			{
				HandleCardCollection(PlayerHandModel, CardOwner.Player);
			}
			else if (CardOwner == CardOwner.Bot)
			{
				HandleCardCollection(BotHandModel, CardOwner.Bot);
			}

			GameStateModel.LastCardCollector = CardOwner;
			TableCardsModel.CardsOnTable.Clear();
		}

		private void HandleCardCollection<T>(T handModel, CardOwner cardOwner) where T : class
		{
			if (handModel is IPlayerHandModel playerModel)
			{
				foreach (Card card in TableCardsModel.CardsOnTable)
				{
					playerModel.WonCards.Add(card);
					MoveCollectedCardsSignal.Dispatch(cardOwner);
					UpdatePointTextsSignal.Dispatch(new UpdatePointTextsSignalData(cardOwner, playerModel.Points));
				}
			}
			else if (handModel is IBotHandModel botModel)
			{
				foreach (Card card in TableCardsModel.CardsOnTable)
				{
					botModel.WonCards.Add(card);
					MoveCollectedCardsSignal.Dispatch(cardOwner);
					UpdatePointTextsSignal.Dispatch(new UpdatePointTextsSignalData(cardOwner, botModel.Points));
				}
			}
		}
	}
}