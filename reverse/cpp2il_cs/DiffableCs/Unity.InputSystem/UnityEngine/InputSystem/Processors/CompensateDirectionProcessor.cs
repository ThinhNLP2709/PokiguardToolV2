namespace UnityEngine.InputSystem.Processors;

[DesignTimeVisible(False)]
internal class CompensateDirectionProcessor : InputProcessor<Vector3>
{

	public virtual CachingPolicy cachingPolicy
	{
		 get { } //Length: 6
	}

	public CompensateDirectionProcessor() { }

	public virtual CachingPolicy get_cachingPolicy() { }

	public virtual Vector3 Process(Vector3 value, InputControl control) { }

	public virtual string ToString() { }

}

