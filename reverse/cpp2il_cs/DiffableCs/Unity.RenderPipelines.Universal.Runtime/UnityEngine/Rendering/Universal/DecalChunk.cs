namespace UnityEngine.Rendering.Universal;

internal abstract class DecalChunk : IDisposable
{
	[CompilerGenerated]
	private int <count>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private int <capacity>k__BackingField; //Field offset: 0x14
	[CompilerGenerated]
	private JobHandle <currentJobHandle>k__BackingField; //Field offset: 0x18

	public int capacity
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public int count
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public JobHandle currentJobHandle
	{
		[CompilerGenerated]
		 get { } //Length: 11
		[CompilerGenerated]
		 set { } //Length: 8
	}

	protected DecalChunk() { }

	public override void Dispose() { }

	[CompilerGenerated]
	public int get_capacity() { }

	[CompilerGenerated]
	public int get_count() { }

	[CompilerGenerated]
	public JobHandle get_currentJobHandle() { }

	public override void Push() { }

	public abstract void RemoveAtSwapBack(int index) { }

	protected void RemoveAtSwapBack(ref NativeArray<T>& array, int index, int count) { }

	protected void RemoveAtSwapBack(ref T[] array, int index, int count) { }

	protected void ResizeNativeArray(ref TransformAccessArray array, DecalProjector[] decalProjectors, int capacity) { }

	[CompilerGenerated]
	protected void set_capacity(int value) { }

	[CompilerGenerated]
	protected void set_count(int value) { }

	[CompilerGenerated]
	public void set_currentJobHandle(JobHandle value) { }

	public abstract void SetCapacity(int capacity) { }

}

