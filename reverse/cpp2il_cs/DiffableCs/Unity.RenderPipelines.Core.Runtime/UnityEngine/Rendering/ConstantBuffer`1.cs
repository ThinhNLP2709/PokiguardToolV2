namespace UnityEngine.Rendering;

public class ConstantBuffer : ConstantBufferBase
{
	private HashSet<Int32> m_GlobalBindings; //Field offset: 0x0
	private CBType[] m_Data; //Field offset: 0x0
	private ComputeBuffer m_GPUConstantBuffer; //Field offset: 0x0

	public ConstantBuffer`1() { }

	public void PushGlobal(CommandBuffer cmd, in CBType data, int shaderId) { }

	public void PushGlobal(in CBType data, int shaderId) { }

	public virtual void Release() { }

	public void Set(CommandBuffer cmd, ComputeShader cs, int shaderId) { }

	public void Set(ComputeShader cs, int shaderId) { }

	public void Set(Material mat, int shaderId) { }

	public void Set(MaterialPropertyBlock mpb, int shaderId) { }

	public void SetGlobal(CommandBuffer cmd, int shaderId) { }

	public void SetGlobal(int shaderId) { }

	public void UpdateData(CommandBuffer cmd, in CBType data) { }

	public void UpdateData(in CBType data) { }

}

