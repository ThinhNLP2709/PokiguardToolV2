namespace UnityEngine.Rendering;

[NativeHeader("Runtime/Shaders/RayTracing/RayTracingShader.h")]
[NativeHeader("Runtime/Shaders/ComputeShader.h")]
[NativeHeader("Runtime/Export/Graphics/RenderingCommandBuffer.bindings.h")]
[NativeType("Runtime/Graphics/CommandBuffer/RenderingCommandBuffer.h")]
[UsedByNativeCode]
public class CommandBuffer : IDisposable
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(CommandBuffer commandBuffer) { }

	}

	public static bool ThrowOnSetRenderTarget; //Field offset: 0x0
	internal IntPtr m_Ptr; //Field offset: 0x10

	public string name
	{
		 get { } //Length: 206
		 set { } //Length: 425
	}

	public int sizeInBytes
	{
		[NativeMethod("GetBufferSize")]
		 get { } //Length: 81
	}

	public CommandBuffer() { }

	public void BeginRenderPass(int width, int height, int volumeDepth, int samples, NativeArray<AttachmentDescriptor> attachments, int depthAttachmentIndex, NativeArray<SubPassDescriptor> subPasses, ReadOnlySpan<Byte> debugNameUtf8) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::BeginRenderPass", HasExplicitThis = True)]
	private void BeginRenderPass_Internal(int width, int height, int volumeDepth, int samples, ReadOnlySpan<AttachmentDescriptor> attachments, int depthAttachmentIndex, ReadOnlySpan<SubPassDescriptor> subPasses, ReadOnlySpan<Byte> debugNameUtf8) { }

	private static void BeginRenderPass_Internal_Injected(IntPtr _unity_self, int width, int height, int volumeDepth, int samples, ref ManagedSpanWrapper attachments, int depthAttachmentIndex, ref ManagedSpanWrapper subPasses, ref ManagedSpanWrapper debugNameUtf8) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::BeginSample", HasExplicitThis = True)]
	public void BeginSample(string name) { }

	public void BeginSample(CustomSampler sampler) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::BeginSample_CustomSampler", HasExplicitThis = True)]
	private void BeginSample_CustomSampler(CustomSampler sampler) { }

	private static void BeginSample_CustomSampler_Injected(IntPtr _unity_self, IntPtr sampler) { }

	private static void BeginSample_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name) { }

	public void Blit(RenderTargetIdentifier source, RenderTargetIdentifier dest) { }

	public void Blit(Texture source, RenderTargetIdentifier dest) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Blit_Identifier", HasExplicitThis = True)]
	private void Blit_Identifier(ref RenderTargetIdentifier source, ref RenderTargetIdentifier dest, Material mat, int pass, Vector2 scale, Vector2 offset, int sourceDepthSlice, int destDepthSlice) { }

	private static void Blit_Identifier_Injected(IntPtr _unity_self, ref RenderTargetIdentifier source, ref RenderTargetIdentifier dest, IntPtr mat, int pass, in Vector2 scale, in Vector2 offset, int sourceDepthSlice, int destDepthSlice) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Blit_Texture", HasExplicitThis = True)]
	private void Blit_Texture(Texture source, ref RenderTargetIdentifier dest, Material mat, int pass, Vector2 scale, Vector2 offset, int sourceDepthSlice, int destDepthSlice) { }

	private static void Blit_Texture_Injected(IntPtr _unity_self, IntPtr source, ref RenderTargetIdentifier dest, IntPtr mat, int pass, in Vector2 scale, in Vector2 offset, int sourceDepthSlice, int destDepthSlice) { }

	public void BuildRayTracingAccelerationStructure(RayTracingAccelerationStructure accelerationStructure, Vector3 relativeOrigin) { }

	public void BuildRayTracingAccelerationStructure(RayTracingAccelerationStructure accelerationStructure) { }

	private static void CheckThrowOnSetRenderTarget() { }

	[NativeMethod("ClearCommands")]
	public void Clear() { }

	private static void Clear_Injected(IntPtr _unity_self) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::ClearRandomWriteTargets", HasExplicitThis = True, ThrowsException = True)]
	public void ClearRandomWriteTargets() { }

	private static void ClearRandomWriteTargets_Injected(IntPtr _unity_self) { }

	public void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor) { }

	public void ClearRenderTarget(RTClearFlags clearFlags, Color backgroundColor, float depth = 1, uint stencil = 0) { }

	public void ClearRenderTarget(RTClearFlags clearFlags, Color[] backgroundColors, float depth = 1, uint stencil = 0) { }

	public void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor, float depth) { }

	public void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor, float depth = 1, uint stencil = 0) { }

	private void ClearRenderTargetMulti_Internal(RTClearFlags clearFlags, Color[] colors, float depth, uint stencil) { }

	private static void ClearRenderTargetMulti_Internal_Injected(IntPtr _unity_self, RTClearFlags clearFlags, ref ManagedSpanWrapper colors, float depth, uint stencil) { }

	private void ClearRenderTargetSingle_Internal(RTClearFlags clearFlags, Color color, float depth, uint stencil) { }

	private static void ClearRenderTargetSingle_Internal_Injected(IntPtr _unity_self, RTClearFlags clearFlags, in Color color, float depth, uint stencil) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::ConfigureFoveatedRendering", HasExplicitThis = True)]
	public void ConfigureFoveatedRendering(IntPtr platformData) { }

	private static void ConfigureFoveatedRendering_Injected(IntPtr _unity_self, IntPtr platformData) { }

	public void CopyCounterValue(ComputeBuffer src, ComputeBuffer dst, uint dstOffsetBytes) { }

	public void CopyCounterValue(GraphicsBuffer src, ComputeBuffer dst, uint dstOffsetBytes) { }

	public void CopyCounterValue(ComputeBuffer src, GraphicsBuffer dst, uint dstOffsetBytes) { }

	public void CopyCounterValue(GraphicsBuffer src, GraphicsBuffer dst, uint dstOffsetBytes) { }

	[NativeMethod("AddCopyCounterValue")]
	private void CopyCounterValueCC(ComputeBuffer src, ComputeBuffer dst, uint dstOffsetBytes) { }

	private static void CopyCounterValueCC_Injected(IntPtr _unity_self, IntPtr src, IntPtr dst, uint dstOffsetBytes) { }

	[NativeMethod("AddCopyCounterValue")]
	private void CopyCounterValueCG(ComputeBuffer src, GraphicsBuffer dst, uint dstOffsetBytes) { }

	private static void CopyCounterValueCG_Injected(IntPtr _unity_self, IntPtr src, IntPtr dst, uint dstOffsetBytes) { }

	[NativeMethod("AddCopyCounterValue")]
	private void CopyCounterValueGC(GraphicsBuffer src, ComputeBuffer dst, uint dstOffsetBytes) { }

	private static void CopyCounterValueGC_Injected(IntPtr _unity_self, IntPtr src, IntPtr dst, uint dstOffsetBytes) { }

	[NativeMethod("AddCopyCounterValue")]
	private void CopyCounterValueGG(GraphicsBuffer src, GraphicsBuffer dst, uint dstOffsetBytes) { }

	private static void CopyCounterValueGG_Injected(IntPtr _unity_self, IntPtr src, IntPtr dst, uint dstOffsetBytes) { }

	public GraphicsFence CreateAsyncGraphicsFence() { }

	[FreeFunction("RenderingCommandBuffer_Bindings::CreateGPUFence_Internal", HasExplicitThis = True)]
	private IntPtr CreateGPUFence_Internal(GraphicsFenceType fenceType, SynchronisationStageFlags stage) { }

	private static IntPtr CreateGPUFence_Internal_Injected(IntPtr _unity_self, GraphicsFenceType fenceType, SynchronisationStageFlags stage) { }

	public GraphicsFence CreateGraphicsFence(GraphicsFenceType fenceType, SynchronisationStageFlags stage) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::DisableComputeKeyword", HasExplicitThis = True)]
	private void DisableComputeKeyword(ComputeShader computeShader, LocalKeyword keyword) { }

	private static void DisableComputeKeyword_Injected(IntPtr _unity_self, IntPtr computeShader, in LocalKeyword keyword) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::DisableShaderKeyword", HasExplicitThis = True)]
	private void DisableGlobalKeyword(GlobalKeyword keyword) { }

	private static void DisableGlobalKeyword_Injected(IntPtr _unity_self, in GlobalKeyword keyword) { }

	public void DisableKeyword(in GlobalKeyword keyword) { }

	public void DisableKeyword(Material material, in LocalKeyword keyword) { }

	public void DisableKeyword(ComputeShader computeShader, in LocalKeyword keyword) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::DisableMaterialKeyword", HasExplicitThis = True)]
	private void DisableMaterialKeyword(Material material, LocalKeyword keyword) { }

	private static void DisableMaterialKeyword_Injected(IntPtr _unity_self, IntPtr material, in LocalKeyword keyword) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::DisableScissorRect", HasExplicitThis = True, ThrowsException = True)]
	public void DisableScissorRect() { }

	private static void DisableScissorRect_Injected(IntPtr _unity_self) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::DisableShaderKeyword", HasExplicitThis = True)]
	public void DisableShaderKeyword(string keyword) { }

	private static void DisableShaderKeyword_Injected(IntPtr _unity_self, ref ManagedSpanWrapper keyword) { }

	public void DispatchCompute(ComputeShader computeShader, int kernelIndex, int threadGroupsX, int threadGroupsY, int threadGroupsZ) { }

	public void DispatchCompute(ComputeShader computeShader, int kernelIndex, GraphicsBuffer indirectBuffer, uint argsOffset) { }

	public void DispatchCompute(ComputeShader computeShader, int kernelIndex, ComputeBuffer indirectBuffer, uint argsOffset) { }

	public void DispatchRays(RayTracingShader rayTracingShader, string rayGenName, uint width, uint height, uint depth, Camera camera = null) { }

	private void Dispose(bool disposing) { }

	public override void Dispose() { }

	[ExcludeFromDocs]
	public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass) { }

	[ExcludeFromDocs]
	public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex) { }

	[ExcludeFromDocs]
	public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material) { }

	public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass, MaterialPropertyBlock properties) { }

	public void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices) { }

	public void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices, int count) { }

	public void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties) { }

	public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs, int argsOffset) { }

	public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs, int argsOffset) { }

	public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs) { }

	public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs) { }

	public void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	public void DrawMeshInstancedProcedural(Mesh mesh, int submeshIndex, Material material, int shaderPass, int count, MaterialPropertyBlock properties = null) { }

	[ExcludeFromDocs]
	public void DrawMultipleMeshes(Matrix4x4[] matrices, Mesh[] meshes, Int32[] subsetIndices, int count, Material material, int shaderPass, MaterialPropertyBlock properties) { }

	public void DrawOcclusionMesh(RectInt normalizedCamViewport) { }

	public void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount) { }

	[ExcludeFromDocs]
	public void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount) { }

	public void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount, int instanceCount, MaterialPropertyBlock properties) { }

	[ExcludeFromDocs]
	public void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount, int instanceCount) { }

	public void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount, int instanceCount, MaterialPropertyBlock properties) { }

	public void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount, int instanceCount) { }

	public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset) { }

	public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset) { }

	public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs) { }

	public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset) { }

	public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs) { }

	public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs) { }

	public void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset) { }

	public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs) { }

	public void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	public void DrawRenderer(Renderer renderer, Material material, int submeshIndex, int shaderPass) { }

	[ExcludeFromDocs]
	public void DrawRenderer(Renderer renderer, Material material) { }

	[ExcludeFromDocs]
	public void DrawRenderer(Renderer renderer, Material material, int submeshIndex) { }

	public void DrawRendererList(RendererList rendererList) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::EnableComputeKeyword", HasExplicitThis = True)]
	private void EnableComputeKeyword(ComputeShader computeShader, LocalKeyword keyword) { }

	private static void EnableComputeKeyword_Injected(IntPtr _unity_self, IntPtr computeShader, in LocalKeyword keyword) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::EnableShaderKeyword", HasExplicitThis = True)]
	private void EnableGlobalKeyword(GlobalKeyword keyword) { }

	private static void EnableGlobalKeyword_Injected(IntPtr _unity_self, in GlobalKeyword keyword) { }

	public void EnableKeyword(in GlobalKeyword keyword) { }

	public void EnableKeyword(Material material, in LocalKeyword keyword) { }

	public void EnableKeyword(ComputeShader computeShader, in LocalKeyword keyword) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::EnableMaterialKeyword", HasExplicitThis = True)]
	private void EnableMaterialKeyword(Material material, LocalKeyword keyword) { }

	private static void EnableMaterialKeyword_Injected(IntPtr _unity_self, IntPtr material, in LocalKeyword keyword) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::EnableScissorRect", HasExplicitThis = True, ThrowsException = True)]
	public void EnableScissorRect(Rect scissor) { }

	private static void EnableScissorRect_Injected(IntPtr _unity_self, in Rect scissor) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::EnableShaderKeyword", HasExplicitThis = True)]
	public void EnableShaderKeyword(string keyword) { }

	private static void EnableShaderKeyword_Injected(IntPtr _unity_self, ref ManagedSpanWrapper keyword) { }

	public void EndRenderPass() { }

	[FreeFunction("RenderingCommandBuffer_Bindings::EndRenderPass", HasExplicitThis = True)]
	private void EndRenderPass_Internal() { }

	private static void EndRenderPass_Internal_Injected(IntPtr _unity_self) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::EndSample", HasExplicitThis = True)]
	public void EndSample(string name) { }

	public void EndSample(CustomSampler sampler) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::EndSample_CustomSampler", HasExplicitThis = True)]
	private void EndSample_CustomSampler(CustomSampler sampler) { }

	private static void EndSample_CustomSampler_Injected(IntPtr _unity_self, IntPtr sampler) { }

	private static void EndSample_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name) { }

	protected virtual void Finalize() { }

	public string get_name() { }

	private static void get_name_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret) { }

	[NativeMethod("GetBufferSize")]
	public int get_sizeInBytes() { }

	private static int get_sizeInBytes_Injected(IntPtr _unity_self) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::IncrementUpdateCount", HasExplicitThis = True)]
	public void IncrementUpdateCount(RenderTargetIdentifier dest) { }

	private static void IncrementUpdateCount_Injected(IntPtr _unity_self, in RenderTargetIdentifier dest) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::InitBuffer")]
	private static IntPtr InitBuffer() { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_BuildRayTracingAccelerationStructure", HasExplicitThis = True)]
	private void Internal_BuildRayTracingAccelerationStructure(RayTracingAccelerationStructure accelerationStructure, BuildSettings buildSettings) { }

	private static void Internal_BuildRayTracingAccelerationStructure_Injected(IntPtr _unity_self, IntPtr accelerationStructure, in BuildSettings buildSettings) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DispatchCompute", HasExplicitThis = True, ThrowsException = True)]
	private void Internal_DispatchCompute(ComputeShader computeShader, int kernelIndex, int threadGroupsX, int threadGroupsY, int threadGroupsZ) { }

	private static void Internal_DispatchCompute_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, int threadGroupsX, int threadGroupsY, int threadGroupsZ) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DispatchComputeIndirect", HasExplicitThis = True, ThrowsException = True)]
	private void Internal_DispatchComputeIndirect(ComputeShader computeShader, int kernelIndex, ComputeBuffer indirectBuffer, uint argsOffset) { }

	private static void Internal_DispatchComputeIndirect_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, IntPtr indirectBuffer, uint argsOffset) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DispatchComputeIndirect", HasExplicitThis = True, ThrowsException = True)]
	private void Internal_DispatchComputeIndirectGraphicsBuffer(ComputeShader computeShader, int kernelIndex, GraphicsBuffer indirectBuffer, uint argsOffset) { }

	private static void Internal_DispatchComputeIndirectGraphicsBuffer_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, IntPtr indirectBuffer, uint argsOffset) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DispatchRays", HasExplicitThis = True, ThrowsException = True)]
	private void Internal_DispatchRays(RayTracingShader rayTracingShader, string rayGenShaderName, uint width, uint height, uint depth, Camera camera = null) { }

	private static void Internal_DispatchRays_Injected(IntPtr _unity_self, IntPtr rayTracingShader, ref ManagedSpanWrapper rayGenShaderName, uint width, uint height, uint depth, IntPtr camera) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawMesh", HasExplicitThis = True)]
	private void Internal_DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass, MaterialPropertyBlock properties) { }

	private static void Internal_DrawMesh_Injected(IntPtr _unity_self, IntPtr mesh, in Matrix4x4 matrix, IntPtr material, int submeshIndex, int shaderPass, IntPtr properties) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawMeshInstanced", HasExplicitThis = True)]
	private void Internal_DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties) { }

	private static void Internal_DrawMeshInstanced_Injected(IntPtr _unity_self, IntPtr mesh, int submeshIndex, IntPtr material, int shaderPass, ref ManagedSpanWrapper matrices, int count, IntPtr properties) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawMeshInstancedIndirect", HasExplicitThis = True)]
	private void Internal_DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	private static void Internal_DrawMeshInstancedIndirect_Injected(IntPtr _unity_self, IntPtr mesh, int submeshIndex, IntPtr material, int shaderPass, IntPtr bufferWithArgs, int argsOffset, IntPtr properties) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawMeshInstancedIndirect", HasExplicitThis = True)]
	private void Internal_DrawMeshInstancedIndirectGraphicsBuffer(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	private static void Internal_DrawMeshInstancedIndirectGraphicsBuffer_Injected(IntPtr _unity_self, IntPtr mesh, int submeshIndex, IntPtr material, int shaderPass, IntPtr bufferWithArgs, int argsOffset, IntPtr properties) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawMeshInstancedProcedural", HasExplicitThis = True)]
	private void Internal_DrawMeshInstancedProcedural(Mesh mesh, int submeshIndex, Material material, int shaderPass, int count, MaterialPropertyBlock properties) { }

	private static void Internal_DrawMeshInstancedProcedural_Injected(IntPtr _unity_self, IntPtr mesh, int submeshIndex, IntPtr material, int shaderPass, int count, IntPtr properties) { }

	[NativeMethod("AddDrawMultipleMeshes")]
	private void Internal_DrawMultipleMeshes(Matrix4x4[] matrices, Mesh[] meshes, Int32[] subsetIndices, int count, Material material, int shaderPass, MaterialPropertyBlock properties) { }

	private static void Internal_DrawMultipleMeshes_Injected(IntPtr _unity_self, ref ManagedSpanWrapper matrices, Mesh[] meshes, ref ManagedSpanWrapper subsetIndices, int count, IntPtr material, int shaderPass, IntPtr properties) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawOcclusionMesh", HasExplicitThis = True)]
	private void Internal_DrawOcclusionMesh(RectInt normalizedCamViewport) { }

	private static void Internal_DrawOcclusionMesh_Injected(IntPtr _unity_self, in RectInt normalizedCamViewport) { }

	[NativeMethod("AddDrawProcedural")]
	private void Internal_DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount, int instanceCount, MaterialPropertyBlock properties) { }

	private static void Internal_DrawProcedural_Injected(IntPtr _unity_self, in Matrix4x4 matrix, IntPtr material, int shaderPass, MeshTopology topology, int vertexCount, int instanceCount, IntPtr properties) { }

	[NativeMethod("AddDrawProceduralIndexed")]
	private void Internal_DrawProceduralIndexed(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount, int instanceCount, MaterialPropertyBlock properties) { }

	private static void Internal_DrawProceduralIndexed_Injected(IntPtr _unity_self, IntPtr indexBuffer, in Matrix4x4 matrix, IntPtr material, int shaderPass, MeshTopology topology, int indexCount, int instanceCount, IntPtr properties) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawProceduralIndexedIndirect", HasExplicitThis = True)]
	private void Internal_DrawProceduralIndexedIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	private static void Internal_DrawProceduralIndexedIndirect_Injected(IntPtr _unity_self, IntPtr indexBuffer, in Matrix4x4 matrix, IntPtr material, int shaderPass, MeshTopology topology, IntPtr bufferWithArgs, int argsOffset, IntPtr properties) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawProceduralIndexedIndirect", HasExplicitThis = True)]
	private void Internal_DrawProceduralIndexedIndirectGraphicsBuffer(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	private static void Internal_DrawProceduralIndexedIndirectGraphicsBuffer_Injected(IntPtr _unity_self, IntPtr indexBuffer, in Matrix4x4 matrix, IntPtr material, int shaderPass, MeshTopology topology, IntPtr bufferWithArgs, int argsOffset, IntPtr properties) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawProceduralIndirect", HasExplicitThis = True)]
	private void Internal_DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	private static void Internal_DrawProceduralIndirect_Injected(IntPtr _unity_self, in Matrix4x4 matrix, IntPtr material, int shaderPass, MeshTopology topology, IntPtr bufferWithArgs, int argsOffset, IntPtr properties) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_DrawProceduralIndirect", HasExplicitThis = True)]
	private void Internal_DrawProceduralIndirectGraphicsBuffer(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	private static void Internal_DrawProceduralIndirectGraphicsBuffer_Injected(IntPtr _unity_self, in Matrix4x4 matrix, IntPtr material, int shaderPass, MeshTopology topology, IntPtr bufferWithArgs, int argsOffset, IntPtr properties) { }

	[NativeMethod("AddDrawRenderer")]
	private void Internal_DrawRenderer(Renderer renderer, Material material, int submeshIndex, int shaderPass) { }

	private static void Internal_DrawRenderer_Injected(IntPtr _unity_self, IntPtr renderer, IntPtr material, int submeshIndex, int shaderPass) { }

	[NativeMethod("AddDrawRendererList")]
	private void Internal_DrawRendererList(RendererList rendererList) { }

	private static void Internal_DrawRendererList_Injected(IntPtr _unity_self, in RendererList rendererList) { }

	[NativeMethod("AddRequestAsyncReadback")]
	private void Internal_RequestAsyncReadback_1(ComputeBuffer src, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null) { }

	private static void Internal_RequestAsyncReadback_1_Injected(IntPtr _unity_self, IntPtr src, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData) { }

	[NativeMethod("AddRequestAsyncReadback")]
	private void Internal_RequestAsyncReadback_2(ComputeBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null) { }

	private static void Internal_RequestAsyncReadback_2_Injected(IntPtr _unity_self, IntPtr src, int size, int offset, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData) { }

	[NativeMethod("AddRequestAsyncReadback")]
	private void Internal_RequestAsyncReadback_3(Texture src, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null) { }

	private static void Internal_RequestAsyncReadback_3_Injected(IntPtr _unity_self, IntPtr src, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData) { }

	[NativeMethod("AddRequestAsyncReadback")]
	private void Internal_RequestAsyncReadback_4(Texture src, int mipIndex, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null) { }

	private static void Internal_RequestAsyncReadback_4_Injected(IntPtr _unity_self, IntPtr src, int mipIndex, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData) { }

	[NativeMethod("AddRequestAsyncReadback")]
	private void Internal_RequestAsyncReadback_5(Texture src, int mipIndex, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null) { }

	private static void Internal_RequestAsyncReadback_5_Injected(IntPtr _unity_self, IntPtr src, int mipIndex, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData) { }

	[NativeMethod("AddRequestAsyncReadback")]
	private void Internal_RequestAsyncReadback_6(Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null) { }

	private static void Internal_RequestAsyncReadback_6_Injected(IntPtr _unity_self, IntPtr src, int mipIndex, int x, int width, int y, int height, int z, int depth, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData) { }

	[NativeMethod("AddRequestAsyncReadback")]
	private void Internal_RequestAsyncReadback_7(Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null) { }

	private static void Internal_RequestAsyncReadback_7_Injected(IntPtr _unity_self, IntPtr src, int mipIndex, int x, int width, int y, int height, int z, int depth, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData) { }

	[NativeMethod("AddRequestAsyncReadback")]
	private void Internal_RequestAsyncReadback_8(GraphicsBuffer src, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null) { }

	private static void Internal_RequestAsyncReadback_8_Injected(IntPtr _unity_self, IntPtr src, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData) { }

	[NativeMethod("AddRequestAsyncReadback")]
	private void Internal_RequestAsyncReadback_9(GraphicsBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData = null) { }

	private static void Internal_RequestAsyncReadback_9_Injected(IntPtr _unity_self, IntPtr src, int size, int offset, Action<AsyncGPUReadbackRequest> callback, AsyncRequestNativeArrayData* nativeArrayData) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeBufferParam", HasExplicitThis = True)]
	private void Internal_SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, ComputeBuffer buffer) { }

	private static void Internal_SetComputeBufferParam_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, int nameID, IntPtr buffer) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeConstantBufferParam", HasExplicitThis = True)]
	private void Internal_SetComputeConstantComputeBufferParam(ComputeShader computeShader, int nameID, ComputeBuffer buffer, int offset, int size) { }

	private static void Internal_SetComputeConstantComputeBufferParam_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, IntPtr buffer, int offset, int size) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeConstantBufferParam", HasExplicitThis = True)]
	private void Internal_SetComputeConstantGraphicsBufferParam(ComputeShader computeShader, int nameID, GraphicsBuffer buffer, int offset, int size) { }

	private static void Internal_SetComputeConstantGraphicsBufferParam_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, IntPtr buffer, int offset, int size) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetComputeFloats", HasExplicitThis = True)]
	private void Internal_SetComputeFloats(ComputeShader computeShader, int nameID, Single[] values) { }

	private static void Internal_SetComputeFloats_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, ref ManagedSpanWrapper values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeBufferParam", HasExplicitThis = True)]
	private void Internal_SetComputeGraphicsBufferHandleParam(ComputeShader computeShader, int kernelIndex, int nameID, GraphicsBufferHandle bufferHandle) { }

	private static void Internal_SetComputeGraphicsBufferHandleParam_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, int nameID, in GraphicsBufferHandle bufferHandle) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeBufferParam", HasExplicitThis = True)]
	private void Internal_SetComputeGraphicsBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, GraphicsBuffer buffer) { }

	private static void Internal_SetComputeGraphicsBufferParam_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, int nameID, IntPtr buffer) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetComputeInts", HasExplicitThis = True)]
	private void Internal_SetComputeInts(ComputeShader computeShader, int nameID, Int32[] values) { }

	private static void Internal_SetComputeInts_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, ref ManagedSpanWrapper values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetComputeRayTracingAccelerationStructure", HasExplicitThis = True)]
	private void Internal_SetComputeRayTracingAccelerationStructure(ComputeShader computeShader, int kernelIndex, int nameID, RayTracingAccelerationStructure accelerationStructure) { }

	private static void Internal_SetComputeRayTracingAccelerationStructure_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, int nameID, IntPtr accelerationStructure) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetComputeTextureParam", HasExplicitThis = True)]
	private void Internal_SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, ref RenderTargetIdentifier rt, int mipLevel, RenderTextureSubElement element) { }

	private static void Internal_SetComputeTextureParam_Injected(IntPtr _unity_self, IntPtr computeShader, int kernelIndex, int nameID, ref RenderTargetIdentifier rt, int mipLevel, RenderTextureSubElement element) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingAccelerationStructure", HasExplicitThis = True)]
	private void Internal_SetRayTracingAccelerationStructure(RayTracingShader rayTracingShader, int nameID, RayTracingAccelerationStructure accelerationStructure) { }

	private static void Internal_SetRayTracingAccelerationStructure_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, IntPtr accelerationStructure) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingBufferParam", HasExplicitThis = True)]
	private void Internal_SetRayTracingComputeBufferParam(RayTracingShader rayTracingShader, int nameID, ComputeBuffer buffer) { }

	private static void Internal_SetRayTracingComputeBufferParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, IntPtr buffer) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingConstantBufferParam", HasExplicitThis = True)]
	private void Internal_SetRayTracingConstantComputeBufferParam(RayTracingShader rayTracingShader, int nameID, ComputeBuffer buffer, int offset, int size) { }

	private static void Internal_SetRayTracingConstantComputeBufferParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, IntPtr buffer, int offset, int size) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingConstantBufferParam", HasExplicitThis = True)]
	private void Internal_SetRayTracingConstantGraphicsBufferParam(RayTracingShader rayTracingShader, int nameID, GraphicsBuffer buffer, int offset, int size) { }

	private static void Internal_SetRayTracingConstantGraphicsBufferParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, IntPtr buffer, int offset, int size) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingFloatParam", HasExplicitThis = True)]
	private void Internal_SetRayTracingFloatParam(RayTracingShader rayTracingShader, int nameID, float val) { }

	private static void Internal_SetRayTracingFloatParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, float val) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingFloats", HasExplicitThis = True)]
	private void Internal_SetRayTracingFloats(RayTracingShader rayTracingShader, int nameID, Single[] values) { }

	private static void Internal_SetRayTracingFloats_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, ref ManagedSpanWrapper values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingBufferParam", HasExplicitThis = True)]
	private void Internal_SetRayTracingGraphicsBufferHandleParam(RayTracingShader rayTracingShader, int nameID, GraphicsBufferHandle bufferHandle) { }

	private static void Internal_SetRayTracingGraphicsBufferHandleParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, in GraphicsBufferHandle bufferHandle) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingBufferParam", HasExplicitThis = True)]
	private void Internal_SetRayTracingGraphicsBufferParam(RayTracingShader rayTracingShader, int nameID, GraphicsBuffer buffer) { }

	private static void Internal_SetRayTracingGraphicsBufferParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, IntPtr buffer) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingIntParam", HasExplicitThis = True)]
	private void Internal_SetRayTracingIntParam(RayTracingShader rayTracingShader, int nameID, int val) { }

	private static void Internal_SetRayTracingIntParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, int val) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingInts", HasExplicitThis = True)]
	private void Internal_SetRayTracingInts(RayTracingShader rayTracingShader, int nameID, Int32[] values) { }

	private static void Internal_SetRayTracingInts_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, ref ManagedSpanWrapper values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingMatrixArrayParam", HasExplicitThis = True)]
	private void Internal_SetRayTracingMatrixArrayParam(RayTracingShader rayTracingShader, int nameID, Matrix4x4[] values) { }

	private static void Internal_SetRayTracingMatrixArrayParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, ref ManagedSpanWrapper values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingMatrixParam", HasExplicitThis = True)]
	private void Internal_SetRayTracingMatrixParam(RayTracingShader rayTracingShader, int nameID, Matrix4x4 val) { }

	private static void Internal_SetRayTracingMatrixParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, in Matrix4x4 val) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingTextureParam", HasExplicitThis = True)]
	private void Internal_SetRayTracingTextureParam(RayTracingShader rayTracingShader, int nameID, ref RenderTargetIdentifier rt) { }

	private static void Internal_SetRayTracingTextureParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, ref RenderTargetIdentifier rt) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingVectorArrayParam", HasExplicitThis = True)]
	private void Internal_SetRayTracingVectorArrayParam(RayTracingShader rayTracingShader, int nameID, Vector4[] values) { }

	private static void Internal_SetRayTracingVectorArrayParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, ref ManagedSpanWrapper values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetRayTracingVectorParam", HasExplicitThis = True)]
	private void Internal_SetRayTracingVectorParam(RayTracingShader rayTracingShader, int nameID, Vector4 val) { }

	private static void Internal_SetRayTracingVectorParam_Injected(IntPtr _unity_self, IntPtr rayTracingShader, int nameID, in Vector4 val) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::Internal_SetSinglePassStereo", HasExplicitThis = True)]
	private void Internal_SetSinglePassStereo(SinglePassStereoMode mode) { }

	private static void Internal_SetSinglePassStereo_Injected(IntPtr _unity_self, SinglePassStereoMode mode) { }

	[FreeFunction(Name = "RenderingCommandBuffer_Bindings::InternalSetGraphicsBufferCounterValue", HasExplicitThis = True)]
	private void InternalSetComputeBufferCounterValue(ComputeBuffer buffer, uint counterValue) { }

	private static void InternalSetComputeBufferCounterValue_Injected(IntPtr _unity_self, IntPtr buffer, uint counterValue) { }

	[FreeFunction(Name = "RenderingCommandBuffer_Bindings::InternalSetGraphicsBufferData", HasExplicitThis = True, ThrowsException = True)]
	private void InternalSetComputeBufferData(ComputeBuffer buffer, Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize) { }

	private static void InternalSetComputeBufferData_Injected(IntPtr _unity_self, IntPtr buffer, Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize) { }

	[FreeFunction(Name = "RenderingCommandBuffer_Bindings::InternalSetGraphicsBufferNativeData", HasExplicitThis = True, ThrowsException = True)]
	private void InternalSetComputeBufferNativeData(ComputeBuffer buffer, IntPtr data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize) { }

	private static void InternalSetComputeBufferNativeData_Injected(IntPtr _unity_self, IntPtr buffer, IntPtr data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize) { }

	[FreeFunction(Name = "RenderingCommandBuffer_Bindings::InternalSetGraphicsBufferCounterValue", HasExplicitThis = True)]
	private void InternalSetGraphicsBufferCounterValue(GraphicsBuffer buffer, uint counterValue) { }

	private static void InternalSetGraphicsBufferCounterValue_Injected(IntPtr _unity_self, IntPtr buffer, uint counterValue) { }

	[FreeFunction(Name = "RenderingCommandBuffer_Bindings::InternalSetGraphicsBufferData", HasExplicitThis = True, ThrowsException = True)]
	private void InternalSetGraphicsBufferData(GraphicsBuffer buffer, Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize) { }

	private static void InternalSetGraphicsBufferData_Injected(IntPtr _unity_self, IntPtr buffer, Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize) { }

	[FreeFunction(Name = "RenderingCommandBuffer_Bindings::InternalSetGraphicsBufferNativeData", HasExplicitThis = True, ThrowsException = True)]
	private void InternalSetGraphicsBufferNativeData(GraphicsBuffer buffer, IntPtr data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize) { }

	private static void InternalSetGraphicsBufferNativeData_Injected(IntPtr _unity_self, IntPtr buffer, IntPtr data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize) { }

	public void InvokeOnRenderObjectCallbacks() { }

	[FreeFunction("RenderingCommandBuffer_Bindings::InvokeOnRenderObjectCallbacks", HasExplicitThis = True)]
	private void InvokeOnRenderObjectCallbacks_Internal() { }

	private static void InvokeOnRenderObjectCallbacks_Internal_Injected(IntPtr _unity_self) { }

	public void IssuePluginCustomBlit(IntPtr callback, uint command, RenderTargetIdentifier source, RenderTargetIdentifier dest, uint commandParam, uint commandFlags) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::IssuePluginCustomBlitInternal", HasExplicitThis = True)]
	private void IssuePluginCustomBlitInternal(IntPtr callback, uint command, ref RenderTargetIdentifier source, ref RenderTargetIdentifier dest, uint commandParam, uint commandFlags) { }

	private static void IssuePluginCustomBlitInternal_Injected(IntPtr _unity_self, IntPtr callback, uint command, ref RenderTargetIdentifier source, ref RenderTargetIdentifier dest, uint commandParam, uint commandFlags) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::IssuePluginCustomTextureUpdateInternal", HasExplicitThis = True)]
	private void IssuePluginCustomTextureUpdateInternal(IntPtr callback, Texture targetTexture, uint userData, bool useNewUnityRenderingExtTextureUpdateParamsV2) { }

	private static void IssuePluginCustomTextureUpdateInternal_Injected(IntPtr _unity_self, IntPtr callback, IntPtr targetTexture, uint userData, bool useNewUnityRenderingExtTextureUpdateParamsV2) { }

	public void IssuePluginCustomTextureUpdateV2(IntPtr callback, Texture targetTexture, uint userData) { }

	public void IssuePluginEvent(IntPtr callback, int eventID) { }

	public void IssuePluginEventAndData(IntPtr callback, int eventID, IntPtr data) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::IssuePluginEventAndDataInternal", HasExplicitThis = True)]
	private void IssuePluginEventAndDataInternal(IntPtr callback, int eventID, IntPtr data) { }

	private static void IssuePluginEventAndDataInternal_Injected(IntPtr _unity_self, IntPtr callback, int eventID, IntPtr data) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::IssuePluginEventInternal", HasExplicitThis = True)]
	private void IssuePluginEventInternal(IntPtr callback, int eventID) { }

	private static void IssuePluginEventInternal_Injected(IntPtr _unity_self, IntPtr callback, int eventID) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::MarkLateLatchMatrixShaderPropertyID", HasExplicitThis = True)]
	public void MarkLateLatchMatrixShaderPropertyID(CameraLateLatchMatrixType matrixPropertyType, int shaderPropertyID) { }

	private static void MarkLateLatchMatrixShaderPropertyID_Injected(IntPtr _unity_self, CameraLateLatchMatrixType matrixPropertyType, int shaderPropertyID) { }

	public void NextSubPass() { }

	[FreeFunction("RenderingCommandBuffer_Bindings::NextSubPass", HasExplicitThis = True)]
	private void NextSubPass_Internal() { }

	private static void NextSubPass_Internal_Injected(IntPtr _unity_self) { }

	public void Release() { }

	[FreeFunction("RenderingCommandBuffer_Bindings::ReleaseBuffer", HasExplicitThis = True, IsThreadSafe = True)]
	private void ReleaseBuffer() { }

	private static void ReleaseBuffer_Injected(IntPtr _unity_self) { }

	public void RequestAsyncReadbackIntoNativeArray(ref NativeArray<T>& output, ComputeBuffer src, Action<AsyncGPUReadbackRequest> callback) { }

	public void RequestAsyncReadbackIntoNativeArray(ref NativeArray<T>& output, Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, Action<AsyncGPUReadbackRequest> callback) { }

	public void RequestAsyncReadbackIntoNativeArray(ref NativeArray<T>& output, ComputeBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback) { }

	public void RequestAsyncReadbackIntoNativeArray(ref NativeArray<T>& output, GraphicsBuffer src, Action<AsyncGPUReadbackRequest> callback) { }

	public void RequestAsyncReadbackIntoNativeArray(ref NativeArray<T>& output, GraphicsBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback) { }

	public void RequestAsyncReadbackIntoNativeArray(ref NativeArray<T>& output, Texture src, Action<AsyncGPUReadbackRequest> callback) { }

	public void RequestAsyncReadbackIntoNativeArray(ref NativeArray<T>& output, Texture src, int mipIndex, Action<AsyncGPUReadbackRequest> callback) { }

	public void RequestAsyncReadbackIntoNativeArray(ref NativeArray<T>& output, Texture src, int mipIndex, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback) { }

	public void RequestAsyncReadbackIntoNativeArray(ref NativeArray<T>& output, Texture src, int mipIndex, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback) { }

	public void RequestAsyncReadbackIntoNativeArray(ref NativeArray<T>& output, Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback) { }

	public void RequestAsyncReadbackIntoNativeArray(ref NativeArray<T>& output, Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback) { }

	public void set_name(string value) { }

	private static void set_name_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value) { }

	public void SetBufferCounterValue(ComputeBuffer buffer, uint counterValue) { }

	public void SetBufferCounterValue(GraphicsBuffer buffer, uint counterValue) { }

	public void SetBufferData(ComputeBuffer buffer, NativeArray<T> data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count) { }

	public void SetBufferData(ComputeBuffer buffer, List<T> data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count) { }

	public void SetBufferData(ComputeBuffer buffer, List<T> data) { }

	public void SetBufferData(ComputeBuffer buffer, Array data) { }

	public void SetBufferData(GraphicsBuffer buffer, Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count) { }

	public void SetBufferData(GraphicsBuffer buffer, List<T> data) { }

	public void SetBufferData(GraphicsBuffer buffer, NativeArray<T> data) { }

	public void SetBufferData(ComputeBuffer buffer, NativeArray<T> data) { }

	public void SetBufferData(GraphicsBuffer buffer, List<T> data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count) { }

	public void SetBufferData(GraphicsBuffer buffer, NativeArray<T> data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count) { }

	public void SetBufferData(GraphicsBuffer buffer, Array data) { }

	public void SetBufferData(ComputeBuffer buffer, Array data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count) { }

	public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, ComputeBuffer buffer) { }

	public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, GraphicsBufferHandle bufferHandle) { }

	public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, string name, GraphicsBufferHandle bufferHandle) { }

	public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, int nameID, GraphicsBuffer buffer) { }

	public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, string name, GraphicsBuffer buffer) { }

	public void SetComputeBufferParam(ComputeShader computeShader, int kernelIndex, string name, ComputeBuffer buffer) { }

	public void SetComputeConstantBufferParam(ComputeShader computeShader, int nameID, GraphicsBuffer buffer, int offset, int size) { }

	public void SetComputeConstantBufferParam(ComputeShader computeShader, string name, ComputeBuffer buffer, int offset, int size) { }

	public void SetComputeConstantBufferParam(ComputeShader computeShader, int nameID, ComputeBuffer buffer, int offset, int size) { }

	public void SetComputeConstantBufferParam(ComputeShader computeShader, string name, GraphicsBuffer buffer, int offset, int size) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeFloatParam", HasExplicitThis = True)]
	public void SetComputeFloatParam(ComputeShader computeShader, int nameID, float val) { }

	public void SetComputeFloatParam(ComputeShader computeShader, string name, float val) { }

	private static void SetComputeFloatParam_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, float val) { }

	public void SetComputeFloatParams(ComputeShader computeShader, int nameID, Single[] values) { }

	public void SetComputeFloatParams(ComputeShader computeShader, string name, Single[] values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeIntParam", HasExplicitThis = True)]
	public void SetComputeIntParam(ComputeShader computeShader, int nameID, int val) { }

	public void SetComputeIntParam(ComputeShader computeShader, string name, int val) { }

	private static void SetComputeIntParam_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, int val) { }

	public void SetComputeIntParams(ComputeShader computeShader, string name, Int32[] values) { }

	public void SetComputeIntParams(ComputeShader computeShader, int nameID, Int32[] values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeKeyword", HasExplicitThis = True)]
	private void SetComputeKeyword(ComputeShader computeShader, LocalKeyword keyword, bool value) { }

	private static void SetComputeKeyword_Injected(IntPtr _unity_self, IntPtr computeShader, in LocalKeyword keyword, bool value) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeMatrixArrayParam", HasExplicitThis = True)]
	public void SetComputeMatrixArrayParam(ComputeShader computeShader, int nameID, Matrix4x4[] values) { }

	public void SetComputeMatrixArrayParam(ComputeShader computeShader, string name, Matrix4x4[] values) { }

	private static void SetComputeMatrixArrayParam_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, ref ManagedSpanWrapper values) { }

	public void SetComputeMatrixParam(ComputeShader computeShader, string name, Matrix4x4 val) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeMatrixParam", HasExplicitThis = True)]
	public void SetComputeMatrixParam(ComputeShader computeShader, int nameID, Matrix4x4 val) { }

	private static void SetComputeMatrixParam_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, in Matrix4x4 val) { }

	public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, RenderTargetIdentifier rt, int mipLevel) { }

	public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, RenderTargetIdentifier rt, int mipLevel) { }

	public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, RenderTargetIdentifier rt, int mipLevel, RenderTextureSubElement element) { }

	public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, RenderTargetIdentifier rt, int mipLevel, RenderTextureSubElement element) { }

	public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, string name, RenderTargetIdentifier rt) { }

	public void SetComputeTextureParam(ComputeShader computeShader, int kernelIndex, int nameID, RenderTargetIdentifier rt) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeVectorArrayParam", HasExplicitThis = True)]
	public void SetComputeVectorArrayParam(ComputeShader computeShader, int nameID, Vector4[] values) { }

	public void SetComputeVectorArrayParam(ComputeShader computeShader, string name, Vector4[] values) { }

	private static void SetComputeVectorArrayParam_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, ref ManagedSpanWrapper values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetComputeVectorParam", HasExplicitThis = True)]
	public void SetComputeVectorParam(ComputeShader computeShader, int nameID, Vector4 val) { }

	public void SetComputeVectorParam(ComputeShader computeShader, string name, Vector4 val) { }

	private static void SetComputeVectorParam_Injected(IntPtr _unity_self, IntPtr computeShader, int nameID, in Vector4 val) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetExecutionFlags", HasExplicitThis = True, ThrowsException = True)]
	public void SetExecutionFlags(CommandBufferExecutionFlags flags) { }

	private static void SetExecutionFlags_Injected(IntPtr _unity_self, CommandBufferExecutionFlags flags) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetFoveatedRenderingMode", HasExplicitThis = True)]
	public void SetFoveatedRenderingMode(FoveatedRenderingMode foveatedRenderingMode) { }

	private static void SetFoveatedRenderingMode_Injected(IntPtr _unity_self, FoveatedRenderingMode foveatedRenderingMode) { }

	public void SetGlobalBuffer(string name, ComputeBuffer value) { }

	public void SetGlobalBuffer(int nameID, ComputeBuffer value) { }

	public void SetGlobalBuffer(string name, GraphicsBuffer value) { }

	public void SetGlobalBuffer(int nameID, GraphicsBuffer value) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalBuffer", HasExplicitThis = True)]
	private void SetGlobalBufferInternal(int nameID, ComputeBuffer value) { }

	private static void SetGlobalBufferInternal_Injected(IntPtr _unity_self, int nameID, IntPtr value) { }

	public void SetGlobalColor(string name, Color value) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalColor", HasExplicitThis = True)]
	public void SetGlobalColor(int nameID, Color value) { }

	private static void SetGlobalColor_Injected(IntPtr _unity_self, int nameID, in Color value) { }

	public void SetGlobalConstantBuffer(GraphicsBuffer buffer, string name, int offset, int size) { }

	public void SetGlobalConstantBuffer(GraphicsBuffer buffer, int nameID, int offset, int size) { }

	public void SetGlobalConstantBuffer(ComputeBuffer buffer, string name, int offset, int size) { }

	public void SetGlobalConstantBuffer(ComputeBuffer buffer, int nameID, int offset, int size) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalConstantBuffer", HasExplicitThis = True)]
	private void SetGlobalConstantBufferInternal(ComputeBuffer buffer, int nameID, int offset, int size) { }

	private static void SetGlobalConstantBufferInternal_Injected(IntPtr _unity_self, IntPtr buffer, int nameID, int offset, int size) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalConstantBuffer", HasExplicitThis = True)]
	private void SetGlobalConstantGraphicsBufferInternal(GraphicsBuffer buffer, int nameID, int offset, int size) { }

	private static void SetGlobalConstantGraphicsBufferInternal_Injected(IntPtr _unity_self, IntPtr buffer, int nameID, int offset, int size) { }

	[NativeMethod("AddSetGlobalDepthBias")]
	public void SetGlobalDepthBias(float bias, float slopeBias) { }

	private static void SetGlobalDepthBias_Injected(IntPtr _unity_self, float bias, float slopeBias) { }

	public void SetGlobalFloat(string name, float value) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalFloat", HasExplicitThis = True)]
	public void SetGlobalFloat(int nameID, float value) { }

	private static void SetGlobalFloat_Injected(IntPtr _unity_self, int nameID, float value) { }

	public void SetGlobalFloatArray(int nameID, List<Single> values) { }

	public void SetGlobalFloatArray(string propertyName, List<Single> values) { }

	public void SetGlobalFloatArray(string propertyName, Single[] values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalFloatArray", HasExplicitThis = True, ThrowsException = True)]
	public void SetGlobalFloatArray(int nameID, Single[] values) { }

	private static void SetGlobalFloatArray_Injected(IntPtr _unity_self, int nameID, ref ManagedSpanWrapper values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalFloatArrayListImpl", HasExplicitThis = True)]
	private void SetGlobalFloatArrayListImpl(int nameID, object values) { }

	private static void SetGlobalFloatArrayListImpl_Injected(IntPtr _unity_self, int nameID, object values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalBuffer", HasExplicitThis = True)]
	private void SetGlobalGraphicsBufferInternal(int nameID, GraphicsBuffer value) { }

	private static void SetGlobalGraphicsBufferInternal_Injected(IntPtr _unity_self, int nameID, IntPtr value) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalInt", HasExplicitThis = True)]
	public void SetGlobalInt(int nameID, int value) { }

	public void SetGlobalInt(string name, int value) { }

	private static void SetGlobalInt_Injected(IntPtr _unity_self, int nameID, int value) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalInteger", HasExplicitThis = True)]
	public void SetGlobalInteger(int nameID, int value) { }

	public void SetGlobalInteger(string name, int value) { }

	private static void SetGlobalInteger_Injected(IntPtr _unity_self, int nameID, int value) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetShaderKeyword", HasExplicitThis = True)]
	private void SetGlobalKeyword(GlobalKeyword keyword, bool value) { }

	private static void SetGlobalKeyword_Injected(IntPtr _unity_self, in GlobalKeyword keyword, bool value) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalMatrix", HasExplicitThis = True)]
	public void SetGlobalMatrix(int nameID, Matrix4x4 value) { }

	public void SetGlobalMatrix(string name, Matrix4x4 value) { }

	private static void SetGlobalMatrix_Injected(IntPtr _unity_self, int nameID, in Matrix4x4 value) { }

	public void SetGlobalMatrixArray(string propertyName, Matrix4x4[] values) { }

	public void SetGlobalMatrixArray(string propertyName, List<Matrix4x4> values) { }

	public void SetGlobalMatrixArray(int nameID, List<Matrix4x4> values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalMatrixArray", HasExplicitThis = True, ThrowsException = True)]
	public void SetGlobalMatrixArray(int nameID, Matrix4x4[] values) { }

	private static void SetGlobalMatrixArray_Injected(IntPtr _unity_self, int nameID, ref ManagedSpanWrapper values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalMatrixArrayListImpl", HasExplicitThis = True)]
	private void SetGlobalMatrixArrayListImpl(int nameID, object values) { }

	private static void SetGlobalMatrixArrayListImpl_Injected(IntPtr _unity_self, int nameID, object values) { }

	public void SetGlobalTexture(int nameID, RenderTargetIdentifier value, RenderTextureSubElement element) { }

	public void SetGlobalTexture(string name, RenderTargetIdentifier value, RenderTextureSubElement element) { }

	public void SetGlobalTexture(int nameID, RenderTargetIdentifier value) { }

	public void SetGlobalTexture(string name, RenderTargetIdentifier value) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalTexture_Impl", HasExplicitThis = True)]
	private void SetGlobalTexture_Impl(int nameID, ref RenderTargetIdentifier rt, RenderTextureSubElement element) { }

	private static void SetGlobalTexture_Impl_Injected(IntPtr _unity_self, int nameID, ref RenderTargetIdentifier rt, RenderTextureSubElement element) { }

	public void SetGlobalVector(string name, Vector4 value) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalVector", HasExplicitThis = True)]
	public void SetGlobalVector(int nameID, Vector4 value) { }

	private static void SetGlobalVector_Injected(IntPtr _unity_self, int nameID, in Vector4 value) { }

	public void SetGlobalVectorArray(string propertyName, Vector4[] values) { }

	public void SetGlobalVectorArray(int nameID, List<Vector4> values) { }

	public void SetGlobalVectorArray(string propertyName, List<Vector4> values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalVectorArray", HasExplicitThis = True, ThrowsException = True)]
	public void SetGlobalVectorArray(int nameID, Vector4[] values) { }

	private static void SetGlobalVectorArray_Injected(IntPtr _unity_self, int nameID, ref ManagedSpanWrapper values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetGlobalVectorArrayListImpl", HasExplicitThis = True)]
	private void SetGlobalVectorArrayListImpl(int nameID, object values) { }

	private static void SetGlobalVectorArrayListImpl_Injected(IntPtr _unity_self, int nameID, object values) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetInstanceMultiplier", HasExplicitThis = True)]
	public void SetInstanceMultiplier(uint multiplier) { }

	private static void SetInstanceMultiplier_Injected(IntPtr _unity_self, uint multiplier) { }

	[NativeMethod("AddSetInvertCulling")]
	public void SetInvertCulling(bool invertCulling) { }

	private static void SetInvertCulling_Injected(IntPtr _unity_self, bool invertCulling) { }

	public void SetKeyword(in GlobalKeyword keyword, bool value) { }

	public void SetKeyword(Material material, in LocalKeyword keyword, bool value) { }

	public void SetKeyword(ComputeShader computeShader, in LocalKeyword keyword, bool value) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetLateLatchProjectionMatrices", HasExplicitThis = True, ThrowsException = True)]
	public void SetLateLatchProjectionMatrices(Matrix4x4[] projectionMat) { }

	private static void SetLateLatchProjectionMatrices_Injected(IntPtr _unity_self, ref ManagedSpanWrapper projectionMat) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetMaterialKeyword", HasExplicitThis = True)]
	private void SetMaterialKeyword(Material material, LocalKeyword keyword, bool value) { }

	private static void SetMaterialKeyword_Injected(IntPtr _unity_self, IntPtr material, in LocalKeyword keyword, bool value) { }

	public void SetRandomWriteTarget(int index, RenderTargetIdentifier rt) { }

	public void SetRandomWriteTarget(int index, GraphicsBuffer buffer, bool preserveCounterValue) { }

	public void SetRandomWriteTarget(int index, GraphicsBuffer buffer) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetRandomWriteTarget_Buffer", HasExplicitThis = True, ThrowsException = True)]
	private void SetRandomWriteTarget_GraphicsBuffer(int index, GraphicsBuffer uav, bool preserveCounterValue) { }

	private static void SetRandomWriteTarget_GraphicsBuffer_Injected(IntPtr _unity_self, int index, IntPtr uav, bool preserveCounterValue) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetRandomWriteTarget_Texture", HasExplicitThis = True, ThrowsException = True)]
	private void SetRandomWriteTarget_Texture(int index, ref RenderTargetIdentifier rt) { }

	private static void SetRandomWriteTarget_Texture_Injected(IntPtr _unity_self, int index, ref RenderTargetIdentifier rt) { }

	public void SetRayTracingAccelerationStructure(ComputeShader computeShader, int kernelIndex, int nameID, RayTracingAccelerationStructure rayTracingAccelerationStructure) { }

	public void SetRayTracingAccelerationStructure(ComputeShader computeShader, int kernelIndex, string name, RayTracingAccelerationStructure rayTracingAccelerationStructure) { }

	public void SetRayTracingAccelerationStructure(RayTracingShader rayTracingShader, int nameID, RayTracingAccelerationStructure rayTracingAccelerationStructure) { }

	public void SetRayTracingAccelerationStructure(RayTracingShader rayTracingShader, string name, RayTracingAccelerationStructure rayTracingAccelerationStructure) { }

	public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, string name, ComputeBuffer buffer) { }

	public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, int nameID, ComputeBuffer buffer) { }

	public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, int nameID, GraphicsBufferHandle bufferHandle) { }

	public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, string name, GraphicsBufferHandle bufferHandle) { }

	public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, int nameID, GraphicsBuffer buffer) { }

	public void SetRayTracingBufferParam(RayTracingShader rayTracingShader, string name, GraphicsBuffer buffer) { }

	public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, string name, ComputeBuffer buffer, int offset, int size) { }

	public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, string name, GraphicsBuffer buffer, int offset, int size) { }

	public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, int nameID, GraphicsBuffer buffer, int offset, int size) { }

	public void SetRayTracingConstantBufferParam(RayTracingShader rayTracingShader, int nameID, ComputeBuffer buffer, int offset, int size) { }

	public void SetRayTracingFloatParam(RayTracingShader rayTracingShader, int nameID, float val) { }

	public void SetRayTracingFloatParam(RayTracingShader rayTracingShader, string name, float val) { }

	public void SetRayTracingFloatParams(RayTracingShader rayTracingShader, int nameID, Single[] values) { }

	public void SetRayTracingFloatParams(RayTracingShader rayTracingShader, string name, Single[] values) { }

	public void SetRayTracingIntParam(RayTracingShader rayTracingShader, string name, int val) { }

	public void SetRayTracingIntParam(RayTracingShader rayTracingShader, int nameID, int val) { }

	public void SetRayTracingIntParams(RayTracingShader rayTracingShader, string name, Int32[] values) { }

	public void SetRayTracingIntParams(RayTracingShader rayTracingShader, int nameID, Int32[] values) { }

	public void SetRayTracingMatrixArrayParam(RayTracingShader rayTracingShader, int nameID, Matrix4x4[] values) { }

	public void SetRayTracingMatrixArrayParam(RayTracingShader rayTracingShader, string name, Matrix4x4[] values) { }

	public void SetRayTracingMatrixParam(RayTracingShader rayTracingShader, int nameID, Matrix4x4 val) { }

	public void SetRayTracingMatrixParam(RayTracingShader rayTracingShader, string name, Matrix4x4 val) { }

	public void SetRayTracingTextureParam(RayTracingShader rayTracingShader, int nameID, RenderTargetIdentifier rt) { }

	public void SetRayTracingTextureParam(RayTracingShader rayTracingShader, string name, RenderTargetIdentifier rt) { }

	public void SetRayTracingVectorArrayParam(RayTracingShader rayTracingShader, string name, Vector4[] values) { }

	public void SetRayTracingVectorArrayParam(RayTracingShader rayTracingShader, int nameID, Vector4[] values) { }

	public void SetRayTracingVectorParam(RayTracingShader rayTracingShader, int nameID, Vector4 val) { }

	public void SetRayTracingVectorParam(RayTracingShader rayTracingShader, string name, Vector4 val) { }

	public void SetRenderTarget(RenderTargetIdentifier rt) { }

	public void SetRenderTarget(RenderTargetIdentifier rt, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction) { }

	public void SetRenderTarget(RenderTargetIdentifier rt, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction) { }

	public void SetRenderTarget(RenderTargetIdentifier rt, int mipLevel) { }

	public void SetRenderTarget(RenderTargetIdentifier rt, int mipLevel, CubemapFace cubemapFace) { }

	public void SetRenderTarget(RenderTargetIdentifier rt, int mipLevel, CubemapFace cubemapFace, int depthSlice) { }

	public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth) { }

	public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth, int mipLevel) { }

	public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth, int mipLevel, CubemapFace cubemapFace, int depthSlice) { }

	public void SetRenderTarget(RenderTargetIdentifier color, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depth, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction) { }

	public void SetRenderTarget(RenderTargetIdentifier color, RenderTargetIdentifier depth, int mipLevel, CubemapFace cubemapFace) { }

	public void SetRenderTarget(RenderTargetBinding binding) { }

	public void SetRenderTarget(RenderTargetBinding binding, int mipLevel, CubemapFace cubemapFace, int depthSlice) { }

	public void SetRenderTarget(RenderTargetIdentifier[] colors, RenderTargetIdentifier depth, int mipLevel, CubemapFace cubemapFace, int depthSlice) { }

	public void SetRenderTarget(RenderTargetIdentifier[] colors, RenderTargetIdentifier depth) { }

	private void SetRenderTargetColorDepth_Internal(RenderTargetIdentifier color, RenderTargetIdentifier depth, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, RenderTargetFlags flags) { }

	private static void SetRenderTargetColorDepth_Internal_Injected(IntPtr _unity_self, in RenderTargetIdentifier color, in RenderTargetIdentifier depth, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, RenderTargetFlags flags) { }

	private void SetRenderTargetColorDepthSubtarget(RenderTargetIdentifier color, RenderTargetIdentifier depth, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, int mipLevel, CubemapFace cubemapFace, int depthSlice) { }

	private static void SetRenderTargetColorDepthSubtarget_Injected(IntPtr _unity_self, in RenderTargetIdentifier color, in RenderTargetIdentifier depth, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, int mipLevel, CubemapFace cubemapFace, int depthSlice) { }

	private void SetRenderTargetMulti_Internal(RenderTargetIdentifier[] colors, RenderTargetIdentifier depth, RenderBufferLoadAction[] colorLoadActions, RenderBufferStoreAction[] colorStoreActions, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, RenderTargetFlags flags) { }

	private static void SetRenderTargetMulti_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper colors, in RenderTargetIdentifier depth, ref ManagedSpanWrapper colorLoadActions, ref ManagedSpanWrapper colorStoreActions, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, RenderTargetFlags flags) { }

	private void SetRenderTargetMultiSubtarget(RenderTargetIdentifier[] colors, RenderTargetIdentifier depth, RenderBufferLoadAction[] colorLoadActions, RenderBufferStoreAction[] colorStoreActions, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, int mipLevel, CubemapFace cubemapFace, int depthSlice) { }

	private static void SetRenderTargetMultiSubtarget_Injected(IntPtr _unity_self, ref ManagedSpanWrapper colors, in RenderTargetIdentifier depth, ref ManagedSpanWrapper colorLoadActions, ref ManagedSpanWrapper colorStoreActions, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, int mipLevel, CubemapFace cubemapFace, int depthSlice) { }

	private void SetRenderTargetSingle_Internal(RenderTargetIdentifier rt, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction) { }

	private static void SetRenderTargetSingle_Internal_Injected(IntPtr _unity_self, in RenderTargetIdentifier rt, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction) { }

	public void SetShadowSamplingMode(RenderTargetIdentifier shadowmap, ShadowSamplingMode mode) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetShadowSamplingMode_Impl", HasExplicitThis = True)]
	private void SetShadowSamplingMode_Impl(ref RenderTargetIdentifier shadowmap, ShadowSamplingMode mode) { }

	private static void SetShadowSamplingMode_Impl_Injected(IntPtr _unity_self, ref RenderTargetIdentifier shadowmap, ShadowSamplingMode mode) { }

	public void SetSinglePassStereo(SinglePassStereoMode mode) { }

	public void SetupCameraProperties(Camera camera) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetupCameraProperties", HasExplicitThis = True)]
	private void SetupCameraProperties_Internal(Camera camera) { }

	private static void SetupCameraProperties_Internal_Injected(IntPtr _unity_self, IntPtr camera) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetViewport", HasExplicitThis = True, ThrowsException = True)]
	public void SetViewport(Rect pixelRect) { }

	private static void SetViewport_Injected(IntPtr _unity_self, in Rect pixelRect) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetViewProjectionMatrices", HasExplicitThis = True, ThrowsException = True)]
	public void SetViewProjectionMatrices(Matrix4x4 view, Matrix4x4 proj) { }

	private static void SetViewProjectionMatrices_Injected(IntPtr _unity_self, in Matrix4x4 view, in Matrix4x4 proj) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::SetWireframe", HasExplicitThis = True)]
	public void SetWireframe(bool enable) { }

	private static void SetWireframe_Injected(IntPtr _unity_self, bool enable) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::UnmarkLateLatchMatrix", HasExplicitThis = True)]
	public void UnmarkLateLatchMatrix(CameraLateLatchMatrixType matrixPropertyType) { }

	private static void UnmarkLateLatchMatrix_Injected(IntPtr _unity_self, CameraLateLatchMatrixType matrixPropertyType) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::ValidateAgainstExecutionFlags", HasExplicitThis = True, ThrowsException = True)]
	private bool ValidateAgainstExecutionFlags(CommandBufferExecutionFlags requiredFlags, CommandBufferExecutionFlags invalidFlags) { }

	private static bool ValidateAgainstExecutionFlags_Injected(IntPtr _unity_self, CommandBufferExecutionFlags requiredFlags, CommandBufferExecutionFlags invalidFlags) { }

	public void WaitOnAsyncGraphicsFence(GraphicsFence fence, SynchronisationStageFlags stage) { }

	public void WaitOnAsyncGraphicsFence(GraphicsFence fence, SynchronisationStage stage) { }

	public void WaitOnAsyncGraphicsFence(GraphicsFence fence) { }

	[FreeFunction("RenderingCommandBuffer_Bindings::WaitOnGPUFence_Internal", HasExplicitThis = True)]
	private void WaitOnGPUFence_Internal(IntPtr fencePtr, SynchronisationStageFlags stage) { }

	private static void WaitOnGPUFence_Internal_Injected(IntPtr _unity_self, IntPtr fencePtr, SynchronisationStageFlags stage) { }

}

