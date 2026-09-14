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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class GuildHallView : MonoBehaviour // TypeDefIndex: 794
{
	// Fields
	[SerializeField]
	private GuildLogoView logo; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtNumMember; // 0x30
	[SerializeField]
	private Button btnEdit; // 0x38
	[SerializeField]
	private Button btnOut; // 0x40
	[SerializeField]
	private Button btnInfo; // 0x48
	[SerializeField]
	private Button btnBoss; // 0x50
	[SerializeField]
	private Button btnShop; // 0x58
	[SerializeField]
	private Button btnRequest; // 0x60
	[SerializeField]
	private Button btnRank; // 0x68
	[SerializeField]
	private GameObject notifyRequest; // 0x70
	[SerializeField]
	private GameObject notifyBoss; // 0x78
	[SerializeField]
	private GameObject notifyShop; // 0x80
	[SerializeField]
	private GameObject notifyRank; // 0x88
	[SerializeField]
	private Button btnClose; // 0x90
	[SerializeField]
	private UnityEngine.UI.Text txtSlogan; // 0x98
	private readonly List<Transform> _showcase; // 0xA0
	public const float CARD_W = 560f; // Metadata: 0x005EE844
	public const float CARD_H = 136f; // Metadata: 0x005EE848
	public static readonly Vector2 CARD_POS; // 0x00
	public const float FLAG_X = -220f; // Metadata: 0x005EE84C
	public const float FLAG_SIDE = 100f; // Metadata: 0x005EE850
	public const float ROW1_Y = 40f; // Metadata: 0x005EE854
	public const float ROW2_Y = 6f; // Metadata: 0x005EE858
	public const float ROW3_Y = -36f; // Metadata: 0x005EE85C
	public const float NAME_L = -150f; // Metadata: 0x005EE860
	public const float NAME_R = 86f; // Metadata: 0x005EE864
	public const float NAME_H = 36f; // Metadata: 0x005EE868
	public const float LV_X = 128f; // Metadata: 0x005EE86C
	public const float LV_W = 72f; // Metadata: 0x005EE870
	public const float LV_H = 34f; // Metadata: 0x005EE874
	public const float EDIT_X = 190f; // Metadata: 0x005EE878
	public const float OUT_X = 240f; // Metadata: 0x005EE87C
	public const float CARD_BTN = 42f; // Metadata: 0x005EE880
	public const float SLOGAN_L = -150f; // Metadata: 0x005EE884
	public const float SLOGAN_R = 256f; // Metadata: 0x005EE888
	public const float SLOGAN_H = 26f; // Metadata: 0x005EE88C
	public const float MEM_ICON_X = -150f; // Metadata: 0x005EE890
	public const float MEM_ICON = 26f; // Metadata: 0x005EE894
	public const float MEM_TXT_L = -131f; // Metadata: 0x005EE898
	public const float MEM_TXT_W = 70f; // Metadata: 0x005EE89C
	public const float MEM_TXT_H = 30f; // Metadata: 0x005EE8A0
	public const float EXP_L = -48f; // Metadata: 0x005EE8A4
	public const float EXP_R = 186f; // Metadata: 0x005EE8A8
	public const float EXP_R_WIDE = 256f; // Metadata: 0x005EE8AC
	public const float EXP_H = 34f; // Metadata: 0x005EE8B0
	public const float CONTRIB_X = 226f; // Metadata: 0x005EE8B4
	public const float CONTRIB_W = 60f; // Metadata: 0x005EE8B8
	public const float CONTRIB_H = 46f; // Metadata: 0x005EE8BC
	public const float RIGHT_W = 186f; // Metadata: 0x005EE8C0
	public const float RIGHT_H = 546f; // Metadata: 0x005EE8C4
	public const float RIGHT_X = -14f; // Metadata: 0x005EE8C8
	public static readonly float[] RIGHT_BTN_Y; // 0x08
	public const float RIGHT_BTN_W = 112f; // Metadata: 0x005EE8CC
	public const float RIGHT_BTN_H = 76f; // Metadata: 0x005EE8D0
	public const float RIGHT_LBL_Y = -52f; // Metadata: 0x005EE8D4
	public const float RIGHT_LBL_W = 176f; // Metadata: 0x005EE8D8
	public const float RIGHT_LBL_H = 26f; // Metadata: 0x005EE8DC
	public const int RIGHT_LBL_FS = 20; // Metadata: 0x005EE8E0
	public const int RIGHT_LBL_FS_MIN = 14; // Metadata: 0x005EE8E1
	private static readonly string[] RIGHT_BTNS; // 0x10
	public const string NODE_BTN_RANK = "Btn-Rank"; // Metadata: 0x005EE8E2
	private const string NODE_RANK_ICON = "Icon"; // Metadata: 0x005EE8EB
	private const float RANK_ICON_W = 60f; // Metadata: 0x005EE8F0
	private const float RANK_ICON_H = 50f; // Metadata: 0x005EE8F4
	private const string NODE_NOTIFY = "notify"; // Metadata: 0x005EE8F8
	private const float RANK_NOTIFY_D = 22f; // Metadata: 0x005EE8FF
	private const float RANK_NOTIFY_X = 44f; // Metadata: 0x005EE903
	private const float RANK_NOTIFY_Y = 28f; // Metadata: 0x005EE907
	public static readonly Vector2 GRID_POS; // 0x18
	public const float GRID_W = 1100f; // Metadata: 0x005EE90B
	public const float TITLE_Y = -162f; // Metadata: 0x005EE90F
	public const float TITLE_W = 420f; // Metadata: 0x005EE913
	public const float TITLE_H = 26f; // Metadata: 0x005EE917
	public static readonly float[] ROW_Y; // 0x20
	public static readonly float[] ROW1_X; // 0x28
	public static readonly float[] ROW2_X; // 0x30
	public const float CELL_W = 190f; // Metadata: 0x005EE91B
	public const float CELL_H = 180f; // Metadata: 0x005EE91F
	public const float AVATAR_SIDE = 140f; // Metadata: 0x005EE923
	public const float AVATAR_Y = 12f; // Metadata: 0x005EE927
	public const float PLATE_Y = -74f; // Metadata: 0x005EE92B
	public const float PLATE_W = 176f; // Metadata: 0x005EE92F
	public const float PLATE_H = 28f; // Metadata: 0x005EE933
	public const float RANK_D = 56f; // Metadata: 0x005EE937
	public const float RANK_X = -66f; // Metadata: 0x005EE93B
	public const float RANK_Y = 62f; // Metadata: 0x005EE93F
	public const int RANK_FONT = 26; // Metadata: 0x005EE943
	public const int RANK_FONT_MIN = 14; // Metadata: 0x005EE944
	private const string NODE_EXP_BAR = "GuildExpBar"; // Metadata: 0x005EE945
	private const string NODE_EXP_FILL = "Fill"; // Metadata: 0x005EE951
	private const string NODE_EXP_TEXT = "Text"; // Metadata: 0x005EE956
	private const string NODE_BTN_CONTRIB = "btnGuildContrib"; // Metadata: 0x005EE95B
	private const string NODE_LEVELUP_FLASH = "GuildLevelUpFlash"; // Metadata: 0x005EE96B
	private const string NODE_LEVEL_CHIP = "chipBg"; // Metadata: 0x005EE97D
	private const string NODE_SHOWCASE_TITLE = "txtShowcaseTitle"; // Metadata: 0x005EE984
	private const string NODE_SHOWCASE_PET = "Pet"; // Metadata: 0x005EE995
	private const string NODE_SHOWCASE_AVATAR = "Avatar"; // Metadata: 0x005EE999
	public const string NODE_SHOWCASE_RANK = "Rank"; // Metadata: 0x005EE9A0
	private const string NODE_SHOWCASE_RANK_TXT = "txtRank"; // Metadata: 0x005EE9A5
	private const string NODE_SHOWCASE_RANK_ICON = "Icon"; // Metadata: 0x005EE9AD
	public const string NODE_RANK_ART = "RankArt"; // Metadata: 0x005EE9B2
	private const int LEVEL_MAX = 30; // Metadata: 0x005EE9BA
	private const int EXP_FONT_SIZE = 22; // Metadata: 0x005EE9BB
	private const int EXP_FONT_MIN = 14; // Metadata: 0x005EE9BC
	private static readonly Color EXP_BG; // 0x38
	private static readonly Color EXP_FILL; // 0x48
	private static readonly Color EXP_FILL_MAX; // 0x58
	private static readonly Color CONTRIB_GOLD; // 0x68
	private static readonly Vector2 CENTER; // 0x78
	private RectTransform _expBar; // 0xA8
	private RectTransform _expFill; // 0xB0
	private UnityEngine.UI.Text _expText; // 0xB8
	private Button _btnContrib; // 0xC0
	private Image _flash; // 0xC8
	private GuildContribPopup _contribPopup; // 0xD0
	private RectTransform _levelBadge; // 0xD8
	private UnityEngine.UI.Text _levelText; // 0xE0
	private GuildPanelController _owner; // 0xE8
	private bool _wired; // 0xF0
	private GuildInfo _guild; // 0xF8
	private Coroutine _settleCo; // 0x100

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass166_0 // TypeDefIndex: 795
	{
		// Fields
		public GuildHallView __4__this; // 0x10
		public Transform badge; // 0x18
		public Action<float> __9__3; // 0x20
		public Action __9__4; // 0x28

		// Constructors
		public __c__DisplayClass166_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayLevelUpFx_b__0(float a); // 0x0000000180529900-0x0000000180529A70
		internal void _PlayLevelUpFx_b__1(); // 0x0000000180529A70-0x0000000180529D90
		internal void _PlayLevelUpFx_b__3(float a); // 0x0000000180529D90-0x0000000180529F00
		internal void _PlayLevelUpFx_b__4(); // 0x0000000180529F00-0x000000018052A070
		internal void _PlayLevelUpFx_b__2(); // 0x000000018052A070-0x000000018052A200
	}

	[CompilerGenerated]
	private sealed class _SettleLayout_d__159 : IEnumerator<object> // TypeDefIndex: 796
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildHallView __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SettleLayout_d__159(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018052A200-0x000000018052A3D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018052A3D0-0x000000018052A410
	}

	// Constructors
	public GuildHallView(); // 0x0000000180528770-0x0000000180528870
	static GuildHallView(); // 0x0000000180528870-0x0000000180528DC0

	// Methods
	public void Init(GuildPanelController owner); // 0x00000001805151D0-0x0000000180515230
	private void EnsureWired(); // 0x0000000180515230-0x0000000180516400
	private void CollectShowcase(); // 0x0000000180516400-0x0000000180516770
	private void ResolveLevelBadge(); // 0x0000000180516770-0x0000000180516BA0
	public void Open(); // 0x0000000180516BA0-0x0000000180516CA0
	public void Close(); // 0x0000000180516CA0-0x0000000180516D90
	public void Render(GuildInfo g, int requestCount, bool bossNotify, bool shopNotify); // 0x0000000180516D90-0x0000000180516DC0
	public void Render(GuildInfo g, int requestCount, bool bossNotify, bool shopNotify, bool vaultNotify); // 0x0000000180516DC0-0x0000000180517460
	public void RenderShowcase(List<GuildMemberItem> top); // 0x0000000180517460-0x0000000180517C00
	private static void HideLegacyPetNode(Transform slot); // 0x0000000180517C00-0x0000000180518150
	private static RectTransform EnsureAvatarNode(Transform slot); // 0x0000000180518150-0x0000000180518790
	public static void LayoutHall(Transform hall, Font font); // 0x0000000180518790-0x0000000180518BA0
	private static void LayoutCard(RectTransform card); // 0x0000000180518BA0-0x0000000180519B10
	private static void EnsureLevelChip(RectTransform level); // 0x0000000180519B10-0x000000018051A320
	private static void LayoutRightBox(RectTransform right, Font font); // 0x000000018051A320-0x000000018051ABD0
	public static void EnsureRankButton(RectTransform right, Font font); // 0x000000018051ABD0-0x000000018051BC40
	private static void EnsureRankNotify(RectTransform right, RectTransform rank); // 0x000000018051BC40-0x000000018051CA10
	private static void LayoutShowcase(RectTransform members, Font font); // 0x000000018051CA10-0x000000018051CE20
	private static void EnsureShowcaseTitle(RectTransform members, Font font); // 0x000000018051CE20-0x000000018051D760
	public static Vector2 SlotPos(int index); // 0x000000018051D760-0x000000018051D890
	public static void LayoutShowcaseSlot(RectTransform slot, int index); // 0x000000018051D890-0x000000018051D900
	public static void LayoutShowcaseSlot(RectTransform slot, int index, Font font); // 0x000000018051D900-0x000000018051E6E0
	private static RectTransform EnsureRankNode(Transform slot, Font font); // 0x000000018051E6E0-0x000000018051F810
	public static string RankArtKey(int rank); // 0x000000018051F810-0x000000018051F8C0
	public static Sprite RankSprite(Transform searchRoot, int rank); // 0x000000018051F8C0-0x000000018051FD80
	public static void ApplyShowcaseRank(Transform slot, int rank); // 0x000000018051FD80-0x00000001805207C0
	private static bool IsIntendedOverlay(RectTransform node, Transform other); // 0x00000001805207C0-0x0000000180520E20
	private static void SetRect(RectTransform rt, float cx, float cy, float w, float h); // 0x0000000180520E20-0x0000000180521060
	private static void SetTopCenter(RectTransform rt, Vector2 pos, float w, float h); // 0x0000000180521060-0x00000001805212B0
	private static void SetSquareButton(RectTransform rt, float cx, float cy, float side); // 0x00000001805212B0-0x00000001805214C0
	private static void FitText(UnityEngine.UI.Text t, int max, int min, TextAnchor align, bool bold); // 0x00000001805214C0-0x00000001805217F0
	private static void FitText(RectTransform rt, int max, int min, TextAnchor align, bool bold); // 0x00000001805217F0-0x0000000180521960
	private void RenderExpBar(GuildInfo g); // 0x0000000180521960-0x00000001805223C0
	private void PlaceRuntimeRow(bool wantBtn); // 0x00000001805223C0-0x0000000180522650
	private void EnsureExpBar(); // 0x0000000180522650-0x00000001805234E0
	private void EnsureContribButton(Transform info); // 0x00000001805234E0-0x00000001805243A0
	private void DropLegacyContribButton(); // 0x00000001805243A0-0x0000000180524890
	[IteratorStateMachine(typeof(_SettleLayout_d__159))]
	private IEnumerator SettleLayout(); // 0x0000000180524890-0x0000000180524930
	private static bool Draws(Graphic g); // 0x0000000180524930-0x0000000180524CA0
	private static float OverlapArea(Rect r, List<Rect> blockers); // 0x0000000180524CA0-0x0000000180524E20
	private void AuditOverlaps(); // 0x0000000180524E20-0x0000000180525A20
	private void AuditOne(RectTransform node, string label); // 0x0000000180525A20-0x0000000180525F40
	private void CollectBlockersFor(RectTransform node, List<Rect> outList); // 0x0000000180525F40-0x00000001805267B0
	private void OpenContrib(); // 0x00000001805267B0-0x0000000180526D00
	public void PlayLevelUpFx(int level); // 0x0000000180526D00-0x0000000180527600
	private void EnsureFlash(); // 0x0000000180527600-0x0000000180527DA0
	private void OnDisable(); // 0x0000000180527DA0-0x0000000180528250
	private Font SampleFont(); // 0x0000000180528250-0x0000000180528570
	private void OnClickLeave(); // 0x0000000180528570-0x0000000180528770
	[CompilerGenerated]
	private void _EnsureWired_b__123_0(); // 0x0000000180528DC0-0x0000000180528FD0
	[CompilerGenerated]
	private void _EnsureWired_b__123_1(); // 0x0000000180528FD0-0x00000001805290D0
	[CompilerGenerated]
	private void _EnsureWired_b__123_2(); // 0x00000001805290D0-0x00000001805291D0
	[CompilerGenerated]
	private void _EnsureWired_b__123_3(); // 0x00000001805291D0-0x00000001805292D0
	[CompilerGenerated]
	private void _EnsureWired_b__123_4(); // 0x00000001805292D0-0x00000001805293D0
	[CompilerGenerated]
	private void _EnsureWired_b__123_5(); // 0x00000001805293D0-0x00000001805294D0
	[CompilerGenerated]
	private void _EnsureWired_b__123_6(); // 0x00000001805294D0-0x00000001805295D0
	[CompilerGenerated]
	private void _OnClickLeave_b__170_0(); // 0x00000001805295D0-0x00000001805297A0
	[CompilerGenerated]
	private void _OnClickLeave_b__170_1(); // 0x00000001805297A0-0x0000000180529900
}

