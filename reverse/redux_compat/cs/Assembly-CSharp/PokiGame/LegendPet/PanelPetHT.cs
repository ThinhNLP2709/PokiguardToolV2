/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokiGame.LegendPet
{
	public class PanelPetHT : MonoBehaviour // TypeDefIndex: 1992
	{
		// Fields
		[Header("UI References")]
		[SerializeField]
		private GameObject panelObject; // 0x20
		[SerializeField]
		private UnityEngine.UI.Text petNameText; // 0x28
		[SerializeField]
		private UnityEngine.UI.Text progressText; // 0x30
		[SerializeField]
		private Image progressBar; // 0x38
		[SerializeField]
		private Button closeButton; // 0x40
		[Header("Pet Selection Buttons")]
		[SerializeField]
		private Button[] btnHTs; // 0x48
		[SerializeField]
		private UnityEngine.UI.Text[] btnHtTexts; // 0x50
		[SerializeField]
		private Image[] btnHtIcons; // 0x58
		[Header("Image Panels - C\u00E1c ImageHT1, ImageHT2, ...")]
		[SerializeField]
		private GameObject[] imagePanels; // 0x60
		[Header("Star Info Display")]
		[SerializeField]
		private UnityEngine.UI.Text starWhiteText; // 0x68
		[SerializeField]
		private UnityEngine.UI.Text starBlueText; // 0x70
		[SerializeField]
		private UnityEngine.UI.Text starRedText; // 0x78
		[Header("Confirm Panel")]
		[SerializeField]
		private GameObject confirmPanelObject; // 0x80
		[SerializeField]
		private Image confirmIcon; // 0x88
		[SerializeField]
		private UnityEngine.UI.Text confirmMessageTxt; // 0x90
		[SerializeField]
		private Button confirmBtnOK; // 0x98
		[SerializeField]
		private Button confirmBtnCancel; // 0xA0
		[SerializeField]
		private Sprite starWhiteIcon; // 0xA8
		[SerializeField]
		private Sprite starBlueIcon; // 0xB0
		[SerializeField]
		private Sprite starRedIcon; // 0xB8
		[SerializeField]
		private CanvasGroup confirmCanvasGroup; // 0xC0
		[Header("Other Panels")]
		[SerializeField]
		private GameObject loadingPanel; // 0xC8
		[SerializeField]
		private GameObject petUnlockPanel; // 0xD0
		[SerializeField]
		private GameObject PanelPetMain; // 0xD8
		[Header("Debug")]
		[SerializeField]
		private Button btnTestAPI; // 0xE0
		[SerializeField]
		private bool autoShowOnStart; // 0xE8
		public GameObject PanelCardPet; // 0xF0
		public Image imgCard; // 0xF8
		public UnityEngine.UI.Text txtDescription; // 0x100
		public UnityEngine.UI.Text namePet; // 0x108
		public UnityEngine.UI.Text txtHp; // 0x110
		public UnityEngine.UI.Text txtMana; // 0x118
		public UnityEngine.UI.Text txtDame; // 0x120
		public UnityEngine.UI.Text txtWee; // 0x128
		public UnityEngine.UI.Text txtLv; // 0x130
		public UnityEngine.UI.Text des; // 0x138
		public Image imgAtribute; // 0x140
		public Image imgAtributeOther; // 0x148
		private LegendPetBasicInfo[] allPets; // 0x150
		private LegendPetData currentPetData; // 0x158
		private long userId; // 0x160
		private int currentPetIndex; // 0x168
		private int currentImageIndex; // 0x16C
		private InlayStarRequest lastInlayRequest; // 0x170
		private Dictionary<long, Button> starButtonDict; // 0x178
		private Dictionary<long, Image> starImageDict; // 0x180
		private StarSlotData currentConfirmSlotData; // 0x188
		private LegendPetData confirmPetData; // 0x190
		private int confirmPetIndex; // 0x198
		private Dictionary<long, PetUserDTO> userPetsCache; // 0x1A0
		private Dictionary<long, LegendPetData> petDetailCache; // 0x1A8
		private PetUserDTO currentUserPetData; // 0x1B0
		private bool isLoadingUserPet; // 0x1B8
		private bool _shownOnce; // 0x1B9
		private bool _loadingResolved; // 0x1BA
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 1993
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<string> __9__63_1; // 0x08
			public static Action<string> __9__64_1; // 0x10
			public static Comparison<StarSlotData> __9__80_0; // 0x18
			public static Comparison<StarSlotData> __9__80_1; // 0x20
			public static Comparison<StarSlotData> __9__80_2; // 0x28
			public static Comparison<Transform> __9__83_0; // 0x30
			public static Comparison<StarSlotData> __9__86_0; // 0x38
			public static Comparison<StarSlotData> __9__86_1; // 0x40
			public static Comparison<StarSlotData> __9__86_2; // 0x48
			public static TweenCallback __9__101_0; // 0x50
			public static TweenCallback __9__101_1; // 0x58
			public static Action<LegendPetListResponse> __9__114_0; // 0x60
			public static Action<string> __9__114_1; // 0x68
	
			// Constructors
			static __c(); // 0x000000018067B970-0x000000018067B9E0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _PreloadPetDetail_b__63_1(string error); // 0x00000001802E76C0-0x00000001802E76D0
			internal void _PreloadUserPetStats_b__64_1(string error); // 0x00000001802E76C0-0x00000001802E76D0
			internal int _InitializeAllStarButtons_b__80_0(StarSlotData a, StarSlotData b); // 0x00000001806778F0-0x0000000180677920
			internal int _InitializeAllStarButtons_b__80_1(StarSlotData a, StarSlotData b); // 0x00000001806778F0-0x0000000180677920
			internal int _InitializeAllStarButtons_b__80_2(StarSlotData a, StarSlotData b); // 0x00000001806778F0-0x0000000180677920
			internal int _MapStarGroup_b__83_0(Transform a, Transform b); // 0x0000000180677920-0x0000000180677980
			internal int _InitializeStarButtonsForImage_b__86_0(StarSlotData a, StarSlotData b); // 0x00000001806778F0-0x0000000180677920
			internal int _InitializeStarButtonsForImage_b__86_1(StarSlotData a, StarSlotData b); // 0x00000001806778F0-0x0000000180677920
			internal int _InitializeStarButtonsForImage_b__86_2(StarSlotData a, StarSlotData b); // 0x00000001806778F0-0x0000000180677920
			internal void _ShowPetUnlockPanel_b__101_0(); // 0x00000001802E76C0-0x00000001802E76D0
			internal void _ShowPetUnlockPanel_b__101_1(); // 0x00000001802E76C0-0x00000001802E76D0
			internal void _TestAPI_b__114_0(LegendPetListResponse response); // 0x0000000180677B40-0x0000000180677C00
			internal void _TestAPI_b__114_1(string error); // 0x0000000180677C00-0x0000000180677C90
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass54_0 // TypeDefIndex: 1994
		{
			// Fields
			public int index; // 0x10
			public PanelPetHT __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass54_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Awake_b__2(); // 0x000000018067B080-0x000000018067B0B0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass63_0 // TypeDefIndex: 1995
		{
			// Fields
			public PanelPetHT __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass63_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _PreloadPetDetail_b__0(LegendPetData data); // 0x000000018067B0B0-0x000000018067B140
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass64_0 // TypeDefIndex: 1996
		{
			// Fields
			public PanelPetHT __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass64_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _PreloadUserPetStats_b__0(PetUserDTO pet); // 0x000000018067B140-0x000000018067B1B0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass71_0 // TypeDefIndex: 1997
		{
			// Fields
			public PanelPetHT __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass71_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _LoadPetDetail_b__0(LegendPetData data); // 0x000000018067B1B0-0x000000018067B230
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass74_0 // TypeDefIndex: 1998
		{
			// Fields
			public PanelPetHT __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass74_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _LoadAndShowPetStats_b__0(PetUserDTO pet); // 0x000000018067B230-0x000000018067B350
			internal void _LoadAndShowPetStats_b__1(string error); // 0x000000018067B350-0x000000018067B440
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass83_0 // TypeDefIndex: 1999
		{
			// Fields
			public StarSlotData slotData; // 0x10
			public PanelPetHT __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass83_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _MapStarGroup_b__1(); // 0x000000018067B440-0x000000018067B470
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass92_0 // TypeDefIndex: 2000
		{
			// Fields
			public PanelPetHT __4__this; // 0x10
			public InlayStarResponse response; // 0x18
			public LegendPetData pet; // 0x20
			public bool isViewing; // 0x28
			public int petIndex; // 0x2C
			public Action __9__0; // 0x30
	
			// Constructors
			public __c__DisplayClass92_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _OnInlaySuccess_b__0(); // 0x000000018067B620-0x000000018067B900
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass99_0 // TypeDefIndex: 2001
		{
			// Fields
			public Action onComplete; // 0x10
	
			// Constructors
			public __c__DisplayClass99_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _PlayStarInlayAnimation_b__0(); // 0x00000001803A72E0-0x00000001803A7300
		}
	
		// Constructors
		public PanelPetHT(); // 0x0000000180662400-0x0000000180662570
	
		// Methods
		private void Awake(); // 0x0000000180658C60-0x0000000180659140
		private void Start(); // 0x0000000180660780-0x00000001806607C0
		public void Show(); // 0x00000001806606A0-0x0000000180660780
		public void Hide(); // 0x000000018065A260-0x000000018065A2E0
		private void OnDisable(); // 0x000000018065D200-0x000000018065D220
		private long GetCurrentUserId(); // 0x0000000180659AA0-0x0000000180659B30
		private void LoadAllPets(); // 0x000000018065B4B0-0x000000018065B730
		private void OnLoadAllPetsSuccess(LegendPetListResponse response); // 0x000000018065D9B0-0x000000018065DCF0
		private void PreloadOtherPetsData(int skipIndex); // 0x000000018065EA10-0x000000018065EAB0
		private void PreloadPetDetail(long petId); // 0x000000018065EAB0-0x000000018065EC90
		private void PreloadUserPetStats(long petId); // 0x000000018065EC90-0x000000018065EE70
		private void OnLoadAllPetsError(string error); // 0x000000018065D8E0-0x000000018065D9B0
		private void SetupPetButtons(); // 0x000000018065F2E0-0x000000018065F5A0
		private void UpdatePetButtonVisual(int index, LegendPetBasicInfo pet); // 0x0000000180661980-0x0000000180661AD0
		private void OnPetButtonClick(int index); // 0x000000018065E030-0x000000018065E130
		private void SelectPet(int index); // 0x000000018065F110-0x000000018065F250
		private void UpdatePetButtonHighlight(int selectedIndex); // 0x00000001806615A0-0x0000000180661980
		private void LoadPetDetail(long petId); // 0x000000018065BE70-0x000000018065C400
		private void OnLoadPetDetailSuccess(LegendPetData data); // 0x000000018065DDB0-0x000000018065E030
		private void HideAllPetStatsUI(); // 0x0000000180659B30-0x0000000180659EF0
		private void LoadAndShowPetStats(long petId); // 0x000000018065B730-0x000000018065BD90
		private void DisplayPetStats(PetUserDTO pet); // 0x0000000180659920-0x0000000180659930
		private void ClearAllStarButtons(); // 0x0000000180659140-0x0000000180659640
		private void OnLoadPetDetailError(string error); // 0x000000018065DCF0-0x000000018065DDB0
		private void UpdatePetInfo(); // 0x0000000180661AD0-0x0000000180661CA0
		private void UpdateStarCount(); // 0x0000000180661CA0-0x0000000180661E30
		private void InitializeAllStarButtons(); // 0x000000018065A2E0-0x000000018065ABF0
		private void ClearStarsInPanel(GameObject panel); // 0x0000000180659640-0x00000001806598F0
		private Transform FindStarGroupContainer(Transform parent, string groupName); // 0x0000000180659930-0x0000000180659AA0
		private int MapStarGroup(Transform container, List<StarSlotData> slotDataList, int starType); // 0x000000018065C5E0-0x000000018065CB40
		private void UpdateStarVisual(StarSlotData slotData, Image starImage, Button starButton); // 0x00000001806620A0-0x0000000180662400
		private void ShowImageHT(int petIndex); // 0x000000018065FAE0-0x00000001806601B0
		private void InitializeStarButtonsForImage(int panelIndex, ImageHTData imageData); // 0x000000018065ABF0-0x000000018065B2D0
		private void OnStarClicked(StarSlotData slotData); // 0x000000018065E600-0x000000018065E6B0
		private void ShowConfirmPanel(StarSlotData slotData, int currentStarCount); // 0x000000018065F5A0-0x000000018065FA30
		private void HideConfirmPanel(); // 0x0000000180659EF0-0x0000000180659FF0
		private void OnConfirm(bool confirmed); // 0x000000018065CB40-0x000000018065CDF0
		private void InlayStar(StarSlotData slotData); // 0x000000018065B2D0-0x000000018065B4B0
		private void OnInlaySuccess(InlayStarResponse response); // 0x000000018065D2E0-0x000000018065D8E0
		private void OnPetsReceived(PetUserDTO pet); // 0x000000018065E130-0x000000018065E600
		private void LoadPetSkillCard(int skillCardId, string description); // 0x000000018065C400-0x000000018065C5E0
		private void SetTextIfNotNull(UnityEngine.UI.Text textComponent, string value); // 0x000000018065F250-0x000000018065F2E0
		private void LoadAttributeImage(Image imageComponent, string attributeName); // 0x000000018065BD90-0x000000018065BE70
		private void UpdateStarSlotVisual(long slotId, bool inlaid); // 0x0000000180661E30-0x00000001806620A0
		private void HideStarsAndChangeImageColor(); // 0x0000000180659FF0-0x000000018065A260
		private void PlayStarInlayAnimation(long slotId, Action onComplete); // 0x000000018065E820-0x000000018065EA10
		private void OnInlayError(string error); // 0x000000018065D220-0x000000018065D2E0
		private void ShowPetUnlockPanel(); // 0x00000001806603A0-0x00000001806606A0
		private void ShowLoading(bool show); // 0x00000001806601B0-0x00000001806603A0
		private void ShowErrorMessage(string message); // 0x000000018065FA30-0x000000018065FAE0
		private void OnDestroy(); // 0x000000018065CDF0-0x000000018065D200
		private void OnStarCountChangedHandler(int white, int blue, int red); // 0x000000018065E6B0-0x000000018065E820
		private void RecomputeCanInlay(ImageHTData imageData); // 0x000000018065EE70-0x000000018065F020
		private void UpdateAllStarButtonStates(); // 0x0000000180660E90-0x00000001806615A0
		public void RefreshData(); // 0x000000018065F020-0x000000018065F090
		public void SelectPetById(long petId); // 0x000000018065F090-0x000000018065F110
		[ContextMenu("Test - Show Panel")]
		private void ContextMenu_ShowPanel(); // 0x00000001806598F0-0x0000000180659900
		[ContextMenu("Test - Call API")]
		private void ContextMenu_TestAPI(); // 0x0000000180659900-0x0000000180659910
		[ContextMenu("Test - Load Fake Data")]
		private void ContextMenu_TestFakeData(); // 0x0000000180659910-0x0000000180659920
		public void TestAPI(); // 0x00000001806607C0-0x0000000180660AC0
		public void TestWithFakeData(); // 0x0000000180660AC0-0x0000000180660D60
		[CompilerGenerated]
		private void _Awake_b__54_0(); // 0x0000000180660D60-0x0000000180660D70
		[CompilerGenerated]
		private void _Awake_b__54_1(); // 0x0000000180660D70-0x0000000180660D80
		[CompilerGenerated]
		private void _HideConfirmPanel_b__89_0(); // 0x0000000180660D80-0x0000000180660DB0
		[CompilerGenerated]
		private void _ShowPetUnlockPanel_b__101_2(); // 0x0000000180660DB0-0x0000000180660E60
		[CompilerGenerated]
		private void _ShowPetUnlockPanel_b__101_3(); // 0x0000000180660E60-0x0000000180660E90
	}
}
