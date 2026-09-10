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

public class GuildBossView : MonoBehaviour // TypeDefIndex: 683
{
	// Fields
	[Header("Ch\u1ECDn boss")]
	[SerializeField]
	private GameObject listCanvas; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtDiffTitle; // 0x28
	[SerializeField]
	private Transform pagesContainer; // 0x30
	[SerializeField]
	private GameObject islandSelect; // 0x38
	[SerializeField]
	private Transform islandPages; // 0x40
	[SerializeField]
	private Button btnBackIsland; // 0x48
	[SerializeField]
	private UnityEngine.UI.Text txtStatus; // 0x50
	[SerializeField]
	private UnityEngine.UI.Text txtSeasonReset; // 0x58
	[Header("Chi ti\u1EBFt boss")]
	[SerializeField]
	private GameObject infoCanvas; // 0x60
	[SerializeField]
	private UnityEngine.UI.Text txtHp; // 0x68
	[SerializeField]
	private Image imgHpFill; // 0x70
	[SerializeField]
	private Button btnFight; // 0x78
	[SerializeField]
	private UnityEngine.UI.Text txtFight; // 0x80
	[SerializeField]
	private UnityEngine.UI.Text txtFightCost; // 0x88
	private Transform _fightCostIcon; // 0x90
	[SerializeField]
	private GameObject fightingBox; // 0x98
	[SerializeField]
	private UnityEngine.UI.Text txtFightingName; // 0xA0
	[SerializeField]
	private Transform bossContainer; // 0xA8
	[SerializeField]
	private RectTransform topContent; // 0xB0
	[SerializeField]
	private GameObject topRowTemplate; // 0xB8
	[SerializeField]
	private Button btnReward; // 0xC0
	[Header("B\u1EA3ng th\u01B0\u1EDFng")]
	[SerializeField]
	private GameObject rewardCanvas; // 0xC8
	[SerializeField]
	private RectTransform rewardContent; // 0xD0
	[SerializeField]
	private GameObject rewardItemTemplate; // 0xD8
	private const float REWARD_CELL = 52f; // Metadata: 0x0068B835
	private const float KILL_REWARD_CELL = 46f; // Metadata: 0x0068B839
	private const float INFO_PET_BOX = 170f; // Metadata: 0x0068B83D
	private const string NODE_BOSS_NAME = "txtBossName"; // Metadata: 0x0068B841
	private const string NODE_BOSS_ELEMENT = "imgBossElement"; // Metadata: 0x0068B84D
	private const string NODE_KILL_REWARD = "KillRewardBox"; // Metadata: 0x0068B85C
	private const string NODE_GUILD_HP = "txtGuildBossHp"; // Metadata: 0x0068B86A
	private const string NODE_GUILD_STATE = "txtGuildBossState"; // Metadata: 0x0068B879
	private const string NODE_HUNT = "txtHuntProgress"; // Metadata: 0x0068B88B
	private const string NODE_HELP_BTN = "btnBossHelp"; // Metadata: 0x0068B89B
	private const string HELP_SPRITE = "Image/FriendUI/btnHelp"; // Metadata: 0x0068B8A7
	private const float HELP_BTN_SIZE = 44f; // Metadata: 0x0068B8BE
	private const float HELP_BTN_X = 250f; // Metadata: 0x0068B8C2
	private const string PREF_HELP_SEEN = "GuildBossHelpSeen"; // Metadata: 0x0068B8C6
	private const string HEX_HELP_GOLD = "FFD84A"; // Metadata: 0x0068B8D8
	private const string HEX_HELP_RED = "FF6B60"; // Metadata: 0x0068B8DF
	private RectTransform _helpBtnRt; // 0xE0
	private static readonly Color HUNT_LABEL; // 0x00
	private static readonly Color HUNT_DONE; // 0x10
	private static readonly Color GUILD_HP_LABEL; // 0x20
	private static readonly Color GUILD_KILLABLE; // 0x30
	private static readonly Color GUILD_FIGHTING; // 0x40
	private static readonly string[] ISLAND_BTN_ART; // 0x50
	private static readonly string[] ISLAND_BTN_ART_LEGACY; // 0x58
	private static readonly string[] ISLAND_BG_ART; // 0x60
	private static readonly string[] ISLAND_BG_ART_LEGACY; // 0x68
	private const string SLOT_INFO_ART = "Image/Common/endless_img_1"; // Metadata: 0x0068B8E6
	private readonly List<GuildBossNodeView> _nodePool; // 0xE8
	private readonly List<GuildTopDamageRow> _topPool; // 0xF0
	private readonly List<GameObject> _pageCells; // 0xF8
	private readonly List<GameObject> _rewardRows; // 0x100
	private readonly List<Transform> _islandPages; // 0x108
	private bool _inIsland; // 0x110
	private GuildPanelController _owner; // 0x118
	private bool _wired; // 0x120
	private GuildBossData _data; // 0x128
	private GuildBossNodeData _selected; // 0x130
	private Color? _fightColorHome; // 0x138
	private int _diff; // 0x14C
	private int _petShown; // 0x150
	private Coroutine _seasonCo; // 0x158
	private bool _starting; // 0x160
	private Coroutine _petQueueCo; // 0x168
	private Animator _infoAnim; // 0x170
	private Image _infoImg; // 0x178
	private PetImageFit _infoFit; // 0x180
	private UnityEngine.UI.Text _txtBossName; // 0x188
	private Image _imgBossElement; // 0x190
	private Transform _killRewardBox; // 0x198
	private UnityEngine.UI.Text _txtGuildHp; // 0x1A0
	private UnityEngine.UI.Text _txtGuildState; // 0x1A8
	private UnityEngine.UI.Text _txtHunt; // 0x1B0
	private Button _btnInfoClaim; // 0x1B8
	private UnityEngine.UI.Text _txtInfoClaim; // 0x1C0
	private Image _imgInfoClaim; // 0x1C8
	private bool _claiming; // 0x1D0
	private GameObject _claimPopup; // 0x1D8
	private const float PANEL_SCALE = 1.2f; // Metadata: 0x0068B901
	private const float CONTENT_HALF_H = 267.5f; // Metadata: 0x0068B905
	private static readonly Vector2 ISLAND_NAME_POS; // 0x70
	private static readonly Color ISLAND_NAME_COLOR; // 0x78
	private static readonly Color ISLAND_NAME_EDGE; // 0x88
	private static readonly Vector2 ISLAND_NAME_SIZE; // 0x98
	private const int ISLAND_NAME_MAX_FONT = 22; // Metadata: 0x0068B909
	private const int ISLAND_NAME_MIN_FONT = 13; // Metadata: 0x0068B90A
	private const string NODE_PET_LOADING = "petLoadingTag"; // Metadata: 0x0068B90B
	private const string TICKET_ICON = "Image/item/9010"; // Metadata: 0x0068B919
	private static readonly Vector2 GUILD_POOL_ROW; // 0xA0
	private static readonly Vector2 GUILD_HP_POS; // 0xA8
	private static readonly Vector2 GUILD_STATE_POS; // 0xB0

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 684
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__92_0; // 0x08
		public static Action<string> __9__152_0; // 0x10
		public static Action<string> __9__156_0; // 0x18

