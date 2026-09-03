/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal static class Shaders // TypeDefIndex: 5149
	{
		// Fields
		public static readonly string k_AtlasBlit; // 0x00
		public static readonly string k_Default; // 0x08
		public static readonly string k_RuntimeGaussianBlur; // 0x10
		public static readonly string k_RuntimeColorEffect; // 0x18
		public static readonly string k_RuntimeDropShadowComposite; // 0x20
		public static readonly string k_ColorConversionBlit; // 0x28
		public static readonly string k_ForceGammaKeyword; // 0x30
		public static readonly string k_OutputLinearKeyword; // 0x38
		public static readonly string k_TextureSlotCount1; // 0x40
		public static readonly string k_TextureSlotCount2; // 0x48
		public static readonly string k_TextureSlotCount4; // 0x50
		public static readonly string k_ForceRenderTypeSolid; // 0x58
		public static readonly string k_ForceRenderTypeTextured; // 0x60
		public static readonly string k_ForceRenderTypeText; // 0x68
		public static readonly string k_ForceRenderTypeSvgGradient; // 0x70
		[NoAutoStaticsCleanup]
		private static Material s_DefaultMaterial; // 0x78
		[NoAutoStaticsCleanup]
		private static int s_RefCount; // 0x80
	
		// Properties
		public static Material defaultMaterial { get; } // 0x0000000182446C80-0x0000000182446E20 
	
		// Constructors
		static Shaders(); // 0x0000000182446870-0x0000000182446C80
	
		// Methods
		private static Material GetOrCreateMaterial(ref Material material, string shaderName); // 0x00000001824465D0-0x0000000182446720
		public static void Acquire(); // 0x0000000182446570-0x00000001824465D0
		public static void Release(); // 0x0000000182446720-0x0000000182446870
	}
}
