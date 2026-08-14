namespace System.Buffers;

public abstract class MemoryPool : IDisposable
{
	private static readonly MemoryPool<T> s_shared; //Field offset: 0x0

	public static MemoryPool<T> Shared
	{
		 get { } //Length: 153
	}

	private static MemoryPool`1() { }

	protected MemoryPool`1() { }

	public override void Dispose() { }

	protected abstract void Dispose(bool disposing) { }

	public static MemoryPool<T> get_Shared() { }

	public abstract IMemoryOwner<T> Rent(int minBufferSize = -1) { }

}

