/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public sealed class DebugManager // TypeDefIndex: 5441
	{
		// Fields
		private const string k_EnableDebug = "Enable Debug"; // Metadata: 0x006614E6
		private const string k_ResetBtn = "Debug Reset"; // Metadata: 0x006614F3
		private const string k_DebugPreviousBtn = "Debug Previous"; // Metadata: 0x006614FF
		private const string k_DebugNextBtn = "Debug Next"; // Metadata: 0x0066150E
		private const string k_PersistentBtn = "Debug Persistent"; // Metadata: 0x00661519
		private const string k_DPadHorizontal = "Debug Horizontal"; // Metadata: 0x0066152A
		private const string k_MultiplierBtn = "Debug Multiplier"; // Metadata: 0x0066153B
		private const string k_AnyTouch = "Any Touch"; // Metadata: 0x0066154C
		private readonly InputActionMap m_DebugMenuEnableActions; // 0x10
		private readonly InputActionMap m_DebugMenuActions; // 0x18
		private InputAction m_MultiplierAction; // 0x20
		[CompilerGenerated]
		private static Action<UIMode, bool> windowStateChanged; // 0x00
		private readonly UIState m_EditorUIState; // 0x28
		private bool m_EnableRuntimeUI; // 0x30
		private readonly UIState m_RuntimeUIState; // 0x38
		private static readonly Lazy<DebugManager> s_Instance; // 0x08
		private ReadOnlyCollection<DebugUI.Panel> m_ReadOnlyPanels; // 0x40
		private readonly List<DebugUI.Panel> m_Panels; // 0x48
		[CompilerGenerated]
		private Action<bool> onDisplayRuntimeUIChanged; // 0x50
		[CompilerGenerated]
		private Action onSetDirty; // 0x58
		[CompilerGenerated]
		private Action resetData; // 0x60
		[CompilerGenerated]
		private Action onRecreateDebugUI; // 0x68
		[CompilerGenerated]
		private Action<string> onPanelSelectionRequested; // 0x70
		private string m_RequestedPanel; // 0x78
		[CompilerGenerated]
		private DebugUI.Widget _selectedWidget_k__BackingField; // 0x80
		[Obsolete("Polling pattern is deprecated. Subscribe to onRecreateDebugUI event instead. #from(6000.6)", false)]
		public bool refreshEditorRequested; // 0x88
	
		// Properties
		public bool displayEditorUI { get; set; } // 0x0000000181E43B40-0x0000000181E43B60 0x0000000181E43010-0x0000000181E43030
		public bool enableRuntimeUI { get; set; } // 0x00000001802E8950-0x00000001802E8960 0x0000000181E44120-0x0000000181E441E0
		public bool displayRuntimeUI { get; set; } // 0x00000001802E7840-0x00000001802E7850 0x0000000181E440C0-0x0000000181E44120
		public bool displayPersistentRuntimeUI { get; set; } // 0x00000001802E7840-0x00000001802E7850 0x0000000181E44060-0x0000000181E440C0
		public static DebugManager instance { get; } // 0x0000000181E43B60-0x0000000181E43BE0 
		public ReadOnlyCollection<DebugUI.Panel> panels { get; } // 0x0000000181E43BE0-0x0000000181E43C10 
		internal DebugUI.Widget selectedWidget { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4A0-0x000000018033D4B0 0x000000018033EA30-0x000000018033EA40
		public bool isAnyDebugUIActive { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Events
		public static event Action<UIMode, bool> windowStateChanged {
			add; // 0x0000000181E43A50-0x0000000181E43B40
			remove; // 0x0000000181E43F70-0x0000000181E44060
		}
		public event Action<bool> onDisplayRuntimeUIChanged {
			add; // 0x0000000181E436F0-0x0000000181E437B0
			remove; // 0x0000000181E43C10-0x0000000181E43CD0
		}
		public event Action onSetDirty {
			add; // 0x0000000181E43910-0x0000000181E439B0
			remove; // 0x0000000181E43E30-0x0000000181E43ED0
		}
		private event Action resetData {
			add; // 0x0000000181E439B0-0x0000000181E43A50
			remove; // 0x0000000181E43ED0-0x0000000181E43F70
		}
		internal event Action onRecreateDebugUI {
			add; // 0x0000000181E43870-0x0000000181E43910
			remove; // 0x0000000181E43D90-0x0000000181E43E30
		}
		internal event Action<string> onPanelSelectionRequested {
			add; // 0x0000000181E437B0-0x0000000181E43870
			remove; // 0x0000000181E43CD0-0x0000000181E43D90
		}
	
		// Nested types
		public enum UIMode // TypeDefIndex: 5442
		{
			EditorMode = 0,
			RuntimeMode = 1
		}
	
		private class UIState // TypeDefIndex: 5443
		{
			// Fields
			public UIMode mode; // 0x10
			private bool m_Open; // 0x14
	
			// Properties
			public bool open { get; set; } // 0x0000000181102980-0x0000000181102990 0x0000000181E4FA30-0x0000000181E4FAC0
	
			// Constructors
			public UIState(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5444
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<bool> __9__67_0; // 0x08
			public static Action __9__67_1; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181E4F950-0x0000000181E4F9C0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _.ctor_b__67_0(bool _p0_); // 0x00000001802E76C0-0x00000001802E76D0
			internal void _.ctor_b__67_1(); // 0x00000001802E76C0-0x00000001802E76D0
			internal DebugManager _.cctor_b__95_0(); // 0x0000000181E4E7C0-0x0000000181E4E810
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass80_0 // TypeDefIndex: 5445
		{
			// Fields
			public string displayName; // 0x10
	
			// Constructors
			public __c__DisplayClass80_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _FindPanelIndex_b__0(DebugUI.Panel p); // 0x000000018176F780-0x000000018176F7B0
		}
	
		// Constructors
		private DebugManager(); // 0x0000000181E43410-0x0000000181E436F0
		static DebugManager(); // 0x0000000181E43300-0x0000000181E43410
	
		// Methods
		internal void EnableInputCallbacks(); // 0x0000000181E41150-0x0000000181E41170
		internal void DisableInputCallbacks(); // 0x0000000181E41130-0x0000000181E41150
		private void ToggleRuntimeUI(); // 0x0000000181E43030-0x0000000181E43080
		private void RegisterDebugInputs(); // 0x0000000181E427E0-0x0000000181E42B00
		private void UpdateReadOnlyCollection(); // 0x0000000181E43280-0x0000000181E43300
		private void ForEachWidgetInContainer(DebugUI.Widget widget, Action<DebugUI.Widget> action); // 0x0000000181E41240-0x0000000181E41470
		internal void ForEachWidget(Action<DebugUI.Widget> action); // 0x0000000181E41470-0x0000000181E416C0
		public void RecreateDebugUI(); // 0x0000000181E426C0-0x0000000181E426E0
		public void Reset(); // 0x0000000181E42F30-0x0000000181E43010
		public void RegisterData(IDebugData data); // 0x0000000181E426F0-0x0000000181E427E0
		public void UnregisterData(IDebugData data); // 0x0000000181E43190-0x0000000181E43280
		private int GetMaxPinnedIndex(DebugUI.Container container); // 0x0000000181E41FF0-0x0000000181E42220
		internal void TogglePersistent(); // 0x00000001809CF740-0x00000001809CF750
		private void TogglePersistent(DebugUI.Widget widget, int? forceTupleIndex = default); // 0x00000001802E76C0-0x00000001802E76D0
		private void OnPanelDirty(DebugUI.Panel panel); // 0x0000000181E42540-0x0000000181E42570
		public int PanelIndex([DisallowNull] string displayName); // 0x0000000181E42610-0x0000000181E426C0
		public string PanelDisplayName(int panelIndex); // 0x0000000181E425C0-0x0000000181E42610
		public void RequestPanelSelection(string panelName); // 0x0000000181E42DB0-0x0000000181E42F30
		public DebugUI.Panel GetPanel(string displayName, bool createIfNull = false /* Metadata: 0x006614E3 */, int groupIndex = 0 /* Metadata: 0x006614E4 */, bool overrideIfExist = false /* Metadata: 0x006614E5 */); // 0x0000000181E42220-0x0000000181E42540
		public int FindPanelIndex(string displayName); // 0x0000000181E41170-0x0000000181E41240
		public void RemovePanel(string displayName); // 0x0000000181E42B00-0x0000000181E42CD0
		public void RemovePanel(DebugUI.Panel panel); // 0x0000000181E42CD0-0x0000000181E42D40
		public DebugUI.Widget[] GetItems(DebugUI.Flags flags); // 0x0000000181E41DA0-0x0000000181E41FF0
		internal DebugUI.Widget[] GetItemsFromContainer(DebugUI.Flags flags, DebugUI.IContainer container); // 0x0000000181E419E0-0x0000000181E41DA0
		public DebugUI.Widget GetItem(string queryPath); // 0x0000000181E418D0-0x0000000181E419E0
		private DebugUI.Widget GetItem(string queryPath, DebugUI.IContainer container); // 0x0000000181E416C0-0x0000000181E418D0
		[Obsolete("Use RecreateDebugUI() instead. RefreshEditor only marks widgets dirty, it doesn\'t recreate panel structure. #from(6000.6) (UnityUpgradable) -> RecreateDebugUI(*)", true)]
		public void RefreshEditor(); // 0x0000000181E426E0-0x0000000181E426F0
		[Obsolete("Use RecreateDebugUI() instead. #from(6000.6) (UnityUpgradable) -> RecreateDebugUI(*)", true)]
		public void ReDrawOnScreenDebug(); // 0x0000000181E426C0-0x0000000181E426E0
		[Obsolete("Use RequestEditorWindowPanelName instead. #from(6000.5)")]
		public void RequestEditorWindowPanelIndex(int index); // 0x0000000181E42D40-0x0000000181E42DA0
		[Obsolete("Use RequestPanelSelection instead. #from(6000.6) (UnityUpgradable) -> RequestPanelSelection(*)", true)]
		public void RequestEditorWindowPanel(string panelName); // 0x0000000181E42DA0-0x0000000181E42DB0
		[Obsolete("Method is obsolete. Use PanelDisplayName instead. #from(6000.4) (UnityUpgradable) -> PanelDisplayName", true)]
		public string PanelDiplayName(int panelIndex); // 0x0000000181E42570-0x0000000181E425C0
		[Obsolete("Use DebugManager.instance.displayEditorUI property instead. #from(2023.1)")]
		public void ToggleEditorUI(bool open); // 0x0000000181E43010-0x0000000181E43030
		[Obsolete("This method is unused. #from(6000.5)")]
		public int GetState(); // 0x00000001802E7860-0x00000001802E7870
		[CompilerGenerated]
		private void _RegisterDebugInputs_b__14_0(InputAction.CallbackContext _); // 0x0000000181E43080-0x0000000181E43090
		[CompilerGenerated]
		private void _RegisterDebugInputs_b__14_1(InputAction.CallbackContext ctx); // 0x0000000181E43090-0x0000000181E43190
	}
}
