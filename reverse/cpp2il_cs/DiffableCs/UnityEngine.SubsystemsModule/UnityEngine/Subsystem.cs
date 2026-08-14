namespace UnityEngine;

[Obsolete("Use SubsystemWithProvider instead.", False)]
public abstract class Subsystem : ISubsystem
{

	public abstract bool running
	{
		 get { } //Length: 0
	}

	protected Subsystem() { }

	public override void Destroy() { }

	public abstract bool get_running() { }

	protected abstract void OnDestroy() { }

	public abstract void Start() { }

	public abstract void Stop() { }

}

