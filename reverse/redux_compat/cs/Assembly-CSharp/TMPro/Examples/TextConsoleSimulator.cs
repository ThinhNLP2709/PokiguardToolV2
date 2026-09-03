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
	public class TextConsoleSimulator : MonoBehaviour // TypeDefIndex: 1817
	{
		// Fields
		private TMP_Text m_TextComponent; // 0x20
		private bool hasTextChanged; // 0x28
	
		// Nested types
		[CompilerGenerated]
		private sealed class _RevealCharacters_d__7 : IEnumerator<object> // TypeDefIndex: 1818
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public TMP_Text textComponent; // 0x20
			public TextConsoleSimulator __4__this; // 0x28
			private TMP_TextInfo _textInfo_5__2; // 0x30
			private int _totalVisibleCharacters_5__3; // 0x38
			private int _visibleCount_5__4; // 0x3C
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _RevealCharacters_d__7(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
			private bool MoveNext(); // 0x00000001806120D0-0x0000000180612260
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180612260-0x00000001806122A0
		}
	
		[CompilerGenerated]
		private sealed class _RevealWords_d__8 : IEnumerator<object> // TypeDefIndex: 1819
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public TMP_Text textComponent; // 0x20
			private int _totalWordCount_5__2; // 0x28
			private int _totalVisibleCharacters_5__3; // 0x2C
			private int _counter_5__4; // 0x30
			private int _visibleCount_5__5; // 0x34
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _RevealWords_d__8(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x00000001806122A0-0x00000001806124B0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001806124B0-0x00000001806124F0
		}
	
		// Constructors
		public TextConsoleSimulator(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void Awake(); // 0x000000018060A0D0-0x000000018060A130
		private void Start(); // 0x000000018060A3E0-0x000000018060A470
		private void OnEnable(); // 0x000000018060A210-0x000000018060A2E0
		private void OnDisable(); // 0x000000018060A140-0x000000018060A210
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x000000018060A130-0x000000018060A140
		[IteratorStateMachine(typeof(_RevealCharacters_d__7))]
		private IEnumerator RevealCharacters(TMP_Text textComponent); // 0x000000018060A2E0-0x000000018060A370
		[IteratorStateMachine(typeof(_RevealWords_d__8))]
		private IEnumerator RevealWords(TMP_Text textComponent); // 0x000000018060A370-0x000000018060A3E0
	}
}
