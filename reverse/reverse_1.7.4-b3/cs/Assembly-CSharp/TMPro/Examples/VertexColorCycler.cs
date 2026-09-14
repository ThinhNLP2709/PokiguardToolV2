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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace TMPro.Examples
{
	public class VertexColorCycler : MonoBehaviour // TypeDefIndex: 2501
	{
		// Fields
		private TMP_Text m_TextComponent; // 0x20
	
		// Nested types
		[CompilerGenerated]
		private sealed class _AnimateVertexColors_d__3 : IEnumerator<object> // TypeDefIndex: 2502
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public VertexColorCycler __4__this; // 0x20
			private TMP_TextInfo _textInfo_5__2; // 0x28
			private int _currentCharacter_5__3; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _AnimateVertexColors_d__3(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
			private bool MoveNext(); // 0x0000000180B93160-0x0000000180B935E0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180B935E0-0x0000000180B93620
		}
	
		// Constructors
		public VertexColorCycler(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void Awake(); // 0x0000000180B92F80-0x0000000180B93010
		private void Start(); // 0x0000000180B93010-0x0000000180B930C0
		[IteratorStateMachine(typeof(_AnimateVertexColors_d__3))]
		private IEnumerator AnimateVertexColors(); // 0x0000000180B930C0-0x0000000180B93160
	}
}
