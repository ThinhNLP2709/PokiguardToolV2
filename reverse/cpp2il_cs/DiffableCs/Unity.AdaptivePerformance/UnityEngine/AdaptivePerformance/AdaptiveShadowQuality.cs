namespace UnityEngine.AdaptivePerformance;

public class AdaptiveShadowQuality : AdaptivePerformanceScaler
{
	private int m_DefaultShadowQualityBias; //Field offset: 0x50

	public AdaptiveShadowQuality() { }

	protected virtual void Awake() { }

	protected virtual void OnDisabled() { }

	protected virtual void OnEnabled() { }

	protected virtual void OnLevel() { }

}

