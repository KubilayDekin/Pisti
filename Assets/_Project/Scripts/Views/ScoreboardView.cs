﻿using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pisti
{
	public class ScoreboardView : View
	{
		[Header("Settings")]
		[SerializeField] private GameState targetTurn;
		[SerializeField] private Color playingBackgroundColor;
		[SerializeField] private Color waitingBackgroundColor;

		[Header("References")]
		[SerializeField] private Image scoreboardBackgroundImage;
		[SerializeField] private TextMeshProUGUI scoreText;

		public void SetTurn(GameState gameState)
		{
			if(gameState == targetTurn)
			{
				scoreboardBackgroundImage.color = playingBackgroundColor;
			}
			else
			{
				scoreboardBackgroundImage.color = waitingBackgroundColor;
			}
		}

		public void SetScoreText(CardOwner cardOwner, int score)
		{
			if(cardOwner == CardOwner.Player && targetTurn == GameState.PlayerTurn)
			{
				scoreText.text = score.ToString();
			}
			else if(cardOwner == CardOwner.Bot && targetTurn == GameState.BotTurn)
			{
				scoreText.text = score.ToString();
			}
		}
	}
}