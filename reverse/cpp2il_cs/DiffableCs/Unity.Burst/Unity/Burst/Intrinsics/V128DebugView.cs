namespace Unity.Burst.Intrinsics;

internal class V128DebugView
{
	private v128 m_Value; //Field offset: 0x10

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public Byte[] Byte
	{
		 get { } //Length: 316
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public Double[] Double
	{
		 get { } //Length: 108
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public Single[] Float
	{
		 get { } //Length: 140
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public SByte[] SByte
	{
		 get { } //Length: 316
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public Int32[] SInt
	{
		 get { } //Length: 124
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public Int64[] SLong
	{
		 get { } //Length: 104
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public Int16[] SShort
	{
		 get { } //Length: 188
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public UInt32[] UInt
	{
		 get { } //Length: 124
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public UInt64[] ULong
	{
		 get { } //Length: 104
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Collapsed (2))]
	public UInt16[] UShort
	{
		 get { } //Length: 188
	}

	public V128DebugView(v128 value) { }

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

