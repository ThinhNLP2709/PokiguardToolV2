namespace UnityEngine.UIElements.UIR;

internal struct RenderChainVEData
{
	public VisualElement prev; //Field offset: 0x0
	public VisualElement next; //Field offset: 0x8
	public VisualElement groupTransformAncestor; //Field offset: 0x10
	public VisualElement boneTransformAncestor; //Field offset: 0x18
	public VisualElement prevDirty; //Field offset: 0x20
	public VisualElement nextDirty; //Field offset: 0x28
	public RenderDataFlags flags; //Field offset: 0x30
	public int hierarchyDepth; //Field offset: 0x34
	public RenderDataDirtyTypes dirtiedValues; //Field offset: 0x38
	public uint dirtyID; //Field offset: 0x3C
	public RenderChainCommand firstHeadCommand; //Field offset: 0x40
	public RenderChainCommand lastHeadCommand; //Field offset: 0x48
	public RenderChainCommand firstTailCommand; //Field offset: 0x50
	public RenderChainCommand lastTailCommand; //Field offset: 0x58
	public bool localFlipsWinding; //Field offset: 0x60
	public bool localTransformScaleZero; //Field offset: 0x61
	public bool worldFlipsWinding; //Field offset: 0x62
	public bool worldTransformScaleZero; //Field offset: 0x63
	public ClipMethod clipMethod; //Field offset: 0x64
	public int childrenStencilRef; //Field offset: 0x68
	public int childrenMaskDepth; //Field offset: 0x6C
	public MeshHandle headMesh; //Field offset: 0x70
	public MeshHandle tailMesh; //Field offset: 0x78
	public Matrix4x4 verticesSpace; //Field offset: 0x80
	public BMPAlloc transformID; //Field offset: 0xC0
	public BMPAlloc clipRectID; //Field offset: 0xC8
	public BMPAlloc opacityID; //Field offset: 0xD0
	public BMPAlloc textCoreSettingsID; //Field offset: 0xD8
	public BMPAlloc colorID; //Field offset: 0xE0
	public BMPAlloc backgroundColorID; //Field offset: 0xE8
	public BMPAlloc borderLeftColorID; //Field offset: 0xF0
	public BMPAlloc borderTopColorID; //Field offset: 0xF8
	public BMPAlloc borderRightColorID; //Field offset: 0x100
	public BMPAlloc borderBottomColorID; //Field offset: 0x108
	public BMPAlloc tintColorID; //Field offset: 0x110
	public float compositeOpacity; //Field offset: 0x118
	public float backgroundAlpha; //Field offset: 0x11C
	public BasicNode<TextureEntry> textures; //Field offset: 0x120
	public bool pendingRepaint; //Field offset: 0x128
	public bool pendingHierarchicalRepaint; //Field offset: 0x129

	public bool hasExtraData
	{
		 get { } //Length: 9
	}

	public bool hasExtraMeshes
	{
		 get { } //Length: 9
	}

	public bool isGroupTransform
	{
		 get { } //Length: 8
	}

	public bool isIgnoringDynamicColorHint
	{
		 get { } //Length: 9
	}

	public bool isInChain
	{
		 get { } //Length: 7
	}

	public RenderChainCommand lastTailOrHeadCommand
	{
		 get { } //Length: 14
	}

	public static bool AllocatesID(BMPAlloc alloc) { }

	public bool get_hasExtraData() { }

	public bool get_hasExtraMeshes() { }

	public bool get_isGroupTransform() { }

	public bool get_isIgnoringDynamicColorHint() { }

	public bool get_isInChain() { }

	public RenderChainCommand get_lastTailOrHeadCommand() { }

	public static bool InheritsID(BMPAlloc alloc) { }

}

