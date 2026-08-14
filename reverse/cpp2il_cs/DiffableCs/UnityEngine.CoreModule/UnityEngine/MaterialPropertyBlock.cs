namespace UnityEngine;

[NativeHeader("Runtime/Shaders/ComputeShader.h")]
[NativeHeader("Runtime/Math/SphericalHarmonicsL2.h")]
[NativeHeader("Runtime/Shaders/ShaderPropertySheet.h")]
[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
public sealed class MaterialPropertyBlock
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(MaterialPropertyBlock materialPropertyBlock) { }

	}

	internal IntPtr m_Ptr; //Field offset: 0x10

	public MaterialPropertyBlock() { }

	public void Clear() { }

	[ThreadSafe]
	private void Clear(bool keepMemory) { }

	private static void Clear_Injected(IntPtr _unity_self, bool keepMemory) { }

	[NativeMethod(Name = "MaterialPropertyBlockScripting::Create", IsFreeFunction = True)]
	private static IntPtr CreateImpl() { }

	[NativeMethod(Name = "MaterialPropertyBlockScripting::Destroy", IsFreeFunction = True, IsThreadSafe = True)]
	private static void DestroyImpl(IntPtr mpb) { }

	private void Dispose() { }

	protected virtual void Finalize() { }

	public void SetBuffer(string name, ComputeBuffer value) { }

	[NativeName("SetBufferFromScript")]
	[ThreadSafe]
	private void SetBufferImpl(int name, ComputeBuffer value) { }

	private static void SetBufferImpl_Injected(IntPtr _unity_self, int name, IntPtr value) { }

	public void SetConstantBuffer(int nameID, ComputeBuffer value, int offset, int size) { }

	[NativeName("SetConstantBufferFromScript")]
	[ThreadSafe]
	private void SetConstantBufferImpl(int name, ComputeBuffer value, int offset, int size) { }

	private static void SetConstantBufferImpl_Injected(IntPtr _unity_self, int name, IntPtr value, int offset, int size) { }

	public void SetFloat(string name, float value) { }

	public void SetFloat(int nameID, float value) { }

	public void SetFloatArray(string name, Single[] values) { }

	private void SetFloatArray(int name, Single[] values, int count) { }

	[NativeName("SetFloatArrayFromScript")]
	[ThreadSafe]
	private void SetFloatArrayImpl(int name, Single[] values, int count) { }

	private static void SetFloatArrayImpl_Injected(IntPtr _unity_self, int name, ref ManagedSpanWrapper values, int count) { }

	[NativeName("SetFloatFromScript")]
	[ThreadSafe]
	private void SetFloatImpl(int name, float value) { }

	private static void SetFloatImpl_Injected(IntPtr _unity_self, int name, float value) { }

	public void SetInt(int nameID, int value) { }

	public void SetInt(string name, int value) { }

	public void SetInteger(int nameID, int value) { }

	[NativeName("SetIntFromScript")]
	[ThreadSafe]
	private void SetIntImpl(int name, int value) { }

	private static void SetIntImpl_Injected(IntPtr _unity_self, int name, int value) { }

	public void SetMatrix(string name, Matrix4x4 value) { }

	public void SetMatrix(int nameID, Matrix4x4 value) { }

	public void SetMatrixArray(string name, Matrix4x4[] values) { }

	private void SetMatrixArray(int name, Matrix4x4[] values, int count) { }

	[NativeName("SetMatrixArrayFromScript")]
	[ThreadSafe]
	private void SetMatrixArrayImpl(int name, Matrix4x4[] values, int count) { }

	private static void SetMatrixArrayImpl_Injected(IntPtr _unity_self, int name, ref ManagedSpanWrapper values, int count) { }

	[NativeName("SetMatrixFromScript")]
	[ThreadSafe]
	private void SetMatrixImpl(int name, Matrix4x4 value) { }

	private static void SetMatrixImpl_Injected(IntPtr _unity_self, int name, in Matrix4x4 value) { }

	[NativeName("SetRenderTextureFromScript")]
	[ThreadSafe]
	private void SetRenderTextureImpl(int name, RenderTexture value, RenderTextureSubElement element) { }

	private static void SetRenderTextureImpl_Injected(IntPtr _unity_self, int name, IntPtr value, RenderTextureSubElement element) { }

	public void SetTexture(int nameID, RenderTexture value, RenderTextureSubElement element) { }

	public void SetTexture(string name, Texture value) { }

	public void SetTexture(int nameID, Texture value) { }

	[NativeName("SetTextureFromScript")]
	[ThreadSafe]
	private void SetTextureImpl(int name, Texture value) { }

	private static void SetTextureImpl_Injected(IntPtr _unity_self, int name, IntPtr value) { }

	public void SetVector(int nameID, Vector4 value) { }

	public void SetVector(string name, Vector4 value) { }

	public void SetVectorArray(int nameID, Vector4[] values) { }

	public void SetVectorArray(string name, Vector4[] values) { }

	private void SetVectorArray(int name, Vector4[] values, int count) { }

	[NativeName("SetVectorArrayFromScript")]
	[ThreadSafe]
	private void SetVectorArrayImpl(int name, Vector4[] values, int count) { }

	private static void SetVectorArrayImpl_Injected(IntPtr _unity_self, int name, ref ManagedSpanWrapper values, int count) { }

	[NativeName("SetVectorFromScript")]
	[ThreadSafe]
	private void SetVectorImpl(int name, Vector4 value) { }

	private static void SetVectorImpl_Injected(IntPtr _unity_self, int name, in Vector4 value) { }

}

