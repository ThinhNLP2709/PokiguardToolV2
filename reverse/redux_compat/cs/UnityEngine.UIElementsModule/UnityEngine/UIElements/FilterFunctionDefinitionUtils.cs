/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal static class FilterFunctionDefinitionUtils // TypeDefIndex: 4158
	{
		// Fields
		private static FilterFunctionDefinition s_BlurDef; // 0x00
		private static FilterFunctionDefinition s_TintDef; // 0x08
		private static FilterFunctionDefinition s_OpacityDef; // 0x10
		private static FilterFunctionDefinition s_InvertDef; // 0x18
		private static FilterFunctionDefinition s_GrayscaleDef; // 0x20
		private static FilterFunctionDefinition s_SepiaDef; // 0x28
		private static FilterFunctionDefinition s_ContrastDef; // 0x30
		private static FilterFunctionDefinition s_HueRotateDef; // 0x38
		private static FilterFunctionDefinition s_DropShadowDef; // 0x40
	
		// Nested types
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 4159
		{
			// Fields
			public static PostProcessingPass.ComputeRequiredMarginsDelegate _0___ComputeHorizontalBlurMargins; // 0x00
			public static PostProcessingPass.ApplyFilterPassSettingsDelegate _1___ApplyBlurSettings; // 0x08
			public static PostProcessingPass.ComputeRequiredMarginsDelegate _2___ComputeVerticalBlurMargins; // 0x10
			public static PostProcessingPass.ApplyFilterPassSettingsDelegate _3___ApplySettings; // 0x18
			public static PostProcessingPass.ComputeRequiredMarginsDelegate _4___ComputeDropShadowHorizontalBlurMargins; // 0x20
			public static PostProcessingPass.ApplyFilterPassSettingsDelegate _5___ApplyDropShadowBlurSettings; // 0x28
			public static PostProcessingPass.ComputeRequiredMarginsDelegate _6___ComputeDropShadowVerticalBlurMargins; // 0x30
			public static PostProcessingPass.ComputeRequiredMarginsDelegate _7___ComputeDropShadowCompositeReadMargins; // 0x38
			public static PostProcessingPass.ComputeRequiredMarginsDelegate _8___ComputeDropShadowCompositeWriteMargins; // 0x40
			public static PostProcessingPass.ApplyFilterPassSettingsDelegate _9___ApplyDropShadowCompositeSettings; // 0x48
		}
	
		// Methods
		public static string GetBuiltinFilterName(FilterFunctionType type); // 0x0000000182494E00-0x0000000182494F50
		public static FilterFunctionDefinition GetBuiltinDefinition(FilterFunctionType type); // 0x00000001824948C0-0x0000000182494E00
		private static FilterFunctionDefinition CreateBlurFilterFunctionDefinition(); // 0x00000001824928A0-0x0000000182493350
		private static FilterFunctionDefinition CreateColorEffectFilterFunctionDefinition(FilterFunctionType filterType); // 0x0000000182493350-0x0000000182493870
		private static FilterFunctionDefinition CreateDropShadowFilterFunctionDefinition(); // 0x0000000182493870-0x00000001824948C0
		private static PostProcessingMargins ComputeHorizontalBlurMargins(FilterFunction func); // 0x0000000182492690-0x0000000182492790
		private static PostProcessingMargins ComputeVerticalBlurMargins(FilterFunction func); // 0x0000000182492790-0x00000001824928A0
		private static void ApplyBlurSettings(MaterialPropertyBlock mpb, FilterPassContext context); // 0x0000000182491730-0x00000001824917F0
		private static PostProcessingMargins ComputeDropShadowHorizontalBlurMargins(FilterFunction func); // 0x0000000182492490-0x0000000182492590
		private static PostProcessingMargins ComputeDropShadowVerticalBlurMargins(FilterFunction func); // 0x0000000182492590-0x0000000182492690
		private static void ApplyDropShadowBlurSettings(MaterialPropertyBlock mpb, FilterPassContext context); // 0x00000001824917F0-0x00000001824918B0
		private static PostProcessingMargins ComputeDropShadowCompositeReadMargins(FilterFunction func); // 0x00000001824922E0-0x00000001824923C0
		private static PostProcessingMargins ComputeDropShadowCompositeWriteMargins(FilterFunction func); // 0x00000001824923C0-0x0000000182492490
		private static void ApplyDropShadowCompositeSettings(MaterialPropertyBlock mpb, FilterPassContext context); // 0x00000001824918B0-0x0000000182491A10
		private static void ApplySettings(MaterialPropertyBlock mpb, FilterPassContext context); // 0x0000000182491A10-0x00000001824922E0
	}
}
