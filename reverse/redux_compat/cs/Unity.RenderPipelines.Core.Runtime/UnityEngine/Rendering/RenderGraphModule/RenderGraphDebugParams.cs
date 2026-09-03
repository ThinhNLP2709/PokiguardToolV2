/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	internal class RenderGraphDebugParams : IDebugDisplaySettingsQuery // TypeDefIndex: 5897
	{
		// Fields
		private DebugUI.Widget[] m_DebugItems; // 0x10
		private DebugUI.Panel m_DebugPanel; // 0x18
		public bool clearRenderTargetsAtCreation; // 0x20
		public bool clearRenderTargetsAtRelease; // 0x21
		public bool disablePassCulling; // 0x22
		public bool disablePassMerging; // 0x23
	
		// Properties
		public bool AreAnySettingsActive { get; } // 0x0000000181EC3D70-0x0000000181EC3D90 
	
		// Nested types
		private static class Strings // TypeDefIndex: 5898
		{
			// Fields
			public static readonly DebugUI.Widget.NameAndTooltip ClearRenderTargetsAtCreation; // 0x00
			public static readonly DebugUI.Widget.NameAndTooltip ClearRenderTargetsAtFree; // 0x10
			public static readonly DebugUI.Widget.NameAndTooltip DisablePassCulling; // 0x20
			public static readonly DebugUI.Widget.NameAndTooltip DisablePassMerging; // 0x30
	
			// Constructors
			static Strings(); // 0x0000000181ECBA70-0x0000000181ECBC70
		}
	
		// Constructors
		public RenderGraphDebugParams(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal void Reset(); // 0x0000000181EC3CB0-0x0000000181EC3CC0
		internal List<DebugUI.Widget> GetWidgetList(); // 0x0000000181EC35B0-0x0000000181EC3B20
		public void RegisterDebug(string name, DebugUI.Panel debugPanel = null); // 0x0000000181EC3B20-0x0000000181EC3CB0
		public void UnRegisterDebug(string name); // 0x0000000181EC3CF0-0x0000000181EC3D70
		[CompilerGenerated]
		private bool _GetWidgetList_b__8_0(); // 0x0000000180F1D2E0-0x0000000180F1D2F0
		[CompilerGenerated]
		private void _GetWidgetList_b__8_1(bool value); // 0x00000001813C7380-0x00000001813C7390
		[CompilerGenerated]
		private bool _GetWidgetList_b__8_2(); // 0x000000018147B6C0-0x000000018147B6D0
		[CompilerGenerated]
		private void _GetWidgetList_b__8_3(bool value); // 0x000000018147BC30-0x000000018147BC40
		[CompilerGenerated]
		private bool _GetWidgetList_b__8_4(); // 0x0000000181ACC770-0x0000000181ACC780
		[CompilerGenerated]
		private void _GetWidgetList_b__8_5(bool value); // 0x0000000181EC3CC0-0x0000000181EC3CD0
		[CompilerGenerated]
		private bool _GetWidgetList_b__8_6(); // 0x0000000181EC3CD0-0x0000000181EC3CE0
		[CompilerGenerated]
		private void _GetWidgetList_b__8_7(bool value); // 0x0000000181EC3CE0-0x0000000181EC3CF0
	}
}
