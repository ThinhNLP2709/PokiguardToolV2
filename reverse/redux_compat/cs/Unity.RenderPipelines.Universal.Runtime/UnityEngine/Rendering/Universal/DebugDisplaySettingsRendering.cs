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
	public class DebugDisplaySettingsRendering : IDebugDisplaySettingsData, ISerializedDebugDisplaySettings // TypeDefIndex: 9364
	{
		// Fields
		private DebugWireframeMode m_WireframeMode; // 0x10
		private bool m_Overdraw; // 0x14
		private DebugOverdrawMode m_OverdrawMode; // 0x18
		[CompilerGenerated]
		private int _maxOverdrawCount_k__BackingField; // 0x1C
		[CompilerGenerated]
		private DebugFullScreenMode _fullScreenDebugMode_k__BackingField; // 0x20
		[CompilerGenerated]
		private bool _batchingTypeViewEnabled_k__BackingField; // 0x24
		[CompilerGenerated]
		private int _stpDebugViewIndex_k__BackingField; // 0x28
		[CompilerGenerated]
		private int _fullScreenDebugModeOutputSizeScreenPercent_k__BackingField; // 0x2C
		[CompilerGenerated]
		private DebugSceneOverrideMode _sceneOverrideMode_k__BackingField; // 0x30
		[CompilerGenerated]
		private DebugMipInfoMode _mipInfoMode_k__BackingField; // 0x34
		[CompilerGenerated]
		private bool _mipDebugStatusShowCode_k__BackingField; // 0x38
		[CompilerGenerated]
		private DebugMipMapStatusMode _mipDebugStatusMode_k__BackingField; // 0x3C
		[CompilerGenerated]
		private float _mipDebugOpacity_k__BackingField; // 0x40
		[CompilerGenerated]
		private float _mipDebugRecentUpdateCooldown_k__BackingField; // 0x44
		[CompilerGenerated]
		private int _mipDebugMaterialTextureSlot_k__BackingField; // 0x48
		[CompilerGenerated]
		private bool _showInfoForAllSlots_k__BackingField; // 0x4C
		[CompilerGenerated]
		private DebugMipMapModeTerrainTexture _mipDebugTerrainTexture_k__BackingField; // 0x50
		[CompilerGenerated]
		private DebugPostProcessingMode _postProcessingDebugMode_k__BackingField; // 0x54
		[CompilerGenerated]
		private bool _enableMsaa_k__BackingField; // 0x58
		[CompilerGenerated]
		private bool _enableHDR_k__BackingField; // 0x59
		[CompilerGenerated]
		private TaaDebugMode _taaDebugMode_k__BackingField; // 0x5C
		[CompilerGenerated]
		private DebugValidationMode _validationMode_k__BackingField; // 0x60
		[CompilerGenerated]
		private PixelValidationChannels _validationChannels_k__BackingField; // 0x64
		[CompilerGenerated]
		private float _validationRangeMin_k__BackingField; // 0x68
		[CompilerGenerated]
		private float _validationRangeMax_k__BackingField; // 0x6C
	
		// Properties
		public DebugWireframeMode wireframeMode { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x0000000181F570C0-0x0000000181F57120
		[Obsolete("overdraw has been deprecated. Use overdrawMode instead. #from(2022.2) #breakingFrom(2023.1)", true)]
		public bool overdraw { get; set; } // 0x0000000181102980-0x0000000181102990 0x0000000181F57060-0x0000000181F570C0
		public DebugOverdrawMode overdrawMode { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000181F57010-0x0000000181F57060
		public int maxOverdrawCount { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
		public DebugFullScreenMode fullScreenDebugMode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public bool batchingTypeViewEnabled { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018153BC50-0x000000018153BC60 0x0000000181706050-0x0000000181706060
		internal int stpDebugViewIndex { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
		public int fullScreenDebugModeOutputSizeScreenPercent { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001803FE010-0x00000001803FE020
		internal DebugSceneOverrideMode sceneOverrideMode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		public DebugMipInfoMode mipInfoMode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780
		public bool mipDebugStatusShowCode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180476380-0x0000000180476390 0x00000001804763A0-0x00000001804763B0
		public DebugMipMapStatusMode mipDebugStatusMode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x00000001805D5550-0x00000001805D5560
		public float mipDebugOpacity { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181D8CC60-0x0000000181D8CC70 0x0000000181F56C00-0x0000000181F56C10
		public float mipDebugRecentUpdateCooldown { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180349420-0x0000000180349430 0x0000000180349430-0x0000000180349440
		public int mipDebugMaterialTextureSlot { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D1C0-0x000000018033D1D0 0x000000018033E7A0-0x000000018033E7B0
		public bool showInfoForAllSlots { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803B6550-0x00000001803B6560 0x0000000181DB90D0-0x0000000181DB90E0
		internal bool canAggregateData { get; } // 0x0000000181F56FF0-0x0000000181F57010 
		public DebugMipMapModeTerrainTexture mipDebugTerrainTexture { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D660-0x000000018033D670 0x000000018033EC40-0x000000018033EC50
		public DebugPostProcessingMode postProcessingDebugMode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180CC1EB0-0x0000000180CC1EC0 0x0000000181ADB600-0x0000000181ADB610
		public bool enableMsaa { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181424750-0x0000000181424760 0x0000000181424790-0x00000001814247A0
		public bool enableHDR { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E7880-0x00000001802E7890 0x0000000181727420-0x0000000181727430
		public TaaDebugMode taaDebugMode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D270-0x000000018033D280 0x000000018033E880-0x000000018033E890
		internal bool blockReflectionProbeAtlasOverlay { get; } // 0x0000000181F56E50-0x0000000181F56F40 
		internal bool blockSTPOverlay { get; } // 0x0000000181F56F40-0x0000000181F56FF0 
		public DebugValidationMode validationMode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018150C180-0x000000018150C190 0x000000018041DC00-0x000000018041DC10
		public PixelValidationChannels validationChannels { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F2020-0x00000001802F2030 0x000000018033EA40-0x000000018033EA50
		public float validationRangeMin { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C245B0-0x0000000180C245C0 0x0000000180C24770-0x0000000180C24780
		public float validationRangeMax { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C24480-0x0000000180C24490 0x0000000180C245C0-0x0000000180C245D0
		public bool AreAnySettingsActive { get; } // 0x0000000181F56DD0-0x0000000181F56E10 
		public bool IsPostProcessingAllowed { get; } // 0x0000000181F56E30-0x0000000181F56E50 
		public bool IsLightingActive { get; } // 0x0000000181F56E10-0x0000000181F56E30 
	
		// Nested types
		public enum TaaDebugMode // TypeDefIndex: 9365
		{
			None = 0,
			ShowRawFrame = 1,
			ShowRawFrameNoJitter = 2,
			ShowClampedHistory = 3
		}
	
		private static class Strings // TypeDefIndex: 9366
		{
			// Fields
			public const string RangeValidationSettingsContainerName = "Pixel Range Settings"; // Metadata: 0x0069E9F3
			public static readonly DebugUI.Widget.NameAndTooltip MapOverlays; // 0x00
			public static readonly DebugUI.Widget.NameAndTooltip ReflectionProbeAtlasDebugWarning; // 0x10
			public static readonly DebugUI.Widget.NameAndTooltip StpDebugWarning; // 0x20
			public static readonly DebugUI.Widget.NameAndTooltip StpDebugViews; // 0x30
			public static readonly DebugUI.Widget.NameAndTooltip MapSize; // 0x40
			public static readonly DebugUI.Widget.NameAndTooltip AdditionalWireframeModes; // 0x50
			public static readonly DebugUI.Widget.NameAndTooltip WireframeNotSupportedWarning; // 0x60
			public static readonly DebugUI.Widget.NameAndTooltip OverdrawMode; // 0x70
			public static readonly DebugUI.Widget.NameAndTooltip BatchingType; // 0x80
			public static readonly DebugUI.Widget.NameAndTooltip MaxOverdrawCount; // 0x90
			public static readonly DebugUI.Widget.NameAndTooltip MipMapDisableMipCaching; // 0xA0
			public static readonly DebugUI.Widget.NameAndTooltip MipMapDebugView; // 0xB0
			public static readonly DebugUI.Widget.NameAndTooltip MipMapDebugOpacity; // 0xC0
			public static readonly DebugUI.Widget.NameAndTooltip MipMapMaterialTextureSlot; // 0xD0
			public static readonly DebugUI.Widget.NameAndTooltip MipMapTerrainTexture; // 0xE0
			public static readonly DebugUI.Widget.NameAndTooltip MipMapDisplayStatusCodes; // 0xF0
			public static readonly DebugUI.Widget.NameAndTooltip MipMapActivityTimespan; // 0x100
			public static readonly DebugUI.Widget.NameAndTooltip MipMapCombinePerMaterial; // 0x110
			public static readonly DebugUI.Widget.NameAndTooltip PostProcessing; // 0x120
			public static readonly DebugUI.Widget.NameAndTooltip MSAA; // 0x130
			public static readonly DebugUI.Widget.NameAndTooltip HDR; // 0x140
			public static readonly DebugUI.Widget.NameAndTooltip TaaDebugMode; // 0x150
			public static readonly DebugUI.Widget.NameAndTooltip PixelValidationMode; // 0x160
			public static readonly DebugUI.Widget.NameAndTooltip Channels; // 0x170
			public static readonly DebugUI.Widget.NameAndTooltip ValueRangeMin; // 0x180
			public static readonly DebugUI.Widget.NameAndTooltip ValueRangeMax; // 0x190
	
			// Constructors
			static Strings(); // 0x0000000181F5F4E0-0x0000000181F60130
		}
	
		internal static class WidgetFactory // TypeDefIndex: 9367
		{
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 9368
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Func<int> __9__2_4; // 0x08
				public static Func<int> __9__2_5; // 0x10
				public static Func<bool> __9__6_2; // 0x18
				public static Func<int> __9__7_3; // 0x20
				public static Func<int> __9__7_4; // 0x28
				public static Func<bool> __9__8_0; // 0x30
				public static Action<bool> __9__8_1; // 0x38
				public static Func<float> __9__10_4; // 0x40
				public static Func<float> __9__10_5; // 0x48
				public static Func<bool> __9__10_10; // 0x50
				public static Func<float> __9__12_3; // 0x58
				public static Func<float> __9__12_4; // 0x60
	
				// Constructors
				static __c(); // 0x0000000181F623D0-0x0000000181F62440
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreateMapOverlaySize_b__2_4(); // 0x00000001802E7860-0x00000001802E7870
				internal int _CreateMapOverlaySize_b__2_5(); // 0x0000000180A326B0-0x0000000180A326C0
				internal bool _CreateBatchingTypeViewEnabled_b__6_2(); // 0x00000001802E7990-0x00000001802E79A0
				internal int _CreateMaxOverdrawCount_b__7_3(); // 0x0000000180472790-0x00000001804727A0
				internal int _CreateMaxOverdrawCount_b__7_4(); // 0x0000000181F60AD0-0x0000000181F60AE0
				internal bool _CreateMipMapDebugWidget_b__8_0(); // 0x0000000181F60AF0-0x0000000181F60B30
				internal void _CreateMipMapDebugWidget_b__8_1(bool value); // 0x0000000181F60B30-0x0000000181F60B80
				internal float _CreateMipMapDebugSettings_b__10_4(); // 0x00000001807185C0-0x00000001807185D0
				internal float _CreateMipMapDebugSettings_b__10_5(); // 0x0000000181E471E0-0x0000000181E471F0
				internal bool _CreateMipMapDebugSettings_b__10_10(); // 0x00000001802E7840-0x00000001802E7850
				internal float _CreateMipMapDebugCooldownSlider_b__12_3(); // 0x00000001807185C0-0x00000001807185D0
				internal float _CreateMipMapDebugCooldownSlider_b__12_4(); // 0x0000000181F60AE0-0x0000000181F60AF0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass0_0 // TypeDefIndex: 9369
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass0_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreateMapOverlays_b__0(); // 0x0000000180F1C220-0x0000000180F1C240
				internal void _CreateMapOverlays_b__1(int value); // 0x0000000181F4A4B0-0x0000000181F4A4D0
				internal int _CreateMapOverlays_b__2(); // 0x0000000180F1C220-0x0000000180F1C240
				internal void _CreateMapOverlays_b__3(int value); // 0x0000000181F4A4B0-0x0000000181F4A4D0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass10_0 // TypeDefIndex: 9370
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass10_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _CreateMipMapDebugSettings_b__0(); // 0x0000000181F616F0-0x0000000181F61710
				internal float _CreateMipMapDebugSettings_b__2(); // 0x0000000181F61760-0x0000000181F61780
				internal void _CreateMipMapDebugSettings_b__3(float value); // 0x0000000181F61780-0x0000000181F617A0
				internal bool _CreateMipMapDebugSettings_b__1(); // 0x0000000181F61730-0x0000000181F61760
				internal bool _CreateMipMapDebugSettings_b__6(); // 0x0000000181F617A0-0x0000000181F617D0
				internal bool _CreateMipMapDebugSettings_b__7(); // 0x0000000181F617D0-0x0000000181F617F0
				internal void _CreateMipMapDebugSettings_b__8(bool value); // 0x0000000181F617F0-0x0000000181F61820
				internal bool _CreateMipMapDebugSettings_b__9(); // 0x0000000181F61820-0x0000000181F61850
				internal int _CreateMipMapDebugSettings_b__11(); // 0x00000001818FFCC0-0x00000001818FFCE0
				internal void _CreateMipMapDebugSettings_b__12(int value); // 0x0000000181F61710-0x0000000181F61730
				internal int _CreateMipMapDebugSettings_b__13(); // 0x00000001818FFCC0-0x00000001818FFCE0
				internal void _CreateMipMapDebugSettings_b__14(int value); // 0x0000000181F61710-0x0000000181F61730
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass11_0 // TypeDefIndex: 9371
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass11_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreateMipMapDebugSlotSelector_b__0(); // 0x0000000181F61880-0x0000000181F618A0
				internal void _CreateMipMapDebugSlotSelector_b__1(int value); // 0x0000000181F618A0-0x0000000181F618C0
				internal int _CreateMipMapDebugSlotSelector_b__2(); // 0x0000000181F61880-0x0000000181F618A0
				internal void _CreateMipMapDebugSlotSelector_b__3(int value); // 0x0000000181F618A0-0x0000000181F618C0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass12_0 // TypeDefIndex: 9372
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass12_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _CreateMipMapDebugCooldownSlider_b__0(); // 0x0000000181F61900-0x0000000181F61920
				internal float _CreateMipMapDebugCooldownSlider_b__1(); // 0x0000000181F61920-0x0000000181F61940
				internal void _CreateMipMapDebugCooldownSlider_b__2(float value); // 0x0000000181F61940-0x0000000181F61960
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass13_0 // TypeDefIndex: 9373
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass13_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _CreateMipMapShowStatusCodeToggle_b__0(); // 0x0000000181F61960-0x0000000181F61980
				internal bool _CreateMipMapShowStatusCodeToggle_b__1(); // 0x0000000181F61980-0x0000000181F619A0
				internal void _CreateMipMapShowStatusCodeToggle_b__2(bool value); // 0x0000000181F619A0-0x0000000181F619C0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass14_0 // TypeDefIndex: 9374
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass14_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreatePostProcessing_b__0(); // 0x0000000181F619C0-0x0000000181F619E0
				internal void _CreatePostProcessing_b__1(int value); // 0x0000000181F619E0-0x0000000181F61A00
				internal int _CreatePostProcessing_b__2(); // 0x0000000181F619C0-0x0000000181F619E0
				internal void _CreatePostProcessing_b__3(int value); // 0x0000000181F619E0-0x0000000181F61A00
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass15_0 // TypeDefIndex: 9375
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass15_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _CreateMSAA_b__0(); // 0x0000000181F61A00-0x0000000181F61A20
				internal void _CreateMSAA_b__1(bool value); // 0x0000000181F61A20-0x0000000181F61A40
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass16_0 // TypeDefIndex: 9376
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass16_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _CreateHDR_b__0(); // 0x0000000181F61A40-0x0000000181F61A60
				internal void _CreateHDR_b__1(bool value); // 0x0000000181F61A60-0x0000000181F61A80
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass17_0 // TypeDefIndex: 9377
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass17_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreateTaaDebugMode_b__0(); // 0x0000000181F615E0-0x0000000181F61600
				internal void _CreateTaaDebugMode_b__1(int value); // 0x0000000181F61600-0x0000000181F61620
				internal int _CreateTaaDebugMode_b__2(); // 0x0000000181F615E0-0x0000000181F61600
				internal void _CreateTaaDebugMode_b__3(int value); // 0x0000000181F61600-0x0000000181F61620
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass18_0 // TypeDefIndex: 9378
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass18_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreatePixelValidationMode_b__0(); // 0x0000000181F61A80-0x0000000181F61AA0
				internal void _CreatePixelValidationMode_b__1(int value); // 0x0000000181F61AA0-0x0000000181F61AC0
				internal int _CreatePixelValidationMode_b__2(); // 0x0000000181F61A80-0x0000000181F61AA0
				internal void _CreatePixelValidationMode_b__3(int value); // 0x0000000181F61AA0-0x0000000181F61AC0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass19_0 // TypeDefIndex: 9379
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass19_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreatePixelValidationChannels_b__0(); // 0x0000000181F61AC0-0x0000000181F61AE0
				internal void _CreatePixelValidationChannels_b__1(int value); // 0x0000000181F61AE0-0x0000000181F61B00
				internal int _CreatePixelValidationChannels_b__2(); // 0x0000000181F61AC0-0x0000000181F61AE0
				internal void _CreatePixelValidationChannels_b__3(int value); // 0x0000000181F61AE0-0x0000000181F61B00
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass1_0 // TypeDefIndex: 9380
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass1_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _CreateStpDebugViews_b__0(); // 0x0000000181F61BE0-0x0000000181F61CA0
				internal bool _CreateStpDebugViews_b__1(); // 0x0000000181F61CA0-0x0000000181F61CC0
				internal int _CreateStpDebugViews_b__2(); // 0x0000000181F61CC0-0x0000000181F61CE0
				internal void _CreateStpDebugViews_b__3(int value); // 0x0000000181F61CE0-0x0000000181F61D00
				internal int _CreateStpDebugViews_b__4(); // 0x0000000181F61CC0-0x0000000181F61CE0
				internal void _CreateStpDebugViews_b__5(int value); // 0x0000000181F61CE0-0x0000000181F61D00
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass20_0 // TypeDefIndex: 9381
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass20_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal float _CreatePixelValueRangeMin_b__0(); // 0x0000000181F61D00-0x0000000181F61D20
				internal void _CreatePixelValueRangeMin_b__1(float value); // 0x0000000181F61D20-0x0000000181F61D40
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass21_0 // TypeDefIndex: 9382
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass21_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal float _CreatePixelValueRangeMax_b__0(); // 0x0000000181F61D40-0x0000000181F61D60
				internal void _CreatePixelValueRangeMax_b__1(float value); // 0x0000000181F61D60-0x0000000181F61D80
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass2_0 // TypeDefIndex: 9383
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass2_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _CreateMapOverlaySize_b__0(); // 0x0000000181F61DA0-0x0000000181F61DD0
				internal bool _CreateMapOverlaySize_b__1(); // 0x0000000181F61DD0-0x0000000181F61DF0
				internal int _CreateMapOverlaySize_b__2(); // 0x0000000181F61DF0-0x0000000181F61E10
				internal void _CreateMapOverlaySize_b__3(int value); // 0x0000000181F61E10-0x0000000181F61E30
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass3_0 // TypeDefIndex: 9384
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass3_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreateAdditionalWireframeShaderViews_b__0(); // 0x0000000181463040-0x0000000181463060
				internal void _CreateAdditionalWireframeShaderViews_b__1(int value); // 0x0000000181F61E70-0x0000000181F61EE0
				internal int _CreateAdditionalWireframeShaderViews_b__2(); // 0x0000000181463040-0x0000000181463060
				internal void _CreateAdditionalWireframeShaderViews_b__3(int value); // 0x0000000181F61E70-0x0000000181F61EE0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass4_0 // TypeDefIndex: 9385
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass4_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _CreateWireframeNotSupportedWarning_b__0(); // 0x0000000181F61F80-0x0000000181F61FC0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass5_0 // TypeDefIndex: 9386
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass5_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreateOverdrawMode_b__0(); // 0x0000000180B5F570-0x0000000180B5F590
				internal void _CreateOverdrawMode_b__1(int value); // 0x0000000181F62110-0x0000000181F62180
				internal int _CreateOverdrawMode_b__2(); // 0x0000000180B5F570-0x0000000180B5F590
				internal void _CreateOverdrawMode_b__3(int value); // 0x0000000181F62110-0x0000000181F62180
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass6_0 // TypeDefIndex: 9387
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass6_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _CreateBatchingTypeViewEnabled_b__0(); // 0x0000000181F621F0-0x0000000181F62210
				internal void _CreateBatchingTypeViewEnabled_b__1(bool value); // 0x0000000181F62210-0x0000000181F62230
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass7_0 // TypeDefIndex: 9388
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass7_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _CreateMaxOverdrawCount_b__0(); // 0x0000000181F616D0-0x0000000181F616F0
				internal int _CreateMaxOverdrawCount_b__1(); // 0x0000000181F622A0-0x0000000181F622C0
				internal void _CreateMaxOverdrawCount_b__2(int value); // 0x0000000181F622C0-0x0000000181F622E0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass9_0 // TypeDefIndex: 9389
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass9_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreateMipMapMode_b__0(); // 0x0000000181F62320-0x0000000181F62340
				internal void _CreateMipMapMode_b__1(int value); // 0x0000000181F62340-0x0000000181F62360
				internal int _CreateMipMapMode_b__2(); // 0x0000000181F62320-0x0000000181F62340
				internal void _CreateMipMapMode_b__3(int value); // 0x0000000181F62340-0x0000000181F62360
			}
	
			// Methods
			internal static DebugUI.Widget CreateMapOverlays(DebugDisplaySettingsRendering data); // 0x0000000181F67080-0x0000000181F672D0
			internal static DebugUI.Widget CreateStpDebugViews(DebugDisplaySettingsRendering data); // 0x0000000181F6A620-0x0000000181F6AA80
			internal static DebugUI.Widget CreateMapOverlaySize(DebugDisplaySettingsRendering data); // 0x0000000181F66C40-0x0000000181F67080
			internal static DebugUI.Widget CreateAdditionalWireframeShaderViews(DebugDisplaySettingsRendering data); // 0x0000000181F65080-0x0000000181F652D0
			internal static DebugUI.Widget CreateWireframeNotSupportedWarning(DebugDisplaySettingsRendering data); // 0x0000000181F6AF20-0x0000000181F6B0E0
			internal static DebugUI.Widget CreateOverdrawMode(DebugDisplaySettingsRendering data); // 0x0000000181F69640-0x0000000181F69890
			internal static DebugUI.Widget CreateBatchingTypeViewEnabled(DebugDisplaySettingsRendering data); // 0x0000000181F65E00-0x0000000181F66040
			internal static DebugUI.Widget CreateMaxOverdrawCount(DebugDisplaySettingsRendering data); // 0x0000000181F67770-0x0000000181F67AF0
			internal static DebugUI.Widget CreateMipMapDebugWidget(DebugDisplaySettingsRendering data); // 0x0000000181F68F40-0x0000000181F69220
			internal static DebugUI.Widget CreateMipMapMode(DebugDisplaySettingsRendering data); // 0x0000000181F69220-0x0000000181F69470
			internal static DebugUI.Widget CreateMipMapDebugSettings(DebugDisplaySettingsRendering data); // 0x0000000181F68140-0x0000000181F68CD0
			internal static DebugUI.Widget CreateMipMapDebugSlotSelector(DebugDisplaySettingsRendering data, Func<bool> hiddenCB, GUIContent[] texSlotStrings, int[] texSlotValues); // 0x0000000181F68CD0-0x0000000181F68F40
			internal static DebugUI.Widget CreateMipMapDebugCooldownSlider(DebugDisplaySettingsRendering data); // 0x0000000181F67E30-0x0000000181F68140
			internal static DebugUI.Widget CreateMipMapShowStatusCodeToggle(DebugDisplaySettingsRendering data); // 0x0000000181F69470-0x0000000181F69640
			internal static DebugUI.Widget CreatePostProcessing(DebugDisplaySettingsRendering data); // 0x0000000181F6A070-0x0000000181F6A2C0
			internal static DebugUI.Widget CreateMSAA(DebugDisplaySettingsRendering data); // 0x0000000181F66AB0-0x0000000181F66C40
			internal static DebugUI.Widget CreateHDR(DebugDisplaySettingsRendering data); // 0x0000000181F66510-0x0000000181F666A0
			internal static DebugUI.Widget CreateTaaDebugMode(DebugDisplaySettingsRendering data); // 0x0000000181F6AA80-0x0000000181F6ACD0
			internal static DebugUI.Widget CreatePixelValidationMode(DebugDisplaySettingsRendering data); // 0x0000000181F69AE0-0x0000000181F69D30
			internal static DebugUI.Widget CreatePixelValidationChannels(DebugDisplaySettingsRendering data); // 0x0000000181F69890-0x0000000181F69AE0
			internal static DebugUI.Widget CreatePixelValueRangeMin(DebugDisplaySettingsRendering data); // 0x0000000181F69ED0-0x0000000181F6A070
			internal static DebugUI.Widget CreatePixelValueRangeMax(DebugDisplaySettingsRendering data); // 0x0000000181F69D30-0x0000000181F69ED0
		}
	
		[DisplayInfo(name = "Rendering", order = 1)]
		internal class SettingsPanel : DebugDisplaySettingsPanel<DebugDisplaySettingsRendering> // TypeDefIndex: 9390
		{
			// Nested types
			[CompilerGenerated]
			private sealed class __c__DisplayClass0_0 // TypeDefIndex: 9391
			{
				// Fields
				public DebugDisplaySettingsRendering data; // 0x10
	
				// Constructors
				public __c__DisplayClass0_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _.ctor_b__0(); // 0x0000000181F85A70-0x0000000181F85A90
			}
	
			// Constructors
			public SettingsPanel(DebugDisplaySettingsRendering data); // 0x0000000181F5EA60-0x0000000181F5F360
		}
	
		// Constructors
		public DebugDisplaySettingsRendering(); // 0x0000000181F56D90-0x0000000181F56DD0
	
		// Methods
		private void UpdateDebugSceneOverrideMode(); // 0x0000000181F56D30-0x0000000181F56D90
		internal void SetBatchingTypeDebugEnabled(bool enabled); // 0x00000001802E76C0-0x00000001802E76D0
		public bool TryGetScreenClearColor(ref Color color); // 0x0000000181F56C20-0x0000000181F56CD0
		IDebugDisplaySettingsPanelDisposable IDebugDisplaySettingsData.CreatePanel(); // 0x0000000181F56CD0-0x0000000181F56D30
	}
}
