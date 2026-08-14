namespace Unity.Burst.Intrinsics;

internal class V64DebugView
{
	private v64 m_Value; //Field offset: 0x10

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public Byte[] Byte
	{
		 get { } //Length: 180
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public Double[] Double
	{
		 get { } //Length: 92
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public Single[] Float
	{
		 get { } //Length: 108
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public SByte[] SByte
	{
		 get { } //Length: 180
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public Int32[] SInt
	{
		 get { } //Length: 100
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public Int64[] SLong
	{
		 get { } //Length: 90
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public Int16[] SShort
	{
		 get { } //Length: 132
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public UInt32[] UInt
	{
		 get { } //Length: 100
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public UInt64[] ULong
	{
		 get { } //Length: 90
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public UInt16[] UShort
	{
		 get { } //Length: 132
	}

	public V64DebugView(v64 value) { }

	public Byte[] get_Byte() { }

	public Double[] get_Double() { }

	public Single[] get_Float() { }

	public SByte[] get_SByte() { }

	public Int32[] get_SInt() { }

	public Int64[] get_SLong() { }

	public Int16[] get_SShort() { }

	public UInt32[] get_UInt() { }

	public UInt64[] get_ULong() { }

	public UInt16[] get_UShort() { }

}

