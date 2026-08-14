namespace UnityEngine.Rendering;

internal struct LODGroupCullingData
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <percentageFlags>e__FixedBuffer
	{
		public bool FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <sqrDistances>e__FixedBuffer
	{
		public float FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <transitionDistances>e__FixedBuffer
	{
		public float FixedElementField; //Field offset: 0x0

	}

	public float3 worldSpaceReferencePoint; //Field offset: 0x0
	public int lodCount; //Field offset: 0xC
	[FixedBuffer(typeof(float), 8)]
	public <sqrDistances>e__FixedBuffer sqrDistances; //Field offset: 0x10
	[FixedBuffer(typeof(float), 8)]
	public <transitionDistances>e__FixedBuffer transitionDistances; //Field offset: 0x30
	public float worldSpaceSize; //Field offset: 0x50
	[FixedBuffer(typeof(bool), 8)]
	public <percentageFlags>e__FixedBuffer percentageFlags; //Field offset: 0x54

}

