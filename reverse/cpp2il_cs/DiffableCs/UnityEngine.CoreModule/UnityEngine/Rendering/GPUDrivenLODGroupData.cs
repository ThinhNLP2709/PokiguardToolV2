namespace UnityEngine.Rendering;

internal struct GPUDrivenLODGroupData
{
	public NativeArray<Int32> lodGroupID; //Field offset: 0x0
	public NativeArray<Int32> lodOffset; //Field offset: 0x10
	public NativeArray<Int32> lodCount; //Field offset: 0x20
	public NativeArray<LODFadeMode> fadeMode; //Field offset: 0x30
	public NativeArray<Vector3> worldSpaceReferencePoint; //Field offset: 0x40
	public NativeArray<Single> worldSpaceSize; //Field offset: 0x50
	public NativeArray<Int16> renderersCount; //Field offset: 0x60
	public NativeArray<Boolean> lastLODIsBillboard; //Field offset: 0x70
	public NativeArray<Int32> invalidLODGroupID; //Field offset: 0x80
	public NativeArray<Int16> lodRenderersCount; //Field offset: 0x90
	public NativeArray<Single> lodScreenRelativeTransitionHeight; //Field offset: 0xA0
	public NativeArray<Single> lodFadeTransitionWidth; //Field offset: 0xB0

}

