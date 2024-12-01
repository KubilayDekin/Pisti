using strange.extensions.command.impl;
using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class CollectCardsCommand : Command
	{
		[Inject] public CardOwner CardOwner { get; set; }
		[Inject] public ITableCardsModel TableCardsModel { get; set; }
		[Inject] public IPlayerHandModel PlayerHandModel { get; set; }
		[Inject] public IBotHandModel BotHandModel { get; set; }
		[Inject] public MoveCollectedCardsSignal MoveCollectedCardsSignal { get; set; }

		public override void Execute()
		{
			if(CardOwner == CardOwner.Player)
			{
				foreach(Card card in TableCardsModel.CardsOnTable)
				{
					PlayerHandModel.WonCards.Add(card);
					MoveCollectedCardsSignal.Dispatch(CardOwner.Player);
				}
			}
			else
			{
				foreach (Card card in TableCardsModel.CardsOnTable)
				{
					BotHandModel.WonCards.Add(card);
					MoveCollectedCardsSignal.Dispatch(CardOwner.Bot);
				}
			}
		}
	}
}