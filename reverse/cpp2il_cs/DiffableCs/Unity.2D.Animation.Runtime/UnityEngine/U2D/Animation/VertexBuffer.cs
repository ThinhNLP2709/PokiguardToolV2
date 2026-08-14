namespace UnityEngine.U2D.Animation;

internal class VertexBuffer
{
	private readonly int m_Id; //Field offset: 0x10
	private bool m_IsActive; //Field offset: 0x14
	private int m_DeactivateFrame; //Field offset: 0x18
	private NativeByteArray[] m_Buffers; //Field offset: 0x20
	private int m_ActiveIndex; //Field offset: 0x28

	public int bufferCount
	{
		 get { } //Length: 26
	}

	public VertexBuffer(int id, int size, bool needDoubleBuffering) { }

	public void Deactivate() { }

	public void Dispose() { }

	public int get_bufferCount() { }

	public NativeByteArray GetBuffer(int size) { }

	private static int GetCurrentFrame() { }

	public virtual int GetHashCode() { }

	public bool IsSafeToDispose() { }

	private void ResizeBuffer(int bufferId, int newSize) { }

}

