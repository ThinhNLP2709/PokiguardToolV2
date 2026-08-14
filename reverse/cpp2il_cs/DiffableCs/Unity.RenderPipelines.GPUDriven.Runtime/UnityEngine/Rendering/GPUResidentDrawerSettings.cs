namespace UnityEngine.Rendering;

public struct GPUResidentDrawerSettings
{
	public GPUResidentDrawerMode mode; //Field offset: 0x0
	public bool supportDitheringCrossFade; //Field offset: 0x1
	public bool enableOcclusionCulling; //Field offset: 0x2
	public bool allowInEditMode; //Field offset: 0x3
	public float smallMeshScreenPercentage; //Field offset: 0x4
	public Shader errorShader; //Field offset: 0x8
	public Shader loadingShader; //Field offset: 0x10

}

