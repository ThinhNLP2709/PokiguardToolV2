namespace UnityEngine.AdaptivePerformance.Samsung.Android;

public interface IVariableRefreshRate
{

	public event VariableRefreshRateEventHandler RefreshRateChanged
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public int CurrentRefreshRate
	{
		 get { } //Length: 0
	}

	public Int32[] SupportedRefreshRates
	{
		 get { } //Length: 0
	}

	[CompilerGenerated]
	public void add_RefreshRateChanged(VariableRefreshRateEventHandler value) { }

	public int get_CurrentRefreshRate() { }

	public Int32[] get_SupportedRefreshRates() { }

	[CompilerGenerated]
	public void remove_RefreshRateChanged(VariableRefreshRateEventHandler value) { }

	public bool SetRefreshRateByIndex(int index) { }

}

