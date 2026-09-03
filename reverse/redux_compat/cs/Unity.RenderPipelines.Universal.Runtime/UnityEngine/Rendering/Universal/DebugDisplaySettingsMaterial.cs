/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	public class DebugDisplaySettingsMaterial : IDebugDisplaySettingsData, ISerializedDebugDisplaySettings // TypeDefIndex: 9342
	{
		// Fields
		private AlbedoDebugValidationPresetData[] m_AlbedoDebugValidationPresetData; // 0x10
		private AlbedoDebugValidationPreset m_AlbedoValidationPreset; // 0x18
		[CompilerGenerated]
		private float _albedoMinLuminance_k__BackingField; // 0x1C
		[CompilerGenerated]
		private float _albedoMaxLuminance_k__BackingField; // 0x20
		private float m_AlbedoHueTolerance; // 0x24
		private float m_AlbedoSaturationTolerance; // 0x28
		[CompilerGenerated]
		private Color _albedoCompareColor_k__BackingField; // 0x2C
		[CompilerGenerated]
		private float _metallicMinValue_k__BackingField; // 0x3C
		[CompilerGenerated]
		private float _metallicMaxValue_k__BackingField; // 0x40
		[CompilerGenerated]
		private bool _renderingLayersSelectedLight_k__BackingField; // 0x44
		[CompilerGenerated]
		private bool _selectedLightShadowLayerMask_k__BackingField; // 0x45
		[CompilerGenerated]
		private uint _renderingLayerMask_k__BackingField; // 0x48
		public Vector4[] debugRenderingLayersColors; // 0x50
		[CompilerGenerated]
		private DebugMaterialValidationMode _materialValidationMode_k__BackingField; // 0x58
		[CompilerGenerated]
		private DebugMaterialMode _materialDebugMode_k__BackingField; // 0x5C
		[CompilerGenerated]
		private DebugVertexAttributeMode _vertexAttributeDebugMode_k__BackingField; // 0x60
	
		// Properties
		public AlbedoDebugValidationPreset albedoValidationPreset { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000181F56B90-0x0000000181F56C00
		public float albedoMinLuminance { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CE2A30-0x0000000181CE2A40 0x0000000181EB7970-0x0000000181EB7980
		public float albedoMaxLuminance { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CE2820-0x0000000181CE2830 0x0000000181CE28D0-0x0000000181CE28E0
		public float albedoHueTolerance { get; set; } // 0x0000000181F56B30-0x0000000181F56B50 0x0000000181CE28E0-0x0000000181CE28F0
		public float albedoSaturationTolerance { get; set; } // 0x0000000181F56B50-0x0000000181F56B70 0x0000000180F997A0-0x0000000180F997B0
		public Color albedoCompareColor { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181F56B20-0x0000000181F56B30 0x0000000181F56B80-0x0000000181F56B90
		public float metallicMinValue { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181C58AB0-0x0000000181C58AC0 0x0000000181DBEB40-0x0000000181DBEB50
		public float metallicMaxValue { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181D8CC60-0x0000000181D8CC70 0x0000000181F56C00-0x0000000181F56C10
		public bool renderingLayersSelectedLight { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018180F140-0x000000018180F150 0x000000018180F150-0x000000018180F160
		public bool selectedLightShadowLayerMask { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181F56B70-0x0000000181F56B80 0x0000000181F56C10-0x0000000181F56C20
		public uint renderingLayerMask { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D1C0-0x000000018033D1D0 0x000000018033E7A0-0x000000018033E7B0
		public DebugMaterialValidationMode materialValidationMode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D260-0x000000018033D270 0x000000018033E870-0x000000018033E880
		public DebugMaterialMode materialDebugMode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D270-0x000000018033D280 0x000000018033E880-0x000000018033E890
		public DebugVertexAttributeMode vertexAttributeDebugMode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018150C180-0x000000018150C190 0x000000018041DC00-0x000000018041DC10
		public bool AreAnySettingsActive { get; } // 0x0000000181F56AE0-0x0000000181F56B00 
		public bool IsPostProcessingAllowed { get; } // 0x0000000181F56B00-0x0000000181F56B20 
		public bool IsLightingActive { get; } // 0x0000000181F56B00-0x0000000181F56B20 
	
		// Nested types
		public enum AlbedoDebugValidationPreset // TypeDefIndex: 9343
		{
			DefaultLuminance = 0,
			BlackAcrylicPaint = 1,
			DarkSoil = 2,
			WornAsphalt = 3,
			DryClaySoil = 4,
			GreenGrass = 5,
			OldConcrete = 6,
			RedClayTile = 7,
			DrySand = 8,
			NewConcrete = 9,
			WhiteAcrylicPaint = 10,
			FreshSnow = 11,
			BlueSky = 12,
			Foliage = 13,
			Custom = 14
		}
	
		private struct AlbedoDebugValidationPresetData // TypeDefIndex: 9344
		{
			// Fields
			public string name; // 0x00
			public Color color; // 0x08
			public float minLuminance; // 0x18
			public float maxLuminance; // 0x1C
		}
	
		private static class Strings // TypeDefIndex: 9345
		{
			// Fields
			public const string AlbedoSettingsContainerName = "Albedo Settings"; // Metadata: 0x0069E9AA
			public const string MetallicSettingsContainerName = "Metallic Settings"; // Metadata: 0x0069E9BA
			public const string RenderingLayerMasksSettingsContainerName = "Rendering Layer Masks Settings"; // Metadata: 0x0069E9CC
			public static readonly DebugUI.Widget.NameAndTooltip MaterialOverride; // 0x00
			public static readonly DebugUI.Widget.NameAndTooltip VertexAttribute; // 0x10
			public static readonly DebugUI.Widget.NameAndTooltip MaterialValidationMode; // 0x20
			public static readonly DebugUI.Widget.NameAndTooltip RenderingLayersSelectedLight; // 0x30
			public static readonly DebugUI.Widget.NameAndTooltip SelectedLightShadowLayerMask; // 0x40
			public static readonly DebugUI.Widget.NameAndTooltip FilterRenderingLayerMask; // 0x50
			public static readonly DebugUI.Widget.NameAndTooltip ValidationPreset; // 0x60
			public static readonly DebugUI.Widget.NameAndTooltip AlbedoCustomColor; // 0x70
			public static readonly DebugUI.Widget.NameAndTooltip AlbedoMinLuminance; // 0x80
			public static readonly DebugUI.Widget.NameAndTooltip AlbedoMaxLuminance; // 0x90
			public static readonly DebugUI.Widget.NameAndTooltip AlbedoHueTolerance; // 0xA0
			public static readonly DebugUI.Widget.NameAndTooltip AlbedoSaturationTolerance; // 0xB0
			public static readonly DebugUI.Widget.NameAndTooltip MetallicMinValue; // 0xC0
			public static readonly DebugUI.Widget.NameAndTooltip MetallicMaxValue; // 0xD0
	
			// Constructors
			static Strings(); // 0x0000000181F603C0-0x0000000181F60A50
		}
	
		internal static class WidgetFactory // TypeDefIndex: 9346
		{
			// Nested types
			[CompilerGenerated]
			private sealed class __c__DisplayClass0_0 // TypeDefIndex: 9347
			{
				// Fields
				public DebugDisplaySettingsMaterial data; // 0x10
	
				// Constructors
				public __c__DisplayClass0_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreateMaterialOverride_b__0(); // 0x0000000181F615E0-0x0000000181F61600
				internal void _CreateMaterialOverride_b__1(int value); // 0x0000000181F61600-0x0000000181F61620
				internal int _CreateMaterialOverride_b__2(); // 0x0000000181F615E0-0x0000000181F61600
				internal void _CreateMaterialOverride_b__3(int value); // 0x0000000181F61600-0x0000000181F61620
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass10_0 // TypeDefIndex: 9348
			{
				// Fields
				public DebugDisplaySettingsMaterial data; // 0x10
	
				// Constructors
				public __c__DisplayClass10_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal float _CreateAlbedoHueTolerance_b__0(); // 0x0000000181F61680-0x0000000181F616B0
				internal void _CreateAlbedoHueTolerance_b__1(float value); // 0x0000000181F616B0-0x0000000181F616D0
				internal bool _CreateAlbedoHueTolerance_b__2(); // 0x0000000181F616D0-0x0000000181F616F0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass11_0 // TypeDefIndex: 9349
			{
				// Fields
				public DebugDisplaySettingsMaterial data; // 0x10
	
				// Constructors
				public __c__DisplayClass11_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal float _CreateAlbedoSaturationTolerance_b__0(); // 0x0000000181F61850-0x0000000181F61880
				internal void _CreateAlbedoSaturationTolerance_b__1(float value); // 0x0000000180719970-0x0000000180719990
				internal bool _CreateAlbedoSaturationTolerance_b__2(); // 0x0000000181F616D0-0x0000000181F616F0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass12_0 // TypeDefIndex: 9350
			{
				// Fields
				public DebugDisplaySettingsMaterial data; // 0x10
	
				// Constructors
				public __c__DisplayClass12_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal float _CreateMetallicMinValue_b__0(); // 0x0000000181F618C0-0x0000000181F618E0
				internal void _CreateMetallicMinValue_b__1(float value); // 0x0000000181F618E0-0x0000000181F61900
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass13_0 // TypeDefIndex: 9351
			{
				// Fields
				public DebugDisplaySettingsMaterial data; // 0x10
	
				// Constructors
				public __c__DisplayClass13_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal float _CreateMetallicMaxValue_b__0(); // 0x0000000181F61760-0x0000000181F61780
				internal void _CreateMetallicMaxValue_b__1(float value); // 0x0000000181F61780-0x0000000181F617A0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass1_0 // TypeDefIndex: 9352
			{
				// Fields
				public DebugDisplaySettingsMaterial data; // 0x10
	
				// Constructors
				public __c__DisplayClass1_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreateVertexAttribute_b__0(); // 0x0000000181F61A80-0x0000000181F61AA0
				internal void _CreateVertexAttribute_b__1(int value); // 0x0000000181F61AA0-0x0000000181F61AC0
				internal int _CreateVertexAttribute_b__2(); // 0x0000000181F61A80-0x0000000181F61AA0
				internal void _CreateVertexAttribute_b__3(int value); // 0x0000000181F61AA0-0x0000000181F61AC0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass2_0 // TypeDefIndex: 9353
			{
				// Fields
				public DebugDisplaySettingsMaterial data; // 0x10
	
				// Constructors
				public __c__DisplayClass2_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreateMaterialValidationMode_b__0(); // 0x0000000181F61E30-0x0000000181F61E50
				internal void _CreateMaterialValidationMode_b__1(int value); // 0x0000000181F61E50-0x0000000181F61E70
				internal int _CreateMaterialValidationMode_b__2(); // 0x0000000181F61E30-0x0000000181F61E50
				internal void _CreateMaterialValidationMode_b__3(int value); // 0x0000000181F61E50-0x0000000181F61E70
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass3_0 // TypeDefIndex: 9354
			{
				// Fields
				public DebugDisplaySettingsMaterial data; // 0x10
	
				// Constructors
				public __c__DisplayClass3_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _CreateRenderingLayersSelectedLight_b__0(); // 0x0000000181F61EE0-0x0000000181F61F00
				internal void _CreateRenderingLayersSelectedLight_b__1(bool value); // 0x0000000181F61F00-0x0000000181F61F20
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass4_0 // TypeDefIndex: 9355
			{
				// Fields
				public DebugDisplaySettingsMaterial data; // 0x10
	
				// Constructors
				public __c__DisplayClass4_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _CreateSelectedLightShadowLayerMask_b__0(); // 0x0000000181F61F20-0x0000000181F61F40
				internal void _CreateSelectedLightShadowLayerMask_b__1(bool value); // 0x0000000181F61F40-0x0000000181F61F60
				internal bool _CreateSelectedLightShadowLayerMask_b__2(); // 0x0000000181F61F60-0x0000000181F61F80
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass5_0 // TypeDefIndex: 9356
			{
				// Fields
				public DebugDisplaySettingsMaterial data; // 0x10
	
				// Constructors
				public __c__DisplayClass5_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal RenderingLayerMask _CreateFilterRenderingLayerMasks_b__0(); // 0x0000000181F61FC0-0x0000000181F62020
				internal void _CreateFilterRenderingLayerMasks_b__1(RenderingLayerMask value); // 0x0000000181F62020-0x0000000181F62080
				internal Vector4 _CreateFilterRenderingLayerMasks_b__2(int index); // 0x0000000181F62080-0x0000000181F620D0
				internal void _CreateFilterRenderingLayerMasks_b__3(Vector4 value, int index); // 0x0000000181F620D0-0x0000000181F62110
				internal bool _CreateFilterRenderingLayerMasks_b__4(); // 0x0000000181F61EE0-0x0000000181F61F00
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass6_0 // TypeDefIndex: 9357
			{
				// Fields
				public DebugDisplaySettingsMaterial data; // 0x10
	
				// Constructors
				public __c__DisplayClass6_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreateAlbedoPreset_b__0(); // 0x0000000180B5F570-0x0000000180B5F590
				internal void _CreateAlbedoPreset_b__1(int value); // 0x0000000181F62180-0x0000000181F621F0
				internal int _CreateAlbedoPreset_b__2(); // 0x0000000180B5F570-0x0000000180B5F590
				internal void _CreateAlbedoPreset_b__3(int value); // 0x0000000181F62180-0x0000000181F621F0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass7_0 // TypeDefIndex: 9358
			{
				// Fields
				public DebugDisplaySettingsMaterial data; // 0x10
	
				// Constructors
				public __c__DisplayClass7_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal Color _CreateAlbedoCustomColor_b__0(); // 0x0000000181F62230-0x0000000181F62260
				internal void _CreateAlbedoCustomColor_b__1(Color value); // 0x0000000181F62260-0x0000000181F62280
				internal bool _CreateAlbedoCustomColor_b__2(); // 0x0000000181F62280-0x0000000181F622A0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass8_0 // TypeDefIndex: 9359
			{
				// Fields
				public DebugDisplaySettingsMaterial data; // 0x10
	
				// Constructors
				public __c__DisplayClass8_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal float _CreateAlbedoMinLuminance_b__0(); // 0x0000000181F4A530-0x0000000181F4A550
				internal void _CreateAlbedoMinLuminance_b__1(float value); // 0x0000000181F4A550-0x0000000181F4A570
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass9_0 // TypeDefIndex: 9360
			{
				// Fields
				public DebugDisplaySettingsMaterial data; // 0x10
	
				// Constructors
				public __c__DisplayClass9_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal float _CreateAlbedoMaxLuminance_b__0(); // 0x0000000181F622E0-0x0000000181F62300
				internal void _CreateAlbedoMaxLuminance_b__1(float value); // 0x0000000181F62300-0x0000000181F62320
			}
	
			// Methods
			internal static DebugUI.Widget CreateMaterialOverride(DebugDisplaySettingsMaterial data); // 0x0000000181F672D0-0x0000000181F67520
			internal static DebugUI.Widget CreateVertexAttribute(DebugDisplaySettingsMaterial data); // 0x0000000181F6ACD0-0x0000000181F6AF20
			internal static DebugUI.Widget CreateMaterialValidationMode(DebugDisplaySettingsMaterial data); // 0x0000000181F67520-0x0000000181F67770
			internal static DebugUI.Widget CreateRenderingLayersSelectedLight(DebugDisplaySettingsMaterial data); // 0x0000000181F6A2C0-0x0000000181F6A450
			internal static DebugUI.Widget CreateSelectedLightShadowLayerMask(DebugDisplaySettingsMaterial data); // 0x0000000181F6A450-0x0000000181F6A620
			internal static DebugUI.RenderingLayerField CreateFilterRenderingLayerMasks(DebugDisplaySettingsMaterial data); // 0x0000000181F66040-0x0000000181F662C0
			internal static DebugUI.Widget CreateAlbedoPreset(DebugDisplaySettingsMaterial data); // 0x0000000181F659D0-0x0000000181F65C20
			internal static DebugUI.Widget CreateAlbedoCustomColor(DebugDisplaySettingsMaterial data); // 0x0000000181F652D0-0x0000000181F654B0
			internal static DebugUI.Widget CreateAlbedoMinLuminance(DebugDisplaySettingsMaterial data); // 0x0000000181F65830-0x0000000181F659D0
			internal static DebugUI.Widget CreateAlbedoMaxLuminance(DebugDisplaySettingsMaterial data); // 0x0000000181F65690-0x0000000181F65830
			internal static DebugUI.Widget CreateAlbedoHueTolerance(DebugDisplaySettingsMaterial data); // 0x0000000181F654B0-0x0000000181F65690
			internal static DebugUI.Widget CreateAlbedoSaturationTolerance(DebugDisplaySettingsMaterial data); // 0x0000000181F65C20-0x0000000181F65E00
			internal static DebugUI.Widget CreateMetallicMinValue(DebugDisplaySettingsMaterial data); // 0x0000000181F67C90-0x0000000181F67E30
			internal static DebugUI.Widget CreateMetallicMaxValue(DebugDisplaySettingsMaterial data); // 0x0000000181F67AF0-0x0000000181F67C90
		}
	
		[DisplayInfo(name = "Material", order = 2)]
		internal class SettingsPanel : DebugDisplaySettingsPanel<DebugDisplaySettingsMaterial> // TypeDefIndex: 9361
		{
			// Nested types
			[CompilerGenerated]
			private sealed class __c__DisplayClass0_0 // TypeDefIndex: 9362
			{
				// Fields
				public DebugDisplaySettingsMaterial data; // 0x10
	
				// Constructors
				public __c__DisplayClass0_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _.ctor_b__0(); // 0x0000000181F61620-0x0000000181F61640
				internal bool _.ctor_b__1(); // 0x0000000181F61640-0x0000000181F61660
				internal bool _.ctor_b__2(); // 0x0000000181F61660-0x0000000181F61680
			}
	
			// Constructors
			public SettingsPanel(DebugDisplaySettingsMaterial data); // 0x0000000181F5D6D0-0x0000000181F5EA60
		}
	
		// Constructors
		public DebugDisplaySettingsMaterial(); // 0x0000000181F55F80-0x0000000181F56AE0
	
		// Methods
		public uint GetDebugLightLayersMask(); // 0x0000000181547E70-0x0000000181547E80
		IDebugDisplaySettingsPanelDisposable IDebugDisplaySettingsData.CreatePanel(); // 0x0000000181F55F20-0x0000000181F55F80
	}
}
