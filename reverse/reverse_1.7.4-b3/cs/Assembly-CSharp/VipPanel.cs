/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class VipPanel : MonoBehaviour // TypeDefIndex: 1485
{
	// Fields
	public const string N_ROOT = "[VipPanel]"; // Metadata: 0x005EFC2F
	private const int SORT_ORDER = 400; // Metadata: 0x005EFC3A
	private const float BOX_X = 267f; // Metadata: 0x005EFC3C
	private const float BOX_Y = 64f; // Metadata: 0x005EFC40
	private const float BOX_W = 1240f; // Metadata: 0x005EFC44
	private const float BOX_H = 760f; // Metadata: 0x005EFC48
	private const float CROWN_X = 506f; // Metadata: 0x005EFC4C
	private const float CROWN_Y = 24f; // Metadata: 0x005EFC50
	private const float CROWN_SIZE = 56f; // Metadata: 0x005EFC54
	private const float CROWN_GAP = 12f; // Metadata: 0x005EFC58
	private const float TITLE_Y = 22f; // Metadata: 0x005EFC5C
	private const float TITLE_H = 60f; // Metadata: 0x005EFC60
	private const float SUB_Y = 84f; // Metadata: 0x005EFC64
	private const float SUB_H = 30f; // Metadata: 0x005EFC68
	private const float CLOSE_X = 1145f; // Metadata: 0x005EFC6C
	private const float CLOSE_Y = 12f; // Metadata: 0x005EFC70
	private const float CLOSE_W = 81f; // Metadata: 0x005EFC74
	private const float CLOSE_H = 84f; // Metadata: 0x005EFC78
	private const float CARD_X = 36f; // Metadata: 0x005EFC7C
	private const float CARD_Y0 = 120f; // Metadata: 0x005EFC80
	private const float CARD_W = 760f; // Metadata: 0x005EFC84
	private const float CARD_H = 182f; // Metadata: 0x005EFC88
	private const float CARD_STEP = 192f; // Metadata: 0x005EFC8C
	private const float C_ICON_X = 16f; // Metadata: 0x005EFC90
	private const float C_ICON_Y = 21f; // Metadata: 0x005EFC94
	private const float C_ICON = 140f; // Metadata: 0x005EFC98
	private const float C_TEXT_X = 172f; // Metadata: 0x005EFC9C
	private const float C_NAME_Y = 12f; // Metadata: 0x005EFCA0
	private const float C_NAME_W = 300f; // Metadata: 0x005EFCA4
	private const float C_NAME_H = 40f; // Metadata: 0x005EFCA8
	private const float C_COST_Y = 54f; // Metadata: 0x005EFCAC
	private const float C_COST_W = 340f; // Metadata: 0x005EFCB0
	private const float C_COST_H = 30f; // Metadata: 0x005EFCB4
	private const float C_RW_Y = 88f; // Metadata: 0x005EFCB8
	private const float C_RW_W = 360f; // Metadata: 0x005EFCBC
	private const float C_RW_H = 40f; // Metadata: 0x005EFCC0
	private const float C_ST_Y = 134f; // Metadata: 0x005EFCC4
	private const float C_ST_W = 360f; // Metadata: 0x005EFCC8
	private const float C_ST_H = 28f; // Metadata: 0x005EFCCC
	private const float C_BTN_X = 540f; // Metadata: 0x005EFCD0
	private const float C_BTN_Y = 59f; // Metadata: 0x005EFCD4
	private const float C_BTN_W = 200f; // Metadata: 0x005EFCD8
	private const float C_BTN_H = 64f; // Metadata: 0x005EFCDC
	private const int MAX_REWARD_CHIPS = 3; // Metadata: 0x005EFCE0
	private const float COL_X = 830f; // Metadata: 0x005EFCE1
	private const float COL_W = 374f; // Metadata: 0x005EFCE5
	private const float TODAY_Y = 124f; // Metadata: 0x005EFCE9
	private const float TODAY_H = 40f; // Metadata: 0x005EFCED
	private const float LIST_Y = 172f; // Metadata: 0x005EFCF1
	private const float LIST_H = 256f; // Metadata: 0x005EFCF5
	private const float ROW_STEP = 64f; // Metadata: 0x005EFCF9
	private const float ROW_H = 60f; // Metadata: 0x005EFCFD
	private const float ROW_ICON = 56f; // Metadata: 0x005EFD01
	private const float CLAIM_X = 847f; // Metadata: 0x005EFD05
	private const float CLAIM_Y = 470f; // Metadata: 0x005EFD09
	private const float CLAIM_W = 340f; // Metadata: 0x005EFD0D
	private const float CLAIM_H = 84f; // Metadata: 0x005EFD11
	private const float NEXT_Y = 566f; // Metadata: 0x005EFD15
	private const float NEXT_H = 28f; // Metadata: 0x005EFD19
	private const float SAFIA_Y = 640f; // Metadata: 0x005EFD1D
	private const float SAFIA_H = 44f; // Metadata: 0x005EFD21
	private const float SAFIA_ICON = 40f; // Metadata: 0x005EFD25
	private const float NOTE_X = 36f; // Metadata: 0x005EFD29
	private const float NOTE_Y = 700f; // Metadata: 0x005EFD2D
	private const float NOTE_W = 1168f; // Metadata: 0x005EFD31
	private const float NOTE_H = 44f; // Metadata: 0x005EFD35
	private const int MAX_TODAY_ROWS = 4; // Metadata: 0x005EFD39
	private static VipPanel _instance; // 0x00
	[CompilerGenerated]
	private static string _LastSource_k__BackingField; // 0x08
	private Canvas _canvas; // 0x20
	private GraphicRaycaster _raycaster; // 0x28
	private CanvasGroup _group; // 0x30
	private RectTransform _content; // 0x38
	private Image _imgCrown; // 0x40
	private UnityEngine.UI.Text _txtTitle; // 0x48
	private UnityEngine.UI.Text _txtSub; // 0x50
	private CardUi[] _cards; // 0x58
	private UnityEngine.UI.Text _txtTodayTitle; // 0x60
	private RectTransform _listToday; // 0x68
	private RectTransform[] _todayRows; // 0x70
	private Image[] _todayIcons; // 0x78
	private UnityEngine.UI.Text[] _todayTexts; // 0x80
	private Button _btnClaim; // 0x88
	private UnityEngine.UI.Text _lblClaim; // 0x90
	private UnityEngine.UI.Text _txtNext; // 0x98
	private UnityEngine.UI.Text _txtSafia; // 0xA0
	private UnityEngine.UI.Text _txtNote; // 0xA8
	private VipConfirmDialog _confirm; // 0xB0
	private long _builtConfigVersion; // 0xB8
	private VipInfoData _info; // 0xC0
	private bool _sending; // 0xC8
	private long _nextResetSec; // 0xD0
	private const string TICK = "TickCountdown"; // Metadata: 0x005EFD3A
	private const string CODE_OFF = "OFF"; // Metadata: 0x005EFD48

	// Properties
	public static string LastSource { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018080C5E0-0x000000018080C620 0x000000018080C620-0x000000018080C6C0
	public VipConfirmDialog Confirm { get; } // 0x00000001802D8F00-0x00000001802D8F10 
	public static bool IsOpen { get; } // 0x000000018080C6C0-0x000000018080C8F0 

	// Nested types
	private class CardUi // TypeDefIndex: 1486
	{
		// Fields
		public int tier; // 0x10
		public RectTransform root; // 0x18
		public Image icon; // 0x20
		public UnityEngine.UI.Text name; // 0x28
		public UnityEngine.UI.Text cost; // 0x30
		public RectTransform rewards; // 0x38
		public Image[] rwIcons; // 0x40
		public UnityEngine.UI.Text[] rwTexts; // 0x48
		public UnityEngine.UI.Text status; // 0x50
		public Button action; // 0x58
		public UnityEngine.UI.Text actionLabel; // 0x60
		public Image sweep; // 0x68

		// Constructors
		public CardUi(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1487
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__101_0; // 0x08

		// Constructors
		static __c(); // 0x0000000180818610-0x00000001808186B0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RegisterOpener_b__101_0(string src); // 0x00000001808186B0-0x00000001808186C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass111_0 // TypeDefIndex: 1488
	{
		// Fields
		public VipPanel __4__this; // 0x10
		public int captured; // 0x18

		// Constructors
		public __c__DisplayClass111_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildCard_b__0(); // 0x00000001808186C0-0x00000001808186F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass128_0 // TypeDefIndex: 1489
	{
		// Fields
		public VipPanel __4__this; // 0x10
		public int tier; // 0x18

		// Constructors
		public __c__DisplayClass128_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnTierTap_b__0(); // 0x00000001808186F0-0x0000000180818720
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass131_0 // TypeDefIndex: 1490
	{
		// Fields
		public VipPanel __4__this; // 0x10
		public int tier; // 0x18

		// Constructors
		public __c__DisplayClass131_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DoActivate_b__0(VipActivateData res); // 0x0000000180818720-0x0000000180818750
		internal void _DoActivate_b__1(string err); // 0x0000000180818750-0x0000000180818770
	}

	// Constructors
	public VipPanel(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void RegisterOpener(); // 0x000000018080C8F0-0x000000018080CB70
	public static void Open(string source = null); // 0x000000018080CB70-0x000000018080D2B0
	public static void CloseIfOpen(); // 0x000000018080D2B0-0x000000018080D3D0
	public void Close(); // 0x000000018080D3D0-0x000000018080D7D0
	private void SetShown(bool on); // 0x000000018080D7D0-0x000000018080DAF0
	private void OnDestroy(); // 0x000000018080DAF0-0x000000018080DD20
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x000000018080DD20-0x000000018080DD30
	private bool AliveUi(); // 0x000000018080DD30-0x000000018080DF10
	private static VipPanel Build(long configVersion); // 0x000000018080DF10-0x000000018080E6B0
	private void BuildBody(RectTransform root); // 0x000000018080E6B0-0x000000018080F1A0
	private CardUi BuildCard(RectTransform box, int tier, float y); // 0x000000018080F1A0-0x00000001808106C0
	private void BuildRightColumn(RectTransform box, VipConfig.StringsCfg s); // 0x00000001808106C0-0x0000000180811920
	private void BuildDialogs(); // 0x0000000180811920-0x0000000180811C50
	private void RenderCached(); // 0x0000000180811C50-0x0000000180811CE0
	private void ShowSkeleton(); // 0x0000000180811CE0-0x00000001808121D0
	private void Render(VipInfoData info); // 0x00000001808121D0-0x00000001808128B0
	private void RenderCard(CardUi c, VipTierData t, VipConfig.StringsCfg s); // 0x00000001808128B0-0x0000000180813290
	private void RenderRewards(CardUi c, VipRewardData[] rewards); // 0x0000000180813290-0x0000000180813810
	private void HideChips(CardUi c, int keep); // 0x0000000180813810-0x0000000180813A80
	private void RenderToday(VipInfoData info, VipConfig.StringsCfg s); // 0x0000000180813A80-0x0000000180814100
	private void RenderNext(VipConfig.StringsCfg s, int level, bool claimed); // 0x0000000180814100-0x0000000180814340
	private void StartCountdown(); // 0x0000000180814340-0x00000001808143B0
	private void StopCountdown(); // 0x00000001808143B0-0x0000000180814400
	private void TickCountdown(); // 0x0000000180814400-0x00000001808144F0
	private void RequestInfo(); // 0x00000001808144F0-0x00000001808146E0
	private void OnInfo(VipInfoData info); // 0x00000001808146E0-0x0000000180814800
	private void OnInfoError(string err); // 0x0000000180814800-0x0000000180814920
	private void OnTierTap(int tier); // 0x0000000180814920-0x0000000180814D60
	private static string LockedReason(VipTierData t, int tier); // 0x0000000180814D60-0x0000000180815080
	private void DoActivate(int tier); // 0x0000000180815080-0x00000001808152C0
	private void OnActivateResult(int tier, VipActivateData res); // 0x00000001808152C0-0x0000000180815A30
	private void OnClaimTap(); // 0x0000000180815A30-0x0000000180815BE0
	private void OnClaimResult(VipClaimData res); // 0x0000000180815BE0-0x00000001808160E0
	private void ToastGranted(VipRewardData[] granted, VipConfig.StringsCfg s); // 0x00000001808160E0-0x00000001808164F0
	private void OnWriteError(string err); // 0x00000001808164F0-0x0000000180816620
	private void SetSending(bool on, bool rerender = true /* Metadata: 0x005EFC2E */); // 0x0000000180816620-0x0000000180816850
	private void RenderCurrent(); // 0x0000000180816850-0x0000000180816870
	private void ApplyAndRender(VipInfoData info); // 0x0000000180816870-0x0000000180816940
	private void RefreshHubWallet(); // 0x0000000180816940-0x0000000180816A10
	private void ShakeCard(int tier); // 0x0000000180816A10-0x0000000180816A90
	private CardUi CardOf(int tier); // 0x0000000180816A90-0x0000000180816B00
	private static VipTierData FindTier(VipInfoData info, int tier); // 0x0000000180816B00-0x0000000180816B70
	private static int DefaultDays(VipInfoData info); // 0x0000000180816B70-0x0000000180816BF0
	private static RewardDisplayHelper.Entry EntryOf(VipRewardData r); // 0x0000000180816BF0-0x0000000180816D20
	private static Sprite RewardIcon(VipRewardData r); // 0x0000000180816D20-0x0000000180816D90
	private bool ApplyRewardIcon(Image img, VipRewardData r); // 0x0000000180816D90-0x00000001808170A0
	private static Sprite CurrencyIconOf(string iconType); // 0x00000001808170A0-0x0000000180817110
	private static string ItemIconPath(VipRewardData r); // 0x0000000180817110-0x0000000180817290
	private static string RewardLine(VipRewardData r); // 0x0000000180817290-0x00000001808173B0
	private Image VipIcon(Transform parent, string name, float x, float y, float w, float h, string art, Sprite fallback); // 0x00000001808173B0-0x0000000180817700
	private void PlaceCrown(); // 0x0000000180817700-0x0000000180817960
	private void BindCrown(Image img, int level); // 0x0000000180817960-0x0000000180817BC0
	private static string CrownArt(int level); // 0x0000000180817BC0-0x0000000180817C60
	private static string SafiaArt(); // 0x0000000180817C60-0x0000000180817CA0
	private static Sprite SafiaFallback(); // 0x0000000180817CA0-0x0000000180817D10
	private static Sprite ProceduralCrown(int level); // 0x0000000180817D10-0x0000000180817D70
	private static void SetIcon(Image img, Sprite sp); // 0x0000000180817D70-0x0000000180817F50
	private static void SetText(UnityEngine.UI.Text t, string v); // 0x0000000180817F50-0x0000000180818060
	private static int SelfId(); // 0x0000000180818060-0x0000000180818080
	private static VipConfig.StringsCfg StringsOrNull(); // 0x0000000180818080-0x00000001808180D0
	private static bool ConfigEnabled(); // 0x00000001808180D0-0x0000000180818120
	private static string FormatRemaining(long seconds); // 0x0000000180818120-0x0000000180818190
	private static string FormatClock(long seconds); // 0x0000000180818190-0x0000000180818370
	public static string Txt(string value, string fallback); // 0x0000000180343570-0x0000000180343590
	public static float FontOf(float raw); // 0x0000000180818370-0x0000000180818450
	public static string Fmt(string fmt, params object[] args); // 0x0000000180818450-0x0000000180818610
}

