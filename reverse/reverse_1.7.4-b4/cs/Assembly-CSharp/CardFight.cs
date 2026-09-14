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

public class CardFight : MonoBehaviour // TypeDefIndex: 2250
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
	private sealed class _DisableOnAnimationAfterPlay_d__18 : IEnumerator<object> // TypeDefIndex: 2251
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AD5B40-0x0000000180AD5C70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD5C70-0x0000000180AD5CB0
	}

	[CompilerGenerated]
	private sealed class _ProcessCardEffect_d__13 : IEnumerator<object> // TypeDefIndex: 2252
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AD5CB0-0x0000000180AD6550
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD6550-0x0000000180AD6590
	}

	[CompilerGenerated]
	private sealed class _ShowCardEffect_d__15 : IEnumerator<object> // TypeDefIndex: 2253
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AD6590-0x0000000180AD7670
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD7670-0x0000000180AD76B0
	}

	// Constructors
	public CardFight(); // 0x0000000180AD5990-0x0000000180AD5B40

	// Methods
	private void Start(); // 0x0000000180AD4440-0x0000000180AD4580
	public void GenerateCards(); // 0x0000000180AD4580-0x0000000180AD4E60
	public void HandleCardEffect(int cardID, int level); // 0x0000000180AD4E60-0x0000000180AD50F0
	[IteratorStateMachine(typeof(_ProcessCardEffect_d__13))]
	private IEnumerator ProcessCardEffect(int cardID, int level); // 0x0000000180AD50F0-0x0000000180AD51B0
	public void ActivateOnAnimationCard(int level); // 0x0000000180AD51B0-0x0000000180AD5350
	[IteratorStateMachine(typeof(_ShowCardEffect_d__15))]
	private IEnumerator ShowCardEffect(int cardID, int level = 1 /* Metadata: 0x005F1C90 */); // 0x0000000180AD5350-0x0000000180AD5410
	private string GetSpriteNameById(int id); // 0x0000000180AD5410-0x0000000180AD54C0
	public void playAnimationCard(); // 0x0000000180AD54C0-0x0000000180AD57C0
	[IteratorStateMachine(typeof(_DisableOnAnimationAfterPlay_d__18))]
	private IEnumerator DisableOnAnimationAfterPlay(); // 0x0000000180AD57C0-0x0000000180AD5860
	private void OnValidate(); // 0x0000000180AD5860-0x0000000180AD5980
	public void OnNewTurn(); // 0x0000000180AD5980-0x0000000180AD5990
}

