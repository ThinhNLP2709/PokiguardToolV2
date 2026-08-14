namespace UnityEngine.Bindings;

[IsByRefLike]
[Obsolete("Types with embedded references are not supported in this version of your compiler.", True)]
[VisibleToOtherModules]
internal struct BlittableArrayWrapper
{
	public enum UpdateFlags
	{
		NoUpdateNeeded = 0,
		SizeChanged = 1,
		DataIsNativePointer = 2,
		DataIsNativeOwnedMemory = 3,
		DataIsEmpty = 4,
		DataIsNull = 5,
	}

	internal Void* data; //Field offset: 0x0
	internal int size; //Field offset: 0x8
	internal UpdateFlags updateFlags; //Field offset: 0xC

	public BlittableArrayWrapper(Void* data, int size) { }

	internal void Unmarshal(ref T[] array) { }

}

