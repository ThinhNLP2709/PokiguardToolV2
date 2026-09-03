/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public abstract class DebugDisplayStats // TypeDefIndex: 5433
	{
		// Fields
		private List<ProfilingSampler> m_CoreProfilingSamplers; // 0x10
		private static readonly string[] k_DetailedStatsColumnLabels; // 0x00
		private Dictionary<ProfilingSampler, AccumulatedTiming>[] m_AccumulatedTiming; // 0x18
		private float m_TimeSinceLastAvgValue; // 0x20
		private int m_AccumulatedFrames; // 0x24
		private HashSet<ProfilingSampler> m_HiddenSamplers; // 0x28
		private const float k_AccumulationTimeInSeconds = 1f; // Metadata: 0x006614C8
		protected bool averageProfilerTimingsOverASecond; // 0x30
		protected bool hideEmptyScopes; // 0x31
		private readonly DebugFrameTiming m_DebugFrameTiming; // 0x38
		private readonly List<ProfilingSampler> m_RecordedSamplers; // 0x40
	
		// Nested types
		private class AccumulatedTiming // TypeDefIndex: 5434
		{
			// Fields
			public float accumulatedValue; // 0x10
			public float lastAverage; // 0x14
	
			// Constructors
			public AccumulatedTiming(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void UpdateLastAverage(int frameCount); // 0x0000000181E38370-0x0000000181E38390
		}
	
		private enum DebugProfilingType // TypeDefIndex: 5435
		{
			CPU = 0,
			InlineCPU = 1,
			GPU = 2
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass23_0 // TypeDefIndex: 5436
		{
			// Fields
			public ProfilingSampler sampler; // 0x10
			public DebugProfilingType type; // 0x18
			public DebugDisplayStats __4__this; // 0x20
	
			// Constructors
			public __c__DisplayClass23_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal object _BuildProfilingSamplerWidgetList_b__1(); // 0x0000000181E4F110-0x0000000181E4F210
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass23_1 // TypeDefIndex: 5437
		{
			// Fields
			public ProfilingSampler sampler; // 0x10
			public DebugDisplayStats __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass23_1(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _BuildProfilingSamplerWidgetList_b__2(); // 0x0000000181E4F210-0x0000000181E4F270
			internal DebugUI.Value _BuildProfilingSamplerWidgetList_b__3(DebugProfilingType e); // 0x0000000181E4F270-0x0000000181E4F2A0
		}
	
		// Constructors
		protected DebugDisplayStats(); // 0x0000000181E3E5C0-0x0000000181E3E8B0
		static DebugDisplayStats(); // 0x0000000181E3E4C0-0x0000000181E3E5C0
	
		// Methods
		public virtual void EnableProfilingRecorders(); // 0x0000000181E3D5A0-0x0000000181E3D5B0
		protected void AddAndEnableProfilingSamplers(List<ProfilingSampler> samplers); // 0x0000000181E3CD60-0x0000000181E3CE90
		public virtual void DisableProfilingRecorders(); // 0x0000000181E3D480-0x0000000181E3D5A0
		public virtual void RegisterDebugUI(List<DebugUI.Widget> list); // 0x0000000181E3D8B0-0x0000000181E3DD60
		public virtual void Update(); // 0x0000000181E3E420-0x0000000181E3E4C0
		protected static List<ProfilingSampler> GetProfilingSamplersToDisplay(Type markersType); // 0x0000000181E3D5B0-0x0000000181E3D7B0
		protected void UpdateDetailedStats(List<ProfilingSampler> samplers); // 0x0000000181E3DF70-0x0000000181E3E000
		protected DebugUI.Widget BuildDetailedStatsList(string title, List<ProfilingSampler> samplers); // 0x0000000181E3CE90-0x0000000181E3D000
		private void UpdateListOfAveragedProfilerTimings(bool needUpdatingAverages, List<ProfilingSampler> samplers); // 0x0000000181E3E000-0x0000000181E3E420
		private float GetSamplerTiming(ProfilingSampler sampler, DebugProfilingType type); // 0x0000000181E3D7B0-0x0000000181E3D8B0
		protected ObservableList<DebugUI.Widget> BuildProfilingSamplerWidgetList(IEnumerable<ProfilingSampler> samplers); // 0x0000000181E3D000-0x0000000181E3D480
		[CompilerGenerated]
		private bool _RegisterDebugUI_b__6_0(); // 0x00000001802E8950-0x00000001802E8960
		[CompilerGenerated]
		private void _RegisterDebugUI_b__6_1(bool value); // 0x00000001802E8960-0x00000001802E8970
		[CompilerGenerated]
		private bool _RegisterDebugUI_b__6_2(); // 0x0000000180634F10-0x0000000180634F20
		[CompilerGenerated]
		private void _RegisterDebugUI_b__6_3(bool value); // 0x0000000181B14860-0x0000000181B14870
		[CompilerGenerated]
		private DebugUI.Value _BuildProfilingSamplerWidgetList_g__CreateWidgetForSampler_23_0(ProfilingSampler sampler, DebugProfilingType type); // 0x0000000181E3DD60-0x0000000181E3DF70
	}
}
