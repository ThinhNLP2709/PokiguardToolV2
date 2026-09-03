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

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.EventSystems
{
	[AddComponentMenu("Event/Physics 2D Raycaster")]
	[RequireComponent(typeof(Camera))]
	[UGUIHelpURL("Physics2DRaycaster")]
	public class Physics2DRaycaster : PhysicsRaycaster // TypeDefIndex: 13209
	{
		// Fields
		private RaycastHit2D[] m_Hits; // 0x48
	
		// Constructors
		protected Physics2DRaycaster(); // 0x00000001825B6920-0x00000001825B6950
	
		// Methods
		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList); // 0x00000001825B60C0-0x00000001825B6920
	}
}
