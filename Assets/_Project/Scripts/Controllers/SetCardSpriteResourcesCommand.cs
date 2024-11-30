using strange.extensions.command.impl;
using UnityEngine;

namespace Pisti
{
	public class SetCardSpriteResourcesCommand : Command
	{
		[Inject] public ICardVisualsModel CardVisualsModel { get; set; }

		public override void Execute()
		{
			CardSprites cardSprites = Resources.Load<CardSprites>("CardSprites");

			CardVisualsModel.SetCardSprites(cardSprites);
		}
	}
}