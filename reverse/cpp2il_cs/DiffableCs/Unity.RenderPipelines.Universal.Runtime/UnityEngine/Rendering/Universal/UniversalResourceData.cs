namespace UnityEngine.Rendering.Universal;

public class UniversalResourceData : UniversalResourceDataBase
{
	[CompilerGenerated]
	private ActiveID <activeColorID>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private ActiveID <activeDepthID>k__BackingField; //Field offset: 0x1C
	private TextureHandle _backBufferColor; //Field offset: 0x20
	private TextureHandle _backBufferDepth; //Field offset: 0x30
	private TextureHandle _cameraColor; //Field offset: 0x40
	private TextureHandle _cameraDepth; //Field offset: 0x50
	private TextureHandle _mainShadowsTexture; //Field offset: 0x60
	private TextureHandle _additionalShadowsTexture; //Field offset: 0x70
	private TextureHandle[] _gBuffer; //Field offset: 0x80
	private TextureHandle _cameraOpaqueTexture; //Field offset: 0x88
	private TextureHandle _cameraDepthTexture; //Field offset: 0x98
	private TextureHandle _cameraNormalsTexture; //Field offset: 0xA8
	private TextureHandle _motionVectorColor; //Field offset: 0xB8
	private TextureHandle _motionVectorDepth; //Field offset: 0xC8
	private TextureHandle _internalColorLut; //Field offset: 0xD8
	internal TextureHandle _debugScreenColor; //Field offset: 0xE8
	internal TextureHandle _debugScreenDepth; //Field offset: 0xF8
	private TextureHandle _afterPostProcessColor; //Field offset: 0x108
	private TextureHandle _overlayUITexture; //Field offset: 0x118
	private TextureHandle _renderingLayersTexture; //Field offset: 0x128
	private TextureHandle[] _dBuffer; //Field offset: 0x138
	private TextureHandle _dBufferDepth; //Field offset: 0x140
	private TextureHandle _ssaoTexture; //Field offset: 0x150
	private TextureHandle _stpDebugView; //Field offset: 0x160

