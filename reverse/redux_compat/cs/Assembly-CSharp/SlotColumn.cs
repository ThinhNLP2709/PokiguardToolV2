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

public class SlotColumn : MonoBehaviour // TypeDefIndex: 1054
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
		add; // 0x00000001804A76B0-0x00000001804A7770
		remove; // 0x00000001804A7770-0x00000001804A7830
	}

	// Nested types
	public delegate void SlotEvents(int index); // TypeDefIndex: 1055; 0x00000001804A78A0-0x00000001804A78B0

	[CompilerGenerated]
	private sealed class _WaitToEndSpin_d__16 : IEnumerator<object> // TypeDefIndex: 1056
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float duration; // 0x20
		public SlotColumn __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitToEndSpin_d__16(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804AB2D0-0x00000001804AB3D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804AB3D0-0x00000001804AB410
	}

	// Constructors
	public SlotColumn(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public void Initialize(SlotMachine parent, int index); // 0x00000001804A70A0-0x00000001804A7120
	public void SetRandom(); // 0x00000001804A7120-0x00000001804A7310
	public void StartSpin(); // 0x00000001804A73C0-0x00000001804A74E0
	public void SetTargetAndStop(SlotType targetType); // 0x00000001804A7310-0x00000001804A7390
	public void StopSpin(); // 0x00000001804A74E0-0x00000001804A7540
	private void DoStopAnimation(); // 0x00000001804A6E60-0x00000001804A7040
	[IteratorStateMachine(typeof(_WaitToEndSpin_d__16))]
	private IEnumerator WaitToEndSpin(float duration); // 0x00000001804A7630-0x00000001804A76B0
	public void SetVisibility(bool status); // 0x00000001804A7390-0x00000001804A73C0
	public SlotData GetTopSlot(); // 0x00000001804A7070-0x00000001804A70A0
	public SlotData GetBottomSlot(); // 0x00000001804A7040-0x00000001804A7070
	[CompilerGenerated]
	private void _StartSpin_b__12_0(); // 0x00000001804A75B0-0x00000001804A7630
	[CompilerGenerated]
	private void _DoStopAnimation_b__15_0(); // 0x00000001804A7540-0x00000001804A75B0
}

