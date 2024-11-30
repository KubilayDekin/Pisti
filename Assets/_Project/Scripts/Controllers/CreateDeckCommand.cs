using strange.extensions.command.impl;

namespace Pisti
{
	public class CreateDeckCommand : Command
	{
		[Inject] public IDeckService DeckService { get; set; }

		public override void Execute()
		{
			DeckService.CreateDeck();
			DeckService.ShuffleDeck();
		}
	}
}
