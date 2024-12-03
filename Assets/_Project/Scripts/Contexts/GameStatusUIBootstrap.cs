using strange.extensions.context.impl;

namespace Pisti
{
	public class GameStatusUIBootstrap : ContextView
	{
		void Awake() //TODO: DOCUMENT SAYS THIS SHOULD BE START METHOD. HOWEVER, THIS SOLVES CONTEXT NOT FOUND PROBLEM ON START-UP. 
		{
			context = new GameStatusUIContext(this);
		}
	}
}