using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

public class SignalContext : MVCSContext
{

	public SignalContext(MonoBehaviour view) : base(view)
	{
	}

	public SignalContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
	{
	}

	// Unbind the default EventCommandBinder and rebind the SignalCommandBinder
	protected override void addCoreComponents()
	{
		base.addCoreComponents();
		injectionBinder.Unbind<ICommandBinder>();
		injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
	}

	protected override void mapBindings()
	{

	}
}