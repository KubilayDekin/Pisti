using strange.extensions.mediation.impl;
using System.Collections;
using UnityEngine;

namespace Pisti
{
	public class BotHandMediator : Mediator
	{
		[Inject] public BotHandView View { get; set; }

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