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

namespace Poki.Assets.Script.Boss.xephang
{
	public class ManagerXepHangBoss : MonoBehaviour // TypeDefIndex: 2002
	{
		// Fields
		[Header("UI References")]
		public GameObject panelXepHang; // 0x20
		public Button btnClose; // 0x28
		public Button btnNhanQua; // 0x30
		[Header("Top Players Panel")]
		public Transform panelTop; // 0x38
		public GameObject topItemPrefab; // 0x40
		[Header("Your Result Panel")]
		public GameObject panelYourResult; // 0x48
		public Image imgPet; // 0x50
		public Image imgBoss; // 0x58
		public UnityEngine.UI.Text txtName; // 0x60
		public UnityEngine.UI.Text txtDame; // 0x68
		public UnityEngine.UI.Text txtYourTop; // 0x70
		[Header("Boss Info")]
		public UnityEngine.UI.Text txtBossName; // 0x78
		[Header("Notice Panel")]
		public GameObject panelNotice; // 0x80
		public Button btnGet; // 0x88
		public UnityEngine.UI.Text txtMessage; // 0x90
		private BossRankingResponseDTO currentRanking; // 0x98
		private int currentUserId; // 0xA0
		private long currentBossScheduleId; // 0xA8
		private bool _loading; // 0xB0
		private string _bossNameBase; // 0xB8
		private Coroutine _statusCo; // 0xC0
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass35_0 // TypeDefIndex: 2003
		{
			// Fields
			public UnityEngine.UI.Text target; // 0x10
			public int value; // 0x18
	
			// Constructors
			public __c__DisplayClass35_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _AnimateNumber_b__0(float v); // 0x000000018067AF00-0x000000018067AFD0
			internal void _AnimateNumber_b__1(); // 0x000000018067AFD0-0x000000018067B080
		}
	
		[CompilerGenerated]
		private sealed class _RefreshUserInfoSilently_d__38 : IEnumerator<object> // TypeDefIndex: 2004
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public ManagerXepHangBoss __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _RefreshUserInfoSilently_d__38(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x00000001806776F0-0x00000001806778B0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001806778B0-0x00000001806778F0
		}
	
		[CompilerGenerated]
		private sealed class _UpdateStatusLabelLoop_d__27 : IEnumerator<object> // TypeDefIndex: 2005
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public ManagerXepHangBoss __4__this; // 0x20
			private long _clockOffsetMs_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _UpdateStatusLabelLoop_d__27(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x000000018067B9E0-0x000000018067BE20
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018067BE20-0x000000018067BE60
		}
	
		// Constructors
		public ManagerXepHangBoss(); // 0x0000000180674280-0x00000001806742E0
	
		// Methods
		private void Start(); // 0x0000000180673FE0-0x0000000180674210
		public void OpenPanel(); // 0x0000000180673A10-0x0000000180673A90
		public void ClosePanel(); // 0x00000001806718F0-0x00000001806719A0
		private void LoadRankingData(); // 0x0000000180672D30-0x0000000180672F20
		private void HideAllPanels(); // 0x00000001806725C0-0x0000000180672690
		private void OnRankingReceived(BossRankingResponseDTO ranking); // 0x00000001806731E0-0x00000001806734C0
		[IteratorStateMachine(typeof(_UpdateStatusLabelLoop_d__27))]
		private IEnumerator UpdateStatusLabelLoop(); // 0x0000000180674210-0x0000000180674280
		private static long NowMs(); // 0x0000000180672F20-0x0000000180673000
		private static string FormatDuration(long ms); // 0x0000000180672430-0x00000001806725C0
		private void HideCurrentPlayer(); // 0x0000000180672690-0x0000000180672740
		private void HideTopPlayers(); // 0x0000000180672740-0x00000001806729D0
		private void DisplayTopPlayers(List<BossRankingPlayerDTO> topPlayers); // 0x0000000180671F60-0x0000000180672430
		private void SetupTopItemManually(GameObject itemObj, BossRankingPlayerDTO player); // 0x0000000180673B00-0x0000000180673E40
		private void DisplayCurrentPlayer(BossRankingPlayerDTO currentPlayer); // 0x00000001806719A0-0x0000000180671F60
		private void AnimateNumber(UnityEngine.UI.Text target, int value); // 0x0000000180671340-0x00000001806715A0
		private void ClaimReward(); // 0x00000001806715A0-0x0000000180671870
		private void OnRewardClaimed(ClaimRewardResponseDTO response); // 0x0000000180673530-0x00000001806737D0
		[IteratorStateMachine(typeof(_RefreshUserInfoSilently_d__38))]
		private IEnumerator RefreshUserInfoSilently(); // 0x0000000180673A90-0x0000000180673B00
		private void OnUserInfoRefreshed(UserDTO user); // 0x00000001806737D0-0x0000000180673A10
		private void OnRefreshError(string error); // 0x00000001806734C0-0x0000000180673530
		private void LoadPetAvatar(Image imgPet, long petId); // 0x0000000180672B80-0x0000000180672D30
		private void LoadBossAvatar(Image imgBoss, long bossId); // 0x00000001806729D0-0x0000000180672B80
		private void ShowNotice(string message); // 0x0000000180673E40-0x0000000180673FE0
		private void CloseNotice(); // 0x0000000180671870-0x00000001806718F0
		private void OnError(string error); // 0x0000000180673140-0x00000001806731E0
		private void OnClaimError(string error); // 0x0000000180673000-0x00000001806730F0
		private void OnDisable(); // 0x00000001806730F0-0x0000000180673140
	}
}
