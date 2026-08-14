namespace UnityEngine.Rendering.Universal;

internal struct URPLightShadowCullingInfos
{
	public NativeArray<ShadowSliceData> slices; //Field offset: 0x0
	public uint slicesValidMask; //Field offset: 0x10

	[IsReadOnly]
	public bool IsSliceValid(int i) { }

}

