namespace UnityEngine;

[NativeHeader("Runtime/Export/Graphics/GraphicsBuffer.bindings.h")]
[NativeHeader("Runtime/Shaders/GraphicsBuffer.h")]
[UsedByNativeCode]
public sealed class GraphicsBuffer : IDisposable
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(GraphicsBuffer graphicsBuffer) { }

	}

	[Flags]
	internal enum Target
	{
		Vertex = 1,
		Index = 2,
		CopySource = 4,
		CopyDestination = 8,
		Structured = 16,
		Raw = 32,
		Append = 64,
		Counter = 128,
		IndirectArguments = 256,
		Constant = 512,
	}

	[Flags]
	internal enum UsageFlags
	{
		None = 0,
		LockBufferForWrite = 1,
	}

	internal IntPtr m_Ptr; //Field offset: 0x10

	public GraphicsBufferHandle bufferHandle
	{
		 get { } //Length: 98
	}

	public int count
	{
		 get { } //Length: 81
	}

	public string name
	{
		 set { } //Length: 8
	}

	public int stride
	{
		 get { } //Length: 81
	}

	public UsageFlags usageFlags
	{
		 get { } //Length: 81
	}

	public GraphicsBuffer(Target target, UsageFlags usageFlags, int count, int stride) { }

	public GraphicsBuffer(Target target, int count, int stride) { }

	private Void* BeginBufferWrite(int offset = 0, int size = 0) { }

	private static Void* BeginBufferWrite_Injected(IntPtr _unity_self, int offset, int size) { }

	[FreeFunction("GraphicsBuffer_Bindings::DestroyBuffer")]
	private static void DestroyBuffer(GraphicsBuffer buf) { }

	private static void DestroyBuffer_Injected(IntPtr buf) { }

	public override void Dispose() { }

	private void Dispose(bool disposing) { }

	private void EndBufferWrite(int bytesWritten = 0) { }

	private static void EndBufferWrite_Injected(IntPtr _unity_self, int bytesWritten) { }

	protected virtual void Finalize() { }

	public GraphicsBufferHandle get_bufferHandle() { }

	private static void get_bufferHandle_Injected(IntPtr _unity_self, out GraphicsBufferHandle ret) { }

	public int get_count() { }

	private static int get_count_Injected(IntPtr _unity_self) { }

	public int get_stride() { }

	private static int get_stride_Injected(IntPtr _unity_self) { }

	public UsageFlags get_usageFlags() { }

	[FreeFunction(Name = "GraphicsBuffer_Bindings::GetUsageFlags", HasExplicitThis = True)]
	private UsageFlags GetUsageFlags() { }

	private static UsageFlags GetUsageFlags_Injected(IntPtr _unity_self) { }

	[FreeFunction("GraphicsBuffer_Bindings::InitBuffer")]
	private static IntPtr InitBuffer(Target target, UsageFlags usageFlags, int count, int stride) { }

	private void InternalInitialization(Target target, UsageFlags usageFlags, int count, int stride) { }

	[FreeFunction(Name = "GraphicsBuffer_Bindings::InternalSetData", HasExplicitThis = True, ThrowsException = True)]
	private void InternalSetData(Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize) { }

	private static void InternalSetData_Injected(IntPtr _unity_self, Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize) { }

	[FreeFunction(Name = "GraphicsBuffer_Bindings::InternalSetNativeData", HasExplicitThis = True, ThrowsException = True)]
	private void InternalSetNativeData(IntPtr data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize) { }

	private static void InternalSetNativeData_Injected(IntPtr _unity_self, IntPtr data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize) { }

	public bool IsValid() { }

	[FreeFunction("GraphicsBuffer_Bindings::IsValidBuffer")]
	private static bool IsValidBuffer(GraphicsBuffer buf) { }

	private static bool IsValidBuffer_Injected(IntPtr buf) { }

	private static bool IsVertexIndexOrCopyOnly(Target target) { }

	public NativeArray<T> LockBufferForWrite(int bufferStartIndex, int count) { }

	public void Release() { }

	private static bool RequiresCompute(Target target) { }

	public void set_name(string value) { }

	public void SetData(Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count) { }

	public void SetData(NativeArray<T> data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count) { }

	public void SetData(NativeArray<T> data) { }

	[FreeFunction(Name = "GraphicsBuffer_Bindings::SetName", HasExplicitThis = True)]
	private void SetName(string name) { }

	private static void SetName_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name) { }

	public void UnlockBufferAfterWrite(int countWritten) { }

}

