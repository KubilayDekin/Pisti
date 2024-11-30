using System.Collections;
using UnityEngine;

namespace Pisti
{
	public interface ICard
	{
		public int CardValue { get; set; }
		public string CardSuit { get; set; }
		public Sprite CardSprite { get; set; }
		public string CardValueText { get; set; }
	}
}