namespace Unity.Profiling;

[DebuggerDisplay("Value = {Value}; Count = {Count}")]
[UsedByNativeCode]
public struct ProfilerRecorderSample
{
	private long value; //Field offset: 0x0
	private long count; //Field offset: 0x8
	private long refValue; //Field offset: 0x10

	public long Count
	{
		 get { } //Length: 5
	}

	public long get_Count() { }

}

