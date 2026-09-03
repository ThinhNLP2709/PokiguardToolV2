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
	public class VertexColorCycler : MonoBehaviour // TypeDefIndex: 1824
	{
		// Fields
		private TMP_Text m_TextComponent; // 0x20
	
		// Nested types
		[CompilerGenerated]
		private sealed class _AnimateVertexColors_d__3 : IEnumerator<object> // TypeDefIndex: 1825
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public VertexColorCycler __4__this; // 0x20
			private TMP_TextInfo _textInfo_5__2; // 0x28
			private int _currentCharacter_5__3; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _AnimateVertexColors_d__3(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
			private bool MoveNext(); // 0x000000018060FE50-0x0000000180610150
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180610150-0x0000000180610190
		}
	
		// Constructors
		public VertexColorCycler(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void Awake(); // 0x00000001806137D0-0x0000000180613820
		private void Start(); // 0x0000000180613820-0x00000001806138A0
		[IteratorStateMachine(typeof(_AnimateVertexColors_d__3))]
		private IEnumerator AnimateVertexColors(); // 0x0000000180613760-0x00000001806137D0
	}
}
