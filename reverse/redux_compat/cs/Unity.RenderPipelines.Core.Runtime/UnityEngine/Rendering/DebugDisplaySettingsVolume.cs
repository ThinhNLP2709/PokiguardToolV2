/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	public class DebugDisplaySettingsVolume : IDebugDisplaySettingsData, ISerializedDebugDisplaySettings // TypeDefIndex: 5420
	{
		// Fields
		[CompilerGenerated]
		private readonly IVolumeDebugSettings _volumeDebugSettings_k__BackingField; // 0x10
		private int m_SelectedComponentIndex; // 0x18
		private Camera m_SelectedCamera; // 0x20
		private VolumeComponent m_VolumeInterpolatedResults; // 0x28
		private bool m_StoreStackInterpolatedValues; // 0x30
		private ObservableList<Volume> m_InfluenceVolumes; // 0x38
		[TupleElementNames(new string[2] {"volume", "weight" })]
		private List<ValueTuple<Volume, float>> m_VolumesWeights; // 0x40
		internal int volumeComponentEnumIndex; // 0x48
		private const string k_PanelTitle = "Volume"; // Metadata: 0x006614C1
	
		// Properties
		[Obsolete("This property has been obsoleted and will be removed in a future version. #from(6000.2)")]
		public IVolumeDebugSettings volumeDebugSettings { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public int selectedComponent { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000181E3CD50-0x0000000181E3CD60
		public Type selectedComponentType { get; set; } // 0x0000000181E3CAE0-0x0000000181E3CB30 0x0000000181E3CC50-0x0000000181E3CD50
		public List<ValueTuple<string, Type>> volumeComponentsPathAndType { get; } // 0x0000000181E3CB30-0x0000000181E3CBC0 
		public Camera selectedCamera { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181E3CBC0-0x0000000181E3CC50
		internal VolumeComponent resultVolumeComponent { get; } // 0x0000000181E3C990-0x0000000181E3CAE0 
		public bool AreAnySettingsActive { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Nested types
		private static class Styles // TypeDefIndex: 5421
		{
			// Fields
			public static readonly GUIContent none; // 0x00
	
			// Constructors
			static Styles(); // 0x0000000181E4DF60-0x0000000181E4DFF0
		}
	
		private static class Strings // TypeDefIndex: 5422
		{
			// Fields
			public static readonly string cameraNeedsRendering; // 0x00
			public static readonly string none; // 0x08
			public static readonly string parameter; // 0x10
			public static readonly string component; // 0x18
			public static readonly string debugViewNotSupported; // 0x20
			public static readonly string volumeInfo; // 0x28
			public static readonly string gameObject; // 0x30
			public static readonly string priority; // 0x38
			public static readonly string resultValue; // 0x40
			public static readonly string resultValueTooltip; // 0x48
			public static readonly string globalDefaultValue; // 0x50
			public static readonly string globalDefaultValueTooltip; // 0x58
			public static readonly string qualityLevelValue; // 0x60
			public static readonly string qualityLevelValueTooltip; // 0x68
			public static readonly string global; // 0x70
			public static readonly string local; // 0x78
			public static readonly string volumeProfile; // 0x80
			public static readonly string parameterNotCalculated; // 0x88
	
			// Constructors
			static Strings(); // 0x0000000181E4D6B0-0x0000000181E4DB90
		}
	
		internal static class WidgetFactory // TypeDefIndex: 5423
		{
			// Fields
			private static readonly DebugUI.Value s_EmptyDebugUIValue; // 0x00
	
			// Nested types
			private struct VolumeParameterChain // TypeDefIndex: 5424
			{
				// Fields
				public DebugUI.Widget.NameAndTooltip nameAndTooltip; // 0x00
				public VolumeProfile volumeProfile; // 0x10
				public VolumeComponent volumeComponent; // 0x18
				public Volume volume; // 0x20
			}
	
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 5425
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Func<object> __9__2_0; // 0x08
				public static Func<bool> __9__7_0; // 0x10
				public static Func<object> __9__8_3; // 0x18
	
				// Constructors
				static __c(); // 0x0000000181E4F790-0x0000000181E4F800
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal object _CreateVolumeParameterWidget_b__2_0(); // 0x0000000181E4E460-0x0000000181E4E4C0
				internal bool _CreateVolumeTable_b__7_0(); // 0x00000001802E7990-0x00000001802E79A0
				internal object _GenerateTableColumns_b__8_3(); // 0x00000001815B1550-0x00000001815B1570
				internal object _.cctor_b__10_0(); // 0x00000001815B1550-0x00000001815B1570
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass0_0 // TypeDefIndex: 5426
			{
				// Fields
				public SettingsPanel panel; // 0x10
	
				// Constructors
				public __c__DisplayClass0_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _CreateComponentSelector_b__0(); // 0x0000000181E4E8E0-0x0000000181E4E910
				internal void _CreateComponentSelector_b__1(int value); // 0x0000000181E4E910-0x0000000181E4E950
				internal int _CreateComponentSelector_b__2(); // 0x0000000181E4E950-0x0000000181E4E980
				internal void _CreateComponentSelector_b__3(int value); // 0x0000000181E4E980-0x0000000181E4E9B0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass1_0 // TypeDefIndex: 5427
			{
				// Fields
				public SettingsPanel panel; // 0x10
	
				// Constructors
				public __c__DisplayClass1_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal UnityEngine.Object _CreateCameraSelector_b__0(); // 0x0000000181E4E9B0-0x0000000181E4E9E0
				internal void _CreateCameraSelector_b__1(UnityEngine.Object value); // 0x0000000181E4E9E0-0x0000000181E4EA50
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass8_0 // TypeDefIndex: 5428
			{
				// Fields
				public DebugDisplaySettingsVolume data; // 0x10
	
				// Constructors
				public __c__DisplayClass8_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass8_1 // TypeDefIndex: 5429
			{
				// Fields
				public VolumeParameterChain chain; // 0x10
				public __c__DisplayClass8_0 CS___8__locals1; // 0x38
	
				// Constructors
				public __c__DisplayClass8_1(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal object _GenerateTableColumns_b__0(); // 0x0000000181E4F610-0x0000000181E4F750
				internal UnityEngine.Object _GenerateTableColumns_b__1(); // 0x000000018031E110-0x000000018031E120
				internal object _GenerateTableColumns_b__2(); // 0x0000000181E4F750-0x0000000181E4F790
				internal UnityEngine.Object _GenerateTableColumns_b__4(); // 0x00000001802F8630-0x00000001802F8640
			}
	
			// Constructors
			static WidgetFactory(); // 0x0000000181E525E0-0x0000000181E52720
	
			// Methods
			public static DebugUI.EnumField CreateComponentSelector(SettingsPanel panel, Action<DebugUI.Field<int>, int> refresh); // 0x0000000181E50030-0x0000000181E50670
			public static DebugUI.CameraSelector CreateCameraSelector(SettingsPanel panel, Action<DebugUI.Field<UnityEngine.Object>, UnityEngine.Object> refresh); // 0x0000000181E4FE10-0x0000000181E50030
			internal static DebugUI.Widget CreateVolumeParameterWidget(string name, bool isResultParameter, VolumeParameter param); // 0x0000000181E50670-0x0000000181E507D0
			private static VolumeComponent GetSelectedVolumeComponent(VolumeProfile profile, Type selectedType); // 0x0000000181E52440-0x0000000181E525E0
			private static List<VolumeParameterChain> GetResolutionChain(DebugDisplaySettingsVolume data); // 0x0000000181E51960-0x0000000181E52440
			public static DebugUI.Table CreateVolumeTable(DebugDisplaySettingsVolume data); // 0x0000000181E507D0-0x0000000181E509C0
			private static void GenerateTableColumns(DebugUI.Table table, DebugDisplaySettingsVolume data, List<VolumeParameterChain> resolutionChain); // 0x0000000181E509C0-0x0000000181E51510
			private static void GenerateTableRows(DebugUI.Table table, List<VolumeParameterChain> resolutionChain); // 0x0000000181E51510-0x0000000181E51960
		}
	
		[DisplayInfo(name = "Volume", order = 2147483647)]
		internal class SettingsPanel : DebugDisplaySettingsPanel<DebugDisplaySettingsVolume> // TypeDefIndex: 5430
		{
			// Fields
			private DebugUI.Table m_VolumeTable; // 0x28
	
			// Nested types
			[CompilerGenerated]
			private sealed class __c__DisplayClass1_0 // TypeDefIndex: 5431
			{
				// Fields
				public SettingsPanel __4__this; // 0x10
				public DebugDisplaySettingsVolume data; // 0x18
	
				// Constructors
				public __c__DisplayClass1_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal void _.ctor_b__0(DebugUI.Field<UnityEngine.Object> _, UnityEngine.Object __); // 0x0000000181E4F000-0x0000000181E4F020
				internal void _.ctor_b__1(DebugUI.Field<int> _, int __); // 0x0000000181E4F000-0x0000000181E4F020
				internal bool _.ctor_b__2(); // 0x0000000181E4F020-0x0000000181E4F080
				internal bool _.ctor_b__3(); // 0x0000000181E4F080-0x0000000181E4F110
			}
	
			// Constructors
			public SettingsPanel(DebugDisplaySettingsVolume data); // 0x0000000181E4CE50-0x0000000181E4D2D0
	
			// Methods
			public override void Dispose(); // 0x0000000181E4C980-0x0000000181E4CAB0
			private void OnVolumeInfluenceChanged(ObservableList<Volume> sender, ListChangedEventArgs<Volume> e); // 0x0000000181E4CAB0-0x0000000181E4CAC0
			private void Refresh(); // 0x0000000181E4CAC0-0x0000000181E4CE50
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass10_0 // TypeDefIndex: 5432
		{
			// Fields
			public Type value; // 0x10
	
			// Constructors
			public __c__DisplayClass10_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _set_selectedComponentType_b__0(ValueTuple<string, Type> t); // 0x0000000180A69BF0-0x0000000180A69C30
		}
	
		// Constructors
		[Obsolete("This constructor has been obsoleted and will be removed in a future version. #from(6000.2)")]
		public DebugDisplaySettingsVolume(IVolumeDebugSettings volumeDebugSettings); // 0x0000000181E3C8A0-0x0000000181E3C990
		public DebugDisplaySettingsVolume(); // 0x0000000181E3C7D0-0x0000000181E3C8A0
	
		// Methods
		private void DestroyVolumeInterpolatedResults(); // 0x0000000181E3BC10-0x0000000181E3BC80
		private void OnSelectionChanged(); // 0x0000000181E3C620-0x0000000181E3C6D0
		private void ClearInterpolationData(); // 0x0000000181E3BB70-0x0000000181E3BBB0
		private static bool AreVolumesChanged(ObservableList<Volume> influenceVolumes, [TupleElementNames(new string[2] {"volume", "weight" })] List<ValueTuple<Volume, float>> volumesWeights); // 0x0000000181E3BA70-0x0000000181E3BB70
		private void OnBeginVolumeStackUpdate(VolumeStack stack, Camera camera); // 0x0000000181E3C1B0-0x0000000181E3C2D0
		private void OnEndVolumeStackUpdate(VolumeStack stack, Camera camera); // 0x0000000181E3C2D0-0x0000000181E3C620
		private void OnVolumeStackInterpolated(VolumeStack stack, Volume volume, float interpolationFactor); // 0x0000000181E3C6D0-0x0000000181E3C7D0
		public float GetVolumeWeight(Volume volume); // 0x0000000181E3C040-0x0000000181E3C1B0
		public ObservableList<Volume> GetVolumesList(); // 0x00000001803272A0-0x00000001803272B0
		void IDebugDisplaySettingsData.Reset(); // 0x0000000181E3C620-0x0000000181E3C6D0
		internal static string ExtractResult(VolumeParameter param); // 0x0000000181E3BC80-0x0000000181E3C040
		public IDebugDisplaySettingsPanelDisposable CreatePanel(); // 0x0000000181E3BBB0-0x0000000181E3BC10
	}
}
