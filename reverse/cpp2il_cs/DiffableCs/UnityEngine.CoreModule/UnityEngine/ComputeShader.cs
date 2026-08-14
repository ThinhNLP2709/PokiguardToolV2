namespace UnityEngine;

[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
[NativeHeader("Runtime/Shaders/RayTracing/RayTracingAccelerationStructure.h")]
[NativeHeader("Runtime/Shaders/ComputeShader.h")]
[UsedByNativeCode]
public sealed class ComputeShader : object
{

	public LocalKeywordSpace keywordSpace
	{
		 get { } //Length: 138
	}

	public String[] shaderKeywords
	{
		 set { } //Length: 134
	}

	[FreeFunction("ComputeShaderScripting::DisableKeyword", HasExplicitThis = True)]
	public void DisableKeyword(string keyword) { }

	private static void DisableKeyword_Injected(IntPtr _unity_self, ref ManagedSpanWrapper keyword) { }

	[NativeName("DispatchComputeShader")]
	public void Dispatch(int kernelIndex, int threadGroupsX, int threadGroupsY, int threadGroupsZ) { }

	private static void Dispatch_Injected(IntPtr _unity_self, int kernelIndex, int threadGroupsX, int threadGroupsY, int threadGroupsZ) { }

	[FreeFunction("ComputeShaderScripting::EnableKeyword", HasExplicitThis = True)]
	public void EnableKeyword(string keyword) { }

	private static void EnableKeyword_Injected(IntPtr _unity_self, ref ManagedSpanWrapper keyword) { }

	[NativeMethod(Name = "ComputeShaderScripting::FindKernel", HasExplicitThis = True, IsFreeFunction = True, ThrowsException = True)]
	[RequiredByNativeCode]
	public int FindKernel(string name) { }

	private static int FindKernel_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name) { }

	public LocalKeywordSpace get_keywordSpace() { }

	private static void get_keywordSpace_Injected(IntPtr _unity_self, out LocalKeywordSpace ret) { }

	[FreeFunction(Name = "ComputeShaderScripting::SetBuffer", HasExplicitThis = True)]
	private void Internal_SetBuffer(int kernelIndex, int nameID, ComputeBuffer buffer) { }

	private static void Internal_SetBuffer_Injected(IntPtr _unity_self, int kernelIndex, int nameID, IntPtr buffer) { }

	[FreeFunction(Name = "ComputeShaderScripting::SetBuffer", HasExplicitThis = True)]
	private void Internal_SetGraphicsBuffer(int kernelIndex, int nameID, GraphicsBuffer buffer) { }

	private static void Internal_SetGraphicsBuffer_Injected(IntPtr _unity_self, int kernelIndex, int nameID, IntPtr buffer) { }

	public void set_shaderKeywords(String[] value) { }

	public void SetBuffer(int kernelIndex, int nameID, GraphicsBuffer buffer) { }

	public void SetBuffer(int kernelIndex, int nameID, ComputeBuffer buffer) { }

	public void SetConstantBuffer(int nameID, ComputeBuffer buffer, int offset, int size) { }

	[FreeFunction(Name = "ComputeShaderScripting::SetConstantBuffer", HasExplicitThis = True)]
	private void SetConstantComputeBuffer(int nameID, ComputeBuffer buffer, int offset, int size) { }

	private static void SetConstantComputeBuffer_Injected(IntPtr _unity_self, int nameID, IntPtr buffer, int offset, int size) { }

	[FreeFunction(Name = "ComputeShaderScripting::SetValue<int>", HasExplicitThis = True)]
	public void SetInt(int nameID, int val) { }

	private static void SetInt_Injected(IntPtr _unity_self, int nameID, int val) { }

	[FreeFunction(Name = "ComputeShaderScripting::SetArray<int>", HasExplicitThis = True)]
	private void SetIntArray(int nameID, Int32[] values) { }

	private static void SetIntArray_Injected(IntPtr _unity_self, int nameID, ref ManagedSpanWrapper values) { }

	public void SetInts(int nameID, Int32[] values) { }

	[FreeFunction("ComputeShaderScripting::SetShaderKeywords", HasExplicitThis = True)]
	private void SetShaderKeywords(String[] names) { }

	private static void SetShaderKeywords_Injected(IntPtr _unity_self, String[] names) { }

}

