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
using UnityEngine.Serialization;
using UnityEngine.UIElements;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.EventSystems
{
	[AddComponentMenu("Event/Event System")]
	[DisallowMultipleComponent]
	[UGUIHelpURL("EventSystem")]
	public class EventSystem : UIBehaviour // TypeDefIndex: 13187
	{
		// Fields
		private static readonly List<EventSystem> m_EventSystems; // 0x00
		private static UIToolkitOverrideConfigOld? s_UIToolkitOverrideConfigOld; // 0x08
		private List<BaseInputModule> m_SystemInputModules; // 0x20
		private BaseInputModule m_CurrentInputModule; // 0x28
		[FormerlySerializedAs("m_Selected")]
		[SerializeField]
		private GameObject m_FirstSelected; // 0x30
		[SerializeField]
		private bool m_sendNavigationEvents; // 0x38
		[SerializeField]
		private int m_DragThreshold; // 0x3C
		private GameObject m_CurrentSelected; // 0x40
		private bool m_HasFocus; // 0x48
		private bool m_SelectionGuard; // 0x49
		private BaseEventData m_DummyData; // 0x50
		private static readonly Comparison<RaycastResult> s_RaycastComparer; // 0x20
		private UIToolkitInteroperabilityBridge m_UIToolkitInterop; // 0x58
	
		// Properties
		public static EventSystem current { get; set; } // 0x00000001825B07D0-0x00000001825B0840 0x00000001825B0900-0x00000001825B0A60
		public bool sendNavigationEvents { get; set; } // 0x0000000180476380-0x0000000180476390 0x00000001804763A0-0x00000001804763B0
		public int pixelDragThreshold { get; set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x00000001805D5550-0x00000001805D5560
		public BaseInputModule currentInputModule { get; } // 0x000000018033D240-0x000000018033D250 
		public GameObject firstSelectedGameObject { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public GameObject currentSelectedGameObject { get; } // 0x0000000180377940-0x0000000180377950 
		[Obsolete("lastSelectedGameObject is no longer supported", true)]
		public GameObject lastSelectedGameObject { get; } // 0x00000001802E7860-0x00000001802E7870 
		public bool isFocused { get; } // 0x00000001804EFDA0-0x00000001804EFDB0 
		public bool alreadySelecting { get; } // 0x0000000181A42150-0x0000000181A42160 
		private BaseEventData baseEventDataCache { get; } // 0x00000001825B0750-0x00000001825B07D0 
		internal UIToolkitInteroperabilityBridge uiToolkitInterop { get; } // 0x00000001802F4000-0x00000001802F4010 
		internal bool isOverridingUIToolkitEvents { get; } // 0x00000001825B0840-0x00000001825B0900 
	
		// Nested types
		private struct UIToolkitOverrideConfigOld // TypeDefIndex: 13188
		{
			// Fields
			public EventSystem activeEventSystem; // 0x00
			public bool sendEvents; // 0x08
			public bool createPanelGameObjectsOnStart; // 0x09
		}
	
		// Constructors
		protected EventSystem(); // 0x00000001825B0690-0x00000001825B0750
		static EventSystem(); // 0x00000001825B0580-0x00000001825B0690
	
		// Methods
		public void UpdateModules(); // 0x00000001825B0170-0x00000001825B0290
		public void SetSelectedGameObject(GameObject selected, BaseEventData pointer); // 0x00000001825AF810-0x00000001825AFA40
		public void SetSelectedGameObject(GameObject selected); // 0x00000001825AF770-0x00000001825AF810
		private static int RaycastComparer(RaycastResult lhs, RaycastResult rhs); // 0x00000001825AF310-0x00000001825AF770
		public void RaycastAll(PointerEventData eventData, List<RaycastResult> raycastResults); // 0x00000001825AF110-0x00000001825AF310
		public bool IsPointerOverGameObject(); // 0x00000001825AEA40-0x00000001825AEAD0
		public bool IsPointerOverGameObject(int pointerId); // 0x00000001825AE9A0-0x00000001825AEA40
		[Obsolete("Use PanelInputConfiguration component instead.")]
		public static void SetUITookitEventSystemOverride(EventSystem activeEventSystem, bool sendEvents = true /* Metadata: 0x006A77C1 */, bool createPanelGameObjectsOnStart = true /* Metadata: 0x006A77C2 */); // 0x00000001825AFA40-0x00000001825AFF00
		protected override void OnEnable(); // 0x00000001825AED80-0x00000001825AF110
		protected override void OnDisable(); // 0x00000001825AEAE0-0x00000001825AED80
		protected override void Start(); // 0x00000001825AFF00-0x00000001825AFF30
		private void TickModules(); // 0x00000001825AFF30-0x00000001825B0020
		protected virtual void OnApplicationFocus(bool hasFocus); // 0x00000001825AEAD0-0x00000001825AEAE0
		protected virtual void Update(); // 0x00000001825B0290-0x00000001825B0580
		private void ChangeEventModule(BaseInputModule module); // 0x00000001825AE8C0-0x00000001825AE9A0
		public override string ToString(); // 0x00000001825B0020-0x00000001825B0170
	}
}
