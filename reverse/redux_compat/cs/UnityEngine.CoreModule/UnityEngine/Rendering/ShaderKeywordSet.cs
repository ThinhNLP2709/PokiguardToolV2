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
	[NativeHeader("Editor/Src/Graphics/ShaderCompilerData.h")]
	[UsedByNativeCode]
	public struct ShaderKeywordSet // TypeDefIndex: 8457
	{
		// Fields
		private IntPtr m_KeywordState; // 0x00
		private IntPtr m_Shader; // 0x08
		private IntPtr m_ComputeShader; // 0x10
		private ulong m_StateIndex; // 0x18
	
		// Nested types
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 8458
		{
			// Fields
			public static Comparison<ShaderKeyword> _0___ShaderKeywordComparer; // 0x00
		}
	
		// Methods
		[FreeFunction("keywords::IsKeywordEnabled")]
		private static bool IsKeywordNameEnabled(ShaderKeywordSet state, string name); // 0x0000000182268CC0-0x0000000182268E30
		[FreeFunction("keywords::GetEnabledKeywords")]
		private static ShaderKeyword[] GetEnabledKeywords(ShaderKeywordSet state); // 0x0000000182268B60-0x0000000182268BA0
		private void CheckKeywordCompatible(ShaderKeyword keyword); // 0x0000000182268A90-0x0000000182268B20
		public bool IsEnabled(ShaderKeyword keyword); // 0x0000000182268BA0-0x0000000182268C70
		public override string ToString(); // 0x0000000182268E60-0x0000000182268F90
		private static int ShaderKeywordComparer(ShaderKeyword kw1, ShaderKeyword kw2); // 0x0000000182268E30-0x0000000182268E60
		private static bool IsKeywordNameEnabled_Injected(in ShaderKeywordSet state, ref ManagedSpanWrapper name); // 0x0000000182268C70-0x0000000182268CC0
		private static ShaderKeyword[] GetEnabledKeywords_Injected(in ShaderKeywordSet state); // 0x0000000182268B20-0x0000000182268B60
	}
}
