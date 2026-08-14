namespace UnityEngine.Rendering;

internal class FrameTimeSampleHistory
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal float <.cctor>b__15_0(float value, float other) { }

		internal float <.cctor>b__15_1(float value, float other) { }

		internal float <.cctor>b__15_2(float value, float other) { }

		internal float <.cctor>b__15_3(float value, float other) { }

		internal float <.cctor>b__15_4(float value, float other) { }

		internal float <.cctor>b__15_5(float value, float other) { }

	}

	private static Func<Single, Single, Single> s_SampleValueAdd; //Field offset: 0x0
	private static Func<Single, Single, Single> s_SampleValueMin; //Field offset: 0x8
	private static Func<Single, Single, Single> s_SampleValueMax; //Field offset: 0x10
	private static Func<Single, Single, Single> s_SampleValueCountValid; //Field offset: 0x18
	private static Func<Single, Single, Single> s_SampleValueEnsureValid; //Field offset: 0x20
	private static Func<Single, Single, Single> s_SampleValueDivide; //Field offset: 0x28
	private List<FrameTimeSample> m_Samples; //Field offset: 0x10
	internal FrameTimeSample SampleAverage; //Field offset: 0x18
	internal FrameTimeSample SampleMin; //Field offset: 0x30
	internal FrameTimeSample SampleMax; //Field offset: 0x48

	private static FrameTimeSampleHistory() { }

	public FrameTimeSampleHistory(int initialCapacity) { }

	[CompilerGenerated]
	internal static void <ComputeAggregateValues>g__ForEachSampleMember|12_0(ref FrameTimeSample aggregate, FrameTimeSample sample, Func<Single, Single, Single> func) { }

	internal void Add(FrameTimeSample sample) { }

	internal void Clear() { }

	internal void ComputeAggregateValues() { }

	internal void DiscardOldSamples(int sampleHistorySize) { }

}

