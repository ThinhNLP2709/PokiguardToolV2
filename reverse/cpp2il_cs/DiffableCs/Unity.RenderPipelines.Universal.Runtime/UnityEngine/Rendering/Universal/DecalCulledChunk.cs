namespace UnityEngine.Rendering.Universal;

internal class DecalCulledChunk : DecalChunk
{
	public Vector3 cameraPosition; //Field offset: 0x28
	public ulong sceneCullingMask; //Field offset: 0x38
	public int cullingMask; //Field offset: 0x40
	public CullingGroup cullingGroups; //Field offset: 0x48
	public Int32[] visibleDecalIndexArray; //Field offset: 0x50
	public NativeArray<Int32> visibleDecalIndices; //Field offset: 0x58
	public int visibleDecalCount; //Field offset: 0x68

	public DecalCulledChunk() { }

	public virtual void Dispose() { }

	public virtual void RemoveAtSwapBack(int entityIndex) { }

	public virtual void SetCapacity(int newCapacity) { }

}

