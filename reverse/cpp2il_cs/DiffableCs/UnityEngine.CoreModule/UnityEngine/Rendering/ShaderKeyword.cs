namespace UnityEngine.Rendering;

[NativeHeader("Runtime/Shaders/Keywords/KeywordSpaceScriptBindings.h")]
[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
[UsedByNativeCode]
public struct ShaderKeyword
{
	internal string m_Name; //Field offset: 0x0
	internal uint m_Index; //Field offset: 0x8
	internal bool m_IsLocal; //Field offset: 0xC
	internal bool m_IsCompute; //Field offset: 0xD
	internal bool m_IsValid; //Field offset: 0xE

	public string name
	{
		 get { } //Length: 6
	}

	public ShaderKeyword(string keywordName) { }

	[FreeFunction("ShaderScripting::CreateGlobalKeyword")]
	internal static void CreateGlobalKeyword(string keyword) { }

	private static void CreateGlobalKeyword_Injected(ref ManagedSpanWrapper keyword) { }

	public string get_name() { }

	[FreeFunction("ShaderScripting::GetGlobalKeywordCount")]
	internal static uint GetGlobalKeywordCount() { }

	[FreeFunction("ShaderScripting::GetGlobalKeywordIndex")]
	internal static uint GetGlobalKeywordIndex(string keyword) { }

	private static uint GetGlobalKeywordIndex_Injected(ref ManagedSpanWrapper keyword) { }

	public virtual string ToString() { }

}

