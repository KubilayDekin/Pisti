using strange.extensions.command.impl;

namespace Pisti
{
	public class DealCardsAtStartCommand : Command
	{
		[Inject] public IDeckService DeckService { get; set; }
		[Inject] public DistributeCardSignal DistributeCardSignal { get; set; }

		public override void Execute()
		{
			DistributeCardSignal.Dispatch(new DistributeCardSignalData(DeckService.DrawCard(), true));
		}
	}
}