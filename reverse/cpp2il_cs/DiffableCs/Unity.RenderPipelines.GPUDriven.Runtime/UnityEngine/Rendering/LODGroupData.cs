namespace UnityEngine.Rendering;

internal struct LODGroupData
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <fadeTransitionWidth>e__FixedBuffer
	{
		public float FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <screenRelativeTransitionHeights>e__FixedBuffer
	{
		public float FixedElementField; //Field offset: 0x0

	}

	public const int k_MaxLODLevelsCount = 8; //Field offset: 0x0
	public bool valid; //Field offset: 0x0
	public int lodCount; //Field offset: 0x4
	public int rendererCount; //Field offset: 0x8
	[FixedBuffer(typeof(float), 8)]
	public <screenRelativeTransitionHeights>e__FixedBuffer screenRelativeTransitionHeights; //Field offset: 0xC
	[FixedBuffer(typeof(float), 8)]
	public <fadeTransitionWidth>e__FixedBuffer fadeTransitionWidth; //Field offset: 0x2C

}

