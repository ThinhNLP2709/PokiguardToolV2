namespace UnityEngine.AdaptivePerformance;

internal class TemperatureTrend
{
	private const int MeasurementTimeframeSeconds = 20; //Field offset: 0x0
	private const int UpdateFrequency = 10; //Field offset: 0x0
	private const int SamplesCapacity = 200; //Field offset: 0x0
	private const double SlopeAtMaxTrend = 0.005; //Field offset: 0x0
	private bool m_UseProviderTrend; //Field offset: 0x10
	private double m_SumX; //Field offset: 0x18
	private double m_SumY; //Field offset: 0x20
	private double m_SumXY; //Field offset: 0x28
	private double m_SumXX; //Field offset: 0x30
	private Single[] m_TimeStamps; //Field offset: 0x38
	private Single[] m_Temperature; //Field offset: 0x40
	private int m_NumValues; //Field offset: 0x48
	private int m_NextValueIndex; //Field offset: 0x4C
	private int m_OldestValueIndex; //Field offset: 0x50
	[CompilerGenerated]
	private float <ThermalTrend>k__BackingField; //Field offset: 0x54

	public int NumValues
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public private float ThermalTrend
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		private set { } //Length: 6
	}

	public TemperatureTrend(bool useProviderTrend) { }

	public int get_NumValues() { }

	[CompilerGenerated]
	public float get_ThermalTrend() { }

	private void PopOldestValue() { }

	private void PushNewValue(float tempLevel, float timestamp) { }

	public void Reset() { }

	public void set_NumValues(int value) { }

	[CompilerGenerated]
	private void set_ThermalTrend(float value) { }

	public void Update(float temperatureTrendFromProvider, float newTemperatureLevel, bool changed, float newTemperatureTimestamp) { }

	private void UpdateTrend() { }

}

