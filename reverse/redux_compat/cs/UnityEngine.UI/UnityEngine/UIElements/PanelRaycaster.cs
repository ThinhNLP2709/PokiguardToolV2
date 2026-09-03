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
	[AddComponentMenu("UI Toolkit/Panel Raycaster (UI Toolkit)")]
	[UGUIHelpURL("PanelRaycaster")]
	public class PanelRaycaster : BaseRaycaster, IRuntimePanelComponent // TypeDefIndex: 13156
	{
		// Fields
		private IRuntimePanel m_Panel; // 0x28
	
		// Properties
		public IPanel panel { get; set; } // 0x000000018033D240-0x000000018033D250 0x00000001825B5F30-0x00000001825B60C0
		private GameObject selectableGameObject { get; } // 0x00000001825B5DE0-0x00000001825B5E30 
		public override int sortOrderPriority { get; } // 0x00000001825B5E30-0x00000001825B5F30 
		public override int renderOrderPriority { get; } // 0x00000001825B5D20-0x00000001825B5DE0 
		public override Camera eventCamera { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		public PanelRaycaster(); // 0x00000001820502E0-0x00000001820502F0
	
		// Methods
		private void RegisterCallbacks(); // 0x00000001825B5BE0-0x00000001825B5C80
		private void UnregisterCallbacks(); // 0x00000001825B5C80-0x00000001825B5D20
		private void OnPanelDestroyed(); // 0x00000001825B55B0-0x00000001825B5710
		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList); // 0x00000001825B5710-0x00000001825B5BE0
	}
}
