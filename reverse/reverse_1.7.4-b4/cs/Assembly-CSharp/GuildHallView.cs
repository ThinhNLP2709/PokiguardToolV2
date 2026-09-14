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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class GuildHallView : MonoBehaviour // TypeDefIndex: 795
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
	public const float CARD_W = 560f; // Metadata: 0x005EFC14
	public const float CARD_H = 136f; // Metadata: 0x005EFC18
	public static readonly Vector2 CARD_POS; // 0x00
	public const float FLAG_X = -220f; // Metadata: 0x005EFC1C
	public const float FLAG_SIDE = 100f; // Metadata: 0x005EFC20
	public const float ROW1_Y = 40f; // Metadata: 0x005EFC24
	public const float ROW2_Y = 6f; // Metadata: 0x005EFC28
	public const float ROW3_Y = -36f; // Metadata: 0x005EFC2C
	public const float NAME_L = -150f; // Metadata: 0x005EFC30
	public const float NAME_R = 86f; // Metadata: 0x005EFC34
	public const float NAME_H = 36f; // Metadata: 0x005EFC38
	public const float LV_X = 128f; // Metadata: 0x005EFC3C
	public const float LV_W = 72f; // Metadata: 0x005EFC40
	public const float LV_H = 34f; // Metadata: 0x005EFC44
	public const float EDIT_X = 190f; // Metadata: 0x005EFC48
	public const float OUT_X = 240f; // Metadata: 0x005EFC4C
	public const float CARD_BTN = 42f; // Metadata: 0x005EFC50
	public const float SLOGAN_L = -150f; // Metadata: 0x005EFC54
	public const float SLOGAN_R = 256f; // Metadata: 0x005EFC58
	public const float SLOGAN_H = 26f; // Metadata: 0x005EFC5C
	public const float MEM_ICON_X = -150f; // Metadata: 0x005EFC60
	public const float MEM_ICON = 26f; // Metadata: 0x005EFC64
	public const float MEM_TXT_L = -131f; // Metadata: 0x005EFC68
	public const float MEM_TXT_W = 70f; // Metadata: 0x005EFC6C
	public const float MEM_TXT_H = 30f; // Metadata: 0x005EFC70
	public const float EXP_L = -48f; // Metadata: 0x005EFC74
	public const float EXP_R = 186f; // Metadata: 0x005EFC78
	public const float EXP_R_WIDE = 256f; // Metadata: 0x005EFC7C
	public const float EXP_H = 34f; // Metadata: 0x005EFC80
	public const float CONTRIB_X = 226f; // Metadata: 0x005EFC84
	public const float CONTRIB_W = 60f; // Metadata: 0x005EFC88
	public const float CONTRIB_H = 46f; // Metadata: 0x005EFC8C
	public const float RIGHT_W = 186f; // Metadata: 0x005EFC90
	public const float RIGHT_H = 546f; // Metadata: 0x005EFC94
	public const float RIGHT_X = -14f; // Metadata: 0x005EFC98
	public static readonly float[] RIGHT_BTN_Y; // 0x08
	public const float RIGHT_BTN_W = 112f; // Metadata: 0x005EFC9C
	public const float RIGHT_BTN_H = 76f; // Metadata: 0x005EFCA0
	public const float RIGHT_LBL_Y = -52f; // Metadata: 0x005EFCA4
	public const float RIGHT_LBL_W = 176f; // Metadata: 0x005EFCA8
	public const float RIGHT_LBL_H = 26f; // Metadata: 0x005EFCAC
	public const int RIGHT_LBL_FS = 20; // Metadata: 0x005EFCB0
	public const int RIGHT_LBL_FS_MIN = 14; // Metadata: 0x005EFCB1
	private static readonly string[] RIGHT_BTNS; // 0x10
	public const string NODE_BTN_RANK = "Btn-Rank"; // Metadata: 0x005EFCB2
	private const string NODE_RANK_ICON = "Icon"; // Metadata: 0x005EFCBB
	private const float RANK_ICON_W = 60f; // Metadata: 0x005EFCC0
	private const float RANK_ICON_H = 50f; // Metadata: 0x005EFCC4
	private const string NODE_NOTIFY = "notify"; // Metadata: 0x005EFCC8
	private const float RANK_NOTIFY_D = 22f; // Metadata: 0x005EFCCF
	private const float RANK_NOTIFY_X = 44f; // Metadata: 0x005EFCD3
	private const float RANK_NOTIFY_Y = 28f; // Metadata: 0x005EFCD7
	public static readonly Vector2 GRID_POS; // 0x18
	public const float GRID_W = 1100f; // Metadata: 0x005EFCDB
	public const float TITLE_Y = -162f; // Metadata: 0x005EFCDF
	public const float TITLE_W = 420f; // Metadata: 0x005EFCE3
	public const float TITLE_H = 26f; // Metadata: 0x005EFCE7
	public static readonly float[] ROW_Y; // 0x20
	public static readonly float[] ROW1_X; // 0x28
	public static readonly float[] ROW2_X; // 0x30
	public const float CELL_W = 190f; // Metadata: 0x005EFCEB
	public const float CELL_H = 180f; // Metadata: 0x005EFCEF
	public const float AVATAR_SIDE = 140f; // Metadata: 0x005EFCF3
	public const float AVATAR_Y = 12f; // Metadata: 0x005EFCF7
	public const float PLATE_Y = -74f; // Metadata: 0x005EFCFB
	public const float PLATE_W = 176f; // Metadata: 0x005EFCFF
	public const float PLATE_H = 28f; // Metadata: 0x005EFD03
	public const float RANK_D = 56f; // Metadata: 0x005EFD07
	public const float RANK_X = -66f; // Metadata: 0x005EFD0B
	public const float RANK_Y = 62f; // Metadata: 0x005EFD0F
	public const int RANK_FONT = 26; // Metadata: 0x005EFD13
	public const int RANK_FONT_MIN = 14; // Metadata: 0x005EFD14
	private const string NODE_EXP_BAR = "GuildExpBar"; // Metadata: 0x005EFD15
	private const string NODE_EXP_FILL = "Fill"; // Metadata: 0x005EFD21
	private const string NODE_EXP_TEXT = "Text"; // Metadata: 0x005EFD26
	private const string NODE_BTN_CONTRIB = "btnGuildContrib"; // Metadata: 0x005EFD2B
	private const string NODE_LEVELUP_FLASH = "GuildLevelUpFlash"; // Metadata: 0x005EFD3B
	private const string NODE_LEVEL_CHIP = "chipBg"; // Metadata: 0x005EFD4D
	private const string NODE_SHOWCASE_TITLE = "txtShowcaseTitle"; // Metadata: 0x005EFD54
	private const string NODE_SHOWCASE_PET = "Pet"; // Metadata: 0x005EFD65
	private const string NODE_SHOWCASE_AVATAR = "Avatar"; // Metadata: 0x005EFD69
	public const string NODE_SHOWCASE_RANK = "Rank"; // Metadata: 0x005EFD70
	private const string NODE_SHOWCASE_RANK_TXT = "txtRank"; // Metadata: 0x005EFD75
	private const string NODE_SHOWCASE_RANK_ICON = "Icon"; // Metadata: 0x005EFD7D
	public const string NODE_RANK_ART = "RankArt"; // Metadata: 0x005EFD82
	private const int EXP_FONT_SIZE = 22; // Metadata: 0x005EFD8A
	private const int EXP_FONT_MIN = 14; // Metadata: 0x005EFD8B
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
	private sealed class __c__DisplayClass165_0 // TypeDefIndex: 796
	{
		// Fields
		public GuildHallView __4__this; // 0x10
		public Transform badge; // 0x18
		public Action<float> __9__3; // 0x20
		public Action __9__4; // 0x28

		// Constructors
		public __c__DisplayClass165_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayLevelUpFx_b__0(float a); // 0x000000018052B0C0-0x000000018052B230
		internal void _PlayLevelUpFx_b__1(); // 0x000000018052B230-0x000000018052B550
		internal void _PlayLevelUpFx_b__3(float a); // 0x000000018052B550-0x000000018052B6C0
		internal void _PlayLevelUpFx_b__4(); // 0x000000018052B6C0-0x000000018052B830
		internal void _PlayLevelUpFx_b__2(); // 0x000000018052B830-0x000000018052B9C0
	}

	[CompilerGenerated]
	private sealed class _SettleLayout_d__158 : IEnumerator<object> // TypeDefIndex: 797
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
		public _SettleLayout_d__158(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018052B9C0-0x000000018052BB90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018052BB90-0x000000018052BBD0
	}

	// Constructors
	public GuildHallView(); // 0x0000000180529F30-0x000000018052A030
	static GuildHallView(); // 0x000000018052A030-0x000000018052A580

	// Methods
	public void Init(GuildPanelController owner); // 0x0000000180516970-0x00000001805169D0
	private void EnsureWired(); // 0x00000001805169D0-0x0000000180517BA0
	private void CollectShowcase(); // 0x0000000180517BA0-0x0000000180517F10
	private void ResolveLevelBadge(); // 0x0000000180517F10-0x0000000180518340
	public void Open(); // 0x0000000180518340-0x0000000180518440
	public void Close(); // 0x0000000180518440-0x0000000180518530
	public void Render(GuildInfo g, int requestCount, bool bossNotify, bool shopNotify); // 0x0000000180518530-0x0000000180518560
	public void Render(GuildInfo g, int requestCount, bool bossNotify, bool shopNotify, bool vaultNotify); // 0x0000000180518560-0x0000000180518C00
	public void RenderShowcase(List<GuildMemberItem> top); // 0x0000000180518C00-0x00000001805193A0
	private static void HideLegacyPetNode(Transform slot); // 0x00000001805193A0-0x00000001805198F0
	private static RectTransform EnsureAvatarNode(Transform slot); // 0x00000001805198F0-0x0000000180519F30
	public static void LayoutHall(Transform hall, Font font); // 0x0000000180519F30-0x000000018051A340
	private static void LayoutCard(RectTransform card); // 0x000000018051A340-0x000000018051B2B0
	private static void EnsureLevelChip(RectTransform level); // 0x000000018051B2B0-0x000000018051BAC0
	private static void LayoutRightBox(RectTransform right, Font font); // 0x000000018051BAC0-0x000000018051C370
	public static void EnsureRankButton(RectTransform right, Font font); // 0x000000018051C370-0x000000018051D3E0
	private static void EnsureRankNotify(RectTransform right, RectTransform rank); // 0x000000018051D3E0-0x000000018051E1B0
	private static void LayoutShowcase(RectTransform members, Font font); // 0x000000018051E1B0-0x000000018051E5C0
	private static void EnsureShowcaseTitle(RectTransform members, Font font); // 0x000000018051E5C0-0x000000018051EF00
	public static Vector2 SlotPos(int index); // 0x000000018051EF00-0x000000018051F030
	public static void LayoutShowcaseSlot(RectTransform slot, int index); // 0x000000018051F030-0x000000018051F0A0
	public static void LayoutShowcaseSlot(RectTransform slot, int index, Font font); // 0x000000018051F0A0-0x000000018051FE80
	private static RectTransform EnsureRankNode(Transform slot, Font font); // 0x000000018051FE80-0x0000000180520FB0
	public static string RankArtKey(int rank); // 0x0000000180520FB0-0x0000000180521060
	public static Sprite RankSprite(Transform searchRoot, int rank); // 0x0000000180521060-0x0000000180521520
	public static void ApplyShowcaseRank(Transform slot, int rank); // 0x0000000180521520-0x0000000180521F60
	private static bool IsIntendedOverlay(RectTransform node, Transform other); // 0x0000000180521F60-0x00000001805225C0
	private static void SetRect(RectTransform rt, float cx, float cy, float w, float h); // 0x00000001805225C0-0x0000000180522800
	private static void SetTopCenter(RectTransform rt, Vector2 pos, float w, float h); // 0x0000000180522800-0x0000000180522A50
	private static void SetSquareButton(RectTransform rt, float cx, float cy, float side); // 0x0000000180522A50-0x0000000180522C60
	private static void FitText(UnityEngine.UI.Text t, int max, int min, TextAnchor align, bool bold); // 0x0000000180522C60-0x0000000180522F90
	private static void FitText(RectTransform rt, int max, int min, TextAnchor align, bool bold); // 0x0000000180522F90-0x0000000180523100
	private void RenderExpBar(GuildInfo g); // 0x0000000180523100-0x0000000180523B80
	private void PlaceRuntimeRow(bool wantBtn); // 0x0000000180523B80-0x0000000180523E10
	private void EnsureExpBar(); // 0x0000000180523E10-0x0000000180524CA0
	private void EnsureContribButton(Transform info); // 0x0000000180524CA0-0x0000000180525B60
	private void DropLegacyContribButton(); // 0x0000000180525B60-0x0000000180526050
	[IteratorStateMachine(typeof(_SettleLayout_d__158))]
	private IEnumerator SettleLayout(); // 0x0000000180526050-0x00000001805260F0
	private static bool Draws(Graphic g); // 0x00000001805260F0-0x0000000180526460
	private static float OverlapArea(Rect r, List<Rect> blockers); // 0x0000000180526460-0x00000001805265E0
	private void AuditOverlaps(); // 0x00000001805265E0-0x00000001805271E0
	private void AuditOne(RectTransform node, string label); // 0x00000001805271E0-0x0000000180527700
	private void CollectBlockersFor(RectTransform node, List<Rect> outList); // 0x0000000180527700-0x0000000180527F70
	private void OpenContrib(); // 0x0000000180527F70-0x00000001805284C0
	public void PlayLevelUpFx(int level); // 0x00000001805284C0-0x0000000180528DC0
	private void EnsureFlash(); // 0x0000000180528DC0-0x0000000180529560
	private void OnDisable(); // 0x0000000180529560-0x0000000180529A10
	private Font SampleFont(); // 0x0000000180529A10-0x0000000180529D30
	private void OnClickLeave(); // 0x0000000180529D30-0x0000000180529F30
	[CompilerGenerated]
	private void _EnsureWired_b__122_0(); // 0x000000018052A580-0x000000018052A790
	[CompilerGenerated]
	private void _EnsureWired_b__122_1(); // 0x000000018052A790-0x000000018052A890
	[CompilerGenerated]
	private void _EnsureWired_b__122_2(); // 0x000000018052A890-0x000000018052A990
	[CompilerGenerated]
	private void _EnsureWired_b__122_3(); // 0x000000018052A990-0x000000018052AA90
	[CompilerGenerated]
	private void _EnsureWired_b__122_4(); // 0x000000018052AA90-0x000000018052AB90
	[CompilerGenerated]
	private void _EnsureWired_b__122_5(); // 0x000000018052AB90-0x000000018052AC90
	[CompilerGenerated]
	private void _EnsureWired_b__122_6(); // 0x000000018052AC90-0x000000018052AD90
	[CompilerGenerated]
	private void _OnClickLeave_b__169_0(); // 0x000000018052AD90-0x000000018052AF60
	[CompilerGenerated]
	private void _OnClickLeave_b__169_1(); // 0x000000018052AF60-0x000000018052B0C0
}

