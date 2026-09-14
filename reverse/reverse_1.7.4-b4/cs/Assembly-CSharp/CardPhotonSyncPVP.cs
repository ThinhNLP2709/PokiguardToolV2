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

public class CardPhotonSyncPVP : MonoBehaviour // TypeDefIndex: 168
{
	// Fields
	[CompilerGenerated]
	private static CardPhotonSyncPVP _Instance_k__BackingField; // 0x00
	private BoardPVP board; // 0x20
	private ActivePVP active; // 0x28
	private float _lastFusionSentAt; // 0x30
	private const float QtePrefetchWaitSec = 2f; // Metadata: 0x005EEB53
	private const float GalaxyScanSec = 1f; // Metadata: 0x005EEB57
	private const float GalaxyChargeSec = 0.8f; // Metadata: 0x005EEB5B
	private const float GalaxyRickyChargeSec = 0.15f; // Metadata: 0x005EEB5F
	private const float HealConvertCastSec = 0.6f; // Metadata: 0x005EEB63

	// Properties
	public static CardPhotonSyncPVP Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180B00F30-0x0000000180B00F70 0x0000000180B00F70-0x0000000180B01010

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass14_0 // TypeDefIndex: 169
	{
		// Fields
		public bool qteReady; // 0x10

		// Constructors
		public __c__DisplayClass14_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _WsRunDotSkillPvp_b__0(bool ok); // 0x0000000180290F20-0x0000000180290F30
	}

	[CompilerGenerated]
	private sealed class _PrepareQteChallengePvp_d__13 : IEnumerator<object> // TypeDefIndex: 170
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<bool> onDone; // 0x20
		public CardUIPVP cardUI; // 0x28
		private MatchService _msvc_5__2; // 0x30
		private float _waited_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PrepareQteChallengePvp_d__13(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x0000000180B03040-0x0000000180B032C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B032C0-0x0000000180B03300
	}

	[CompilerGenerated]
	private sealed class _WsRunDotSkillPvp_d__14 : IEnumerator<object> // TypeDefIndex: 171
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WsRunDotSkillPvp_d__14(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x0000000180B03300-0x0000000180B03AF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B03AF0-0x0000000180B03B30
	}

	[CompilerGenerated]
	private sealed class _WsRunGalaxyRickySkillPvp_d__19 : IEnumerator<object> // TypeDefIndex: 172
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WsRunGalaxyRickySkillPvp_d__19(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x0000000180B03B30-0x0000000180B041E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B041E0-0x0000000180B04220
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WsRunGalaxySkillPvp_d__17(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x0000000180B04220-0x0000000180B04A00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B04A00-0x0000000180B04A40
	}

	[CompilerGenerated]
	private sealed class _WsRunHealConvertSkillPvp_d__21 : IEnumerator<object> // TypeDefIndex: 174
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WsRunHealConvertSkillPvp_d__21(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x0000000180B04A40-0x0000000180B05230
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B05230-0x0000000180B05270
	}

	// Constructors
	public CardPhotonSyncPVP(); // 0x0000000180B02FF0-0x0000000180B03040

	// Methods
	private void Awake(); // 0x0000000180B01010-0x0000000180B01270
	private void Start(); // 0x0000000180B01270-0x0000000180B01550
	private void OnDestroy(); // 0x0000000180B01550-0x0000000180B016E0
	private string LocalBlockReasonPvp(CardUIPVP cardUI); // 0x0000000180B016E0-0x0000000180B01DF0
	public void RequestUseCard(CardUIPVP cardUI); // 0x0000000180B01DF0-0x0000000180B02AA0
	[IteratorStateMachine(typeof(_PrepareQteChallengePvp_d__13))]
	private IEnumerator PrepareQteChallengePvp(CardUIPVP cardUI, Action<bool> onDone); // 0x0000000180B02AA0-0x0000000180B02BB0
	[IteratorStateMachine(typeof(_WsRunDotSkillPvp_d__14))]
	private IEnumerator WsRunDotSkillPvp(CardUIPVP cardUI); // 0x0000000180B02BB0-0x0000000180B02CC0
	[IteratorStateMachine(typeof(_WsRunGalaxySkillPvp_d__17))]
	private IEnumerator WsRunGalaxySkillPvp(CardUIPVP cardUI); // 0x0000000180B02CC0-0x0000000180B02DD0
	[IteratorStateMachine(typeof(_WsRunGalaxyRickySkillPvp_d__19))]
	private IEnumerator WsRunGalaxyRickySkillPvp(CardUIPVP cardUI); // 0x0000000180B02DD0-0x0000000180B02EE0
	[IteratorStateMachine(typeof(_WsRunHealConvertSkillPvp_d__21))]
	private IEnumerator WsRunHealConvertSkillPvp(CardUIPVP cardUI); // 0x0000000180B02EE0-0x0000000180B02FF0
}

