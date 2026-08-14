namespace UnityEngine.Rendering;

public class ConstantBuffer
{
	private static List<ConstantBufferBase> m_RegisteredConstantBuffers; //Field offset: 0x0

	private static ConstantBuffer() { }

	public ConstantBuffer() { }

	public static void Push(CommandBuffer cmd, in CBType data, ComputeShader cs, int shaderId) { }

	public static void Push(in CBType data, ComputeShader cs, int shaderId) { }

	public static void Push(CommandBuffer cmd, in CBType data, Material mat, int shaderId) { }

	public static void Push(in CBType data, Material mat, int shaderId) { }

	public static void PushGlobal(CommandBuffer cmd, in CBType data, int shaderId) { }

	public static void PushGlobal(in CBType data, int shaderId) { }

	internal static void Register(ConstantBufferBase cb) { }

	public static void ReleaseAll() { }

	public static void Set(CommandBuffer cmd, ComputeShader cs, int shaderId) { }

	public static void Set(ComputeShader cs, int shaderId) { }

	public static void Set(Material mat, int shaderId) { }

	public static void SetGlobal(int shaderId) { }

	public static void SetGlobal(CommandBuffer cmd, int shaderId) { }

	public static void UpdateData(in CBType data) { }

	public static void UpdateData(CommandBuffer cmd, in CBType data) { }

}

