namespace UnityEngine.Rendering;

[UsedByNativeCode]
public struct ShadowSplitData : IEquatable<ShadowSplitData>
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <m_CullingPlanes>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	private const int k_MaximumCullingPlaneCount = 10; //Field offset: 0x0
	public static readonly int maximumCullingPlaneCount; //Field offset: 0x0
	private int m_CullingPlaneCount; //Field offset: 0x0
	[FixedBuffer(typeof(byte), 160)]
	internal <m_CullingPlanes>e__FixedBuffer m_CullingPlanes; //Field offset: 0x4
	private Vector4 m_CullingSphere; //Field offset: 0xA4
	private float m_ShadowCascadeBlendCullingFactor; //Field offset: 0xB4
	private float m_CullingNearPlane; //Field offset: 0xB8
	private Matrix4x4 m_CullingMatrix; //Field offset: 0xBC

	public int cullingPlaneCount
	{
		 get { } //Length: 5
	}

	public Vector4 cullingSphere
	{
		 get { } //Length: 14
	}

	public float shadowCascadeBlendCullingFactor
	{
		 set { } //Length: 267
	}

	private static ShadowSplitData() { }

	public override bool Equals(ShadowSplitData other) { }

	public virtual bool Equals(object obj) { }

	public int get_cullingPlaneCount() { }

	public Vector4 get_cullingSphere() { }

	public Plane GetCullingPlane(int index) { }

	public virtual int GetHashCode() { }

	public void set_shadowCascadeBlendCullingFactor(float value) { }

}

