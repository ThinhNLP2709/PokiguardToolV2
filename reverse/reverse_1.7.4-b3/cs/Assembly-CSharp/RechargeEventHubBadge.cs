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
public class RechargeEventHubBadge : MonoBehaviour // TypeDefIndex: 1171
{
	// Fields
	public GameObject notifyDot; // 0x20
	private const float MIN_GAP_SEC = 60f; // Metadata: 0x005EF522
	private float _nextAllowed; // 0x28
	private bool _subscribed; // 0x2C
	private bool _running; // 0x2D
	private Vector3 _dotBaseScale; // 0x30
	private bool _dotBaseCaptured; // 0x3C
	private float _lastPulseAt; // 0x40
	private int _pulseTweenId; // 0x44

	// Nested types
	[CompilerGenerated]
	private sealed class _Fetch_d__18 : IEnumerator<object> // TypeDefIndex: 1172
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RechargeEventHubBadge __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Fetch_d__18(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001806BFD40-0x00000001806BFFE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806BFFE0-0x00000001806C0020
	}

	// Constructors
	public RechargeEventHubBadge(); // 0x00000001806BFC50-0x00000001806BFCC0

	// Methods
	private void OnEnable(); // 0x00000001806BF0A0-0x00000001806BF430
	private void OnDisable(); // 0x00000001806BF430-0x00000001806BF590
	private bool TryApplyBadges(HubBadgesData badges); // 0x00000001806BF590-0x00000001806BF630
	private void SetDot(bool on); // 0x00000001806BF630-0x00000001806BF880
	private void Subscribe(); // 0x00000001806BF880-0x00000001806BF960
	private void Unsubscribe(); // 0x00000001806BF960-0x00000001806BFA40
	private void OnProgress(); // 0x00000001806BFA40-0x00000001806BFA50
	private void OnRecharged(int safiaAdded, int newBalance); // 0x00000001806BFA40-0x00000001806BFA50
	public void Refresh(bool force = false /* Metadata: 0x005EF521 */); // 0x00000001806BFA50-0x00000001806BFBB0
	[IteratorStateMachine(typeof(_Fetch_d__18))]
	private IEnumerator Fetch(); // 0x00000001806BFBB0-0x00000001806BFC50
	[CompilerGenerated]
	private void _OnEnable_b__9_0(); // 0x00000001806BFA40-0x00000001806BFA50
	[CompilerGenerated]
	private void _Fetch_b__18_0(RechargeEventStatusData d); // 0x00000001806BFCC0-0x00000001806BFD30
	[CompilerGenerated]
	private void _Fetch_b__18_1(string err); // 0x00000001806BFD30-0x00000001806BFD40
}

