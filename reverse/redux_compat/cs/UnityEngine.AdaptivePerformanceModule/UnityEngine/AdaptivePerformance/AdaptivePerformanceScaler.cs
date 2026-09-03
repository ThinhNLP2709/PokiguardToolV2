/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	public abstract class AdaptivePerformanceScaler : ScriptableObject // TypeDefIndex: 14159
	{
		// Fields
		private AdaptivePerformanceIndexer m_Indexer; // 0x18
		[CompilerGenerated]
		private int _CurrentLevel_k__BackingField; // 0x20
		[CompilerGenerated]
		private int _GpuImpact_k__BackingField; // 0x24
		[CompilerGenerated]
		private int _CpuImpact_k__BackingField; // 0x28
		private int m_OverrideLevel; // 0x2C
		[SerializeField]
		private AdaptivePerformanceScalerSettingsBase m_defaultSetting; // 0x30
		protected IAdaptivePerformanceSettings m_Settings; // 0x38
	
		// Properties
		public virtual string Name { get; set; } // 0x0000000181A6EA40-0x0000000181A6EA60 0x000000018213E5A0-0x000000018213E600
		public virtual bool Enabled { get; set; } // 0x000000018213E3F0-0x000000018213E410 0x000000018213E500-0x000000018213E520
		public virtual float Scale { get; set; } // 0x000000018213E4A0-0x000000018213E4C0 0x000000018213E670-0x000000018213E6A0
		public virtual ScalerVisualImpact VisualImpact { get; set; } // 0x000000018213E4E0-0x000000018213E500 0x000000018213E6C0-0x000000018213E6E0
		public virtual ScalerTarget Target { get; set; } // 0x000000018213E4C0-0x000000018213E4E0 0x000000018213E6A0-0x000000018213E6C0
		public virtual int MaxLevel { get; set; } // 0x000000018213E460-0x000000018213E480 0x000000018213E550-0x000000018213E570
		public virtual float MinBound { get; set; } // 0x000000018213E480-0x000000018213E4A0 0x000000018213E570-0x000000018213E5A0
		public virtual float MaxBound { get; set; } // 0x000000018213E440-0x000000018213E460 0x000000018213E520-0x000000018213E550
		public int CurrentLevel { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public bool IsMaxLevel { get; } // 0x000000018213E410-0x000000018213E440 
		public bool NotLeveled { get; } // 0x0000000181B6AD70-0x0000000181B6AD80 
		public int GpuImpact { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
		public int CpuImpact { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
		public AdaptivePerformanceScalerSettingsBase DefaultSetting { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public int OverrideLevel { get; set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x000000018213E600-0x000000018213E670
	
		// Constructors
		protected AdaptivePerformanceScaler(); // 0x000000018212FB20-0x000000018212FB90
	
		// Methods
		public int CalculateCost(); // 0x000000018213DAD0-0x000000018213DDB0
		protected virtual void Awake(); // 0x000000018213D940-0x000000018213DAD0
		internal void InitializeScaler(); // 0x000000018213DFC0-0x000000018213E170
		private void OnEnable(); // 0x000000018213DE90-0x000000018213DEE0
		internal void EnableScaler(); // 0x000000018213DE90-0x000000018213DEE0
		internal void RemoveScaler(); // 0x000000018213E180-0x000000018213E2D0
		private void OnDisable(); // 0x000000018213E170-0x000000018213E180
		internal void IncreaseLevel(); // 0x000000018213DEE0-0x000000018213DFC0
		internal void DecreaseLevel(); // 0x000000018213DDD0-0x000000018213DE90
		internal void Activate(); // 0x000000018213D920-0x000000018213D940
		internal void Deactivate(); // 0x000000018213DDB0-0x000000018213DDD0
		public void ApplyDefaultSetting(AdaptivePerformanceScalerSettingsBase defaultSetting); // 0x0000000180378110-0x0000000180378120
		protected bool ScaleChanged(); // 0x000000018213E2D0-0x000000018213E3F0
		protected virtual void OnLevelIncrease(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnLevelDecrease(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnLevel(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnEnabled(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnDisabled(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
