/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	public class DebugDisplaySettingsLighting : IDebugDisplaySettingsData, ISerializedDebugDisplaySettings // TypeDefIndex: 9335
	{
		// Fields
		[CompilerGenerated]
		private DebugLightingMode _lightingDebugMode_k__BackingField; // 0x10
		[CompilerGenerated]
		private DebugLightingFeatureFlags _lightingFeatureFlags_k__BackingField; // 0x14
		[CompilerGenerated]
		private HDRDebugMode _hdrDebugMode_k__BackingField; // 0x18
	
		// Properties
		public DebugLightingMode lightingDebugMode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public DebugLightingFeatureFlags lightingFeatureFlags { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		public HDRDebugMode hdrDebugMode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public bool AreAnySettingsActive { get; } // 0x0000000181F55EE0-0x0000000181F55F00 
		public bool IsPostProcessingAllowed { get; } // 0x0000000181F55F00-0x0000000181F55F20 
		public bool IsLightingActive { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Nested types
		internal static class Strings // TypeDefIndex: 9336
		{
			// Fields
			public static readonly DebugUI.Widget.NameAndTooltip LightingDebugMode; // 0x00
			public static readonly DebugUI.Widget.NameAndTooltip LightingFeatures; // 0x10
			public static readonly DebugUI.Widget.NameAndTooltip HDRDebugMode; // 0x20
	
			// Constructors
			static Strings(); // 0x0000000181F60130-0x0000000181F602D0
		}
	
		internal static class WidgetFactory // TypeDefIndex: 9337
		{
			// Nested types
			[CompilerGenerated]
			private sealed class __c__DisplayClass0_0 // TypeDefIndex: 9338
			{
				// Fields
				public DebugDisplaySettingsLighting data; // 0x10
	
				// Constructors
				public __c__DisplayClass0_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreateLightingDebugMode_b__0(); // 0x0000000181463040-0x0000000181463060
				internal void _CreateLightingDebugMode_b__1(int value); // 0x0000000181F615C0-0x0000000181F615E0
				internal int _CreateLightingDebugMode_b__2(); // 0x0000000181463040-0x0000000181463060
				internal void _CreateLightingDebugMode_b__3(int value); // 0x0000000181F615C0-0x0000000181F615E0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass1_0 // TypeDefIndex: 9339
			{
				// Fields
				public DebugDisplaySettingsLighting data; // 0x10
	
				// Constructors
				public __c__DisplayClass1_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal Enum _CreateLightingFeatures_b__0(); // 0x0000000181F61B00-0x0000000181F61B60
				internal void _CreateLightingFeatures_b__1(Enum value); // 0x0000000181F61B60-0x0000000181F61BE0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass2_0 // TypeDefIndex: 9340
			{
				// Fields
				public DebugDisplaySettingsLighting data; // 0x10
	
				// Constructors
				public __c__DisplayClass2_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreateHDRDebugMode_b__0(); // 0x0000000180B5F570-0x0000000180B5F590
				internal void _CreateHDRDebugMode_b__1(int value); // 0x0000000181F61D80-0x0000000181F61DA0
				internal int _CreateHDRDebugMode_b__2(); // 0x0000000180B5F570-0x0000000180B5F590
				internal void _CreateHDRDebugMode_b__3(int value); // 0x0000000181F61D80-0x0000000181F61DA0
			}
	
			// Methods
			internal static DebugUI.Widget CreateLightingDebugMode(DebugDisplaySettingsLighting data); // 0x0000000181F666A0-0x0000000181F668F0
			internal static DebugUI.Widget CreateLightingFeatures(DebugDisplaySettingsLighting data); // 0x0000000181F668F0-0x0000000181F66AB0
			internal static DebugUI.Widget CreateHDRDebugMode(DebugDisplaySettingsLighting data); // 0x0000000181F662C0-0x0000000181F66510
		}
	
		[DisplayInfo(name = "Lighting", order = 3)]
		internal class SettingsPanel : DebugDisplaySettingsPanel<DebugDisplaySettingsLighting> // TypeDefIndex: 9341
		{
			// Constructors
			public SettingsPanel(DebugDisplaySettingsLighting data); // 0x0000000181F5D4E0-0x0000000181F5D6D0
		}
	
		// Constructors
		public DebugDisplaySettingsLighting(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		IDebugDisplaySettingsPanelDisposable IDebugDisplaySettingsData.CreatePanel(); // 0x0000000181F55E80-0x0000000181F55EE0
	}
}
