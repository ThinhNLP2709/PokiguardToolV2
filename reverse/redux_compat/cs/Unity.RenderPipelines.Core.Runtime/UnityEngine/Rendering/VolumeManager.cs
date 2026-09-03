/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public sealed class VolumeManager // TypeDefIndex: 5527
	{
		// Fields
		private static readonly ProfilerMarker k_ProfilerMarkerInitialize; // 0x00
		private static readonly ProfilerMarker k_ProfilerMarkerInitializeBaseTypesArray; // 0x08
		private static readonly ProfilerMarker k_ProfilerMarkerUpdate; // 0x10
		private static readonly ProfilerMarker k_ProfilerMarkerReplaceData; // 0x18
		private static readonly ProfilerMarker k_ProfilerMarkerEvaluateVolumeDefaultState; // 0x20
		private static readonly Lazy<VolumeManager> s_Instance; // 0x28
		[CompilerGenerated]
		private VolumeStack _stack_k__BackingField; // 0x10
		private static readonly Dictionary<Type, List<ValueTuple<string, Type>>> s_SupportedVolumeComponentsForRenderPipeline; // 0x30
		private Type[] m_BaseComponentTypeArray; // 0x18
		[CompilerGenerated]
		private VolumeProfile _globalDefaultProfile_k__BackingField; // 0x20
		[CompilerGenerated]
		private VolumeProfile _qualityDefaultProfile_k__BackingField; // 0x28
		[CompilerGenerated]
		private ReadOnlyCollection<VolumeProfile> _customDefaultProfiles_k__BackingField; // 0x30
		private readonly VolumeCollection m_VolumeCollection; // 0x38
		private VolumeComponent[] m_ComponentsDefaultState; // 0x40
		internal VolumeParameter[] m_ParametersDefaultState; // 0x48
		private VolumeStack m_DefaultStack; // 0x50
		private readonly List<VolumeStack> m_CreatedVolumeStacks; // 0x58
		[CompilerGenerated]
		private bool _isInitialized_k__BackingField; // 0x60
	
		// Properties
		public static VolumeManager instance { get; } // 0x0000000181E75470-0x0000000181E754F0 
		public VolumeStack stack { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		[Obsolete("Please use baseComponentTypeArray instead. #from(2021.2)")]
		public IEnumerable<Type> baseComponentTypes { get; } // 0x0000000181E75400-0x0000000181E75470 
		public Type[] baseComponentTypeArray { get; internal set; } // 0x0000000181E75400-0x0000000181E75470 0x00000001802FAF70-0x00000001802FAF80
		public VolumeProfile globalDefaultProfile { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public VolumeProfile qualityDefaultProfile { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public ReadOnlyCollection<VolumeProfile> customDefaultProfiles { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public bool isInitialized { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D4F0-0x000000018033D500 0x000000018033EA80-0x000000018033EA90
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5528
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<ValueTuple<string, Type>> __9__19_0; // 0x08
			public static Predicate<VolumeProfile> __9__53_0; // 0x10
			public static Predicate<Volume> __9__76_0; // 0x18
	
			// Constructors
			static __c(); // 0x0000000181E71460-0x0000000181E714D0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _BuildVolumeComponentDisplayList_b__19_0(ValueTuple<string, Type> a, ValueTuple<string, Type> b); // 0x0000000181E711E0-0x0000000181E71200
			internal bool _SetCustomDefaultProfiles_b__53_0(VolumeProfile x); // 0x0000000181E71250-0x0000000181E712A0
			internal bool _GetVolumes_b__76_0(Volume v); // 0x0000000181E71200-0x0000000181E71250
			internal VolumeManager _.cctor_b__79_0(); // 0x0000000181E71310-0x0000000181E713F0
		}
	
		[CompilerGenerated]
		private struct __c__DisplayClass63_0 // TypeDefIndex: 5529
		{
			// Fields
			public List<VolumeComponent> componentsDefaultStateList; // 0x00
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass63_1 // TypeDefIndex: 5530
		{
			// Fields
			public VolumeComponent profileComponent; // 0x10
	
			// Constructors
			public __c__DisplayClass63_1(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _EvaluateVolumeDefaultState_b__1(VolumeComponent x); // 0x0000000181E713F0-0x0000000181E71460
		}
	
		// Constructors
		internal VolumeManager(); // 0x0000000181E75350-0x0000000181E75400
		static VolumeManager(); // 0x0000000181E750C0-0x0000000181E75350
	
		// Methods
		[Obsolete("Please use the Register without a given layer index. #from(6000.0)")]
		public void Register(Volume volume, int layer); // 0x0000000181E739C0-0x0000000181E73CB0
		[Obsolete("Please use the Register without a given layer index. #from(6000.0)")]
		public void Unregister(Volume volume, int layer); // 0x0000000181E746D0-0x0000000181E749C0
		internal List<ValueTuple<string, Type>> GetVolumeComponentsForDisplay(Type currentPipelineAssetType); // 0x0000000181E72B90-0x0000000181E72DA0
		internal bool TryGetVolumePathAndType(Type type, [TupleElementNames(new string[2] {"path", "t" })] out ValueTuple<string, Type> result); // 0x0000000181E74230-0x0000000181E744B0
		private List<ValueTuple<string, Type>> BuildVolumeComponentDisplayList(Type[] types); // 0x0000000181E71540-0x0000000181E71760
		public VolumeComponent GetVolumeComponentDefaultState(Type volumeComponentType); // 0x0000000181E72AA0-0x0000000181E72B90
		public void Initialize(VolumeProfile globalDefaultVolumeProfile = null, VolumeProfile qualityDefaultVolumeProfile = null); // 0x0000000181E73300-0x0000000181E73500
		private void InitializeBaseTypesArray(VolumeProfile globalDefaultVolumeProfile = null); // 0x0000000181E72EF0-0x0000000181E730D0
		internal void InitializeInternal(VolumeProfile globalDefaultVolumeProfile = null, VolumeProfile qualityDefaultVolumeProfile = null); // 0x0000000181E730D0-0x0000000181E73220
		public void Deinitialize(); // 0x0000000181E71BC0-0x0000000181E71D80
		public void SetGlobalDefaultProfile(VolumeProfile profile); // 0x0000000181E740F0-0x0000000181E741E0
		public void SetQualityDefaultProfile(VolumeProfile profile); // 0x0000000181E74200-0x0000000181E74230
		public void SetCustomDefaultProfiles(List<VolumeProfile> profiles); // 0x0000000181E73F10-0x0000000181E740F0
		public void OnVolumeProfileChanged(VolumeProfile profile); // 0x0000000181E73750-0x0000000181E73810
		public void OnVolumeComponentChanged(VolumeComponent component); // 0x0000000181E73500-0x0000000181E73750
		public VolumeStack CreateStack(); // 0x0000000181E71B50-0x0000000181E71BC0
		private VolumeStack CreateStackInternal(); // 0x0000000181E71A60-0x0000000181E71B50
		public void ResetMainStack(); // 0x0000000181E73EF0-0x0000000181E73F10
		public void DestroyStack(VolumeStack stack); // 0x0000000181E71D80-0x0000000181E71DF0
		internal static Type[] GetBaseComponentTypesForPipeline(Type pipelineAssetType, VolumeProfile globalDefaultVolumeProfile = null); // 0x0000000181E726E0-0x0000000181E72740
		private static Type[] GetBaseComponentTypesFromProfile(Type pipelineAssetType, VolumeProfile globalDefaultVolumeProfile); // 0x0000000181E72740-0x0000000181E72AA0
		internal void InitializeVolumeComponents(); // 0x0000000181E73220-0x0000000181E73300
		private void EvaluateVolumeDefaultState(); // 0x0000000181E71DF0-0x0000000181E726E0
		public void Register(Volume volume); // 0x0000000181E73CB0-0x0000000181E73D10
		public void Unregister(Volume volume); // 0x0000000181E74670-0x0000000181E746D0
		public bool IsComponentActiveInMask<T>(LayerMask layerMask)
			where T : VolumeComponent;
		internal void SetLayerDirty(int layer); // 0x0000000181E741E0-0x0000000181E74200
		internal void UpdateVolumeLayer(Volume volume, int prevLayer, int newLayer); // 0x0000000181E749C0-0x0000000181E749F0
		private void OverrideData(VolumeStack stack, Volume volume, float interpFactor); // 0x0000000181E73810-0x0000000181E739C0
		internal void ReplaceData(VolumeStack stack); // 0x0000000181E73D10-0x0000000181E73EF0
		[Conditional("UNITY_EDITOR")]
		public void CheckDefaultVolumeState(); // 0x0000000181E71760-0x0000000181E717F0
		[Conditional("UNITY_EDITOR")]
		public void CheckStack(VolumeStack stack); // 0x0000000181E717F0-0x0000000181E71A10
		private bool CheckUpdateRequired(VolumeStack stack); // 0x0000000181E71A10-0x0000000181E71A60
		public void Update(Transform trigger, LayerMask layerMask); // 0x0000000181E75090-0x0000000181E750C0
		public void Update(VolumeStack stack, Transform trigger, LayerMask layerMask); // 0x0000000181E749F0-0x0000000181E75090
		public Volume[] GetVolumes(LayerMask layerMask); // 0x0000000181E72DA0-0x0000000181E72ED0
		private List<Volume> GrabVolumes(LayerMask mask); // 0x0000000181E72ED0-0x0000000181E72EF0
		private static bool IsVolumeRenderedByCamera(Volume volume, Camera camera); // 0x00000001802E7990-0x00000001802E79A0
		[CompilerGenerated]
		internal static void _EvaluateVolumeDefaultState_g__ApplyDefaultProfile_63_0(VolumeProfile profile, ref __c__DisplayClass63_0 param_000092f4); // 0x0000000181E744B0-0x0000000181E74670
	}
}
