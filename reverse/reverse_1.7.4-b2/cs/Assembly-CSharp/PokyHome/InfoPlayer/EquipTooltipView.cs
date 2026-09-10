/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class EquipTooltipView : MonoBehaviour // TypeDefIndex: 2347
	{
		// Fields
		public const string FLAG = "infoplayer.tooltip"; // Metadata: 0x0068EBAB
		public const string ROOT_NAME = "EquipTooltip"; // Metadata: 0x0068EBBE
		public const string ART_DIR = "Image/InfoPlayer/"; // Metadata: 0x0068EBCB
		public const string SP_PANEL = "Image/InfoPlayer/tooltip_panel"; // Metadata: 0x0068EBDD
		public const float K = 0.65f; // Metadata: 0x0068EBFC
		private const float D_W = 575f; // Metadata: 0x0068EC00
		private const float D_PAD = 22f; // Metadata: 0x0068EC04
		private const float D_FRAME_X = 18f; // Metadata: 0x0068EC08
		private const float D_FRAME_Y = 12f; // Metadata: 0x0068EC0C
		private const float D_FRAME = 68f; // Metadata: 0x0068EC10
		private const float D_ICON_INSET = 7f; // Metadata: 0x0068EC14
		private const float D_NAME_X = 98f; // Metadata: 0x0068EC18
		private const float D_NAME_Y = 12f; // Metadata: 0x0068EC1C
		private const float D_NAME_W = 430f; // Metadata: 0x0068EC20
		private const float D_NAME_H = 36f; // Metadata: 0x0068EC24
		private const float D_NAME_FS = 30f; // Metadata: 0x0068EC28
		private const float D_STAR_Y = 49f; // Metadata: 0x0068EC2C
		private const float D_STAR = 22f; // Metadata: 0x0068EC30
		private const float D_STAR_GAP = 3f; // Metadata: 0x0068EC34
		private const float D_RARITY_H = 26f; // Metadata: 0x0068EC38
		private const float D_RARITY_FS = 18f; // Metadata: 0x0068EC3C
		private const float D_DIV1_Y = 90f; // Metadata: 0x0068EC40
		private const float D_STAT_Y = 100f; // Metadata: 0x0068EC44
		private const float D_STAT_H = 36f; // Metadata: 0x0068EC48
		private const float D_STAT_W = 168f; // Metadata: 0x0068EC4C
		private const float D_STAT_STEP = 176f; // Metadata: 0x0068EC50
		private const float D_STAT_ICON = 30f; // Metadata: 0x0068EC54
		private const float D_STAT_FS = 22f; // Metadata: 0x0068EC58
		private const float D_ELEM_Y = 144f; // Metadata: 0x0068EC5C
		private const float D_ELEM_H = 30f; // Metadata: 0x0068EC60
		private const float D_ELEM_W = 104f; // Metadata: 0x0068EC64
		private const float D_ELEM_STEP = 107f; // Metadata: 0x0068EC68
		private const float D_ELEM_ICON = 24f; // Metadata: 0x0068EC6C
		private const float D_ELEM_FS = 18f; // Metadata: 0x0068EC70
		private const float D_SET_Y = 184f; // Metadata: 0x0068EC74
		private const float D_SET_H = 116f; // Metadata: 0x0068EC78
		private const float D_SET_INSET = 18f; // Metadata: 0x0068EC7C
		private const float D_SETTITLE_Y = 6f; // Metadata: 0x0068EC80
		private const float D_SETTITLE_H = 30f; // Metadata: 0x0068EC84
		private const float D_SETTITLE_FS = 22f; // Metadata: 0x0068EC88
		private const float D_SETBONUS_Y = 38f; // Metadata: 0x0068EC8C
		private const float D_SETBONUS_H = 72f; // Metadata: 0x0068EC90
		private const float D_SETBONUS_FS = 20f; // Metadata: 0x0068EC94
		private const float D_FOOT = 72f; // Metadata: 0x0068EC98
		private const float D_BTN_W = 128f; // Metadata: 0x0068EC9C
		private const float D_BTN_H = 44f; // Metadata: 0x0068ECA0
		private const float D_BTN_FS = 22f; // Metadata: 0x0068ECA4
		private const float D_BTN_MARGIN = 20f; // Metadata: 0x0068ECA8
		private const float D_BTN_GAP = 8f; // Metadata: 0x0068ECAC
		private const float D_BTN_BOTTOM = 14f; // Metadata: 0x0068ECB0
		private const float D_POWER_W = 300f; // Metadata: 0x0068ECB4
		private const float D_POWER_H = 34f; // Metadata: 0x0068ECB8
		private const float D_POWER_FS = 23f; // Metadata: 0x0068ECBC
		private const float D_COMPARE_H = 24f; // Metadata: 0x0068ECC0
		private const float D_COMPARE_FS = 18f; // Metadata: 0x0068ECC4
		private const float D_COMPARE_EXTRA = 26f; // Metadata: 0x0068ECC8
		private const float D_TOOL_ROW = 54f; // Metadata: 0x0068ECCC
		private const float SALVAGE_CONFIRM_SEC = 4f; // Metadata: 0x0068ECD0
		private const float D_H_COMPACT = 256f; // Metadata: 0x0068ECD4
		private const float D_H_EXPANDED = 384f; // Metadata: 0x0068ECD8
		public const float GAP = 11.7f; // Metadata: 0x0068ECDC
		public const float MARGIN = 10.4f; // Metadata: 0x0068ECE0
		private const float BLOCKER_ALPHA = 0.25f; // Metadata: 0x0068ECE4
		private const string ManaColor = "#4FD8E4"; // Metadata: 0x0068ECE8
		private const string HpColor = "#F0A030"; // Metadata: 0x0068ECF0
		private const string AtkColor = "#4FD8E4"; // Metadata: 0x0068ECF8
		private static readonly string[] ElementNames; // 0x00
		private static readonly string[] ElementColors; // 0x08
		private static readonly Color BodyColor; // 0x10
		private static readonly Color StarOn; // 0x20
		private static readonly Color StarOff; // 0x30
		private static readonly Color EquipTint; // 0x40
		private static readonly Color UnequipTint; // 0x50
		private static readonly Color AvatarTint; // 0x60
		private static readonly Color UpgradeTint; // 0x70
		private static readonly Color SalvageTint; // 0x80
		public static Sprite StarSprite; // 0x90
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
		private CanvasGroup _group; // 0xF8
		private bool _built; // 0x100
		private bool _hasSet; // 0x101
		private bool _hasCompare; // 0x102
		private bool _hasTools; // 0x103
		private int _iconToken; // 0x104
		private long _shownPower; // 0x108
		private Action _equipAction; // 0x110
		private Action _unequipAction; // 0x118
		private Action _avatarAction; // 0x120
		private Action _upgradeAction; // 0x128
		private Action _salvageAction; // 0x130
		private float _salvageArmedUntil; // 0x138
		private int _shownShardCost; // 0x13C
		private int _shownSalvageShards; // 0x140
		private RectTransform[] _liftNodes; // 0x148
		private Vector2[] _liftBase; // 0x150
		private static EquipTooltipView _instance; // 0x98
		private readonly StringBuilder _builder; // 0x158
	
		// Properties
		public static bool Enabled { get; } // 0x00000001807D4710-0x00000001807D4770 
		public static bool IsShowing { get; } // 0x00000001807D4770-0x00000001807D4840 
		public static float PanelW { get; } // 0x00000001807D4860-0x00000001807D4870 
		public static float PanelHCompact { get; } // 0x00000001807D4840-0x00000001807D4850 
		public static float PanelHExpanded { get; } // 0x00000001807D4850-0x00000001807D4860 
	
		// Nested types
		public struct Actions // TypeDefIndex: 2348
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
	
		public enum Side : byte // TypeDefIndex: 2349
		{
			Above = 0,
			Below = 1,
			Right = 2,
			Left = 3
		}
	
		public struct Placement // TypeDefIndex: 2350
		{
			// Fields
			public Vector2 anchoredPosition; // 0x00
			public Vector2 pivot; // 0x08
			public Side side; // 0x10
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass145_0 // TypeDefIndex: 2351
		{
			// Fields
			public int token; // 0x10
			public EquipTooltipView __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass145_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _ApplyIcon_b__0(Sprite sp); // 0x00000001807DC440-0x00000001807DC540
		}
	
		// Constructors
		public EquipTooltipView(); // 0x00000001807D4610-0x00000001807D4710
		static EquipTooltipView(); // 0x00000001807D42D0-0x00000001807D4610
	
		// Methods
		public static void Show(RectTransform anchor, EquipItemDTO item, Actions actions); // 0x00000001807D3C70-0x00000001807D3D80
		public static void Hide(); // 0x00000001807D2B70-0x00000001807D2C60
		private static EquipTooltipView Resolve(); // 0x00000001807D36E0-0x00000001807D39A0
		public static EquipTooltipView Spawn(); // 0x00000001807D40E0-0x00000001807D4250
		private void Awake(); // 0x00000001807D0350-0x00000001807D0450
		private void OnDestroy(); // 0x00000001807D2CF0-0x00000001807D2DC0
		private void OnDisable(); // 0x00000001807D2DC0-0x00000001807D2EE0
		private void EnsureBuilt(); // 0x00000001807D0CF0-0x00000001807D27D0
		private void Present(RectTransform anchor, EquipItemDTO item, Actions actions); // 0x00000001807D3280-0x00000001807D3470
		public void Fill(EquipItemDTO item); // 0x00000001807D27D0-0x00000001807D2B70
		private void Relayout(); // 0x00000001807D3470-0x00000001807D36E0
		private void ApplyIcon(long iconId); // 0x00000001807CF7C0-0x00000001807CFA50
		private void ApplyStars(int star, int maxStar); // 0x00000001807CFA50-0x00000001807CFE60
		private bool BindSetBlock(EquipItemDTO item); // 0x00000001807D0450-0x00000001807D0BC0
		private void ApplyCompare(Actions actions); // 0x00000001807CF360-0x00000001807CF7C0
		public void SetActions(Actions actions); // 0x00000001807D39A0-0x00000001807D3C70
		private void ApplyTools(Actions actions); // 0x00000001807CFE60-0x00000001807D0350
		private void OnUpgradeClicked(); // 0x00000001807D31D0-0x00000001807D3280
		private void OnSalvageClicked(); // 0x00000001807D2F90-0x00000001807D3120
		private void OnEquipClicked(); // 0x00000001807D2EE0-0x00000001807D2F90
		private void OnUnequipClicked(); // 0x00000001807D3120-0x00000001807D31D0
		private void OnAvatarToggleClicked(); // 0x00000001807D2C60-0x00000001807D2CF0
		private void ClosePanel(); // 0x00000001807D0BC0-0x00000001807D0CF0
		private static void AppendBonus(StringBuilder b, string color, string label, long value); // 0x00000001807CF240-0x00000001807CF360
		public static Placement Solve(Rect safe, Rect target, Vector2 size, float gap, float margin); // 0x00000001807D3D80-0x00000001807D40E0
		private static float ClampAxis(float value, float pivot, float size, float min, float max, float center, float margin); // 0x0000000180679CA0-0x0000000180679D10
		[CompilerGenerated]
		private void _ClosePanel_b__156_0(); // 0x00000001807D4250-0x00000001807D42D0
	}
}
