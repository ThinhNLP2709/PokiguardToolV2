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
	public abstract class BaseRaycaster : UIBehaviour // TypeDefIndex: 13208
	{
		// Fields
		private BaseRaycaster m_RootRaycaster; // 0x20
	
		// Properties
		public abstract Camera eventCamera { get; }
		[Obsolete("Please use sortOrderPriority and renderOrderPriority", true)]
		public virtual int priority { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual int sortOrderPriority { get; } // 0x00000001825AE5B0-0x00000001825AE5C0 
		public virtual int renderOrderPriority { get; } // 0x00000001825AE5B0-0x00000001825AE5C0 
		public BaseRaycaster rootRaycaster { get; } // 0x00000001825AE5C0-0x00000001825AE680 
	
		// Constructors
		protected BaseRaycaster(); // 0x00000001820502E0-0x00000001820502F0
	
		// Methods
		public abstract void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList);
		public override string ToString(); // 0x00000001825AE380-0x00000001825AE5B0
		protected override void OnEnable(); // 0x00000001825AE230-0x00000001825AE380
		protected override void OnDisable(); // 0x00000001825AE130-0x00000001825AE230
		protected override void OnCanvasHierarchyChanged(); // 0x00000001825AE100-0x00000001825AE130
		protected override void OnTransformParentChanged(); // 0x00000001825AE100-0x00000001825AE130
	}
}
