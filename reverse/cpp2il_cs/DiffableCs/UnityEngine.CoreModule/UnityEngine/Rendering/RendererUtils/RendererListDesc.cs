namespace UnityEngine.Rendering.RendererUtils;

public struct RendererListDesc
{
	private static readonly ShaderTagId s_EmptyName; //Field offset: 0x0
	public SortingCriteria sortingCriteria; //Field offset: 0x0
	public PerObjectData rendererConfiguration; //Field offset: 0x4
	public RenderQueueRange renderQueueRange; //Field offset: 0x8
	public Nullable<RenderStateBlock> stateBlock; //Field offset: 0x10
	public Shader overrideShader; //Field offset: 0x80
	public Material overrideMaterial; //Field offset: 0x88
	public bool excludeObjectMotionVectors; //Field offset: 0x90
	public int layerMask; //Field offset: 0x94
	public uint renderingLayerMask; //Field offset: 0x98
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private uint <batchLayerMask>k__BackingField; //Field offset: 0x9C
	public int overrideMaterialPassIndex; //Field offset: 0xA0
	public int overrideShaderPassIndex; //Field offset: 0xA4
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private CullingResults <cullingResult>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Camera <camera>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private ShaderTagId <passName>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private ShaderTagId[] <passNames>k__BackingField; //Field offset: 0xC8

	public uint batchLayerMask
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 7
	}

	internal Camera camera
	{
		[CompilerGenerated]
		[IsReadOnly]
		internal get { } //Length: 8
	}

	internal CullingResults cullingResult
	{
		[CompilerGenerated]
		[IsReadOnly]
		internal get { } //Length: 14
	}

	internal ShaderTagId passName
	{
		[CompilerGenerated]
		[IsReadOnly]
		internal get { } //Length: 7
	}

	internal ShaderTagId[] passNames
	{
		[CompilerGenerated]
		[IsReadOnly]
		internal get { } //Length: 8
	}

	private static RendererListDesc() { }

	public static RendererListParams ConvertToParameters(in RendererListDesc desc) { }

	[CompilerGenerated]
	[IsReadOnly]
	public uint get_batchLayerMask() { }

	[CompilerGenerated]
	[IsReadOnly]
	internal Camera get_camera() { }

	[CompilerGenerated]
	[IsReadOnly]
	internal CullingResults get_cullingResult() { }

	[CompilerGenerated]
	[IsReadOnly]
	internal ShaderTagId get_passName() { }

	[CompilerGenerated]
	[IsReadOnly]
	internal ShaderTagId[] get_passNames() { }

	public bool IsValid() { }

}

