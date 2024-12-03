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

			if(CardOwner == CardOwner.Player)
			{
				foreach(Card card in TableCardsModel.CardsOnTable)
				{
					PlayerHandModel.WonCards.Add(card);
					MoveCollectedCardsSignal.Dispatch(CardOwner.Player);
					UpdatePointTextsSignal.Dispatch(new UpdatePointTextsSignalData(CardOwner.Player, PlayerHandModel.Points));
				}
			}
			else
			{
				foreach (Card card in TableCardsModel.CardsOnTable)
				{
					BotHandModel.WonCards.Add(card);
					MoveCollectedCardsSignal.Dispatch(CardOwner.Bot);
					UpdatePointTextsSignal.Dispatch(new UpdatePointTextsSignalData(CardOwner.Bot, BotHandModel.Points));
				}
			}

			GameStateModel.LastCardCollector = CardOwner;
			TableCardsModel.CardsOnTable.Clear();
		}
	}
}