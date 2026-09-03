/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UIElements
{
	internal class UIToolkitInteroperabilityBridge // TypeDefIndex: 13157
	{
		// Fields
		private EventSystem m_EventSystem; // 0x10
		private bool m_OverrideUIToolkitEvents; // 0x18
		private EventHandlerTypes m_HandlerTypes; // 0x1C
		private LayerMask m_WorldPickingLayers; // 0x20
		private float m_WorldPickingMaxDistance; // 0x24
		private bool m_CreateDefaultPanelComponents; // 0x28
		private bool m_Started; // 0x29
		private bool m_Enabled; // 0x2A
		private bool m_IsTrackingPanels; // 0x2B
		private GameObject m_WorldSpaceGo; // 0x30
		private bool m_PendingRegistration; // 0x38
		private readonly HashSet<IRuntimePanel> trackedPanels; // 0x40
		private readonly Dictionary<object, Action> destroyedActions; // 0x48
		private PanelInputSettings m_InputSettings; // 0x50
		private bool m_OldOverrideUIToolkitEvents; // 0x70
		private EventHandlerTypes m_OldHandlerTypes; // 0x74
		private bool m_OldCreateDefaultPanelComponents; // 0x78
		private bool m_OldDefaultEventCameraIsMainCamera; // 0x79
		private long m_OldEventCamerasHash; // 0x80
		private List<IRuntimePanel> m_PanelsToRemove; // 0x88
	
		// Properties
		internal EventSystem eventSystem { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001825C33D0-0x00000001825C3450
		public bool overrideUIToolkitEvents { get; internal set; } // 0x0000000180F9E350-0x0000000180F9E360 0x00000001825C34A0-0x00000001825C34B0
		public EventHandlerTypes handlerTypes { get; internal set; } // 0x0000000180B232F0-0x0000000180B23300 0x00000001825C3450-0x00000001825C34A0
		public int worldPickingLayers { get; internal set; } // 0x0000000180C4F680-0x0000000180C4F690 0x00000001825C34B0-0x00000001825C34D0
		public float worldPickingMaxDistance { get; internal set; } // 0x0000000181CE2830-0x0000000181CE2840 0x0000000181CE28E0-0x0000000181CE28F0
		public bool createDefaultPanelComponents { get; internal set; } // 0x0000000180327270-0x0000000180327280 0x00000001825C3380-0x00000001825C33D0
		private bool shouldTrackPanels { get; } // 0x00000001825C3360-0x00000001825C3380 
	
		// Nested types
		[Flags]
		public enum EventHandlerTypes // TypeDefIndex: 13158
		{
			ScreenOverlay = 1,
			WorldSpace = 2
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass38_0 // TypeDefIndex: 13159
		{
			// Fields
			public UIToolkitInteroperabilityBridge __4__this; // 0x10
			public IRuntimePanel panel; // 0x18
	
			// Constructors
			public __c__DisplayClass38_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _CreatePanelGameObject_b__0(); // 0x00000001825C1680-0x00000001825C16B0
		}
	
		// Constructors
		public UIToolkitInteroperabilityBridge(); // 0x00000001825C3190-0x00000001825C3360
	
		// Methods
		private void StartTrackingUIToolkitPanels(); // 0x00000001825C26F0-0x00000001825C29F0
		private void StartTrackingPanel(IRuntimePanel panel); // 0x00000001825C2690-0x00000001825C26F0
		private void StopTrackingUIToolkitPanels(); // 0x00000001825C2A00-0x00000001825C2C20
		private void UpdatePanelGameObject(IRuntimePanel panel); // 0x00000001825C2C20-0x00000001825C2CA0
		private void CreatePanelGameObject(IRuntimePanel panel); // 0x00000001825C1C30-0x00000001825C1F00
		private void DestroyPanelGameObject(IRuntimePanel panel); // 0x00000001825C20E0-0x00000001825C2210
		private void CreateWorldSpacePanelGameObject(); // 0x00000001825C1F00-0x00000001825C20E0
		private void DestroyWorldSpacePanelGameObject(); // 0x00000001825C2210-0x00000001825C2280
		public void Start(); // 0x00000001825C29F0-0x00000001825C2A00
		public void OnEnable(); // 0x00000001825C2430-0x00000001825C2690
		public void OnDisable(); // 0x00000001825C2280-0x00000001825C2430
		public void Update(); // 0x00000001825C30A0-0x00000001825C3190
		private void Apply(IPanelInputProvider input); // 0x00000001825C1A20-0x00000001825C1C30
		private void ApplyOverrideUIToolkitEvents(); // 0x00000001825C18D0-0x00000001825C1A20
		private void ApplyCameraProperties(); // 0x00000001825C1720-0x00000001825C1880
		private void ApplyOtherProperties(); // 0x00000001825C1880-0x00000001825C18D0
		private void UpdatePanelTracking(); // 0x00000001825C3070-0x00000001825C30A0
		private void UpdatePanelGameObjects(); // 0x00000001825C2CA0-0x00000001825C3070
	}
}
