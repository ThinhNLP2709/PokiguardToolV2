namespace UnityEngine.Rendering;

[UsedByNativeCode]
internal struct GPUDrivenRendererGroupDataNative
{
	public Int32* rendererGroupID; //Field offset: 0x0
	public Bounds* localBounds; //Field offset: 0x8
	public Vector4* lightmapScaleOffset; //Field offset: 0x10
	public Int32* gameObjectLayer; //Field offset: 0x18
	public UInt32* renderingLayerMask; //Field offset: 0x20
	public Int32* lodGroupID; //Field offset: 0x28
	public MotionVectorGenerationMode* motionVecGenMode; //Field offset: 0x30
	public GPUDrivenPackedRendererData* packedRendererData; //Field offset: 0x38
	public Int32* rendererPriority; //Field offset: 0x40
	public Int32* meshIndex; //Field offset: 0x48
	public Int16* subMeshStartIndex; //Field offset: 0x50
	public Int32* materialsOffset; //Field offset: 0x58
	public Int16* materialsCount; //Field offset: 0x60
	public Int32* instancesOffset; //Field offset: 0x68
	public Int32* instancesCount; //Field offset: 0x70
	public GPUDrivenRendererEditorData* editorData; //Field offset: 0x78
	public int rendererGroupCount; //Field offset: 0x80
	public Int32* invalidRendererGroupID; //Field offset: 0x88
	public int invalidRendererGroupIDCount; //Field offset: 0x90
	public Matrix4x4* localToWorldMatrix; //Field offset: 0x98
	public Matrix4x4* prevLocalToWorldMatrix; //Field offset: 0xA0
	public Int32* rendererGroupIndex; //Field offset: 0xA8
	public int instanceCount; //Field offset: 0xB0
	public Int32* meshID; //Field offset: 0xB8
	public Int16* subMeshCount; //Field offset: 0xC0
	public Int32* subMeshDescOffset; //Field offset: 0xC8
	public int meshCount; //Field offset: 0xD0
	public SubMeshDescriptor* subMeshDesc; //Field offset: 0xD8
	public int subMeshDescCount; //Field offset: 0xE0
	public Int32* materialIndex; //Field offset: 0xE8
	public int materialIndexCount; //Field offset: 0xF0
	public Int32* materialID; //Field offset: 0xF8
	public GPUDrivenPackedMaterialData* packedMaterialData; //Field offset: 0x100
	public Int32* materialFilterFlags; //Field offset: 0x108
	public int materialCount; //Field offset: 0x110

}

