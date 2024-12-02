using DG.Tweening;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pisti
{
	public class CardView : View
	{
		[Header("References")]
		[SerializeField] private Image cardImage;
		[SerializeField] private TextMeshProUGUI cardValueText;
		[SerializeField] private Sprite backOfCard;
		[SerializeField] private Button playCardButton;

		[Header("Settings")]
		[SerializeField] private Color redTextColor;
		[SerializeField] private Color blackTextColor;

		[HideInInspector] public Card cardData;

		internal Signal onCardTapped = new Signal();
		internal Signal cardReachedToTableSignal = new Signal();

		protected override void OnEnable()
		{
			base.OnEnable();

			playCardButton.onClick.AddListener(OnPlayCardButtonClick);
		}

		protected override void OnDisable()
		{
			base.OnDisable();

			playCardButton.onClick.RemoveListener(OnPlayCardButtonClick);
		}

		public void InitializeCardView(Card cardData)
		{
			this.cardData = cardData;
			cardImage.sprite = cardData.CardSprite;
			cardValueText.text = cardData.CardValueText;

			if(cardData.CardSuit == Constants.Diamonds || cardData.CardSuit == Constants.Hearts)
			{
				cardValueText.color = redTextColor;
			}
			else
			{
				cardValueText.color = blackTextColor;
			}
		}

		public void SetVisibility(bool isVisible)
		{
			cardValueText.gameObject.SetActive(isVisible);
			cardImage.sprite = isVisible ? cardData.CardSprite : backOfCard;
		}

		public void SetCardInteractability(CardOwner cardOwner)
		{
			playCardButton.interactable = cardOwner == CardOwner.Player;
		}

		public void MoveToTheHand(Transform targetTransform)
		{
			transform.DOMove(targetTransform.position, Constants.cardToHandDuration).SetEase(Ease.Linear).OnComplete(() => transform.parent = targetTransform);
		}

		public void MoveToTheTable(Transform targetTransform)
		{
			Vector3 targetTablePosition = new Vector3(
				targetTransform.position.x + Random.Range(-Constants.tableCardRandomXRange,Constants.tableCardRandomXRange),
				targetTransform.position.y + Random.Range(-Constants.tableCardRandomYRange,Constants.tableCardRandomYRange),
				targetTransform.position.z);

			transform.DOMove(targetTablePosition, Constants.cardToTableDuration).SetEase(Ease.Linear).OnComplete(() =>
			{
				HandleCardMovedToTheTable(targetTransform);
			});
		}

		public void MoveToWonPoint(Transform targetTransform)
		{
			transform.DOMove(targetTransform.position, Constants.wonCardMoveDuration).SetEase(Ease.Linear).OnComplete(() => Destroy(gameObject));
		}

		private void HandleCardMovedToTheTable(Transform targetTransform)
		{
			transform.parent = targetTransform;
			cardReachedToTableSignal.Dispatch();
		}

		private void OnPlayCardButtonClick()
		{
			onCardTapped.Dispatch();
		}
	}
}


