/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyRewardGridFit : MonoBehaviour // TypeDefIndex: 1927
	{
		// Fields
		private const float NATURAL = 128f; // Metadata: 0x0064DFED
		private const float MIN_CELL = 22f; // Metadata: 0x0064DFF1
		private const float MAX_CELL = 72f; // Metadata: 0x0064DFF5
		private bool _pending; // 0x20
	
		// Nested types
		[CompilerGenerated]
		private sealed class _ApplyNextFrame_d__8 : IEnumerator<object> // TypeDefIndex: 1928
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyRewardGridFit __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _ApplyNextFrame_d__8(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x00000001806528D0-0x0000000180652940
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180652940-0x0000000180652980
		}
	
		// Constructors
		public PokyRewardGridFit(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void OnEnable(); // 0x000000018064C920-0x000000018064C930
		private void OnDisable(); // 0x000000018064C910-0x000000018064C920
		private void OnTransformChildrenChanged(); // 0x000000018064C920-0x000000018064C930
		private void Schedule(); // 0x000000018064C930-0x000000018064C9C0
		[IteratorStateMachine(typeof(_ApplyNextFrame_d__8))]
		private IEnumerator ApplyNextFrame(); // 0x000000018064C340-0x000000018064C3B0
		private void Apply(); // 0x000000018064C3B0-0x000000018064C910
	}
}
