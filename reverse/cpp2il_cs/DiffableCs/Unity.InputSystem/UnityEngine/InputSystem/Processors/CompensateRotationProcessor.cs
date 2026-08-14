namespace UnityEngine.InputSystem.Processors;

[DesignTimeVisible(False)]
internal class CompensateRotationProcessor : InputProcessor<Quaternion>
{

	public virtual CachingPolicy cachingPolicy
	{
		 get { } //Length: 6
	}

	public CompensateRotationProcessor() { }

	public virtual CachingPolicy get_cachingPolicy() { }

	public virtual Quaternion Process(Quaternion value, InputControl control) { }

	public virtual string ToString() { }

}

