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

namespace Poki.Assets.Script.Boss.xephang
{
	public class ManagerXepHangBoss : MonoBehaviour // TypeDefIndex: 2603
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
		private sealed class __c__DisplayClass35_0 // TypeDefIndex: 2604
		{
			// Fields
			public UnityEngine.UI.Text target; // 0x10
			public int value; // 0x18
	
			// Constructors
			public __c__DisplayClass35_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _AnimateNumber_b__0(float v); // 0x0000000180C016B0-0x0000000180C01880
			internal void _AnimateNumber_b__1(); // 0x0000000180C01880-0x0000000180C01A40
		}
	
		[CompilerGenerated]
		private sealed class _RefreshUserInfoSilently_d__38 : IEnumerator<object> // TypeDefIndex: 2605
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public ManagerXepHangBoss __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _RefreshUserInfoSilently_d__38(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180C01A40-0x0000000180C01CB0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C01CB0-0x0000000180C01CF0
		}
	
		[CompilerGenerated]
		private sealed class _UpdateStatusLabelLoop_d__27 : IEnumerator<object> // TypeDefIndex: 2606
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public ManagerXepHangBoss __4__this; // 0x20
			private long _clockOffsetMs_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _UpdateStatusLabelLoop_d__27(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180C01CF0-0x0000000180C023A0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C023A0-0x0000000180C023E0
		}
	
		// Constructors
		public ManagerXepHangBoss(); // 0x0000000180C015E0-0x0000000180C016B0
	
		// Methods
		private void Start(); // 0x0000000180BFBDA0-0x0000000180BFC2C0
		public void OpenPanel(); // 0x0000000180BFC2C0-0x0000000180BFC410
		public void ClosePanel(); // 0x0000000180BFC410-0x0000000180BFC5D0
		private void LoadRankingData(); // 0x0000000180BFC5D0-0x0000000180BFC8F0
		private void HideAllPanels(); // 0x0000000180BFC8F0-0x0000000180BFCA90
		private void OnRankingReceived(BossRankingResponseDTO ranking); // 0x0000000180BFCA90-0x0000000180BFCEE0
		[IteratorStateMachine(typeof(_UpdateStatusLabelLoop_d__27))]
		private IEnumerator UpdateStatusLabelLoop(); // 0x0000000180BFCEE0-0x0000000180BFCF80
		private static long NowMs(); // 0x0000000180BFCF80-0x0000000180BFD080
		private static string FormatDuration(long ms); // 0x0000000180BFD080-0x0000000180BFD340
		private void HideCurrentPlayer(); // 0x0000000180BFD340-0x0000000180BFD590
		private void HideTopPlayers(); // 0x0000000180BFD590-0x0000000180BFD980
		private void DisplayTopPlayers(List<BossRankingPlayerDTO> topPlayers); // 0x0000000180BFD980-0x0000000180BFE270
		private void SetupTopItemManually(GameObject itemObj, BossRankingPlayerDTO player); // 0x0000000180BFE270-0x0000000180BFEA90
		private void DisplayCurrentPlayer(BossRankingPlayerDTO currentPlayer); // 0x0000000180BFEA90-0x0000000180BFF510
		private void AnimateNumber(UnityEngine.UI.Text target, int value); // 0x0000000180BFF510-0x0000000180BFF8A0
		private void ClaimReward(); // 0x0000000180BFF8A0-0x0000000180BFFDE0
		private void OnRewardClaimed(ClaimRewardResponseDTO response); // 0x0000000180BFFDE0-0x0000000180C002C0
		[IteratorStateMachine(typeof(_RefreshUserInfoSilently_d__38))]
		private IEnumerator RefreshUserInfoSilently(); // 0x0000000180C002C0-0x0000000180C00360
		private void OnUserInfoRefreshed(UserDTO user); // 0x0000000180C00360-0x0000000180C00650
		private void OnRefreshError(string error); // 0x0000000180C00650-0x0000000180C006D0
		private void LoadPetAvatar(Image imgPet, long petId); // 0x0000000180C006D0-0x0000000180C00A50
		private void LoadBossAvatar(Image imgBoss, long bossId); // 0x0000000180C00A50-0x0000000180C00DD0
		private void ShowNotice(string message); // 0x0000000180C00DD0-0x0000000180C011D0
		private void CloseNotice(); // 0x0000000180C011D0-0x0000000180C01320
		private void OnError(string error); // 0x0000000180C01320-0x0000000180C013D0
		private void OnClaimError(string error); // 0x0000000180C013D0-0x0000000180C01560
		private void OnDisable(); // 0x0000000180C01560-0x0000000180C015E0
	}
}
