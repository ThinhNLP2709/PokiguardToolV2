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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerAvatarExchange : MonoBehaviour // TypeDefIndex: 1196
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
	private sealed class __c // TypeDefIndex: 1197
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__14_1; // 0x08

		// Constructors
		static __c(); // 0x000000018058BDD0-0x000000018058BE40
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadExchangeListCoroutine_b__14_1(string error); // 0x000000018058BC80-0x000000018058BCF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 1198
	{
		// Fields
		public ManagerAvatarExchange __4__this; // 0x10
		public AvatarExchangeItemDTO avatarData; // 0x18

		// Constructors
		public __c__DisplayClass16_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupGavt_b__0(); // 0x000000018058BCF0-0x000000018058BDD0
	}

	[CompilerGenerated]
	private sealed class _ExchangeAvatarCoroutine_d__21 : IEnumerator<object> // TypeDefIndex: 1199
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerAvatarExchange __4__this; // 0x20
		public AvatarExchangeItemDTO avatarData; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ExchangeAvatarCoroutine_d__21(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018058B580-0x000000018058B720
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018058B720-0x000000018058B760
	}

	[CompilerGenerated]
	private sealed class _LoadExchangeListCoroutine_d__14 : IEnumerator<object> // TypeDefIndex: 1200
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerAvatarExchange __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadExchangeListCoroutine_d__14(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018058BA50-0x000000018058BC40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018058BC40-0x000000018058BC80
	}

	// Constructors
	public ManagerAvatarExchange(); // 0x0000000180578710-0x0000000180578790

	// Methods
	private void Awake(); // 0x0000000180575FF0-0x0000000180576220
	public void LoadExchangeList(); // 0x0000000180576580-0x00000001805768F0
	[IteratorStateMachine(typeof(_LoadExchangeListCoroutine_d__14))]
	private IEnumerator LoadExchangeListCoroutine(); // 0x0000000180576510-0x0000000180576580
	private void DisplayAvatars(); // 0x0000000180576220-0x0000000180576480
	private void SetupGavt(GameObject gavtObj, AvatarExchangeItemDTO avatarData); // 0x00000001805771A0-0x0000000180577860
	private void SetupAvatarImage(GameObject avtObj, AvatarExchangeItemDTO avatarData); // 0x0000000180576B50-0x0000000180576EC0
	private void SetupItemDisplay(GameObject itemObj, long itemId, int current, int required); // 0x0000000180577860-0x0000000180577B20
	private void SetupE3Display(GameObject e3Obj, int current, int required); // 0x0000000180577050-0x00000001805771A0
	private void OnExchangeClicked(AvatarExchangeItemDTO avatarData); // 0x00000001805768F0-0x00000001805769C0
	[IteratorStateMachine(typeof(_ExchangeAvatarCoroutine_d__21))]
	private IEnumerator ExchangeAvatarCoroutine(AvatarExchangeItemDTO avatarData); // 0x0000000180576480-0x0000000180576510
	private void ShowInsufficientMessage(AvatarExchangeItemDTO avatarData); // 0x0000000180577F80-0x00000001805783B0
	private void ShowExchangeSuccess(List<RewardItemDTO> rewards); // 0x0000000180577B30-0x0000000180577F80
	private void SetupAvatarReward(GameObject rewardObj, long avatarId); // 0x0000000180576EC0-0x0000000180577050
	private void ShowMessage(string message); // 0x00000001805783B0-0x0000000180578530
	private void ShowErrorMessage(string error); // 0x0000000180577B20-0x0000000180577B30
	private void OnGetResultClicked(); // 0x00000001805769C0-0x0000000180576AC0
	public void OpenPanel(); // 0x0000000180576AC0-0x0000000180576B50
	[CompilerGenerated]
	private void _LoadExchangeListCoroutine_b__14_0(AvatarExchangeInfoDTO info); // 0x00000001805786A0-0x00000001805786E0
	[CompilerGenerated]
	private void _ExchangeAvatarCoroutine_b__21_0(EventClaimResponseDTO response); // 0x0000000180578530-0x0000000180578630
	[CompilerGenerated]
	private void _ExchangeAvatarCoroutine_b__21_1(string error); // 0x0000000180578630-0x00000001805786A0
	[CompilerGenerated]
	private void _OnGetResultClicked_b__27_0(); // 0x00000001805786E0-0x0000000180578710
}

