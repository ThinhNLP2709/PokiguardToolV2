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
	public class VertexColorCycler : MonoBehaviour // TypeDefIndex: 2103
	{
		// Fields
		private TMP_Text m_TextComponent; // 0x20
	
		// Nested types
		[CompilerGenerated]
		private sealed class _AnimateVertexColors_d__3 : IEnumerator<object> // TypeDefIndex: 2104
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public VertexColorCycler __4__this; // 0x20
			private TMP_TextInfo _textInfo_5__2; // 0x28
			private int _currentCharacter_5__3; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _AnimateVertexColors_d__3(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
			private bool MoveNext(); // 0x0000000180736570-0x0000000180736870
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180736870-0x00000001807368B0
		}
	
		// Constructors
		public VertexColorCycler(); // 0x00000001802EBA70-0x00000001802EBAF0
	
		// Methods
		private void Awake(); // 0x0000000180739730-0x0000000180739780
		private void Start(); // 0x0000000180739780-0x0000000180739800
		[IteratorStateMachine(typeof(_AnimateVertexColors_d__3))]
		private IEnumerator AnimateVertexColors(); // 0x00000001807396C0-0x0000000180739730
	}
}
