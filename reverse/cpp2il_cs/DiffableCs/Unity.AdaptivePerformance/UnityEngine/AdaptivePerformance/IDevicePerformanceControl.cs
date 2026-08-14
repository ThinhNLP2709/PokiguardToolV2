namespace UnityEngine.AdaptivePerformance;

public interface IDevicePerformanceControl
{

	public bool AutomaticPerformanceControl
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public int CpuLevel
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public bool CpuPerformanceBoost
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public int GpuLevel
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public bool GpuPerformanceBoost
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public int MaxCpuPerformanceLevel
	{
		 get { } //Length: 0
	}

	public int MaxGpuPerformanceLevel
	{
		 get { } //Length: 0
	}

	public PerformanceControlMode PerformanceControlMode
	{
		 get { } //Length: 0
	}

	public bool get_AutomaticPerformanceControl() { }

	public int get_CpuLevel() { }

	public bool get_CpuPerformanceBoost() { }

	public int get_GpuLevel() { }

	public bool get_GpuPerformanceBoost() { }

	public int get_MaxCpuPerformanceLevel() { }

	public int get_MaxGpuPerformanceLevel() { }

	public PerformanceControlMode get_PerformanceControlMode() { }

	public void set_AutomaticPerformanceControl(bool value) { }

	public void set_CpuLevel(int value) { }

	public void set_CpuPerformanceBoost(bool value) { }

	public void set_GpuLevel(int value) { }

	public void set_GpuPerformanceBoost(bool value) { }

}

