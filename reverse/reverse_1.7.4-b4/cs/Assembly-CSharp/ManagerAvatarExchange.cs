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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ManagerAvatarExchange : MonoBehaviour // TypeDefIndex: 1599
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
	private sealed class __c // TypeDefIndex: 1600
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__14_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180883890-0x0000000180883930
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadExchangeListCoroutine_b__14_1(string error); // 0x0000000180883930-0x00000001808839B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 1601
	{
		// Fields
		public ManagerAvatarExchange __4__this; // 0x10
		public AvatarExchangeItemDTO avatarData; // 0x18

		// Constructors
		public __c__DisplayClass16_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupGavt_b__0(); // 0x00000001808839B0-0x0000000180883B50
	}

	[CompilerGenerated]
	private sealed class _ExchangeAvatarCoroutine_d__21 : IEnumerator<object> // TypeDefIndex: 1602
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180883B50-0x0000000180883E80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180883E80-0x0000000180883EC0
	}

	[CompilerGenerated]
	private sealed class _LoadExchangeListCoroutine_d__14 : IEnumerator<object> // TypeDefIndex: 1603
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180883EC0-0x0000000180884290
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180884290-0x00000001808842D0
	}

	// Constructors
	public ManagerAvatarExchange(); // 0x0000000180883440-0x0000000180883540

	// Methods
	private void Awake(); // 0x000000018087EE60-0x000000018087F350
	public void LoadExchangeList(); // 0x000000018087F350-0x000000018087F850
	[IteratorStateMachine(typeof(_LoadExchangeListCoroutine_d__14))]
	private IEnumerator LoadExchangeListCoroutine(); // 0x000000018087F850-0x000000018087F8F0
	private void DisplayAvatars(); // 0x000000018087F8F0-0x000000018087FD00
	private void SetupGavt(GameObject gavtObj, AvatarExchangeItemDTO avatarData); // 0x000000018087FD00-0x00000001808809C0
	private void SetupAvatarImage(GameObject avtObj, AvatarExchangeItemDTO avatarData); // 0x00000001808809C0-0x0000000180881100
	private void SetupItemDisplay(GameObject itemObj, long itemId, int current, int required); // 0x0000000180881100-0x0000000180881690
	private void SetupE3Display(GameObject e3Obj, int current, int required); // 0x0000000180881690-0x0000000180881900
	private void OnExchangeClicked(AvatarExchangeItemDTO avatarData); // 0x0000000180881900-0x0000000180881A90
	[IteratorStateMachine(typeof(_ExchangeAvatarCoroutine_d__21))]
	private IEnumerator ExchangeAvatarCoroutine(AvatarExchangeItemDTO avatarData); // 0x0000000180881A90-0x0000000180881BA0
	private void ShowInsufficientMessage(AvatarExchangeItemDTO avatarData); // 0x0000000180881BA0-0x00000001808822A0
	private void ShowExchangeSuccess(List<RewardItemDTO> rewards); // 0x00000001808822A0-0x00000001808829C0
	private void SetupAvatarReward(GameObject rewardObj, long avatarId); // 0x00000001808829C0-0x0000000180882D70
	private void ShowMessage(string message); // 0x0000000180882D70-0x0000000180883080
	private void ShowErrorMessage(string error); // 0x0000000180883080-0x0000000180883090
	private void OnGetResultClicked(); // 0x0000000180883090-0x00000001808832F0
	public void OpenPanel(); // 0x00000001808832F0-0x0000000180883440
	[CompilerGenerated]
	private void _LoadExchangeListCoroutine_b__14_0(AvatarExchangeInfoDTO info); // 0x0000000180883540-0x00000001808835C0
	[CompilerGenerated]
	private void _ExchangeAvatarCoroutine_b__21_0(EventClaimResponseDTO response); // 0x00000001808835C0-0x0000000180883770
	[CompilerGenerated]
	private void _ExchangeAvatarCoroutine_b__21_1(string error); // 0x0000000180883770-0x0000000180883810
	[CompilerGenerated]
	private void _OnGetResultClicked_b__27_0(); // 0x0000000180883810-0x0000000180883890
}

