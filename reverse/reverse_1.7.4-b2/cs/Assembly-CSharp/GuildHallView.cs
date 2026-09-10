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

public class GuildHallView : MonoBehaviour // TypeDefIndex: 705
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
	private GameObject notifyRequest; // 0x68
	[SerializeField]
	private GameObject notifyBoss; // 0x70
	[SerializeField]
	private GameObject notifyShop; // 0x78
	[SerializeField]
	private Button btnClose; // 0x80
	[SerializeField]
	private UnityEngine.UI.Text txtSlogan; // 0x88
	private readonly List<Transform> _showcase; // 0x90
	public const float CARD_W = 560f; // Metadata: 0x0068B94E
	public const float CARD_H = 136f; // Metadata: 0x0068B952
	public static readonly Vector2 CARD_POS; // 0x00
	public const float FLAG_X = -220f; // Metadata: 0x0068B956
	public const float FLAG_SIDE = 100f; // Metadata: 0x0068B95A
	public const float ROW1_Y = 40f; // Metadata: 0x0068B95E
	public const float ROW2_Y = 6f; // Metadata: 0x0068B962
	public const float ROW3_Y = -36f; // Metadata: 0x0068B966
	public const float NAME_L = -150f; // Metadata: 0x0068B96A
	public const float NAME_R = 86f; // Metadata: 0x0068B96E
	public const float NAME_H = 36f; // Metadata: 0x0068B972
	public const float LV_X = 128f; // Metadata: 0x0068B976
	public const float LV_W = 72f; // Metadata: 0x0068B97A
	public const float LV_H = 34f; // Metadata: 0x0068B97E
	public const float EDIT_X = 190f; // Metadata: 0x0068B982
	public const float OUT_X = 240f; // Metadata: 0x0068B986
	public const float CARD_BTN = 42f; // Metadata: 0x0068B98A
	public const float SLOGAN_L = -150f; // Metadata: 0x0068B98E
	public const float SLOGAN_R = 256f; // Metadata: 0x0068B992
	public const float SLOGAN_H = 26f; // Metadata: 0x0068B996
	public const float MEM_ICON_X = -150f; // Metadata: 0x0068B99A
	public const float MEM_ICON = 26f; // Metadata: 0x0068B99E
	public const float MEM_TXT_L = -131f; // Metadata: 0x0068B9A2
	public const float MEM_TXT_W = 70f; // Metadata: 0x0068B9A6
	public const float MEM_TXT_H = 30f; // Metadata: 0x0068B9AA
	public const float EXP_L = -48f; // Metadata: 0x0068B9AE
	public const float EXP_R = 186f; // Metadata: 0x0068B9B2
	public const float EXP_R_WIDE = 256f; // Metadata: 0x0068B9B6
	public const float EXP_H = 34f; // Metadata: 0x0068B9BA
	public const float CONTRIB_X = 226f; // Metadata: 0x0068B9BE
	public const float CONTRIB_W = 60f; // Metadata: 0x0068B9C2
	public const float CONTRIB_H = 46f; // Metadata: 0x0068B9C6
	public const float RIGHT_W = 186f; // Metadata: 0x0068B9CA
	public const float RIGHT_H = 540f; // Metadata: 0x0068B9CE
	public const float RIGHT_X = -14f; // Metadata: 0x0068B9D2
	public static readonly float[] RIGHT_BTN_Y; // 0x08
	public const float RIGHT_LBL_Y = -64f; // Metadata: 0x0068B9D6
	public const float RIGHT_LBL_W = 176f; // Metadata: 0x0068B9DA
	public const float RIGHT_LBL_H = 30f; // Metadata: 0x0068B9DE
	public const int RIGHT_LBL_FS = 22; // Metadata: 0x0068B9E2
	private static readonly string[] RIGHT_BTNS; // 0x10
	public static readonly Vector2 GRID_POS; // 0x18
	public const float GRID_W = 1100f; // Metadata: 0x0068B9E3
	public const float TITLE_Y = -162f; // Metadata: 0x0068B9E7
	public const float TITLE_W = 420f; // Metadata: 0x0068B9EB
	public const float TITLE_H = 26f; // Metadata: 0x0068B9EF
	public static readonly float[] ROW_Y; // 0x20
	public static readonly float[] ROW1_X; // 0x28
	public static readonly float[] ROW2_X; // 0x30
	public const float CELL_W = 190f; // Metadata: 0x0068B9F3
	public const float CELL_H = 180f; // Metadata: 0x0068B9F7
	public const float AVATAR_SIDE = 140f; // Metadata: 0x0068B9FB
	public const float AVATAR_Y = 12f; // Metadata: 0x0068B9FF
	public const float PLATE_Y = -74f; // Metadata: 0x0068BA03
	public const float PLATE_W = 176f; // Metadata: 0x0068BA07
	public const float PLATE_H = 28f; // Metadata: 0x0068BA0B
	private const string NODE_EXP_BAR = "GuildExpBar"; // Metadata: 0x0068BA0F
	private const string NODE_EXP_FILL = "Fill"; // Metadata: 0x0068BA1B
	private const string NODE_EXP_TEXT = "Text"; // Metadata: 0x0068BA20
	private const string NODE_BTN_CONTRIB = "btnGuildContrib"; // Metadata: 0x0068BA25
	private const string NODE_LEVELUP_FLASH = "GuildLevelUpFlash"; // Metadata: 0x0068BA35
	private const string NODE_LEVEL_CHIP = "chipBg"; // Metadata: 0x0068BA47
	private const string NODE_SHOWCASE_TITLE = "txtShowcaseTitle"; // Metadata: 0x0068BA4E
	private const string NODE_SHOWCASE_PET = "Pet"; // Metadata: 0x0068BA5F
	private const string NODE_SHOWCASE_AVATAR = "Avatar"; // Metadata: 0x0068BA63
	private const int LEVEL_MAX = 30; // Metadata: 0x0068BA6A
	private const int EXP_FONT_SIZE = 22; // Metadata: 0x0068BA6B
	private const int EXP_FONT_MIN = 14; // Metadata: 0x0068BA6C
	private static readonly Color EXP_BG; // 0x38
	private static readonly Color EXP_FILL; // 0x48
	private static readonly Color EXP_FILL_MAX; // 0x58
	private static readonly Color CONTRIB_GOLD; // 0x68
	private static readonly Vector2 CENTER; // 0x78
	private RectTransform _expBar; // 0x98
	private RectTransform _expFill; // 0xA0
	private UnityEngine.UI.Text _expText; // 0xA8
	private Button _btnContrib; // 0xB0
	private Image _flash; // 0xB8
	private GuildContribPopup _contribPopup; // 0xC0
	private RectTransform _levelBadge; // 0xC8
	private UnityEngine.UI.Text _levelText; // 0xD0
	private GuildPanelController _owner; // 0xD8
	private bool _wired; // 0xE0
	private GuildInfo _guild; // 0xE8
	private Coroutine _settleCo; // 0xF0

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass135_0 // TypeDefIndex: 706
	{
		// Fields
		public GuildHallView __4__this; // 0x10
		public Transform badge; // 0x18
		public Action<float> __9__3; // 0x20
		public Action __9__4; // 0x28

		// Constructors
		public __c__DisplayClass135_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayLevelUpFx_b__0(float a); // 0x000000018047DE40-0x000000018047DF30
		internal void _PlayLevelUpFx_b__1(); // 0x000000018047DF30-0x000000018047E130
		internal void _PlayLevelUpFx_b__3(float a); // 0x000000018047E240-0x000000018047E330
		internal void _PlayLevelUpFx_b__4(); // 0x000000018047E330-0x000000018047E3E0
		internal void _PlayLevelUpFx_b__2(); // 0x000000018047E130-0x000000018047E240
	}

	[CompilerGenerated]
	private sealed class _SettleLayout_d__128 : IEnumerator<object> // TypeDefIndex: 707
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildHallView __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SettleLayout_d__128(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018047DC20-0x000000018047DD20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018047DD20-0x000000018047DD60
	}

	// Constructors
	public GuildHallView(); // 0x0000000180466A10-0x0000000180466A90
	static GuildHallView(); // 0x0000000180466670-0x0000000180466A10

	// Methods
	public void Init(GuildPanelController owner); // 0x0000000180462420-0x0000000180462450
	private void EnsureWired(); // 0x0000000180461650-0x0000000180462090
	private void CollectShowcase(); // 0x000000018045E9D0-0x000000018045EC00
	private void ResolveLevelBadge(); // 0x0000000180465980-0x0000000180465B60
	public void Open(); // 0x00000001804641D0-0x0000000180464220
	public void Close(); // 0x00000001802F4D60-0x00000001802F4DB0
	public void Render(GuildInfo g, int requestCount, bool bossNotify, bool shopNotify); // 0x00000001804655F0-0x0000000180465980
	public void RenderShowcase(List<GuildMemberItem> top); // 0x0000000180465120-0x00000001804655F0
	private static void HideLegacyPetNode(Transform slot); // 0x0000000180462270-0x0000000180462420
	private static RectTransform EnsureAvatarNode(Transform slot); // 0x000000018045EF90-0x000000018045F2D0
	public static void LayoutHall(Transform hall, Font font); // 0x0000000180462CC0-0x0000000180462EC0
	private static void LayoutCard(RectTransform card); // 0x0000000180462450-0x0000000180462CC0
	private static void EnsureLevelChip(RectTransform level); // 0x0000000180460CF0-0x0000000180461150
	private static void LayoutRightBox(RectTransform right); // 0x0000000180462EC0-0x0000000180463510
	private static void LayoutShowcase(RectTransform members, Font font); // 0x0000000180463960-0x0000000180463BB0
	private static void EnsureShowcaseTitle(RectTransform members, Font font); // 0x0000000180461150-0x0000000180461650
	public static Vector2 SlotPos(int index); // 0x00000001804660B0-0x00000001804661E0
	public static void LayoutShowcaseSlot(RectTransform slot, int index); // 0x0000000180463510-0x0000000180463960
	private static void SetRect(RectTransform rt, float cx, float cy, float w, float h); // 0x0000000180465C40-0x0000000180465DB0
	private static void SetTopCenter(RectTransform rt, Vector2 pos, float w, float h); // 0x0000000180465EC0-0x0000000180466040
	private static void SetSquareButton(RectTransform rt, float cx, float cy, float side); // 0x0000000180465DB0-0x0000000180465EC0
	private static void FitText(UnityEngine.UI.Text t, int max, int min, TextAnchor align, bool bold); // 0x0000000180462090-0x0000000180462180
	private static void FitText(RectTransform rt, int max, int min, TextAnchor align, bool bold); // 0x0000000180462180-0x0000000180462270
	private void RenderExpBar(GuildInfo g); // 0x0000000180464AC0-0x0000000180465120
	private void PlaceRuntimeRow(bool wantBtn); // 0x0000000180464370-0x0000000180464520
	private void EnsureExpBar(); // 0x000000018045FBE0-0x00000001804608B0
	private void EnsureContribButton(Transform info); // 0x000000018045F2D0-0x000000018045FBE0
	private void DropLegacyContribButton(); // 0x000000018045EDD0-0x000000018045EF90
	[IteratorStateMachine(typeof(_SettleLayout_d__128))]
	private IEnumerator SettleLayout(); // 0x0000000180466040-0x00000001804660B0
	private static bool Draws(Graphic g); // 0x000000018045EC00-0x000000018045EDD0
	private static float OverlapArea(Rect r, List<Rect> blockers); // 0x0000000180464220-0x0000000180464370
	private void AuditOverlaps(); // 0x000000018045DE90-0x000000018045E3F0
	private void AuditOne(RectTransform node, string label); // 0x000000018045DB40-0x000000018045DE90
	private void CollectBlockersFor(RectTransform node, List<Rect> outList); // 0x000000018045E3F0-0x000000018045E9D0
	private void OpenContrib(); // 0x0000000180463EF0-0x00000001804641D0
	public void PlayLevelUpFx(int level); // 0x0000000180464520-0x0000000180464AC0
	private void EnsureFlash(); // 0x00000001804608B0-0x0000000180460CF0
	private void OnDisable(); // 0x0000000180463D00-0x0000000180463EF0
	private Font SampleFont(); // 0x0000000180465B60-0x0000000180465C40
	private void OnClickLeave(); // 0x0000000180463BB0-0x0000000180463D00
	[CompilerGenerated]
	private void _EnsureWired_b__101_0(); // 0x00000001804661E0-0x0000000180466260
	[CompilerGenerated]
	private void _EnsureWired_b__101_1(); // 0x0000000180466260-0x00000001804662E0
	[CompilerGenerated]
	private void _EnsureWired_b__101_2(); // 0x00000001804662E0-0x0000000180466360
	[CompilerGenerated]
	private void _EnsureWired_b__101_3(); // 0x0000000180466360-0x00000001804663E0
	[CompilerGenerated]
	private void _EnsureWired_b__101_4(); // 0x00000001804663E0-0x0000000180466460
	[CompilerGenerated]
	private void _EnsureWired_b__101_5(); // 0x0000000180466460-0x00000001804664E0
	[CompilerGenerated]
	private void _OnClickLeave_b__139_0(); // 0x00000001804664E0-0x00000001804665C0
	[CompilerGenerated]
	private void _OnClickLeave_b__139_1(); // 0x00000001804665C0-0x0000000180466670
}

