namespace UnityEngine.Rendering;

internal struct ParallelBitArray
{
	private Allocator m_Allocator; //Field offset: 0x0
	private NativeArray<Int64> m_Bits; //Field offset: 0x8
	private int m_Length; //Field offset: 0x18

	public bool IsCreated
	{
		 get { } //Length: 51
	}

	public int Length
	{
		 get { } //Length: 4
	}

	public ParallelBitArray(int length, Allocator allocator, NativeArrayOptions options = 1) { }

	public int ChunkCount() { }

	public void Dispose() { }

	public void Dispose(JobHandle inputDeps) { }

	public void FillZeroes(int length) { }

	public bool Get(int index) { }

	public bool get_IsCreated() { }

	public int get_Length() { }

	public NativeArray<Int64> GetBitsArray() { }

	public ulong GetChunk(int chunk_index) { }

	public ParallelBitArray GetSubArray(int length) { }

	public void InterlockedOrChunk(int chunk_index, ulong chunk_bits) { }

	public ulong InterlockedReadChunk(int chunk_index) { }

	public void Resize(int newLength) { }

	public void Set(int index, bool value) { }

	public void SetChunk(int chunk_index, ulong chunk_bits) { }

}

