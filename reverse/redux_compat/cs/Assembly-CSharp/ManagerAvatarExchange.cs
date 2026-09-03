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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerAvatarExchange : MonoBehaviour // TypeDefIndex: 998
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
	private sealed class __c // TypeDefIndex: 999
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__14_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180494630-0x00000001804946A0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadExchangeListCoroutine_b__14_1(string error); // 0x0000000180493DA0-0x0000000180493E10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 1000
	{
		// Fields
		public ManagerAvatarExchange __4__this; // 0x10
		public AvatarExchangeItemDTO avatarData; // 0x18

		// Constructors
		public __c__DisplayClass16_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupGavt_b__0(); // 0x0000000180493E80-0x0000000180493F60
	}

	[CompilerGenerated]
	private sealed class _ExchangeAvatarCoroutine_d__21 : IEnumerator<object> // TypeDefIndex: 1001
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerAvatarExchange __4__this; // 0x20
		public AvatarExchangeItemDTO avatarData; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ExchangeAvatarCoroutine_d__21(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804931C0-0x0000000180493360
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180493360-0x00000001804933A0
	}

	[CompilerGenerated]
	private sealed class _LoadExchangeListCoroutine_d__14 : IEnumerator<object> // TypeDefIndex: 1002
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerAvatarExchange __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadExchangeListCoroutine_d__14(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180493900-0x0000000180493AF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180493AF0-0x0000000180493B30
	}

	// Constructors
	public ManagerAvatarExchange(); // 0x0000000180484580-0x0000000180484600

	// Methods
	private void Awake(); // 0x0000000180481E60-0x0000000180482090
	public void LoadExchangeList(); // 0x00000001804823F0-0x0000000180482760
	[IteratorStateMachine(typeof(_LoadExchangeListCoroutine_d__14))]
	private IEnumerator LoadExchangeListCoroutine(); // 0x0000000180482380-0x00000001804823F0
	private void DisplayAvatars(); // 0x0000000180482090-0x00000001804822F0
	private void SetupGavt(GameObject gavtObj, AvatarExchangeItemDTO avatarData); // 0x0000000180483010-0x00000001804836D0
	private void SetupAvatarImage(GameObject avtObj, AvatarExchangeItemDTO avatarData); // 0x00000001804829C0-0x0000000180482D30
	private void SetupItemDisplay(GameObject itemObj, long itemId, int current, int required); // 0x00000001804836D0-0x0000000180483990
	private void SetupE3Display(GameObject e3Obj, int current, int required); // 0x0000000180482EC0-0x0000000180483010
	private void OnExchangeClicked(AvatarExchangeItemDTO avatarData); // 0x0000000180482760-0x0000000180482830
	[IteratorStateMachine(typeof(_ExchangeAvatarCoroutine_d__21))]
	private IEnumerator ExchangeAvatarCoroutine(AvatarExchangeItemDTO avatarData); // 0x00000001804822F0-0x0000000180482380
	private void ShowInsufficientMessage(AvatarExchangeItemDTO avatarData); // 0x0000000180483DF0-0x0000000180484220
	private void ShowExchangeSuccess(List<RewardItemDTO> rewards); // 0x00000001804839A0-0x0000000180483DF0
	private void SetupAvatarReward(GameObject rewardObj, long avatarId); // 0x0000000180482D30-0x0000000180482EC0
	private void ShowMessage(string message); // 0x0000000180484220-0x00000001804843A0
	private void ShowErrorMessage(string error); // 0x0000000180483990-0x00000001804839A0
	private void OnGetResultClicked(); // 0x0000000180482830-0x0000000180482930
	public void OpenPanel(); // 0x0000000180482930-0x00000001804829C0
	[CompilerGenerated]
	private void _LoadExchangeListCoroutine_b__14_0(AvatarExchangeInfoDTO info); // 0x0000000180484510-0x0000000180484550
	[CompilerGenerated]
	private void _ExchangeAvatarCoroutine_b__21_0(EventClaimResponseDTO response); // 0x00000001804843A0-0x00000001804844A0
	[CompilerGenerated]
	private void _ExchangeAvatarCoroutine_b__21_1(string error); // 0x00000001804844A0-0x0000000180484510
	[CompilerGenerated]
	private void _OnGetResultClicked_b__27_0(); // 0x0000000180484550-0x0000000180484580
}

