/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ManagerTop : MonoBehaviour // TypeDefIndex: 2418
{
	// Fields
	public const string PANEL_KEY = "PanelXepHang"; // Metadata: 0x005F0BA2
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
	private static readonly CultureInfo VN; // 0x00
	private static readonly DetailUserColumnLayout.Spec DETAIL_COLUMN; // 0x08
	private GameObject _rewardRowTemplate; // 0x158
	private Transform _rewardRowsParent; // 0x160
	[Header("Loading")]
	public GameObject loadingIndicator; // 0x168
	private RankUserDetailPopup detailPopup; // 0x170
	private const int MAX_ANIMATED_PET_ITEMS = 12; // Metadata: 0x005F0BAF

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2419
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__60_0; // 0x08
		public static Action __9__62_0; // 0x10
		public static Action<string> __9__70_1; // 0x18
		public static Action<string> __9__90_1; // 0x20
		public static Action<string> __9__96_1; // 0x28

		// Constructors
		static __c(); // 0x0000000180B6EFC0-0x0000000180B6F060
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadRankingRewardTable_b__60_0(string error); // 0x0000000180B6F060-0x0000000180B6F0E0
		internal void _OnCloseRankingClicked_b__62_0(); // 0x0000000180B6F0E0-0x0000000180B6F270
		internal void _FetchUserDetail_b__70_1(string error); // 0x0000000180B6F270-0x0000000180B6F2F0
		internal void _LoadTop30Ranking_b__90_1(string error); // 0x0000000180B6F2F0-0x0000000180B6F370
		internal void _LoadUserDetailById_b__96_1(string error); // 0x0000000180B6F370-0x0000000180B6F3F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass48_0 // TypeDefIndex: 2420
	{
		// Fields
		public UserDetailData userDetail; // 0x10
		public bool success; // 0x18
		public ManagerTop __4__this; // 0x20
		public string username; // 0x28

		// Constructors
		public __c__DisplayClass48_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SearchUserByName_b__0(UserDetailData data); // 0x000000018076D550-0x000000018076D5B0
		internal void _SearchUserByName_b__1(string error); // 0x0000000180B6F3F0-0x0000000180B6F4C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass59_0 // TypeDefIndex: 2421
	{
		// Fields
		public List<TopRankingData> rankings; // 0x10
		public bool dataLoaded; // 0x18

		// Constructors
		public __c__DisplayClass59_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadDataThenOpenPanel_b__0(List<TopRankingData> data); // 0x000000018076D550-0x000000018076D5B0
		internal void _LoadDataThenOpenPanel_b__1(string error); // 0x0000000180B6F4C0-0x0000000180B6F550
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass68_0 // TypeDefIndex: 2422
	{
		// Fields
		public Transform userT; // 0x10
		public ManagerTop __4__this; // 0x18
		public TopRankingData ranking; // 0x20
		public Action __9__1; // 0x28

		// Constructors
		public __c__DisplayClass68_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupRankingItem_b__0(); // 0x0000000180B6F550-0x0000000180B6F7F0
		internal void _SetupRankingItem_b__1(); // 0x0000000180B6F7F0-0x0000000180B6F8B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass78_0 // TypeDefIndex: 2423
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10

		// Constructors
		public __c__DisplayClass78_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AnimateNumberText_b__0(float val); // 0x000000018097A590-0x000000018097A640
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass90_0 // TypeDefIndex: 2424
	{
		// Fields
		public List<TopRankingData> top30Rankings; // 0x10
		public bool success; // 0x18

		// Constructors
		public __c__DisplayClass90_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadTop30Ranking_b__0(List<TopRankingData> data); // 0x000000018076D550-0x000000018076D5B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass91_0 // TypeDefIndex: 2425
	{
		// Fields
		public long userId; // 0x10
		public ManagerTop __4__this; // 0x18

		// Constructors
		public __c__DisplayClass91_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DisplayTop30Panel_b__0(); // 0x0000000180B6F8B0-0x0000000180B6F990
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass96_0 // TypeDefIndex: 2426
	{
		// Fields
		public UserDetailData userDetail; // 0x10
		public bool success; // 0x18

		// Constructors
		public __c__DisplayClass96_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadUserDetailById_b__0(UserDetailData data); // 0x000000018076D550-0x000000018076D5B0
	}

	[CompilerGenerated]
	private sealed class _DelayedAnimatePetItem_d__82 : IEnumerator<object> // TypeDefIndex: 2427
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerTop __4__this; // 0x20
		public GameObject item; // 0x28
		public int index; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DelayedAnimatePetItem_d__82(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B6F990-0x0000000180B6FA40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B6FA40-0x0000000180B6FA80
	}

	[CompilerGenerated]
	private sealed class _FetchUserDetail_d__70 : IEnumerator<object> // TypeDefIndex: 2428
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ManagerTop __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FetchUserDetail_d__70(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B6FA80-0x0000000180B6FD60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B6FD60-0x0000000180B6FDA0
	}

	[CompilerGenerated]
	private sealed class _HideSearchErrorAfterDelay_d__50 : IEnumerator<object> // TypeDefIndex: 2429
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerTop __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HideSearchErrorAfterDelay_d__50(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B6FDA0-0x0000000180B6FFB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B6FFB0-0x0000000180B6FFF0
	}

	[CompilerGenerated]
	private sealed class _LoadDataThenOpenPanel_d__59 : IEnumerator<object> // TypeDefIndex: 2430
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerTop __4__this; // 0x20
		private __c__DisplayClass59_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadDataThenOpenPanel_d__59(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180B6FFF0-0x0000000180B705A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B705A0-0x0000000180B705E0
	}

	[CompilerGenerated]
	private sealed class _LoadTop30Ranking_d__90 : IEnumerator<object> // TypeDefIndex: 2431
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerTop __4__this; // 0x20
		private __c__DisplayClass90_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadTop30Ranking_d__90(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180B705E0-0x0000000180B70A60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B70A60-0x0000000180B70AA0
	}

	[CompilerGenerated]
	private sealed class _LoadUserDetailById_d__96 : IEnumerator<object> // TypeDefIndex: 2432
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long userId; // 0x20
		public ManagerTop __4__this; // 0x28
		private __c__DisplayClass96_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadUserDetailById_d__96(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x0000000180B70AA0-0x0000000180B70F40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B70F40-0x0000000180B70F80
	}

	[CompilerGenerated]
	private sealed class _SearchUserByName_d__48 : IEnumerator<object> // TypeDefIndex: 2433
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerTop __4__this; // 0x20
		public string username; // 0x28
		private __c__DisplayClass48_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SearchUserByName_d__48(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x0000000180B70F80-0x0000000180B714B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B714B0-0x0000000180B714F0
	}

	// Constructors
	public ManagerTop(); // 0x0000000180B6E790-0x0000000180B6EB50
	static ManagerTop(); // 0x0000000180B6EB50-0x0000000180B6EC50

	// Methods
	private void Awake(); // 0x0000000180B62380-0x0000000180B62B20
	private void OnSearchButtonClicked(); // 0x0000000180B62B20-0x0000000180B62DC0
	[IteratorStateMachine(typeof(_SearchUserByName_d__48))]
	private IEnumerator SearchUserByName(string username); // 0x0000000180B62DC0-0x0000000180B62ED0
	private void ShowSearchError(string message); // 0x0000000180B62ED0-0x0000000180B631F0
	[IteratorStateMachine(typeof(_HideSearchErrorAfterDelay_d__50))]
	private IEnumerator HideSearchErrorAfterDelay(float delay); // 0x0000000180B631F0-0x0000000180B632B0
	private void ShowLoadingIndicator(); // 0x0000000180B632B0-0x0000000180B63400
	private void HideLoadingIndicator(); // 0x0000000180B63400-0x0000000180B635D0
	private void SetupCanvasGroups(); // 0x0000000180B635D0-0x0000000180B639B0
	private void InitializeStoneDictionary(); // 0x0000000180B639B0-0x0000000180B64450
	private int CountValidSprites(Sprite[] sprites); // 0x0000000180B64450-0x0000000180B645B0
	private Sprite GetStoneSprite(long stoneId); // 0x0000000180B645B0-0x0000000180B64710
	private void OnTopButtonClicked(); // 0x0000000180B64710-0x0000000180B64950
	public void OpenRanking(); // 0x0000000180B64950-0x0000000180B64B80
	[IteratorStateMachine(typeof(_LoadDataThenOpenPanel_d__59))]
	private IEnumerator LoadDataThenOpenPanel(); // 0x0000000180B64B80-0x0000000180B64C20
	private void LoadRankingRewardTable(); // 0x0000000180B64C20-0x0000000180B64EA0
	private void BuildRewardTable(List<RankingRewardTier> tiers); // 0x0000000180B64EA0-0x0000000180B65B90
	private void OnCloseRankingClicked(); // 0x0000000180B65B90-0x0000000180B65F20
	private void OnCloseDetailClicked(); // 0x0000000180B65F20-0x0000000180B661B0
	private void AnimateOpenPanel(GameObject panel, CanvasGroup canvasGroup); // 0x0000000180B661B0-0x0000000180B66210
	private void AnimateClosePanel(GameObject panel, CanvasGroup canvasGroup); // 0x0000000180B66210-0x0000000180B66280
	private void DisplayRankings(List<TopRankingData> rankings); // 0x0000000180B66280-0x0000000180B665C0
	private void AnimateRankingItem(GameObject item, int index); // 0x0000000180B665C0-0x0000000180B66A80
	private void SetupRankingItem(Transform userT, TopRankingData ranking); // 0x0000000180B66A80-0x0000000180B67760
	private void OnUserItemClicked(long userId); // 0x0000000180B67760-0x0000000180B67810
	[IteratorStateMachine(typeof(_FetchUserDetail_d__70))]
	private IEnumerator FetchUserDetail(int userId); // 0x0000000180B67810-0x0000000180B678C0
	private RankUserDetailPopup EnsureDetailPopup(); // 0x0000000180B678C0-0x0000000180B67BB0
	private void SetupImgLevel(int level, Image imgLv); // 0x0000000180B67BB0-0x0000000180B67CF0
	private void DisplayUserDetail(UserDetailData userDetail); // 0x0000000180B67CF0-0x0000000180B68C50
	private static void FitText(UnityEngine.UI.Text t, int minSize, int maxSize); // 0x0000000180B68C50-0x0000000180B68EA0
	private void AnimateText(GameObject textObj, float delay); // 0x0000000180B68EA0-0x0000000180B69010
	private void AnimateImage(GameObject imgObj, float delay); // 0x0000000180B69010-0x0000000180B692B0
	private void AnimateNumberText(UnityEngine.UI.Text textComponent, int fromValue, int toValue, float delay, float duration); // 0x0000000180B692B0-0x0000000180B69580
	private void DisplayPetList(List<UserPetInfo> pets); // 0x0000000180B69580-0x0000000180B69C70
	private void ShowPetItemInstantly(GameObject item); // 0x0000000180B69C70-0x0000000180B69EF0
	[IteratorStateMachine(typeof(_DelayedAnimatePetItem_d__82))]
	private IEnumerator DelayedAnimatePetItem(GameObject item, int index); // 0x0000000180B69EF0-0x0000000180B6A000
	private void AnimatePetItem(GameObject item, int index); // 0x0000000180B6A000-0x0000000180B6A460
	private void SetupPetItem(GameObject item, UserPetInfo pet); // 0x0000000180B6A460-0x0000000180B6ABE0
	private void DisplayStoneList(List<StoneInfo> stones); // 0x0000000180B6ABE0-0x0000000180B6B1A0
	private void AnimateStoneItem(GameObject item, int index); // 0x0000000180B6B1A0-0x0000000180B6B4C0
	private void SetupStoneItem(GameObject item, StoneInfo stone); // 0x0000000180B6B4C0-0x0000000180B6BA80
	private bool TrySetupPetAnimation(Animator petAnimator, string petID); // 0x0000000180B6BA80-0x0000000180B6C500
	private void OnRewardButtonClicked(); // 0x0000000180B6C500-0x0000000180B6C6E0
	[IteratorStateMachine(typeof(_LoadTop30Ranking_d__90))]
	private IEnumerator LoadTop30Ranking(); // 0x0000000180B6C6E0-0x0000000180B6C780
	private void DisplayTop30Panel(List<TopRankingData> rankings); // 0x0000000180B6C780-0x0000000180B6D0A0
	private void SetupTop30Item(GameObject item, TopRankingData ranking); // 0x0000000180B6D0A0-0x0000000180B6D7B0
	private static void ApplyRowWeaponBadge(Transform row, string avatarNodeName, int imageId, string rarity, long userId); // 0x0000000180B6D7B0-0x0000000180B6DB00
	private void AnimateTop30Item(GameObject item, int index); // 0x0000000180B6DB00-0x0000000180B6DE10
	private void OnTop30ItemClicked(long userId); // 0x0000000180B6DE10-0x0000000180B6DED0
	[IteratorStateMachine(typeof(_LoadUserDetailById_d__96))]
	private IEnumerator LoadUserDetailById(long userId); // 0x0000000180B6DED0-0x0000000180B6DF90
	private void OnCloseTop30PanelClicked(); // 0x0000000180B6DF90-0x0000000180B6E0E0
	private void AnimatePanelOpen(GameObject panel); // 0x0000000180B6E0E0-0x0000000180B6E2D0
	private void AnimatePanelClose(GameObject panel, Action onComplete); // 0x0000000180B6E2D0-0x0000000180B6E4F0
	private void OnDestroy(); // 0x0000000180B6E4F0-0x0000000180B6E790
	[CompilerGenerated]
	private void _OnTopButtonClicked_b__57_0(); // 0x0000000180B6EC50-0x0000000180B6ED10
	[CompilerGenerated]
	private void _OnCloseRankingClicked_b__62_1(); // 0x0000000180B6ED10-0x0000000180B6EDD0
	[CompilerGenerated]
	private void _OnCloseDetailClicked_b__63_0(); // 0x0000000180B6EDD0-0x0000000180B6EE90
	[CompilerGenerated]
	private void _FetchUserDetail_b__70_0(UserDetailData userDetail); // 0x0000000180B6EE90-0x0000000180B6EFC0
	[CompilerGenerated]
	private void _OnCloseTop30PanelClicked_b__97_0(); // 0x00000001808814B0-0x0000000180881530
}

