namespace UnityEngine.Rendering;

[NativeHeader("Modules/Terrain/Public/SpeedTreeWind.h")]
[UsedByNativeCode]
internal struct SpeedTreeWindParamsBufferIterator
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <uintParamOffsets>e__FixedBuffer
	{
		public int FixedElementField; //Field offset: 0x0

	}

	public IntPtr bufferPtr; //Field offset: 0x0
	[FixedBuffer(typeof(int), 16)]
	public <uintParamOffsets>e__FixedBuffer uintParamOffsets; //Field offset: 0x8
	public int uintStride; //Field offset: 0x48
	public int elementOffset; //Field offset: 0x4C
	public int elementsCount; //Field offset: 0x50

}

