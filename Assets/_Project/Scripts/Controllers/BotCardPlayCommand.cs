using strange.extensions.command.impl;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Pisti
{
	public class BotCardPlayCommand : Command
	{
		[Inject] public BotPlayCardSignalData Data { get; set; }

		[Inject] public IBotHandModel BotHandModel { get; set; }
		[Inject] public ITableCardsModel TableCardsModel { get; set; }
		[Inject] public PlayCardSignal PlayCardSignal { get; set; }

		public async override void Execute()
		{
			// Wait for a random amount of time before playing a card to simulate thinking
			await Task.Delay((int)(1000 * Random.Range(Constants.botDecideDelayMin, Constants.botDecideDelayMax)));

			CardView cardToPlay = DecideCardToPlay(Data.CardViews, TableCardsModel.CardsOnTable);
			cardToPlay.SetVisibility(true);

			PlayCardSignal.Dispatch(new PlayCardSignalData(
				cardToPlay,
				CardOwner.Bot
				));
		}

		public CardView DecideCardToPlay(List<CardView> hand, List<Card> table)
		{
			// Rule 1: Attempt to make a "Pişti"
			// If there is only one card on the table and the bot has a matching card, play it.
			if (table.Count == 1)
			{
				int tableValue = table[0].CardValue;
				CardView matchingCard = hand.FirstOrDefault(card => card.cardData.CardValue == tableValue);
				if (matchingCard != null)
					return matchingCard; // Play the card to make a Pişti
			}

			// Rule 2: Capture cards if possible
			// If the bot has a card that matches any card on the table by value, play it.
			foreach (Card tableCard in table)
			{
				CardView matchingCard = hand.FirstOrDefault(card => card.cardData.CardValue == tableCard.CardValue);
				if (matchingCard != null)
					return matchingCard; // Play the card to capture
			}

			// Rule 3: Bluff by playing the lowest value card
			// If no other rules apply, play the card with the smallest value.
			return hand.OrderBy(card => card.cardData.CardValue).First();
		}
	}
}