namespace UnityEngine;

[NativeClass("GraphicsBuffer")]
[NativeHeader("Runtime/Shaders/GraphicsBuffer.h")]
[NativeHeader("Runtime/Export/Graphics/GraphicsBuffer.bindings.h")]
[UsedByNativeCode]
public sealed class ComputeBuffer : IDisposable
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(ComputeBuffer computeBuffer) { }

	}

	internal IntPtr m_Ptr; //Field offset: 0x10

	public int count
	{
		 get { } //Length: 82
	}

	public int stride
	{
		 get { } //Length: 82
	}

	public ComputeBuffer(int count, int stride) { }

	public ComputeBuffer(int count, int stride, ComputeBufferType type) { }

	private ComputeBuffer(int count, int stride, ComputeBufferType type, ComputeBufferMode usage, int stackDepth) { }

	[FreeFunction("GraphicsBuffer_Bindings::DestroyComputeBuffer")]
	private static void DestroyBuffer(ComputeBuffer buf) { }

	private static void DestroyBuffer_Injected(IntPtr buf) { }

	public override void Dispose() { }

	private void Dispose(bool disposing) { }

	protected virtual void Finalize() { }

	public int get_count() { }

	private static int get_count_Injected(IntPtr _unity_self) { }

	public int get_stride() { }

	private static int get_stride_Injected(IntPtr _unity_self) { }

	[FreeFunction("GraphicsBuffer_Bindings::InitComputeBuffer")]
	private static IntPtr InitBuffer(int count, int stride, ComputeBufferType type, ComputeBufferMode usage) { }

	[FreeFunction(Name = "GraphicsBuffer_Bindings::InternalSetData", HasExplicitThis = True, ThrowsException = True)]
	private void InternalSetData(Array data, int managedBufferStartIndex, int computeBufferStartIndex, int count, int elemSize) { }

	private static void InternalSetData_Injected(IntPtr _unity_self, Array data, int managedBufferStartIndex, int computeBufferStartIndex, int count, int elemSize) { }

	[FreeFunction(Name = "GraphicsBuffer_Bindings::InternalSetNativeData", HasExplicitThis = True, ThrowsException = True)]
	private void InternalSetNativeData(IntPtr data, int nativeBufferStartIndex, int computeBufferStartIndex, int count, int elemSize) { }

	private static void InternalSetNativeData_Injected(IntPtr _unity_self, IntPtr data, int nativeBufferStartIndex, int computeBufferStartIndex, int count, int elemSize) { }

	public bool IsValid() { }

	[FreeFunction("GraphicsBuffer_Bindings::IsValidBuffer")]
	private static bool IsValidBuffer(ComputeBuffer buf) { }

	private static bool IsValidBuffer_Injected(IntPtr buf) { }

	public void Release() { }

	public void SetData(Array data) { }

	public void SetData(NativeArray<T> data) { }

	public void SetData(NativeArray<T> data, int nativeBufferStartIndex, int computeBufferStartIndex, int count) { }

}

