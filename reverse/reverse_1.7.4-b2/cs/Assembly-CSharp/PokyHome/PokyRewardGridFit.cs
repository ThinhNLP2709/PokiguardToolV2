/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyRewardGridFit : MonoBehaviour // TypeDefIndex: 2253
	{
		// Fields
		private const float NATURAL = 128f; // Metadata: 0x0068E46D
		private const float MIN_CELL = 22f; // Metadata: 0x0068E471
		private const float MAX_CELL = 72f; // Metadata: 0x0068E475
		private bool _pending; // 0x20
	
		// Nested types
		[CompilerGenerated]
		private sealed class _ApplyNextFrame_d__8 : IEnumerator<object> // TypeDefIndex: 2254
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyRewardGridFit __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _ApplyNextFrame_d__8(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x00000001807A9190-0x00000001807A9200
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807A9200-0x00000001807A9240
		}
	
		// Constructors
		public PokyRewardGridFit(); // 0x00000001802EBA70-0x00000001802EBAF0
	
		// Methods
		private void OnEnable(); // 0x000000018079C4E0-0x000000018079C4F0
		private void OnDisable(); // 0x000000018079C4D0-0x000000018079C4E0
		private void OnTransformChildrenChanged(); // 0x000000018079C4E0-0x000000018079C4F0
		private void Schedule(); // 0x000000018079C4F0-0x000000018079C580
		[IteratorStateMachine(typeof(_ApplyNextFrame_d__8))]
		private IEnumerator ApplyNextFrame(); // 0x000000018079BF00-0x000000018079BF70
		private void Apply(); // 0x000000018079BF70-0x000000018079C4D0
	}
}
