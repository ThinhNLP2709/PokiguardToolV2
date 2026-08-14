namespace UnityEngine.Rendering.Universal;

internal struct PinnedArray : IDisposable
{
	public T[] managedArray; //Field offset: 0x0
	public GCHandle handle; //Field offset: 0x0
	public NativeArray<T> nativeArray; //Field offset: 0x0

	public int length
	{
		 get { } //Length: 16
	}

	public PinnedArray`1(int length) { }

	public override void Dispose() { }

	public int get_length() { }

}

