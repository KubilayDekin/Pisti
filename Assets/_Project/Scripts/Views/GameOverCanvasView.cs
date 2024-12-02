using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pisti
{
	public class GameOverCanvasView : View
	{
		[SerializeField] private Canvas canvas;
		[SerializeField] private Button restartGameButton;
		[SerializeField] private TextMeshProUGUI playerPointsText;
		[SerializeField] private TextMeshProUGUI botPointsText;

		internal Signal restartGameSignal = new Signal();

		protected override void OnEnable()
		{
			base.OnEnable();
			restartGameButton.onClick.AddListener(OnRestartGameButtonClicked);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			restartGameButton.onClick.RemoveListener(OnRestartGameButtonClicked);
		}

		internal void ShowGameOverCanvas(int playerPoints, int botPoints) 
		{ 			
			playerPointsText.text = playerPoints.ToString();
			botPointsText.text = botPoints.ToString();

			canvas.enabled = true;
		}

		private void OnRestartGameButtonClicked()
		{
			restartGameSignal.Dispatch();
		}

	}
}