namespace UnityEngine.U2D;

[VisibleToOtherModules]
internal struct SpriteChannelInfo
{
	[NativeName("buffer")]
	private IntPtr m_Buffer; //Field offset: 0x0
	[NativeName("count")]
	private int m_Count; //Field offset: 0x8
	[NativeName("offset")]
	private int m_Offset; //Field offset: 0xC
	[NativeName("stride")]
	private int m_Stride; //Field offset: 0x10

	public Void* buffer
	{
		 get { } //Length: 12
	}

	public int count
	{
		 get { } //Length: 6
	}

	public int offset
	{
		 get { } //Length: 6
	}

	public int stride
	{
		 get { } //Length: 6
	}

	public Void* get_buffer() { }

	public int get_count() { }

	public int get_offset() { }

	public int get_stride() { }

}

