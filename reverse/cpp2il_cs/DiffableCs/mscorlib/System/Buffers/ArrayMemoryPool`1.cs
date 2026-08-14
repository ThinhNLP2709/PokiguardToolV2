namespace System.Buffers;

internal sealed class ArrayMemoryPool : MemoryPool<T>
{
	private sealed class ArrayMemoryPoolBuffer : IMemoryOwner<T>, IDisposable
	{
		private T[] _array; //Field offset: 0x0

		public override Memory<T> Memory
		{
			 get { } //Length: 103
		}

		public ArrayMemoryPoolBuffer(int size) { }

		public override void Dispose() { }

		public override Memory<T> get_Memory() { }

	}


	public ArrayMemoryPool`1() { }

	protected virtual void Dispose(bool disposing) { }

	public virtual IMemoryOwner<T> Rent(int minimumBufferSize = -1) { }

}

