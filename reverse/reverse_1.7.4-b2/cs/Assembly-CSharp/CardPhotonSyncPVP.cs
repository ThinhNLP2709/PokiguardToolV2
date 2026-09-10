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

public class CardPhotonSyncPVP : MonoBehaviour // TypeDefIndex: 169
{
	// Fields
	[CompilerGenerated]
	private static CardPhotonSyncPVP _Instance_k__BackingField; // 0x00
	private BoardPVP board; // 0x20
	private ActivePVP active; // 0x28
	private float _lastFusionSentAt; // 0x30
	private const float QtePrefetchWaitSec = 2f; // Metadata: 0x0068AB5C
	private const float GalaxyScanSec = 1f; // Metadata: 0x0068AB60
	private const float GalaxyChargeSec = 0.8f; // Metadata: 0x0068AB64
	private const float HealConvertCastSec = 0.6f; // Metadata: 0x0068AB68

	// Properties
	public static CardPhotonSyncPVP Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018081A420-0x000000018081A460 0x000000018081A460-0x000000018081A4C0

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass14_0 // TypeDefIndex: 170
	{
		// Fields
		public bool qteReady; // 0x10

		// Constructors
		public __c__DisplayClass14_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _WsRunDotSkillPvp_b__0(bool ok); // 0x0000000180300940-0x0000000180300950
	}

	[CompilerGenerated]
	private sealed class _PrepareQteChallengePvp_d__13 : IEnumerator<object> // TypeDefIndex: 171
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<bool> onDone; // 0x20
		public CardUIPVP cardUI; // 0x28
		private MatchService _msvc_5__2; // 0x30
		private float _waited_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PrepareQteChallengePvp_d__13(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x00000001808278F0-0x0000000180827B10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180827B10-0x0000000180827B50
	}

	[CompilerGenerated]
	private sealed class _WsRunDotSkillPvp_d__14 : IEnumerator<object> // TypeDefIndex: 172
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardPhotonSyncPVP __4__this; // 0x20
		public CardUIPVP cardUI; // 0x28
		private __c__DisplayClass14_0 __8__1; // 0x30
		private int _localActor_5__2; // 0x38
		private bool _hidBoard_5__3; // 0x3C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WsRunDotSkillPvp_d__14(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x0000000180829B80-0x000000018082A070
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018082A070-0x000000018082A0B0
	}

	[CompilerGenerated]
	private sealed class _WsRunGalaxySkillPvp_d__17 : IEnumerator<object> // TypeDefIndex: 173
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardPhotonSyncPVP __4__this; // 0x20
		public CardUIPVP cardUI; // 0x28
		private int _localActor_5__2; // 0x30
		private CardData _data_5__3; // 0x38
		private bool _paused_5__4; // 0x40
		private bool _hidBoard_5__5; // 0x41
		private int _timShown_5__6; // 0x44

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WsRunGalaxySkillPvp_d__17(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x000000018082A0B0-0x000000018082A6B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018082A6B0-0x000000018082A6F0
	}

	[CompilerGenerated]
	private sealed class _WsRunHealConvertSkillPvp_d__19 : IEnumerator<object> // TypeDefIndex: 174
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardPhotonSyncPVP __4__this; // 0x20
		public CardUIPVP cardUI; // 0x28
		private int _localActor_5__2; // 0x30
		private CardData _data_5__3; // 0x38
		private bool _paused_5__4; // 0x40
		private bool _hidBoard_5__5; // 0x41

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WsRunHealConvertSkillPvp_d__19(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x000000018082A6F0-0x000000018082AC30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018082AC30-0x000000018082AC70
	}

	// Constructors
	public CardPhotonSyncPVP(); // 0x000000018081A410-0x000000018081A420

	// Methods
	private void Awake(); // 0x0000000180819330-0x0000000180819460
	private void Start(); // 0x000000018081A130-0x000000018081A260
	private void OnDestroy(); // 0x00000001808197E0-0x00000001808198C0
	private string LocalBlockReasonPvp(CardUIPVP cardUI); // 0x0000000180819460-0x00000001808197E0
	public void RequestUseCard(CardUIPVP cardUI); // 0x0000000180819950-0x000000018081A130
	[IteratorStateMachine(typeof(_PrepareQteChallengePvp_d__13))]
	private IEnumerator PrepareQteChallengePvp(CardUIPVP cardUI, Action<bool> onDone); // 0x00000001808198C0-0x0000000180819950
	[IteratorStateMachine(typeof(_WsRunDotSkillPvp_d__14))]
	private IEnumerator WsRunDotSkillPvp(CardUIPVP cardUI); // 0x000000018081A260-0x000000018081A2F0
	[IteratorStateMachine(typeof(_WsRunGalaxySkillPvp_d__17))]
	private IEnumerator WsRunGalaxySkillPvp(CardUIPVP cardUI); // 0x000000018081A2F0-0x000000018081A380
	[IteratorStateMachine(typeof(_WsRunHealConvertSkillPvp_d__19))]
	private IEnumerator WsRunHealConvertSkillPvp(CardUIPVP cardUI); // 0x000000018081A380-0x000000018081A410
}

