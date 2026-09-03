/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class DebugDisplaySettingsStats : IDebugDisplaySettingsData // TypeDefIndex: 5414
	{
		// Fields
		[CompilerGenerated]
		private readonly DebugDisplayStats _debugDisplayStats_k__BackingField; // 0x10
	
		// Properties
		public DebugDisplayStats debugDisplayStats { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public bool AreAnySettingsActive { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Nested types
		[DisplayInfo(name = "Display Stats", order = 2147483647)]
		private class StatsPanel : DebugDisplaySettingsPanel // TypeDefIndex: 5415
		{
			// Fields
			private readonly DebugDisplaySettingsStats m_Data; // 0x20
	
			// Properties
			public override DebugUI.Flags Flags { get; } // 0x00000001804CB980-0x00000001804CB990 
	
			// Constructors
			public StatsPanel(DebugDisplaySettingsStats displaySettingsStats); // 0x0000000181E4D340-0x0000000181E4D6B0
	
			// Methods
			public override void Dispose(); // 0x0000000181E4D2D0-0x0000000181E4D340
		}
	
		// Constructors
		public DebugDisplaySettingsStats(DebugDisplayStats debugDisplayStats); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public IDebugDisplaySettingsPanelDisposable CreatePanel(); // 0x0000000181E3ABA0-0x0000000181E3AC00
	}
}
