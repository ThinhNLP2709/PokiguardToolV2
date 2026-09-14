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

public class SlotColumn : MonoBehaviour // TypeDefIndex: 1656
{
	// Fields
	[CompilerGenerated]
	private static SlotEvents OnSpinComplete; // 0x00
	[SerializeField]
	private List<SlotData> slots; // 0x20
	private SlotMachine _parent; // 0x28
	private int _index; // 0x30
	private RectTransform _rt; // 0x38
	private bool _isComplete; // 0x40
	private SlotType? _targetType; // 0x44

	// Events
	public static event SlotEvents OnSpinComplete {
		add; // 0x00000001808AFF20-0x00000001808B0040
		remove; // 0x00000001808B0040-0x00000001808B0160
	}

	// Nested types
	public delegate void SlotEvents(int index); // TypeDefIndex: 1657; 0x00000001808B0EA0-0x00000001808B0EB0

	[CompilerGenerated]
	private sealed class _WaitToEndSpin_d__16 : IEnumerator<object> // TypeDefIndex: 1658
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float duration; // 0x20
		public SlotColumn __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitToEndSpin_d__16(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808B0EB0-0x00000001808B0FF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808B0FF0-0x00000001808B1030
	}

	// Constructors
	public SlotColumn(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void Initialize(SlotMachine parent, int index); // 0x00000001808B0160-0x00000001808B0270
	public void SetRandom(); // 0x00000001808B0270-0x00000001808B0560
	public void StartSpin(); // 0x00000001808B0560-0x00000001808B0770
	public void SetTargetAndStop(SlotType targetType); // 0x00000001808B0770-0x00000001808B07F0
	public void StopSpin(); // 0x00000001808B07F0-0x00000001808B0850
	private void DoStopAnimation(); // 0x00000001808B0850-0x00000001808B0AC0
	[IteratorStateMachine(typeof(_WaitToEndSpin_d__16))]
	private IEnumerator WaitToEndSpin(float duration); // 0x00000001808B0AC0-0x00000001808B0B80
	public void SetVisibility(bool status); // 0x00000001808B0B80-0x00000001808B0C10
	public SlotData GetTopSlot(); // 0x00000001808B0C10-0x00000001808B0C60
	public SlotData GetBottomSlot(); // 0x00000001808B0C60-0x00000001808B0CC0
	[CompilerGenerated]
	private void _StartSpin_b__12_0(); // 0x00000001808B0CC0-0x00000001808B0D40
	[CompilerGenerated]
	private void _DoStopAnimation_b__15_0(); // 0x00000001808B0D40-0x00000001808B0DB0
}

