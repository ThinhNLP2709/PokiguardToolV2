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

[DisallowMultipleComponent]
public class RechargeEventHubBadge : MonoBehaviour // TypeDefIndex: 912
{
	// Fields
	public GameObject notifyDot; // 0x20
	private const float MIN_GAP_SEC = 60f; // Metadata: 0x0068BF36
	private float _nextAllowed; // 0x28
	private bool _subscribed; // 0x2C
	private bool _running; // 0x2D
	private Vector3 _dotBaseScale; // 0x30
	private bool _dotBaseCaptured; // 0x3C
	private float _lastPulseAt; // 0x40
	private int _pulseTweenId; // 0x44

	// Nested types
	[CompilerGenerated]
	private sealed class _Fetch_d__18 : IEnumerator<object> // TypeDefIndex: 913
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RechargeEventHubBadge __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Fetch_d__18(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804DE2B0-0x00000001804DE4A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804DE4A0-0x00000001804DE4E0
	}

	// Constructors
	public RechargeEventHubBadge(); // 0x00000001804D5BD0-0x00000001804D5C00

	// Methods
	private void OnEnable(); // 0x00000001804D54F0-0x00000001804D5700
	private void OnDisable(); // 0x00000001804D53B0-0x00000001804D54F0
	private bool TryApplyBadges(HubBadgesData badges); // 0x00000001804D5A30-0x00000001804D5A90
	private void SetDot(bool on); // 0x00000001804D5860-0x00000001804D5970
	private void Subscribe(); // 0x00000001804D5970-0x00000001804D5A30
	private void Unsubscribe(); // 0x00000001804D5B10-0x00000001804D5BD0
	private void OnProgress(); // 0x00000001804D5700-0x00000001804D57A0
	private void OnRecharged(int safiaAdded, int newBalance); // 0x00000001804D5700-0x00000001804D57A0
	public void Refresh(bool force = false /* Metadata: 0x0068BF35 */); // 0x00000001804D57A0-0x00000001804D5860
	[IteratorStateMachine(typeof(_Fetch_d__18))]
	private IEnumerator Fetch(); // 0x00000001804D5340-0x00000001804D53B0
	[CompilerGenerated]
	private void _OnEnable_b__9_0(); // 0x00000001804D5700-0x00000001804D57A0
	[CompilerGenerated]
	private void _Fetch_b__18_0(RechargeEventStatusData d); // 0x00000001804D5A90-0x00000001804D5B00
	[CompilerGenerated]
	private void _Fetch_b__18_1(string err); // 0x00000001804D5B00-0x00000001804D5B10
}

