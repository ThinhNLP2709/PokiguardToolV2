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
	public class TeleType : MonoBehaviour // TypeDefIndex: 2499
	{
		// Fields
		private string label01; // 0x20
		private string label02; // 0x28
		private TMP_Text m_textMeshPro; // 0x30
	
		// Nested types
		[CompilerGenerated]
		private sealed class _Start_d__4 : IEnumerator<object> // TypeDefIndex: 2500
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public TeleType __4__this; // 0x20
			private int _totalVisibleCharacters_5__2; // 0x28
			private int _counter_5__3; // 0x2C
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _Start_d__4(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
			private bool MoveNext(); // 0x0000000180B9C220-0x0000000180B9C4F0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180B9C4F0-0x0000000180B9C530
		}
	
		// Constructors
		public TeleType(); // 0x0000000180B9C0E0-0x0000000180B9C220
	
		// Methods
		private void Awake(); // 0x0000000180B9BEE0-0x0000000180B9C040
		[IteratorStateMachine(typeof(_Start_d__4))]
		private IEnumerator Start(); // 0x0000000180B9C040-0x0000000180B9C0E0
	}
}
