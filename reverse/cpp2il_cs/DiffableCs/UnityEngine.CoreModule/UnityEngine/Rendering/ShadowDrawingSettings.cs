namespace UnityEngine.Rendering;

[UsedByNativeCode]
public struct ShadowDrawingSettings : IEquatable<ShadowDrawingSettings>
{
	private CullingResults m_CullingResults; //Field offset: 0x0
	private int m_LightIndex; //Field offset: 0x10
	private int m_SplitIndex; //Field offset: 0x14
	private int m_UseRenderingLayerMaskTest; //Field offset: 0x18
	private uint m_BatchLayerMask; //Field offset: 0x1C
	private ShadowSplitData m_SplitData; //Field offset: 0x20
	private ShadowObjectsFilter m_ObjectsFilter; //Field offset: 0x11C
	private BatchCullingProjectionType m_ProjectionType; //Field offset: 0x120

	public bool useRenderingLayerMaskTest
	{
		 set { } //Length: 9
	}

	public ShadowDrawingSettings(CullingResults cullingResults, int lightIndex) { }

	public override bool Equals(ShadowDrawingSettings other) { }

	public virtual bool Equals(object obj) { }

	public virtual int GetHashCode() { }

	public void set_useRenderingLayerMaskTest(bool value) { }

}

