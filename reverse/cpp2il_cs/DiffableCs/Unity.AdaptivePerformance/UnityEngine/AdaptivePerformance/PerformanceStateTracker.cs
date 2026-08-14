namespace UnityEngine.AdaptivePerformance;

internal class PerformanceStateTracker
{
	private Queue<Single> m_Samples; //Field offset: 0x10
	private int m_SampleCapacity; //Field offset: 0x18
	[CompilerGenerated]
	private float <Trend>k__BackingField; //Field offset: 0x1C

	public float Trend
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		 set { } //Length: 6
	}

	public PerformanceStateTracker(int sampleCapacity) { }

	[CompilerGenerated]
	public float get_Trend() { }

	protected override float GetEffectiveTargetFrameRate() { }

	[CompilerGenerated]
	public void set_Trend(float value) { }

	public StateAction Update() { }

}

