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
	public abstract class DebugDisplaySettingsPanel : IDebugDisplaySettingsPanelDisposable // TypeDefIndex: 5412
	{
		// Fields
		private readonly List<DebugUI.Widget> m_Widgets; // 0x10
		private readonly DisplayInfoAttribute m_DisplayInfo; // 0x18
	
		// Properties
		public virtual string PanelName { get; } // 0x0000000181E3AB20-0x0000000181E3AB50 
		public virtual int Order { get; } // 0x0000000181E3AB10-0x0000000181E3AB20 
		public DebugUI.Widget[] Widgets { get; } // 0x0000000181E3AB50-0x0000000181E3ABA0 
		public virtual DebugUI.Flags Flags { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		protected DebugDisplaySettingsPanel(); // 0x0000000181E3A9F0-0x0000000181E3AB10
	
		// Methods
		protected void AddWidget(DebugUI.Widget widget); // 0x0000000181E3A8B0-0x0000000181E3A9B0
		protected void Clear(); // 0x0000000181E3A9B0-0x0000000181E3A9F0
		public virtual void Dispose(); // 0x0000000181E3A9B0-0x0000000181E3A9F0
	}
}
