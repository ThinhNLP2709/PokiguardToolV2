/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Obsolete("Use the non-generic DebugDisplaySettingsStats class. #from(6000.6)")]
	public class DebugDisplaySettingsStats<TProfileId> : IDebugDisplaySettingsData // TypeDefIndex: 5416
		where TProfileId : Enum
	{
		// Fields
		[CompilerGenerated]
		private readonly DebugDisplayStats<TProfileId> _debugDisplayStats_k__BackingField;
	
		// Properties
		public DebugDisplayStats<TProfileId> debugDisplayStats { [CompilerGenerated] get; }
		public bool AreAnySettingsActive { get; }
	
		// Nested types
		[DisplayInfo(name = "Display Stats", order = 2147483647)]
		private class StatsPanel : DebugDisplaySettingsPanel // TypeDefIndex: 5417
		{
			// Fields
			private readonly DebugDisplaySettingsStats<TProfileId> m_Data;
	
			// Properties
			public override DebugUI.Flags Flags { get; }
	
			// Constructors
			public StatsPanel(DebugDisplaySettingsStats<TProfileId> displaySettingsStats);
	
			// Methods
			public override void Dispose();
		}
	
		// Constructors
		public DebugDisplaySettingsStats(DebugDisplayStats<TProfileId> debugDisplayStats);
	
		// Methods
		public IDebugDisplaySettingsPanelDisposable CreatePanel();
	}
}
