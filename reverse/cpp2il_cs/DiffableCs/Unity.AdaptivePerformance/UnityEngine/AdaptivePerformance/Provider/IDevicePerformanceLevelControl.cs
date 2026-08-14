namespace UnityEngine.AdaptivePerformance.Provider;

public interface IDevicePerformanceLevelControl
{

	public int MaxCpuPerformanceLevel
	{
		 get { } //Length: 0
	}

	public int MaxGpuPerformanceLevel
	{
		 get { } //Length: 0
	}

	public bool EnableCpuBoost() { }

	public bool EnableGpuBoost() { }

	public int get_MaxCpuPerformanceLevel() { }

	public int get_MaxGpuPerformanceLevel() { }

	public bool SetPerformanceLevel(ref int cpu, ref int gpu) { }

}

