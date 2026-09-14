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

public class CardPhotonSync : MonoBehaviour // TypeDefIndex: 5
{
	// Fields
	[CompilerGenerated]
	private static CardPhotonSync _Instance_k__BackingField; // 0x00
	private Board board; // 0x20
	private Active active; // 0x28
	private const float GalaxyRickyChargeSec = 0.15f; // Metadata: 0x005ED220
	private const float HealConvertCastSec = 0.6f; // Metadata: 0x005ED224
	private const float GalaxyScanSec = 1f; // Metadata: 0x005ED228
	private const float GalaxyChargeSec = 0.8f; // Metadata: 0x005ED22C
	private const float QtePrefetchWaitSec = 2f; // Metadata: 0x005ED230

	// Properties
	public static CardPhotonSync Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018028EE30-0x000000018028EE70 0x000000018028EE70-0x000000018028EF10

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 6
	{
		// Fields
		public bool qteReady; // 0x10

		// Constructors
		public __c__DisplayClass19_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _WsRunDotSkill_b__0(bool ok); // 0x0000000180290F20-0x0000000180290F30
	}

	[CompilerGenerated]
	private sealed class _PrepareQteChallenge_d__18 : IEnumerator<object> // TypeDefIndex: 7
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<bool> onDone; // 0x20
		public CardUI cardUI; // 0x28
		private MatchService _msvc_5__2; // 0x30
		private float _waited_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PrepareQteChallenge_d__18(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x0000000180290F30-0x00000001802911B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802911B0-0x00000001802911F0
	}

	[CompilerGenerated]
	private sealed class _WsRunDotSkill_d__19 : IEnumerator<object> // TypeDefIndex: 8
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardPhotonSync __4__this; // 0x20
		public CardUI cardUI; // 0x28
		private __c__DisplayClass19_0 __8__1; // 0x30
		private int _localActor_5__2; // 0x38
		private bool _hidBoard_5__3; // 0x3C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WsRunDotSkill_d__19(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x00000001802911F0-0x0000000180291A00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180291A00-0x0000000180291A40
	}

	[CompilerGenerated]
	private sealed class _WsRunGalaxyRickySkill_d__12 : IEnumerator<object> // TypeDefIndex: 9
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardPhotonSync __4__this; // 0x20
		public CardUI cardUI; // 0x28
		private int _localActor_5__2; // 0x30
		private CardData _data_5__3; // 0x38
		private bool _paused_5__4; // 0x40
		private bool _hidBoard_5__5; // 0x41

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WsRunGalaxyRickySkill_d__12(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x0000000180291AB0-0x0000000180292160
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180292160-0x00000001802921A0
	}

	[CompilerGenerated]
	private sealed class _WsRunGalaxySkill_d__10 : IEnumerator<object> // TypeDefIndex: 10
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardPhotonSync __4__this; // 0x20
		public CardUI cardUI; // 0x28
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
		public _WsRunGalaxySkill_d__10(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x00000001802921A0-0x0000000180292990
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180292990-0x00000001802929D0
	}

	[CompilerGenerated]
	private sealed class _WsRunHealConvertSkill_d__11 : IEnumerator<object> // TypeDefIndex: 11
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardPhotonSync __4__this; // 0x20
		public CardUI cardUI; // 0x28
		private int _localActor_5__2; // 0x30
		private CardData _data_5__3; // 0x38
		private bool _paused_5__4; // 0x40
		private bool _hidBoard_5__5; // 0x41

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WsRunHealConvertSkill_d__11(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x00000001802929D0-0x00000001802931C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802931C0-0x0000000180293200
	}

	// Constructors
	public CardPhotonSync(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x000000018028EF10-0x000000018028F1F0
	private void Start(); // 0x000000018028F1F0-0x000000018028F4D0
	public void RequestUseCard(CardUI cardUI); // 0x000000018028F4D0-0x00000001802901C0
	private string LocalBlockReason(CardUI cardUI); // 0x00000001802901C0-0x00000001802909D0
	[IteratorStateMachine(typeof(_WsRunGalaxySkill_d__10))]
	private IEnumerator WsRunGalaxySkill(CardUI cardUI); // 0x00000001802909D0-0x0000000180290AE0
	[IteratorStateMachine(typeof(_WsRunHealConvertSkill_d__11))]
	private IEnumerator WsRunHealConvertSkill(CardUI cardUI); // 0x0000000180290AE0-0x0000000180290BF0
	[IteratorStateMachine(typeof(_WsRunGalaxyRickySkill_d__12))]
	private IEnumerator WsRunGalaxyRickySkill(CardUI cardUI); // 0x0000000180290BF0-0x0000000180290D00
	[IteratorStateMachine(typeof(_PrepareQteChallenge_d__18))]
	private IEnumerator PrepareQteChallenge(CardUI cardUI, Action<bool> onDone); // 0x0000000180290D00-0x0000000180290E10
	[IteratorStateMachine(typeof(_WsRunDotSkill_d__19))]
	private IEnumerator WsRunDotSkill(CardUI cardUI); // 0x0000000180290E10-0x0000000180290F20
}

