using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pisti
{
	public interface IDeckModel
	{
		public List<Card> Cards { get; set; }
	}
}