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

public class CardFight : MonoBehaviour // TypeDefIndex: 1877
{
	// Fields
	[Header("C\u00E0i \u0111\u1EB7t sinh card")]
	public GameObject cardPrefab; // 0x20
	public Transform cardParent; // 0x28
	public int cardCount; // 0x30
	[Header("ID h\u00ECnh cho t\u1EEBng card (1 = HP, 2 = Mana, 3 = No, 4 = dameCard)")]
	private List<int> cardIDs; // 0x38
	[Header("Animation References")]
	public GameObject onAnimationCardObject; // 0x40
	[Header("C\u1EA5p \u0111\u1ED9 cho card ID 4 (DameCard)")]
	[Range(1f, 10f)]
	public int dameCardLevel; // 0x48
	[Header("UI References")]
	public Active active; // 0x50
	public Board board; // 0x58
	private List<GameObject> spawnedCards; // 0x60
	public Animator cardAnimator; // 0x68

	// Nested types
	[CompilerGenerated]
	private sealed class _DisableOnAnimationAfterPlay_d__18 : IEnumerator<object> // TypeDefIndex: 1878
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardFight __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DisableOnAnimationAfterPlay_d__18(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806DCBC0-0x00000001806DCC80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806DCC80-0x00000001806DCCC0
	}

	[CompilerGenerated]
	private sealed class _ProcessCardEffect_d__13 : IEnumerator<object> // TypeDefIndex: 1879
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardFight __4__this; // 0x20
		public int cardID; // 0x28
		public int level; // 0x2C
		private int _value_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ProcessCardEffect_d__13(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806E2760-0x00000001806E2E80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E2E80-0x00000001806E2EC0
	}

	[CompilerGenerated]
	private sealed class _ShowCardEffect_d__15 : IEnumerator<object> // TypeDefIndex: 1880
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int cardID; // 0x20
		public CardFight __4__this; // 0x28
		public int level; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShowCardEffect_d__15(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806E3F20-0x00000001806E48D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E48D0-0x00000001806E4910
	}

	// Constructors
	public CardFight(); // 0x00000001806D9750-0x00000001806D9820

	// Methods
	private void Start(); // 0x00000001806D96B0-0x00000001806D9750
	public void GenerateCards(); // 0x00000001806D8CB0-0x00000001806D92A0
	public void HandleCardEffect(int cardID, int level); // 0x00000001806D9340-0x00000001806D9470
	[IteratorStateMachine(typeof(_ProcessCardEffect_d__13))]
	private IEnumerator ProcessCardEffect(int cardID, int level); // 0x00000001806D9590-0x00000001806D9620
	public void ActivateOnAnimationCard(int level); // 0x00000001806D8B80-0x00000001806D8C40
	[IteratorStateMachine(typeof(_ShowCardEffect_d__15))]
	private IEnumerator ShowCardEffect(int cardID, int level = 1 /* Metadata: 0x0068DA0F */); // 0x00000001806D9620-0x00000001806D96B0
	private string GetSpriteNameById(int id); // 0x00000001806D92A0-0x00000001806D9340
	public void playAnimationCard(); // 0x00000001806D9820-0x00000001806D9980
	[IteratorStateMachine(typeof(_DisableOnAnimationAfterPlay_d__18))]
	private IEnumerator DisableOnAnimationAfterPlay(); // 0x00000001806D8C40-0x00000001806D8CB0
	private void OnValidate(); // 0x00000001806D9480-0x00000001806D9590
	public void OnNewTurn(); // 0x00000001806D9470-0x00000001806D9480
}

