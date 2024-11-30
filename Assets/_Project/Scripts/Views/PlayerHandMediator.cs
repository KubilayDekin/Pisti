using strange.extensions.mediation.impl;
using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class PlayerHandMediator : Mediator
	{
		[Inject] public PlayerHandView View { get; set; }
		[Inject] public SendCardToPlayerSignal SendCardToPlayerSignal { get; set; }

		public override void OnRegister()
		{
			base.OnRegister();
		}

		public override void OnRemove()
		{
			base.OnRemove();
		}
	}
}