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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokiGame.LegendPet
{
	public class PanelPetHT : MonoBehaviour // TypeDefIndex: 2159
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
		private sealed class __c // TypeDefIndex: 2160
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
			static __c(); // 0x000000018077DB80-0x000000018077DBF0
			public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _PreloadPetDetail_b__63_1(string error); // 0x00000001802EB6C0-0x00000001802EB6D0
			internal void _PreloadUserPetStats_b__64_1(string error); // 0x00000001802EB6C0-0x00000001802EB6D0
			internal int _InitializeAllStarButtons_b__80_0(StarSlotData a, StarSlotData b); // 0x000000018077CE50-0x000000018077CE80
			internal int _InitializeAllStarButtons_b__80_1(StarSlotData a, StarSlotData b); // 0x000000018077CE50-0x000000018077CE80
			internal int _InitializeAllStarButtons_b__80_2(StarSlotData a, StarSlotData b); // 0x000000018077CE50-0x000000018077CE80
			internal int _MapStarGroup_b__83_0(Transform a, Transform b); // 0x000000018077CE80-0x000000018077CEE0
			internal int _InitializeStarButtonsForImage_b__86_0(StarSlotData a, StarSlotData b); // 0x000000018077CE50-0x000000018077CE80
			internal int _InitializeStarButtonsForImage_b__86_1(StarSlotData a, StarSlotData b); // 0x000000018077CE50-0x000000018077CE80
			internal int _InitializeStarButtonsForImage_b__86_2(StarSlotData a, StarSlotData b); // 0x000000018077CE50-0x000000018077CE80
			internal void _ShowPetUnlockPanel_b__101_0(); // 0x00000001802EB6C0-0x00000001802EB6D0
			internal void _ShowPetUnlockPanel_b__101_1(); // 0x00000001802EB6C0-0x00000001802EB6D0
			internal void _TestAPI_b__114_0(LegendPetListResponse response); // 0x000000018077CEE0-0x000000018077CFA0
			internal void _TestAPI_b__114_1(string error); // 0x000000018077CFA0-0x000000018077D030
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass54_0 // TypeDefIndex: 2161
		{
			// Fields
			public int index; // 0x10
			public PanelPetHT __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass54_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Awake_b__2(); // 0x000000018077D300-0x000000018077D330
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass63_0 // TypeDefIndex: 2162
		{
			// Fields
			public PanelPetHT __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass63_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _PreloadPetDetail_b__0(LegendPetData data); // 0x000000018077D330-0x000000018077D3C0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass64_0 // TypeDefIndex: 2163
		{
			// Fields
			public PanelPetHT __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass64_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _PreloadUserPetStats_b__0(PetUserDTO pet); // 0x000000018077D3C0-0x000000018077D430
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass71_0 // TypeDefIndex: 2164
		{
			// Fields
			public PanelPetHT __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass71_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _LoadPetDetail_b__0(LegendPetData data); // 0x000000018077D430-0x000000018077D4B0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass74_0 // TypeDefIndex: 2165
		{
			// Fields
			public PanelPetHT __4__this; // 0x10
			public long petId; // 0x18
	
			// Constructors
			public __c__DisplayClass74_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _LoadAndShowPetStats_b__0(PetUserDTO pet); // 0x000000018077D4B0-0x000000018077D5D0
			internal void _LoadAndShowPetStats_b__1(string error); // 0x000000018077D5D0-0x000000018077D6C0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass83_0 // TypeDefIndex: 2166
		{
			// Fields
			public StarSlotData slotData; // 0x10
			public PanelPetHT __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass83_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _MapStarGroup_b__1(); // 0x000000018077D6C0-0x000000018077D6F0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass92_0 // TypeDefIndex: 2167
		{
			// Fields
			public PanelPetHT __4__this; // 0x10
			public InlayStarResponse response; // 0x18
			public LegendPetData pet; // 0x20
			public bool isViewing; // 0x28
			public int petIndex; // 0x2C
			public Action __9__0; // 0x30
	
			// Constructors
			public __c__DisplayClass92_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _OnInlaySuccess_b__0(); // 0x000000018077D8A0-0x000000018077DB80
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass99_0 // TypeDefIndex: 2168
		{
			// Fields
			public Action onComplete; // 0x10
	
			// Constructors
			public __c__DisplayClass99_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _PlayStarInlayAnimation_b__0(); // 0x0000000180410BE0-0x0000000180410C00
		}
	
		// Constructors
		public PanelPetHT(); // 0x000000018075AC60-0x000000018075ADD0
	
		// Methods
		private void Awake(); // 0x00000001807514C0-0x00000001807519A0
		private void Start(); // 0x0000000180758FE0-0x0000000180759020
		public void Show(); // 0x0000000180758F00-0x0000000180758FE0
		public void Hide(); // 0x0000000180752AC0-0x0000000180752B40
		private void OnDisable(); // 0x0000000180755A60-0x0000000180755A80
		private long GetCurrentUserId(); // 0x0000000180752300-0x0000000180752390
		private void LoadAllPets(); // 0x0000000180753D10-0x0000000180753F90
		private void OnLoadAllPetsSuccess(LegendPetListResponse response); // 0x0000000180756210-0x0000000180756550
		private void PreloadOtherPetsData(int skipIndex); // 0x0000000180757270-0x0000000180757310
		private void PreloadPetDetail(long petId); // 0x0000000180757310-0x00000001807574F0
		private void PreloadUserPetStats(long petId); // 0x00000001807574F0-0x00000001807576D0
		private void OnLoadAllPetsError(string error); // 0x0000000180756140-0x0000000180756210
		private void SetupPetButtons(); // 0x0000000180757B40-0x0000000180757E00
		private void UpdatePetButtonVisual(int index, LegendPetBasicInfo pet); // 0x000000018075A1E0-0x000000018075A330
		private void OnPetButtonClick(int index); // 0x0000000180756890-0x0000000180756990
		private void SelectPet(int index); // 0x0000000180757970-0x0000000180757AB0
		private void UpdatePetButtonHighlight(int selectedIndex); // 0x0000000180759E00-0x000000018075A1E0
		private void LoadPetDetail(long petId); // 0x00000001807546D0-0x0000000180754C60
		private void OnLoadPetDetailSuccess(LegendPetData data); // 0x0000000180756610-0x0000000180756890
		private void HideAllPetStatsUI(); // 0x0000000180752390-0x0000000180752750
		private void LoadAndShowPetStats(long petId); // 0x0000000180753F90-0x00000001807545F0
		private void DisplayPetStats(PetUserDTO pet); // 0x0000000180752180-0x0000000180752190
		private void ClearAllStarButtons(); // 0x00000001807519A0-0x0000000180751EA0
		private void OnLoadPetDetailError(string error); // 0x0000000180756550-0x0000000180756610
		private void UpdatePetInfo(); // 0x000000018075A330-0x000000018075A500
		private void UpdateStarCount(); // 0x000000018075A500-0x000000018075A690
		private void InitializeAllStarButtons(); // 0x0000000180752B40-0x0000000180753450
		private void ClearStarsInPanel(GameObject panel); // 0x0000000180751EA0-0x0000000180752150
		private Transform FindStarGroupContainer(Transform parent, string groupName); // 0x0000000180752190-0x0000000180752300
		private int MapStarGroup(Transform container, List<StarSlotData> slotDataList, int starType); // 0x0000000180754E40-0x00000001807553A0
		private void UpdateStarVisual(StarSlotData slotData, Image starImage, Button starButton); // 0x000000018075A900-0x000000018075AC60
		private void ShowImageHT(int petIndex); // 0x0000000180758340-0x0000000180758A10
		private void InitializeStarButtonsForImage(int panelIndex, ImageHTData imageData); // 0x0000000180753450-0x0000000180753B30
		private void OnStarClicked(StarSlotData slotData); // 0x0000000180756E60-0x0000000180756F10
		private void ShowConfirmPanel(StarSlotData slotData, int currentStarCount); // 0x0000000180757E00-0x0000000180758290
		private void HideConfirmPanel(); // 0x0000000180752750-0x0000000180752850
		private void OnConfirm(bool confirmed); // 0x00000001807553A0-0x0000000180755650
		private void InlayStar(StarSlotData slotData); // 0x0000000180753B30-0x0000000180753D10
		private void OnInlaySuccess(InlayStarResponse response); // 0x0000000180755B40-0x0000000180756140
		private void OnPetsReceived(PetUserDTO pet); // 0x0000000180756990-0x0000000180756E60
		private void LoadPetSkillCard(int skillCardId, string description); // 0x0000000180754C60-0x0000000180754E40
		private void SetTextIfNotNull(UnityEngine.UI.Text textComponent, string value); // 0x0000000180757AB0-0x0000000180757B40
		private void LoadAttributeImage(Image imageComponent, string attributeName); // 0x00000001807545F0-0x00000001807546D0
		private void UpdateStarSlotVisual(long slotId, bool inlaid); // 0x000000018075A690-0x000000018075A900
		private void HideStarsAndChangeImageColor(); // 0x0000000180752850-0x0000000180752AC0
		private void PlayStarInlayAnimation(long slotId, Action onComplete); // 0x0000000180757080-0x0000000180757270
		private void OnInlayError(string error); // 0x0000000180755A80-0x0000000180755B40
		private void ShowPetUnlockPanel(); // 0x0000000180758C00-0x0000000180758F00
		private void ShowLoading(bool show); // 0x0000000180758A10-0x0000000180758C00
		private void ShowErrorMessage(string message); // 0x0000000180758290-0x0000000180758340
		private void OnDestroy(); // 0x0000000180755650-0x0000000180755A60
		private void OnStarCountChangedHandler(int white, int blue, int red); // 0x0000000180756F10-0x0000000180757080
		private void RecomputeCanInlay(ImageHTData imageData); // 0x00000001807576D0-0x0000000180757880
		private void UpdateAllStarButtonStates(); // 0x00000001807596F0-0x0000000180759E00
		public void RefreshData(); // 0x0000000180757880-0x00000001807578F0
		public void SelectPetById(long petId); // 0x00000001807578F0-0x0000000180757970
		[ContextMenu("Test - Show Panel")]
		private void ContextMenu_ShowPanel(); // 0x0000000180752150-0x0000000180752160
		[ContextMenu("Test - Call API")]
		private void ContextMenu_TestAPI(); // 0x0000000180752160-0x0000000180752170
		[ContextMenu("Test - Load Fake Data")]
		private void ContextMenu_TestFakeData(); // 0x0000000180752170-0x0000000180752180
		public void TestAPI(); // 0x0000000180759020-0x0000000180759320
		public void TestWithFakeData(); // 0x0000000180759320-0x00000001807595C0
		[CompilerGenerated]
		private void _Awake_b__54_0(); // 0x00000001807595C0-0x00000001807595D0
		[CompilerGenerated]
		private void _Awake_b__54_1(); // 0x00000001807595D0-0x00000001807595E0
		[CompilerGenerated]
		private void _HideConfirmPanel_b__89_0(); // 0x00000001807595E0-0x0000000180759610
		[CompilerGenerated]
		private void _ShowPetUnlockPanel_b__101_2(); // 0x0000000180759610-0x00000001807596C0
		[CompilerGenerated]
		private void _ShowPetUnlockPanel_b__101_3(); // 0x00000001807596C0-0x00000001807596F0
	}
}
