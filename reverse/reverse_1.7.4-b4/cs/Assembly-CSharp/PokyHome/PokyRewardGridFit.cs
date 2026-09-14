/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyRewardGridFit : MonoBehaviour // TypeDefIndex: 2696
	{
		// Fields
		private const float NATURAL = 128f; // Metadata: 0x005F28EB
		private const float MIN_CELL = 22f; // Metadata: 0x005F28EF
		private const float MAX_CELL = 72f; // Metadata: 0x005F28F3
		private bool _pending; // 0x20
	
		// Nested types
		[CompilerGenerated]
		private sealed class _ApplyNextFrame_d__8 : IEnumerator<object> // TypeDefIndex: 2697
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
			void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
			private bool MoveNext(); // 0x0000000180C55050-0x0000000180C55100
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C55100-0x0000000180C55140
		}
	
		// Constructors
		public PokyRewardGridFit(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void OnEnable(); // 0x0000000180C54080-0x0000000180C54090
		private void OnDisable(); // 0x0000000180C54090-0x0000000180C540A0
		private void OnTransformChildrenChanged(); // 0x0000000180C54080-0x0000000180C54090
		private void Schedule(); // 0x0000000180C540A0-0x0000000180C541C0
		[IteratorStateMachine(typeof(_ApplyNextFrame_d__8))]
		private IEnumerator ApplyNextFrame(); // 0x0000000180C541C0-0x0000000180C54260
		private void Apply(); // 0x0000000180C54260-0x0000000180C55050
	}
}
