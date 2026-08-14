namespace UnityEngine.Rendering;

[UsedByNativeCode]
internal struct GPUDrivenPackedRendererData
{
	private uint data; //Field offset: 0x0

	public bool hasTree
	{
		 get { } //Length: 10
	}

	public bool isPartOfStaticBatch
	{
		 get { } //Length: 10
	}

	public LightProbeUsage lightProbeUsage
	{
		 get { } //Length: 9
	}

	public byte lodMask
	{
		 get { } //Length: 6
	}

	public MotionVectorGenerationMode motionVecGenMode
	{
		 get { } //Length: 9
	}

	public ShadowCastingMode shadowCastingMode
	{
		 get { } //Length: 9
	}

	public bool smallMeshCulling
	{
		 get { } //Length: 10
	}

	public bool staticShadowCaster
	{
		 get { } //Length: 7
	}

	public GPUDrivenPackedRendererData() { }

	public bool get_hasTree() { }

	public bool get_isPartOfStaticBatch() { }

	public LightProbeUsage get_lightProbeUsage() { }

	public byte get_lodMask() { }

	public MotionVectorGenerationMode get_motionVecGenMode() { }

	public ShadowCastingMode get_shadowCastingMode() { }

	public bool get_smallMeshCulling() { }

	public bool get_staticShadowCaster() { }

}

