namespace UnityEngine.Rendering.Universal;

public class UniversalRenderingData : ContextItem
{
	internal CommandBuffer m_CommandBuffer; //Field offset: 0x10
	public CullingResults cullResults; //Field offset: 0x18
	public bool supportsDynamicBatching; //Field offset: 0x28
	public PerObjectData perObjectData; //Field offset: 0x2C
	[CompilerGenerated]
	private RenderingMode <renderingMode>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private LayerMask <opaqueLayerMask>k__BackingField; //Field offset: 0x34
	[CompilerGenerated]
	private LayerMask <transparentLayerMask>k__BackingField; //Field offset: 0x38

	internal CommandBuffer commandBuffer
	{
		internal get { } //Length: 101
	}

	public internal LayerMask opaqueLayerMask
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	public internal RenderingMode renderingMode
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	public internal LayerMask transparentLayerMask
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	public UniversalRenderingData() { }

	internal CommandBuffer get_commandBuffer() { }

	[CompilerGenerated]
	public LayerMask get_opaqueLayerMask() { }

	[CompilerGenerated]
	public RenderingMode get_renderingMode() { }

	[CompilerGenerated]
	public LayerMask get_transparentLayerMask() { }

	public virtual void Reset() { }

	[CompilerGenerated]
	internal void set_opaqueLayerMask(LayerMask value) { }

	[CompilerGenerated]
	internal void set_renderingMode(RenderingMode value) { }

	[CompilerGenerated]
	internal void set_transparentLayerMask(LayerMask value) { }

}

