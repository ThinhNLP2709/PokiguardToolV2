namespace UnityEngine.AdaptivePerformance;

public class AdaptiveLut : AdaptivePerformanceScaler
{
	private float m_DefaultLutBias; //Field offset: 0x50

	public AdaptiveLut() { }

	protected virtual void Awake() { }

	protected virtual void OnDisabled() { }

	protected virtual void OnEnabled() { }

	protected virtual void OnLevel() { }

}

