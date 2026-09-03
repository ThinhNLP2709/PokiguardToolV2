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
	[AddComponentMenu("Event/Physics Raycaster")]
	[RequireComponent(typeof(Camera))]
	[UGUIHelpURL("PhysicsRaycaster")]
	public class PhysicsRaycaster : BaseRaycaster // TypeDefIndex: 13210
	{
		// Fields
		protected const int kNoEventMaskSet = -1; // Metadata: 0x006A77E6
		protected Camera m_EventCamera; // 0x28
		[SerializeField]
		protected LayerMask m_EventMask; // 0x30
		[SerializeField]
		protected int m_MaxRayIntersections; // 0x34
		protected int m_LastMaxRayIntersections; // 0x38
		private RaycastHit[] m_Hits; // 0x40
	
		// Properties
		public override Camera eventCamera { get; } // 0x00000001825B7360-0x00000001825B7440 
		public virtual int depth { get; } // 0x00000001825B72A0-0x00000001825B7360 
		public int finalEventMask { get; } // 0x00000001825B7440-0x00000001825B7500 
		public LayerMask eventMask { get; set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		public int maxRayIntersections { get; set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780
	
		// Nested types
		private class RaycastHitComparer : IComparer<RaycastHit> // TypeDefIndex: 13211
		{
			// Fields
			public static readonly RaycastHitComparer instance; // 0x00
	
			// Constructors
			public RaycastHitComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
			static RaycastHitComparer(); // 0x00000001825C62E0-0x00000001825C6350
	
			// Methods
			public int Compare(RaycastHit x, RaycastHit y); // 0x00000001825C62B0-0x00000001825C62E0
		}
	
		// Constructors
		protected PhysicsRaycaster(); // 0x00000001825B6920-0x00000001825B6950
	
		// Methods
		protected bool ComputeRayAndDistance(PointerEventData eventData, ref Ray ray, ref int eventDisplayIndex, ref float distanceToClipPlane); // 0x00000001825B6950-0x00000001825B6D90
		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList); // 0x00000001825B6D90-0x00000001825B72A0
	}
}
