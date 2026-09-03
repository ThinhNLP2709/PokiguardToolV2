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

public class CardPhotonSync : MonoBehaviour // TypeDefIndex: 5
{
	// Fields
	[CompilerGenerated]
	private static CardPhotonSync _Instance_k__BackingField; // 0x00
	private Board board; // 0x20
	private Active active; // 0x28
	private const float HealConvertCastSec = 0.6f; // Metadata: 0x0064BEF8
	private const float GalaxyScanSec = 1f; // Metadata: 0x0064BEFC
	private const float GalaxyChargeSec = 0.8f; // Metadata: 0x0064BF00

	// Properties
	public static CardPhotonSync Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802E9790-0x00000001802E97D0 0x00000001802E97D0-0x00000001802E9830

	// Nested types
	[CompilerGenerated]
	private sealed class _WsRunDotSkill_d__15 : IEnumerator<object> // TypeDefIndex: 6
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardPhotonSync __4__this; // 0x20
		public CardUI cardUI; // 0x28
		private int _localActor_5__2; // 0x30
		private bool _hidBoard_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WsRunDotSkill_d__15(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001802FB8D0-0x00000001802FBBC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802FBBC0-0x00000001802FBC00
	}

	[CompilerGenerated]
	private sealed class _WsRunGalaxySkill_d__10 : IEnumerator<object> // TypeDefIndex: 7
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WsRunGalaxySkill_d__10(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x00000001802FBC00-0x00000001802FC1F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802FC1F0-0x00000001802FC230
	}

	[CompilerGenerated]
	private sealed class _WsRunHealConvertSkill_d__11 : IEnumerator<object> // TypeDefIndex: 8
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WsRunHealConvertSkill_d__11(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x00000001802FC260-0x00000001802FC790
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802FC790-0x00000001802FCB40
	}

	// Constructors
	public CardPhotonSync(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x00000001802E8970-0x00000001802E8AA0
	private void Start(); // 0x00000001802E94B0-0x00000001802E95E0
	public void RequestUseCard(CardUI cardUI); // 0x00000001802E8DB0-0x00000001802E94B0
	private string LocalBlockReason(CardUI cardUI); // 0x00000001802E8AA0-0x00000001802E8DB0
	[IteratorStateMachine(typeof(_WsRunGalaxySkill_d__10))]
	private IEnumerator WsRunGalaxySkill(CardUI cardUI); // 0x00000001802E9670-0x00000001802E9700
	[IteratorStateMachine(typeof(_WsRunHealConvertSkill_d__11))]
	private IEnumerator WsRunHealConvertSkill(CardUI cardUI); // 0x00000001802E9700-0x00000001802E9790
	[IteratorStateMachine(typeof(_WsRunDotSkill_d__15))]
	private IEnumerator WsRunDotSkill(CardUI cardUI); // 0x00000001802E95E0-0x00000001802E9670
}

