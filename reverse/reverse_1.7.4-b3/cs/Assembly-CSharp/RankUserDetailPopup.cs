/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class RankUserDetailPopup : MonoBehaviour // TypeDefIndex: 2440
{
	// Fields
	public const string NODE_NAME = "[RankUserDetail]"; // Metadata: 0x005F0BB0
	private const string N_POKY_SKIN = "PokySkin"; // Metadata: 0x005F0BC1
	private const float FRAME_W = 1774f; // Metadata: 0x005F0BCA
	private const float FRAME_H = 887f; // Metadata: 0x005F0BCE
	private const float DIM_OVERSCAN = 600f; // Metadata: 0x005F0BD2
	private const float BOX_W = 1300f; // Metadata: 0x005F0BD6
	private const float BOX_H = 800f; // Metadata: 0x005F0BDA
	private const float BOX_X = 237f; // Metadata: 0x005F0BDE
	private const float BOX_Y = 44f; // Metadata: 0x005F0BE2
	private const float TITLE_Y = 18f; // Metadata: 0x005F0BE6
	private const float TITLE_H = 54f; // Metadata: 0x005F0BEA
	private const float TITLE_FS = 40f; // Metadata: 0x005F0BEE
	private const float CLOSE_X = 1205f; // Metadata: 0x005F0BF2
	private const float CLOSE_Y = 10f; // Metadata: 0x005F0BF6
	private const float CLOSE_W = 78f; // Metadata: 0x005F0BFA
	private const float CLOSE_H = 80f; // Metadata: 0x005F0BFE
	private const float HINT_Y = 754f; // Metadata: 0x005F0C02
	private const float HINT_H = 28f; // Metadata: 0x005F0C06
	private const float CARD_Y = 96f; // Metadata: 0x005F0C0A
	private const float CARD_H = 640f; // Metadata: 0x005F0C0E
	private const float P_X = 24f; // Metadata: 0x005F0C12
	private const float P_W = 430f; // Metadata: 0x005F0C16
	private const float P_CHIP_X = 90f; // Metadata: 0x005F0C1A
	private const float P_CHIP_Y = 14f; // Metadata: 0x005F0C1E
	private const float P_CHIP_W = 250f; // Metadata: 0x005F0C22
	private const float P_CHIP_H = 46f; // Metadata: 0x005F0C26
	private const float P_PORT_X = 55f; // Metadata: 0x005F0C2A
	private const float P_PORT_Y = 68f; // Metadata: 0x005F0C2E
	private const float P_PORT_W = 320f; // Metadata: 0x005F0C32
	private const float P_PORT_H = 360f; // Metadata: 0x005F0C36
	private const float P_AVA_X = 10f; // Metadata: 0x005F0C3A
	private const float P_AVA_Y = 8f; // Metadata: 0x005F0C3E
	private const float P_AVA_W = 300f; // Metadata: 0x005F0C42
	private const float P_AVA_H = 320f; // Metadata: 0x005F0C46
	private const float P_LV_X = 8f; // Metadata: 0x005F0C4A
	private const float P_LV_Y = 8f; // Metadata: 0x005F0C4E
	private const float P_LV_H = 72f; // Metadata: 0x005F0C52
	private const float LV_FALLBACK_AR = 1.5152019f; // Metadata: 0x005F0C56
	private const float LV_TEXT_OFFSET = -0.041f; // Metadata: 0x005F0C5A
	private const float P_WEP_X = 240f; // Metadata: 0x005F0C5E
	private const float P_WEP_Y = 268f; // Metadata: 0x005F0C62
	private const float P_WEP_D = 68f; // Metadata: 0x005F0C66
	private const float P_PET_X = 170f; // Metadata: 0x005F0C6A
	private const float P_PET_Y = 220f; // Metadata: 0x005F0C6E
	private const float P_PET_W = 140f; // Metadata: 0x005F0C72
	private const float P_PET_H = 132f; // Metadata: 0x005F0C76
	private const float P_NAME_X = 105f; // Metadata: 0x005F0C7A
	private const float P_NAME_Y = 440f; // Metadata: 0x005F0C7E
	private const float P_NAME_W = 220f; // Metadata: 0x005F0C82
	private const float P_NAME_H = 48f; // Metadata: 0x005F0C86
	private const float VIP_BADGE_SCALE = 0.8f; // Metadata: 0x005F0C8A
	private const int NAME_MAX_CHARS = 20; // Metadata: 0x005F0C8E
	private const float P_GUILD_X = 15f; // Metadata: 0x005F0C8F
	private const float P_GUILD_W = 400f; // Metadata: 0x005F0C93
	private const float P_GUILD_Y = 492f; // Metadata: 0x005F0C97
	private const float P_GUILD_H = 28f; // Metadata: 0x005F0C9B
	private const float P_DIV_X = 36f; // Metadata: 0x005F0C9F
	private const float P_DIV_Y = 530f; // Metadata: 0x005F0CA3
	private const float P_DIV_W = 358f; // Metadata: 0x005F0CA7
	private const float P_POW_X = 55f; // Metadata: 0x005F0CAB
	private const float P_POW_Y = 542f; // Metadata: 0x005F0CAF
	private const float P_POW_W = 320f; // Metadata: 0x005F0CB3
	private const float P_POW_H = 68f; // Metadata: 0x005F0CB7
	private const float P_ID_Y = 614f; // Metadata: 0x005F0CBB
	private const float P_ID_H = 24f; // Metadata: 0x005F0CBF
	private const float R_X = 478f; // Metadata: 0x005F0CC3
	private const float R_W = 798f; // Metadata: 0x005F0CC7
	private const float SEC_X = 24f; // Metadata: 0x005F0CCB
	private const float SEC_Y = 14f; // Metadata: 0x005F0CCF
	private const float SEC_H = 34f; // Metadata: 0x005F0CD3
	private const float SEC_FS = 24f; // Metadata: 0x005F0CD7
	private const float R_DIV_Y = 52f; // Metadata: 0x005F0CDB
	private const float R_DIV_W = 750f; // Metadata: 0x005F0CDF
	private const float R_NAME_X = 24f; // Metadata: 0x005F0CE3
	private const float R_NAME_Y = 62f; // Metadata: 0x005F0CE7
	private const float R_NAME_W = 420f; // Metadata: 0x005F0CEB
	private const float R_NAME_H = 40f; // Metadata: 0x005F0CEF
	private const float R_LV_X = 460f; // Metadata: 0x005F0CF3
	private const float R_LV_Y = 64f; // Metadata: 0x005F0CF7
	private const float R_LV_W = 120f; // Metadata: 0x005F0CFB
	private const float R_LV_H = 36f; // Metadata: 0x005F0CFF
	private const float R_STAT_Y = 110f; // Metadata: 0x005F0D03
	private const float R_STAT_W = 242f; // Metadata: 0x005F0D07
	private const float R_STAT_H = 58f; // Metadata: 0x005F0D0B
	private const float R_STAT_STEP = 254f; // Metadata: 0x005F0D0F
	private const float L_SEC_Y = 182f; // Metadata: 0x005F0D13
	private const float L_DIV_Y = 220f; // Metadata: 0x005F0D17
	private const float L_DIV_W = 460f; // Metadata: 0x005F0D1B
	private const float L_VP_X = 24f; // Metadata: 0x005F0D1F
	private const float L_VP_Y = 230f; // Metadata: 0x005F0D23
	private const float L_VP_W = 460f; // Metadata: 0x005F0D27
	private const float L_VP_H = 390f; // Metadata: 0x005F0D2B
	private const float PET_CELL_W = 104f; // Metadata: 0x005F0D2F
	private const float PET_CELL_H = 116f; // Metadata: 0x005F0D33
	private const float CELL_GAP = 8f; // Metadata: 0x005F0D37
	private const int PET_COLS = 4; // Metadata: 0x005F0D3B
	private const float S_SEC_X = 508f; // Metadata: 0x005F0D3C
	private const float S_DIV_W = 266f; // Metadata: 0x005F0D40
	private const float S_VP_X = 508f; // Metadata: 0x005F0D44
	private const float S_VP_W = 266f; // Metadata: 0x005F0D48
	private const float STONE_CELL_W = 80f; // Metadata: 0x005F0D4C
	private const float STONE_CELL_H = 88f; // Metadata: 0x005F0D50
	private const int STONE_COLS = 3; // Metadata: 0x005F0D54
	private const int MAX_CELLS = 200; // Metadata: 0x005F0D55
	private const string ART_ATK = "icon_atk"; // Metadata: 0x005F0D57
	private const string ART_HP = "icon_hp"; // Metadata: 0x005F0D60
	private const string ART_MANA = "icon_mana"; // Metadata: 0x005F0D68
	private const string ART_STAR = "star_gold"; // Metadata: 0x005F0D72
	private const string ELEMENT_DIR = "Image/Attribute/"; // Metadata: 0x005F0D7C
	private const string PET_ICON_DIR = "Image/IconsPet/"; // Metadata: 0x005F0D8D
	private const string AVATAR_DIR = "Image/Avt/"; // Metadata: 0x005F0D9D
	private static readonly CultureInfo VN; // 0x00
	private static readonly Color POWER_COLOR; // 0x08
	private static readonly Color ATK_COLOR; // 0x18
	private static readonly Color HP_COLOR; // 0x28
	private static readonly Color MANA_COLOR; // 0x38
	private bool _built; // 0x20
	private RectTransform _infoRoot; // 0x28
	private RectTransform _content; // 0x30
	private CanvasGroup _group; // 0x38
	private Button _btnClose; // 0x40
	private UnityEngine.UI.Text _txtRank; // 0x48
	private Image _imgAvatar; // 0x50
	private Image _imgLevel; // 0x58
	private UnityEngine.UI.Text _txtLevel; // 0x60
	private WeaponBadgeUI _weapon; // 0x68
	private UnityEngine.UI.Text _txtName; // 0x70
	private UnityEngine.UI.Text _txtGuild; // 0x78
	private UnityEngine.UI.Text _txtPower; // 0x80
	private UnityEngine.UI.Text _txtId; // 0x88
	private RectTransform _petStage; // 0x90
	private Animator _petAnim; // 0x98
	private Image _petImg; // 0xA0
	private PetImageFit _petFit; // 0xA8
	private UnityEngine.UI.Text _txtPetName; // 0xB0
	private UnityEngine.UI.Text _txtPetLevel; // 0xB8
	private UnityEngine.UI.Text _txtAtk; // 0xC0
	private UnityEngine.UI.Text _txtHp; // 0xC8
	private UnityEngine.UI.Text _txtMana; // 0xD0
	private RectTransform _petGrid; // 0xD8
	private RectTransform _stoneGrid; // 0xE0
	private UnityEngine.UI.Text _secPets; // 0xE8
	private UnityEngine.UI.Text _secStones; // 0xF0
	private UnityEngine.UI.Text _emptyPets; // 0xF8
	private UnityEngine.UI.Text _emptyStones; // 0x100
	private ScrollRect _petScroll; // 0x108
	private ScrollRect _stoneScroll; // 0x110
	private readonly List<PetCell> _petCells; // 0x118
	private readonly List<StoneCell> _stoneCells; // 0x120
	private long _shownUserId; // 0x128
	private Func<long, Sprite> _stoneSprite; // 0x130

	// Properties
	public bool IsOpen { get; } // 0x0000000180B73740-0x0000000180B738A0 

	// Nested types
	private class PetCell // TypeDefIndex: 2441
	{
		// Fields
		public RectTransform root; // 0x10
		public Image icon; // 0x18
		public Image element; // 0x20
		public Image star; // 0x28
		public UnityEngine.UI.Text starText; // 0x30
		public UnityEngine.UI.Text level; // 0x38
		public long petId; // 0x40

		// Constructors
		public PetCell(); // 0x000000018028A320-0x000000018028A330
	}

	private class StoneCell // TypeDefIndex: 2442
	{
		// Fields
		public RectTransform root; // 0x10
		public Image icon; // 0x18
		public UnityEngine.UI.Text count; // 0x20

		// Constructors
		public StoneCell(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass175_0 // TypeDefIndex: 2443
	{
		// Fields
		public RankUserDetailPopup __4__this; // 0x10
		public PetCell c; // 0x18
		public long wantPet; // 0x20
		public long wantUser; // 0x28

		// Constructors
		public __c__DisplayClass175_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ApplyPetIcon_b__0(Sprite s); // 0x0000000180B7CED0-0x0000000180B7D0D0
	}

	// Constructors
	public RankUserDetailPopup(); // 0x0000000180B7C950-0x0000000180B7CBB0
	static RankUserDetailPopup(); // 0x0000000180B7CBB0-0x0000000180B7CCF0

	// Methods
	public static RankUserDetailPopup Mount(Transform panelRoot); // 0x0000000180B73040-0x0000000180B736E0
	public void SetStoneSpriteSource(Func<long, Sprite> resolver); // 0x0000000180B736E0-0x0000000180B73740
	public void Open(UserDetailData d); // 0x0000000180B738A0-0x0000000180B73C00
	public void Close(); // 0x0000000180B73C00-0x0000000180B74000
	public void CloseImmediate(); // 0x0000000180B74000-0x0000000180B74350
	private void ReleaseAvatar(); // 0x0000000180B74350-0x0000000180B74470
	private void OnDisable(); // 0x0000000180B74470-0x0000000180B74680
	private void Build(); // 0x0000000180B74680-0x0000000180B750E0
	private void BuildProfileCard(RectTransform box); // 0x0000000180B750E0-0x0000000180B76280
	private void BuildStatsCard(RectTransform box); // 0x0000000180B76280-0x0000000180B77270
	private UnityEngine.UI.Text StatChip(RectTransform card, string name, float x, string label, string icon, Color color); // 0x0000000180B77270-0x0000000180B77520
	private RectTransform BuildGrid(RectTransform card, string name, float x, float y, float w, float h, float cellW, float cellH, int cols, out ScrollRect scroll); // 0x0000000180B77520-0x0000000180B77CA0
	private void Render(UserDetailData d); // 0x0000000180B77CA0-0x0000000180B77ED0
	private void RenderProfile(UserDetailData d); // 0x0000000180B77ED0-0x0000000180B78E00
	private void RenderPet(PetDetailInfo pet); // 0x0000000180B78E00-0x0000000180B79220
	private void RenderPets(List<UserPetInfo> pets); // 0x0000000180B79220-0x0000000180B79660
	private void RenderStones(List<StoneInfo> stones); // 0x0000000180B79660-0x0000000180B79BE0
	private PetCell EnsurePetCell(int index); // 0x0000000180B79BE0-0x0000000180B79F30
	private PetCell NewPetCell(); // 0x0000000180B79F30-0x0000000180B7A730
	private void BindPetCell(PetCell c, UserPetInfo pet); // 0x0000000180B7A730-0x0000000180B7ACA0
	private void ApplyPetIcon(PetCell c, string path); // 0x0000000180B7ACA0-0x0000000180B7B0D0
	private StoneCell EnsureStoneCell(int index); // 0x0000000180B7B0D0-0x0000000180B7B420
	private StoneCell NewStoneCell(); // 0x0000000180B7B420-0x0000000180B7B810
	private void BindStoneCell(StoneCell c, StoneInfo stone); // 0x0000000180B7B810-0x0000000180B7B940
	private static void EnsureRaycaster(Transform node); // 0x0000000180B7B940-0x0000000180B7BC10
	private void FitLevelBadge(); // 0x0000000180B7BC10-0x0000000180B7C080
	private static void SplitDecoratedName(string raw, out string name, out string extra); // 0x0000000180B7C080-0x0000000180B7C4F0
	private static string PlainName(string s); // 0x0000000180B7C4F0-0x0000000180B7C640
	private static void ApplyIcon(Image img, string path); // 0x0000000180B7C640-0x0000000180B7C6F0
	private static void SetIcon(Image img, Sprite sprite); // 0x0000000180B7C6F0-0x0000000180B7C8D0
	private static Color RankTint(int rank); // 0x0000000180B7C8D0-0x0000000180B7C950
	[CompilerGenerated]
	private void _Close_b__158_0(); // 0x0000000180B7CCF0-0x0000000180B7CED0
}

