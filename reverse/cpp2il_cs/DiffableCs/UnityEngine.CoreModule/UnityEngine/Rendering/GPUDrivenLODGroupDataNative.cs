namespace UnityEngine.Rendering;

[UsedByNativeCode]
internal struct GPUDrivenLODGroupDataNative
{
	public Int32* lodGroupID; //Field offset: 0x0
	public Int32* lodOffset; //Field offset: 0x8
	public Int32* lodCount; //Field offset: 0x10
	public LODFadeMode* fadeMode; //Field offset: 0x18
	public Vector3* worldSpaceReferencePoint; //Field offset: 0x20
	public Single* worldSpaceSize; //Field offset: 0x28
	public Int16* renderersCount; //Field offset: 0x30
	public Boolean* lastLODIsBillboard; //Field offset: 0x38
	public int lodGroupCount; //Field offset: 0x40
	public Int32* invalidLODGroupID; //Field offset: 0x48
	public int invalidLODGroupCount; //Field offset: 0x50
	public Int16* lodRenderersCount; //Field offset: 0x58
	public Single* lodScreenRelativeTransitionHeight; //Field offset: 0x60
	public Single* lodFadeTransitionWidth; //Field offset: 0x68
	public int lodDataCount; //Field offset: 0x70

}

