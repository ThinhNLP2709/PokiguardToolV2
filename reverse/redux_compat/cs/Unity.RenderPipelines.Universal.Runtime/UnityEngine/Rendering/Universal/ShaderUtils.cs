/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public static class ShaderUtils // TypeDefIndex: 9780
	{
		// Fields
		private static readonly string[] s_ShaderPaths; // 0x00
	
		// Properties
		internal static float PersistentDeltaTime { get; } // 0x0000000181FE5730-0x0000000181FE5740 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass2_0 // TypeDefIndex: 9781
		{
			// Fields
			public string path; // 0x10
	
			// Constructors
			public __c__DisplayClass2_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _GetEnumFromPath_b__0(string m); // 0x0000000181FF42F0-0x0000000181FF4310
		}
	
		// Constructors
		static ShaderUtils(); // 0x0000000181FE5480-0x0000000181FE5730
	
		// Methods
		public static string GetShaderPath(ShaderPathID id); // 0x0000000181FE51D0-0x0000000181FE53F0
		public static ShaderPathID GetEnumFromPath(string path); // 0x0000000181FE50C0-0x0000000181FE51D0
		public static bool IsLWShader(Shader shader); // 0x0000000181FE53F0-0x0000000181FE5480
	}
}
