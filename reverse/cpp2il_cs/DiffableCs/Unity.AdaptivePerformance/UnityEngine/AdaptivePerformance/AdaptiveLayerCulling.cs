namespace UnityEngine.AdaptivePerformance;

public class AdaptiveLayerCulling : AdaptivePerformanceScaler
{
	private Single[] m_defaultDistances; //Field offset: 0x50
	private Single[] m_scaledDistances; //Field offset: 0x58
	private bool init; //Field offset: 0x60
	private Camera m_cachedCamera; //Field offset: 0x68

	public AdaptiveLayerCulling() { }

	private void AsignDefaultValues() { }

	protected virtual void Awake() { }

	protected virtual void OnDisabled() { }

	protected virtual void OnEnabled() { }

	protected virtual void OnLevel() { }

}

