namespace UnityEngine.Rendering;

public sealed class ShaderDebugPrintManager
{
	private enum DebugValueType
	{
		TypeUint = 1,
		TypeInt = 2,
		TypeFloat = 3,
		TypeUint2 = 4,
		TypeInt2 = 5,
		TypeFloat2 = 6,
		TypeUint3 = 7,
		TypeInt3 = 8,
		TypeFloat3 = 9,
		TypeUint4 = 10,
		TypeInt4 = 11,
		TypeFloat4 = 12,
		TypeBool = 13,
	}

	private static class Profiling
	{
		public static readonly ProfilingSampler BufferReadComplete; //Field offset: 0x0

		private static Profiling() { }

	}

	private static readonly ShaderDebugPrintManager s_Instance; //Field offset: 0x0
	private const int k_FramesInFlight = 4; //Field offset: 0x0
	private const int k_MaxBufferElements = 16384; //Field offset: 0x0
	private const uint k_TypeHasTag = 128; //Field offset: 0x0
	private static readonly int m_ShaderPropertyIDInputMouse; //Field offset: 0x8
	private static readonly int m_ShaderPropertyIDInputFrame; //Field offset: 0xC
	private static readonly int m_shaderDebugOutputData; //Field offset: 0x10
	private List<GraphicsBuffer> m_OutputBuffers; //Field offset: 0x10
	private List<AsyncGPUReadbackRequest> m_ReadbackRequests; //Field offset: 0x18
	private Action<AsyncGPUReadbackRequest> m_BufferReadCompleteAction; //Field offset: 0x20
	private int m_FrameCounter; //Field offset: 0x28
	private bool m_FrameCleared; //Field offset: 0x2C
	private string m_OutputLine; //Field offset: 0x30
	private Action<String> m_OutputAction; //Field offset: 0x38

	public static ShaderDebugPrintManager instance
	{
		 get { } //Length: 78
	}

	public Action<String> outputAction
	{
		 set { } //Length: 13
	}

	public string outputLine
	{
		 get { } //Length: 5
	}

	private static ShaderDebugPrintManager() { }

	private ShaderDebugPrintManager() { }

	private void BufferReadComplete(AsyncGPUReadbackRequest request) { }

	private void ClearShaderDebugPrintBuffer() { }

	private int DebugValueTypeToElemSize(DebugValueType type) { }

	public void DefaultOutput(string line) { }

	public void EndFrame() { }

	public static ShaderDebugPrintManager get_instance() { }

	public string get_outputLine() { }

	public void PrintImmediate() { }

	public void set_outputAction(Action<String> value) { }

	public void SetShaderDebugPrintBindings(CommandBuffer cmd) { }

	public void SetShaderDebugPrintInputConstants(CommandBuffer cmd, ShaderDebugPrintInput input) { }

}

