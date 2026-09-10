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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace TMPro.Examples
{
	public class TextConsoleSimulator : MonoBehaviour // TypeDefIndex: 2096
	{
		// Fields
		private TMP_Text m_TextComponent; // 0x20
		private bool hasTextChanged; // 0x28
	
		// Nested types
		[CompilerGenerated]
		private sealed class _RevealCharacters_d__7 : IEnumerator<object> // TypeDefIndex: 2097
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _RevealCharacters_d__7(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
			private bool MoveNext(); // 0x0000000180737450-0x00000001807375E0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807375E0-0x0000000180737620
		}
	
		[CompilerGenerated]
		private sealed class _RevealWords_d__8 : IEnumerator<object> // TypeDefIndex: 2098
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _RevealWords_d__8(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x0000000180737620-0x0000000180737830
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180737830-0x0000000180737870
		}
	
		// Constructors
		public TextConsoleSimulator(); // 0x00000001802EBA70-0x00000001802EBAF0
	
		// Methods
		private void Awake(); // 0x0000000180730630-0x0000000180730690
		private void Start(); // 0x0000000180730940-0x00000001807309D0
		private void OnEnable(); // 0x0000000180730770-0x0000000180730840
		private void OnDisable(); // 0x00000001807306A0-0x0000000180730770
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x0000000180730690-0x00000001807306A0
		[IteratorStateMachine(typeof(_RevealCharacters_d__7))]
		private IEnumerator RevealCharacters(TMP_Text textComponent); // 0x0000000180730840-0x00000001807308D0
		[IteratorStateMachine(typeof(_RevealWords_d__8))]
		private IEnumerator RevealWords(TMP_Text textComponent); // 0x00000001807308D0-0x0000000180730940
	}
}
