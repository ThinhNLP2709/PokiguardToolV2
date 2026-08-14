namespace UnityEngine.Rendering;

internal struct GPUDrivenRendererGroupData
{
	public NativeArray<Int32> rendererGroupID; //Field offset: 0x0
	public NativeArray<Bounds> localBounds; //Field offset: 0x10
	public NativeArray<Vector4> lightmapScaleOffset; //Field offset: 0x20
	public NativeArray<Int32> gameObjectLayer; //Field offset: 0x30
	public NativeArray<UInt32> renderingLayerMask; //Field offset: 0x40
	public NativeArray<Int32> lodGroupID; //Field offset: 0x50
	public NativeArray<Int32> lightmapIndex; //Field offset: 0x60
	public NativeArray<GPUDrivenPackedRendererData> packedRendererData; //Field offset: 0x70
	public NativeArray<Int32> rendererPriority; //Field offset: 0x80
	public NativeArray<Int32> meshIndex; //Field offset: 0x90
	public NativeArray<Int16> subMeshStartIndex; //Field offset: 0xA0
	public NativeArray<Int32> materialsOffset; //Field offset: 0xB0
	public NativeArray<Int16> materialsCount; //Field offset: 0xC0
	public NativeArray<Int32> instancesOffset; //Field offset: 0xD0
	public NativeArray<Int32> instancesCount; //Field offset: 0xE0
	public NativeArray<GPUDrivenRendererEditorData> editorData; //Field offset: 0xF0
	public NativeArray<Int32> invalidRendererGroupID; //Field offset: 0x100
	public NativeArray<Matrix4x4> localToWorldMatrix; //Field offset: 0x110
	public NativeArray<Matrix4x4> prevLocalToWorldMatrix; //Field offset: 0x120
	public NativeArray<Int32> rendererGroupIndex; //Field offset: 0x130
	public NativeArray<Int32> meshID; //Field offset: 0x140
	public NativeArray<Int16> subMeshCount; //Field offset: 0x150
	public NativeArray<Int32> subMeshDescOffset; //Field offset: 0x160
	public NativeArray<SubMeshDescriptor> subMeshDesc; //Field offset: 0x170
	public NativeArray<Int32> materialIndex; //Field offset: 0x180
	public NativeArray<Int32> materialID; //Field offset: 0x190
	public NativeArray<GPUDrivenPackedMaterialData> packedMaterialData; //Field offset: 0x1A0
	public NativeArray<Int32> materialFilterFlags; //Field offset: 0x1B0

}

