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
	[NativeHeader("Runtime/Shaders/Keywords/KeywordSpaceScriptBindings.h")]
	[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
	[UsedByNativeCode]
	public struct LocalKeyword : IEquatable<LocalKeyword> // TypeDefIndex: 8452
	{
		// Fields
		internal readonly LocalKeywordSpace m_SpaceInfo; // 0x00
		internal readonly string m_Name; // 0x08
		internal readonly uint m_Index; // 0x10
	
		// Properties
		public string name { get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
		public bool isValid { get; } // 0x000000018225E120-0x000000018225E160 
	
		// Constructors
		public LocalKeyword(Shader shader, string name); // 0x000000018225DF50-0x000000018225E120
		public LocalKeyword(ComputeShader shader, string name); // 0x000000018225DB80-0x000000018225DD50
		public LocalKeyword(RayTracingShader shader, string name); // 0x000000018225DD50-0x000000018225DF50
	
		// Methods
		[FreeFunction("ShaderScripting::GetKeywordCount")]
		private static uint GetShaderKeywordCount(Shader shader); // 0x000000018225D900-0x000000018225D940
		[FreeFunction("ShaderScripting::GetKeywordIndex")]
		private static uint GetShaderKeywordIndex(Shader shader, string keyword); // 0x000000018225D990-0x000000018225DB00
		[FreeFunction("ShaderScripting::GetKeywordCount")]
		private static uint GetComputeShaderKeywordCount(ComputeShader shader); // 0x000000018225D440-0x000000018225D480
		[FreeFunction("ShaderScripting::GetKeywordIndex")]
		private static uint GetComputeShaderKeywordIndex(ComputeShader shader, string keyword); // 0x000000018225D4D0-0x000000018225D640
		[FreeFunction("ShaderScripting::GetKeywordCount")]
		private static uint GetRayTracingShaderKeywordCount(RayTracingShader shader); // 0x000000018225D6C0-0x000000018225D700
		[FreeFunction("ShaderScripting::GetKeywordIndex")]
		private static uint GetRayTracingShaderKeywordIndex(RayTracingShader shader, string keyword); // 0x000000018225D750-0x000000018225D8C0
		[FreeFunction("keywords::IsKeywordValid")]
		private static bool IsValid(LocalKeywordSpace spaceInfo, uint keyword); // 0x000000018225DB40-0x000000018225DB80
		public override string ToString(); // 0x0000000180C5CF90-0x0000000180C5CFA0
		public override bool Equals(object o); // 0x000000018225D320-0x000000018225D3D0
		public bool Equals(LocalKeyword rhs); // 0x000000018225D3D0-0x000000018225D400
		public override int GetHashCode(); // 0x000000018225D640-0x000000018225D680
		private static uint GetShaderKeywordCount_Injected(IntPtr shader); // 0x000000018225D8C0-0x000000018225D900
		private static uint GetShaderKeywordIndex_Injected(IntPtr shader, ref ManagedSpanWrapper keyword); // 0x000000018225D940-0x000000018225D990
		private static uint GetComputeShaderKeywordCount_Injected(IntPtr shader); // 0x000000018225D400-0x000000018225D440
		private static uint GetComputeShaderKeywordIndex_Injected(IntPtr shader, ref ManagedSpanWrapper keyword); // 0x000000018225D480-0x000000018225D4D0
		private static uint GetRayTracingShaderKeywordCount_Injected(IntPtr shader); // 0x000000018225D680-0x000000018225D6C0
		private static uint GetRayTracingShaderKeywordIndex_Injected(IntPtr shader, ref ManagedSpanWrapper keyword); // 0x000000018225D700-0x000000018225D750
		private static bool IsValid_Injected(in LocalKeywordSpace spaceInfo, uint keyword); // 0x000000018225DB00-0x000000018225DB40
	}
}
