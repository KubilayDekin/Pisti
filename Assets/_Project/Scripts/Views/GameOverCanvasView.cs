using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Pisti
{
	public class GameOverCanvasView : View
	{
		[SerializeField] private Canvas canvas;
		[SerializeField] private Button restartGameButton;

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

		internal void ShowGameOverCanvas() 
		{ 			
			canvas.enabled = true;
		}

		private void OnRestartGameButtonClicked()
		{
			restartGameSignal.Dispatch();
		}

	}
}