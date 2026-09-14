/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ManagerAvatarExchange : MonoBehaviour // TypeDefIndex: 1597
{
	// Fields
	[Header("Panels")]
	public GameObject panelAvt; // 0x20
	public GameObject panelResult; // 0x28
	[Header("Avatar Groups - Theo hierarchy")]
	public GameObject Gavt; // 0x30
	public GameObject Gavt1; // 0x38
	public GameObject Gavt2; // 0x40
	public GameObject Gavt3; // 0x48
	[Header("Panel Result UI")]
	public Transform listRewardResult; // 0x50
	public Button btnGetResult; // 0x58
	public GameObject avatarRewardPrefab; // 0x60
	private int userId; // 0x68
	private List<AvatarExchangeItemDTO> exchangeList; // 0x70
	private List<GameObject> gavtSlots; // 0x78

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1598
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__14_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180881530-0x00000001808815D0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadExchangeListCoroutine_b__14_1(string error); // 0x00000001808815D0-0x0000000180881650
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 1599
	{
		// Fields
		public ManagerAvatarExchange __4__this; // 0x10
		public AvatarExchangeItemDTO avatarData; // 0x18

		// Constructors
		public __c__DisplayClass16_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupGavt_b__0(); // 0x0000000180881650-0x00000001808817B0
	}

	[CompilerGenerated]
	private sealed class _ExchangeAvatarCoroutine_d__21 : IEnumerator<object> // TypeDefIndex: 1600
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerAvatarExchange __4__this; // 0x20
		public AvatarExchangeItemDTO avatarData; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ExchangeAvatarCoroutine_d__21(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001808817B0-0x0000000180881AB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180881AB0-0x0000000180881AF0
	}

	[CompilerGenerated]
	private sealed class _LoadExchangeListCoroutine_d__14 : IEnumerator<object> // TypeDefIndex: 1601
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerAvatarExchange __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadExchangeListCoroutine_d__14(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180881AF0-0x0000000180881EA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180881EA0-0x0000000180881EE0
	}

	// Constructors
	public ManagerAvatarExchange(); // 0x0000000180881130-0x0000000180881230

	// Methods
	private void Awake(); // 0x000000018087CB80-0x000000018087D070
	public void LoadExchangeList(); // 0x000000018087D070-0x000000018087D570
	[IteratorStateMachine(typeof(_LoadExchangeListCoroutine_d__14))]
	private IEnumerator LoadExchangeListCoroutine(); // 0x000000018087D570-0x000000018087D610
	private void DisplayAvatars(); // 0x000000018087D610-0x000000018087DA20
	private void SetupGavt(GameObject gavtObj, AvatarExchangeItemDTO avatarData); // 0x000000018087DA20-0x000000018087E6E0
	private void SetupAvatarImage(GameObject avtObj, AvatarExchangeItemDTO avatarData); // 0x000000018087E6E0-0x000000018087EE20
	private void SetupItemDisplay(GameObject itemObj, long itemId, int current, int required); // 0x000000018087EE20-0x000000018087F3B0
	private void SetupE3Display(GameObject e3Obj, int current, int required); // 0x000000018087F3B0-0x000000018087F620
	private void OnExchangeClicked(AvatarExchangeItemDTO avatarData); // 0x000000018087F620-0x000000018087F780
	[IteratorStateMachine(typeof(_ExchangeAvatarCoroutine_d__21))]
	private IEnumerator ExchangeAvatarCoroutine(AvatarExchangeItemDTO avatarData); // 0x000000018087F780-0x000000018087F890
	private void ShowInsufficientMessage(AvatarExchangeItemDTO avatarData); // 0x000000018087F890-0x000000018087FF90
	private void ShowExchangeSuccess(List<RewardItemDTO> rewards); // 0x000000018087FF90-0x00000001808806B0
	private void SetupAvatarReward(GameObject rewardObj, long avatarId); // 0x00000001808806B0-0x0000000180880A60
	private void ShowMessage(string message); // 0x0000000180880A60-0x0000000180880D70
	private void ShowErrorMessage(string error); // 0x0000000180880D70-0x0000000180880D80
	private void OnGetResultClicked(); // 0x0000000180880D80-0x0000000180880FE0
	public void OpenPanel(); // 0x0000000180880FE0-0x0000000180881130
	[CompilerGenerated]
	private void _LoadExchangeListCoroutine_b__14_0(AvatarExchangeInfoDTO info); // 0x0000000180881230-0x00000001808812B0
	[CompilerGenerated]
	private void _ExchangeAvatarCoroutine_b__21_0(EventClaimResponseDTO response); // 0x00000001808812B0-0x0000000180881440
	[CompilerGenerated]
	private void _ExchangeAvatarCoroutine_b__21_1(string error); // 0x0000000180881440-0x00000001808814B0
	[CompilerGenerated]
	private void _OnGetResultClicked_b__27_0(); // 0x00000001808814B0-0x0000000180881530
}

