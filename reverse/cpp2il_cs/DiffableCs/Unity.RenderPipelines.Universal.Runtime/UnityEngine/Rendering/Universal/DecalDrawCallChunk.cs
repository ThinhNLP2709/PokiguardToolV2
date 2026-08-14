namespace UnityEngine.Rendering.Universal;

internal class DecalDrawCallChunk : DecalChunk
{
	public NativeArray<float4x4> decalToWorlds; //Field offset: 0x28
	public NativeArray<float4x4> normalToDecals; //Field offset: 0x38
	public NativeArray<Single> renderingLayerMasks; //Field offset: 0x48
	public NativeArray<DecalSubDrawCall> subCalls; //Field offset: 0x58
	public NativeArray<Int32> subCallCounts; //Field offset: 0x68

	public int subCallCount
	{
		 get { } //Length: 7
		 set { } //Length: 7
	}

	public DecalDrawCallChunk() { }

	public virtual void Dispose() { }

	public int get_subCallCount() { }

	public virtual void RemoveAtSwapBack(int entityIndex) { }

	public void set_subCallCount(int value) { }

	public virtual void SetCapacity(int newCapacity) { }

}

