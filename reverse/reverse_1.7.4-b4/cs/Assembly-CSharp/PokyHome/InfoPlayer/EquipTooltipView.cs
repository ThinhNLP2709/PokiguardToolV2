/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class EquipTooltipView : MonoBehaviour // TypeDefIndex: 2790
	{
		// Fields
		public const string FLAG = "infoplayer.tooltip"; // Metadata: 0x005F2DD5
		public const string ROOT_NAME = "EquipTooltip"; // Metadata: 0x005F2DE8
		public const string ART_DIR = "Image/InfoPlayer/"; // Metadata: 0x005F2DF5
		public const string SP_PANEL = "Image/InfoPlayer/tooltip_panel"; // Metadata: 0x005F2E07
		public const float K = 0.65f; // Metadata: 0x005F2E26
		private const float D_W = 575f; // Metadata: 0x005F2E2A
		private const float D_PAD = 22f; // Metadata: 0x005F2E2E
		private const float D_FRAME_X = 18f; // Metadata: 0x005F2E32
		private const float D_FRAME_Y = 12f; // Metadata: 0x005F2E36
		private const float D_FRAME = 68f; // Metadata: 0x005F2E3A
		private const float D_ICON_INSET = 7f; // Metadata: 0x005F2E3E
		private const float D_NAME_X = 98f; // Metadata: 0x005F2E42
		private const float D_NAME_Y = 12f; // Metadata: 0x005F2E46
		private const float D_NAME_W = 430f; // Metadata: 0x005F2E4A
		private const float D_NAME_H = 36f; // Metadata: 0x005F2E4E
		private const float D_NAME_FS = 30f; // Metadata: 0x005F2E52
		private const float D_STAR_Y = 49f; // Metadata: 0x005F2E56
		private const float D_STAR = 22f; // Metadata: 0x005F2E5A
		private const float D_STAR_GAP = 3f; // Metadata: 0x005F2E5E
		private const float D_RARITY_H = 26f; // Metadata: 0x005F2E62
		private const float D_RARITY_FS = 18f; // Metadata: 0x005F2E66
		private const float D_DIV1_Y = 90f; // Metadata: 0x005F2E6A
		private const float D_STAT_Y = 100f; // Metadata: 0x005F2E6E
		private const float D_STAT_H = 36f; // Metadata: 0x005F2E72
		private const float D_STAT_W = 168f; // Metadata: 0x005F2E76
		private const float D_STAT_STEP = 176f; // Metadata: 0x005F2E7A
		private const float D_STAT_ICON = 30f; // Metadata: 0x005F2E7E
		private const float D_STAT_FS = 22f; // Metadata: 0x005F2E82
		private const float D_ELEM_Y = 144f; // Metadata: 0x005F2E86
		private const float D_ELEM_H = 30f; // Metadata: 0x005F2E8A
		private const float D_ELEM_W = 104f; // Metadata: 0x005F2E8E
		private const float D_ELEM_STEP = 107f; // Metadata: 0x005F2E92
		private const float D_ELEM_ICON = 24f; // Metadata: 0x005F2E96
		private const float D_ELEM_FS = 18f; // Metadata: 0x005F2E9A
		private const float D_SET_Y = 184f; // Metadata: 0x005F2E9E
		private const float D_SET_H = 116f; // Metadata: 0x005F2EA2
		private const float D_SET_INSET = 18f; // Metadata: 0x005F2EA6
		private const float D_SETTITLE_Y = 6f; // Metadata: 0x005F2EAA
		private const float D_SETTITLE_H = 30f; // Metadata: 0x005F2EAE
		private const float D_SETTITLE_FS = 22f; // Metadata: 0x005F2EB2
		private const float D_SETBONUS_Y = 38f; // Metadata: 0x005F2EB6
		private const float D_SETBONUS_H = 72f; // Metadata: 0x005F2EBA
		private const float D_SETBONUS_FS = 20f; // Metadata: 0x005F2EBE
		private const float D_FOOT = 72f; // Metadata: 0x005F2EC2
		private const float D_BTN_W = 128f; // Metadata: 0x005F2EC6
		private const float D_BTN_H = 44f; // Metadata: 0x005F2ECA
		private const float D_BTN_FS = 22f; // Metadata: 0x005F2ECE
		private const float D_BTN_MARGIN = 20f; // Metadata: 0x005F2ED2
		private const float D_BTN_GAP = 8f; // Metadata: 0x005F2ED6
		private const float D_BTN_BOTTOM = 14f; // Metadata: 0x005F2EDA
		private const float D_POWER_W = 300f; // Metadata: 0x005F2EDE
		private const float D_POWER_H = 34f; // Metadata: 0x005F2EE2
		private const float D_POWER_FS = 23f; // Metadata: 0x005F2EE6
		private const float D_COMPARE_H = 24f; // Metadata: 0x005F2EEA
		private const float D_COMPARE_FS = 18f; // Metadata: 0x005F2EEE
		private const float D_COMPARE_EXTRA = 26f; // Metadata: 0x005F2EF2
		private const float D_TOOL_ROW = 54f; // Metadata: 0x005F2EF6
		private const float SALVAGE_CONFIRM_SEC = 4f; // Metadata: 0x005F2EFA
		private const float D_H_COMPACT = 256f; // Metadata: 0x005F2EFE
		private const float D_H_EXPANDED = 384f; // Metadata: 0x005F2F02
		private const float D_BLOCK_GAP = 12f; // Metadata: 0x005F2F06
		private const float CHIP_ROW_GAP = 10f; // Metadata: 0x005F2F0A
		private const float D_PERK_PAD_TOP = 6f; // Metadata: 0x005F2F0E
		private const float D_PERK_PAD_BOTTOM = 8f; // Metadata: 0x005F2F12
		private const float D_PERKTITLE_H = 26f; // Metadata: 0x005F2F16
		private const float D_PERKTITLE_FS = 20f; // Metadata: 0x005F2F1A
		private const float D_PERK_ROW_H = 34f; // Metadata: 0x005F2F1E
		private const float D_PERK_ROW_HINT_H = 54f; // Metadata: 0x005F2F22
		private const float D_PERK_ICON_X = 18f; // Metadata: 0x005F2F26
		private const float D_PERK_ICON = 28f; // Metadata: 0x005F2F2A
		private const float D_PERK_LABEL_FS = 20f; // Metadata: 0x005F2F2E
		private const float D_PERK_VALUE_FS = 22f; // Metadata: 0x005F2F32
		private const float D_PERK_HINT_FS = 15f; // Metadata: 0x005F2F36
		private const float D_PERK_VALUE_W = 110f; // Metadata: 0x005F2F3A
		private const float D_PERKMORE_H = 24f; // Metadata: 0x005F2F3E
		private const float D_PERKMORE_FS = 17f; // Metadata: 0x005F2F42
		private const float D_PERK_LABEL_X = 56f; // Metadata: 0x005F2F46
		private const float D_PERK_LABEL_W = 349f; // Metadata: 0x005F2F4A
		private const float D_PERKNOTE_H = 26f; // Metadata: 0x005F2F4E
		private const float D_PERKNOTE_FS = 15f; // Metadata: 0x005F2F52
		private const int PERKTEXT_WRAP_CHARS = 44; // Metadata: 0x005F2F56
		public const int MaxPerkRows = 6; // Metadata: 0x005F2F57
		private const float D_SET_HINT_H = 24f; // Metadata: 0x005F2F58
		private const float D_SET_HINT_FS = 17f; // Metadata: 0x005F2F5C
		private const float D_MEMBER_CELL_W = 100f; // Metadata: 0x005F2F60
		private const float D_MEMBER_CELL_H = 80f; // Metadata: 0x005F2F64
		private const float D_MEMBER_NAME_H = 22f; // Metadata: 0x005F2F68
		private const float D_MEMBER_NAME_FS = 14f; // Metadata: 0x005F2F6C
		private const float D_MEMBER_STATE_H = 20f; // Metadata: 0x005F2F70
		private const float D_MEMBER_STATE_FS = 14f; // Metadata: 0x005F2F74
		private const float D_MEMBER_TICK = 18f; // Metadata: 0x005F2F78
		public const int MaxSetMembers = 10; // Metadata: 0x005F2F7C
		private const float MIN_FIT_SCALE = 0.55f; // Metadata: 0x005F2F7D
		private const float FX_REOPEN_GUARD = 0.3f; // Metadata: 0x005F2F81
		public const string FLAG_AFFIX_UI = "equip.affix.ui"; // Metadata: 0x005F2F85
		public const string FLAG_AFFIX_FX = "equip.affix.fx"; // Metadata: 0x005F2F94
		public const float GAP = 11.7f; // Metadata: 0x005F2FA3
		public const float MARGIN = 10.4f; // Metadata: 0x005F2FA7
		private const float BLOCKER_ALPHA = 0.25f; // Metadata: 0x005F2FAB
		private const string ManaColor = "#4FD8E4"; // Metadata: 0x005F2FAF
		private const string HpColor = "#F0A030"; // Metadata: 0x005F2FB7
		private const string AtkColor = "#4FD8E4"; // Metadata: 0x005F2FBF
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
		private const float D_BLOCK_W = 539f; // Metadata: 0x005F2FC7
	
		// Properties
		public static bool Enabled { get; } // 0x0000000180CDB9C0-0x0000000180CDBA30 
		public static bool IsShowing { get; } // 0x0000000180CDBA30-0x0000000180CDBBC0 
		public static float PanelW { get; } // 0x0000000180CDC3D0-0x0000000180CDC3E0 
		public static float PanelHCompact { get; } // 0x0000000180CDC3E0-0x0000000180CDC3F0 
		public static float PanelHExpanded { get; } // 0x0000000180CDC3F0-0x0000000180CDC400 
		public static bool AffixUiOn { get; } // 0x0000000180CE4DB0-0x0000000180CE4E20 
		private static bool AffixFxOn { get; } // 0x0000000180CE4E20-0x0000000180CE4EE0 
	
		// Nested types
		public struct Actions // TypeDefIndex: 2791
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
	
		public struct PerkRow // TypeDefIndex: 2792
		{
			// Fields
			public RectTransform root; // 0x00
			public CanvasGroup group; // 0x08
			public Image icon; // 0x10
			public UnityEngine.UI.Text label; // 0x18
			public UnityEngine.UI.Text value; // 0x20
			public UnityEngine.UI.Text hint; // 0x28
		}
	
		public struct MemberCell // TypeDefIndex: 2793
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
	
		public enum Side : byte // TypeDefIndex: 2794
		{
			Above = 0,
			Below = 1,
			Right = 2,
			Left = 3
		}
	
		public struct Placement // TypeDefIndex: 2795
		{
			// Fields
			public Vector2 anchoredPosition; // 0x00
			public Vector2 pivot; // 0x08
			public Side side; // 0x10
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass208_0 // TypeDefIndex: 2796
		{
			// Fields
			public int token; // 0x10
			public EquipTooltipView __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass208_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _ApplyIcon_b__0(Sprite sp); // 0x0000000180CEEF20-0x0000000180CEF120
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass218_0 // TypeDefIndex: 2797
		{
			// Fields
			public Image target; // 0x10
	
			// Constructors
			public __c__DisplayClass218_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BindPerkRow_b__0(Sprite sp); // 0x0000000180CEF120-0x0000000180CEF410
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass226_0 // TypeDefIndex: 2798
		{
			// Fields
			public EquipSetMemberDTO member; // 0x10
			public RectTransform anchor; // 0x18
	
			// Constructors
			public __c__DisplayClass226_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BindMemberTap_b__0(); // 0x0000000180CEF410-0x0000000180CEF4A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass228_0 // TypeDefIndex: 2799
		{
			// Fields
			public int token; // 0x10
			public EquipTooltipView __4__this; // 0x18
			public Image img; // 0x20
			public Color ready; // 0x28
	
			// Constructors
			public __c__DisplayClass228_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _ApplyMemberIcon_b__0(Sprite sp); // 0x0000000180CEF4A0-0x0000000180CEF680
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass238_0 // TypeDefIndex: 2800
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
			internal void _PlayAffixFx_b__0(float t); // 0x0000000180CEF680-0x0000000180CEF8B0
			internal void _PlayAffixFx_b__1(); // 0x0000000180CEF8B0-0x0000000180CEFAB0
			internal void _PlayAffixFx_b__2(); // 0x0000000180CEFAB0-0x0000000180CEFC30
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass238_1 // TypeDefIndex: 2801
		{
			// Fields
			public GameObject cell; // 0x10
	
			// Constructors
			public __c__DisplayClass238_1(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PlayAffixFx_b__3(); // 0x0000000180CEFC30-0x0000000180CEFDB0
		}
	
		// Constructors
		public EquipTooltipView(); // 0x0000000180CEE6B0-0x0000000180CEEA50
		static EquipTooltipView(); // 0x0000000180CEEA50-0x0000000180CEEDD0
	
		// Methods
		public static void Show(RectTransform anchor, EquipItemDTO item, Actions actions); // 0x0000000180CDBBC0-0x0000000180CDBD50
		public static void Hide(); // 0x0000000180CDBD50-0x0000000180CDBF00
		private static EquipTooltipView Resolve(); // 0x0000000180CDBF00-0x0000000180CDC230
		public static EquipTooltipView Spawn(); // 0x0000000180CDC230-0x0000000180CDC3D0
		private void Awake(); // 0x0000000180CDC400-0x0000000180CDC600
		private void OnDestroy(); // 0x0000000180CDC600-0x0000000180CDC7E0
		private void OnDisable(); // 0x0000000180CDC7E0-0x0000000180CDCB60
		private void EnsureBuilt(); // 0x0000000180CDCB60-0x0000000180CDEFA0
		private void BuildPerkSection(); // 0x0000000180CDEFA0-0x0000000180CE04E0
		private void BuildSetSection(); // 0x0000000180CE04E0-0x0000000180CE20C0
		private static void SetRect(RectTransform rt, float dx, float dy, float dw, float dh); // 0x0000000180CE20C0-0x0000000180CE2250
		private void Present(RectTransform anchor, EquipItemDTO item, Actions actions); // 0x0000000180CE2250-0x0000000180CE2640
		private float FitScale(); // 0x0000000180CE2640-0x0000000180CE29F0
		private void OpenPanel(float fit); // 0x0000000180CE29F0-0x0000000180CE2E30
		public void Fill(EquipItemDTO item); // 0x0000000180CE2E30-0x0000000180CE3140
		private void BindChips(EquipItemDTO item); // 0x0000000180CE3140-0x0000000180CE3740
		private static void ShowChip(InfoPlayerTooltipKit.Chip c, bool on, float dx, float dy, float dw, float dh); // 0x0000000180CE3740-0x0000000180CE39D0
		private static string RarityLine(EquipItemDTO item); // 0x0000000180CE39D0-0x0000000180CE3BF0
		private void Relayout(); // 0x0000000180CE3BF0-0x0000000180CE41E0
		private void ApplyIcon(long iconId); // 0x0000000180CE41E0-0x0000000180CE45C0
		private void ApplyStars(int star, int maxStar); // 0x0000000180CE45C0-0x0000000180CE4DB0
		private static string SafeFormat(string format, string fallback, params object[] args); // 0x0000000180CE4EE0-0x0000000180CE50C0
		private bool BindPerks(EquipItemDTO item); // 0x0000000180CE50C0-0x0000000180CE5F70
		private float BindPerkNote(InfoPlayerConfig.StringsCfg s, float y); // 0x0000000180CE5F70-0x0000000180CE62F0
		private void BindPerkTextRow(int index, string text, ref float y); // 0x0000000180CE62F0-0x0000000180CE6B20
		private void BindPerkRow(int index, EquipPerkDTO p, string label, ref float y); // 0x0000000180CE6B20-0x0000000180CE7A90
		private void HidePerkRows(int from); // 0x0000000180CE7A90-0x0000000180CE7C30
		private static string PerkLabel(EquipPerkDTO p); // 0x0000000180CE7C30-0x0000000180CE7CD0
		private static bool IsLuckPerk(EquipPerkDTO p); // 0x0000000180CE7CD0-0x0000000180CE7E30
		private bool BindSetBlock(EquipItemDTO item, bool allowPerkText); // 0x0000000180CE7E30-0x0000000180CE91B0
		private void LayoutSetBlock(float gridH, bool hint); // 0x0000000180CE91B0-0x0000000180CE95A0
		private float BindMembers(EquipItemDTO item, int memberCount); // 0x0000000180CE95A0-0x0000000180CE9CE0
		private void BindMemberCell(MemberCell c, EquipSetMemberDTO m, float frame, float iconSize, float cellW); // 0x0000000180CE9CE0-0x0000000180CEA7A0
		private void BindMemberTap(MemberCell c, EquipSetMemberDTO m, float cellW); // 0x0000000180CEA7A0-0x0000000180CEAC40
		private static string MemberName(EquipSetMemberDTO m); // 0x0000000180CEAC40-0x0000000180CEAD30
		private void ApplyMemberIcon(Image img, long iconId, Color ready); // 0x0000000180CEAD30-0x0000000180CEB1B0
		private void ApplyCompare(Actions actions); // 0x0000000180CEB1B0-0x0000000180CEB820
		public void SetActions(Actions actions); // 0x0000000180CEB820-0x0000000180CEBC60
		private void ApplyTools(Actions actions); // 0x0000000180CEBC60-0x0000000180CEC430
		private void OnUpgradeClicked(); // 0x0000000180CEC430-0x0000000180CEC530
		private void OnSalvageClicked(); // 0x0000000180CEC530-0x0000000180CEC800
		private void OnEquipClicked(); // 0x0000000180CEC800-0x0000000180CEC900
		private void OnUnequipClicked(); // 0x0000000180CEC900-0x0000000180CECA00
		private void OnAvatarToggleClicked(); // 0x0000000180CECA00-0x0000000180CECAE0
		private void ClosePanel(); // 0x0000000180CECAE0-0x0000000180CECD00
		private void PlayAffixFx(); // 0x0000000180CECD00-0x0000000180CEDC20
		private void CancelFx(); // 0x0000000180CEDC20-0x0000000180CEE210
		private static void AppendBonus(StringBuilder b, string color, string label, long value); // 0x0000000180CEE210-0x0000000180CEE340
		public static Placement Solve(Rect safe, Rect target, Vector2 size, float gap, float margin); // 0x0000000180CEE340-0x0000000180CEE6B0
		private static float ClampAxis(float value, float pivot, float size, float min, float max, float center, float margin); // 0x0000000180A18D80-0x0000000180A18DF0
		[CompilerGenerated]
		private void _ClosePanel_b__237_0(); // 0x0000000180CEEDD0-0x0000000180CEEF20
	}
}
