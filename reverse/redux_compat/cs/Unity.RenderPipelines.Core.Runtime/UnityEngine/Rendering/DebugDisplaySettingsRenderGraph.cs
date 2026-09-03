/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	internal class DebugDisplaySettingsRenderGraph : IDebugDisplaySettingsData // TypeDefIndex: 5649
	{
		// Properties
		public bool AreAnySettingsActive { get; } // 0x0000000181E8D100-0x0000000181E8D2C0 
	
		// Nested types
		[DisplayInfo(name = "Rendering", order = 10)]
		private class SettingsPanel : DebugDisplaySettingsPanel // TypeDefIndex: 5650
		{
			// Constructors
			public SettingsPanel(DebugDisplaySettingsRenderGraph _); // 0x0000000181E9DCF0-0x0000000181E9E070
		}
	
		// Constructors
		public DebugDisplaySettingsRenderGraph(); // 0x0000000181E8CFE0-0x0000000181E8D100
	
		// Methods
		IDebugDisplaySettingsPanelDisposable IDebugDisplaySettingsData.CreatePanel(); // 0x0000000181E8CF80-0x0000000181E8CFE0
	}
}
