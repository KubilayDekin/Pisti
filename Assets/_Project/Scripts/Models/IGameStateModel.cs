namespace Pisti
{
	public interface IGameStateModel
	{
		public GameState GameState { get; set; }
		public GameState LastPlayerState { get; set; }
		public CardOwner LastCardCollector { get; set; }
	}
}

public enum GameState
{
	Beginning,
	PlayerTurn,
	BotTurn,
	OnHold,
	DealCards,
	GameOver
}