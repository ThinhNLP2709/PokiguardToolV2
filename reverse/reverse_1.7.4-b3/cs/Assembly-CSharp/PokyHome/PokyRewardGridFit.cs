/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyRewardGridFit : MonoBehaviour // TypeDefIndex: 2689
	{
		// Fields
		private const float NATURAL = 128f; // Metadata: 0x005F14D4
		private const float MIN_CELL = 22f; // Metadata: 0x005F14D8
		private const float MAX_CELL = 72f; // Metadata: 0x005F14DC
		private bool _pending; // 0x20
	
		// Nested types
		[CompilerGenerated]
		private sealed class _ApplyNextFrame_d__8 : IEnumerator<object> // TypeDefIndex: 2690
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyRewardGridFit __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _ApplyNextFrame_d__8(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180C47A90-0x0000000180C47B40
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C47B40-0x0000000180C47B80
		}
	
		// Constructors
		public PokyRewardGridFit(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void OnEnable(); // 0x0000000180C46AC0-0x0000000180C46AD0
		private void OnDisable(); // 0x0000000180C46AD0-0x0000000180C46AE0
		private void OnTransformChildrenChanged(); // 0x0000000180C46AC0-0x0000000180C46AD0
		private void Schedule(); // 0x0000000180C46AE0-0x0000000180C46C00
		[IteratorStateMachine(typeof(_ApplyNextFrame_d__8))]
		private IEnumerator ApplyNextFrame(); // 0x0000000180C46C00-0x0000000180C46CA0
		private void Apply(); // 0x0000000180C46CA0-0x0000000180C47A90
	}
}
