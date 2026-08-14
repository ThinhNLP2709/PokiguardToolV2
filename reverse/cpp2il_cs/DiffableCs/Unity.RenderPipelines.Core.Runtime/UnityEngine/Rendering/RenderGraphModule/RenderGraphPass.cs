namespace UnityEngine.Rendering.RenderGraphModule;

[DebuggerDisplay("RenderPass: {name} (Index:{index} Async:{enableAsyncCompute})")]
internal abstract class RenderGraphPass
{
	internal struct RandomWriteResourceInfo
	{
		public ResourceHandle h; //Field offset: 0x0
		public bool preserveCounterValue; //Field offset: 0xC

	}

	[CompilerGenerated]
	private string <name>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private int <index>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private RenderGraphPassType <type>k__BackingField; //Field offset: 0x1C
	[CompilerGenerated]
	private ProfilingSampler <customSampler>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private bool <enableAsyncCompute>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private bool <allowPassCulling>k__BackingField; //Field offset: 0x29
	[CompilerGenerated]
	private bool <allowGlobalState>k__BackingField; //Field offset: 0x2A
	[CompilerGenerated]
	private bool <enableFoveatedRasterization>k__BackingField; //Field offset: 0x2B
	[CompilerGenerated]
	private TextureAccess <depthAccess>k__BackingField; //Field offset: 0x2C
	[CompilerGenerated]
	private TextureAccess[] <colorBufferAccess>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private int <colorBufferMaxIndex>k__BackingField; //Field offset: 0x50
	[CompilerGenerated]
	private TextureAccess[] <fragmentInputAccess>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private int <fragmentInputMaxIndex>k__BackingField; //Field offset: 0x60
	[CompilerGenerated]
	private RandomWriteResourceInfo[] <randomAccessResource>k__BackingField; //Field offset: 0x68
	[CompilerGenerated]
	private int <randomAccessResourceMaxIndex>k__BackingField; //Field offset: 0x70
	[CompilerGenerated]
	private bool <generateDebugData>k__BackingField; //Field offset: 0x74
	[CompilerGenerated]
	private bool <allowRendererListCulling>k__BackingField; //Field offset: 0x75
	public List<ResourceHandle>[] resourceReadLists; //Field offset: 0x78
	public List<ResourceHandle>[] resourceWriteLists; //Field offset: 0x80
	public List<ResourceHandle>[] transientResourceList; //Field offset: 0x88
	public List<RendererListHandle> usedRendererListList; //Field offset: 0x90
	public List<ValueTuple`2<TextureHandle, Int32>> setGlobalsList; //Field offset: 0x98
	public bool useAllGlobalTextures; //Field offset: 0xA0
	public List<ResourceHandle> implicitReadsList; //Field offset: 0xA8

	public bool allowGlobalState
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 170
	}

	public bool allowPassCulling
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool allowRendererListCulling
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public TextureAccess[] colorBufferAccess
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public int colorBufferMaxIndex
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public ProfilingSampler customSampler
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public TextureAccess depthAccess
	{
		[CompilerGenerated]
		 get { } //Length: 27
		[CompilerGenerated]
		 set { } //Length: 24
	}

	public bool enableAsyncCompute
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool enableFoveatedRasterization
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public TextureAccess[] fragmentInputAccess
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public int fragmentInputMaxIndex
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool generateDebugData
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public int index
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public string name
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public RandomWriteResourceInfo[] randomAccessResource
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public int randomAccessResourceMaxIndex
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public internal RenderGraphPassType type
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	public RenderGraphPass() { }

	public void AddResourceRead(in ResourceHandle res) { }

	public void AddResourceWrite(in ResourceHandle res) { }

	public void AddTransientResource(in ResourceHandle res) { }

	public void AllowGlobalState(bool value) { }

	public void AllowPassCulling(bool value) { }

	public void AllowRendererListCulling(bool value) { }

	public void Clear() { }

	public void ComputeHash(ref HashFNV1A32 generator, RenderGraphResourceRegistry resources) { }

	private static void ComputeHashForTextureAccess(ref HashFNV1A32 generator, in ResourceHandle handle, in TextureAccess textureAccess) { }

	private void ComputeTextureHash(ref HashFNV1A32 generator, in ResourceHandle handle, RenderGraphResourceRegistry resources) { }

	public void EnableAsyncCompute(bool value) { }

	public void EnableFoveatedRasterization(bool value) { }

	public abstract void Execute(InternalRenderGraphContext renderGraphContext) { }

	public void GenerateDebugData(bool value) { }

	[CompilerGenerated]
	public bool get_allowGlobalState() { }

	[CompilerGenerated]
	public bool get_allowPassCulling() { }

	[CompilerGenerated]
	public bool get_allowRendererListCulling() { }

	[CompilerGenerated]
	public TextureAccess[] get_colorBufferAccess() { }

	[CompilerGenerated]
	public int get_colorBufferMaxIndex() { }

	[CompilerGenerated]
	public ProfilingSampler get_customSampler() { }

	[CompilerGenerated]
	public TextureAccess get_depthAccess() { }

	[CompilerGenerated]
	public bool get_enableAsyncCompute() { }

	[CompilerGenerated]
	public bool get_enableFoveatedRasterization() { }

	[CompilerGenerated]
	public TextureAccess[] get_fragmentInputAccess() { }

	[CompilerGenerated]
	public int get_fragmentInputMaxIndex() { }

	[CompilerGenerated]
	public bool get_generateDebugData() { }

	[CompilerGenerated]
	public int get_index() { }

	[CompilerGenerated]
	public string get_name() { }

	[CompilerGenerated]
	public RandomWriteResourceInfo[] get_randomAccessResource() { }

	[CompilerGenerated]
	public int get_randomAccessResourceMaxIndex() { }

	[CompilerGenerated]
	public RenderGraphPassType get_type() { }

	public abstract int GetRenderFuncHash() { }

	public bool HasRenderAttachments() { }

	public abstract bool HasRenderFunc() { }

	public bool IsAttachment(in TextureHandle res) { }

	public bool IsRead(in ResourceHandle res) { }

	public bool IsTransient(in ResourceHandle res) { }

	public bool IsWritten(in ResourceHandle res) { }

	public abstract void Release(RenderGraphObjectPool pool) { }

	[CompilerGenerated]
	protected void set_allowGlobalState(bool value) { }

	[CompilerGenerated]
	protected void set_allowPassCulling(bool value) { }

	[CompilerGenerated]
	protected void set_allowRendererListCulling(bool value) { }

	[CompilerGenerated]
	protected void set_colorBufferAccess(TextureAccess[] value) { }

	[CompilerGenerated]
	protected void set_colorBufferMaxIndex(int value) { }

	[CompilerGenerated]
	protected void set_customSampler(ProfilingSampler value) { }

	[CompilerGenerated]
	protected void set_depthAccess(TextureAccess value) { }

	[CompilerGenerated]
	protected void set_enableAsyncCompute(bool value) { }

	[CompilerGenerated]
	protected void set_enableFoveatedRasterization(bool value) { }

	[CompilerGenerated]
	protected void set_fragmentInputAccess(TextureAccess[] value) { }

	[CompilerGenerated]
	protected void set_fragmentInputMaxIndex(int value) { }

	[CompilerGenerated]
	protected void set_generateDebugData(bool value) { }

	[CompilerGenerated]
	protected void set_index(int value) { }

	[CompilerGenerated]
	protected void set_name(string value) { }

	[CompilerGenerated]
	protected void set_randomAccessResource(RandomWriteResourceInfo[] value) { }

	[CompilerGenerated]
	protected void set_randomAccessResourceMaxIndex(int value) { }

	[CompilerGenerated]
	internal void set_type(RenderGraphPassType value) { }

	public void SetColorBuffer(in TextureHandle resource, int index) { }

	public void SetColorBufferRaw(in TextureHandle resource, int index, AccessFlags accessFlags, int mipLevel, int depthSlice) { }

	public void SetDepthBuffer(in TextureHandle resource, DepthAccess flags) { }

	public void SetDepthBufferRaw(in TextureHandle resource, AccessFlags accessFlags, int mipLevel, int depthSlice) { }

	public void SetFragmentInputRaw(in TextureHandle resource, int index, AccessFlags accessFlags, int mipLevel, int depthSlice) { }

	public void SetRandomWriteResourceRaw(in ResourceHandle resource, int index, bool preserveCounterValue, AccessFlags accessFlags) { }

	public void UseRendererList(in RendererListHandle rendererList) { }

}

