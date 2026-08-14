namespace UnityEngine.Rendering.Universal;

public struct RenderingData
{
	internal ContextContainer frameData; //Field offset: 0x0
	public CameraData cameraData; //Field offset: 0x8
	public LightData lightData; //Field offset: 0x10
	public ShadowData shadowData; //Field offset: 0x18
	public PostProcessingData postProcessingData; //Field offset: 0x20

	internal CommandBuffer commandBuffer
	{
		internal get { } //Length: 146
	}

	public CullingResults cullResults
	{
		 get { } //Length: 77
	}

	public PerObjectData perObjectData
	{
		 get { } //Length: 77
	}

	public bool postProcessingEnabled
	{
		 get { } //Length: 77
	}

	public bool supportsDynamicBatching
	{
		 get { } //Length: 77
	}

	internal UniversalRenderingData universalRenderingData
	{
		internal get { } //Length: 67
	}

	internal RenderingData(ContextContainer frameData) { }

	internal CommandBuffer get_commandBuffer() { }

	public CullingResults get_cullResults() { }

	public PerObjectData get_perObjectData() { }

	public bool get_postProcessingEnabled() { }

	public bool get_supportsDynamicBatching() { }

	internal UniversalRenderingData get_universalRenderingData() { }

}

