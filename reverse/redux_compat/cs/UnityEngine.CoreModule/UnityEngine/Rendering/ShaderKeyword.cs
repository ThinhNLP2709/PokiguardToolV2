/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
	[NativeHeader("Runtime/Shaders/Keywords/KeywordSpaceScriptBindings.h")]
	[UsedByNativeCode]
	public struct ShaderKeyword // TypeDefIndex: 8456
	{
		// Fields
		internal string m_Name; // 0x00
		internal uint m_Index; // 0x08
		internal bool m_IsLocal; // 0x0C
		internal bool m_IsCompute; // 0x0D
		internal bool m_IsValid; // 0x0E
	
		// Properties
		public string name { get; } // 0x00000001808BADD0-0x00000001808BADE0 
	
		// Constructors
		public ShaderKeyword(string keywordName); // 0x00000001822692D0-0x0000000182269360
	
		// Methods
		[FreeFunction("ShaderScripting::GetGlobalKeywordCount")]
		internal static uint GetGlobalKeywordCount(); // 0x0000000182269110-0x0000000182269140
		[FreeFunction("ShaderScripting::GetGlobalKeywordIndex")]
		internal static uint GetGlobalKeywordIndex(string keyword); // 0x0000000182269180-0x00000001822692D0
		[FreeFunction("ShaderScripting::CreateGlobalKeyword")]
		internal static void CreateGlobalKeyword(string keyword); // 0x0000000182268FD0-0x0000000182269110
		public override string ToString(); // 0x00000001808BADD0-0x00000001808BADE0
		private static uint GetGlobalKeywordIndex_Injected(ref ManagedSpanWrapper keyword); // 0x0000000182269140-0x0000000182269180
		private static void CreateGlobalKeyword_Injected(ref ManagedSpanWrapper keyword); // 0x0000000182268F90-0x0000000182268FD0
	}
}
