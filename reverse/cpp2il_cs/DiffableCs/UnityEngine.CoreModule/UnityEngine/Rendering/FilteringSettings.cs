namespace UnityEngine.Rendering;

public struct FilteringSettings : IEquatable<FilteringSettings>
{
	private RenderQueueRange m_RenderQueueRange; //Field offset: 0x0
	private int m_LayerMask; //Field offset: 0x8
	private uint m_RenderingLayerMask; //Field offset: 0xC
	private uint m_BatchLayerMask; //Field offset: 0x10
	private int m_ExcludeMotionVectorObjects; //Field offset: 0x14
	private int m_ForceAllMotionVectorObjects; //Field offset: 0x18
	private SortingLayerRange m_SortingLayerRange; //Field offset: 0x1C

	public uint batchLayerMask
	{
		 set { } //Length: 4
	}

	public bool excludeMotionVectorObjects
	{
		 set { } //Length: 9
	}

	public bool forceAllMotionVectorObjects
	{
		 set { } //Length: 9
	}

	public RenderQueueRange renderQueueRange
	{
		 get { } //Length: 6
	}

	public FilteringSettings(Nullable<RenderQueueRange> renderQueueRange = null, int layerMask = -1, uint renderingLayerMask = 4294967295, int excludeMotionVectorObjects = 0) { }

	public override bool Equals(FilteringSettings other) { }

	public virtual bool Equals(object obj) { }

	public RenderQueueRange get_renderQueueRange() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(FilteringSettings left, FilteringSettings right) { }

	public void set_batchLayerMask(uint value) { }

	public void set_excludeMotionVectorObjects(bool value) { }

	public void set_forceAllMotionVectorObjects(bool value) { }

}

