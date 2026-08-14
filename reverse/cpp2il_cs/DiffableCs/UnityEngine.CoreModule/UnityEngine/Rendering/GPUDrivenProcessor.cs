namespace UnityEngine.Rendering;

[NativeHeader("Runtime/Camera/GPUDrivenProcessor.h")]
[RequiredByNativeCode]
internal class GPUDrivenProcessor
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal void <.cctor>b__34_0(in GPUDrivenRendererGroupDataNative nativeData, List<Mesh> meshes, List<Material> materials, GPUDrivenRendererDataCallback callback) { }

		internal void <.cctor>b__34_1(in GPUDrivenLODGroupDataNative nativeData, GPUDrivenLODGroupDataCallback callback) { }

	}

	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(GPUDrivenProcessor obj) { }

	}

	private static GPUDrivenRendererDataNativeCallback s_NativeRendererCallback; //Field offset: 0x0
	private static GPUDrivenLODGroupDataNativeCallback s_NativeLODGroupCallback; //Field offset: 0x8
	internal IntPtr m_Ptr; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private List<Mesh> <scratchMeshes>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private List<Material> <scratchMaterials>k__BackingField; //Field offset: 0x20

	public bool enablePartialRendering
	{
		 set { } //Length: 155
	}

	internal List<Material> scratchMaterials
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	internal List<Mesh> scratchMeshes
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	private static GPUDrivenProcessor() { }

	public GPUDrivenProcessor() { }

	public void ClearMaterialFilters() { }

	private static void ClearMaterialFilters_Injected(IntPtr _unity_self) { }

	private void Destroy() { }

	public void DisableGPUDrivenRendering(ReadOnlySpan<Int32> renderersID) { }

	private static void DisableGPUDrivenRendering_Injected(IntPtr _unity_self, ref ManagedSpanWrapper renderersID) { }

	private void DispatchLODGroupData(ReadOnlySpan<Int32> lodGroupID, GPUDrivenLODGroupDataNativeCallback callback, GPUDrivenLODGroupDataCallback param) { }

	public void DispatchLODGroupData(ReadOnlySpan<Int32> lodGroupID, GPUDrivenLODGroupDataCallback callback) { }

	private static void DispatchLODGroupData_Injected(IntPtr _unity_self, ref ManagedSpanWrapper lodGroupID, GPUDrivenLODGroupDataNativeCallback callback, GPUDrivenLODGroupDataCallback param) { }

	public void Dispose() { }

	private void EnableGPUDrivenRenderingAndDispatchRendererData(ReadOnlySpan<Int32> renderersID, GPUDrivenRendererDataNativeCallback callback, List<Mesh> meshes, List<Material> materials, GPUDrivenRendererDataCallback param) { }

	public void EnableGPUDrivenRenderingAndDispatchRendererData(ReadOnlySpan<Int32> renderersID, GPUDrivenRendererDataCallback callback) { }

	private static void EnableGPUDrivenRenderingAndDispatchRendererData_Injected(IntPtr _unity_self, ref ManagedSpanWrapper renderersID, GPUDrivenRendererDataNativeCallback callback, List<Mesh> meshes, List<Material> materials, GPUDrivenRendererDataCallback param) { }

	protected virtual void Finalize() { }

	public static int FindUnsupportedMaterialIDs(NativeArray<Int32> materialIDs, NativeArray<Int32> unsupportedMaterialIDs) { }

	[FreeFunction("GPUDrivenProcessor::FindUnsupportedMaterials", IsThreadSafe = True)]
	private static int FindUnsupportedMaterialsImpl(ReadOnlySpan<Int32> materialIDs, Span<Int32> unsupportedMaterialIDs) { }

	private static int FindUnsupportedMaterialsImpl_Injected(ref ManagedSpanWrapper materialIDs, ref ManagedSpanWrapper unsupportedMaterialIDs) { }

	[CompilerGenerated]
	internal List<Material> get_scratchMaterials() { }

	[CompilerGenerated]
	internal List<Mesh> get_scratchMeshes() { }

	private static IntPtr Internal_Create() { }

	private static void Internal_Destroy(IntPtr ptr) { }

	public void set_enablePartialRendering(bool value) { }

	private static void set_enablePartialRendering_Injected(IntPtr _unity_self, bool value) { }

	[CompilerGenerated]
	private void set_scratchMaterials(List<Material> value) { }

	[CompilerGenerated]
	private void set_scratchMeshes(List<Mesh> value) { }

}

