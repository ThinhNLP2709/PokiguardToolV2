/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokiGame.LegendPet
{
	[DisallowMultipleComponent]
	public class LegendStarPanel : MonoBehaviour // TypeDefIndex: 2580
	{
		// Fields
		public const string NODE_NAME = "[LegendStarPanel]"; // Metadata: 0x005F0FF1
		private const float FRAME_W = 1774f; // Metadata: 0x005F1003
		private const float FRAME_H = 887f; // Metadata: 0x005F1007
		private const float DIM_OVERSCAN = 600f; // Metadata: 0x005F100B
		private const float TITLE_Y = 26f; // Metadata: 0x005F100F
		private const float TITLE_H = 60f; // Metadata: 0x005F1013
		private const float TITLE_FS = 44f; // Metadata: 0x005F1017
		private const float CLOSE_X = 1673f; // Metadata: 0x005F101B
		private const float CLOSE_Y = 12f; // Metadata: 0x005F101F
		private const float CLOSE_W = 81f; // Metadata: 0x005F1023
		private const float CLOSE_H = 84f; // Metadata: 0x005F1027
		private const float CARD_Y = 118f; // Metadata: 0x005F102B
		private const float CARD_H = 720f; // Metadata: 0x005F102F
		private const float L_X = 44f; // Metadata: 0x005F1033
		private const float L_W = 330f; // Metadata: 0x005F1037
		private const float C_X = 400f; // Metadata: 0x005F103B
		private const float C_W = 900f; // Metadata: 0x005F103F
		private const float R_X = 1326f; // Metadata: 0x005F1043
		private const float R_W = 404f; // Metadata: 0x005F1047
		private const float SEC_H = 34f; // Metadata: 0x005F104B
		private const float SEC_FS = 24f; // Metadata: 0x005F104F
		private const float L_SEC_X = 20f; // Metadata: 0x005F1053
		private const float L_SEC_Y = 14f; // Metadata: 0x005F1057
		private const float L_DIV_Y = 52f; // Metadata: 0x005F105B
		private const float L_DIV_W = 290f; // Metadata: 0x005F105F
		private const float L_VP_X = 16f; // Metadata: 0x005F1063
		private const float L_VP_Y = 64f; // Metadata: 0x005F1067
		private const float L_VP_W = 298f; // Metadata: 0x005F106B
		private const float L_VP_H = 642f; // Metadata: 0x005F106F
		private const float ROW_W = 290f; // Metadata: 0x005F1073
		private const float ROW_H = 104f; // Metadata: 0x005F1077
		private const float ROW_GAP = 8f; // Metadata: 0x005F107B
		private const float RW_ICON_X = 10f; // Metadata: 0x005F107F
		private const float RW_ICON_Y = 10f; // Metadata: 0x005F1083
		private const float RW_ICON_D = 84f; // Metadata: 0x005F1087
		private const float RW_TXT_X = 104f; // Metadata: 0x005F108B
		private const float RW_NAME_Y = 10f; // Metadata: 0x005F108F
		private const float RW_TXT_W = 174f; // Metadata: 0x005F1093
		private const float RW_NAME_H = 34f; // Metadata: 0x005F1097
		private const float RW_TRACK_Y = 52f; // Metadata: 0x005F109B
		private const float RW_TRACK_H = 14f; // Metadata: 0x005F109F
		private const float RW_SUB_Y = 70f; // Metadata: 0x005F10A3
		private const float RW_SUB_W = 88f; // Metadata: 0x005F10A7
		private const float RW_SUB_H = 26f; // Metadata: 0x005F10AB
		private const float RW_TAG_X = 104f; // Metadata: 0x005F10AF
		private const float RW_TAG_W = 132f; // Metadata: 0x005F10B3
		private const float RW_TAG_H = 30f; // Metadata: 0x005F10B7
		private const int MAX_ROWS = 40; // Metadata: 0x005F10BB
		private const float C_NAME_Y = 10f; // Metadata: 0x005F10BC
		private const float C_NAME_H = 46f; // Metadata: 0x005F10C0
		private const float C_NAME_FS = 32f; // Metadata: 0x005F10C4
		private const float STAGE_X = 170f; // Metadata: 0x005F10C8
		private const float STAGE_Y = 64f; // Metadata: 0x005F10CC
		private const float STAGE_W = 560f; // Metadata: 0x005F10D0
		private const float STAGE_H = 566f; // Metadata: 0x005F10D4
		private const float C_DIV_X = 60f; // Metadata: 0x005F10D8
		private const float C_DIV_Y = 644f; // Metadata: 0x005F10DC
		private const float C_DIV_W = 780f; // Metadata: 0x005F10E0
		private const float C_LBL_Y = 652f; // Metadata: 0x005F10E4
		private const float C_LBL_H = 32f; // Metadata: 0x005F10E8
		private const float C_LBL_FS = 22f; // Metadata: 0x005F10EC
		private const float C_BAR_Y = 690f; // Metadata: 0x005F10F0
		private const float C_BAR_H = 22f; // Metadata: 0x005F10F4
		private const float GEM_RATIO = 0.08158191f; // Metadata: 0x005F10F8
		private const int MAX_GEMS = 120; // Metadata: 0x005F10FC
		private const float R_PAD = 24f; // Metadata: 0x005F10FE
		private const float R_INNER = 356f; // Metadata: 0x005F1102
		private const float R_SEC1_Y = 14f; // Metadata: 0x005F1106
		private const float R_DIV1_Y = 52f; // Metadata: 0x005F110A
		private const float R_WALLET_Y = 62f; // Metadata: 0x005F110E
		private const float R_WALLET_H = 54f; // Metadata: 0x005F1112
		private const float R_WALLET_STEP = 60f; // Metadata: 0x005F1116
		private const float R_DIV2_Y = 246f; // Metadata: 0x005F111A
		private const float R_SEC2_Y = 256f; // Metadata: 0x005F111E
		private const float R_BLOCK_Y = 300f; // Metadata: 0x005F1122
		private const float R_NEED_H = 44f; // Metadata: 0x005F1126
		private const float R_NEED_STEP = 48f; // Metadata: 0x005F112A
		private const float R_HINT_Y = 456f; // Metadata: 0x005F112E
		private const float R_HINT_H = 240f; // Metadata: 0x005F1132
		private const float R_STAT_H = 58f; // Metadata: 0x005F1136
		private const float R_STAT_STEP = 66f; // Metadata: 0x005F113A
		private const float R_ELEM_Y = 500f; // Metadata: 0x005F113E
		private const float R_ELEM_H = 52f; // Metadata: 0x005F1142
		private const float R_DESC_Y = 562f; // Metadata: 0x005F1146
		private const float R_DESC_H = 138f; // Metadata: 0x005F114A
		private const float CARD_W = 96f; // Metadata: 0x005F114E
		private const float DLG_W = 700f; // Metadata: 0x005F1152
		private const float DLG_H = 430f; // Metadata: 0x005F1156
		private const float DLG_ICON_D = 96f; // Metadata: 0x005F115A
		private const float DLG_BTN_Y = 336f; // Metadata: 0x005F115E
		private const float DLG_BTN_W = 220f; // Metadata: 0x005F1162
		private const float DLG_BTN_H = 66f; // Metadata: 0x005F1166
		private const string GEM_ATLAS = "Image/stone/ngoc (3)"; // Metadata: 0x005F116A
		private static readonly string[] GEM_SPRITE; // 0x00
		private const string PET_ICON_DIR = "Image/IconsPet/"; // Metadata: 0x005F117F
		private const string ELEMENT_DIR = "Image/Attribute/"; // Metadata: 0x005F118F
		private const string CARD_DIR = "Image/Card/HT"; // Metadata: 0x005F11A0
		private const string ART_ATK = "icon_atk"; // Metadata: 0x005F11AE
		private const string ART_HP = "icon_hp"; // Metadata: 0x005F11B7
		private const string ART_MANA = "icon_mana"; // Metadata: 0x005F11BF
		private static readonly Color[] STAR_TINT; // 0x08
		private static readonly string[] STAR_NAME; // 0x10
		private static readonly Color GEM_LOCKED; // 0x18
		private const float GEM_DONE_ALPHA = 0.55f; // Metadata: 0x005F11C9
		private const float GEM_DONE_SCALE = 0.78f; // Metadata: 0x005F11CD
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
		public bool IsOpen { get; } // 0x0000000180BD9AE0-0x0000000180BD9C40 
		private static LegendPetAPIService Api { get; } // 0x0000000180BE1FF0-0x0000000180BE2080 
	
		// Nested types
		private class PetRow // TypeDefIndex: 2581
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
	
		private class GemCell // TypeDefIndex: 2582
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
		private sealed class __c // TypeDefIndex: 2583
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<string> __9__192_1; // 0x08
			public static Action<string> __9__193_1; // 0x10
			public static Comparison<StarSlotData> __9__201_0; // 0x18
	
			// Constructors
			static __c(); // 0x0000000180BEBC30-0x0000000180BEBCD0
			public __c(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PreloadDetail_b__192_1(string err); // 0x000000018028A320-0x000000018028A330
			internal void _PreloadStats_b__193_1(string err); // 0x000000018028A320-0x000000018028A330
			internal int _BuildGems_b__201_0(StarSlotData a, StarSlotData b); // 0x0000000180BEBCD0-0x0000000180BEBD10
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass186_0 // TypeDefIndex: 2584
		{
			// Fields
			public LegendStarPanel __4__this; // 0x10
			public Transform host; // 0x18
	
			// Constructors
			public __c__DisplayClass186_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _HideDialog_b__0(); // 0x0000000180BEBD10-0x0000000180BEBF00
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass192_0 // TypeDefIndex: 2585
		{
			// Fields
			public LegendStarPanel __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass192_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PreloadDetail_b__0(LegendPetData data); // 0x0000000180BEBF00-0x0000000180BEBFA0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass193_0 // TypeDefIndex: 2586
		{
			// Fields
			public LegendStarPanel __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass193_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PreloadStats_b__0(PetUserDTO pet); // 0x0000000180BEBFA0-0x0000000180BEC030
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass194_0 // TypeDefIndex: 2587
		{
			// Fields
			public LegendStarPanel __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass194_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _SelectPet_b__0(LegendPetData data); // 0x0000000180BEC030-0x0000000180BEC210
			internal void _SelectPet_b__1(string err); // 0x0000000180BEC210-0x0000000180BEC320
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass198_0 // TypeDefIndex: 2588
		{
			// Fields
			public LegendStarPanel __4__this; // 0x10
			public int captured; // 0x18
	
			// Constructors
			public __c__DisplayClass198_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BindRow_b__0(); // 0x0000000180BEC320-0x0000000180BEC3A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass205_0 // TypeDefIndex: 2589
		{
			// Fields
			public LegendStarPanel __4__this; // 0x10
			public StarSlotData shown; // 0x18
	
			// Constructors
			public __c__DisplayClass205_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BindGem_b__0(); // 0x0000000180BEC3A0-0x0000000180BEC430
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass205_1 // TypeDefIndex: 2590
		{
			// Fields
			public StarSlotData captured; // 0x10
			public __c__DisplayClass205_0 CS___8__locals1; // 0x18
	
			// Constructors
			public __c__DisplayClass205_1(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BindGem_b__1(); // 0x0000000180BEC430-0x0000000180BEC4D0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass209_0 // TypeDefIndex: 2591
		{
			// Fields
			public LegendStarPanel __4__this; // 0x10
			public long want; // 0x18
	
			// Constructors
			public __c__DisplayClass209_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PaintSide_b__0(PetUserDTO pet); // 0x0000000180BEC4D0-0x0000000180BEC690
			internal void _PaintSide_b__1(string err); // 0x0000000180BEC690-0x0000000180BEC750
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass222_0 // TypeDefIndex: 2592
		{
			// Fields
			public GemCell cell; // 0x10
			public LegendStarPanel __4__this; // 0x18
			public float rest; // 0x20
	
			// Constructors
			public __c__DisplayClass222_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PlayInlayFx_b__0(); // 0x0000000180BEC750-0x0000000180BEC860
		}
	
		// Constructors
		public LegendStarPanel(); // 0x0000000180BEB1D0-0x0000000180BEB660
		static LegendStarPanel(); // 0x0000000180BEB660-0x0000000180BEBA20
	
		// Methods
		public static LegendStarPanel Mount(Transform host); // 0x0000000180BD94C0-0x0000000180BD9AE0
		public void Show(); // 0x0000000180BD9C40-0x0000000180BD9FE0
		public void Hide(); // 0x0000000180BD9FE0-0x0000000180BDA280
		public void HideImmediate(); // 0x0000000180BDA280-0x0000000180BDA570
		private void ReleasePet(); // 0x0000000180BDA570-0x0000000180BDA6E0
		private void OnEnable(); // 0x0000000180BDA6E0-0x0000000180BDA860
		private void OnDisable(); // 0x0000000180BDA860-0x0000000180BDABA0
		private void Build(); // 0x0000000180BDABA0-0x0000000180BDB750
		private static void EnsureRaycaster(Transform node); // 0x0000000180BDB750-0x0000000180BDBA20
		private void RequestClose(); // 0x0000000180BDBA20-0x0000000180BDBC70
		private void SetLocked(bool on); // 0x0000000180BDBC70-0x0000000180BDBE60
		private void BuildPetList(RectTransform root); // 0x0000000180BDBE60-0x0000000180BDC8E0
		private PetRow EnsureRow(int index); // 0x0000000180BDC8E0-0x0000000180BDCC20
		private PetRow NewRow(); // 0x0000000180BDCC20-0x0000000180BDD690
		private void BuildStageCard(RectTransform root); // 0x0000000180BDD690-0x0000000180BDE1F0
		private void BuildSideCard(RectTransform root); // 0x0000000180BDE1F0-0x0000000180BE01D0
		private UnityEngine.UI.Text StatChip(RectTransform parent, string name, float y, string label, string icon, Color color); // 0x0000000180BE01D0-0x0000000180BE0490
		private Image NewElementIcon(RectTransform parent, string name, float x); // 0x0000000180BE0490-0x0000000180BE05F0
		private void BuildDialog(RectTransform root); // 0x0000000180BE05F0-0x0000000180BE1120
		private void ShowDialog(StarSlotData slot); // 0x0000000180BE1120-0x0000000180BE1B50
		private void HideDialog(bool immediate); // 0x0000000180BE1B50-0x0000000180BE1FF0
		private void LoadPets(); // 0x0000000180BE2080-0x0000000180BE22C0
		private void OnPetsLoaded(LegendPetListResponse resp); // 0x0000000180BE22C0-0x0000000180BE2540
		private void OnPetsError(string error); // 0x0000000180BE2540-0x0000000180BE2730
		private void PreloadDetail(long petId); // 0x0000000180BE2730-0x0000000180BE2A60
		private void PreloadStats(long petId); // 0x0000000180BE2A60-0x0000000180BE2D90
		private void SelectPet(int index); // 0x0000000180BE2D90-0x0000000180BE3D80
		private void OnDetailLoaded(LegendPetData data); // 0x0000000180BE3D80-0x0000000180BE3F20
		private void SetListMessage(string message); // 0x0000000180BE3F20-0x0000000180BE40D0
		private void PaintList(); // 0x0000000180BE40D0-0x0000000180BE4410
		private void BindRow(PetRow row, LegendPetBasicInfo pet, int index); // 0x0000000180BE4410-0x0000000180BE4A00
		private void PaintListSelection(); // 0x0000000180BE4A00-0x0000000180BE4D50
		private void PaintStage(LegendPetData data); // 0x0000000180BE4D50-0x0000000180BE54B0
		private void BuildGems(LegendPetData data, float stageW, float stageH); // 0x0000000180BE54B0-0x0000000180BE5A70
		private static List<StarSlotData> MergeSlots(LegendPetData data); // 0x0000000180BE5A70-0x0000000180BE5C70
		private GemCell EnsureGem(int index); // 0x0000000180BE5C70-0x0000000180BE5F50
		private GemCell NewGem(); // 0x0000000180BE5F50-0x0000000180BE61B0
		private void BindGem(GemCell cell); // 0x0000000180BE61B0-0x0000000180BE6B20
		private void Twinkle(GemCell cell, float rest); // 0x0000000180BE6B20-0x0000000180BE6D30
		private void CancelGemTweens(); // 0x0000000180BE6D30-0x0000000180BE6FB0
		private void PaintProgress(LegendPetData data); // 0x0000000180BE6FB0-0x0000000180BE73F0
		private void PaintSide(LegendPetData data); // 0x0000000180BE73F0-0x0000000180BE7880
		private void PaintNeed(LegendPetData data); // 0x0000000180BE7880-0x0000000180BE7EB0
		private void PaintStats(LegendPetData data, PetUserDTO pet); // 0x0000000180BE7EB0-0x0000000180BE85F0
		private static void ApplyElement(Image img, string element); // 0x0000000180BE85F0-0x0000000180BE8830
		private static int WalletOf(int starType); // 0x0000000180BE8830-0x0000000180BE88E0
		private void PaintWallet(); // 0x0000000180BE88E0-0x0000000180BE8A60
		private void OnWalletChanged(int white, int blue, int red); // 0x0000000180BE8A60-0x0000000180BE8CB0
		private static void RecomputeCanInlay(LegendPetData data); // 0x0000000180BE8CB0-0x0000000180BE8E30
		private void OnGemTapped(StarSlotData slot); // 0x0000000180BE8E30-0x0000000180BE8E50
		private void OnConfirmInlay(); // 0x0000000180BE8E50-0x0000000180BE9210
		private void OnInlayDone(InlayStarResponse resp); // 0x0000000180BE9210-0x0000000180BE99A0
		private void OnInlayFailed(string error); // 0x0000000180BE99A0-0x0000000180BE9A90
		private void RefreshGemsAfterInlay(); // 0x0000000180BE9A90-0x0000000180BE9C50
		private void PlayInlayFx(StarSlotData slot); // 0x0000000180BE9C50-0x0000000180BEA3F0
		private void CelebrateUnlock(LegendPetData pet); // 0x0000000180BEA3F0-0x0000000180BEAAC0
		private GemCell FindGem(StarSlotData slot); // 0x0000000180BEAAC0-0x0000000180BEACA0
		private static string PetName(LegendPetData data); // 0x0000000180BEACA0-0x0000000180BEAD30
		private static Sprite GemSprite(int starType); // 0x0000000180BEAD30-0x0000000180BEB1D0
		[CompilerGenerated]
		private void _Hide_b__168_0(); // 0x0000000180BEBA20-0x0000000180BEBC20
		[CompilerGenerated]
		private void _BuildDialog_b__184_0(); // 0x0000000180BEBC20-0x0000000180BEBC30
		[CompilerGenerated]
		private void _BuildDialog_b__184_1(); // 0x0000000180BEBC20-0x0000000180BEBC30
	}
}
