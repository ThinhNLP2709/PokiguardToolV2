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

[DisallowMultipleComponent]
public class RechargeEventHubBadge : MonoBehaviour // TypeDefIndex: 722
{
	// Fields
	public GameObject notifyDot; // 0x20
	private const float MIN_GAP_SEC = 60f; // Metadata: 0x0064C876
	private float _nextAllowed; // 0x28
	private bool _subscribed; // 0x2C
	private bool _running; // 0x2D

	// Nested types
	[CompilerGenerated]
	private sealed class _Fetch_d__12 : IEnumerator<object> // TypeDefIndex: 723
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RechargeEventHubBadge __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Fetch_d__12(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803EE0C0-0x00000001803EE2B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803EE2B0-0x00000001803EE2F0
	}

	// Constructors
	public RechargeEventHubBadge(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void OnEnable(); // 0x00000001803E7860-0x00000001803E7A10
	private void OnDisable(); // 0x00000001803E7790-0x00000001803E7860
	private void Subscribe(); // 0x00000001803E7B70-0x00000001803E7C30
	private void Unsubscribe(); // 0x00000001803E7D80-0x00000001803E7E40
	private void OnProgress(); // 0x00000001803E7A10-0x00000001803E7AB0
	private void OnRecharged(int safiaAdded, int newBalance); // 0x00000001803E7A10-0x00000001803E7AB0
	public void Refresh(bool force = false /* Metadata: 0x0064C875 */); // 0x00000001803E7AB0-0x00000001803E7B70
	[IteratorStateMachine(typeof(_Fetch_d__12))]
	private IEnumerator Fetch(); // 0x00000001803E7720-0x00000001803E7790
	[CompilerGenerated]
	private void _Fetch_b__12_0(RechargeEventStatusData d); // 0x00000001803E7C30-0x00000001803E7D00
	[CompilerGenerated]
	private void _Fetch_b__12_1(string err); // 0x00000001803E7D00-0x00000001803E7D80
}

