/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	internal class DebugDisplaySettingsCommon : IDebugDisplaySettingsData, ISerializedDebugDisplaySettings // TypeDefIndex: 9332
	{
		// Properties
		public bool AreAnySettingsActive { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Nested types
		[DisplayInfo(name = "Frequently Used", order = -1)]
		private class SettingsPanel : DebugDisplaySettingsPanel // TypeDefIndex: 9333
		{
			// Nested types
			[CompilerGenerated]
			private sealed class __c__DisplayClass0_0 // TypeDefIndex: 9334
			{
				// Fields
				public string panelName; // 0x10
	
				// Constructors
				public __c__DisplayClass0_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal void _AddGoToSectionContextMenuItem_b__0(); // 0x0000000181F61560-0x0000000181F615C0
			}
	
			// Constructors
			public SettingsPanel(); // 0x0000000181F5CE10-0x0000000181F5D4E0
	
			// Methods
			private DebugUI.Foldout.ContextMenuItem AddGoToSectionContextMenuItem(string panelName); // 0x0000000181F5CCF0-0x0000000181F5CE10
		}
	
		// Constructors
		public DebugDisplaySettingsCommon(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public IDebugDisplaySettingsPanelDisposable CreatePanel(); // 0x0000000181F55E30-0x0000000181F55E80
	}
}
