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

public class CardPhotonSyncPVP : MonoBehaviour // TypeDefIndex: 157
{
	// Fields
	[CompilerGenerated]
	private static CardPhotonSyncPVP _Instance_k__BackingField; // 0x00
	private BoardPVP board; // 0x20
	private ActivePVP active; // 0x28
	private float _lastFusionSentAt; // 0x30
	private const float GalaxyScanSec = 1f; // Metadata: 0x0064C022
	private const float GalaxyChargeSec = 0.8f; // Metadata: 0x0064C026
	private const float HealConvertCastSec = 0.6f; // Metadata: 0x0064C02A

	// Properties
	public static CardPhotonSyncPVP Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180615D90-0x0000000180615DD0 0x0000000180615DD0-0x0000000180615E30

	// Nested types
	[CompilerGenerated]
	private sealed class _WsRunDotSkillPvp_d__12 : IEnumerator<object> // TypeDefIndex: 158
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardPhotonSyncPVP __4__this; // 0x20
		public CardUIPVP cardUI; // 0x28
		private int _localActor_5__2; // 0x30
		private bool _hidBoard_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WsRunDotSkillPvp_d__12(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806282A0-0x00000001806285C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806285C0-0x0000000180628600
	}

	[CompilerGenerated]
	private sealed class _WsRunGalaxySkillPvp_d__15 : IEnumerator<object> // TypeDefIndex: 159
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WsRunGalaxySkillPvp_d__15(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x0000000180628600-0x0000000180628BF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180628BF0-0x0000000180628C30
	}

	[CompilerGenerated]
	private sealed class _WsRunHealConvertSkillPvp_d__17 : IEnumerator<object> // TypeDefIndex: 160
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WsRunHealConvertSkillPvp_d__17(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x0000000180628C30-0x0000000180629160
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180629160-0x0000000180629330
	}

	// Constructors
	public CardPhotonSyncPVP(); // 0x0000000180615D80-0x0000000180615D90

	// Methods
	private void Awake(); // 0x0000000180614AC0-0x0000000180614BF0
	private void Start(); // 0x0000000180615AA0-0x0000000180615BD0
	private void OnDestroy(); // 0x0000000180614E90-0x0000000180614F70
	private string LocalBlockReasonPvp(CardUIPVP cardUI); // 0x0000000180614BF0-0x0000000180614E90
	public void RequestUseCard(CardUIPVP cardUI); // 0x0000000180614F70-0x0000000180615AA0
	[IteratorStateMachine(typeof(_WsRunDotSkillPvp_d__12))]
	private IEnumerator WsRunDotSkillPvp(CardUIPVP cardUI); // 0x0000000180615BD0-0x0000000180615C60
	[IteratorStateMachine(typeof(_WsRunGalaxySkillPvp_d__15))]
	private IEnumerator WsRunGalaxySkillPvp(CardUIPVP cardUI); // 0x0000000180615C60-0x0000000180615CF0
	[IteratorStateMachine(typeof(_WsRunHealConvertSkillPvp_d__17))]
	private IEnumerator WsRunHealConvertSkillPvp(CardUIPVP cardUI); // 0x0000000180615CF0-0x0000000180615D80
}

