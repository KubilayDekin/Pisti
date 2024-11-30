using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pisti
{
	public class GameplayContext : SignalContext
	{
		public GameplayContext(MonoBehaviour view) : base(view)
		{
		}

		protected override void mapBindings()
		{
			base.mapBindings();
		}
	}
}

