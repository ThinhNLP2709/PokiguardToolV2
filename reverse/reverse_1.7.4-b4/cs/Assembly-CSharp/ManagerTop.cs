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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ManagerTop : MonoBehaviour // TypeDefIndex: 2425
{
	// Fields
	public const string PANEL_KEY = "PanelXepHang"; // Metadata: 0x005F1FB9
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
	private const int MAX_ANIMATED_PET_ITEMS = 12; // Metadata: 0x005F1FC6

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2426
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__60_0; // 0x08
		public static Action __9__62_0; // 0x10
		public static Action<string> __9__70_1; // 0x18
		public static Action<string> __9__90_1; // 0x20
		public static Action<string> __9__96_1; // 0x28

		// Constructors
		static __c(); // 0x0000000180B7C210-0x0000000180B7C2B0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadRankingRewardTable_b__60_0(string error); // 0x0000000180B7C2B0-0x0000000180B7C330
		internal void _OnCloseRankingClicked_b__62_0(); // 0x0000000180B7C330-0x0000000180B7C4C0
		internal void _FetchUserDetail_b__70_1(string error); // 0x0000000180B7C4C0-0x0000000180B7C540
		internal void _LoadTop30Ranking_b__90_1(string error); // 0x0000000180B7C540-0x0000000180B7C5C0
		internal void _LoadUserDetailById_b__96_1(string error); // 0x0000000180B7C5C0-0x0000000180B7C640
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass48_0 // TypeDefIndex: 2427
	{
		// Fields
		public UserDetailData userDetail; // 0x10
		public bool success; // 0x18
		public ManagerTop __4__this; // 0x20
		public string username; // 0x28

		// Constructors
		public __c__DisplayClass48_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SearchUserByName_b__0(UserDetailData data); // 0x000000018076F420-0x000000018076F480
		internal void _SearchUserByName_b__1(string error); // 0x0000000180B7C640-0x0000000180B7C710
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass59_0 // TypeDefIndex: 2428
	{
		// Fields
		public List<TopRankingData> rankings; // 0x10
		public bool dataLoaded; // 0x18

		// Constructors
		public __c__DisplayClass59_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadDataThenOpenPanel_b__0(List<TopRankingData> data); // 0x000000018076F420-0x000000018076F480
		internal void _LoadDataThenOpenPanel_b__1(string error); // 0x0000000180B7C710-0x0000000180B7C7A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass68_0 // TypeDefIndex: 2429
	{
		// Fields
		public Transform userT; // 0x10
		public ManagerTop __4__this; // 0x18
		public TopRankingData ranking; // 0x20
		public Action __9__1; // 0x28

		// Constructors
		public __c__DisplayClass68_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupRankingItem_b__0(); // 0x0000000180B7C7A0-0x0000000180B7CA40
		internal void _SetupRankingItem_b__1(); // 0x0000000180B7CA40-0x0000000180B7CB00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass78_0 // TypeDefIndex: 2430
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10

		// Constructors
		public __c__DisplayClass78_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AnimateNumberText_b__0(float val); // 0x000000018097DB90-0x000000018097DC40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass90_0 // TypeDefIndex: 2431
	{
		// Fields
		public List<TopRankingData> top30Rankings; // 0x10
		public bool success; // 0x18

		// Constructors
		public __c__DisplayClass90_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadTop30Ranking_b__0(List<TopRankingData> data); // 0x000000018076F420-0x000000018076F480
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass91_0 // TypeDefIndex: 2432
	{
		// Fields
		public long userId; // 0x10
		public ManagerTop __4__this; // 0x18

		// Constructors
		public __c__DisplayClass91_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DisplayTop30Panel_b__0(); // 0x0000000180B7CB00-0x0000000180B7CBE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass96_0 // TypeDefIndex: 2433
	{
		// Fields
		public UserDetailData userDetail; // 0x10
		public bool success; // 0x18

		// Constructors
		public __c__DisplayClass96_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadUserDetailById_b__0(UserDetailData data); // 0x000000018076F420-0x000000018076F480
	}

	[CompilerGenerated]
	private sealed class _DelayedAnimatePetItem_d__82 : IEnumerator<object> // TypeDefIndex: 2434
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B7CBE0-0x0000000180B7CC90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B7CC90-0x0000000180B7CCD0
	}

	[CompilerGenerated]
	private sealed class _FetchUserDetail_d__70 : IEnumerator<object> // TypeDefIndex: 2435
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B7CCD0-0x0000000180B7CFE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B7CFE0-0x0000000180B7D020
	}

	[CompilerGenerated]
	private sealed class _HideSearchErrorAfterDelay_d__50 : IEnumerator<object> // TypeDefIndex: 2436
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B7D020-0x0000000180B7D230
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B7D230-0x0000000180B7D270
	}

	[CompilerGenerated]
	private sealed class _LoadDataThenOpenPanel_d__59 : IEnumerator<object> // TypeDefIndex: 2437
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
		private bool MoveNext(); // 0x0000000180B7D270-0x0000000180B7D840
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B7D840-0x0000000180B7D880
	}

	[CompilerGenerated]
	private sealed class _LoadTop30Ranking_d__90 : IEnumerator<object> // TypeDefIndex: 2438
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
		private bool MoveNext(); // 0x0000000180B7D880-0x0000000180B7DD40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B7DD40-0x0000000180B7DD80
	}

	[CompilerGenerated]
	private sealed class _LoadUserDetailById_d__96 : IEnumerator<object> // TypeDefIndex: 2439
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
		private bool MoveNext(); // 0x0000000180B7DD80-0x0000000180B7E250
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B7E250-0x0000000180B7E290
	}

	[CompilerGenerated]
	private sealed class _SearchUserByName_d__48 : IEnumerator<object> // TypeDefIndex: 2440
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
		private bool MoveNext(); // 0x0000000180B7E290-0x0000000180B7E7E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B7E7E0-0x0000000180B7E820
	}

	// Constructors
	public ManagerTop(); // 0x0000000180B7BB00-0x0000000180B7BEC0
	static ManagerTop(); // 0x0000000180B7BEC0-0x0000000180B7BFC0

	// Methods
	private void Awake(); // 0x0000000180B6F6C0-0x0000000180B6FE60
	private void OnSearchButtonClicked(); // 0x0000000180B6FE60-0x0000000180B70100
	[IteratorStateMachine(typeof(_SearchUserByName_d__48))]
	private IEnumerator SearchUserByName(string username); // 0x0000000180B70100-0x0000000180B70210
	private void ShowSearchError(string message); // 0x0000000180B70210-0x0000000180B70530
	[IteratorStateMachine(typeof(_HideSearchErrorAfterDelay_d__50))]
	private IEnumerator HideSearchErrorAfterDelay(float delay); // 0x0000000180B70530-0x0000000180B705F0
	private void ShowLoadingIndicator(); // 0x0000000180B705F0-0x0000000180B70740
	private void HideLoadingIndicator(); // 0x0000000180B70740-0x0000000180B70910
	private void SetupCanvasGroups(); // 0x0000000180B70910-0x0000000180B70CF0
	private void InitializeStoneDictionary(); // 0x0000000180B70CF0-0x0000000180B71790
	private int CountValidSprites(Sprite[] sprites); // 0x0000000180B71790-0x0000000180B718F0
	private Sprite GetStoneSprite(long stoneId); // 0x0000000180B718F0-0x0000000180B71A50
	private void OnTopButtonClicked(); // 0x0000000180B71A50-0x0000000180B71C90
	public void OpenRanking(); // 0x0000000180B71C90-0x0000000180B71EC0
	[IteratorStateMachine(typeof(_LoadDataThenOpenPanel_d__59))]
	private IEnumerator LoadDataThenOpenPanel(); // 0x0000000180B71EC0-0x0000000180B71F60
	private void LoadRankingRewardTable(); // 0x0000000180B71F60-0x0000000180B72210
	private void BuildRewardTable(List<RankingRewardTier> tiers); // 0x0000000180B72210-0x0000000180B72F00
	private void OnCloseRankingClicked(); // 0x0000000180B72F00-0x0000000180B73290
	private void OnCloseDetailClicked(); // 0x0000000180B73290-0x0000000180B73520
	private void AnimateOpenPanel(GameObject panel, CanvasGroup canvasGroup); // 0x0000000180B73520-0x0000000180B73580
	private void AnimateClosePanel(GameObject panel, CanvasGroup canvasGroup); // 0x0000000180B73580-0x0000000180B735F0
	private void DisplayRankings(List<TopRankingData> rankings); // 0x0000000180B735F0-0x0000000180B73930
	private void AnimateRankingItem(GameObject item, int index); // 0x0000000180B73930-0x0000000180B73DF0
	private void SetupRankingItem(Transform userT, TopRankingData ranking); // 0x0000000180B73DF0-0x0000000180B74AD0
	private void OnUserItemClicked(long userId); // 0x0000000180B74AD0-0x0000000180B74B80
	[IteratorStateMachine(typeof(_FetchUserDetail_d__70))]
	private IEnumerator FetchUserDetail(int userId); // 0x0000000180B74B80-0x0000000180B74C30
	private RankUserDetailPopup EnsureDetailPopup(); // 0x0000000180B74C30-0x0000000180B74F20
	private void SetupImgLevel(int level, Image imgLv); // 0x0000000180B74F20-0x0000000180B75060
	private void DisplayUserDetail(UserDetailData userDetail); // 0x0000000180B75060-0x0000000180B75FC0
	private static void FitText(UnityEngine.UI.Text t, int minSize, int maxSize); // 0x0000000180B75FC0-0x0000000180B76210
	private void AnimateText(GameObject textObj, float delay); // 0x0000000180B76210-0x0000000180B76380
	private void AnimateImage(GameObject imgObj, float delay); // 0x0000000180B76380-0x0000000180B76620
	private void AnimateNumberText(UnityEngine.UI.Text textComponent, int fromValue, int toValue, float delay, float duration); // 0x0000000180B76620-0x0000000180B768F0
	private void DisplayPetList(List<UserPetInfo> pets); // 0x0000000180B768F0-0x0000000180B76FE0
	private void ShowPetItemInstantly(GameObject item); // 0x0000000180B76FE0-0x0000000180B77260
	[IteratorStateMachine(typeof(_DelayedAnimatePetItem_d__82))]
	private IEnumerator DelayedAnimatePetItem(GameObject item, int index); // 0x0000000180B77260-0x0000000180B77370
	private void AnimatePetItem(GameObject item, int index); // 0x0000000180B77370-0x0000000180B777D0
	private void SetupPetItem(GameObject item, UserPetInfo pet); // 0x0000000180B777D0-0x0000000180B77F50
	private void DisplayStoneList(List<StoneInfo> stones); // 0x0000000180B77F50-0x0000000180B78510
	private void AnimateStoneItem(GameObject item, int index); // 0x0000000180B78510-0x0000000180B78830
	private void SetupStoneItem(GameObject item, StoneInfo stone); // 0x0000000180B78830-0x0000000180B78DF0
	private bool TrySetupPetAnimation(Animator petAnimator, string petID); // 0x0000000180B78DF0-0x0000000180B79870
	private void OnRewardButtonClicked(); // 0x0000000180B79870-0x0000000180B79A50
	[IteratorStateMachine(typeof(_LoadTop30Ranking_d__90))]
	private IEnumerator LoadTop30Ranking(); // 0x0000000180B79A50-0x0000000180B79AF0
	private void DisplayTop30Panel(List<TopRankingData> rankings); // 0x0000000180B79AF0-0x0000000180B7A410
	private void SetupTop30Item(GameObject item, TopRankingData ranking); // 0x0000000180B7A410-0x0000000180B7AB20
	private static void ApplyRowWeaponBadge(Transform row, string avatarNodeName, int imageId, string rarity, long userId); // 0x0000000180B7AB20-0x0000000180B7AE70
	private void AnimateTop30Item(GameObject item, int index); // 0x0000000180B7AE70-0x0000000180B7B180
	private void OnTop30ItemClicked(long userId); // 0x0000000180B7B180-0x0000000180B7B240
	[IteratorStateMachine(typeof(_LoadUserDetailById_d__96))]
	private IEnumerator LoadUserDetailById(long userId); // 0x0000000180B7B240-0x0000000180B7B300
	private void OnCloseTop30PanelClicked(); // 0x0000000180B7B300-0x0000000180B7B450
	private void AnimatePanelOpen(GameObject panel); // 0x0000000180B7B450-0x0000000180B7B640
	private void AnimatePanelClose(GameObject panel, Action onComplete); // 0x0000000180B7B640-0x0000000180B7B860
	private void OnDestroy(); // 0x0000000180B7B860-0x0000000180B7BB00
	[CompilerGenerated]
	private void _OnTopButtonClicked_b__57_0(); // 0x0000000180B7BFC0-0x0000000180B7C080
	[CompilerGenerated]
	private void _OnCloseRankingClicked_b__62_1(); // 0x0000000180B7C080-0x0000000180B7C140
	[CompilerGenerated]
	private void _OnCloseDetailClicked_b__63_0(); // 0x0000000180B7C140-0x0000000180B7C200
	[CompilerGenerated]
	private void _FetchUserDetail_b__70_0(UserDetailData userDetail); // 0x0000000180B7C200-0x0000000180B7C210
	[CompilerGenerated]
	private void _OnCloseTop30PanelClicked_b__97_0(); // 0x0000000180883810-0x0000000180883890
}

