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

[DisallowMultipleComponent]
public class GiftToastQueue : MonoBehaviour // TypeDefIndex: 1394
{
	// Fields
	public const float STEP = 0.45f; // Metadata: 0x005F0E22
	private const int SLOTS = 3; // Metadata: 0x005F0E26
	private const float SLOT_H = 76f; // Metadata: 0x005F0E27
	private const float SLOT_WAIT_CAP = 3f; // Metadata: 0x005F0E2B
	private const int MAX_LINES = 10; // Metadata: 0x005F0E2F
	private static GiftToastQueue _instance; // 0x00
	private readonly Queue<GameNotice.GiftLine> _queue; // 0x20
	private readonly PokyGiftToastView[] _slotView; // 0x28
	private float _hold; // 0x30
	private int _nextSlot; // 0x34
	private bool _running; // 0x38

	// Nested types
	[CompilerGenerated]
	private sealed class _CoRun_d__13 : IEnumerator<object> // TypeDefIndex: 1395
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180788C80-0x0000000180789200
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180789200-0x0000000180789240
	}

	// Constructors
	public GiftToastQueue(); // 0x0000000180788A70-0x0000000180788C80

	// Methods
	internal static void Enqueue(List<GameNotice.GiftLine> lines, float hold); // 0x00000001807880B0-0x00000001807882A0
	private void Push(List<GameNotice.GiftLine> lines, float hold); // 0x00000001807882A0-0x00000001807886A0
	[IteratorStateMachine(typeof(_CoRun_d__13))]
	private IEnumerator CoRun(); // 0x00000001807886A0-0x0000000180788740
	private int FreeSlot(); // 0x0000000180788740-0x00000001807888B0
	private void OnDestroy(); // 0x00000001807888B0-0x0000000180788A70
}