		// Constructors
		static __c(); // 0x00000001804688D0-0x0000000180468940
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Reload_b__92_0(string err); // 0x0000000180467CD0-0x0000000180467D30
		internal void _LoadRanking_b__152_0(string err); // 0x0000000180467C00-0x0000000180467C70
		internal void _OpenRewards_b__156_0(string err); // 0x0000000180467C70-0x0000000180467CD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass120_0 // TypeDefIndex: 685
	{
		// Fields
		public bool done; // 0x10

		// Constructors
		public __c__DisplayClass120_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PetQueue_b__0(); // 0x000000018034AB40-0x000000018034AB50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass140_0 // TypeDefIndex: 686
	{
		// Fields
		public UnityEngine.UI.Text t; // 0x10

		// Constructors
		public __c__DisplayClass140_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _StartGuildStatePulse_b__0(float a); // 0x0000000180467D30-0x0000000180467E20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass161_0 // TypeDefIndex: 687
	{
		// Fields
		public GuildBossView __4__this; // 0x10
		public int diff; // 0x18
		public int node; // 0x1C

		// Constructors
		public __c__DisplayClass161_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _StartBattle_b__0(GuildBossStartData d); // 0x0000000180467E20-0x0000000180467F00
		internal void _StartBattle_b__1(); // 0x0000000180467F00-0x0000000180467F30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass162_0 // TypeDefIndex: 688
	{
		// Fields
		public bool ready; // 0x10
		public bool failed; // 0x11
		public string failReason; // 0x18

		// Constructors
		public __c__DisplayClass162_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _EnterBattle_b__0(); // 0x000000018034AB40-0x000000018034AB50
		internal void _EnterBattle_b__1(string r); // 0x000000018034AB50-0x000000018034AB70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass86_0 // TypeDefIndex: 689
	{
		// Fields
		public int page; // 0x10
		public GuildBossView __4__this; // 0x18

		// Constructors
		public __c__DisplayClass86_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _CollectPages_b__0(); // 0x0000000180468830-0x0000000180468860
	}

	[CompilerGenerated]
	private sealed class _EnterBattle_d__162 : IEnumerator<object> // TypeDefIndex: 690
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildBossView __4__this; // 0x20
		private __c__DisplayClass162_0 __8__1; // 0x28
		public GuildBossStartData start; // 0x30
		public int diff; // 0x38
		public int node; // 0x3C
		private float _tWs_5__2; // 0x40
		private ManagerRoom _roomMgr_5__3; // 0x48
		private GuildBattleBridge _bridge_5__4; // 0x50
		private Action _onReady_5__5; // 0x58
		private Action<string> _onFailed_5__6; // 0x60
		private float _tRoom_5__7; // 0x68

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _EnterBattle_d__162(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180467640-0x00000001804676B0
		private bool MoveNext(); // 0x0000000180466BC0-0x0000000180467600
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180467600-0x0000000180467640
	}

	[CompilerGenerated]
	private sealed class _PetQueue_d__120 : IEnumerator<object> // TypeDefIndex: 691
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildBossView __4__this; // 0x20
		private __c__DisplayClass120_0 __8__1; // 0x28
		public int count; // 0x30
		private int _i_5__2; // 0x34
		private float _t_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PetQueue_d__120(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001804676B0-0x0000000180467940
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180467940-0x0000000180467980
	}

	[CompilerGenerated]
	private sealed class _SeasonLoop_d__165 : IEnumerator<object> // TypeDefIndex: 692
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long seconds; // 0x20
		public GuildBossView __4__this; // 0x28
		private WaitForSecondsRealtime _wait_5__2; // 0x30
		private long _left_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SeasonLoop_d__165(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x0000000180467980-0x0000000180467BC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180467BC0-0x0000000180467C00
	}

	// Constructors
	public GuildBossView(); // 0x000000018044EDD0-0x000000018044EF70
	static GuildBossView(); // 0x000000018044E7C0-0x000000018044EDD0

	// Methods
	public void Init(GuildPanelController owner); // 0x0000000180445370-0x00000001804453A0
	private void EnsureWired(); // 0x0000000180443820-0x0000000180444EB0
	private void ApplyIslandArt(); // 0x000000018043FA00-0x000000018043FFE0
	private static bool ApplyArt(Image img, string path); // 0x000000018043F550-0x000000018043F640
	private void CollectIslandPages(); // 0x0000000180441890-0x00000001804419D0
	private void CollectPages(); // 0x00000001804419D0-0x0000000180441C50
	public void Open(); // 0x0000000180446AD0-0x0000000180446BF0
	public void Close(); // 0x00000001804417B0-0x0000000180441890
	private void BackToHall(); // 0x0000000180440BF0-0x0000000180440D30
	private void OnDisable(); // 0x0000000180446640-0x00000001804467F0
	private void ReleaseAllPets(); // 0x0000000180447C50-0x0000000180447DD0
	public void Reload(); // 0x0000000180447DD0-0x0000000180447FB0
	private void Render(GuildBossData d); // 0x0000000180449CE0-0x0000000180449EA0
	private void ApplyPanelScale(); // 0x0000000180440330-0x0000000180440780
	private static float AvailableHalfHeight(Transform host); // 0x0000000180440A30-0x0000000180440BF0
	private static void ApplyTitleBarLayout(Transform list); // 0x0000000180440780-0x0000000180440A30
	private void EnsureHelpButton(Transform list); // 0x00000001804426C0-0x0000000180442FB0
	private void StartHelpPulse(); // 0x000000018044DDD0-0x000000018044DFB0
	private void StopHelpPulse(); // 0x000000018044E580-0x000000018044E670
	private void ShowHelpTip(); // 0x000000018044B6A0-0x000000018044B910
	private string BuildHelpBody(bool rich); // 0x0000000180440DA0-0x00000001804411E0
	private static string HelpHead(string s, bool rich, string hex = "FFD84A" /* Metadata: 0x0068B82E */); // 0x0000000180445230-0x0000000180445370
	private void ShowIslandSelect(); // 0x000000018044CD00-0x000000018044D010
	private void BackToIslandSelect(); // 0x0000000180440D30-0x0000000180440DA0
	private void ShowIslandPage(int diff); // 0x000000018044C8D0-0x000000018044CBD0
	private void CollectSlots(int diff); // 0x0000000180441C50-0x0000000180441DD0
	private void RenderPages(); // 0x0000000180448ED0-0x0000000180449340
	private static void ApplyIslandNameFit(UnityEngine.UI.Text t); // 0x000000018043FFE0-0x0000000180440330
	private string IslandTitle(int diff); // 0x00000001804453A0-0x0000000180445520
	private void RenderNodes(); // 0x0000000180448B80-0x0000000180448ED0
	private void StartPetQueue(int count); // 0x000000018044DFB0-0x000000018044E1C0
	[IteratorStateMachine(typeof(_PetQueue_d__120))]
	private IEnumerator PetQueue(int count); // 0x0000000180446BF0-0x0000000180446C70
	private static void ShowPetLoading(Transform parent, bool on, Vector2 pos, Vector2 size, int fontSize); // 0x000000018044D010-0x000000018044D7B0
	private void ShowIslandPetLoading(bool on); // 0x000000018044CBD0-0x000000018044CD00
	private void ShowInfoPetLoading(bool on); // 0x000000018044B910-0x000000018044BA20
	private void RenderStatus(); // 0x00000001804499E0-0x0000000180449CE0
	private List<GuildBossNodeData> NodesOf(int diff); // 0x00000001804461B0-0x0000000180446320
	private GuildBossNodeData FindNode(int diff, int node); // 0x0000000180445180-0x0000000180445230
	private void SelectDiff(int diff); // 0x0000000180449F20-0x000000018044A0C0
	private void ShowInfo(GuildBossNodeData n, bool reload); // 0x000000018044BA20-0x000000018044C8D0
	private void RenderFightCost(bool free); // 0x0000000180447FB0-0x00000001804481D0
	private static void PopIn(GameObject go); // 0x0000000180446C70-0x0000000180446DE0
	private void CloseInfo(); // 0x0000000180441670-0x0000000180441750
	private void EnsureBossNameNode(); // 0x0000000180441DD0-0x0000000180442490
	private void ApplyInfoTextLayout(); // 0x000000018043F640-0x000000018043FA00
	private void RenderGuildPool(GuildBossNodeData n); // 0x00000001804481D0-0x0000000180448970
	private void StartGuildStatePulse(); // 0x000000018044DBD0-0x000000018044DDD0
	private void StopGuildStatePulse(); // 0x000000018044E440-0x000000018044E580
	private void EnsureGuildPoolLines(); // 0x0000000180442490-0x00000001804426C0
	private UnityEngine.UI.Text MakeGuildPoolRow(Transform host, string nodeName, Vector2 pos, Color color); // 0x0000000180445730-0x0000000180445D10
	private void FindLegacyHuntLine(Transform parent); // 0x0000000180445080-0x0000000180445180
	private void RefreshInfoClaimButton(GuildBossNodeData n); // 0x0000000180446DE0-0x0000000180447C50
	private void ClaimHunt(GuildBossNodeData n); // 0x00000001804411E0-0x00000001804415F0
	private void ShowClaimPopup(GuildBossHuntClaimData d); // 0x000000018044A0C0-0x000000018044B6A0
	private void CloseClaimPopup(); // 0x00000001804415F0-0x0000000180441670
	private UnityEngine.UI.Text MakePopupText(Transform parent, string name, Vector2 pos, Vector2 size, string value, int fontSize, Color color, FontStyle style); // 0x0000000180445D10-0x00000001804461B0
	private void RenderKillReward(GuildBossNodeData n); // 0x0000000180448970-0x0000000180448B80
	private void EnsureKillRewardBox(); // 0x0000000180442FB0-0x0000000180443410
	private void LoadRanking(); // 0x0000000180445520-0x0000000180445730
	private void RenderRanking(GuildBossRankingData d); // 0x0000000180449340-0x00000001804495B0
	private GuildTopDamageRow EnsureTopRow(int index); // 0x0000000180443610-0x0000000180443820
	private void OpenRanking(); // 0x00000001804467F0-0x0000000180446880
	private void OpenRewards(); // 0x0000000180446880-0x0000000180446AD0
	private void CloseRewards(); // 0x0000000180441750-0x00000001804417B0
	private void RenderRewards(GuildBossRewardsData d); // 0x00000001804495B0-0x00000001804499E0
	private GameObject EnsureRewardRow(int index); // 0x0000000180443410-0x0000000180443610
	private void OnClickFight(); // 0x0000000180446320-0x0000000180446640
	private void StartBattle(); // 0x000000018044D7B0-0x000000018044DBD0
	[IteratorStateMachine(typeof(_EnterBattle_d__162))]
	private IEnumerator EnterBattle(GuildBossStartData start, int diff, int node); // 0x0000000180444EB0-0x0000000180444F60
	private void FailStart(string msg); // 0x0000000180444F60-0x0000000180445080
	private void StartSeasonTimer(long remainSec); // 0x000000018044E1C0-0x000000018044E440
	[IteratorStateMachine(typeof(_SeasonLoop_d__165))]
	private IEnumerator SeasonLoop(long seconds); // 0x0000000180449EA0-0x0000000180449F20
	private void StopSeasonTimer(); // 0x000000018044E670-0x000000018044E6C0
	[CompilerGenerated]
	private void _RenderNodes_b__118_0(GuildBossNodeData n); // 0x000000018044E710-0x000000018044E720
	[CompilerGenerated]
	private void _ShowInfo_b__130_0(float v); // 0x000000018044E720-0x000000018044E7B0
	[CompilerGenerated]
	private void _ShowInfo_b__130_1(bool _); // 0x000000018044E7B0-0x000000018044E7C0
	[CompilerGenerated]
	private void _RefreshInfoClaimButton_b__145_0(); // 0x000000018044E700-0x000000018044E710
	[CompilerGenerated]
	private void _ClaimHunt_b__146_0(GuildBossHuntClaimData d); // 0x000000018044E6C0-0x000000018044E6F0
	[CompilerGenerated]
	private void _ClaimHunt_b__146_1(); // 0x000000018044E6F0-0x000000018044E700
}

