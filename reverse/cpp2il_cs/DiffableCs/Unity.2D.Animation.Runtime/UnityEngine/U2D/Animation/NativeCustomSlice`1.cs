namespace UnityEngine.U2D.Animation;

[DefaultMember("Item")]
internal struct NativeCustomSlice
{
	[NativeDisableUnsafePtrRestriction]
	public IntPtr data; //Field offset: 0x0
	public int length; //Field offset: 0x0
	public int stride; //Field offset: 0x0

	public T Item
	{
		 get { } //Length: 98
	}

	public int Length
	{
		 get { } //Length: 4
	}

	public NativeCustomSlice`1(NativeSlice<T> nativeSlice) { }

	public NativeCustomSlice`1(NativeSlice<Byte> slice, int length, int stride) { }

	public static NativeCustomSlice<T> Default() { }

	public T get_Item(int index) { }

	public int get_Length() { }

}

