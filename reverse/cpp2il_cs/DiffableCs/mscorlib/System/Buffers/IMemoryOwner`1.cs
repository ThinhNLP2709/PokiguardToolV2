namespace System.Buffers;

public interface IMemoryOwner : IDisposable
{

	public Memory<T> Memory
	{
		 get { } //Length: 0
	}

	public Memory<T> get_Memory() { }

}

