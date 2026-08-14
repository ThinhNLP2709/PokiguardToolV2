namespace UnityEngine.UIElements.Layout;

internal struct LayoutComputedData
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <Border>e__FixedBuffer
	{
		public float FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <Dimensions>e__FixedBuffer
	{
		public float FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <Margin>e__FixedBuffer
	{
		public float FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <MeasuredDimensions>e__FixedBuffer
	{
		public float FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <Padding>e__FixedBuffer
	{
		public float FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <Position>e__FixedBuffer
	{
		public float FixedElementField; //Field offset: 0x0

	}

	[FixedBuffer(typeof(float), 4)]
	public <Position>e__FixedBuffer Position; //Field offset: 0x0
	[FixedBuffer(typeof(float), 2)]
	public <Dimensions>e__FixedBuffer Dimensions; //Field offset: 0x10
	[FixedBuffer(typeof(float), 6)]
	public <Margin>e__FixedBuffer Margin; //Field offset: 0x18
	[FixedBuffer(typeof(float), 6)]
	public <Border>e__FixedBuffer Border; //Field offset: 0x30
	[FixedBuffer(typeof(float), 6)]
	public <Padding>e__FixedBuffer Padding; //Field offset: 0x48
	public LayoutDirection Direction; //Field offset: 0x60
	public uint ComputedFlexBasisGeneration; //Field offset: 0x64
	public float ComputedFlexBasis; //Field offset: 0x68
	public bool HadOverflow; //Field offset: 0x6C
	public uint GenerationCount; //Field offset: 0x70
	public LayoutDirection LastParentDirection; //Field offset: 0x74
	public float LastPointScaleFactor; //Field offset: 0x78
	[FixedBuffer(typeof(float), 2)]
	public <MeasuredDimensions>e__FixedBuffer MeasuredDimensions; //Field offset: 0x7C

	public Single* BorderBuffer
	{
		 get { } //Length: 7
	}

	public static LayoutComputedData Default
	{
		 get { } //Length: 429
	}

	public Single* MarginBuffer
	{
		 get { } //Length: 7
	}

	public Single* PaddingBuffer
	{
		 get { } //Length: 7
	}

	public Single* get_BorderBuffer() { }

	public static LayoutComputedData get_Default() { }

	public Single* get_MarginBuffer() { }

	public Single* get_PaddingBuffer() { }

}

