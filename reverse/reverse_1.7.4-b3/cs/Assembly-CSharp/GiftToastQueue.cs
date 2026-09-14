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

[DisallowMultipleComponent]
public class GiftToastQueue : MonoBehaviour // TypeDefIndex: 1392
{
	// Fields
	public const float STEP = 0.45f; // Metadata: 0x005EFA55
	private const int SLOTS = 3; // Metadata: 0x005EFA59
	private const float SLOT_H = 76f; // Metadata: 0x005EFA5A
	private const float SLOT_WAIT_CAP = 3f; // Metadata: 0x005EFA5E
	private const int MAX_LINES = 10; // Metadata: 0x005EFA62
	private static GiftToastQueue _instance; // 0x00
	private readonly Queue<GameNotice.GiftLine> _queue; // 0x20
	private readonly PokyGiftToastView[] _slotView; // 0x28
	private float _hold; // 0x30
	private int _nextSlot; // 0x34
	private bool _running; // 0x38

	// Nested types
	[CompilerGenerated]
	private sealed class _CoRun_d__13 : IEnumerator<object> // TypeDefIndex: 1393
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GiftToastQueue __4__this; // 0x20
		private float _waitedFrom_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CoRun_d__13(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180786D30-0x00000001807872B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807872B0-0x00000001807872F0
	}

	// Constructors
	public GiftToastQueue(); // 0x0000000180786B20-0x0000000180786D30

	// Methods
	internal static void Enqueue(List<GameNotice.GiftLine> lines, float hold); // 0x0000000180786160-0x0000000180786350
	private void Push(List<GameNotice.GiftLine> lines, float hold); // 0x0000000180786350-0x0000000180786750
	[IteratorStateMachine(typeof(_CoRun_d__13))]
	private IEnumerator CoRun(); // 0x0000000180786750-0x00000001807867F0
	private int FreeSlot(); // 0x00000001807867F0-0x0000000180786960
	private void OnDestroy(); // 0x0000000180786960-0x0000000180786B20
}

