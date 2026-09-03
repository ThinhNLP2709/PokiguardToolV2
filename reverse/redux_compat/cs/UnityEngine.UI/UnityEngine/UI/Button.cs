/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[AddComponentMenu("UI (Canvas)/Button", 30)]
	[UGUIHelpURL("Button")]
	public class Button : Selectable, IPointerClickHandler, ISubmitHandler // TypeDefIndex: 13010
	{
		// Fields
		[FormerlySerializedAs("onClick")]
		[SerializeField]
		private ButtonClickedEvent m_OnClick; // 0x100
	
		// Properties
		public ButtonClickedEvent onClick { get; set; } // 0x00000001816A28C0-0x00000001816A28D0 0x00000001816A2D50-0x00000001816A2D70
	
		// Nested types
		[Serializable]
		public class ButtonClickedEvent : UnityEvent // TypeDefIndex: 13011
		{
			// Constructors
			public ButtonClickedEvent(); // 0x0000000180E83F10-0x0000000180E83F20
		}
	
		[CompilerGenerated]
		private sealed class _OnFinishSubmit_d__9 : IEnumerator<object> // TypeDefIndex: 13012
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public Button __4__this; // 0x20
			private float _fadeTime_5__2; // 0x28
			private float _elapsedTime_5__3; // 0x2C
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _OnFinishSubmit_d__9(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000182379F30-0x000000018237A060
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018237A060-0x000000018237A0A0
		}
	
		// Constructors
		protected Button(); // 0x000000018235FAC0-0x000000018235FB50
	
		// Methods
		private void Press(); // 0x000000018235FA30-0x000000018235FAC0
		public virtual void OnPointerClick(PointerEventData eventData); // 0x000000018235F920-0x000000018235F950
		public virtual void OnSubmit(BaseEventData eventData); // 0x000000018235F950-0x000000018235FA30
		[IteratorStateMachine(typeof(_OnFinishSubmit_d__9))]
		private IEnumerator OnFinishSubmit(); // 0x000000018235F8B0-0x000000018235F920
	}
}
