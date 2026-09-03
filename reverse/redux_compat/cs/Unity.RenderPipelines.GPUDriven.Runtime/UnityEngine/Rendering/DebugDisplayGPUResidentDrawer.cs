/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[Serializable]
	public class DebugDisplayGPUResidentDrawer : IDebugDisplaySettingsData, ISerializedDebugDisplaySettings // TypeDefIndex: 12905
	{
		// Fields
		private const string k_FormatString = "{0}"; // Metadata: 0x006A7611
		private const float k_RefreshRate = 0.2f; // Metadata: 0x006A7615
		private const int k_MaxViewCount = 32; // Metadata: 0x006A7619
		private const int k_MaxOcclusionPassCount = 32; // Metadata: 0x006A761A
		private const int k_MaxContextCount = 16; // Metadata: 0x006A761B
		[CompilerGenerated]
		private bool _displayBatcherStats_k__BackingField; // 0x10
		[CompilerGenerated]
		private bool _occlusionTestOverlayEnabled_k__BackingField; // 0x11
		[CompilerGenerated]
		private bool _occlusionTestOverlayCountVisible_k__BackingField; // 0x12
		[CompilerGenerated]
		private bool _overrideOcclusionTestToAlwaysPass_k__BackingField; // 0x13
		public bool occluderDebugViewEnable; // 0x14
		internal bool occluderContextStats; // 0x15
		internal Vector2 occluderDebugViewRange; // 0x18
		internal int occluderDebugViewIndex; // 0x20
	
		// Properties
		internal bool displayBatcherStats { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
		internal bool occlusionTestOverlayEnabled { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180E38E10-0x0000000180E38E20 0x00000001815C0340-0x00000001815C0350
		internal bool occlusionTestOverlayCountVisible { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180E38E20-0x0000000180E38E30 0x0000000181734F30-0x0000000181734F40
		internal bool overrideOcclusionTestToAlwaysPass { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180E38E40-0x0000000180E38E50 0x0000000181F33560-0x0000000181F33570
		public bool AreAnySettingsActive { get; } // 0x00000001805625D0-0x00000001805625E0 
		public bool IsPostProcessingAllowed { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public bool IsLightingActive { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Nested types
		private static class Strings // TypeDefIndex: 12906
		{
			// Fields
			public const string drawerSettingsContainerName = "GPU Resident Drawer Settings"; // Metadata: 0x006A761C
			public static readonly DebugUI.Widget.NameAndTooltip displayBatcherStats; // 0x00
			public const string occlusionCullingTitle = "Occlusion Culling"; // Metadata: 0x006A7639
			public static readonly DebugUI.Widget.NameAndTooltip occlusionTestOverlayEnable; // 0x10
			public static readonly DebugUI.Widget.NameAndTooltip occlusionTestOverlayCountVisible; // 0x20
			public static readonly DebugUI.Widget.NameAndTooltip overrideOcclusionTestToAlwaysPass; // 0x30
			public static readonly DebugUI.Widget.NameAndTooltip occluderContextStats; // 0x40
			public static readonly DebugUI.Widget.NameAndTooltip occluderDebugViewEnable; // 0x50
			public static readonly DebugUI.Widget.NameAndTooltip occluderDebugViewIndex; // 0x60
			public static readonly DebugUI.Widget.NameAndTooltip occluderDebugViewRangeMin; // 0x70
			public static readonly DebugUI.Widget.NameAndTooltip occluderDebugViewRangeMax; // 0x80
	
			// Constructors
			static Strings(); // 0x0000000181F48FD0-0x0000000181F49410
		}
	
		[DisplayInfo(name = "Rendering", order = 5)]
		private class SettingsPanel : DebugDisplaySettingsPanel // TypeDefIndex: 12907
		{
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 12908
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Func<string> __9__0_0; // 0x08
				public static Func<bool> __9__0_1; // 0x10
				public static Func<bool> __9__0_2; // 0x18
				public static Func<int> __9__0_16; // 0x20
				public static Func<int> __9__0_17; // 0x28
				public static Func<bool> __9__0_26; // 0x30
				public static Func<object> __9__3_1; // 0x38
				public static Func<object> __9__3_2; // 0x40
				public static Func<object> __9__3_3; // 0x48
				public static Func<object> __9__3_4; // 0x50
				public static Func<object> __9__3_5; // 0x58
				public static Func<object> __9__3_6; // 0x60
				public static Func<object> __9__3_7; // 0x68
				public static Func<object> __9__4_1; // 0x70
	
				// Constructors
				static __c(); // 0x0000000181F4B270-0x0000000181F4BBD0
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal string _.ctor_b__0_0(); // 0x0000000181F4A140-0x0000000181F4A200
				internal bool _.ctor_b__0_1(); // 0x0000000181F4A2A0-0x0000000181F4A330
				internal bool _.ctor_b__0_2(); // 0x0000000181F4A3C0-0x0000000181F4A450
				internal int _.ctor_b__0_16(); // 0x00000001802E7860-0x00000001802E7870
				internal int _.ctor_b__0_17(); // 0x0000000181F4A200-0x0000000181F4A2A0
				internal bool _.ctor_b__0_26(); // 0x0000000181F4A330-0x0000000181F4A3C0
				internal object _AddInstanceCullingStatsWidget_b__3_1(); // 0x0000000181F49410-0x0000000181F49480
				internal object _AddInstanceCullingStatsWidget_b__3_2(); // 0x0000000181F49480-0x0000000181F495A0
				internal object _AddInstanceCullingStatsWidget_b__3_3(); // 0x0000000181F495A0-0x0000000181F496C0
				internal object _AddInstanceCullingStatsWidget_b__3_4(); // 0x0000000181F496C0-0x0000000181F497F0
				internal object _AddInstanceCullingStatsWidget_b__3_5(); // 0x0000000181F497F0-0x0000000181F49910
				internal object _AddInstanceCullingStatsWidget_b__3_6(); // 0x0000000181F49910-0x0000000181F49A30
				internal object _AddInstanceCullingStatsWidget_b__3_7(); // 0x0000000181F49A30-0x0000000181F49B60
				internal object _AddOcclusionContextStatsWidget_b__4_1(); // 0x0000000181F49B60-0x0000000181F49BD0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass0_0 // TypeDefIndex: 12909
			{
				// Fields
				public DebugDisplayGPUResidentDrawer data; // 0x10
	
				// Constructors
				public __c__DisplayClass0_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _.ctor_b__3(); // 0x0000000181F4A590-0x0000000181F4A5B0
				internal void _.ctor_b__4(bool value); // 0x0000000181F4A5B0-0x0000000181F4A5D0
				internal bool _.ctor_b__5(); // 0x0000000181F4A5D0-0x0000000181F4A5F0
				internal void _.ctor_b__6(bool value); // 0x0000000181F4A5F0-0x0000000181F4A610
				internal bool _.ctor_b__7(); // 0x0000000181F4A610-0x0000000181F4A630
				internal void _.ctor_b__8(bool value); // 0x0000000181F4A630-0x0000000181F4A650
				internal bool _.ctor_b__9(); // 0x0000000181F4A650-0x0000000181F4A670
				internal void _.ctor_b__10(bool value); // 0x0000000181F4A450-0x0000000181F4A470
				internal bool _.ctor_b__11(); // 0x0000000181F4A470-0x0000000181F4A490
				internal void _.ctor_b__12(bool value); // 0x0000000181F4A490-0x0000000181F4A4B0
				internal int _.ctor_b__13(); // 0x0000000180F1C220-0x0000000180F1C240
				internal void _.ctor_b__14(int value); // 0x0000000181F4A4B0-0x0000000181F4A4D0
				internal bool _.ctor_b__15(); // 0x0000000181F4A4D0-0x0000000181F4A4F0
				internal float _.ctor_b__18(); // 0x0000000181F4A4F0-0x0000000181F4A510
				internal void _.ctor_b__19(float value); // 0x0000000181F4A510-0x0000000181F4A530
				internal bool _.ctor_b__20(); // 0x0000000181F4A4D0-0x0000000181F4A4F0
				internal float _.ctor_b__21(); // 0x0000000181F4A530-0x0000000181F4A550
				internal void _.ctor_b__22(float value); // 0x0000000181F4A550-0x0000000181F4A570
				internal bool _.ctor_b__23(); // 0x0000000181F4A4D0-0x0000000181F4A4F0
				internal bool _.ctor_b__24(); // 0x0000000181AD4E30-0x0000000181AD4E50
				internal void _.ctor_b__25(bool value); // 0x0000000181F4A570-0x0000000181F4A590
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass3_0 // TypeDefIndex: 12910
			{
				// Fields
				public DebugDisplayGPUResidentDrawer data; // 0x10
	
				// Constructors
				public __c__DisplayClass3_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _AddInstanceCullingStatsWidget_b__0(); // 0x0000000181F4A9A0-0x0000000181F4A9C0
				internal bool _AddInstanceCullingStatsWidget_b__8(); // 0x0000000181F4A9A0-0x0000000181F4A9C0
				internal bool _AddInstanceCullingStatsWidget_b__9(); // 0x0000000181F4A9A0-0x0000000181F4A9C0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass4_0 // TypeDefIndex: 12911
			{
				// Fields
				public DebugDisplayGPUResidentDrawer data; // 0x10
	
				// Constructors
				public __c__DisplayClass4_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _AddOcclusionContextStatsWidget_b__0(); // 0x0000000181F4B1E0-0x0000000181F4B200
			}
	
			// Constructors
			public SettingsPanel(DebugDisplayGPUResidentDrawer data); // 0x0000000181F47650-0x0000000181F486F0
	
			// Methods
			private void OnGPUResidentDrawerInitializedChanged(bool previousValue, bool currentValue); // 0x0000000181F475F0-0x0000000181F47650
			public override void Dispose(); // 0x0000000181F474A0-0x0000000181F475F0
			private void AddInstanceCullingStatsWidget(DebugDisplayGPUResidentDrawer data); // 0x0000000181F46340-0x0000000181F470A0
			private void AddOcclusionContextStatsWidget(DebugDisplayGPUResidentDrawer data); // 0x0000000181F470A0-0x0000000181F474A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass33_0 // TypeDefIndex: 12912
		{
			// Fields
			public int viewIndex; // 0x10
	
			// Constructors
			public __c__DisplayClass33_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _AddInstanceCullerViewDataRow_b__0(); // 0x0000000181F4A670-0x0000000181F4A6E0
			internal object _AddInstanceCullerViewDataRow_b__1(); // 0x0000000181F4A6E0-0x0000000181F4A740
			internal object _AddInstanceCullerViewDataRow_b__2(); // 0x0000000181F4A740-0x0000000181F4A7B0
			internal object _AddInstanceCullerViewDataRow_b__3(); // 0x0000000181F4A7B0-0x0000000181F4A7F0
			internal object _AddInstanceCullerViewDataRow_b__4(); // 0x0000000181F4A7F0-0x0000000181F4A8A0
			internal object _AddInstanceCullerViewDataRow_b__5(); // 0x0000000181F4A8A0-0x0000000181F4A950
			internal object _AddInstanceCullerViewDataRow_b__6(); // 0x0000000181F4A950-0x0000000181F4A9A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass40_0 // TypeDefIndex: 12913
		{
			// Fields
			public int eventIndex; // 0x10
	
			// Constructors
			public __c__DisplayClass40_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _AddInstanceOcclusionPassDataRow_b__0(); // 0x0000000181F4A9C0-0x0000000181F4AA30
			internal object _AddInstanceOcclusionPassDataRow_b__1(); // 0x0000000181F4AA30-0x0000000181F4AAA0
			internal object _AddInstanceOcclusionPassDataRow_b__2(); // 0x0000000181F4AAA0-0x0000000181F4AB20
			internal object _AddInstanceOcclusionPassDataRow_b__3(); // 0x0000000181F4AB20-0x0000000181F4ABC0
			internal object _AddInstanceOcclusionPassDataRow_b__4(); // 0x0000000181F4ABC0-0x0000000181F4AC30
			internal object _AddInstanceOcclusionPassDataRow_b__5(); // 0x0000000181F4AC30-0x0000000181F4AD00
			internal object _AddInstanceOcclusionPassDataRow_b__6(); // 0x0000000181F4AD00-0x0000000181F4AD90
			internal object _AddInstanceOcclusionPassDataRow_b__7(); // 0x0000000181F4AD90-0x0000000181F4AE20
			internal object _AddInstanceOcclusionPassDataRow_b__8(); // 0x0000000181F4AE20-0x0000000181F4AEB0
			internal object _AddInstanceOcclusionPassDataRow_b__9(); // 0x0000000181F4AEB0-0x0000000181F4AF40
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass41_0 // TypeDefIndex: 12914
		{
			// Fields
			public int index; // 0x10
	
			// Constructors
			public __c__DisplayClass41_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _AddOcclusionContextDataRow_b__0(); // 0x0000000181F4AF40-0x0000000181F4AFB0
			internal object _AddOcclusionContextDataRow_b__1(); // 0x0000000181F4AFB0-0x0000000181F4B060
			internal object _AddOcclusionContextDataRow_b__2(); // 0x0000000181F4B060-0x0000000181F4B0F0
			internal object _AddOcclusionContextDataRow_b__3(); // 0x0000000181F4B0F0-0x0000000181F4B1E0
		}
	
		// Constructors
		public DebugDisplayGPUResidentDrawer(); // 0x0000000181F33540-0x0000000181F33560
	
		// Methods
		internal bool GetOccluderViewID(out EntityId viewID); // 0x0000000181F33240-0x0000000181F332F0
		private static InstanceCullerViewStats GetInstanceCullerViewStats(int viewIndex); // 0x0000000181F32FD0-0x0000000181F33080
		private static InstanceOcclusionEventStats GetInstanceOcclusionEventStats(int passIndex); // 0x0000000181F330E0-0x0000000181F33190
		private static DebugOccluderStats GetOccluderStats(int occluderIndex); // 0x0000000181F33190-0x0000000181F33240
		private static int GetOcclusionContextsCounts(); // 0x0000000181F332F0-0x0000000181F33350
		private static int GetInstanceCullerViewCount(); // 0x0000000181F32F70-0x0000000181F32FD0
		private static int GetInstanceOcclusionEventCount(); // 0x0000000181F33080-0x0000000181F330E0
		private static DebugUI.Table.Row AddInstanceCullerViewDataRow(int viewIndex); // 0x0000000181F31CC0-0x0000000181F322E0
		private static object OccluderVersionString([IsReadOnly] in InstanceOcclusionEventStats stats); // 0x0000000181F33350-0x0000000181F333B0
		private static object OcclusionTestString([IsReadOnly] in InstanceOcclusionEventStats stats); // 0x0000000181F333B0-0x0000000181F33420
		private static object VisibleInstancesString([IsReadOnly] in InstanceOcclusionEventStats stats); // 0x0000000181F33480-0x0000000181F334E0
		private static object CulledInstancesString([IsReadOnly] in InstanceOcclusionEventStats stats); // 0x0000000181F32EB0-0x0000000181F32F10
		private static object VisiblePrimitivesString([IsReadOnly] in InstanceOcclusionEventStats stats); // 0x0000000181F334E0-0x0000000181F33540
		private static object CulledPrimitivesString([IsReadOnly] in InstanceOcclusionEventStats stats); // 0x0000000181F32F10-0x0000000181F32F70
		private static DebugUI.Table.Row AddInstanceOcclusionPassDataRow(int eventIndex); // 0x0000000181F322E0-0x0000000181F32B10
		private static DebugUI.Table.Row AddOcclusionContextDataRow(int index); // 0x0000000181F32B10-0x0000000181F32EB0
		public bool TryGetScreenClearColor(ref Color color); // 0x00000001802E7840-0x00000001802E7850
		IDebugDisplaySettingsPanelDisposable IDebugDisplaySettingsData.CreatePanel(); // 0x0000000181F33420-0x0000000181F33480
	}
}
