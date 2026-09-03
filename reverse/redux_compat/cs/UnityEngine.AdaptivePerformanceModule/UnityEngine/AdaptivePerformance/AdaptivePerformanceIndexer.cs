/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	public class AdaptivePerformanceIndexer // TypeDefIndex: 14154
	{
		// Fields
		private List<AdaptivePerformanceScaler> m_UnappliedScalers; // 0x10
		private List<AdaptivePerformanceScaler> m_AppliedScalers; // 0x18
		private List<AdaptivePerformanceScaler> m_DisabledScalers; // 0x20
		private ThermalStateTracker m_ThermalStateTracker; // 0x28
		private PerformanceStateTracker m_PerformanceStateTracker; // 0x30
		private UtilizationStateTracker m_CpuUtilizationTracker; // 0x38
		private UtilizationStateTracker m_GpuUtilizationTracker; // 0x40
		private AdaptivePerformanceScalerEfficiencyTracker m_ScalerEfficiencyTracker; // 0x48
		private IAdaptivePerformanceSettings m_Settings; // 0x50
		[CompilerGenerated]
		private float _TimeUntilNextAction_k__BackingField; // 0x58
		[CompilerGenerated]
		private StateAction _ThermalAction_k__BackingField; // 0x5C
		[CompilerGenerated]
		private StateAction _PerformanceAction_k__BackingField; // 0x60
		[CompilerGenerated]
		private Action<AdaptivePerformanceScaler> ScalerLevelChanged; // 0x68
		[CompilerGenerated]
		private StateAction _CpuUtilizationAction_k__BackingField; // 0x70
		[CompilerGenerated]
		private StateAction _GpuUtilizationAction_k__BackingField; // 0x74
	
		// Properties
		public float TimeUntilNextAction { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018042C5E0-0x000000018042C5F0 0x0000000181DB54E0-0x0000000181DB54F0
		private StateAction ThermalAction { [CompilerGenerated] set; } // 0x000000018033E880-0x000000018033E890
		public StateAction PerformanceAction { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018150C180-0x000000018150C190 0x000000018041DC00-0x000000018041DC10
		public StateAction CpuUtilizationAction { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180CC2260-0x0000000180CC2270 0x0000000180CC2270-0x0000000180CC2280
		public StateAction GpuUtilizationAction { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181974810-0x0000000181974820 0x000000018198E760-0x000000018198E770
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 14155
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<float> __9__42_0; // 0x08
			public static Func<float> __9__42_1; // 0x10
	
			// Constructors
			static __c(); // 0x0000000182145A00-0x0000000182145A70
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal float _.ctor_b__42_0(); // 0x00000001821457A0-0x0000000182145890
			internal float _.ctor_b__42_1(); // 0x0000000182145890-0x0000000182145980
		}
	
		// Constructors
		internal AdaptivePerformanceIndexer(ref IAdaptivePerformanceSettings settings, PerformanceStateTracker tracker); // 0x0000000182133820-0x0000000182133C10
	
		// Methods
		internal void NotifyScalerLevelChanged(AdaptivePerformanceScaler scaler); // 0x00000001803722F0-0x0000000180372310
		public void GetAppliedScalers(ref List<AdaptivePerformanceScaler> scalers); // 0x0000000182132960-0x00000001821329E0
		public void GetUnappliedScalers(ref List<AdaptivePerformanceScaler> scalers); // 0x0000000182132A60-0x0000000182132AE0
		public void GetDisabledScalers(ref List<AdaptivePerformanceScaler> scalers); // 0x00000001821329E0-0x0000000182132A60
		public void UnapplyAllScalers(); // 0x0000000182132C60-0x0000000182132EA0
		internal void UpdateOverrideLevel(AdaptivePerformanceScaler scaler); // 0x0000000182133240-0x00000001821332B0
		internal void AddScaler(AdaptivePerformanceScaler scaler); // 0x0000000182131BC0-0x0000000182131C60
		internal bool RemoveScaler(AdaptivePerformanceScaler scaler); // 0x0000000182132B30-0x0000000182132C60
		internal StateAction MostPressingAction(StateAction action1, StateAction action2, StateAction action3); // 0x0000000182132AE0-0x0000000182132B30
		internal void Update(); // 0x00000001821332B0-0x0000000182133820
		protected virtual float DeltaTime(); // 0x0000000181FE5730-0x0000000181FE5740
		private void CollectProfilerStats(); // 0x0000000182132220-0x0000000182132650
		private void DeactivateDisabledScalers(); // 0x0000000182132650-0x0000000182132960
		private void ActivateEnabledScalers(); // 0x0000000182131A30-0x0000000182131BC0
		private bool ApplyLowestCostScaler(); // 0x0000000182131C60-0x0000000182131F70
		private void ApplyScaler(AdaptivePerformanceScaler scaler); // 0x0000000182131F70-0x0000000182132220
		private bool UnapplyHighestCostScaler(); // 0x0000000182132EA0-0x0000000182133050
		private void UnapplyScaler(AdaptivePerformanceScaler scaler); // 0x0000000182133050-0x0000000182133240
	}
}
