namespace UnityEngine.Rendering;

[NativeHeader("Modules/UI/CanvasManager.h")]
[NativeHeader("Modules/UI/Canvas.h")]
[NativeHeader("Runtime/Export/RenderPipeline/ScriptableRenderPipeline.bindings.h")]
[NativeHeader("Runtime/Graphics/ScriptableRenderLoop/ScriptableDrawRenderersUtility.h")]
[NativeHeader("Runtime/Export/RenderPipeline/ScriptableRenderContext.bindings.h")]
[NativeType("Runtime/Graphics/ScriptableRenderLoop/ScriptableRenderContext.h")]
public struct ScriptableRenderContext : IEquatable<ScriptableRenderContext>
{
	private struct CullShadowCastersContext
	{
		public IntPtr cullResults; //Field offset: 0x0
		public ShadowSplitData* splitBuffer; //Field offset: 0x8
		public int splitBufferLength; //Field offset: 0x10
		public LightShadowCasterCullingInfo* perLightInfos; //Field offset: 0x18
		public int perLightInfoCount; //Field offset: 0x20

	}

	private static readonly ShaderTagId kRenderTypeTag; //Field offset: 0x0
	private IntPtr m_Ptr; //Field offset: 0x0

	private static ScriptableRenderContext() { }

	internal ScriptableRenderContext(IntPtr ptr) { }

	public void BeginRenderPass(int width, int height, int samples, NativeArray<AttachmentDescriptor> attachments, int depthAttachmentIndex = -1) { }

	[FreeFunction("ScriptableRenderContext::BeginRenderPass")]
	private static void BeginRenderPass_Internal(IntPtr self, int width, int height, int volumeDepth, int samples, IntPtr colors, int colorCount, int depthAttachmentIndex) { }

	public void BeginSubPass(NativeArray<Int32> colors, bool isDepthStencilReadOnly = false) { }

	public void BeginSubPass(NativeArray<Int32> colors, NativeArray<Int32> inputs, bool isDepthStencilReadOnly = false) { }

	[FreeFunction("ScriptableRenderContext::BeginSubPass")]
	private static void BeginSubPass_Internal(IntPtr self, IntPtr colors, int colorCount, IntPtr inputs, int inputCount, bool isDepthReadOnly, bool isStencilReadOnly) { }

	public RendererList CreateGizmoRendererList(Camera camera, GizmoSubset gizmoSubset) { }

	private RendererList CreateGizmoRendererList_Internal(Camera camera, GizmoSubset gizmoSubset) { }

