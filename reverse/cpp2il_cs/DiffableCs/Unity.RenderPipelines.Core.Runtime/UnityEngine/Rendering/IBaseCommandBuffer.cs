namespace UnityEngine.Rendering;

public interface IBaseCommandBuffer
{

	public void BeginSample(string name) { }

	public void BeginSample(ProfilerMarker marker) { }

	public void BeginSample(CustomSampler sampler) { }

	public void DisableKeyword(Material material, in LocalKeyword keyword) { }

	public void DisableKeyword(in GlobalKeyword keyword) { }

	public void DisableKeyword(ComputeShader computeShader, in LocalKeyword keyword) { }

	public void DisableScissorRect() { }

	public void DisableShaderKeyword(string keyword) { }

	public void EnableKeyword(ComputeShader computeShader, in LocalKeyword keyword) { }

	public void EnableKeyword(in GlobalKeyword keyword) { }

	public void EnableKeyword(Material material, in LocalKeyword keyword) { }

	public void EnableScissorRect(Rect scissor) { }

	public void EnableShaderKeyword(string keyword) { }

	public void EndSample(string name) { }

	public void EndSample(ProfilerMarker marker) { }

	public void EndSample(CustomSampler sampler) { }

	public void IncrementUpdateCount(RenderTargetIdentifier dest) { }

	public void InvokeOnRenderObjectCallbacks() { }

	public void IssuePluginCustomBlit(IntPtr callback, uint command, RenderTargetIdentifier source, RenderTargetIdentifier dest, uint commandParam, uint commandFlags) { }

	public void IssuePluginCustomTextureUpdateV2(IntPtr callback, Texture targetTexture, uint userData) { }

	public void IssuePluginEvent(IntPtr callback, int eventID) { }

	public void IssuePluginEventAndData(IntPtr callback, int eventID, IntPtr data) { }

	public void MarkLateLatchMatrixShaderPropertyID(CameraLateLatchMatrixType matrixPropertyType, int shaderPropertyID) { }

	public void SetGlobalBuffer(string name, GraphicsBuffer value) { }

	public void SetGlobalBuffer(int nameID, ComputeBuffer value) { }

	public void SetGlobalBuffer(string name, ComputeBuffer value) { }

	public void SetGlobalBuffer(int nameID, GraphicsBuffer value) { }

	public void SetGlobalColor(string name, Color value) { }

	public void SetGlobalColor(int nameID, Color value) { }

	public void SetGlobalConstantBuffer(GraphicsBuffer buffer, string name, int offset, int size) { }

	public void SetGlobalConstantBuffer(ComputeBuffer buffer, string name, int offset, int size) { }

	public void SetGlobalConstantBuffer(GraphicsBuffer buffer, int nameID, int offset, int size) { }

	public void SetGlobalConstantBuffer(ComputeBuffer buffer, int nameID, int offset, int size) { }

	public void SetGlobalDepthBias(float bias, float slopeBias) { }

	public void SetGlobalFloat(string name, float value) { }

	public void SetGlobalFloat(int nameID, float value) { }

	public void SetGlobalFloatArray(string propertyName, List<Single> values) { }

	public void SetGlobalFloatArray(string propertyName, Single[] values) { }

	public void SetGlobalFloatArray(int nameID, List<Single> values) { }

	public void SetGlobalFloatArray(int nameID, Single[] values) { }

	public void SetGlobalInt(string name, int value) { }

	public void SetGlobalInt(int nameID, int value) { }

	public void SetGlobalInteger(int nameID, int value) { }

	public void SetGlobalInteger(string name, int value) { }

	public void SetGlobalMatrix(string name, Matrix4x4 value) { }

	public void SetGlobalMatrix(int nameID, Matrix4x4 value) { }

	public void SetGlobalMatrixArray(string propertyName, Matrix4x4[] values) { }

	public void SetGlobalMatrixArray(string propertyName, List<Matrix4x4> values) { }

	public void SetGlobalMatrixArray(int nameID, List<Matrix4x4> values) { }

	public void SetGlobalMatrixArray(int nameID, Matrix4x4[] values) { }

	public void SetGlobalTexture(string name, TextureHandle value) { }

	public void SetGlobalTexture(int nameID, TextureHandle value) { }

	public void SetGlobalTexture(string name, TextureHandle value, RenderTextureSubElement element) { }

	public void SetGlobalTexture(int nameID, TextureHandle value, RenderTextureSubElement element) { }

	public void SetGlobalVector(string name, Vector4 value) { }

	public void SetGlobalVector(int nameID, Vector4 value) { }

	public void SetGlobalVectorArray(string propertyName, List<Vector4> values) { }

	public void SetGlobalVectorArray(int nameID, Vector4[] values) { }

	public void SetGlobalVectorArray(int nameID, List<Vector4> values) { }

	public void SetGlobalVectorArray(string propertyName, Vector4[] values) { }

	public void SetInvertCulling(bool invertCulling) { }

	public void SetKeyword(in GlobalKeyword keyword, bool value) { }

	public void SetKeyword(Material material, in LocalKeyword keyword, bool value) { }

	public void SetKeyword(ComputeShader computeShader, in LocalKeyword keyword, bool value) { }

	public void SetLateLatchProjectionMatrices(Matrix4x4[] projectionMat) { }

	public void SetShadowSamplingMode(RenderTargetIdentifier shadowmap, ShadowSamplingMode mode) { }

	public void SetSinglePassStereo(SinglePassStereoMode mode) { }

	public void SetupCameraProperties(Camera camera) { }

	public void SetViewport(Rect pixelRect) { }

	public void SetViewProjectionMatrices(Matrix4x4 view, Matrix4x4 proj) { }

	public void UnmarkLateLatchMatrix(CameraLateLatchMatrixType matrixPropertyType) { }

}

