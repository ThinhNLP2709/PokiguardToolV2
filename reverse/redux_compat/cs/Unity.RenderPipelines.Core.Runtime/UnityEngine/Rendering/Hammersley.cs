/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public static class Hammersley // TypeDefIndex: 5694
	{
		// Fields
		private static readonly float[] k_Hammersley2dSeq16; // 0x00
		private static readonly float[] k_Hammersley2dSeq32; // 0x08
		private static readonly float[] k_Hammersley2dSeq64; // 0x10
		private static readonly float[] k_Hammersley2dSeq256; // 0x18
		private static readonly int s_hammersley2DSeq16Id; // 0x20
		private static readonly int s_hammersley2DSeq32Id; // 0x24
		private static readonly int s_hammersley2DSeq64Id; // 0x28
		private static readonly int s_hammersley2DSeq256Id; // 0x2C
	
		// Nested types
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@4f216c697b2e\\Runtime\\ShaderLibrary\\Sampling\\Hammersley.cs", needAccessors = false, generateCBuffer = true)]
		private struct Hammersley2dSeq16 // TypeDefIndex: 5695
		{
			// Fields
			[HLSLArray(16, typeof(Vector4))]
			public unsafe fixed /* 0x00000000-0x00000000 */ float hammersley2dSeq16[0]; // 0x00
	
			// Nested types
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _hammersley2dSeq16_e__FixedBuffer // TypeDefIndex: 5696
			{
				// Fields
				public float FixedElementField; // 0x00
			}
		}
	
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@4f216c697b2e\\Runtime\\ShaderLibrary\\Sampling\\Hammersley.cs", needAccessors = false, generateCBuffer = true)]
		private struct Hammersley2dSeq32 // TypeDefIndex: 5697
		{
			// Fields
			[HLSLArray(32, typeof(Vector4))]
			public unsafe fixed /* 0x00000000-0x00000000 */ float hammersley2dSeq32[0]; // 0x00
	
			// Nested types
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _hammersley2dSeq32_e__FixedBuffer // TypeDefIndex: 5698
			{
				// Fields
				public float FixedElementField; // 0x00
			}
		}
	
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@4f216c697b2e\\Runtime\\ShaderLibrary\\Sampling\\Hammersley.cs", needAccessors = false, generateCBuffer = true)]
		private struct Hammersley2dSeq64 // TypeDefIndex: 5699
		{
			// Fields
			[HLSLArray(64, typeof(Vector4))]
			public unsafe fixed /* 0x00000000-0x00000000 */ float hammersley2dSeq64[0]; // 0x00
	
			// Nested types
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _hammersley2dSeq64_e__FixedBuffer // TypeDefIndex: 5700
			{
				// Fields
				public float FixedElementField; // 0x00
			}
		}
	
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@4f216c697b2e\\Runtime\\ShaderLibrary\\Sampling\\Hammersley.cs", needAccessors = false, generateCBuffer = true)]
		private struct Hammersley2dSeq256 // TypeDefIndex: 5701
		{
			// Fields
			[HLSLArray(256, typeof(Vector4))]
			public unsafe fixed /* 0x00000000-0x00000000 */ float hammersley2dSeq256[0]; // 0x00
	
			// Nested types
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _hammersley2dSeq256_e__FixedBuffer // TypeDefIndex: 5702
			{
				// Fields
				public float FixedElementField; // 0x00
			}
		}
	
		// Constructors
		static Hammersley(); // 0x0000000181E8DA40-0x0000000181E8DD90
	
		// Methods
		public static void Initialize(); // 0x0000000181E8D660-0x0000000181E8DA40
		public static void BindConstants(CommandBuffer cmd, ComputeShader cs); // 0x0000000181E8D350-0x0000000181E8D490
		public static void BindConstants(IComputeCommandBuffer cmd, ComputeShader cs); // 0x0000000181E8D490-0x0000000181E8D660
	}
}