	private static void CreateGizmoRendererList_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr camera, GizmoSubset gizmoSubset, out RendererList ret) { }

	public RendererList CreateRendererList(ref RendererListParams param) { }

	private RendererList CreateRendererList_Internal(IntPtr cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ShaderTagId tagName, bool isPassTagName, IntPtr tagValues, IntPtr stateBlocks, int stateCount) { }

	private static void CreateRendererList_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, in ShaderTagId tagName, bool isPassTagName, IntPtr tagValues, IntPtr stateBlocks, int stateCount, out RendererList ret) { }

	public RendererList CreateShadowRendererList(ref ShadowDrawingSettings settings) { }

	private RendererList CreateShadowRendererList_Internal(IntPtr shadowDrawinSettings) { }

	private static void CreateShadowRendererList_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr shadowDrawinSettings, out RendererList ret) { }

	public RendererList CreateSkyboxRendererList(Camera camera, Matrix4x4 projectionMatrixL, Matrix4x4 viewMatrixL, Matrix4x4 projectionMatrixR, Matrix4x4 viewMatrixR) { }

	public RendererList CreateSkyboxRendererList(Camera camera) { }

	public RendererList CreateSkyboxRendererList(Camera camera, Matrix4x4 projectionMatrix, Matrix4x4 viewMatrix) { }

	private RendererList CreateSkyboxRendererList_Internal(Camera camera, int mode, Matrix4x4 proj, Matrix4x4 view, Matrix4x4 projR, Matrix4x4 viewR) { }

	private static void CreateSkyboxRendererList_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr camera, int mode, in Matrix4x4 proj, in Matrix4x4 view, in Matrix4x4 projR, in Matrix4x4 viewR, out RendererList ret) { }

	public RendererList CreateUIOverlayRendererList(Camera camera, UISubset uiSubset) { }

	public RendererList CreateUIOverlayRendererList(Camera camera) { }

	private RendererList CreateUIOverlayRendererList_Internal(Camera camera, UISubset uiSubset) { }

	private static void CreateUIOverlayRendererList_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr camera, UISubset uiSubset, out RendererList ret) { }

	public RendererList CreateWireOverlayRendererList(Camera camera) { }

	private RendererList CreateWireOverlayRendererList_Internal(Camera camera) { }

	private static void CreateWireOverlayRendererList_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr camera, out RendererList ret) { }

	public CullingResults Cull(ref ScriptableCullingParameters parameters) { }

	public void CullShadowCasters(CullingResults cullingResults, ShadowCastersCullingInfos infos) { }

	public void DrawWireOverlay(Camera camera) { }

	private void DrawWireOverlay_Impl(Camera camera) { }

	private static void DrawWireOverlay_Impl_Injected(ref ScriptableRenderContext _unity_self, IntPtr camera) { }

	[FreeFunction("PlayerEmitCanvasGeometryForCamera")]
	public static void EmitGeometryForCamera(Camera camera) { }

	private static void EmitGeometryForCamera_Injected(IntPtr camera) { }

	public void EndRenderPass() { }

	[FreeFunction("ScriptableRenderContext::EndRenderPass")]
	private static void EndRenderPass_Internal(IntPtr self) { }

	public void EndSubPass() { }

	[FreeFunction("ScriptableRenderContext::EndSubPass")]
	private static void EndSubPass_Internal(IntPtr self) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(ScriptableRenderContext other) { }

	public void ExecuteCommandBuffer(CommandBuffer commandBuffer) { }

	[NativeThrows]
	private void ExecuteCommandBuffer_Internal(CommandBuffer commandBuffer) { }

	private static void ExecuteCommandBuffer_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr commandBuffer) { }

	public void ExecuteCommandBufferAsync(CommandBuffer commandBuffer, ComputeQueueType queueType) { }

	[NativeThrows]
	private void ExecuteCommandBufferAsync_Internal(CommandBuffer commandBuffer, ComputeQueueType queueType) { }

	private static void ExecuteCommandBufferAsync_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr commandBuffer, ComputeQueueType queueType) { }

	internal void GetCameras(List<Camera> results) { }

	private void GetCameras_Internal(Type listType, object resultList) { }

	public virtual int GetHashCode() { }

	public bool HasInvokeOnRenderObjectCallbacks() { }

	[FreeFunction("ScriptableRenderContext::HasInvokeOnRenderObjectCallbacks")]
	private static bool HasInvokeOnRenderObjectCallbacks_Internal() { }

	[FreeFunction("InitializeSortSettings")]
	internal static void InitializeSortSettings(Camera camera, out SortingSettings sortingSettings) { }

	private static void InitializeSortSettings_Injected(IntPtr camera, out SortingSettings sortingSettings) { }

	[FreeFunction("ScriptableRenderPipeline_Bindings::Internal_Cull")]
	private static void Internal_Cull(ref ScriptableCullingParameters parameters, ScriptableRenderContext renderLoop, IntPtr results) { }

	private static void Internal_Cull_Injected(ref ScriptableCullingParameters parameters, in ScriptableRenderContext renderLoop, IntPtr results) { }

	[FreeFunction("ScriptableRenderPipeline_Bindings::Internal_CullShadowCasters")]
	private static void Internal_CullShadowCasters(ScriptableRenderContext renderLoop, IntPtr context) { }

	private static void Internal_CullShadowCasters_Injected(in ScriptableRenderContext renderLoop, IntPtr context) { }

	internal IntPtr Internal_GetPtr() { }

	public void PrepareRendererListsAsync(List<RendererList> rendererLists) { }

	private void PrepareRendererListsAsync_Internal(object rendererLists) { }

	public RendererListStatus QueryRendererListStatus(RendererList rendererList) { }

	private RendererListStatus QueryRendererListStatus_Internal(RendererList handle) { }

	private static RendererListStatus QueryRendererListStatus_Internal_Injected(ref ScriptableRenderContext _unity_self, in RendererList handle) { }

	public void SetupCameraProperties(Camera camera, bool stereoSetup, int eye) { }

	public void SetupCameraProperties(Camera camera, bool stereoSetup = false) { }

	private void SetupCameraProperties_Internal(Camera camera, bool stereoSetup, int eye) { }

	private static void SetupCameraProperties_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr camera, bool stereoSetup, int eye) { }

	public void Submit() { }

	private void Submit_Internal() { }

	public bool SubmitForRenderPassValidation() { }

	private bool SubmitForRenderPassValidation_Internal() { }

}

