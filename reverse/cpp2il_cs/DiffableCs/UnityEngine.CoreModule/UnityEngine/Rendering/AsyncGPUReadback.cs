namespace UnityEngine.Rendering;

[StaticAccessor("AsyncGPUReadbackManager::GetInstance()", StaticAccessorType::Dot (0))]
public static class AsyncGPUReadback
{

	public static AsyncGPUReadbackRequest Request(GraphicsBuffer src, Action<AsyncGPUReadbackRequest> callback = null) { }

	public static AsyncGPUReadbackRequest Request(GraphicsBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback = null) { }

	[NativeMethod("Request")]
	private static AsyncGPUReadbackRequest Request_Internal_GraphicsBuffer_1(GraphicsBuffer buffer, AsyncRequestNativeArrayData* data) { }

	private static void Request_Internal_GraphicsBuffer_1_Injected(IntPtr buffer, AsyncRequestNativeArrayData* data, out AsyncGPUReadbackRequest ret) { }

	[NativeMethod("Request")]
	private static AsyncGPUReadbackRequest Request_Internal_GraphicsBuffer_2(GraphicsBuffer src, int size, int offset, AsyncRequestNativeArrayData* data) { }

	private static void Request_Internal_GraphicsBuffer_2_Injected(IntPtr src, int size, int offset, AsyncRequestNativeArrayData* data, out AsyncGPUReadbackRequest ret) { }

}

