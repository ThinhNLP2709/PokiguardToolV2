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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace TMPro.Examples
{
	public class TextConsoleSimulator : MonoBehaviour // TypeDefIndex: 2501
	{
		// Fields
		private TMP_Text m_TextComponent; // 0x20
		private bool hasTextChanged; // 0x28
	
		// Nested types
		[CompilerGenerated]
		private sealed class _RevealCharacters_d__7 : IEnumerator<object> // TypeDefIndex: 2502
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _RevealCharacters_d__7(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
			private bool MoveNext(); // 0x0000000180B9CA90-0x0000000180B9CD20
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180B9CD20-0x0000000180B9CD60
		}
	
		[CompilerGenerated]
		private sealed class _RevealWords_d__8 : IEnumerator<object> // TypeDefIndex: 2503
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _RevealWords_d__8(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
			private bool MoveNext(); // 0x0000000180B9CD60-0x0000000180B9D000
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180B9D000-0x0000000180B9D040
		}
	
		// Constructors
		public TextConsoleSimulator(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void Awake(); // 0x0000000180B9C530-0x0000000180B9C5D0
		private void Start(); // 0x0000000180B9C5D0-0x0000000180B9C6F0
		private void OnEnable(); // 0x0000000180B9C6F0-0x0000000180B9C7E0
		private void OnDisable(); // 0x0000000180B9C7E0-0x0000000180B9C8D0
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x0000000180B9C8D0-0x0000000180B9C8E0
		[IteratorStateMachine(typeof(_RevealCharacters_d__7))]
		private IEnumerator RevealCharacters(TMP_Text textComponent); // 0x0000000180B9C8E0-0x0000000180B9C9F0
		[IteratorStateMachine(typeof(_RevealWords_d__8))]
		private IEnumerator RevealWords(TMP_Text textComponent); // 0x0000000180B9C9F0-0x0000000180B9CA90
	}
}
