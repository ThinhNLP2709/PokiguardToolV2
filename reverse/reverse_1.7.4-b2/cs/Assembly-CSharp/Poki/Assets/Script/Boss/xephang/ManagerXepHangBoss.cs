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

namespace Poki.Assets.Script.Boss.xephang
{
	public class ManagerXepHangBoss : MonoBehaviour // TypeDefIndex: 2169
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
		private sealed class __c__DisplayClass35_0 // TypeDefIndex: 2170
		{
			// Fields
			public UnityEngine.UI.Text target; // 0x10
			public int value; // 0x18
	
			// Constructors
			public __c__DisplayClass35_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _AnimateNumber_b__0(float v); // 0x000000018077D180-0x000000018077D250
			internal void _AnimateNumber_b__1(); // 0x000000018077D250-0x000000018077D300
		}
	
		[CompilerGenerated]
		private sealed class _RefreshUserInfoSilently_d__38 : IEnumerator<object> // TypeDefIndex: 2171
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public ManagerXepHangBoss __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _RefreshUserInfoSilently_d__38(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x00000001807798A0-0x0000000180779A60
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180779A60-0x0000000180779AA0
		}
	
		[CompilerGenerated]
		private sealed class _UpdateStatusLabelLoop_d__27 : IEnumerator<object> // TypeDefIndex: 2172
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public ManagerXepHangBoss __4__this; // 0x20
			private long _clockOffsetMs_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _UpdateStatusLabelLoop_d__27(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x000000018077DBF0-0x000000018077E030
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018077E030-0x000000018077E070
		}
	
		// Constructors
		public ManagerXepHangBoss(); // 0x000000018076A5A0-0x000000018076A600
	
		// Methods
		private void Start(); // 0x000000018076A300-0x000000018076A530
		public void OpenPanel(); // 0x0000000180769D30-0x0000000180769DB0
		public void ClosePanel(); // 0x0000000180767C10-0x0000000180767CC0
		private void LoadRankingData(); // 0x0000000180769050-0x0000000180769240
		private void HideAllPanels(); // 0x00000001807688E0-0x00000001807689B0
		private void OnRankingReceived(BossRankingResponseDTO ranking); // 0x0000000180769500-0x00000001807697E0
		[IteratorStateMachine(typeof(_UpdateStatusLabelLoop_d__27))]
		private IEnumerator UpdateStatusLabelLoop(); // 0x000000018076A530-0x000000018076A5A0
		private static long NowMs(); // 0x0000000180769240-0x0000000180769320
		private static string FormatDuration(long ms); // 0x0000000180768750-0x00000001807688E0
		private void HideCurrentPlayer(); // 0x00000001807689B0-0x0000000180768A60
		private void HideTopPlayers(); // 0x0000000180768A60-0x0000000180768CF0
		private void DisplayTopPlayers(List<BossRankingPlayerDTO> topPlayers); // 0x0000000180768280-0x0000000180768750
		private void SetupTopItemManually(GameObject itemObj, BossRankingPlayerDTO player); // 0x0000000180769E20-0x000000018076A160
		private void DisplayCurrentPlayer(BossRankingPlayerDTO currentPlayer); // 0x0000000180767CC0-0x0000000180768280
		private void AnimateNumber(UnityEngine.UI.Text target, int value); // 0x0000000180767660-0x00000001807678C0
		private void ClaimReward(); // 0x00000001807678C0-0x0000000180767B90
		private void OnRewardClaimed(ClaimRewardResponseDTO response); // 0x0000000180769850-0x0000000180769AF0
		[IteratorStateMachine(typeof(_RefreshUserInfoSilently_d__38))]
		private IEnumerator RefreshUserInfoSilently(); // 0x0000000180769DB0-0x0000000180769E20
		private void OnUserInfoRefreshed(UserDTO user); // 0x0000000180769AF0-0x0000000180769D30
		private void OnRefreshError(string error); // 0x00000001807697E0-0x0000000180769850
		private void LoadPetAvatar(Image imgPet, long petId); // 0x0000000180768EA0-0x0000000180769050
		private void LoadBossAvatar(Image imgBoss, long bossId); // 0x0000000180768CF0-0x0000000180768EA0
		private void ShowNotice(string message); // 0x000000018076A160-0x000000018076A300
		private void CloseNotice(); // 0x0000000180767B90-0x0000000180767C10
		private void OnError(string error); // 0x0000000180769460-0x0000000180769500
		private void OnClaimError(string error); // 0x0000000180769320-0x0000000180769410
		private void OnDisable(); // 0x0000000180769410-0x0000000180769460
	}
}
