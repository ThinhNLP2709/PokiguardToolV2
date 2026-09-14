/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class VipPanel : MonoBehaviour // TypeDefIndex: 1487
{
	// Fields
	public const string N_ROOT = "[VipPanel]"; // Metadata: 0x005F0FFC
	private const int SORT_ORDER = 400; // Metadata: 0x005F1007
	private const float BOX_X = 267f; // Metadata: 0x005F1009
	private const float BOX_Y = 64f; // Metadata: 0x005F100D
	private const float BOX_W = 1240f; // Metadata: 0x005F1011
	private const float BOX_H = 760f; // Metadata: 0x005F1015
	private const float CROWN_X = 506f; // Metadata: 0x005F1019
	private const float CROWN_Y = 24f; // Metadata: 0x005F101D
	private const float CROWN_SIZE = 56f; // Metadata: 0x005F1021
	private const float CROWN_GAP = 12f; // Metadata: 0x005F1025
	private const float TITLE_Y = 22f; // Metadata: 0x005F1029
	private const float TITLE_H = 60f; // Metadata: 0x005F102D
	private const float SUB_Y = 84f; // Metadata: 0x005F1031
	private const float SUB_H = 30f; // Metadata: 0x005F1035
	private const float CLOSE_X = 1145f; // Metadata: 0x005F1039
	private const float CLOSE_Y = 12f; // Metadata: 0x005F103D
	private const float CLOSE_W = 81f; // Metadata: 0x005F1041
	private const float CLOSE_H = 84f; // Metadata: 0x005F1045
	private const float CARD_X = 36f; // Metadata: 0x005F1049
	private const float CARD_Y0 = 120f; // Metadata: 0x005F104D
	private const float CARD_W = 760f; // Metadata: 0x005F1051
	private const float CARD_H = 182f; // Metadata: 0x005F1055
	private const float CARD_STEP = 192f; // Metadata: 0x005F1059
	private const float C_ICON_X = 16f; // Metadata: 0x005F105D
	private const float C_ICON_Y = 21f; // Metadata: 0x005F1061
	private const float C_ICON = 140f; // Metadata: 0x005F1065
	private const float C_TEXT_X = 172f; // Metadata: 0x005F1069
	private const float C_NAME_Y = 12f; // Metadata: 0x005F106D
	private const float C_NAME_W = 300f; // Metadata: 0x005F1071
	private const float C_NAME_H = 40f; // Metadata: 0x005F1075
	private const float C_COST_Y = 54f; // Metadata: 0x005F1079
	private const float C_COST_W = 340f; // Metadata: 0x005F107D
	private const float C_COST_H = 30f; // Metadata: 0x005F1081
	private const float C_RW_Y = 88f; // Metadata: 0x005F1085
	private const float C_RW_W = 360f; // Metadata: 0x005F1089
	private const float C_RW_H = 40f; // Metadata: 0x005F108D
	private const float C_ST_Y = 134f; // Metadata: 0x005F1091
	private const float C_ST_W = 360f; // Metadata: 0x005F1095
	private const float C_ST_H = 28f; // Metadata: 0x005F1099
	private const float C_BTN_X = 540f; // Metadata: 0x005F109D
	private const float C_BTN_Y = 59f; // Metadata: 0x005F10A1
	private const float C_BTN_W = 200f; // Metadata: 0x005F10A5
	private const float C_BTN_H = 64f; // Metadata: 0x005F10A9
	private const int MAX_REWARD_CHIPS = 3; // Metadata: 0x005F10AD
	private const float COL_X = 830f; // Metadata: 0x005F10AE
	private const float COL_W = 374f; // Metadata: 0x005F10B2
	private const float TODAY_Y = 124f; // Metadata: 0x005F10B6
	private const float TODAY_H = 40f; // Metadata: 0x005F10BA
	private const float LIST_Y = 172f; // Metadata: 0x005F10BE
	private const float LIST_H = 256f; // Metadata: 0x005F10C2
	private const float ROW_STEP = 64f; // Metadata: 0x005F10C6
	private const float ROW_H = 60f; // Metadata: 0x005F10CA
	private const float ROW_ICON = 56f; // Metadata: 0x005F10CE
	private const float CLAIM_X = 847f; // Metadata: 0x005F10D2
	private const float CLAIM_Y = 470f; // Metadata: 0x005F10D6
	private const float CLAIM_W = 340f; // Metadata: 0x005F10DA
	private const float CLAIM_H = 84f; // Metadata: 0x005F10DE
	private const float NEXT_Y = 566f; // Metadata: 0x005F10E2
	private const float NEXT_H = 28f; // Metadata: 0x005F10E6
	private const float SAFIA_Y = 640f; // Metadata: 0x005F10EA
	private const float SAFIA_H = 44f; // Metadata: 0x005F10EE
	private const float SAFIA_ICON = 40f; // Metadata: 0x005F10F2
	private const float NOTE_X = 36f; // Metadata: 0x005F10F6
	private const float NOTE_Y = 700f; // Metadata: 0x005F10FA
	private const float NOTE_W = 1168f; // Metadata: 0x005F10FE
	private const float NOTE_H = 44f; // Metadata: 0x005F1102
	private const int MAX_TODAY_ROWS = 4; // Metadata: 0x005F1106
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
	private const string TICK = "TickCountdown"; // Metadata: 0x005F1107
	private const string CODE_OFF = "OFF"; // Metadata: 0x005F1115

	// Properties
	public static string LastSource { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018080E6D0-0x000000018080E710 0x000000018080E710-0x000000018080E7B0
	public VipConfirmDialog Confirm { get; } // 0x00000001802D8F30-0x00000001802D8F40 
	public static bool IsOpen { get; } // 0x000000018080E7B0-0x000000018080E9E0 

	// Nested types
	private class CardUi // TypeDefIndex: 1488
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
	private sealed class __c // TypeDefIndex: 1489
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__101_0; // 0x08

		// Constructors
		static __c(); // 0x000000018081A700-0x000000018081A7A0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RegisterOpener_b__101_0(string src); // 0x000000018081A7A0-0x000000018081A7B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass111_0 // TypeDefIndex: 1490
	{
		// Fields
		public VipPanel __4__this; // 0x10
		public int captured; // 0x18

		// Constructors
		public __c__DisplayClass111_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildCard_b__0(); // 0x000000018081A7B0-0x000000018081A7E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass128_0 // TypeDefIndex: 1491
	{
		// Fields
		public VipPanel __4__this; // 0x10
		public int tier; // 0x18

		// Constructors
		public __c__DisplayClass128_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnTierTap_b__0(); // 0x000000018081A7E0-0x000000018081A810
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass131_0 // TypeDefIndex: 1492
	{
		// Fields
		public VipPanel __4__this; // 0x10
		public int tier; // 0x18

		// Constructors
		public __c__DisplayClass131_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DoActivate_b__0(VipActivateData res); // 0x000000018081A810-0x000000018081A840
		internal void _DoActivate_b__1(string err); // 0x000000018081A840-0x000000018081A860
	}

	// Constructors
	public VipPanel(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void RegisterOpener(); // 0x000000018080E9E0-0x000000018080EC60
	public static void Open(string source = null); // 0x000000018080EC60-0x000000018080F3A0
	public static void CloseIfOpen(); // 0x000000018080F3A0-0x000000018080F4C0
	public void Close(); // 0x000000018080F4C0-0x000000018080F8C0
	private void SetShown(bool on); // 0x000000018080F8C0-0x000000018080FBE0
	private void OnDestroy(); // 0x000000018080FBE0-0x000000018080FE10
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x000000018080FE10-0x000000018080FE20
	private bool AliveUi(); // 0x000000018080FE20-0x0000000180810000
	private static VipPanel Build(long configVersion); // 0x0000000180810000-0x00000001808107A0
	private void BuildBody(RectTransform root); // 0x00000001808107A0-0x0000000180811290
	private CardUi BuildCard(RectTransform box, int tier, float y); // 0x0000000180811290-0x00000001808127B0
	private void BuildRightColumn(RectTransform box, VipConfig.StringsCfg s); // 0x00000001808127B0-0x0000000180813A10
	private void BuildDialogs(); // 0x0000000180813A10-0x0000000180813D40
	private void RenderCached(); // 0x0000000180813D40-0x0000000180813DD0
	private void ShowSkeleton(); // 0x0000000180813DD0-0x00000001808142C0
	private void Render(VipInfoData info); // 0x00000001808142C0-0x00000001808149A0
	private void RenderCard(CardUi c, VipTierData t, VipConfig.StringsCfg s); // 0x00000001808149A0-0x0000000180815380
	private void RenderRewards(CardUi c, VipRewardData[] rewards); // 0x0000000180815380-0x0000000180815900
	private void HideChips(CardUi c, int keep); // 0x0000000180815900-0x0000000180815B70
	private void RenderToday(VipInfoData info, VipConfig.StringsCfg s); // 0x0000000180815B70-0x00000001808161F0
	private void RenderNext(VipConfig.StringsCfg s, int level, bool claimed); // 0x00000001808161F0-0x0000000180816430
	private void StartCountdown(); // 0x0000000180816430-0x00000001808164A0
	private void StopCountdown(); // 0x00000001808164A0-0x00000001808164F0
	private void TickCountdown(); // 0x00000001808164F0-0x00000001808165E0
	private void RequestInfo(); // 0x00000001808165E0-0x00000001808167D0
	private void OnInfo(VipInfoData info); // 0x00000001808167D0-0x00000001808168F0
	private void OnInfoError(string err); // 0x00000001808168F0-0x0000000180816A10
	private void OnTierTap(int tier); // 0x0000000180816A10-0x0000000180816E50
	private static string LockedReason(VipTierData t, int tier); // 0x0000000180816E50-0x0000000180817170
	private void DoActivate(int tier); // 0x0000000180817170-0x00000001808173B0
	private void OnActivateResult(int tier, VipActivateData res); // 0x00000001808173B0-0x0000000180817B20
	private void OnClaimTap(); // 0x0000000180817B20-0x0000000180817CD0
	private void OnClaimResult(VipClaimData res); // 0x0000000180817CD0-0x00000001808181D0
	private void ToastGranted(VipRewardData[] granted, VipConfig.StringsCfg s); // 0x00000001808181D0-0x00000001808185E0
	private void OnWriteError(string err); // 0x00000001808185E0-0x0000000180818710
	private void SetSending(bool on, bool rerender = true /* Metadata: 0x005F0FFB */); // 0x0000000180818710-0x0000000180818940
	private void RenderCurrent(); // 0x0000000180818940-0x0000000180818960
	private void ApplyAndRender(VipInfoData info); // 0x0000000180818960-0x0000000180818A30
	private void RefreshHubWallet(); // 0x0000000180818A30-0x0000000180818B00
	private void ShakeCard(int tier); // 0x0000000180818B00-0x0000000180818B80
	private CardUi CardOf(int tier); // 0x0000000180818B80-0x0000000180818BF0
	private static VipTierData FindTier(VipInfoData info, int tier); // 0x0000000180818BF0-0x0000000180818C60
	private static int DefaultDays(VipInfoData info); // 0x0000000180818C60-0x0000000180818CE0
	private static RewardDisplayHelper.Entry EntryOf(VipRewardData r); // 0x0000000180818CE0-0x0000000180818E10
	private static Sprite RewardIcon(VipRewardData r); // 0x0000000180818E10-0x0000000180818E80
	private bool ApplyRewardIcon(Image img, VipRewardData r); // 0x0000000180818E80-0x0000000180819190
	private static Sprite CurrencyIconOf(string iconType); // 0x0000000180819190-0x0000000180819200
	private static string ItemIconPath(VipRewardData r); // 0x0000000180819200-0x0000000180819380
	private static string RewardLine(VipRewardData r); // 0x0000000180819380-0x00000001808194A0
	private Image VipIcon(Transform parent, string name, float x, float y, float w, float h, string art, Sprite fallback); // 0x00000001808194A0-0x00000001808197F0
	private void PlaceCrown(); // 0x00000001808197F0-0x0000000180819A50
	private void BindCrown(Image img, int level); // 0x0000000180819A50-0x0000000180819CB0
	private static string CrownArt(int level); // 0x0000000180819CB0-0x0000000180819D50
	private static string SafiaArt(); // 0x0000000180819D50-0x0000000180819D90
	private static Sprite SafiaFallback(); // 0x0000000180819D90-0x0000000180819E00
	private static Sprite ProceduralCrown(int level); // 0x0000000180819E00-0x0000000180819E60
	private static void SetIcon(Image img, Sprite sp); // 0x0000000180819E60-0x000000018081A040
	private static void SetText(UnityEngine.UI.Text t, string v); // 0x000000018081A040-0x000000018081A150
	private static int SelfId(); // 0x000000018081A150-0x000000018081A170
	private static VipConfig.StringsCfg StringsOrNull(); // 0x000000018081A170-0x000000018081A1C0
	private static bool ConfigEnabled(); // 0x000000018081A1C0-0x000000018081A210
	private static string FormatRemaining(long seconds); // 0x000000018081A210-0x000000018081A280
	private static string FormatClock(long seconds); // 0x000000018081A280-0x000000018081A460
	public static string Txt(string value, string fallback); // 0x0000000180343690-0x00000001803436B0
	public static float FontOf(float raw); // 0x000000018081A460-0x000000018081A540
	public static string Fmt(string fmt, params object[] args); // 0x000000018081A540-0x000000018081A700
}

