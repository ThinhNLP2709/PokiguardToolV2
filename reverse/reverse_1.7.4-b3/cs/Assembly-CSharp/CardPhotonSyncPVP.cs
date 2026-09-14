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

public class CardPhotonSyncPVP : MonoBehaviour // TypeDefIndex: 168
{
	// Fields
	[CompilerGenerated]
	private static CardPhotonSyncPVP _Instance_k__BackingField; // 0x00
	private BoardPVP board; // 0x20
	private ActivePVP active; // 0x28
	private float _lastFusionSentAt; // 0x30
	private const float QtePrefetchWaitSec = 2f; // Metadata: 0x005ED783
	private const float GalaxyScanSec = 1f; // Metadata: 0x005ED787
	private const float GalaxyChargeSec = 0.8f; // Metadata: 0x005ED78B
	private const float GalaxyRickyChargeSec = 0.15f; // Metadata: 0x005ED78F
	private const float HealConvertCastSec = 0.6f; // Metadata: 0x005ED793

	// Properties
	public static CardPhotonSyncPVP Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180B05170-0x0000000180B051B0 0x0000000180B051B0-0x0000000180B05250

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
		private bool MoveNext(); // 0x0000000180B07280-0x0000000180B07500
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B07500-0x0000000180B07540
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
		private bool MoveNext(); // 0x0000000180B07540-0x0000000180B07D30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B07D30-0x0000000180B07D70
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
		private bool MoveNext(); // 0x0000000180B07D70-0x0000000180B08420
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B08420-0x0000000180B08460
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
		private bool MoveNext(); // 0x0000000180B08460-0x0000000180B08C40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B08C40-0x0000000180B08C80
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
		private bool MoveNext(); // 0x0000000180B08C80-0x0000000180B09470
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B09470-0x0000000180B094B0
	}

	// Constructors
	public CardPhotonSyncPVP(); // 0x0000000180B07230-0x0000000180B07280

	// Methods
	private void Awake(); // 0x0000000180B05250-0x0000000180B054B0
	private void Start(); // 0x0000000180B054B0-0x0000000180B05790
	private void OnDestroy(); // 0x0000000180B05790-0x0000000180B05920
	private string LocalBlockReasonPvp(CardUIPVP cardUI); // 0x0000000180B05920-0x0000000180B06030
	public void RequestUseCard(CardUIPVP cardUI); // 0x0000000180B06030-0x0000000180B06CE0
	[IteratorStateMachine(typeof(_PrepareQteChallengePvp_d__13))]
	private IEnumerator PrepareQteChallengePvp(CardUIPVP cardUI, Action<bool> onDone); // 0x0000000180B06CE0-0x0000000180B06DF0
	[IteratorStateMachine(typeof(_WsRunDotSkillPvp_d__14))]
	private IEnumerator WsRunDotSkillPvp(CardUIPVP cardUI); // 0x0000000180B06DF0-0x0000000180B06F00
	[IteratorStateMachine(typeof(_WsRunGalaxySkillPvp_d__17))]
	private IEnumerator WsRunGalaxySkillPvp(CardUIPVP cardUI); // 0x0000000180B06F00-0x0000000180B07010
	[IteratorStateMachine(typeof(_WsRunGalaxyRickySkillPvp_d__19))]
	private IEnumerator WsRunGalaxyRickySkillPvp(CardUIPVP cardUI); // 0x0000000180B07010-0x0000000180B07120
	[IteratorStateMachine(typeof(_WsRunHealConvertSkillPvp_d__21))]
	private IEnumerator WsRunHealConvertSkillPvp(CardUIPVP cardUI); // 0x0000000180B07120-0x0000000180B07230
}

