namespace UnityEngine.Rendering.Universal;

internal class DecalEntityChunk : DecalChunk
{
	public Material material; //Field offset: 0x28
	public NativeArray<DecalEntity> decalEntities; //Field offset: 0x30
	public DecalProjector[] decalProjectors; //Field offset: 0x40
	public TransformAccessArray transformAccessArray; //Field offset: 0x48

	public DecalEntityChunk() { }

	public virtual void Dispose() { }

	public virtual void Push() { }

	public virtual void RemoveAtSwapBack(int entityIndex) { }

	public virtual void SetCapacity(int newCapacity) { }

}

