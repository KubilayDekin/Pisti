﻿using strange.extensions.command.impl;
using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class PlayCardCommand : Command
	{
		[Inject] public PlayCardSignalData Data { get; set; }
		[Inject] public IGameStateModel GameStateModel { get; set; }
		[Inject] public ChangeGameStateSignal ChangeGameStateSignal { get; set; }
		[Inject] public IPistiService PistiService { get; set; }
		[Inject] public SendCardToTableSignal SendCardToTableSignal { get; set; }
		[Inject] public CardReachedToTableSignal CardReachedToTableSignal { get; set; }

		public override void Execute()
		{
			if(Data.CardOwner == CardOwner.Player && GameStateModel.GameState == GameState.PlayerTurn)
			{
				GameStateModel.LastPlayerState = GameState.PlayerTurn;
				ChangeGameStateSignal.Dispatch(GameState.OnHold);

				SendCardToTableSignal.Dispatch(Data.CardView);

				CardReachedToTableSignal.AddListener(() => OnCardReachedToTable());
			}
			else if(Data.CardOwner == CardOwner.Bot && GameStateModel.GameState == GameState.BotTurn)
			{
				GameStateModel.LastPlayerState = GameState.BotTurn;
				ChangeGameStateSignal.Dispatch(GameState.OnHold);

				SendCardToTableSignal.Dispatch(Data.CardView);

				CardReachedToTableSignal.AddListener(() => OnCardReachedToTable());
			}
		}

		private void OnCardReachedToTable()
		{
			PistiService.HandleCardPlayed(Data.CardView.cardData);
		}
	}
}