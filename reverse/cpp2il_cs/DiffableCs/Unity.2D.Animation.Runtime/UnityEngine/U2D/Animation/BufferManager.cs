namespace UnityEngine.U2D.Animation;

internal class BufferManager : ScriptableObject
{
	private static BufferManager s_Instance; //Field offset: 0x0
	private Dictionary<Int32, VertexBuffer> m_Buffers; //Field offset: 0x18
	private Queue<VertexBuffer> m_BuffersToDispose; //Field offset: 0x20
	[CompilerGenerated]
	private bool <needDoubleBuffering>k__BackingField; //Field offset: 0x28

	public int bufferCount
	{
		 get { } //Length: 325
	}

	public static BufferManager instance
	{
		 get { } //Length: 285
	}

	public bool needDoubleBuffering
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public BufferManager() { }

	private VertexBuffer CreateBuffer(int id, int bufferSize) { }

	private void ForceClearBuffers() { }

	public int get_bufferCount() { }

	public static BufferManager get_instance() { }

	[CompilerGenerated]
	public bool get_needDoubleBuffering() { }

	public NativeByteArray GetBuffer(int id, int bufferSize) { }

	private void OnDisable() { }

	private void OnEnable() { }

	public void ReturnBuffer(int id) { }

	[CompilerGenerated]
	public void set_needDoubleBuffering(bool value) { }

	private void Update() { }

}

