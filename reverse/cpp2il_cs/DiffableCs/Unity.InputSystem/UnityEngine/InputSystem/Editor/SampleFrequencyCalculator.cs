namespace UnityEngine.InputSystem.Editor;

internal struct SampleFrequencyCalculator
{
	private double m_LastUpdateTime; //Field offset: 0x0
	private int m_SampleCount; //Field offset: 0x8
	[CompilerGenerated]
	private float <targetFrequency>k__BackingField; //Field offset: 0xC
	[CompilerGenerated]
	private float <frequency>k__BackingField; //Field offset: 0x10

	public private float frequency
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 6
		[CompilerGenerated]
		private set { } //Length: 6
	}

	public private float targetFrequency
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 6
		[CompilerGenerated]
		private set { } //Length: 6
	}

	public SampleFrequencyCalculator(float targetFrequency, double realtimeSinceStartup) { }

	[CompilerGenerated]
	[IsReadOnly]
	public float get_frequency() { }

	[CompilerGenerated]
	[IsReadOnly]
	public float get_targetFrequency() { }

	public void ProcessSample(InputEventPtr eventPtr) { }

	[CompilerGenerated]
	private void set_frequency(float value) { }

	[CompilerGenerated]
	private void set_targetFrequency(float value) { }

	public bool Update() { }

	public bool Update(double realtimeSinceStartup) { }

}

