//Type is in global namespace

public static class AdaptivePerformanceProfilerStats
{
	internal struct ScalerInfo
	{
		[CompilerGenerated]
		[UnsafeValueType]
		internal struct <scalerName>e__FixedBuffer
		{
			public byte FixedElementField; //Field offset: 0x0

		}

		[FixedBuffer(typeof(byte), 320)]
		public <scalerName>e__FixedBuffer scalerName; //Field offset: 0x0
		public uint enabled; //Field offset: 0x140
		public int overrideLevel; //Field offset: 0x144
		public int currentLevel; //Field offset: 0x148
		public int maxLevel; //Field offset: 0x14C
		public float scale; //Field offset: 0x150
		public uint applied; //Field offset: 0x154

	}

	public static readonly ProfilerCategory AdaptivePerformanceProfilerCategory; //Field offset: 0x0
	private const int maxScalerNameSizeInBytes = 320; //Field offset: 0x0
	public static ProfilerCounter<Single> CurrentCPUCounter; //Field offset: 0x2
	public static ProfilerCounter<Single> AvgCPUCounter; //Field offset: 0x3
	public static ProfilerCounter<Single> CurrentGPUCounter; //Field offset: 0x4
	public static ProfilerCounter<Single> AvgGPUCounter; //Field offset: 0x5
	public static ProfilerCounter<Int32> CurrentCPULevelCounter; //Field offset: 0x6
	public static ProfilerCounter<Int32> CurrentGPULevelCounter; //Field offset: 0x7
	public static ProfilerCounter<Single> CurrentFrametimeCounter; //Field offset: 0x8
	public static ProfilerCounter<Single> AvgFrametimeCounter; //Field offset: 0x9
	public static ProfilerCounter<Int32> WarningLevelCounter; //Field offset: 0xA
	public static ProfilerCounter<Single> TemperatureLevelCounter; //Field offset: 0xB
	public static ProfilerCounter<Single> TemperatureTrendCounter; //Field offset: 0xC
	public static ProfilerCounter<Int32> BottleneckCounter; //Field offset: 0xD
	public static ProfilerCounter<Int32> PerformanceModeCounter; //Field offset: 0xE
	public static readonly Guid kAdaptivePerformanceProfilerModuleGuid; //Field offset: 0x10
	public static readonly int kScalerDataTag; //Field offset: 0x20
	private static List<ScalerInfo> scalerInfos; //Field offset: 0x28
	private static Byte[] arr; //Field offset: 0x30

	private static AdaptivePerformanceProfilerStats() { }

	[Conditional("ENABLE_PROFILER")]
	public static void EmitScalerDataToProfilerStream(string scalerName, bool enabled, int overrideLevel, int currentLevel, float scale, bool applied, int maxLevel) { }

	public static void FlushScalerDataToProfilerStream() { }

}

