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

public class CardPhotonSync : MonoBehaviour // TypeDefIndex: 5
{
	// Fields
	[CompilerGenerated]
	private static CardPhotonSync _Instance_k__BackingField; // 0x00
	private Board board; // 0x20
	private Active active; // 0x28
	private const float HealConvertCastSec = 0.6f; // Metadata: 0x0068A750
	private const float GalaxyScanSec = 1f; // Metadata: 0x0068A754
	private const float GalaxyChargeSec = 0.8f; // Metadata: 0x0068A758
	private const float QtePrefetchWaitSec = 2f; // Metadata: 0x0068A75C

	// Properties
	public static CardPhotonSync Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802ED8B0-0x00000001802ED8F0 0x00000001802ED8F0-0x00000001802ED950

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass17_0 // TypeDefIndex: 6
	{
		// Fields
		public bool qteReady; // 0x10

		// Constructors
		public __c__DisplayClass17_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _WsRunDotSkill_b__0(bool ok); // 0x0000000180300940-0x0000000180300950
	}

	[CompilerGenerated]
	private sealed class _PrepareQteChallenge_d__16 : IEnumerator<object> // TypeDefIndex: 7
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<bool> onDone; // 0x20
		public CardUI cardUI; // 0x28
		private MatchService _msvc_5__2; // 0x30
		private float _waited_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PrepareQteChallenge_d__16(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x0000000180300560-0x0000000180300780
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180300780-0x00000001803007C0
	}

	[CompilerGenerated]
	private sealed class _WsRunDotSkill_d__17 : IEnumerator<object> // TypeDefIndex: 8
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardPhotonSync __4__this; // 0x20
		public CardUI cardUI; // 0x28
		private __c__DisplayClass17_0 __8__1; // 0x30
		private int _localActor_5__2; // 0x38
		private bool _hidBoard_5__3; // 0x3C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WsRunDotSkill_d__17(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x0000000180301430-0x0000000180301930
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180301930-0x0000000180301970
	}

	[CompilerGenerated]
	private sealed class _WsRunGalaxySkill_d__10 : IEnumerator<object> // TypeDefIndex: 9
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WsRunGalaxySkill_d__10(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x0000000180301970-0x0000000180301F70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180301F70-0x0000000180301FB0
	}

	[CompilerGenerated]
	private sealed class _WsRunHealConvertSkill_d__11 : IEnumerator<object> // TypeDefIndex: 10
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WsRunHealConvertSkill_d__11(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x0000000180301FE0-0x0000000180302520
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180302520-0x00000001803025B0
	}

	// Constructors
	public CardPhotonSync(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x00000001802EC910-0x00000001802ECA40
	private void Start(); // 0x00000001802ED5D0-0x00000001802ED700
	public void RequestUseCard(CardUI cardUI); // 0x00000001802ECEB0-0x00000001802ED5D0
	private string LocalBlockReason(CardUI cardUI); // 0x00000001802ECA40-0x00000001802ECE20
	[IteratorStateMachine(typeof(_WsRunGalaxySkill_d__10))]
	private IEnumerator WsRunGalaxySkill(CardUI cardUI); // 0x00000001802ED790-0x00000001802ED820
	[IteratorStateMachine(typeof(_WsRunHealConvertSkill_d__11))]
	private IEnumerator WsRunHealConvertSkill(CardUI cardUI); // 0x00000001802ED820-0x00000001802ED8B0
	[IteratorStateMachine(typeof(_PrepareQteChallenge_d__16))]
	private IEnumerator PrepareQteChallenge(CardUI cardUI, Action<bool> onDone); // 0x00000001802ECE20-0x00000001802ECEB0
	[IteratorStateMachine(typeof(_WsRunDotSkill_d__17))]
	private IEnumerator WsRunDotSkill(CardUI cardUI); // 0x00000001802ED700-0x00000001802ED790
}

