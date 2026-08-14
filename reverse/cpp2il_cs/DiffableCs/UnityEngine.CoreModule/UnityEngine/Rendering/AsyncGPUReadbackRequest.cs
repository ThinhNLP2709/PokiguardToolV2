namespace UnityEngine.Rendering;

[NativeHeader("Runtime/Graphics/AsyncGPUReadbackManaged.h")]
[NativeHeader("Runtime/Shaders/ComputeShader.h")]
[NativeHeader("Runtime/Graphics/Texture.h")]
[UsedByNativeCode]
public struct AsyncGPUReadbackRequest
{
	internal IntPtr m_Ptr; //Field offset: 0x0
	internal int m_Version; //Field offset: 0x8

	public bool done
	{
		 get { } //Length: 51
	}

	public bool hasError
	{
		 get { } //Length: 51
	}

	public int layerCount
	{
		 get { } //Length: 51
	}

	public int layerDataSize
	{
		 get { } //Length: 51
	}

	public bool get_done() { }

	public bool get_hasError() { }

	public int get_layerCount() { }

	public int get_layerDataSize() { }

	public NativeArray<T> GetData(int layer = 0) { }

	private IntPtr GetDataRaw(int layer) { }

	private int GetLayerCount() { }

	private int GetLayerDataSize() { }

	private bool HasError() { }

	[RequiredByNativeCode]
	private static void InvokeCallback(Action<AsyncGPUReadbackRequest> callback, AsyncGPUReadbackRequest obj) { }

	private bool IsDone() { }

	internal void SetScriptingCallback(Action<AsyncGPUReadbackRequest> callback) { }

	public void WaitForCompletion() { }

}

