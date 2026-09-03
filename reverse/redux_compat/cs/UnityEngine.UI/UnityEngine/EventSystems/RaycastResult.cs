/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.EventSystems
{
	public struct RaycastResult // TypeDefIndex: 13206
	{
		// Fields
		private GameObject m_GameObject; // 0x00
		public BaseRaycaster module; // 0x08
		public float distance; // 0x10
		public float index; // 0x14
		public int depth; // 0x18
		public int sortingGroupID; // 0x1C
		public int sortingGroupOrder; // 0x20
		public int sortingLayer; // 0x24
		public int sortingOrder; // 0x28
		public Vector3 origin; // 0x2C
		public Vector3 worldPosition; // 0x38
		public Vector3 worldNormal; // 0x44
		public Vector2 screenPosition; // 0x50
		public int displayIndex; // 0x58
		public IPanelComponent panelComponent; // 0x60
		internal IEventHandler m_element; // 0x68
	
		// Properties
		public GameObject gameObject { get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
		public bool isValid { get; } // 0x00000001825BBB90-0x00000001825BBC10 
		[Obsolete("RaycastResult.document is obsolete. Use RaycastResult.panelComponent instead.", true)]
		public UIDocument document { get; set; } // 0x00000001825BBAD0-0x00000001825BBB20 0x00000001803780F0-0x0000000180378100
		public VisualElement element { get; set; } // 0x00000001825BBB20-0x00000001825BBB90 0x0000000180316A40-0x0000000180316A50
	
		// Methods
		public void Clear(); // 0x00000001825BB480-0x00000001825BB560
		public override string ToString(); // 0x00000001825BB560-0x00000001825BBAD0
	}
}
