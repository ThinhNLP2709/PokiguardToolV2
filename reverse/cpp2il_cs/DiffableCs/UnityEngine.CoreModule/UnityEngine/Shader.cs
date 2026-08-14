namespace UnityEngine;

[NativeHeader("Runtime/Shaders/Shader.h")]
[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
[NativeHeader("Runtime/Misc/ResourceManager.h")]
[NativeHeader("Runtime/Shaders/Keywords/KeywordSpaceScriptBindings.h")]
[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
[NativeHeader("Runtime/Shaders/GpuPrograms/ShaderVariantCollection.h")]
[NativeHeader("Runtime/Shaders/ShaderNameRegistry.h")]
[NativeHeader("Runtime/Shaders/ComputeShader.h")]
public sealed class Shader : object
{

	public static string globalRenderPipeline
	{
		 set { } //Length: 362
	}

	public bool isSupported
	{
		[NativeMethod("IsSupported")]
		 get { } //Length: 118
	}

	public LocalKeywordSpace keywordSpace
	{
		 get { } //Length: 137
	}

	public int passCount
	{
		[FreeFunction(Name = "ShaderScripting::GetPassCount", HasExplicitThis = True)]
		 get { } //Length: 118
	}

	[FreeFunction("ShaderScripting::DisableKeyword")]
	public static void DisableKeyword(string keyword) { }

	private static void DisableKeyword_Injected(ref ManagedSpanWrapper keyword) { }

	[FreeFunction("ShaderScripting::EnableKeyword")]
	public static void EnableKeyword(string keyword) { }

	private static void EnableKeyword_Injected(ref ManagedSpanWrapper keyword) { }

	public static Shader Find(string name) { }

	[NativeMethod("IsSupported")]
	public bool get_isSupported() { }

	private static bool get_isSupported_Injected(IntPtr _unity_self) { }

	public LocalKeywordSpace get_keywordSpace() { }

	private static void get_keywordSpace_Injected(IntPtr _unity_self, out LocalKeywordSpace ret) { }

	[FreeFunction(Name = "ShaderScripting::GetPassCount", HasExplicitThis = True)]
	public int get_passCount() { }

	private static int get_passCount_Injected(IntPtr _unity_self) { }

	[FreeFunction(Name = "ShaderScripting::PropertyToID", IsThreadSafe = True)]
	public static int PropertyToID(string name) { }

	private static int PropertyToID_Injected(ref ManagedSpanWrapper name) { }

	public static void set_globalRenderPipeline(string value) { }

	private static void set_globalRenderPipeline_Injected(ref ManagedSpanWrapper value) { }

	public static void SetGlobalBuffer(string name, ComputeBuffer value) { }

	[FreeFunction("ShaderScripting::SetGlobalBuffer")]
	private static void SetGlobalBufferImpl(int name, ComputeBuffer value) { }

	private static void SetGlobalBufferImpl_Injected(int name, IntPtr value) { }

	public static void SetGlobalColor(int nameID, Color value) { }

	public static void SetGlobalConstantBuffer(int nameID, ComputeBuffer value, int offset, int size) { }

	[FreeFunction("ShaderScripting::SetGlobalConstantBuffer")]
	private static void SetGlobalConstantBufferImpl(int name, ComputeBuffer value, int offset, int size) { }

	private static void SetGlobalConstantBufferImpl_Injected(int name, IntPtr value, int offset, int size) { }

	public static void SetGlobalFloat(int nameID, float value) { }

	[FreeFunction("ShaderScripting::SetGlobalFloat")]
	private static void SetGlobalFloatImpl(int name, float value) { }

	public static void SetGlobalTexture(string name, Texture value) { }

	public static void SetGlobalTexture(int nameID, Texture value) { }

	[FreeFunction("ShaderScripting::SetGlobalTexture")]
	private static void SetGlobalTextureImpl(int name, Texture value) { }

	private static void SetGlobalTextureImpl_Injected(int name, IntPtr value) { }

	[FreeFunction("ShaderScripting::SetGlobalVector")]
	private static void SetGlobalVectorImpl(int name, Vector4 value) { }

	private static void SetGlobalVectorImpl_Injected(int name, in Vector4 value) { }

	[FreeFunction("ShaderScripting::TagToID")]
	internal static int TagToID(string name) { }

	private static int TagToID_Injected(ref ManagedSpanWrapper name) { }

}

