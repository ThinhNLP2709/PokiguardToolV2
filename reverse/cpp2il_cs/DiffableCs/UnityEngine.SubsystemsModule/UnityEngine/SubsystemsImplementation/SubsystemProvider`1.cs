namespace UnityEngine.SubsystemsImplementation;

public abstract class SubsystemProvider : SubsystemProvider
{

	protected SubsystemProvider`1() { }

	public abstract void Destroy() { }

	public abstract void Start() { }

	public abstract void Stop() { }

	protected private override bool TryInitialize() { }

}

