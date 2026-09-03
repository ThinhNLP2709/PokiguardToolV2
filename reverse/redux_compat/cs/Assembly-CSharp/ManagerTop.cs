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

public class ManagerTop : MonoBehaviour // TypeDefIndex: 1743
{
	// Fields
	public const string PANEL_KEY = "PanelXepHang"; // Metadata: 0x0064DA39
	[Header("=== TOP 30 PANEL ===")]
	public Button btnReward; // 0x20
	public GameObject panelListTop30; // 0x28
	public Button btnBackTop30; // 0x30
	public Transform listPanelTop30; // 0x38
	public GameObject btnUserTopPrefab; // 0x40
	[Header("=== SEARCH FEATURE ===")]
	public InputField inputSearchUsername; // 0x48
	public Button btnSearch; // 0x50
	public GameObject searchErrorPanel; // 0x58
	public UnityEngine.UI.Text searchErrorText; // 0x60
	[Header("UI References")]
	public Button btnTop; // 0x68
	public GameObject PanelXepHang; // 0x70
	public Button btnBack; // 0x78
	[Header("Ranking Items - C\u00F3 s\u1EB5n 9 userT")]
	public Transform[] userTItems; // 0x80
	[Header("User Detail Panel")]
	public GameObject panelDetailTop; // 0x88
	public Button btnCloseDetail; // 0x90
	public Image imgUserDetail; // 0x98
	public UnityEngine.UI.Text txtUserNameDetail; // 0xA0
	public UnityEngine.UI.Text txtTotalCombatPowerDetail; // 0xA8
	public Image imgUserLevelDetail; // 0xB0
	public Animator anmtCurrentPet; // 0xB8
	public UnityEngine.UI.Text txtUserTop; // 0xC0
	[Header("Current Pet Stats")]
	public UnityEngine.UI.Text txtAttack; // 0xC8
	public UnityEngine.UI.Text txtHP; // 0xD0
	public UnityEngine.UI.Text txtMana; // 0xD8
	[Header("Pet List")]
	public Transform petListContent; // 0xE0
	public GameObject petItemPrefab; // 0xE8
	[Header("Stone List")]
	public Transform stoneListContent; // 0xF0
	public GameObject stoneItemPrefab; // 0xF8
	[Header("Stone Images - 5 H\u1EC7, m\u1ED7i h\u1EC7 7 Level")]
	[Tooltip("H\u1EC7 L\u1EEDa - 7 level")]
	public Sprite[] stoneFire; // 0x100
	[Tooltip("H\u1EC7 N\u01B0\u1EDBc - 7 level")]
	public Sprite[] stoneWater; // 0x108
	[Tooltip("H\u1EC7 Gi\u00F3 - 7 level")]
	public Sprite[] stoneWind; // 0x110
	[Tooltip("H\u1EC7 \u0110\u1EA5t - 7 level")]
	public Sprite[] stoneEarth; // 0x118
	[Tooltip("H\u1EC7 S\u00E9t - 7 level")]
	public Sprite[] stoneThunder; // 0x120
	[Header("Animation Settings")]
	public float panelAnimDuration; // 0x128
	public float itemAnimDelay; // 0x12C
	public LeanTweenType easeType; // 0x130
	private List<TopRankingData> currentRankings; // 0x138
	private Dictionary<int, Sprite> stoneDictionary; // 0x140
	private CanvasGroup panelXepHangCanvasGroup; // 0x148
	private CanvasGroup panelDetailCanvasGroup; // 0x150
	private GameObject _rewardRowTemplate; // 0x158
	private Transform _rewardRowsParent; // 0x160
	[Header("Loading")]
	public GameObject loadingIndicator; // 0x168

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1744
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__58_0; // 0x08
		public static Action __9__60_0; // 0x10
		public static Action<string> __9__68_1; // 0x18
		public static Action<string> __9__83_1; // 0x20
		public static Action<string> __9__89_1; // 0x28

