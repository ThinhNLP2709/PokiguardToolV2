namespace UnityEngine.Rendering;

[NativeHeader("Runtime/Graphics/AsyncGPUReadbackManaged.h")]
[UsedByNativeCode]
internal struct AsyncRequestNativeArrayData
{
	public Void* nativeArrayBuffer; //Field offset: 0x0
	public long lengthInBytes; //Field offset: 0x8

	public static AsyncRequestNativeArrayData CreateAndCheckAccess(NativeArray<T> array) { }

}