	internal ActiveID activeColorID
	{
		[CompilerGenerated]
		internal get { } //Length: 4
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	public TextureHandle activeColorTexture
	{
		 get { } //Length: 349
	}

	internal ActiveID activeDepthID
	{
		[CompilerGenerated]
		internal get { } //Length: 4
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	public TextureHandle activeDepthTexture
	{
		 get { } //Length: 349
	}

	public TextureHandle additionalShadowsTexture
	{
		 get { } //Length: 41
		 set { } //Length: 121
	}

	public internal TextureHandle afterPostProcessColor
	{
		 get { } //Length: 44
		internal set { } //Length: 124
	}

	public internal TextureHandle backBufferColor
	{
		 get { } //Length: 41
		internal set { } //Length: 121
	}

	public internal TextureHandle backBufferDepth
	{
		 get { } //Length: 41
		internal set { } //Length: 121
	}

	public TextureHandle cameraColor
	{
		 get { } //Length: 41
		 set { } //Length: 121
	}

	public TextureHandle cameraDepth
	{
		 get { } //Length: 41
		 set { } //Length: 121
	}

	public internal TextureHandle cameraDepthTexture
	{
		 get { } //Length: 44
		internal set { } //Length: 124
	}

	public internal TextureHandle cameraNormalsTexture
	{
		 get { } //Length: 44
		internal set { } //Length: 124
	}

	public internal TextureHandle cameraOpaqueTexture
	{
		 get { } //Length: 44
		internal set { } //Length: 124
	}

	public TextureHandle[] dBuffer
	{
		 get { } //Length: 15
		 set { } //Length: 18
	}

	public TextureHandle dBufferDepth
	{
		 get { } //Length: 44
		 set { } //Length: 124
	}

	internal TextureHandle debugScreenColor
	{
		internal get { } //Length: 44
		internal set { } //Length: 124
	}

	internal TextureHandle debugScreenDepth
	{
		internal get { } //Length: 44
		internal set { } //Length: 124
	}

	public TextureHandle[] gBuffer
	{
		 get { } //Length: 15
		 set { } //Length: 18
	}

	public TextureHandle internalColorLut
	{
		 get { } //Length: 44
		 set { } //Length: 124
	}

	public bool isActiveTargetBackBuffer
	{
		 get { } //Length: 111
	}

	public TextureHandle mainShadowsTexture
	{
		 get { } //Length: 41
		 set { } //Length: 121
	}

	public TextureHandle motionVectorColor
	{
		 get { } //Length: 44
		 set { } //Length: 124
	}

	public TextureHandle motionVectorDepth
	{
		 get { } //Length: 44
		 set { } //Length: 124
	}

	public internal TextureHandle overlayUITexture
	{
		 get { } //Length: 44
		internal set { } //Length: 124
	}

	public internal TextureHandle renderingLayersTexture
	{
		 get { } //Length: 44
		internal set { } //Length: 124
	}

	public internal TextureHandle ssaoTexture
	{
		 get { } //Length: 44
		internal set { } //Length: 124
	}

	internal TextureHandle stpDebugView
	{
		internal get { } //Length: 44
		internal set { } //Length: 124
	}

	public UniversalResourceData() { }

	[CompilerGenerated]
	internal ActiveID get_activeColorID() { }

	public TextureHandle get_activeColorTexture() { }

	[CompilerGenerated]
	internal ActiveID get_activeDepthID() { }

	public TextureHandle get_activeDepthTexture() { }

	public TextureHandle get_additionalShadowsTexture() { }

	public TextureHandle get_afterPostProcessColor() { }

	public TextureHandle get_backBufferColor() { }

	public TextureHandle get_backBufferDepth() { }

	public TextureHandle get_cameraColor() { }

	public TextureHandle get_cameraDepth() { }

	public TextureHandle get_cameraDepthTexture() { }

	public TextureHandle get_cameraNormalsTexture() { }

	public TextureHandle get_cameraOpaqueTexture() { }

	public TextureHandle[] get_dBuffer() { }

	public TextureHandle get_dBufferDepth() { }

	internal TextureHandle get_debugScreenColor() { }

	internal TextureHandle get_debugScreenDepth() { }

	public TextureHandle[] get_gBuffer() { }

	public TextureHandle get_internalColorLut() { }

	public bool get_isActiveTargetBackBuffer() { }

	public TextureHandle get_mainShadowsTexture() { }

	public TextureHandle get_motionVectorColor() { }

	public TextureHandle get_motionVectorDepth() { }

	public TextureHandle get_overlayUITexture() { }

	public TextureHandle get_renderingLayersTexture() { }

	public TextureHandle get_ssaoTexture() { }

	internal TextureHandle get_stpDebugView() { }

	public virtual void Reset() { }

	[CompilerGenerated]
	internal void set_activeColorID(ActiveID value) { }

	[CompilerGenerated]
	internal void set_activeDepthID(ActiveID value) { }

	public void set_additionalShadowsTexture(TextureHandle value) { }

	internal void set_afterPostProcessColor(TextureHandle value) { }

	internal void set_backBufferColor(TextureHandle value) { }

	internal void set_backBufferDepth(TextureHandle value) { }

	public void set_cameraColor(TextureHandle value) { }

	public void set_cameraDepth(TextureHandle value) { }

	internal void set_cameraDepthTexture(TextureHandle value) { }

	internal void set_cameraNormalsTexture(TextureHandle value) { }

	internal void set_cameraOpaqueTexture(TextureHandle value) { }

	public void set_dBuffer(TextureHandle[] value) { }

	public void set_dBufferDepth(TextureHandle value) { }

	internal void set_debugScreenColor(TextureHandle value) { }

	internal void set_debugScreenDepth(TextureHandle value) { }

	public void set_gBuffer(TextureHandle[] value) { }

	public void set_internalColorLut(TextureHandle value) { }

	public void set_mainShadowsTexture(TextureHandle value) { }

	public void set_motionVectorColor(TextureHandle value) { }

	public void set_motionVectorDepth(TextureHandle value) { }

	internal void set_overlayUITexture(TextureHandle value) { }

	internal void set_renderingLayersTexture(TextureHandle value) { }

	internal void set_ssaoTexture(TextureHandle value) { }

	internal void set_stpDebugView(TextureHandle value) { }

}