		// Constructors
		static __c(); // 0x00000001805FE980-0x00000001805FE9F0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadRankingRewardTable_b__58_0(string error); // 0x00000001805FE0D0-0x00000001805FE140
		internal void _OnCloseRankingClicked_b__60_0(); // 0x00000001805FE220-0x00000001805FE360
		internal void _FetchUserDetail_b__68_1(string error); // 0x00000001805FE060-0x00000001805FE0D0
		internal void _LoadTop30Ranking_b__83_1(string error); // 0x00000001805FE140-0x00000001805FE1B0
		internal void _LoadUserDetailById_b__89_1(string error); // 0x00000001805FE1B0-0x00000001805FE220
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass46_0 // TypeDefIndex: 1745
	{
		// Fields
		public UserDetailData userDetail; // 0x10
		public bool success; // 0x18
		public ManagerTop __4__this; // 0x20
		public string username; // 0x28

		// Constructors
		public __c__DisplayClass46_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SearchUserByName_b__0(UserDetailData data); // 0x0000000180439DF0-0x0000000180439E10
		internal void _SearchUserByName_b__1(string error); // 0x00000001805FE360-0x00000001805FE420
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass57_0 // TypeDefIndex: 1746
	{
		// Fields
		public List<TopRankingData> rankings; // 0x10
		public bool dataLoaded; // 0x18

		// Constructors
		public __c__DisplayClass57_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadDataThenOpenPanel_b__0(List<TopRankingData> data); // 0x0000000180439DF0-0x0000000180439E10
		internal void _LoadDataThenOpenPanel_b__1(string error); // 0x00000001805FE420-0x00000001805FE4A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass66_0 // TypeDefIndex: 1747
	{
		// Fields
		public Transform userT; // 0x10
		public ManagerTop __4__this; // 0x18
		public TopRankingData ranking; // 0x20
		public Action __9__1; // 0x28

		// Constructors
		public __c__DisplayClass66_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupRankingItem_b__0(); // 0x00000001805FE4A0-0x00000001805FE690
		internal void _SetupRankingItem_b__1(); // 0x00000001805FE690-0x00000001805FE750
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass73_0 // TypeDefIndex: 1748
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10

		// Constructors
		public __c__DisplayClass73_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _AnimateNumberText_b__0(float val); // 0x00000001805FE750-0x00000001805FE870
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass83_0 // TypeDefIndex: 1749
	{
		// Fields
		public List<TopRankingData> top30Rankings; // 0x10
		public bool success; // 0x18

		// Constructors
		public __c__DisplayClass83_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadTop30Ranking_b__0(List<TopRankingData> data); // 0x0000000180439DF0-0x0000000180439E10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass84_0 // TypeDefIndex: 1750
	{
		// Fields
		public long userId; // 0x10
		public ManagerTop __4__this; // 0x18

		// Constructors
		public __c__DisplayClass84_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _DisplayTop30Panel_b__0(); // 0x00000001805FE870-0x00000001805FE910
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass89_0 // TypeDefIndex: 1751
	{
		// Fields
		public UserDetailData userDetail; // 0x10
		public bool success; // 0x18

		// Constructors
		public __c__DisplayClass89_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadUserDetailById_b__0(UserDetailData data); // 0x0000000180439DF0-0x0000000180439E10
	}

	[CompilerGenerated]
	private sealed class _DelayedAnimatePetItem_d__75 : IEnumerator<object> // TypeDefIndex: 1752
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerTop __4__this; // 0x20
		public GameObject item; // 0x28
		public int index; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DelayedAnimatePetItem_d__75(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805FBEE0-0x00000001805FBF50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805FBF50-0x00000001805FBF90
	}

	[CompilerGenerated]
	private sealed class _FetchUserDetail_d__68 : IEnumerator<object> // TypeDefIndex: 1753
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ManagerTop __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FetchUserDetail_d__68(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805FBF90-0x00000001805FC190
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805FC190-0x00000001805FC1D0
	}

	[CompilerGenerated]
	private sealed class _HideSearchErrorAfterDelay_d__48 : IEnumerator<object> // TypeDefIndex: 1754
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerTop __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HideSearchErrorAfterDelay_d__48(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805FC310-0x00000001805FC410
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805FC410-0x00000001805FC450
	}

	[CompilerGenerated]
	private sealed class _LoadDataThenOpenPanel_d__57 : IEnumerator<object> // TypeDefIndex: 1755
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerTop __4__this; // 0x20
		private __c__DisplayClass57_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadDataThenOpenPanel_d__57(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001805FC450-0x00000001805FC930
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805FC930-0x00000001805FC970
	}

	[CompilerGenerated]
	private sealed class _LoadTop30Ranking_d__83 : IEnumerator<object> // TypeDefIndex: 1756
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerTop __4__this; // 0x20
		private __c__DisplayClass83_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadTop30Ranking_d__83(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001805FC970-0x00000001805FCC30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805FCC30-0x00000001805FCC70
	}

	[CompilerGenerated]
	private sealed class _LoadUserDetailById_d__89 : IEnumerator<object> // TypeDefIndex: 1757
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long userId; // 0x20
		public ManagerTop __4__this; // 0x28
		private __c__DisplayClass89_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadUserDetailById_d__89(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x00000001805FCC70-0x00000001805FCF50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805FCF50-0x00000001805FCF90
	}

	[CompilerGenerated]
	private sealed class _SearchUserByName_d__46 : IEnumerator<object> // TypeDefIndex: 1758
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerTop __4__this; // 0x20
		public string username; // 0x28
		private __c__DisplayClass46_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SearchUserByName_d__46(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x00000001805FCF90-0x00000001805FD240
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805FD240-0x00000001805FD280
	}

	// Constructors
	public ManagerTop(); // 0x00000001805F4740-0x00000001805F48E0

	// Methods
	private void Awake(); // 0x00000001805EEC90-0x00000001805EF200
	private void OnSearchButtonClicked(); // 0x00000001805F2480-0x00000001805F2610
	[IteratorStateMachine(typeof(_SearchUserByName_d__46))]
	private IEnumerator SearchUserByName(string username); // 0x00000001805F2AE0-0x00000001805F2B70
	private void ShowSearchError(string message); // 0x00000001805F3D60-0x00000001805F3EE0
	[IteratorStateMachine(typeof(_HideSearchErrorAfterDelay_d__48))]
	private IEnumerator HideSearchErrorAfterDelay(float delay); // 0x00000001805F1200-0x00000001805F1280
	private void ShowLoadingIndicator(); // 0x00000001805F3CE0-0x00000001805F3D60
	private void HideLoadingIndicator(); // 0x00000001805F1150-0x00000001805F1200
	private void SetupCanvasGroups(); // 0x00000001805F2B70-0x00000001805F2CE0
	private void InitializeStoneDictionary(); // 0x00000001805F1280-0x00000001805F19C0
	private int CountValidSprites(Sprite[] sprites); // 0x00000001805EF820-0x00000001805EF8F0
	private Sprite GetStoneSprite(long stoneId); // 0x00000001805F1050-0x00000001805F1150
	private void OnTopButtonClicked(); // 0x00000001805F26A0-0x00000001805F2930
	public void OpenRanking(); // 0x00000001805F29C0-0x00000001805F2AE0
	[IteratorStateMachine(typeof(_LoadDataThenOpenPanel_d__57))]
	private IEnumerator LoadDataThenOpenPanel(); // 0x00000001805F19C0-0x00000001805F1A30
	private void LoadRankingRewardTable(); // 0x00000001805F1A30-0x00000001805F1BD0
	private void BuildRewardTable(List<RankingRewardTier> tiers); // 0x00000001805EF200-0x00000001805EF820
	private void OnCloseRankingClicked(); // 0x00000001805F1EB0-0x00000001805F2100
	private void OnCloseDetailClicked(); // 0x00000001805F1CC0-0x00000001805F1EB0
	private void AnimateOpenPanel(GameObject panel, CanvasGroup canvasGroup); // 0x00000001805EDEB0-0x00000001805EDF10
	private void AnimateClosePanel(GameObject panel, CanvasGroup canvasGroup); // 0x00000001805EDA40-0x00000001805EDAA0
	private void DisplayRankings(List<TopRankingData> rankings); // 0x00000001805EFD90-0x00000001805EFFF0
	private void AnimateRankingItem(GameObject item, int index); // 0x00000001805EE380-0x00000001805EE640
	private void SetupRankingItem(Transform userT, TopRankingData ranking); // 0x00000001805F3180-0x00000001805F3700
	private void OnUserItemClicked(long userId); // 0x00000001805F2930-0x00000001805F29C0
	[IteratorStateMachine(typeof(_FetchUserDetail_d__68))]
	private IEnumerator FetchUserDetail(int userId); // 0x00000001805F0FD0-0x00000001805F1050
	private void SetupImgLevel(int level, Image imgLv); // 0x00000001805F2CE0-0x00000001805F2DB0
	private void DisplayUserDetail(UserDetailData userDetail); // 0x00000001805F0940-0x00000001805F0FD0
	private void AnimateText(GameObject textObj, float delay); // 0x00000001805EE840-0x00000001805EE960
	private void AnimateImage(GameObject imgObj, float delay); // 0x00000001805EDAA0-0x00000001805EDC50
	private void AnimateNumberText(UnityEngine.UI.Text textComponent, int fromValue, int toValue, float delay, float duration); // 0x00000001805EDC50-0x00000001805EDEB0
	private void DisplayPetList(List<UserPetInfo> pets); // 0x00000001805EF990-0x00000001805EFD90
	[IteratorStateMachine(typeof(_DelayedAnimatePetItem_d__75))]
	private IEnumerator DelayedAnimatePetItem(GameObject item, int index); // 0x00000001805EF8F0-0x00000001805EF990
	private void AnimatePetItem(GameObject item, int index); // 0x00000001805EE120-0x00000001805EE380
	private void SetupPetItem(GameObject item, UserPetInfo pet); // 0x00000001805F2DB0-0x00000001805F3180
	private void DisplayStoneList(List<StoneInfo> stones); // 0x00000001805EFFF0-0x00000001805F0390
	private void AnimateStoneItem(GameObject item, int index); // 0x00000001805EE640-0x00000001805EE840
	private void SetupStoneItem(GameObject item, StoneInfo stone); // 0x00000001805F3700-0x00000001805F39F0
	private bool TrySetupPetAnimation(Animator petAnimator, string petID); // 0x00000001805F3EE0-0x00000001805F44F0
	private void OnRewardButtonClicked(); // 0x00000001805F2370-0x00000001805F2480
	[IteratorStateMachine(typeof(_LoadTop30Ranking_d__83))]
	private IEnumerator LoadTop30Ranking(); // 0x00000001805F1BD0-0x00000001805F1C40
	private void DisplayTop30Panel(List<TopRankingData> rankings); // 0x00000001805F0390-0x00000001805F0940
	private void SetupTop30Item(GameObject item, TopRankingData ranking); // 0x00000001805F39F0-0x00000001805F3CE0
	private static void ApplyRowWeaponBadge(Transform row, string avatarNodeName, int imageId, string rarity, long userId); // 0x00000001805EEB50-0x00000001805EEC90
	private void AnimateTop30Item(GameObject item, int index); // 0x00000001805EE960-0x00000001805EEB50
	private void OnTop30ItemClicked(long userId); // 0x00000001805F2610-0x00000001805F26A0
	[IteratorStateMachine(typeof(_LoadUserDetailById_d__89))]
	private IEnumerator LoadUserDetailById(long userId); // 0x00000001805F1C40-0x00000001805F1CC0
	private void OnCloseTop30PanelClicked(); // 0x00000001805F2100-0x00000001805F22A0
	private void AnimatePanelOpen(GameObject panel); // 0x00000001805EE030-0x00000001805EE120
	private void AnimatePanelClose(GameObject panel, Action onComplete); // 0x00000001805EDF10-0x00000001805EE030
	private void OnDestroy(); // 0x00000001805F22A0-0x00000001805F2370
	[CompilerGenerated]
	private void _OnTopButtonClicked_b__55_0(); // 0x00000001805F4680-0x00000001805F4740
	[CompilerGenerated]
	private void _OnCloseRankingClicked_b__60_1(); // 0x00000001805F45C0-0x00000001805F4680
	[CompilerGenerated]
	private void _OnCloseDetailClicked_b__61_0(); // 0x00000001805F4500-0x00000001805F45C0
	[CompilerGenerated]
	private void _FetchUserDetail_b__68_0(UserDetailData userDetail); // 0x00000001805F44F0-0x00000001805F4500
	[CompilerGenerated]
	private void _OnCloseTop30PanelClicked_b__90_0(); // 0x0000000180484550-0x0000000180484580
}

