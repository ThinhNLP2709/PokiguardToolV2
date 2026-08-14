namespace UnityEngine.Rendering;

public struct AttachmentDescriptor : IEquatable<AttachmentDescriptor>
{
	private RenderBufferLoadAction m_LoadAction; //Field offset: 0x0
	private RenderBufferStoreAction m_StoreAction; //Field offset: 0x4
	private GraphicsFormat m_Format; //Field offset: 0x8
	private RenderTargetIdentifier m_LoadStoreTarget; //Field offset: 0x10
	private RenderTargetIdentifier m_ResolveTarget; //Field offset: 0x38
	private Color m_ClearColor; //Field offset: 0x60
	private float m_ClearDepth; //Field offset: 0x70
	private uint m_ClearStencil; //Field offset: 0x74

	public Color clearColor
	{
		 set { } //Length: 8
	}

	public float clearDepth
	{
		 set { } //Length: 6
	}

	public uint clearStencil
	{
		 set { } //Length: 4
	}

	public GraphicsFormat graphicsFormat
	{
		 get { } //Length: 6
	}

	public RenderBufferLoadAction loadAction
	{
		 set { } //Length: 3
	}

	public RenderTargetIdentifier loadStoreTarget
	{
		 get { } //Length: 29
		 set { } //Length: 26
	}

	public RenderTargetIdentifier resolveTarget
	{
		 set { } //Length: 26
	}

	public RenderBufferStoreAction storeAction
	{
		 set { } //Length: 4
	}

	public AttachmentDescriptor(GraphicsFormat format) { }

	public void ConfigureClear(Color clearColor, float clearDepth = 1, uint clearStencil = 0) { }

	public void ConfigureResolveTarget(RenderTargetIdentifier target) { }

	public void ConfigureTarget(RenderTargetIdentifier target, bool loadExistingContents, bool storeResults) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(AttachmentDescriptor other) { }

	public GraphicsFormat get_graphicsFormat() { }

	public RenderTargetIdentifier get_loadStoreTarget() { }

	public virtual int GetHashCode() { }

	public static bool op_Inequality(AttachmentDescriptor left, AttachmentDescriptor right) { }

	public void set_clearColor(Color value) { }

	public void set_clearDepth(float value) { }

	public void set_clearStencil(uint value) { }

	public void set_loadAction(RenderBufferLoadAction value) { }

	public void set_loadStoreTarget(RenderTargetIdentifier value) { }

	public void set_resolveTarget(RenderTargetIdentifier value) { }

	public void set_storeAction(RenderBufferStoreAction value) { }

}

