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

public class SlotColumn : MonoBehaviour // TypeDefIndex: 1654
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
		add; // 0x00000001808AD5D0-0x00000001808AD6F0
		remove; // 0x00000001808AD6F0-0x00000001808AD810
	}

	// Nested types
	public delegate void SlotEvents(int index); // TypeDefIndex: 1655; 0x00000001808AE550-0x00000001808AE560

	[CompilerGenerated]
	private sealed class _WaitToEndSpin_d__16 : IEnumerator<object> // TypeDefIndex: 1656
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001808AE560-0x00000001808AE6A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808AE6A0-0x00000001808AE6E0
	}

	// Constructors
	public SlotColumn(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void Initialize(SlotMachine parent, int index); // 0x00000001808AD810-0x00000001808AD920
	public void SetRandom(); // 0x00000001808AD920-0x00000001808ADC10
	public void StartSpin(); // 0x00000001808ADC10-0x00000001808ADE20
	public void SetTargetAndStop(SlotType targetType); // 0x00000001808ADE20-0x00000001808ADEA0
	public void StopSpin(); // 0x00000001808ADEA0-0x00000001808ADF00
	private void DoStopAnimation(); // 0x00000001808ADF00-0x00000001808AE170
	[IteratorStateMachine(typeof(_WaitToEndSpin_d__16))]
	private IEnumerator WaitToEndSpin(float duration); // 0x00000001808AE170-0x00000001808AE230
	public void SetVisibility(bool status); // 0x00000001808AE230-0x00000001808AE2C0
	public SlotData GetTopSlot(); // 0x00000001808AE2C0-0x00000001808AE310
	public SlotData GetBottomSlot(); // 0x00000001808AE310-0x00000001808AE370
	[CompilerGenerated]
	private void _StartSpin_b__12_0(); // 0x00000001808AE370-0x00000001808AE3F0
	[CompilerGenerated]
	private void _DoStopAnimation_b__15_0(); // 0x00000001808AE3F0-0x00000001808AE460
}

