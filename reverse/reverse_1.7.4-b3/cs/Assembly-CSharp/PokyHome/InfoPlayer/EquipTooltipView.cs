/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class EquipTooltipView : MonoBehaviour // TypeDefIndex: 2783
	{
		// Fields
		public const string FLAG = "infoplayer.tooltip"; // Metadata: 0x005F19BE
		public const string ROOT_NAME = "EquipTooltip"; // Metadata: 0x005F19D1
		public const string ART_DIR = "Image/InfoPlayer/"; // Metadata: 0x005F19DE
		public const string SP_PANEL = "Image/InfoPlayer/tooltip_panel"; // Metadata: 0x005F19F0
		public const float K = 0.65f; // Metadata: 0x005F1A0F
		private const float D_W = 575f; // Metadata: 0x005F1A13
		private const float D_PAD = 22f; // Metadata: 0x005F1A17
		private const float D_FRAME_X = 18f; // Metadata: 0x005F1A1B
		private const float D_FRAME_Y = 12f; // Metadata: 0x005F1A1F
		private const float D_FRAME = 68f; // Metadata: 0x005F1A23
		private const float D_ICON_INSET = 7f; // Metadata: 0x005F1A27
		private const float D_NAME_X = 98f; // Metadata: 0x005F1A2B
		private const float D_NAME_Y = 12f; // Metadata: 0x005F1A2F
		private const float D_NAME_W = 430f; // Metadata: 0x005F1A33
		private const float D_NAME_H = 36f; // Metadata: 0x005F1A37
		private const float D_NAME_FS = 30f; // Metadata: 0x005F1A3B
		private const float D_STAR_Y = 49f; // Metadata: 0x005F1A3F
		private const float D_STAR = 22f; // Metadata: 0x005F1A43
		private const float D_STAR_GAP = 3f; // Metadata: 0x005F1A47
		private const float D_RARITY_H = 26f; // Metadata: 0x005F1A4B
		private const float D_RARITY_FS = 18f; // Metadata: 0x005F1A4F
		private const float D_DIV1_Y = 90f; // Metadata: 0x005F1A53
		private const float D_STAT_Y = 100f; // Metadata: 0x005F1A57
		private const float D_STAT_H = 36f; // Metadata: 0x005F1A5B
		private const float D_STAT_W = 168f; // Metadata: 0x005F1A5F
		private const float D_STAT_STEP = 176f; // Metadata: 0x005F1A63
		private const float D_STAT_ICON = 30f; // Metadata: 0x005F1A67
		private const float D_STAT_FS = 22f; // Metadata: 0x005F1A6B
		private const float D_ELEM_Y = 144f; // Metadata: 0x005F1A6F
		private const float D_ELEM_H = 30f; // Metadata: 0x005F1A73
		private const float D_ELEM_W = 104f; // Metadata: 0x005F1A77
		private const float D_ELEM_STEP = 107f; // Metadata: 0x005F1A7B
		private const float D_ELEM_ICON = 24f; // Metadata: 0x005F1A7F
		private const float D_ELEM_FS = 18f; // Metadata: 0x005F1A83
		private const float D_SET_Y = 184f; // Metadata: 0x005F1A87
		private const float D_SET_H = 116f; // Metadata: 0x005F1A8B
		private const float D_SET_INSET = 18f; // Metadata: 0x005F1A8F
		private const float D_SETTITLE_Y = 6f; // Metadata: 0x005F1A93
		private const float D_SETTITLE_H = 30f; // Metadata: 0x005F1A97
		private const float D_SETTITLE_FS = 22f; // Metadata: 0x005F1A9B
		private const float D_SETBONUS_Y = 38f; // Metadata: 0x005F1A9F
		private const float D_SETBONUS_H = 72f; // Metadata: 0x005F1AA3
		private const float D_SETBONUS_FS = 20f; // Metadata: 0x005F1AA7
		private const float D_FOOT = 72f; // Metadata: 0x005F1AAB
		private const float D_BTN_W = 128f; // Metadata: 0x005F1AAF
		private const float D_BTN_H = 44f; // Metadata: 0x005F1AB3
		private const float D_BTN_FS = 22f; // Metadata: 0x005F1AB7
		private const float D_BTN_MARGIN = 20f; // Metadata: 0x005F1ABB
		private const float D_BTN_GAP = 8f; // Metadata: 0x005F1ABF
		private const float D_BTN_BOTTOM = 14f; // Metadata: 0x005F1AC3
		private const float D_POWER_W = 300f; // Metadata: 0x005F1AC7
		private const float D_POWER_H = 34f; // Metadata: 0x005F1ACB
		private const float D_POWER_FS = 23f; // Metadata: 0x005F1ACF
		private const float D_COMPARE_H = 24f; // Metadata: 0x005F1AD3
		private const float D_COMPARE_FS = 18f; // Metadata: 0x005F1AD7
		private const float D_COMPARE_EXTRA = 26f; // Metadata: 0x005F1ADB
		private const float D_TOOL_ROW = 54f; // Metadata: 0x005F1ADF
		private const float SALVAGE_CONFIRM_SEC = 4f; // Metadata: 0x005F1AE3
		private const float D_H_COMPACT = 256f; // Metadata: 0x005F1AE7
		private const float D_H_EXPANDED = 384f; // Metadata: 0x005F1AEB
		private const float D_BLOCK_GAP = 12f; // Metadata: 0x005F1AEF
		private const float CHIP_ROW_GAP = 10f; // Metadata: 0x005F1AF3
		private const float D_PERK_PAD_TOP = 6f; // Metadata: 0x005F1AF7
		private const float D_PERK_PAD_BOTTOM = 8f; // Metadata: 0x005F1AFB
		private const float D_PERKTITLE_H = 26f; // Metadata: 0x005F1AFF
		private const float D_PERKTITLE_FS = 20f; // Metadata: 0x005F1B03
		private const float D_PERK_ROW_H = 34f; // Metadata: 0x005F1B07
		private const float D_PERK_ROW_HINT_H = 54f; // Metadata: 0x005F1B0B
		private const float D_PERK_ICON_X = 18f; // Metadata: 0x005F1B0F
		private const float D_PERK_ICON = 28f; // Metadata: 0x005F1B13
		private const float D_PERK_LABEL_FS = 20f; // Metadata: 0x005F1B17
		private const float D_PERK_VALUE_FS = 22f; // Metadata: 0x005F1B1B
		private const float D_PERK_HINT_FS = 15f; // Metadata: 0x005F1B1F
		private const float D_PERK_VALUE_W = 110f; // Metadata: 0x005F1B23
		private const float D_PERKMORE_H = 24f; // Metadata: 0x005F1B27
		private const float D_PERKMORE_FS = 17f; // Metadata: 0x005F1B2B
		private const float D_PERK_LABEL_X = 56f; // Metadata: 0x005F1B2F
		private const float D_PERK_LABEL_W = 349f; // Metadata: 0x005F1B33
		private const float D_PERKNOTE_H = 26f; // Metadata: 0x005F1B37
		private const float D_PERKNOTE_FS = 15f; // Metadata: 0x005F1B3B
		private const int PERKTEXT_WRAP_CHARS = 44; // Metadata: 0x005F1B3F
		public const int MaxPerkRows = 6; // Metadata: 0x005F1B40
		private const float D_SET_HINT_H = 24f; // Metadata: 0x005F1B41
		private const float D_SET_HINT_FS = 17f; // Metadata: 0x005F1B45
		private const float D_MEMBER_CELL_W = 100f; // Metadata: 0x005F1B49
		private const float D_MEMBER_CELL_H = 80f; // Metadata: 0x005F1B4D
		private const float D_MEMBER_NAME_H = 22f; // Metadata: 0x005F1B51
		private const float D_MEMBER_NAME_FS = 14f; // Metadata: 0x005F1B55
		private const float D_MEMBER_STATE_H = 20f; // Metadata: 0x005F1B59
		private const float D_MEMBER_STATE_FS = 14f; // Metadata: 0x005F1B5D
		private const float D_MEMBER_TICK = 18f; // Metadata: 0x005F1B61
		public const int MaxSetMembers = 10; // Metadata: 0x005F1B65
		private const float MIN_FIT_SCALE = 0.55f; // Metadata: 0x005F1B66
		private const float FX_REOPEN_GUARD = 0.3f; // Metadata: 0x005F1B6A
		public const string FLAG_AFFIX_UI = "equip.affix.ui"; // Metadata: 0x005F1B6E
		public const string FLAG_AFFIX_FX = "equip.affix.fx"; // Metadata: 0x005F1B7D
		public const float GAP = 11.7f; // Metadata: 0x005F1B8C
		public const float MARGIN = 10.4f; // Metadata: 0x005F1B90
		private const float BLOCKER_ALPHA = 0.25f; // Metadata: 0x005F1B94
		private const string ManaColor = "#4FD8E4"; // Metadata: 0x005F1B98
		private const string HpColor = "#F0A030"; // Metadata: 0x005F1BA0
		private const string AtkColor = "#4FD8E4"; // Metadata: 0x005F1BA8
		private static readonly string[] ElementNames; // 0x00
		private static readonly string[] ElementColors; // 0x08
		private static readonly Color BodyColor; // 0x10
		private static readonly Color StarOn; // 0x20
		private static readonly Color StarOff; // 0x30
		private static readonly Color BtnTint; // 0x40
		private static readonly Color MemberMissingTint; // 0x50
		private static readonly Color MemberMissingText; // 0x60
		public static Sprite StarSprite; // 0x70
		public RectTransform panel; // 0x20
		public Button blocker; // 0x28
		public Image imgShadow; // 0x30
		public Image imgPanel; // 0x38
		public Image imgIconFrame; // 0x40
		public Image imgIcon; // 0x48
		public Image imgSetBg; // 0x50
		public UnityEngine.UI.Text txtName; // 0x58
		public UnityEngine.UI.Text txtRarity; // 0x60
		public UnityEngine.UI.Text txtStarsFallback; // 0x68
		public UnityEngine.UI.Text txtSetTitle; // 0x70
		public UnityEngine.UI.Text txtSetBonus; // 0x78
		public UnityEngine.UI.Text txtPower; // 0x80
		public UnityEngine.UI.Text txtCompare; // 0x88
		public Image[] imgStars; // 0x90
		public InfoPlayerTooltipKit.Chip[] statChips; // 0x98
		public InfoPlayerTooltipKit.Chip[] elemChips; // 0xA0
		public GameObject secSetBonus; // 0xA8
		public Button btnEquip; // 0xB0
		public Button btnUnequip; // 0xB8
		public Button btnAvatarToggle; // 0xC0
		public UnityEngine.UI.Text txtAvatarToggle; // 0xC8
		public Button btnUpgrade; // 0xD0
		public Button btnSalvage; // 0xD8
		public UnityEngine.UI.Text txtUpgrade; // 0xE0
		public UnityEngine.UI.Text txtSalvage; // 0xE8
		public UnityEngine.UI.Text txtShards; // 0xF0
		public GameObject secPerks; // 0xF8
		public Image imgPerkBg; // 0x100
		public UnityEngine.UI.Text txtPerkTitle; // 0x108
		public UnityEngine.UI.Text txtPerkMore; // 0x110
		public UnityEngine.UI.Text txtPerkNote; // 0x118
		public PerkRow[] perkRows; // 0x120
		public GameObject secSet; // 0x128
		public GameObject gridSetMembers; // 0x130
		public UnityEngine.UI.Text txtSetHint; // 0x138
		public MemberCell[] memberCells; // 0x140
		private CanvasGroup _group; // 0x148
		private bool _built; // 0x150
		private bool _hasSet; // 0x151
		private bool _hasCompare; // 0x152
		private bool _hasTools; // 0x153
		private bool _hasPerks; // 0x154
		private bool _hasMembers; // 0x155
		private float _perkBlockH; // 0x158
		private float _setBlockH; // 0x15C
		private float _contentTop; // 0x160
		private int _memberToken; // 0x164
		private float _lastOpenAt; // 0x168
		private int _iconToken; // 0x16C
		private long _shownPower; // 0x170
		private Action _equipAction; // 0x178
		private Action _unequipAction; // 0x180
		private Action _avatarAction; // 0x188
		private Action _upgradeAction; // 0x190
		private Action _salvageAction; // 0x198
		private float _salvageArmedUntil; // 0x1A0
		private int _shownShardCost; // 0x1A4
		private int _shownSalvageShards; // 0x1A8
		private RectTransform[] _liftNodes; // 0x1B0
		private Vector2[] _liftBase; // 0x1B8
		private static EquipTooltipView _instance; // 0x78
		private readonly StringBuilder _builder; // 0x1C0
		public static Action<EquipSetMemberDTO, RectTransform> MemberTapped; // 0x80
		private const float D_BLOCK_W = 539f; // Metadata: 0x005F1BB0
	
		// Properties
		public static bool Enabled { get; } // 0x0000000180CCE140-0x0000000180CCE1B0 
		public static bool IsShowing { get; } // 0x0000000180CCE1B0-0x0000000180CCE340 
		public static float PanelW { get; } // 0x0000000180CCEB50-0x0000000180CCEB60 
		public static float PanelHCompact { get; } // 0x0000000180CCEB60-0x0000000180CCEB70 
		public static float PanelHExpanded { get; } // 0x0000000180CCEB70-0x0000000180CCEB80 
		public static bool AffixUiOn { get; } // 0x0000000180CD7530-0x0000000180CD75A0 
		private static bool AffixFxOn { get; } // 0x0000000180CD75A0-0x0000000180CD7660 
	
		// Nested types
		public struct Actions // TypeDefIndex: 2784
		{
			// Fields
			public Action Equip; // 0x00
			public Action Unequip; // 0x08
			public Action ToggleAvatar; // 0x10
			public bool AvatarHidden; // 0x18
			public bool CompareKnown; // 0x19
			public EquipItemDTO CompareWith; // 0x20
			public Action Upgrade; // 0x28
			public Action Salvage; // 0x30
			public int ShardCount; // 0x38
		}
	
		public struct PerkRow // TypeDefIndex: 2785
		{
			// Fields
			public RectTransform root; // 0x00
			public CanvasGroup group; // 0x08
			public Image icon; // 0x10
			public UnityEngine.UI.Text label; // 0x18
			public UnityEngine.UI.Text value; // 0x20
			public UnityEngine.UI.Text hint; // 0x28
		}
	
		public struct MemberCell // TypeDefIndex: 2786
		{
			// Fields
			public RectTransform root; // 0x00
			public Image frame; // 0x08
			public Image icon; // 0x10
			public Image tick; // 0x18
			public UnityEngine.UI.Text name; // 0x20
			public UnityEngine.UI.Text state; // 0x28
			public UnityEngine.UI.Text tickMark; // 0x30
			public Button tap; // 0x38
		}
	
		public enum Side : byte // TypeDefIndex: 2787
		{
			Above = 0,
			Below = 1,
			Right = 2,
			Left = 3
		}
	
		public struct Placement // TypeDefIndex: 2788
		{
			// Fields
			public Vector2 anchoredPosition; // 0x00
			public Vector2 pivot; // 0x08
			public Side side; // 0x10
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass208_0 // TypeDefIndex: 2789
		{
			// Fields
			public int token; // 0x10
			public EquipTooltipView __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass208_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _ApplyIcon_b__0(Sprite sp); // 0x0000000180CE16A0-0x0000000180CE18A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass218_0 // TypeDefIndex: 2790
		{
			// Fields
			public Image target; // 0x10
	
			// Constructors
			public __c__DisplayClass218_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BindPerkRow_b__0(Sprite sp); // 0x0000000180CE18A0-0x0000000180CE1B90
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass226_0 // TypeDefIndex: 2791
		{
			// Fields
			public EquipSetMemberDTO member; // 0x10
			public RectTransform anchor; // 0x18
	
			// Constructors
			public __c__DisplayClass226_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BindMemberTap_b__0(); // 0x0000000180CE1B90-0x0000000180CE1C20
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass228_0 // TypeDefIndex: 2792
		{
			// Fields
			public int token; // 0x10
			public EquipTooltipView __4__this; // 0x18
			public Image img; // 0x20
			public Color ready; // 0x28
	
			// Constructors
			public __c__DisplayClass228_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _ApplyMemberIcon_b__0(Sprite sp); // 0x0000000180CE1C20-0x0000000180CE1E00
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass238_0 // TypeDefIndex: 2793
		{
			// Fields
			public RectTransform rt; // 0x10
			public CanvasGroup cg; // 0x18
			public Vector2 start; // 0x20
			public Vector2 target; // 0x28
			public GameObject valueGo; // 0x30
	
			// Constructors
			public __c__DisplayClass238_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PlayAffixFx_b__0(float t); // 0x0000000180CE1E00-0x0000000180CE2030
			internal void _PlayAffixFx_b__1(); // 0x0000000180CE2030-0x0000000180CE2230
			internal void _PlayAffixFx_b__2(); // 0x0000000180CE2230-0x0000000180CE23B0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass238_1 // TypeDefIndex: 2794
		{
			// Fields
			public GameObject cell; // 0x10
	
			// Constructors
			public __c__DisplayClass238_1(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PlayAffixFx_b__3(); // 0x0000000180CE23B0-0x0000000180CE2530
		}
	
		// Constructors
		public EquipTooltipView(); // 0x0000000180CE0E30-0x0000000180CE11D0
		static EquipTooltipView(); // 0x0000000180CE11D0-0x0000000180CE1550
	
		// Methods
		public static void Show(RectTransform anchor, EquipItemDTO item, Actions actions); // 0x0000000180CCE340-0x0000000180CCE4D0
		public static void Hide(); // 0x0000000180CCE4D0-0x0000000180CCE680
		private static EquipTooltipView Resolve(); // 0x0000000180CCE680-0x0000000180CCE9B0
		public static EquipTooltipView Spawn(); // 0x0000000180CCE9B0-0x0000000180CCEB50
		private void Awake(); // 0x0000000180CCEB80-0x0000000180CCED80
		private void OnDestroy(); // 0x0000000180CCED80-0x0000000180CCEF60
		private void OnDisable(); // 0x0000000180CCEF60-0x0000000180CCF2E0
		private void EnsureBuilt(); // 0x0000000180CCF2E0-0x0000000180CD1720
		private void BuildPerkSection(); // 0x0000000180CD1720-0x0000000180CD2C60
		private void BuildSetSection(); // 0x0000000180CD2C60-0x0000000180CD4840
		private static void SetRect(RectTransform rt, float dx, float dy, float dw, float dh); // 0x0000000180CD4840-0x0000000180CD49D0
		private void Present(RectTransform anchor, EquipItemDTO item, Actions actions); // 0x0000000180CD49D0-0x0000000180CD4DC0
		private float FitScale(); // 0x0000000180CD4DC0-0x0000000180CD5170
		private void OpenPanel(float fit); // 0x0000000180CD5170-0x0000000180CD55B0
		public void Fill(EquipItemDTO item); // 0x0000000180CD55B0-0x0000000180CD58C0
		private void BindChips(EquipItemDTO item); // 0x0000000180CD58C0-0x0000000180CD5EC0
		private static void ShowChip(InfoPlayerTooltipKit.Chip c, bool on, float dx, float dy, float dw, float dh); // 0x0000000180CD5EC0-0x0000000180CD6150
		private static string RarityLine(EquipItemDTO item); // 0x0000000180CD6150-0x0000000180CD6370
		private void Relayout(); // 0x0000000180CD6370-0x0000000180CD6960
		private void ApplyIcon(long iconId); // 0x0000000180CD6960-0x0000000180CD6D40
		private void ApplyStars(int star, int maxStar); // 0x0000000180CD6D40-0x0000000180CD7530
		private static string SafeFormat(string format, string fallback, params object[] args); // 0x0000000180CD7660-0x0000000180CD7840
		private bool BindPerks(EquipItemDTO item); // 0x0000000180CD7840-0x0000000180CD86F0
		private float BindPerkNote(InfoPlayerConfig.StringsCfg s, float y); // 0x0000000180CD86F0-0x0000000180CD8A70
		private void BindPerkTextRow(int index, string text, ref float y); // 0x0000000180CD8A70-0x0000000180CD92A0
		private void BindPerkRow(int index, EquipPerkDTO p, string label, ref float y); // 0x0000000180CD92A0-0x0000000180CDA210
		private void HidePerkRows(int from); // 0x0000000180CDA210-0x0000000180CDA3B0
		private static string PerkLabel(EquipPerkDTO p); // 0x0000000180CDA3B0-0x0000000180CDA450
		private static bool IsLuckPerk(EquipPerkDTO p); // 0x0000000180CDA450-0x0000000180CDA5B0
		private bool BindSetBlock(EquipItemDTO item, bool allowPerkText); // 0x0000000180CDA5B0-0x0000000180CDB930
		private void LayoutSetBlock(float gridH, bool hint); // 0x0000000180CDB930-0x0000000180CDBD20
		private float BindMembers(EquipItemDTO item, int memberCount); // 0x0000000180CDBD20-0x0000000180CDC460
		private void BindMemberCell(MemberCell c, EquipSetMemberDTO m, float frame, float iconSize, float cellW); // 0x0000000180CDC460-0x0000000180CDCF20
		private void BindMemberTap(MemberCell c, EquipSetMemberDTO m, float cellW); // 0x0000000180CDCF20-0x0000000180CDD3C0
		private static string MemberName(EquipSetMemberDTO m); // 0x0000000180CDD3C0-0x0000000180CDD4B0
		private void ApplyMemberIcon(Image img, long iconId, Color ready); // 0x0000000180CDD4B0-0x0000000180CDD930
		private void ApplyCompare(Actions actions); // 0x0000000180CDD930-0x0000000180CDDFA0
		public void SetActions(Actions actions); // 0x0000000180CDDFA0-0x0000000180CDE3E0
		private void ApplyTools(Actions actions); // 0x0000000180CDE3E0-0x0000000180CDEBB0
		private void OnUpgradeClicked(); // 0x0000000180CDEBB0-0x0000000180CDECB0
		private void OnSalvageClicked(); // 0x0000000180CDECB0-0x0000000180CDEF80
		private void OnEquipClicked(); // 0x0000000180CDEF80-0x0000000180CDF080
		private void OnUnequipClicked(); // 0x0000000180CDF080-0x0000000180CDF180
		private void OnAvatarToggleClicked(); // 0x0000000180CDF180-0x0000000180CDF260
		private void ClosePanel(); // 0x0000000180CDF260-0x0000000180CDF480
		private void PlayAffixFx(); // 0x0000000180CDF480-0x0000000180CE03A0
		private void CancelFx(); // 0x0000000180CE03A0-0x0000000180CE0990
		private static void AppendBonus(StringBuilder b, string color, string label, long value); // 0x0000000180CE0990-0x0000000180CE0AC0
		public static Placement Solve(Rect safe, Rect target, Vector2 size, float gap, float margin); // 0x0000000180CE0AC0-0x0000000180CE0E30
		private static float ClampAxis(float value, float pivot, float size, float min, float max, float center, float margin); // 0x0000000180A15190-0x0000000180A15200
		[CompilerGenerated]
		private void _ClosePanel_b__237_0(); // 0x0000000180CE1550-0x0000000180CE16A0
	}
}
