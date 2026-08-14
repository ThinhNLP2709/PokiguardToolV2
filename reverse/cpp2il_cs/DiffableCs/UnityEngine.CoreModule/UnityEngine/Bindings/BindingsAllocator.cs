namespace UnityEngine.Bindings;

[NativeHeader("Runtime/Scripting/Marshalling/BindingsAllocator.h")]
[StaticAccessor("Marshalling::BindingsAllocator", StaticAccessorType::DoubleColon (2))]
[VisibleToOtherModules]
internal static class BindingsAllocator
{
	private struct NativeOwnedMemory
	{
		public Void* data; //Field offset: 0x0

	}


	[ThreadSafe]
	public static void Free(Void* ptr) { }

	[ThreadSafe]
	public static void FreeNativeOwnedMemory(Void* ptr) { }

	public static Void* GetNativeOwnedDataPointer(Void* ptr) { }

}

