namespace UnityEngine.Rendering;

public class DebugFrameTiming
{
	private const string k_FpsFormatString = "{0:F1}"; //Field offset: 0x0
	private const string k_MsFormatString = "{0:F2}ms"; //Field offset: 0x0
	private const float k_RefreshRate = 0.2; //Field offset: 0x0
	internal FrameTimeSampleHistory m_FrameHistory; //Field offset: 0x10
	internal BottleneckHistory m_BottleneckHistory; //Field offset: 0x18
	[CompilerGenerated]
	private int <bottleneckHistorySize>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private int <sampleHistorySize>k__BackingField; //Field offset: 0x24
	private FrameTiming[] m_Timing; //Field offset: 0x28
	private FrameTimeSample m_Sample; //Field offset: 0x30

	public int bottleneckHistorySize
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public int sampleHistorySize
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public DebugFrameTiming() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_0() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_1() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_10() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_11() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_12() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_13() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_14() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_15() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_16() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_17() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_18() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_19() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_2() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_20() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_21() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_3() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_4() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_5() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_6() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_7() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_8() { }

	[CompilerGenerated]
	private object <RegisterDebugUI>b__17_9() { }

	[CompilerGenerated]
	public int get_bottleneckHistorySize() { }

	[CompilerGenerated]
	public int get_sampleHistorySize() { }

	public void RegisterDebugUI(List<Widget> list) { }

	internal void Reset() { }

	[CompilerGenerated]
	public void set_bottleneckHistorySize(int value) { }

	[CompilerGenerated]
	public void set_sampleHistorySize(int value) { }

	public void UpdateFrameTiming() { }

}

