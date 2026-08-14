namespace Unity.VisualScripting;

public static class ProfilingUtility
{
	private static readonly object lock; //Field offset: 0x0
	[CompilerGenerated]
	private static ProfiledSegment <rootSegment>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private static ProfiledSegment <currentSegment>k__BackingField; //Field offset: 0x10

	public static ProfiledSegment currentSegment
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		 set { } //Length: 110
	}

	public private static ProfiledSegment rootSegment
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		private set { } //Length: 110
	}

	private static ProfilingUtility() { }

	[Conditional("ENABLE_PROFILER")]
	public static void BeginSample(string name) { }

	[Conditional("ENABLE_PROFILER")]
	public static void Clear() { }

	[Conditional("ENABLE_PROFILER")]
	public static void EndSample() { }

	[CompilerGenerated]
	public static ProfiledSegment get_currentSegment() { }

	[CompilerGenerated]
	public static ProfiledSegment get_rootSegment() { }

	public static ProfilingScope SampleBlock(string name) { }

	[CompilerGenerated]
	public static void set_currentSegment(ProfiledSegment value) { }

	[CompilerGenerated]
	private static void set_rootSegment(ProfiledSegment value) { }

}

