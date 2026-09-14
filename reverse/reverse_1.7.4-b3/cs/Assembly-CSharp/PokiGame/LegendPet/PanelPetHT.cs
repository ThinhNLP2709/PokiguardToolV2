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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokiGame.LegendPet
{
	public class PanelPetHT : MonoBehaviour // TypeDefIndex: 2593
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
		private LegendStarPanel _view; // 0x1C0
		private bool _loadingResolved; // 0x1C8
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2594
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<string> __9__66_1; // 0x08
			public static Action<string> __9__67_1; // 0x10
			public static Comparison<StarSlotData> __9__83_0; // 0x18
			public static Comparison<StarSlotData> __9__83_1; // 0x20
			public static Comparison<StarSlotData> __9__83_2; // 0x28
			public static Comparison<Transform> __9__86_0; // 0x30
			public static Comparison<StarSlotData> __9__89_0; // 0x38
			public static Comparison<StarSlotData> __9__89_1; // 0x40
			public static Comparison<StarSlotData> __9__89_2; // 0x48
			public static TweenCallback __9__104_0; // 0x50
			public static TweenCallback __9__104_1; // 0x58
			public static Action<LegendPetListResponse> __9__117_0; // 0x60
			public static Action<string> __9__117_1; // 0x68
	
			// Constructors
			static __c(); // 0x0000000180BFB130-0x0000000180BFB1D0
			public __c(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PreloadPetDetail_b__66_1(string error); // 0x000000018028A320-0x000000018028A330
			internal void _PreloadUserPetStats_b__67_1(string error); // 0x000000018028A320-0x000000018028A330
			internal int _InitializeAllStarButtons_b__83_0(StarSlotData a, StarSlotData b); // 0x0000000180BEBCD0-0x0000000180BEBD10
			internal int _InitializeAllStarButtons_b__83_1(StarSlotData a, StarSlotData b); // 0x0000000180BEBCD0-0x0000000180BEBD10
			internal int _InitializeAllStarButtons_b__83_2(StarSlotData a, StarSlotData b); // 0x0000000180BEBCD0-0x0000000180BEBD10
			internal int _MapStarGroup_b__86_0(Transform a, Transform b); // 0x0000000180BFB1D0-0x0000000180BFB2B0
			internal int _InitializeStarButtonsForImage_b__89_0(StarSlotData a, StarSlotData b); // 0x0000000180BEBCD0-0x0000000180BEBD10
			internal int _InitializeStarButtonsForImage_b__89_1(StarSlotData a, StarSlotData b); // 0x0000000180BEBCD0-0x0000000180BEBD10
			internal int _InitializeStarButtonsForImage_b__89_2(StarSlotData a, StarSlotData b); // 0x0000000180BEBCD0-0x0000000180BEBD10
			internal void _ShowPetUnlockPanel_b__104_0(); // 0x000000018028A320-0x000000018028A330
			internal void _ShowPetUnlockPanel_b__104_1(); // 0x000000018028A320-0x000000018028A330
			internal void _TestAPI_b__117_0(LegendPetListResponse response); // 0x0000000180BFB2B0-0x0000000180BFB380
			internal void _TestAPI_b__117_1(string error); // 0x0000000180BFB380-0x0000000180BFB420
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass102_0 // TypeDefIndex: 2595
		{
			// Fields
			public Action onComplete; // 0x10
	
			// Constructors
			public __c__DisplayClass102_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PlayStarInlayAnimation_b__0(); // 0x0000000180335B30-0x0000000180335B50
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass54_0 // TypeDefIndex: 2596
		{
			// Fields
			public int index; // 0x10
			public PanelPetHT __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass54_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Awake_b__2(); // 0x0000000180BFB420-0x0000000180BFB570
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass66_0 // TypeDefIndex: 2597
		{
			// Fields
			public PanelPetHT __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass66_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PreloadPetDetail_b__0(LegendPetData data); // 0x0000000180BFB570-0x0000000180BFB610
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass67_0 // TypeDefIndex: 2598
		{
			// Fields
			public PanelPetHT __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass67_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _PreloadUserPetStats_b__0(PetUserDTO pet); // 0x0000000180BFB610-0x0000000180BFB6A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass74_0 // TypeDefIndex: 2599
		{
			// Fields
			public PanelPetHT __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass74_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _LoadPetDetail_b__0(LegendPetData data); // 0x0000000180BFB6A0-0x0000000180BFB740
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass77_0 // TypeDefIndex: 2600
		{
			// Fields
			public PanelPetHT __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass77_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _LoadAndShowPetStats_b__0(PetUserDTO pet); // 0x0000000180BFB740-0x0000000180BFB8E0
			internal void _LoadAndShowPetStats_b__1(string error); // 0x0000000180BFB8E0-0x0000000180BFB9E0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass86_0 // TypeDefIndex: 2601
		{
			// Fields
			public StarSlotData slotData; // 0x10
			public PanelPetHT __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass86_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _MapStarGroup_b__1(); // 0x0000000180BFB9E0-0x0000000180BFBAB0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass95_0 // TypeDefIndex: 2602
		{
			// Fields
			public PanelPetHT __4__this; // 0x10
			public InlayStarResponse response; // 0x18
			public LegendPetData pet; // 0x20
			public bool isViewing; // 0x28
			public int petIndex; // 0x2C
			public Action __9__0; // 0x30
	
			// Constructors
			public __c__DisplayClass95_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _OnInlaySuccess_b__0(); // 0x0000000180BFBAB0-0x0000000180BFBDA0
		}
	
		// Constructors
		public PanelPetHT(); // 0x0000000180BFAAB0-0x0000000180BFAD90
	
		// Methods
		private void Awake(); // 0x0000000180BEC860-0x0000000180BED2B0
		private void Start(); // 0x0000000180BED2B0-0x0000000180BED2F0
		public void Show(); // 0x0000000180BED2F0-0x0000000180BED4C0
		public void Hide(); // 0x0000000180BED4C0-0x0000000180BED6B0
		private bool OpenRebuiltView(); // 0x0000000180BED6B0-0x0000000180BEDA90
		private void HideLegacyNodes(Transform host); // 0x0000000180BEDA90-0x0000000180BEDF80
		private void OnDisable(); // 0x0000000180BEDF80-0x0000000180BEDFA0
		private long GetCurrentUserId(); // 0x0000000180BEDFA0-0x0000000180BEE050
		private void LoadAllPets(); // 0x0000000180BEE050-0x0000000180BEE3A0
		private void OnLoadAllPetsSuccess(LegendPetListResponse response); // 0x0000000180BEE3A0-0x0000000180BEE780
		private void PreloadOtherPetsData(int skipIndex); // 0x0000000180BEE780-0x0000000180BEE820
		private void PreloadPetDetail(long petId); // 0x0000000180BEE820-0x0000000180BEEAC0
		private void PreloadUserPetStats(long petId); // 0x0000000180BEEAC0-0x0000000180BEED60
		private void OnLoadAllPetsError(string error); // 0x0000000180BEED60-0x0000000180BEEE50
		private void SetupPetButtons(); // 0x0000000180BEEE50-0x0000000180BEF260
		private void UpdatePetButtonVisual(int index, LegendPetBasicInfo pet); // 0x0000000180BEF260-0x0000000180BEF4A0
		private void OnPetButtonClick(int index); // 0x0000000180BEF4A0-0x0000000180BEF5E0
		private void SelectPet(int index); // 0x0000000180BEF5E0-0x0000000180BEF770
		private void UpdatePetButtonHighlight(int selectedIndex); // 0x0000000180BEF770-0x0000000180BEFC30
		private void LoadPetDetail(long petId); // 0x0000000180BEFC30-0x0000000180BEFE30
		private void OnLoadPetDetailSuccess(LegendPetData data); // 0x0000000180BEFE30-0x0000000180BF0370
		private void HideAllPetStatsUI(); // 0x0000000180BF0370-0x0000000180BF0590
		private void LoadAndShowPetStats(long petId); // 0x0000000180BF0590-0x0000000180BF0B90
		private void DisplayPetStats(PetUserDTO pet); // 0x0000000180BF0B90-0x0000000180BF0BA0
		private void ClearAllStarButtons(); // 0x0000000180BF0BA0-0x0000000180BF1270
		private void OnLoadPetDetailError(string error); // 0x0000000180BF1270-0x0000000180BF1340
		private void UpdatePetInfo(); // 0x0000000180BF1340-0x0000000180BF16B0
		private void UpdateStarCount(); // 0x0000000180BF16B0-0x0000000180BF1AA0
		private void InitializeAllStarButtons(); // 0x0000000180BF1AA0-0x0000000180BF2480
		private void ClearStarsInPanel(GameObject panel); // 0x0000000180BF2480-0x0000000180BF2A20
		private Transform FindStarGroupContainer(Transform parent, string groupName); // 0x0000000180BF2A20-0x0000000180BF2CC0
		private int MapStarGroup(Transform container, List<StarSlotData> slotDataList, int starType); // 0x0000000180BF2CC0-0x0000000180BF38F0
		private void UpdateStarVisual(StarSlotData slotData, Image starImage, Button starButton); // 0x0000000180BF38F0-0x0000000180BF3E10
		private void ShowImageHT(int petIndex); // 0x0000000180BF3E10-0x0000000180BF46D0
		private void InitializeStarButtonsForImage(int panelIndex, ImageHTData imageData); // 0x0000000180BF46D0-0x0000000180BF4F10
		private void OnStarClicked(StarSlotData slotData); // 0x0000000180BF4F10-0x0000000180BF4FD0
		private void ShowConfirmPanel(StarSlotData slotData, int currentStarCount); // 0x0000000180BF4FD0-0x0000000180BF5910
		private void HideConfirmPanel(); // 0x0000000180BF5910-0x0000000180BF5B40
		private void OnConfirm(bool confirmed); // 0x0000000180BF5B40-0x0000000180BF5B90
		private void InlayStar(StarSlotData slotData); // 0x0000000180BF5B90-0x0000000180BF5DD0
		private void OnInlaySuccess(InlayStarResponse response); // 0x0000000180BF5DD0-0x0000000180BF66B0
		private void OnPetsReceived(PetUserDTO pet); // 0x0000000180BF66B0-0x0000000180BF6A80
		private void LoadPetSkillCard(int skillCardId, string description); // 0x0000000180BF6A80-0x0000000180BF6FC0
		private void SetTextIfNotNull(UnityEngine.UI.Text textComponent, string value); // 0x0000000180BF6FC0-0x0000000180BF70C0
		private void LoadAttributeImage(Image imageComponent, string attributeName); // 0x0000000180BF70C0-0x0000000180BF72A0
		private void UpdateStarSlotVisual(long slotId, bool inlaid); // 0x0000000180BF72A0-0x0000000180BF76A0
		private void HideStarsAndChangeImageColor(); // 0x0000000180BF76A0-0x0000000180BF7BA0
		private void PlayStarInlayAnimation(long slotId, Action onComplete); // 0x0000000180BF7BA0-0x0000000180BF7FF0
		private void OnInlayError(string error); // 0x0000000180BF7FF0-0x0000000180BF80C0
		private void ShowPetUnlockPanel(); // 0x0000000180BF80C0-0x0000000180BF86B0
		private void ShowLoading(bool show); // 0x0000000180BF86B0-0x0000000180BF8CE0
		private void ShowErrorMessage(string message); // 0x0000000180BF8CE0-0x0000000180BF8DA0
		private void OnDestroy(); // 0x0000000180BF8DA0-0x0000000180BF9620
		private void OnStarCountChangedHandler(int white, int blue, int red); // 0x0000000180BF9620-0x0000000180BF9AA0
		private void RecomputeCanInlay(ImageHTData imageData); // 0x0000000180BF9AA0-0x0000000180BF9CA0
		private void UpdateAllStarButtonStates(); // 0x0000000180BF9CA0-0x0000000180BFA0F0
		public void RefreshData(); // 0x0000000180BFA0F0-0x0000000180BFA230
		public void SelectPetById(long petId); // 0x0000000180BFA230-0x0000000180BFA2B0
		[ContextMenu("Test - Show Panel")]
		private void ContextMenu_ShowPanel(); // 0x0000000180BFA2B0-0x0000000180BFA2C0
		[ContextMenu("Test - Call API")]
		private void ContextMenu_TestAPI(); // 0x0000000180BFA2C0-0x0000000180BFA2D0
		[ContextMenu("Test - Load Fake Data")]
		private void ContextMenu_TestFakeData(); // 0x0000000180BFA2D0-0x0000000180BFA2E0
		public void TestAPI(); // 0x0000000180BFA2E0-0x0000000180BFA720
		public void TestWithFakeData(); // 0x0000000180BFA720-0x0000000180BFAAB0
		[CompilerGenerated]
		private void _Awake_b__54_0(); // 0x0000000180BFAD90-0x0000000180BFADD0
		[CompilerGenerated]
		private void _Awake_b__54_1(); // 0x0000000180BFADD0-0x0000000180BFADE0
		[CompilerGenerated]
		private void _OpenRebuiltView_b__59_0(); // 0x0000000180BFADE0-0x0000000180BFAF20
		[CompilerGenerated]
		private void _HideConfirmPanel_b__92_0(); // 0x0000000180BFAF20-0x0000000180BFAFA0
		[CompilerGenerated]
		private void _ShowPetUnlockPanel_b__104_2(); // 0x0000000180BFAFA0-0x0000000180BFB0B0
		[CompilerGenerated]
		private void _ShowPetUnlockPanel_b__104_3(); // 0x0000000180BFB0B0-0x0000000180BFB130
	}
}
