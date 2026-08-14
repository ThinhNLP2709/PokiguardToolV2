namespace UnityEngine.AdaptivePerformance;

public class AdaptiveVariableRefreshRate : AdaptiveFramerate
{
	private bool m_AdaptiveVRREnabled; //Field offset: 0x58
	private IVariableRefreshRate m_VRR; //Field offset: 0x60
	private int m_CurrentRefreshRateIndex; //Field offset: 0x68
	private int m_DefaultRefreshRateIndex; //Field offset: 0x6C

	public virtual bool Enabled
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public virtual string Name
	{
		 get { } //Length: 44
	}

	public AdaptiveVariableRefreshRate() { }

	protected virtual void Awake() { }

	public virtual bool get_Enabled() { }

	public virtual string get_Name() { }

	private void OnDestroy() { }

	protected virtual void OnDisabled() { }

	protected virtual void OnEnabled() { }

	protected virtual void OnLevelDecrease() { }

	protected virtual void OnLevelIncrease() { }

	private void RefreshRateChanged() { }

	public virtual void set_Enabled(bool value) { }

}

