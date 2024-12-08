﻿namespace Pisti
{
	public static class Constants
	{
		#region Times And Durations

		public static float cardDistributeDelay = 0.25f;
		public static float waitBeforeTurnStart = 0.25f;
		public static float cardToTableDuration = 0.3f;
		public static float cardToHandDuration = 0.3f;
		public static float wonCardMoveDuration = 0.3f;
		public static float botDecideDelayMin = 0.25f;
		public static float botDecideDelayMax = 0.65f;
		public static float waitBeforeCollectingCards = 0.5f;

		#endregion

		#region Random Values
		public static float tableCardRandomXRange = 65f;
		public static float tableCardRandomYRange = 65f;
		#endregion

		#region Deck

		public static int[] values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }; // 1 is Ace, 11 is Jack, 12 is Queen, 13 is King
		public static string[] suits = new string[] { Constants.Spades, Constants.Hearts, Constants.Clubs, Constants.Diamonds };
		
		#endregion

		#region Card Values

		public const string Jack = "Jack";
		public const string Queen = "Queen";
		public const string King = "King";
		public const string Ace = "Ace";

		#endregion

		#region Card Suits

		public const string Spades = "Spades";
		public const string Hearts = "Hearts";
		public const string Clubs = "Clubs";
		public const string Diamonds = "Diamonds";

		#endregion
	}
}