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

public class CardFight : MonoBehaviour // TypeDefIndex: 2243
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
	private sealed class _DisableOnAnimationAfterPlay_d__18 : IEnumerator<object> // TypeDefIndex: 2244
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardFight __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DisableOnAnimationAfterPlay_d__18(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AC8C80-0x0000000180AC8DB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC8DB0-0x0000000180AC8DF0
	}

	[CompilerGenerated]
	private sealed class _ProcessCardEffect_d__13 : IEnumerator<object> // TypeDefIndex: 2245
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardFight __4__this; // 0x20
		public int cardID; // 0x28
		public int level; // 0x2C
		private int _value_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ProcessCardEffect_d__13(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AC8DF0-0x0000000180AC9690
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC9690-0x0000000180AC96D0
	}

	[CompilerGenerated]
	private sealed class _ShowCardEffect_d__15 : IEnumerator<object> // TypeDefIndex: 2246
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int cardID; // 0x20
		public CardFight __4__this; // 0x28
		public int level; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowCardEffect_d__15(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AC96D0-0x0000000180ACA7B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ACA7B0-0x0000000180ACA7F0
	}

	// Constructors
	public CardFight(); // 0x0000000180AC8AD0-0x0000000180AC8C80

	// Methods
	private void Start(); // 0x0000000180AC7580-0x0000000180AC76C0
	public void GenerateCards(); // 0x0000000180AC76C0-0x0000000180AC7FA0
	public void HandleCardEffect(int cardID, int level); // 0x0000000180AC7FA0-0x0000000180AC8230
	[IteratorStateMachine(typeof(_ProcessCardEffect_d__13))]
	private IEnumerator ProcessCardEffect(int cardID, int level); // 0x0000000180AC8230-0x0000000180AC82F0
	public void ActivateOnAnimationCard(int level); // 0x0000000180AC82F0-0x0000000180AC8490
	[IteratorStateMachine(typeof(_ShowCardEffect_d__15))]
	private IEnumerator ShowCardEffect(int cardID, int level = 1 /* Metadata: 0x005F0879 */); // 0x0000000180AC8490-0x0000000180AC8550
	private string GetSpriteNameById(int id); // 0x0000000180AC8550-0x0000000180AC8600
	public void playAnimationCard(); // 0x0000000180AC8600-0x0000000180AC8900
	[IteratorStateMachine(typeof(_DisableOnAnimationAfterPlay_d__18))]
	private IEnumerator DisableOnAnimationAfterPlay(); // 0x0000000180AC8900-0x0000000180AC89A0
	private void OnValidate(); // 0x0000000180AC89A0-0x0000000180AC8AC0
	public void OnNewTurn(); // 0x0000000180AC8AC0-0x0000000180AC8AD0
}

