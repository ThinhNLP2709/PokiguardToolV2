namespace UnityEngine.InputSystem;

public abstract class InputProcessor
{
	internal enum CachingPolicy
	{
		CacheResult = 0,
		EvaluateOnEveryRead = 1,
	}

	internal static TypeTable s_Processors; //Field offset: 0x0

	public override CachingPolicy cachingPolicy
	{
		 get { } //Length: 3
	}

	protected InputProcessor() { }

	public override CachingPolicy get_cachingPolicy() { }

	internal static Type GetValueTypeFromType(Type processorType) { }

	public abstract void Process(Void* buffer, int bufferSize, InputControl control) { }

	public abstract object ProcessAsObject(object value, InputControl control) { }

}

