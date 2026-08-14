namespace UnityEngine.Rendering.RenderGraphModule;

internal class RenderGraphResourceRegistry
{
	private class RenderGraphResourcesData
	{
		public DynamicArray<IRenderGraphResource> resourceArray; //Field offset: 0x10
		public int sharedResourcesCount; //Field offset: 0x18
		public IRenderGraphResourcePool pool; //Field offset: 0x20
		public ResourceCreateCallback createResourceCallback; //Field offset: 0x28
		public ResourceCallback releaseResourceCallback; //Field offset: 0x30

		public RenderGraphResourcesData() { }

		public int AddNewRenderGraphResource(out ResType outRes, bool pooledResource = true) { }

		public void Cleanup() { }

		public void Clear(bool onException, int frameIndex) { }

		public void PurgeUnusedGraphicsResources(int frameIndex) { }

	}

	private sealed class ResourceCallback : MulticastDelegate
	{

		public ResourceCallback(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(InternalRenderGraphContext rgContext, IRenderGraphResource res, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(InternalRenderGraphContext rgContext, IRenderGraphResource res) { }

	}

	private sealed class ResourceCreateCallback : MulticastDelegate
	{

		public ResourceCreateCallback(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(InternalRenderGraphContext rgContext, IRenderGraphResource res, AsyncCallback callback, object object) { }

		public override bool EndInvoke(IAsyncResult result) { }

		public override bool Invoke(InternalRenderGraphContext rgContext, IRenderGraphResource res) { }

	}

	private const int kSharedResourceLifetime = 30; //Field offset: 0x0
	private static RenderGraphResourceRegistry m_CurrentRegistry; //Field offset: 0x0
	private const int kInitialRendererListCount = 256; //Field offset: 0x0
	private static RenderTargetIdentifier emptyId; //Field offset: 0x8
	private static RenderTargetIdentifier builtinCameraRenderTarget; //Field offset: 0x30
	private RenderGraphResourcesData[] m_RenderGraphResources; //Field offset: 0x10
	private DynamicArray<RendererListResource> m_RendererListResources; //Field offset: 0x18
	private DynamicArray<RendererListLegacyResource> m_RendererListLegacyResources; //Field offset: 0x20
	private RenderGraphDebugParams m_RenderGraphDebug; //Field offset: 0x28
	private RenderGraphLogger m_ResourceLogger; //Field offset: 0x30
	private RenderGraphLogger m_FrameInformationLogger; //Field offset: 0x38
	private int m_CurrentFrameIndex; //Field offset: 0x40
	private int m_ExecutionCount; //Field offset: 0x44
	private RTHandle m_CurrentBackbuffer; //Field offset: 0x48
	private List<RendererList> m_ActiveRendererLists; //Field offset: 0x50
	internal bool forceManualClearOfResource; //Field offset: 0x58

	internal static RenderGraphResourceRegistry current
	{
		internal get { } //Length: 78
		internal set { } //Length: 105
	}

	private static RenderGraphResourceRegistry() { }

	internal RenderGraphResourceRegistry(RenderGraphDebugParams renderGraphDebug, RenderGraphLogger frameInformationLogger) { }

	private RenderGraphResourceRegistry() { }

	internal void BeginExecute(int currentFrameIndex) { }

	internal void BeginRenderGraph(int executionCount) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	private void CheckBufferResource(BufferResource bufferResource) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	private void CheckHandleValidity(in ResourceHandle res) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	private void CheckHandleValidity(RenderGraphResourceType type, int index) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	private void CheckTextureResource(TextureResource texResource) { }

	internal void Cleanup() { }

	internal void Clear(bool onException) { }

	internal BufferHandle CreateBuffer(in BufferDesc desc, int transientPassIndex = -1) { }

	internal RendererListHandle CreateGizmoRendererList(ScriptableRenderContext context, in Camera camera, in GizmoSubset gizmoSubset) { }

	internal bool CreatePooledResource(InternalRenderGraphContext rgContext, in ResourceHandle handle) { }

	internal bool CreatePooledResource(InternalRenderGraphContext rgContext, int type, int index) { }

	internal RendererListHandle CreateRendererList(in RendererListDesc desc) { }

	internal RendererListHandle CreateRendererList(in RendererListParams desc) { }

	internal void CreateRendererLists(List<RendererListHandle> rendererLists, ScriptableRenderContext context, bool manualDispatch = false) { }

	internal RendererListHandle CreateShadowRendererList(ScriptableRenderContext context, ref ShadowDrawingSettings shadowDrawinSettings) { }

	internal TextureHandle CreateSharedTexture(in TextureDesc desc, bool explicitRelease) { }

	internal RendererListHandle CreateSkyboxRendererList(ScriptableRenderContext context, in Camera camera) { }

	internal RendererListHandle CreateSkyboxRendererList(ScriptableRenderContext context, in Camera camera, Matrix4x4 projectionMatrixL, Matrix4x4 viewMatrixL, Matrix4x4 projectionMatrixR, Matrix4x4 viewMatrixR) { }

	internal RendererListHandle CreateSkyboxRendererList(ScriptableRenderContext context, in Camera camera, Matrix4x4 projectionMatrix, Matrix4x4 viewMatrix) { }

	internal TextureHandle CreateTexture(in TextureDesc desc, int transientPassIndex = -1) { }

	private bool CreateTextureCallback(InternalRenderGraphContext rgContext, IRenderGraphResource res) { }

	internal RendererListHandle CreateUIOverlayRendererList(ScriptableRenderContext context, in Camera camera, in UISubset uiSubset) { }

	internal RendererListHandle CreateWireOverlayRendererList(ScriptableRenderContext context, in Camera camera) { }

	internal void EndExecute() { }

	internal void FlushLogs() { }

	internal static RenderGraphResourceRegistry get_current() { }

	internal GraphicsBuffer GetBuffer(int index) { }

	internal GraphicsBuffer GetBuffer(in BufferHandle handle) { }

	private BufferResource GetBufferResource(int index) { }

	private BufferResource GetBufferResource(in ResourceHandle handle) { }

	internal int GetBufferResourceCount() { }

	internal BufferDesc GetBufferResourceDesc(in ResourceHandle handle, bool noThrowOnInvalidDesc = false) { }

	internal GraphicsFormat GetFormat(GraphicsFormat color, GraphicsFormat depthStencil) { }

	internal ResourceHandle GetLatestVersionHandle(in ResourceHandle res) { }

	internal int GetLatestVersionNumber(in ResourceHandle res) { }

	internal ResourceHandle GetNewVersionedHandle(in ResourceHandle res) { }

	internal RayTracingAccelerationStructure GetRayTracingAccelerationStructure(in RayTracingAccelerationStructureHandle handle) { }

	private RayTracingAccelerationStructureResource GetRayTracingAccelerationStructureResource(in ResourceHandle handle) { }

	internal int GetRayTracingAccelerationStructureResourceCount() { }

	internal RendererList GetRendererList(in RendererListHandle handle) { }

	internal string GetRenderGraphResourceName(in ResourceHandle res) { }

	internal string GetRenderGraphResourceName(RenderGraphResourceType type, int index) { }

	internal int GetRenderGraphResourceTransientIndex(in ResourceHandle res) { }

	internal void GetRenderTargetInfo(in ResourceHandle res, out RenderTargetInfo outInfo) { }

	internal int GetResourceCount(RenderGraphResourceType type) { }

	internal IRenderGraphResource GetResourceLowLevel(in ResourceHandle res) { }

	internal int GetSharedResourceCount(RenderGraphResourceType type) { }

	internal RTHandle GetTexture(in TextureHandle handle) { }

	internal RTHandle GetTexture(int index) { }

	internal TextureResource GetTextureResource(in ResourceHandle handle) { }

	internal TextureResource GetTextureResource(int index) { }

	internal int GetTextureResourceCount() { }

	internal TextureDesc GetTextureResourceDesc(in ResourceHandle handle, bool noThrowOnInvalidDesc = false) { }

	internal ResourceHandle GetZeroVersionedHandle(in ResourceHandle res) { }

	internal TextureHandle ImportBackbuffer(RenderTargetIdentifier rt, in RenderTargetInfo info, in ImportResourceParams importParams) { }

	internal BufferHandle ImportBuffer(GraphicsBuffer graphicsBuffer, bool forceRelease = false) { }

	internal RayTracingAccelerationStructureHandle ImportRayTracingAccelerationStructure(in RayTracingAccelerationStructure accelStruct, string name) { }

	internal TextureHandle ImportTexture(in RTHandle rt, RenderTargetInfo info, in ImportResourceParams importParams) { }

	internal TextureHandle ImportTexture(in RTHandle rt, bool isBuiltin = false) { }

	internal TextureHandle ImportTexture(in RTHandle rt, in ImportResourceParams importParams, bool isBuiltin = false) { }

	internal void IncrementWriteCount(in ResourceHandle res) { }

	internal bool IsGraphicsResourceCreated(in ResourceHandle res) { }

	internal bool IsRendererListCreated(in RendererListHandle res) { }

	internal bool IsRenderGraphResourceForceReleased(RenderGraphResourceType type, int index) { }

	internal bool IsRenderGraphResourceImported(RenderGraphResourceType type, int index) { }

	internal bool IsRenderGraphResourceImported(in ResourceHandle res) { }

	internal bool IsRenderGraphResourceShared(RenderGraphResourceType type, int index) { }

	internal bool IsRenderGraphResourceShared(in ResourceHandle res) { }

	private void LogResources() { }

	private void ManageSharedRenderGraphResources() { }

	internal void NewVersion(in ResourceHandle res) { }

	internal void PurgeUnusedGraphicsResources() { }

	internal void RefreshSharedTextureDesc(in TextureHandle texture, in TextureDesc desc) { }

	internal void ReleasePooledResource(InternalRenderGraphContext rgContext, int type, int index) { }

	internal void ReleasePooledResource(InternalRenderGraphContext rgContext, in ResourceHandle handle) { }

	internal void ReleaseSharedTexture(in TextureHandle texture) { }

	private void ReleaseTextureCallback(InternalRenderGraphContext rgContext, IRenderGraphResource res) { }

	internal static void set_current(RenderGraphResourceRegistry value) { }

	internal bool TextureNeedsFallback(in TextureHandle handle) { }

	internal void UpdateSharedResourceLastFrameIndex(int type, int index) { }

	internal void UpdateSharedResourceLastFrameIndex(in ResourceHandle handle) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	private void ValidateBufferDesc(in BufferDesc desc) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	internal void ValidateFormat(GraphicsFormat color, GraphicsFormat depthStencil) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	private void ValidateRendererListDesc(in RendererListDesc desc) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	private void ValidateRenderTarget(in ResourceHandle res) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	private void ValidateTextureDesc(in TextureDesc desc) { }

}

