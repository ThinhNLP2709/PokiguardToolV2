namespace UnityEngine;

[NativeHeader("Runtime/Mono/Coroutine.h")]
[RequiredByNativeCode]
public sealed class Coroutine : YieldInstruction
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(Coroutine coroutine) { }

	}

	internal IntPtr m_Ptr; //Field offset: 0x10

	private Coroutine() { }

	protected virtual void Finalize() { }

	[FreeFunction("Coroutine::CleanupCoroutineGC", True)]
	private static void ReleaseCoroutine(IntPtr ptr) { }

}

