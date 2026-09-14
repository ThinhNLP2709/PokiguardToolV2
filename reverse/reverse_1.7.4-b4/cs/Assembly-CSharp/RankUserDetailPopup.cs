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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class RankUserDetailPopup : MonoBehaviour // TypeDefIndex: 2447
{
	// Fields
	public const string NODE_NAME = "[RankUserDetail]"; // Metadata: 0x005F1FC7
	private const string N_POKY_SKIN = "PokySkin"; // Metadata: 0x005F1FD8
	private const float FRAME_W = 1774f; // Metadata: 0x005F1FE1
	private const float FRAME_H = 887f; // Metadata: 0x005F1FE5
	private const float DIM_OVERSCAN = 600f; // Metadata: 0x005F1FE9
	private const float BOX_W = 1300f; // Metadata: 0x005F1FED
	private const float BOX_H = 800f; // Metadata: 0x005F1FF1
	private const float BOX_X = 237f; // Metadata: 0x005F1FF5
	private const float BOX_Y = 44f; // Metadata: 0x005F1FF9
	private const float TITLE_Y = 18f; // Metadata: 0x005F1FFD
	private const float TITLE_H = 54f; // Metadata: 0x005F2001
	private const float TITLE_FS = 40f; // Metadata: 0x005F2005
	private const float CLOSE_X = 1205f; // Metadata: 0x005F2009
	private const float CLOSE_Y = 10f; // Metadata: 0x005F200D
	private const float CLOSE_W = 78f; // Metadata: 0x005F2011
	private const float CLOSE_H = 80f; // Metadata: 0x005F2015
	private const float HINT_Y = 754f; // Metadata: 0x005F2019
	private const float HINT_H = 28f; // Metadata: 0x005F201D
	private const float CARD_Y = 96f; // Metadata: 0x005F2021
	private const float CARD_H = 640f; // Metadata: 0x005F2025
	private const float P_X = 24f; // Metadata: 0x005F2029
	private const float P_W = 430f; // Metadata: 0x005F202D
	private const float P_CHIP_X = 90f; // Metadata: 0x005F2031
	private const float P_CHIP_Y = 14f; // Metadata: 0x005F2035
	private const float P_CHIP_W = 250f; // Metadata: 0x005F2039
	private const float P_CHIP_H = 46f; // Metadata: 0x005F203D
	private const float P_PORT_X = 55f; // Metadata: 0x005F2041
	private const float P_PORT_Y = 68f; // Metadata: 0x005F2045
	private const float P_PORT_W = 320f; // Metadata: 0x005F2049
	private const float P_PORT_H = 360f; // Metadata: 0x005F204D
	private const float P_AVA_X = 10f; // Metadata: 0x005F2051
	private const float P_AVA_Y = 8f; // Metadata: 0x005F2055
	private const float P_AVA_W = 300f; // Metadata: 0x005F2059
	private const float P_AVA_H = 320f; // Metadata: 0x005F205D
	private const float P_LV_X = 8f; // Metadata: 0x005F2061
	private const float P_LV_Y = 8f; // Metadata: 0x005F2065
	private const float P_LV_H = 72f; // Metadata: 0x005F2069
	private const float LV_FALLBACK_AR = 1.5152019f; // Metadata: 0x005F206D
	private const float LV_TEXT_OFFSET = -0.041f; // Metadata: 0x005F2071
	private const float P_WEP_X = 240f; // Metadata: 0x005F2075
	private const float P_WEP_Y = 268f; // Metadata: 0x005F2079
	private const float P_WEP_D = 68f; // Metadata: 0x005F207D
	private const float P_PET_X = 170f; // Metadata: 0x005F2081
	private const float P_PET_Y = 220f; // Metadata: 0x005F2085
	private const float P_PET_W = 140f; // Metadata: 0x005F2089
	private const float P_PET_H = 132f; // Metadata: 0x005F208D
	private const float P_NAME_X = 105f; // Metadata: 0x005F2091
	private const float P_NAME_Y = 440f; // Metadata: 0x005F2095
	private const float P_NAME_W = 220f; // Metadata: 0x005F2099
	private const float P_NAME_H = 48f; // Metadata: 0x005F209D
	private const float VIP_BADGE_SCALE = 0.8f; // Metadata: 0x005F20A1
	private const int NAME_MAX_CHARS = 20; // Metadata: 0x005F20A5
	private const float P_GUILD_X = 15f; // Metadata: 0x005F20A6
	private const float P_GUILD_W = 400f; // Metadata: 0x005F20AA
	private const float P_GUILD_Y = 492f; // Metadata: 0x005F20AE
	private const float P_GUILD_H = 28f; // Metadata: 0x005F20B2
	private const float P_DIV_X = 36f; // Metadata: 0x005F20B6
	private const float P_DIV_Y = 530f; // Metadata: 0x005F20BA
	private const float P_DIV_W = 358f; // Metadata: 0x005F20BE
	private const float P_POW_X = 55f; // Metadata: 0x005F20C2
	private const float P_POW_Y = 542f; // Metadata: 0x005F20C6
	private const float P_POW_W = 320f; // Metadata: 0x005F20CA
	private const float P_POW_H = 68f; // Metadata: 0x005F20CE
	private const float P_ID_Y = 614f; // Metadata: 0x005F20D2
	private const float P_ID_H = 24f; // Metadata: 0x005F20D6
	private const float R_X = 478f; // Metadata: 0x005F20DA
	private const float R_W = 798f; // Metadata: 0x005F20DE
	private const float SEC_X = 24f; // Metadata: 0x005F20E2
	private const float SEC_Y = 14f; // Metadata: 0x005F20E6
	private const float SEC_H = 34f; // Metadata: 0x005F20EA
	private const float SEC_FS = 24f; // Metadata: 0x005F20EE
	private const float R_DIV_Y = 52f; // Metadata: 0x005F20F2
	private const float R_DIV_W = 750f; // Metadata: 0x005F20F6
	private const float R_NAME_X = 24f; // Metadata: 0x005F20FA
	private const float R_NAME_Y = 62f; // Metadata: 0x005F20FE
	private const float R_NAME_W = 420f; // Metadata: 0x005F2102
	private const float R_NAME_H = 40f; // Metadata: 0x005F2106
	private const float R_LV_X = 460f; // Metadata: 0x005F210A
	private const float R_LV_Y = 64f; // Metadata: 0x005F210E
	private const float R_LV_W = 120f; // Metadata: 0x005F2112
	private const float R_LV_H = 36f; // Metadata: 0x005F2116
	private const float R_STAT_Y = 110f; // Metadata: 0x005F211A
	private const float R_STAT_W = 242f; // Metadata: 0x005F211E
	private const float R_STAT_H = 58f; // Metadata: 0x005F2122
	private const float R_STAT_STEP = 254f; // Metadata: 0x005F2126
	private const float L_SEC_Y = 182f; // Metadata: 0x005F212A
	private const float L_DIV_Y = 220f; // Metadata: 0x005F212E
	private const float L_DIV_W = 460f; // Metadata: 0x005F2132
	private const float L_VP_X = 24f; // Metadata: 0x005F2136
	private const float L_VP_Y = 230f; // Metadata: 0x005F213A
	private const float L_VP_W = 460f; // Metadata: 0x005F213E
	private const float L_VP_H = 390f; // Metadata: 0x005F2142
	private const float PET_CELL_W = 104f; // Metadata: 0x005F2146
	private const float PET_CELL_H = 116f; // Metadata: 0x005F214A
	private const float CELL_GAP = 8f; // Metadata: 0x005F214E
	private const int PET_COLS = 4; // Metadata: 0x005F2152
	private const float S_SEC_X = 508f; // Metadata: 0x005F2153
	private const float S_DIV_W = 266f; // Metadata: 0x005F2157
	private const float S_VP_X = 508f; // Metadata: 0x005F215B
	private const float S_VP_W = 266f; // Metadata: 0x005F215F
	private const float STONE_CELL_W = 80f; // Metadata: 0x005F2163
	private const float STONE_CELL_H = 88f; // Metadata: 0x005F2167
	private const int STONE_COLS = 3; // Metadata: 0x005F216B
	private const int MAX_CELLS = 200; // Metadata: 0x005F216C
	private const string ART_ATK = "icon_atk"; // Metadata: 0x005F216E
	private const string ART_HP = "icon_hp"; // Metadata: 0x005F2177
	private const string ART_MANA = "icon_mana"; // Metadata: 0x005F217F
	private const string ART_STAR = "star_gold"; // Metadata: 0x005F2189
	private const string ELEMENT_DIR = "Image/Attribute/"; // Metadata: 0x005F2193
	private const string PET_ICON_DIR = "Image/IconsPet/"; // Metadata: 0x005F21A4
	private const string AVATAR_DIR = "Image/Avt/"; // Metadata: 0x005F21B4
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
	public bool IsOpen { get; } // 0x0000000180B80AA0-0x0000000180B80C00 

	// Nested types
	private class PetCell // TypeDefIndex: 2448
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

	private class StoneCell // TypeDefIndex: 2449
	{
		// Fields
		public RectTransform root; // 0x10
		public Image icon; // 0x18
		public UnityEngine.UI.Text count; // 0x20

		// Constructors
		public StoneCell(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass175_0 // TypeDefIndex: 2450
	{
		// Fields
		public RankUserDetailPopup __4__this; // 0x10
		public PetCell c; // 0x18
		public long wantPet; // 0x20
		public long wantUser; // 0x28

		// Constructors
		public __c__DisplayClass175_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ApplyPetIcon_b__0(Sprite s); // 0x0000000180B8A2F0-0x0000000180B8A4F0
	}

	// Constructors
	public RankUserDetailPopup(); // 0x0000000180B89CB0-0x0000000180B89F10
	static RankUserDetailPopup(); // 0x0000000180B89F10-0x0000000180B8A050

	// Methods
	public static RankUserDetailPopup Mount(Transform panelRoot); // 0x0000000180B803A0-0x0000000180B80A40
	public void SetStoneSpriteSource(Func<long, Sprite> resolver); // 0x0000000180B80A40-0x0000000180B80AA0
	public void Open(UserDetailData d); // 0x0000000180B80C00-0x0000000180B80F60
	public void Close(); // 0x0000000180B80F60-0x0000000180B81360
	public void CloseImmediate(); // 0x0000000180B81360-0x0000000180B816B0
	private void ReleaseAvatar(); // 0x0000000180B816B0-0x0000000180B817D0
	private void OnDisable(); // 0x0000000180B817D0-0x0000000180B819E0
	private void Build(); // 0x0000000180B819E0-0x0000000180B82440
	private void BuildProfileCard(RectTransform box); // 0x0000000180B82440-0x0000000180B835E0
	private void BuildStatsCard(RectTransform box); // 0x0000000180B835E0-0x0000000180B845D0
	private UnityEngine.UI.Text StatChip(RectTransform card, string name, float x, string label, string icon, Color color); // 0x0000000180B845D0-0x0000000180B84880
	private RectTransform BuildGrid(RectTransform card, string name, float x, float y, float w, float h, float cellW, float cellH, int cols, out ScrollRect scroll); // 0x0000000180B84880-0x0000000180B85000
	private void Render(UserDetailData d); // 0x0000000180B85000-0x0000000180B85230
	private void RenderProfile(UserDetailData d); // 0x0000000180B85230-0x0000000180B86160
	private void RenderPet(PetDetailInfo pet); // 0x0000000180B86160-0x0000000180B86580
	private void RenderPets(List<UserPetInfo> pets); // 0x0000000180B86580-0x0000000180B869C0
	private void RenderStones(List<StoneInfo> stones); // 0x0000000180B869C0-0x0000000180B86F40
	private PetCell EnsurePetCell(int index); // 0x0000000180B86F40-0x0000000180B87290
	private PetCell NewPetCell(); // 0x0000000180B87290-0x0000000180B87A90
	private void BindPetCell(PetCell c, UserPetInfo pet); // 0x0000000180B87A90-0x0000000180B88000
	private void ApplyPetIcon(PetCell c, string path); // 0x0000000180B88000-0x0000000180B88430
	private StoneCell EnsureStoneCell(int index); // 0x0000000180B88430-0x0000000180B88780
	private StoneCell NewStoneCell(); // 0x0000000180B88780-0x0000000180B88B70
	private void BindStoneCell(StoneCell c, StoneInfo stone); // 0x0000000180B88B70-0x0000000180B88CA0
	private static void EnsureRaycaster(Transform node); // 0x0000000180B88CA0-0x0000000180B88F70
	private void FitLevelBadge(); // 0x0000000180B88F70-0x0000000180B893E0
	private static void SplitDecoratedName(string raw, out string name, out string extra); // 0x0000000180B893E0-0x0000000180B89850
	private static string PlainName(string s); // 0x0000000180B89850-0x0000000180B899A0
	private static void ApplyIcon(Image img, string path); // 0x0000000180B899A0-0x0000000180B89A50
	private static void SetIcon(Image img, Sprite sprite); // 0x0000000180B89A50-0x0000000180B89C30
	private static Color RankTint(int rank); // 0x0000000180B89C30-0x0000000180B89CB0
	[CompilerGenerated]
	private void _Close_b__158_0(); // 0x0000000180B8A050-0x0000000180B8A2F0
}

