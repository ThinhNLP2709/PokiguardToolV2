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

public class SlotColumn : MonoBehaviour // TypeDefIndex: 1253
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
		add; // 0x00000001805A1D60-0x00000001805A1E20
		remove; // 0x00000001805A1E20-0x00000001805A1EE0
	}

	// Nested types
	public delegate void SlotEvents(int index); // TypeDefIndex: 1254; 0x00000001805A1F40-0x00000001805A1F50

	[CompilerGenerated]
	private sealed class _WaitToEndSpin_d__16 : IEnumerator<object> // TypeDefIndex: 1255
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float duration; // 0x20
		public SlotColumn __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitToEndSpin_d__16(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805A6700-0x00000001805A6800
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A6800-0x00000001805A6840
	}

	// Constructors
	public SlotColumn(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public void Initialize(SlotMachine parent, int index); // 0x00000001805A1750-0x00000001805A17D0
	public void SetRandom(); // 0x00000001805A17D0-0x00000001805A19C0
	public void StartSpin(); // 0x00000001805A1A70-0x00000001805A1B90
	public void SetTargetAndStop(SlotType targetType); // 0x00000001805A19C0-0x00000001805A1A40
	public void StopSpin(); // 0x00000001805A1B90-0x00000001805A1BF0
	private void DoStopAnimation(); // 0x00000001805A1510-0x00000001805A16F0
	[IteratorStateMachine(typeof(_WaitToEndSpin_d__16))]
	private IEnumerator WaitToEndSpin(float duration); // 0x00000001805A1CE0-0x00000001805A1D60
	public void SetVisibility(bool status); // 0x00000001805A1A40-0x00000001805A1A70
	public SlotData GetTopSlot(); // 0x00000001805A1720-0x00000001805A1750
	public SlotData GetBottomSlot(); // 0x00000001805A16F0-0x00000001805A1720
	[CompilerGenerated]
	private void _StartSpin_b__12_0(); // 0x00000001805A1C60-0x00000001805A1CE0
	[CompilerGenerated]
	private void _DoStopAnimation_b__15_0(); // 0x00000001805A1BF0-0x00000001805A1C60
}

