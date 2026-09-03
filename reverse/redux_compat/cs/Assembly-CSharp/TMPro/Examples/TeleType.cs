/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace TMPro.Examples
{
	public class TeleType : MonoBehaviour // TypeDefIndex: 1815
	{
		// Fields
		private string label01; // 0x20
		private string label02; // 0x28
		private TMP_Text m_textMeshPro; // 0x30
	
		// Nested types
		[CompilerGenerated]
		private sealed class _Start_d__4 : IEnumerator<object> // TypeDefIndex: 1816
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public TeleType __4__this; // 0x20
			private int _totalVisibleCharacters_5__2; // 0x28
			private int _counter_5__3; // 0x2C
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _Start_d__4(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x00000001806124F0-0x00000001806127B0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001806127B0-0x00000001806127F0
		}
	
		// Constructors
		public TeleType(); // 0x000000018060A050-0x000000018060A0D0
	
		// Methods
		private void Awake(); // 0x0000000180609F40-0x0000000180609FE0
		[IteratorStateMachine(typeof(_Start_d__4))]
		private IEnumerator Start(); // 0x0000000180609FE0-0x000000018060A050
	}
}
