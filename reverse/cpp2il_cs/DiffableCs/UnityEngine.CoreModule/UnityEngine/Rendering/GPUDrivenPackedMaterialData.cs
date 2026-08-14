namespace UnityEngine.Rendering;

[UsedByNativeCode]
internal struct GPUDrivenPackedMaterialData
{
	private uint data; //Field offset: 0x0

	public bool isIndirectSupported
	{
		 get { } //Length: 7
	}

	public bool isMotionVectorsPassEnabled
	{
		 get { } //Length: 7
	}

	public bool isTransparent
	{
		 get { } //Length: 6
	}

	public GPUDrivenPackedMaterialData() { }

	public bool get_isIndirectSupported() { }

	public bool get_isMotionVectorsPassEnabled() { }

	public bool get_isTransparent() { }

}

