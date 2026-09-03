/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal static class PlatformAutoDetect // TypeDefIndex: 9852
	{
		// Fields
		private static readonly Lazy<PlatformDetectionCache> platformCache; // 0x00
	
		// Properties
		internal static bool isXRMobile { get; } // 0x0000000181FF8620-0x0000000181FF86A0 
		internal static bool isShaderAPIMobileDefined { get; } // 0x0000000181FF84A0-0x0000000181FF8520 
		internal static bool isSwitch { get; } // 0x0000000181FF85A0-0x0000000181FF8620 
		internal static bool isSwitch2 { get; } // 0x0000000181FF8520-0x0000000181FF85A0 
		internal static bool isRunningOnPowerVRGPU { get; } // 0x0000000181FF8420-0x0000000181FF84A0 
		internal static bool hasRenderToR32F { get; } // 0x0000000181FF83A0-0x0000000181FF8420 
		internal static int maxSupportedShadowAtlasResolution { get; } // 0x0000000181FF86A0-0x0000000181FF8720 
	
		// Nested types
		private sealed class PlatformDetectionCache // TypeDefIndex: 9853
		{
			// Fields
			public readonly bool isXRMobile; // 0x10
			public readonly bool isShaderAPIMobileDefined; // 0x11
			public readonly bool isSwitch; // 0x12
			public readonly bool isSwitch2; // 0x13
			public readonly bool isRunningOnPowerVRGPU; // 0x14
			public readonly bool hasRenderToR32F; // 0x15
			public readonly int maxSupportedShadowAtlasResolution; // 0x18
	
			// Constructors
			public PlatformDetectionCache(); // 0x0000000181FF8720-0x0000000181FF8860
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9854
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x0000000181FFB630-0x0000000181FFB6A0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal PlatformDetectionCache _.cctor_b__18_0(); // 0x0000000181FFB390-0x0000000181FFB500
		}
	
		// Constructors
		static PlatformAutoDetect(); // 0x0000000181FF8290-0x0000000181FF83A0
	
		// Methods
		internal static void Initialize(); // 0x0000000181FF80B0-0x0000000181FF8120
		internal static ShEvalMode ShAutoDetect(ShEvalMode mode); // 0x0000000181FF8120-0x0000000181FF8290
	}
}
