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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerTop : MonoBehaviour // TypeDefIndex: 2024
{
	// Fields
	public const string PANEL_KEY = "PanelXepHang"; // Metadata: 0x0068DE9C
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
	private const int MAX_ANIMATED_PET_ITEMS = 12; // Metadata: 0x0068DEA9

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2025
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__60_0; // 0x08
		public static Action __9__62_0; // 0x10
		public static Action<string> __9__70_1; // 0x18
		public static Action<string> __9__88_1; // 0x20
		public static Action<string> __9__94_1; // 0x28

		// Constructors
		static __c(); // 0x0000000180727540-0x00000001807275B0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadRankingRewardTable_b__60_0(string error); // 0x0000000180726B20-0x0000000180726B90
		internal void _OnCloseRankingClicked_b__62_0(); // 0x0000000180726C80-0x0000000180726DC0
		internal void _FetchUserDetail_b__70_1(string error); // 0x0000000180726AB0-0x0000000180726B20
		internal void _LoadTop30Ranking_b__88_1(string error); // 0x0000000180726BA0-0x0000000180726C10
		internal void _LoadUserDetailById_b__94_1(string error); // 0x0000000180726C10-0x0000000180726C80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass48_0 // TypeDefIndex: 2026
	{
		// Fields
		public UserDetailData userDetail; // 0x10
		public bool success; // 0x18
		public ManagerTop __4__this; // 0x20
		public string username; // 0x28

		// Constructors
		public __c__DisplayClass48_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SearchUserByName_b__0(UserDetailData data); // 0x00000001804F8C00-0x00000001804F8C20
		internal void _SearchUserByName_b__1(string error); // 0x0000000180726FC0-0x0000000180727080
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass59_0 // TypeDefIndex: 2027
	{
		// Fields
		public List<TopRankingData> rankings; // 0x10
		public bool dataLoaded; // 0x18

		// Constructors
		public __c__DisplayClass59_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadDataThenOpenPanel_b__0(List<TopRankingData> data); // 0x00000001804F8C00-0x00000001804F8C20
		internal void _LoadDataThenOpenPanel_b__1(string error); // 0x0000000180727080-0x0000000180727100
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass68_0 // TypeDefIndex: 2028
	{
		// Fields
		public Transform userT; // 0x10
		public ManagerTop __4__this; // 0x18
		public TopRankingData ranking; // 0x20
		public Action __9__1; // 0x28

		// Constructors
		public __c__DisplayClass68_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupRankingItem_b__0(); // 0x0000000180727180-0x0000000180727370
		internal void _SetupRankingItem_b__1(); // 0x0000000180727370-0x0000000180727430
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass76_0 // TypeDefIndex: 2029
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10

		// Constructors
		public __c__DisplayClass76_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AnimateNumberText_b__0(float val); // 0x0000000180621220-0x0000000180621280
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass88_0 // TypeDefIndex: 2030
	{
		// Fields
		public List<TopRankingData> top30Rankings; // 0x10
		public bool success; // 0x18

		// Constructors
		public __c__DisplayClass88_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadTop30Ranking_b__0(List<TopRankingData> data); // 0x00000001804F8C00-0x00000001804F8C20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass89_0 // TypeDefIndex: 2031
	{
		// Fields
		public long userId; // 0x10
		public ManagerTop __4__this; // 0x18

		// Constructors
		public __c__DisplayClass89_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _DisplayTop30Panel_b__0(); // 0x0000000180727430-0x00000001807274D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass94_0 // TypeDefIndex: 2032
	{
		// Fields
		public UserDetailData userDetail; // 0x10
		public bool success; // 0x18

		// Constructors
		public __c__DisplayClass94_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadUserDetailById_b__0(UserDetailData data); // 0x00000001804F8C00-0x00000001804F8C20
	}

	[CompilerGenerated]
	private sealed class _DelayedAnimatePetItem_d__80 : IEnumerator<object> // TypeDefIndex: 2033
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerTop __4__this; // 0x20
		public GameObject item; // 0x28
		public int index; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DelayedAnimatePetItem_d__80(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001807238F0-0x0000000180723960
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180723960-0x00000001807239A0
	}

	[CompilerGenerated]
	private sealed class _FetchUserDetail_d__70 : IEnumerator<object> // TypeDefIndex: 2034
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ManagerTop __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FetchUserDetail_d__70(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180723F60-0x0000000180724160
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180724160-0x00000001807241A0
	}

	[CompilerGenerated]
	private sealed class _HideSearchErrorAfterDelay_d__50 : IEnumerator<object> // TypeDefIndex: 2035
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerTop __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HideSearchErrorAfterDelay_d__50(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001807242E0-0x00000001807243E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807243E0-0x0000000180724420
	}

	[CompilerGenerated]
	private sealed class _LoadDataThenOpenPanel_d__59 : IEnumerator<object> // TypeDefIndex: 2036
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerTop __4__this; // 0x20
		private __c__DisplayClass59_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadDataThenOpenPanel_d__59(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180724420-0x0000000180724900
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180724900-0x0000000180724940
	}

	[CompilerGenerated]
	private sealed class _LoadTop30Ranking_d__88 : IEnumerator<object> // TypeDefIndex: 2037
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerTop __4__this; // 0x20
		private __c__DisplayClass88_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadTop30Ranking_d__88(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180724B60-0x0000000180724E20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180724E20-0x0000000180724E60
	}

	[CompilerGenerated]
	private sealed class _LoadUserDetailById_d__94 : IEnumerator<object> // TypeDefIndex: 2038
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long userId; // 0x20
		public ManagerTop __4__this; // 0x28
		private __c__DisplayClass94_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadUserDetailById_d__94(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x0000000180724E60-0x0000000180725140
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180725140-0x0000000180725180
	}

	[CompilerGenerated]
	private sealed class _SearchUserByName_d__48 : IEnumerator<object> // TypeDefIndex: 2039
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerTop __4__this; // 0x20
		public string username; // 0x28
		private __c__DisplayClass48_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SearchUserByName_d__48(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x0000000180725350-0x0000000180725600
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180725600-0x0000000180725640
	}

	// Constructors
	public ManagerTop(); // 0x000000018071D0F0-0x000000018071D290
	static ManagerTop(); // 0x000000018071D040-0x000000018071D0F0

	// Methods
	private void Awake(); // 0x0000000180716EE0-0x0000000180717450
	private void OnSearchButtonClicked(); // 0x000000018071AB60-0x000000018071ACF0
	[IteratorStateMachine(typeof(_SearchUserByName_d__48))]
	private IEnumerator SearchUserByName(string username); // 0x000000018071B1C0-0x000000018071B250
	private void ShowSearchError(string message); // 0x000000018071C660-0x000000018071C7E0
	[IteratorStateMachine(typeof(_HideSearchErrorAfterDelay_d__50))]
	private IEnumerator HideSearchErrorAfterDelay(float delay); // 0x00000001807198E0-0x0000000180719960
	private void ShowLoadingIndicator(); // 0x000000018071C4F0-0x000000018071C570
	private void HideLoadingIndicator(); // 0x0000000180719830-0x00000001807198E0
	private void SetupCanvasGroups(); // 0x000000018071B250-0x000000018071B3C0
	private void InitializeStoneDictionary(); // 0x0000000180719960-0x000000018071A0A0
	private int CountValidSprites(Sprite[] sprites); // 0x0000000180717C00-0x0000000180717CD0
	private Sprite GetStoneSprite(long stoneId); // 0x0000000180719730-0x0000000180719830
	private void OnTopButtonClicked(); // 0x000000018071AD80-0x000000018071B010
	public void OpenRanking(); // 0x000000018071B0A0-0x000000018071B1C0
	[IteratorStateMachine(typeof(_LoadDataThenOpenPanel_d__59))]
	private IEnumerator LoadDataThenOpenPanel(); // 0x000000018071A0A0-0x000000018071A110
	private void LoadRankingRewardTable(); // 0x000000018071A110-0x000000018071A2B0
	private void BuildRewardTable(List<RankingRewardTier> tiers); // 0x0000000180717450-0x0000000180717C00
	private void OnCloseRankingClicked(); // 0x000000018071A590-0x000000018071A7E0
	private void OnCloseDetailClicked(); // 0x000000018071A3A0-0x000000018071A590
	private void AnimateOpenPanel(GameObject panel, CanvasGroup canvasGroup); // 0x0000000180716110-0x0000000180716170
	private void AnimateClosePanel(GameObject panel, CanvasGroup canvasGroup); // 0x0000000180715CA0-0x0000000180715D00
	private void DisplayRankings(List<TopRankingData> rankings); // 0x00000001807181C0-0x0000000180718420
	private void AnimateRankingItem(GameObject item, int index); // 0x00000001807165D0-0x0000000180716890
	private void SetupRankingItem(Transform userT, TopRankingData ranking); // 0x000000018071B860-0x000000018071BE30
	private void OnUserItemClicked(long userId); // 0x000000018071B010-0x000000018071B0A0
	[IteratorStateMachine(typeof(_FetchUserDetail_d__70))]
	private IEnumerator FetchUserDetail(int userId); // 0x00000001807195F0-0x0000000180719670
	private void SetupImgLevel(int level, Image imgLv); // 0x000000018071B3C0-0x000000018071B490
	private void DisplayUserDetail(UserDetailData userDetail); // 0x0000000180718D70-0x00000001807195F0
	private static void FitText(UnityEngine.UI.Text t, int minSize, int maxSize); // 0x0000000180719670-0x0000000180719730
	private void AnimateText(GameObject textObj, float delay); // 0x0000000180716A90-0x0000000180716BB0
	private void AnimateImage(GameObject imgObj, float delay); // 0x0000000180715D00-0x0000000180715EB0
	private void AnimateNumberText(UnityEngine.UI.Text textComponent, int fromValue, int toValue, float delay, float duration); // 0x0000000180715EB0-0x0000000180716110
	private void DisplayPetList(List<UserPetInfo> pets); // 0x0000000180717D70-0x00000001807181C0
	private void ShowPetItemInstantly(GameObject item); // 0x000000018071C570-0x000000018071C660
	[IteratorStateMachine(typeof(_DelayedAnimatePetItem_d__80))]
	private IEnumerator DelayedAnimatePetItem(GameObject item, int index); // 0x0000000180717CD0-0x0000000180717D70
	private void AnimatePetItem(GameObject item, int index); // 0x0000000180716380-0x00000001807165D0
	private void SetupPetItem(GameObject item, UserPetInfo pet); // 0x000000018071B490-0x000000018071B860
	private void DisplayStoneList(List<StoneInfo> stones); // 0x0000000180718420-0x00000001807187C0
	private void AnimateStoneItem(GameObject item, int index); // 0x0000000180716890-0x0000000180716A90
	private void SetupStoneItem(GameObject item, StoneInfo stone); // 0x000000018071BE30-0x000000018071C120
	private bool TrySetupPetAnimation(Animator petAnimator, string petID); // 0x000000018071C7E0-0x000000018071CDF0
	private void OnRewardButtonClicked(); // 0x000000018071AA50-0x000000018071AB60
	[IteratorStateMachine(typeof(_LoadTop30Ranking_d__88))]
	private IEnumerator LoadTop30Ranking(); // 0x000000018071A2B0-0x000000018071A320
	private void DisplayTop30Panel(List<TopRankingData> rankings); // 0x00000001807187C0-0x0000000180718D70
	private void SetupTop30Item(GameObject item, TopRankingData ranking); // 0x000000018071C120-0x000000018071C4F0
	private static void ApplyRowWeaponBadge(Transform row, string avatarNodeName, int imageId, string rarity, long userId); // 0x0000000180716DA0-0x0000000180716EE0
	private void AnimateTop30Item(GameObject item, int index); // 0x0000000180716BB0-0x0000000180716DA0
	private void OnTop30ItemClicked(long userId); // 0x000000018071ACF0-0x000000018071AD80
	[IteratorStateMachine(typeof(_LoadUserDetailById_d__94))]
	private IEnumerator LoadUserDetailById(long userId); // 0x000000018071A320-0x000000018071A3A0
	private void OnCloseTop30PanelClicked(); // 0x000000018071A7E0-0x000000018071A980
	private void AnimatePanelOpen(GameObject panel); // 0x0000000180716290-0x0000000180716380
	private void AnimatePanelClose(GameObject panel, Action onComplete); // 0x0000000180716170-0x0000000180716290
	private void OnDestroy(); // 0x000000018071A980-0x000000018071AA50
	[CompilerGenerated]
	private void _OnTopButtonClicked_b__57_0(); // 0x000000018071CF80-0x000000018071D040
	[CompilerGenerated]
	private void _OnCloseRankingClicked_b__62_1(); // 0x000000018071CEC0-0x000000018071CF80
	[CompilerGenerated]
	private void _OnCloseDetailClicked_b__63_0(); // 0x000000018071CE00-0x000000018071CEC0
	[CompilerGenerated]
	private void _FetchUserDetail_b__70_0(UserDetailData userDetail); // 0x000000018071CDF0-0x000000018071CE00
	[CompilerGenerated]
	private void _OnCloseTop30PanelClicked_b__95_0(); // 0x00000001805786E0-0x0000000180578710
}

