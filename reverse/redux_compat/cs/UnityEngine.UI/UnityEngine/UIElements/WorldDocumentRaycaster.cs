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
	[AddComponentMenu("UI Toolkit/World Document Raycaster (UI Toolkit)")]
	public class WorldDocumentRaycaster : BaseRaycaster // TypeDefIndex: 13160
	{
		// Fields
		[SerializeField]
		private Camera m_EventCamera; // 0x28
	
		// Properties
		public override Camera eventCamera { get; } // 0x000000018033D240-0x000000018033D250 
		public Camera camera { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
	
		// Constructors
		public WorldDocumentRaycaster(); // 0x00000001820502E0-0x00000001820502F0
	
		// Methods
		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList); // 0x00000001825C5CA0-0x00000001825C62B0
		protected virtual bool GetWorldRay(PointerEventData eventData, out Ray worldRay, out float maxDistance, out int layerMask); // 0x00000001825C5B00-0x00000001825C5CA0
	}
}
