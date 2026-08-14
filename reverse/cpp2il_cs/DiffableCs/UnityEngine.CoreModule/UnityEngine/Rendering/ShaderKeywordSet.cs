namespace UnityEngine.Rendering;

[NativeHeader("Editor/Src/Graphics/ShaderCompilerData.h")]
[UsedByNativeCode]
public struct ShaderKeywordSet
{
	private IntPtr m_KeywordState; //Field offset: 0x0
	private IntPtr m_Shader; //Field offset: 0x8
	private IntPtr m_ComputeShader; //Field offset: 0x10
	private ulong m_StateIndex; //Field offset: 0x18

	private void CheckKeywordCompatible(ShaderKeyword keyword) { }

	public bool IsEnabled(ShaderKeyword keyword) { }

	[FreeFunction("keywords::IsKeywordEnabled")]
	private static bool IsKeywordNameEnabled(ShaderKeywordSet state, string name) { }

	private static bool IsKeywordNameEnabled_Injected(in ShaderKeywordSet state, ref ManagedSpanWrapper name) { }

}

