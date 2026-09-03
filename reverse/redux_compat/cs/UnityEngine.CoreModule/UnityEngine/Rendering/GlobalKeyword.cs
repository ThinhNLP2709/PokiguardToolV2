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
	[IsReadOnly]
	[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
	[NativeHeader("Runtime/Shaders/Keywords/KeywordSpaceScriptBindings.h")]
	[UsedByNativeCode]
	public struct GlobalKeyword // TypeDefIndex: 8451
	{
		// Fields
		internal readonly uint m_Index; // 0x00
	
		// Properties
		public string name { get; } // 0x000000018225C920-0x000000018225C930 
	
		// Constructors
		public GlobalKeyword(string name); // 0x000000018225C930-0x000000018225CA50
	
		// Methods
		[FreeFunction("ShaderScripting::GetGlobalKeywordCount")]
		private static uint GetGlobalKeywordCount(); // 0x000000018225C660-0x000000018225C690
		[FreeFunction("ShaderScripting::GetGlobalKeywordIndex")]
		private static uint GetGlobalKeywordIndex(string keyword); // 0x000000018225C6D0-0x000000018225C820
		[FreeFunction("ShaderScripting::CreateGlobalKeyword")]
		private static void CreateGlobalKeyword(string keyword); // 0x000000018225C400-0x000000018225C540
		[FreeFunction("ShaderScripting::GetGlobalKeywordName")]
		private static string GetGlobalKeywordName(uint keywordIndex); // 0x000000018225C860-0x000000018225C920
		public static GlobalKeyword Create(string name); // 0x000000018225C540-0x000000018225C660
		public override string ToString(); // 0x000000018225C920-0x000000018225C930
		private static uint GetGlobalKeywordIndex_Injected(ref ManagedSpanWrapper keyword); // 0x000000018225C690-0x000000018225C6D0
		private static void CreateGlobalKeyword_Injected(ref ManagedSpanWrapper keyword); // 0x000000018225C3C0-0x000000018225C400
		private static void GetGlobalKeywordName_Injected(uint keywordIndex, ); // 0x000000018225C820-0x000000018225C860
	}
}
