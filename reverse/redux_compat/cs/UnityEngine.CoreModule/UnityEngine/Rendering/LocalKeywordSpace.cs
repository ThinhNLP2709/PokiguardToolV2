/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[IsReadOnly]
	[NativeHeader("Runtime/Shaders/Keywords/KeywordSpaceScriptBindings.h")]
	public struct LocalKeywordSpace : IEquatable<UnityEngine.Rendering.LocalKeywordSpace> // TypeDefIndex: 8453
	{
		// Fields
		private readonly IntPtr m_KeywordSpace; // 0x00
	
		// Properties
		public LocalKeyword[] keywords { get; } // 0x000000018225D2E0-0x000000018225D320 
		public string[] keywordNames { get; } // 0x000000018225D080-0x000000018225D0C0 
		public uint keywordCount { get; } // 0x000000018225D040-0x000000018225D080 
	
		// Methods
		[FreeFunction("keywords::GetKeywords", HasExplicitThis = true)]
		private LocalKeyword[] GetKeywords(); // 0x000000018225D2E0-0x000000018225D320
		[FreeFunction("keywords::GetKeywordNames", HasExplicitThis = true)]
		private string[] GetKeywordNames(); // 0x000000018225D080-0x000000018225D0C0
		[FreeFunction("keywords::GetKeywordCount", HasExplicitThis = true)]
		private uint GetKeywordCount(); // 0x000000018225D040-0x000000018225D080
		[FreeFunction("keywords::GetKeyword", HasExplicitThis = true)]
		private LocalKeyword GetKeyword(string name); // 0x000000018225D120-0x000000018225D2E0
		public LocalKeyword FindKeyword(string name); // 0x000000018225D010-0x000000018225D040
		public override bool Equals(object o); // 0x000000018225CF90-0x000000018225D010
		public bool Equals(LocalKeywordSpace rhs); // 0x0000000180DF5FE0-0x0000000180DF5FF0
		public static bool operator ==(LocalKeywordSpace lhs, LocalKeywordSpace rhs); // 0x0000000180A29AB0-0x0000000180A29AC0
		public override int GetHashCode(); // 0x00000001814330E0-0x00000001814330F0
		private static void GetKeyword_Injected(ref LocalKeywordSpace _unity_self, ref ManagedSpanWrapper name, ); // 0x000000018225D0C0-0x000000018225D120
	}
}
