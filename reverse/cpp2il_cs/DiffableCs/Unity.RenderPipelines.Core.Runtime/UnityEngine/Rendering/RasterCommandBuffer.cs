namespace UnityEngine.Rendering;

public class RasterCommandBuffer : BaseCommandBuffer, IRasterCommandBuffer, IBaseCommandBuffer
{

	internal RasterCommandBuffer(CommandBuffer wrapped, RenderGraphPass executingPass, bool isAsync) { }

	public override void BeginSample(ProfilerMarker marker) { }

	public override void BeginSample(CustomSampler sampler) { }

	public override void BeginSample(string name) { }

	public override void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor) { }

	public override void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor, float depth) { }

	public override void ClearRenderTarget(bool clearDepth, bool clearColor, Color backgroundColor, float depth, uint stencil) { }

	public override void ClearRenderTarget(RTClearFlags clearFlags, Color backgroundColor, float depth, uint stencil) { }

	public override void ClearRenderTarget(RTClearFlags clearFlags, Color[] backgroundColors, float depth, uint stencil) { }

	public override void ConfigureFoveatedRendering(IntPtr platformData) { }

	public void DisableKeyword(Material material, in LocalKeyword keyword) { }

	public void DisableKeyword(in GlobalKeyword keyword) { }

	public void DisableKeyword(ComputeShader computeShader, in LocalKeyword keyword) { }

	public override void DisableScissorRect() { }

	public override void DisableShaderKeyword(string keyword) { }

	public override void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass, MaterialPropertyBlock properties) { }

	public override void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex) { }

	public override void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material) { }

	public override void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submeshIndex, int shaderPass) { }

	public override void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices) { }

	public override void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices, int count) { }

	public override void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, int shaderPass, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties) { }

	public override void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs) { }

	public override void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs, int argsOffset) { }

	public override void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs, int argsOffset) { }

	public override void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	public override void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	public override void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, int shaderPass, ComputeBuffer bufferWithArgs) { }

	public override void DrawMeshInstancedProcedural(Mesh mesh, int submeshIndex, Material material, int shaderPass, int count, MaterialPropertyBlock properties) { }

	public override void DrawMultipleMeshes(Matrix4x4[] matrices, Mesh[] meshes, Int32[] subsetIndices, int count, Material material, int shaderPass, MaterialPropertyBlock properties) { }

	public override void DrawOcclusionMesh(RectInt normalizedCamViewport) { }

	public override void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount, int instanceCount, MaterialPropertyBlock properties) { }

	public override void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount, int instanceCount, MaterialPropertyBlock properties) { }

	public override void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount, int instanceCount) { }

	public override void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount) { }

	public override void DrawProcedural(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int indexCount, int instanceCount) { }

	public override void DrawProcedural(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, int vertexCount) { }

	public override void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs) { }

	public override void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset) { }

	public override void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset) { }

	public override void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset) { }

	public override void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs) { }

	public override void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	public override void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset) { }

	public override void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs) { }

	public override void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	public override void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, GraphicsBuffer bufferWithArgs) { }

	public override void DrawProceduralIndirect(GraphicsBuffer indexBuffer, Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	public override void DrawProceduralIndirect(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties) { }

	public override void DrawRenderer(Renderer renderer, Material material, int submeshIndex, int shaderPass) { }

	public override void DrawRenderer(Renderer renderer, Material material, int submeshIndex) { }

	public override void DrawRenderer(Renderer renderer, Material material) { }

	public override void DrawRendererList(RendererList rendererList) { }

	public void EnableKeyword(ComputeShader computeShader, in LocalKeyword keyword) { }

	public void EnableKeyword(in GlobalKeyword keyword) { }

	public void EnableKeyword(Material material, in LocalKeyword keyword) { }

	public override void EnableScissorRect(Rect scissor) { }

	public override void EnableShaderKeyword(string keyword) { }

	public override void EndSample(ProfilerMarker marker) { }

	public override void EndSample(CustomSampler sampler) { }

	public override void EndSample(string name) { }

	public override void IncrementUpdateCount(RenderTargetIdentifier dest) { }

	public override void InvokeOnRenderObjectCallbacks() { }

	public override void IssuePluginCustomBlit(IntPtr callback, uint command, RenderTargetIdentifier source, RenderTargetIdentifier dest, uint commandParam, uint commandFlags) { }

	public override void IssuePluginCustomTextureUpdateV2(IntPtr callback, Texture targetTexture, uint userData) { }

	public override void IssuePluginEvent(IntPtr callback, int eventID) { }

	public override void IssuePluginEventAndData(IntPtr callback, int eventID, IntPtr data) { }

	public override void MarkLateLatchMatrixShaderPropertyID(CameraLateLatchMatrixType matrixPropertyType, int shaderPropertyID) { }

	public override void SetFoveatedRenderingMode(FoveatedRenderingMode foveatedRenderingMode) { }

	public override void SetGlobalBuffer(string name, GraphicsBuffer value) { }

	public override void SetGlobalBuffer(int nameID, ComputeBuffer value) { }

	public override void SetGlobalBuffer(string name, ComputeBuffer value) { }

	public override void SetGlobalBuffer(int nameID, GraphicsBuffer value) { }

	public override void SetGlobalColor(string name, Color value) { }

	public override void SetGlobalColor(int nameID, Color value) { }

	public override void SetGlobalConstantBuffer(ComputeBuffer buffer, int nameID, int offset, int size) { }

	public override void SetGlobalConstantBuffer(ComputeBuffer buffer, string name, int offset, int size) { }

	public override void SetGlobalConstantBuffer(GraphicsBuffer buffer, string name, int offset, int size) { }

	public override void SetGlobalConstantBuffer(GraphicsBuffer buffer, int nameID, int offset, int size) { }

	public override void SetGlobalDepthBias(float bias, float slopeBias) { }

	public override void SetGlobalFloat(int nameID, float value) { }

	public override void SetGlobalFloat(string name, float value) { }

	public override void SetGlobalFloatArray(string propertyName, List<Single> values) { }

	public override void SetGlobalFloatArray(string propertyName, Single[] values) { }

	public override void SetGlobalFloatArray(int nameID, List<Single> values) { }

	public override void SetGlobalFloatArray(int nameID, Single[] values) { }

	public override void SetGlobalInt(int nameID, int value) { }

	public override void SetGlobalInt(string name, int value) { }

	public override void SetGlobalInteger(string name, int value) { }

	public override void SetGlobalInteger(int nameID, int value) { }

	public override void SetGlobalMatrix(string name, Matrix4x4 value) { }

	public override void SetGlobalMatrix(int nameID, Matrix4x4 value) { }

	public override void SetGlobalMatrixArray(int nameID, Matrix4x4[] values) { }

	public override void SetGlobalMatrixArray(string propertyName, Matrix4x4[] values) { }

	public override void SetGlobalMatrixArray(string propertyName, List<Matrix4x4> values) { }

	public override void SetGlobalMatrixArray(int nameID, List<Matrix4x4> values) { }

	public override void SetGlobalTexture(string name, TextureHandle value) { }

	public override void SetGlobalTexture(int nameID, TextureHandle value, RenderTextureSubElement element) { }

	public override void SetGlobalTexture(string name, TextureHandle value, RenderTextureSubElement element) { }

	public override void SetGlobalTexture(int nameID, TextureHandle value) { }

	public override void SetGlobalVector(string name, Vector4 value) { }

	public override void SetGlobalVector(int nameID, Vector4 value) { }

	public override void SetGlobalVectorArray(int nameID, List<Vector4> values) { }

	public override void SetGlobalVectorArray(string propertyName, List<Vector4> values) { }

	public override void SetGlobalVectorArray(int nameID, Vector4[] values) { }

	public override void SetGlobalVectorArray(string propertyName, Vector4[] values) { }

	public override void SetInstanceMultiplier(uint multiplier) { }

	public override void SetInvertCulling(bool invertCulling) { }

	public void SetKeyword(in GlobalKeyword keyword, bool value) { }

	public void SetKeyword(Material material, in LocalKeyword keyword, bool value) { }

	public void SetKeyword(ComputeShader computeShader, in LocalKeyword keyword, bool value) { }

	public override void SetLateLatchProjectionMatrices(Matrix4x4[] projectionMat) { }

	public override void SetShadowSamplingMode(RenderTargetIdentifier shadowmap, ShadowSamplingMode mode) { }

	public override void SetSinglePassStereo(SinglePassStereoMode mode) { }

	public override void SetupCameraProperties(Camera camera) { }

	public override void SetViewport(Rect pixelRect) { }

	public override void SetViewProjectionMatrices(Matrix4x4 view, Matrix4x4 proj) { }

	public override void SetWireframe(bool enable) { }

	private override void UnityEngine.Rendering.IBaseCommandBuffer.DisableKeyword(in GlobalKeyword keyword) { }

	private override void UnityEngine.Rendering.IBaseCommandBuffer.DisableKeyword(Material material, in LocalKeyword keyword) { }

	private override void UnityEngine.Rendering.IBaseCommandBuffer.DisableKeyword(ComputeShader computeShader, in LocalKeyword keyword) { }

	private override void UnityEngine.Rendering.IBaseCommandBuffer.EnableKeyword(in GlobalKeyword keyword) { }

	private override void UnityEngine.Rendering.IBaseCommandBuffer.EnableKeyword(Material material, in LocalKeyword keyword) { }

	private override void UnityEngine.Rendering.IBaseCommandBuffer.EnableKeyword(ComputeShader computeShader, in LocalKeyword keyword) { }

	private override void UnityEngine.Rendering.IBaseCommandBuffer.SetKeyword(Material material, in LocalKeyword keyword, bool value) { }

	private override void UnityEngine.Rendering.IBaseCommandBuffer.SetKeyword(in GlobalKeyword keyword, bool value) { }

	private override void UnityEngine.Rendering.IBaseCommandBuffer.SetKeyword(ComputeShader computeShader, in LocalKeyword keyword, bool value) { }

	public override void UnmarkLateLatchMatrix(CameraLateLatchMatrixType matrixPropertyType) { }

}

