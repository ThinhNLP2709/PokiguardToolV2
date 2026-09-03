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
	public class DebugDisplaySettingsUI : IDebugData // TypeDefIndex: 5418
	{
		// Fields
		private IEnumerable<IDebugDisplaySettingsPanelDisposable> m_DisposablePanels; // 0x10
		private IDebugDisplaySettings m_Settings; // 0x18
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass6_0 // TypeDefIndex: 5419
		{
			// Fields
			public List<IDebugDisplaySettingsPanelDisposable> panels; // 0x10
	
			// Constructors
			public __c__DisplayClass6_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _InitializeDebugUI_b__0(IDebugDisplaySettingsData data); // 0x0000000181E4F3A0-0x0000000181E4F610
		}
	
		// Constructors
		public DebugDisplaySettingsUI(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		private void Reset(); // 0x0000000181E3B350-0x0000000181E3B3C0
		private void ReregisterDebugPanels(); // 0x0000000181E3B320-0x0000000181E3B350
		public void RegisterDebug(IDebugDisplaySettings settings); // 0x0000000181E3AF40-0x0000000181E3B320
		private void DebugUIOpened(DebugManager.UIMode uiMode, bool isOpen); // 0x0000000181E3AC00-0x0000000181E3AC10
		internal void InitializeDebugUI(); // 0x0000000181E3AC80-0x0000000181E3AF40
		public void UnregisterDebug(); // 0x0000000181E3B3C0-0x0000000181E3BA70
		public Action GetReset(); // 0x0000000181E3AC10-0x0000000181E3AC80
	}
}
