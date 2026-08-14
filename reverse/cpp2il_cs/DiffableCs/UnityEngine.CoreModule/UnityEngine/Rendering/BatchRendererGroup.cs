namespace UnityEngine.Rendering;

[NativeHeader("Runtime/Camera/BatchRendererGroup.h")]
[NativeHeader("Runtime/Math/Matrix4x4.h")]
[RequiredByNativeCode]
public class BatchRendererGroup : IDisposable
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(BatchRendererGroup batchRendererGroup) { }

	}

	internal sealed class OnFinishedCulling : MulticastDelegate
	{

		public OnFinishedCulling(object object, IntPtr method) { }

		public override void Invoke(IntPtr customCullingResult) { }

	}

	internal sealed class OnPerformCulling : MulticastDelegate
	{

		public OnPerformCulling(object object, IntPtr method) { }

		public override JobHandle Invoke(BatchRendererGroup rendererGroup, BatchCullingContext cullingContext, BatchCullingOutput cullingOutput, IntPtr userContext) { }

	}

	private IntPtr m_GroupHandle; //Field offset: 0x10
	private OnPerformCulling m_PerformCulling; //Field offset: 0x18
	private OnFinishedCulling m_FinishedCulling; //Field offset: 0x20

	public static BatchBufferTarget BufferTarget
	{
		 get { } //Length: 42
	}

	public BatchRendererGroup(BatchRendererGroupCreateInfo info) { }

	public BatchID AddBatch(NativeArray<MetadataValue> batchMetadata, GraphicsBufferHandle buffer) { }

	private BatchID AddDrawCommandBatch(IntPtr values, int count, GraphicsBufferHandle buffer, uint bufferOffset, uint windowSize) { }

	private static void AddDrawCommandBatch_Injected(IntPtr _unity_self, IntPtr values, int count, in GraphicsBufferHandle buffer, uint bufferOffset, uint windowSize, out BatchID ret) { }

	private static IntPtr Create(BatchRendererGroup group, Void* userContext) { }

	private static void Destroy(IntPtr groupHandle) { }

	public override void Dispose() { }

	public static BatchBufferTarget get_BufferTarget() { }

	private static BatchBufferTarget GetBufferTarget() { }

	[RequiredByNativeCode]
	private static void InvokeOnFinishedCulling(BatchRendererGroup group, IntPtr customCullingResult) { }

	[RequiredByNativeCode]
	private static void InvokeOnPerformCulling(BatchRendererGroup group, ref BatchRendererCullingOutput context, ref LODParameters lodParameters, IntPtr userContext) { }

	[FreeFunction("BatchRendererGroup::OcclusionTestAABB", IsThreadSafe = True)]
	internal static bool OcclusionTestAABB(IntPtr occlusionBuffer, Bounds aabb) { }

	private static bool OcclusionTestAABB_Injected(IntPtr occlusionBuffer, in Bounds aabb) { }

	internal void RegisterMaterials(ReadOnlySpan<Int32> materialID, Span<BatchMaterialID> batchMaterialID) { }

	private static void RegisterMaterials_Injected(IntPtr _unity_self, ref ManagedSpanWrapper materialID, ref ManagedSpanWrapper batchMaterialID) { }

	internal void RegisterMeshes(ReadOnlySpan<Int32> meshID, Span<BatchMeshID> batchMeshID) { }

	private static void RegisterMeshes_Injected(IntPtr _unity_self, ref ManagedSpanWrapper meshID, ref ManagedSpanWrapper batchMeshID) { }

	public void RemoveBatch(BatchID batchID) { }

	private void RemoveDrawCommandBatch(BatchID batchID) { }

	private static void RemoveDrawCommandBatch_Injected(IntPtr _unity_self, in BatchID batchID) { }

	public void UnregisterMaterial(BatchMaterialID material) { }

	private static void UnregisterMaterial_Injected(IntPtr _unity_self, in BatchMaterialID material) { }

	public void UnregisterMesh(BatchMeshID mesh) { }

	private static void UnregisterMesh_Injected(IntPtr _unity_self, in BatchMeshID mesh) { }

}

