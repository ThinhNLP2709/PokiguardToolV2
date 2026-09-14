/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokiGame.LegendPet
{
	[DisallowMultipleComponent]
	public class LegendStarPanel : MonoBehaviour // TypeDefIndex: 2587
	{
		// Fields
		public const string NODE_NAME = "[LegendStarPanel]"; // Metadata: 0x005F2408
		private const float FRAME_W = 1774f; // Metadata: 0x005F241A
		private const float FRAME_H = 887f; // Metadata: 0x005F241E
		private const float DIM_OVERSCAN = 600f; // Metadata: 0x005F2422
		private const float TITLE_Y = 26f; // Metadata: 0x005F2426
		private const float TITLE_H = 60f; // Metadata: 0x005F242A
		private const float TITLE_FS = 44f; // Metadata: 0x005F242E
		private const float CLOSE_X = 1673f; // Metadata: 0x005F2432
		private const float CLOSE_Y = 12f; // Metadata: 0x005F2436
		private const float CLOSE_W = 81f; // Metadata: 0x005F243A
		private const float CLOSE_H = 84f; // Metadata: 0x005F243E
		private const float CARD_Y = 118f; // Metadata: 0x005F2442
		private const float CARD_H = 720f; // Metadata: 0x005F2446
		private const float L_X = 44f; // Metadata: 0x005F244A
		private const float L_W = 330f; // Metadata: 0x005F244E
		private const float C_X = 400f; // Metadata: 0x005F2452
		private const float C_W = 900f; // Metadata: 0x005F2456
		private const float R_X = 1326f; // Metadata: 0x005F245A
		private const float R_W = 404f; // Metadata: 0x005F245E
		private const float SEC_H = 34f; // Metadata: 0x005F2462
		private const float SEC_FS = 24f; // Metadata: 0x005F2466
		private const float L_SEC_X = 20f; // Metadata: 0x005F246A
		private const float L_SEC_Y = 14f; // Metadata: 0x005F246E
		private const float L_DIV_Y = 52f; // Metadata: 0x005F2472
		private const float L_DIV_W = 290f; // Metadata: 0x005F2476
		private const float L_VP_X = 16f; // Metadata: 0x005F247A
		private const float L_VP_Y = 64f; // Metadata: 0x005F247E
		private const float L_VP_W = 298f; // Metadata: 0x005F2482
		private const float L_VP_H = 642f; // Metadata: 0x005F2486
		private const float ROW_W = 290f; // Metadata: 0x005F248A
		private const float ROW_H = 104f; // Metadata: 0x005F248E
		private const float ROW_GAP = 8f; // Metadata: 0x005F2492
		private const float RW_ICON_X = 10f; // Metadata: 0x005F2496
		private const float RW_ICON_Y = 10f; // Metadata: 0x005F249A
		private const float RW_ICON_D = 84f; // Metadata: 0x005F249E
		private const float RW_TXT_X = 104f; // Metadata: 0x005F24A2
		private const float RW_NAME_Y = 10f; // Metadata: 0x005F24A6
		private const float RW_TXT_W = 174f; // Metadata: 0x005F24AA
		private const float RW_NAME_H = 34f; // Metadata: 0x005F24AE
		private const float RW_TRACK_Y = 52f; // Metadata: 0x005F24B2
		private const float RW_TRACK_H = 14f; // Metadata: 0x005F24B6
		private const float RW_SUB_Y = 70f; // Metadata: 0x005F24BA
		private const float RW_SUB_W = 88f; // Metadata: 0x005F24BE
		private const float RW_SUB_H = 26f; // Metadata: 0x005F24C2
		private const float RW_TAG_X = 104f; // Metadata: 0x005F24C6
		private const float RW_TAG_W = 132f; // Metadata: 0x005F24CA
		private const float RW_TAG_H = 30f; // Metadata: 0x005F24CE
		private const int MAX_ROWS = 40; // Metadata: 0x005F24D2
		private const float C_NAME_Y = 10f; // Metadata: 0x005F24D3
		private const float C_NAME_H = 46f; // Metadata: 0x005F24D7
		private const float C_NAME_FS = 32f; // Metadata: 0x005F24DB
		private const float STAGE_X = 170f; // Metadata: 0x005F24DF
		private const float STAGE_Y = 64f; // Metadata: 0x005F24E3
		private const float STAGE_W = 560f; // Metadata: 0x005F24E7
		private const float STAGE_H = 566f; // Metadata: 0x005F24EB
		private const float C_DIV_X = 60f; // Metadata: 0x005F24EF
		private const float C_DIV_Y = 644f; // Metadata: 0x005F24F3
		private const float C_DIV_W = 780f; // Metadata: 0x005F24F7
		private const float C_LBL_Y = 652f; // Metadata: 0x005F24FB
		private const float C_LBL_H = 32f; // Metadata: 0x005F24FF
		private const float C_LBL_FS = 22f; // Metadata: 0x005F2503
		private const float C_BAR_Y = 690f; // Metadata: 0x005F2507
		private const float C_BAR_H = 22f; // Metadata: 0x005F250B
		private const float GEM_RATIO = 0.08158191f; // Metadata: 0x005F250F
		private const int MAX_GEMS = 120; // Metadata: 0x005F2513
		private const float R_PAD = 24f; // Metadata: 0x005F2515
		private const float R_INNER = 356f; // Metadata: 0x005F2519
		private const float R_SEC1_Y = 14f; // Metadata: 0x005F251D
		private const float R_DIV1_Y = 52f; // Metadata: 0x005F2521
		private const float R_WALLET_Y = 62f; // Metadata: 0x005F2525
		private const float R_WALLET_H = 54f; // Metadata: 0x005F2529
		private const float R_WALLET_STEP = 60f; // Metadata: 0x005F252D
		private const float R_DIV2_Y = 246f; // Metadata: 0x005F2531
		private const float R_SEC2_Y = 256f; // Metadata: 0x005F2535
		private const float R_BLOCK_Y = 300f; // Metadata: 0x005F2539
		private const float R_NEED_H = 44f; // Metadata: 0x005F253D
		private const float R_NEED_STEP = 48f; // Metadata: 0x005F2541
		private const float R_HINT_Y = 456f; // Metadata: 0x005F2545
		private const float R_HINT_H = 240f; // Metadata: 0x005F2549
		private const float R_STAT_H = 58f; // Metadata: 0x005F254D
		private const float R_STAT_STEP = 66f; // Metadata: 0x005F2551
		private const float R_ELEM_Y = 500f; // Metadata: 0x005F2555
		private const float R_ELEM_H = 52f; // Metadata: 0x005F2559
		private const float R_DESC_Y = 562f; // Metadata: 0x005F255D
		private const float R_DESC_H = 138f; // Metadata: 0x005F2561
		private const float CARD_W = 96f; // Metadata: 0x005F2565
		private const float DLG_W = 700f; // Metadata: 0x005F2569
		private const float DLG_H = 430f; // Metadata: 0x005F256D
		private const float DLG_ICON_D = 96f; // Metadata: 0x005F2571
		private const float DLG_BTN_Y = 336f; // Metadata: 0x005F2575
		private const float DLG_BTN_W = 220f; // Metadata: 0x005F2579
		private const float DLG_BTN_H = 66f; // Metadata: 0x005F257D
		private const string GEM_ATLAS = "Image/stone/ngoc (3)"; // Metadata: 0x005F2581
		private static readonly string[] GEM_SPRITE; // 0x00
		private const string PET_ICON_DIR = "Image/IconsPet/"; // Metadata: 0x005F2596
		private const string ELEMENT_DIR = "Image/Attribute/"; // Metadata: 0x005F25A6
		private const string CARD_DIR = "Image/Card/HT"; // Metadata: 0x005F25B7
		private const string ART_ATK = "icon_atk"; // Metadata: 0x005F25C5
		private const string ART_HP = "icon_hp"; // Metadata: 0x005F25CE
		private const string ART_MANA = "icon_mana"; // Metadata: 0x005F25D6
		private static readonly Color[] STAR_TINT; // 0x08
		private static readonly string[] STAR_NAME; // 0x10
		private static readonly Color GEM_LOCKED; // 0x18
		private const float GEM_DONE_ALPHA = 0.55f; // Metadata: 0x005F25E0
		private const float GEM_DONE_SCALE = 0.78f; // Metadata: 0x005F25E4
		private static readonly Color PET_SILHOUETTE; // 0x28
		private static readonly Color ATK_COLOR; // 0x38
		private static readonly Color HP_COLOR; // 0x48
		private static readonly Color MANA_COLOR; // 0x58
		private bool _built; // 0x20
		private long _userId; // 0x28
		private RectTransform _infoRoot; // 0x30
		private RectTransform _content; // 0x38
		private CanvasGroup _group; // 0x40
		private Button _btnClose; // 0x48
		private Button _dimButton; // 0x50
		private RectTransform _listContent; // 0x58
		private ScrollRect _listScroll; // 0x60
		private UnityEngine.UI.Text _listEmpty; // 0x68
		private readonly List<PetRow> _rows; // 0x70
		private UnityEngine.UI.Text _txtPetName; // 0x78
		private RectTransform _stageBox; // 0x80
		private RectTransform _stage; // 0x88
		private Animator _petAnim; // 0x90
		private Image _petImg; // 0x98
		private PetImageFit _petFit; // 0xA0
		private RectTransform _gemLayer; // 0xA8
		private LegendStarFx _fx; // 0xB0
		private readonly List<GemCell> _gems; // 0xB8
		private UnityEngine.UI.Text _txtProgress; // 0xC0
		private Image _barFill; // 0xC8
		private readonly UnityEngine.UI.Text[] _wallet; // 0xD0
		private UnityEngine.UI.Text _secRight; // 0xD8
		private RectTransform _blockNeed; // 0xE0
		private RectTransform _blockStats; // 0xE8
		private readonly UnityEngine.UI.Text[] _txtNeed; // 0xF0
		private UnityEngine.UI.Text _txtHint; // 0xF8
		private UnityEngine.UI.Text _txtAtk; // 0x100
		private UnityEngine.UI.Text _txtHp; // 0x108
		private UnityEngine.UI.Text _txtMana; // 0x110
		private UnityEngine.UI.Text _txtLevel; // 0x118
		private UnityEngine.UI.Text _txtDesc; // 0x120
		private Image _imgElement; // 0x128
		private Image _imgElementOther; // 0x130
		private Image _imgCard; // 0x138
		private RectTransform _dlg; // 0x140
		private CanvasGroup _dlgGroup; // 0x148
		private Image _dlgIcon; // 0x150
		private UnityEngine.UI.Text _dlgMsg; // 0x158
		private UnityEngine.UI.Text _dlgCost; // 0x160
		private Button _dlgOk; // 0x168
		private LegendPetBasicInfo[] _pets; // 0x170
		private LegendPetData _current; // 0x178
		private int _currentIndex; // 0x180
		private readonly Dictionary<long, LegendPetData> _detailCache; // 0x188
		private readonly Dictionary<long, PetUserDTO> _statsCache; // 0x190
		private StarSlotData _pendingSlot; // 0x198
		private LegendPetData _pendingPet; // 0x1A0
		private int _pendingIndex; // 0x1A8
		private bool _inlaying; // 0x1AC
		private static Sprite[] _gemSprites; // 0x68
		public Action Closed; // 0x1B0
	
		// Properties
		public bool IsOpen { get; } // 0x0000000180BE6F90-0x0000000180BE70F0 
		private static LegendPetAPIService Api { get; } // 0x0000000180BEF4A0-0x0000000180BEF530 
	
		// Nested types
		private class PetRow // TypeDefIndex: 2588
		{
			// Fields
			public RectTransform root; // 0x10
			public Image bg; // 0x18
			public Image icon; // 0x20
			public UnityEngine.UI.Text name; // 0x28
			public UnityEngine.UI.Text sub; // 0x30
			public Image trackFill; // 0x38
			public Image tagBg; // 0x40
			public UnityEngine.UI.Text tag; // 0x48
			public Button button; // 0x50
	
			// Constructors
			public PetRow(); // 0x000000018028A320-0x000000018028A330
		}
	
		private class GemCell // TypeDefIndex: 2589
		{
			// Fields
			public RectTransform root; // 0x10
			public Image img; // 0x18
			public Button button; // 0x20
			public StarSlotData slot; // 0x28
	
			// Constructors
			public GemCell(); // 0x000000018028A320-0x000000018028A330
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2590
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<string> __9__192_1; // 0x08
			public static Action<string> __9__193_1; // 0x10
			public static Comparison<StarSlotData> __9__201_0; // 0x18
	
			// Constructors
			static __c(); // 0x0000000180BF90E0-0x0000000180BF9180
			public __c(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PreloadDetail_b__192_1(string err); // 0x000000018028A320-0x000000018028A330
			internal void _PreloadStats_b__193_1(string err); // 0x000000018028A320-0x000000018028A330
			internal int _BuildGems_b__201_0(StarSlotData a, StarSlotData b); // 0x0000000180BF9180-0x0000000180BF91C0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass186_0 // TypeDefIndex: 2591
		{
			// Fields
			public LegendStarPanel __4__this; // 0x10
			public Transform host; // 0x18
	
			// Constructors
			public __c__DisplayClass186_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _HideDialog_b__0(); // 0x0000000180BF91C0-0x0000000180BF93B0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass192_0 // TypeDefIndex: 2592
		{
			// Fields
			public LegendStarPanel __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass192_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PreloadDetail_b__0(LegendPetData data); // 0x0000000180BF93B0-0x0000000180BF9450
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass193_0 // TypeDefIndex: 2593
		{
			// Fields
			public LegendStarPanel __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass193_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PreloadStats_b__0(PetUserDTO pet); // 0x0000000180BF9450-0x0000000180BF94E0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass194_0 // TypeDefIndex: 2594
		{
			// Fields
			public LegendStarPanel __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass194_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _SelectPet_b__0(LegendPetData data); // 0x0000000180BF94E0-0x0000000180BF96C0
			internal void _SelectPet_b__1(string err); // 0x0000000180BF96C0-0x0000000180BF97D0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass198_0 // TypeDefIndex: 2595
		{
			// Fields
			public LegendStarPanel __4__this; // 0x10
			public int captured; // 0x18
	
			// Constructors
			public __c__DisplayClass198_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BindRow_b__0(); // 0x0000000180BF97D0-0x0000000180BF9850
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass205_0 // TypeDefIndex: 2596
		{
			// Fields
			public LegendStarPanel __4__this; // 0x10
			public StarSlotData shown; // 0x18
	
			// Constructors
			public __c__DisplayClass205_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BindGem_b__0(); // 0x0000000180BF9850-0x0000000180BF98E0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass205_1 // TypeDefIndex: 2597
		{
			// Fields
			public StarSlotData captured; // 0x10
			public __c__DisplayClass205_0 CS___8__locals1; // 0x18
	
			// Constructors
			public __c__DisplayClass205_1(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BindGem_b__1(); // 0x0000000180BF98E0-0x0000000180BF9980
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass209_0 // TypeDefIndex: 2598
		{
			// Fields
			public LegendStarPanel __4__this; // 0x10
			public long want; // 0x18
	
			// Constructors
			public __c__DisplayClass209_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PaintSide_b__0(PetUserDTO pet); // 0x0000000180BF9980-0x0000000180BF9B40
			internal void _PaintSide_b__1(string err); // 0x0000000180BF9B40-0x0000000180BF9C00
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass222_0 // TypeDefIndex: 2599
		{
			// Fields
			public GemCell cell; // 0x10
			public LegendStarPanel __4__this; // 0x18
			public float rest; // 0x20
	
			// Constructors
			public __c__DisplayClass222_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PlayInlayFx_b__0(); // 0x0000000180BF9C00-0x0000000180BF9D10
		}
	
		// Constructors
		public LegendStarPanel(); // 0x0000000180BF8680-0x0000000180BF8B10
		static LegendStarPanel(); // 0x0000000180BF8B10-0x0000000180BF8ED0
	
		// Methods
		public static LegendStarPanel Mount(Transform host); // 0x0000000180BE6970-0x0000000180BE6F90
		public void Show(); // 0x0000000180BE70F0-0x0000000180BE7490
		public void Hide(); // 0x0000000180BE7490-0x0000000180BE7730
		public void HideImmediate(); // 0x0000000180BE7730-0x0000000180BE7A20
		private void ReleasePet(); // 0x0000000180BE7A20-0x0000000180BE7B90
		private void OnEnable(); // 0x0000000180BE7B90-0x0000000180BE7D10
		private void OnDisable(); // 0x0000000180BE7D10-0x0000000180BE8050
		private void Build(); // 0x0000000180BE8050-0x0000000180BE8C00
		private static void EnsureRaycaster(Transform node); // 0x0000000180BE8C00-0x0000000180BE8ED0
		private void RequestClose(); // 0x0000000180BE8ED0-0x0000000180BE9120
		private void SetLocked(bool on); // 0x0000000180BE9120-0x0000000180BE9310
		private void BuildPetList(RectTransform root); // 0x0000000180BE9310-0x0000000180BE9D90
		private PetRow EnsureRow(int index); // 0x0000000180BE9D90-0x0000000180BEA0D0
		private PetRow NewRow(); // 0x0000000180BEA0D0-0x0000000180BEAB40
		private void BuildStageCard(RectTransform root); // 0x0000000180BEAB40-0x0000000180BEB6A0
		private void BuildSideCard(RectTransform root); // 0x0000000180BEB6A0-0x0000000180BED680
		private UnityEngine.UI.Text StatChip(RectTransform parent, string name, float y, string label, string icon, Color color); // 0x0000000180BED680-0x0000000180BED940
		private Image NewElementIcon(RectTransform parent, string name, float x); // 0x0000000180BED940-0x0000000180BEDAA0
		private void BuildDialog(RectTransform root); // 0x0000000180BEDAA0-0x0000000180BEE5D0
		private void ShowDialog(StarSlotData slot); // 0x0000000180BEE5D0-0x0000000180BEF000
		private void HideDialog(bool immediate); // 0x0000000180BEF000-0x0000000180BEF4A0
		private void LoadPets(); // 0x0000000180BEF530-0x0000000180BEF770
		private void OnPetsLoaded(LegendPetListResponse resp); // 0x0000000180BEF770-0x0000000180BEF9F0
		private void OnPetsError(string error); // 0x0000000180BEF9F0-0x0000000180BEFBE0
		private void PreloadDetail(long petId); // 0x0000000180BEFBE0-0x0000000180BEFF10
		private void PreloadStats(long petId); // 0x0000000180BEFF10-0x0000000180BF0240
		private void SelectPet(int index); // 0x0000000180BF0240-0x0000000180BF1230
		private void OnDetailLoaded(LegendPetData data); // 0x0000000180BF1230-0x0000000180BF13D0
		private void SetListMessage(string message); // 0x0000000180BF13D0-0x0000000180BF1580
		private void PaintList(); // 0x0000000180BF1580-0x0000000180BF18C0
		private void BindRow(PetRow row, LegendPetBasicInfo pet, int index); // 0x0000000180BF18C0-0x0000000180BF1EB0
		private void PaintListSelection(); // 0x0000000180BF1EB0-0x0000000180BF2200
		private void PaintStage(LegendPetData data); // 0x0000000180BF2200-0x0000000180BF2960
		private void BuildGems(LegendPetData data, float stageW, float stageH); // 0x0000000180BF2960-0x0000000180BF2F20
		private static List<StarSlotData> MergeSlots(LegendPetData data); // 0x0000000180BF2F20-0x0000000180BF3120
		private GemCell EnsureGem(int index); // 0x0000000180BF3120-0x0000000180BF3400
		private GemCell NewGem(); // 0x0000000180BF3400-0x0000000180BF3660
		private void BindGem(GemCell cell); // 0x0000000180BF3660-0x0000000180BF3FD0
		private void Twinkle(GemCell cell, float rest); // 0x0000000180BF3FD0-0x0000000180BF41E0
		private void CancelGemTweens(); // 0x0000000180BF41E0-0x0000000180BF4460
		private void PaintProgress(LegendPetData data); // 0x0000000180BF4460-0x0000000180BF48A0
		private void PaintSide(LegendPetData data); // 0x0000000180BF48A0-0x0000000180BF4D30
		private void PaintNeed(LegendPetData data); // 0x0000000180BF4D30-0x0000000180BF5360
		private void PaintStats(LegendPetData data, PetUserDTO pet); // 0x0000000180BF5360-0x0000000180BF5AA0
		private static void ApplyElement(Image img, string element); // 0x0000000180BF5AA0-0x0000000180BF5CE0
		private static int WalletOf(int starType); // 0x0000000180BF5CE0-0x0000000180BF5D90
		private void PaintWallet(); // 0x0000000180BF5D90-0x0000000180BF5F10
		private void OnWalletChanged(int white, int blue, int red); // 0x0000000180BF5F10-0x0000000180BF6160
		private static void RecomputeCanInlay(LegendPetData data); // 0x0000000180BF6160-0x0000000180BF62E0
		private void OnGemTapped(StarSlotData slot); // 0x0000000180BF62E0-0x0000000180BF6300
		private void OnConfirmInlay(); // 0x0000000180BF6300-0x0000000180BF66C0
		private void OnInlayDone(InlayStarResponse resp); // 0x0000000180BF66C0-0x0000000180BF6E50
		private void OnInlayFailed(string error); // 0x0000000180BF6E50-0x0000000180BF6F40
		private void RefreshGemsAfterInlay(); // 0x0000000180BF6F40-0x0000000180BF7100
		private void PlayInlayFx(StarSlotData slot); // 0x0000000180BF7100-0x0000000180BF78A0
		private void CelebrateUnlock(LegendPetData pet); // 0x0000000180BF78A0-0x0000000180BF7F70
		private GemCell FindGem(StarSlotData slot); // 0x0000000180BF7F70-0x0000000180BF8150
		private static string PetName(LegendPetData data); // 0x0000000180BF8150-0x0000000180BF81E0
		private static Sprite GemSprite(int starType); // 0x0000000180BF81E0-0x0000000180BF8680
		[CompilerGenerated]
		private void _Hide_b__168_0(); // 0x0000000180BF8ED0-0x0000000180BF90D0
		[CompilerGenerated]
		private void _BuildDialog_b__184_0(); // 0x0000000180BF90D0-0x0000000180BF90E0
		[CompilerGenerated]
		private void _BuildDialog_b__184_1(); // 0x0000000180BF90D0-0x0000000180BF90E0
	}
}
