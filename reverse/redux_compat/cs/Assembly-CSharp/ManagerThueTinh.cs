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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerThueTinh : MonoBehaviour // TypeDefIndex: 1246
{
	// Fields
	public const string PANEL_KEY = "PanelMega"; // Metadata: 0x0064D53A
	[Header("Main Panel")]
	public GameObject PanelThueTinh; // 0x20
	public Button btnOpenThueTinh; // 0x28
	public Button btnClose; // 0x30
	[Header("Pet List - Board")]
	public Transform Board; // 0x38
	public GameObject btnPetPrefab; // 0x40
	[Header("Pagination")]
	public Button btnLeft; // 0x48
	public Button btnRight; // 0x50
	public UnityEngine.UI.Text txtPageInfo; // 0x58
	[Header("Panel Body - Chi ti\u1EBFt")]
	public GameObject PanelBody; // 0x60
	public Animator anmtPetMain; // 0x68
	public Button btnThueTinh; // 0x70
	public UnityEngine.UI.Text txtstatus; // 0x78
	[Header("PanelPart1 - Pet Info")]
	public GameObject PanelPart1; // 0x80
	public Image imgPetSource; // 0x88
	public UnityEngine.UI.Text txtCurrentLevel; // 0x90
	public UnityEngine.UI.Text txtNamePet; // 0x98
	public UnityEngine.UI.Text txtDesReq; // 0xA0
	[Header("PanelPart2 - Crystal")]
	public GameObject PanelPart2; // 0xA8
	public UnityEngine.UI.Text txtCrystalCount; // 0xB0
	[Header("PanelPart3 - 9 Vi\u00EAn L\u00F5i")]
	public GameObject PanelPart3; // 0xB8
	[Tooltip("9 frame l\u00F5i theo th\u1EE9 t\u1EF1 1\u21929")]
	public GameObject[] frameCores; // 0xC0
	[Tooltip("9 Text current/required c\u1EE7a t\u1EEBng l\u00F5i")]
	public UnityEngine.UI.Text[] txtCountCores; // 0xC8
	[Tooltip("9 Sprite icon l\u00F5i")]
	public Sprite[] coreSprites; // 0xD0
	[Header("Panel Condition")]
	public GameObject PanelCondition; // 0xD8
	public UnityEngine.UI.Text txtCondition; // 0xE0
	[Header("Background")]
	public Image imgBg; // 0xE8
	[Header("Loading")]
	public GameObject loadingIndicator; // 0xF0
	[Header("Panel \u0110\u1ED5i L\u00F5i - pnlDoiItem")]
	[Tooltip("pnlDoiItem \u2014 panel t\u1ED5ng")]
	public GameObject pnlDoiItem; // 0xF8
	[Tooltip("btnBack \u2014 \u0111\u00F3ng panel, kh\u00F4ng \u0111\u1ED5i")]
	public Button btnBack; // 0x100
	[Tooltip("btnDoi \u2014 x\u00E1c nh\u1EADn \u0111\u1ED5i (ch\u1EC9 b\u1EADt khi C\u1EA2 4 lo\u1EA1i eItem \u0111\u1EC1u \u0111\u1EE7 4)")]
	public Button btnDoi; // 0x108
	[Tooltip("item1 \u2014 Image icon l\u00F5i \u0111ang \u0111\u01B0\u1EE3c ch\u1ECDn \u0111\u1ED5i")]
	public Image imgCorePreviewed; // 0x110
	[Tooltip("(Tu\u1EF3 ch\u1ECDn) Text t\u00EAn l\u00F5i \u0111ang ch\u1ECDn")]
	public UnityEngine.UI.Text txtCorePreviewName; // 0x118
	[Tooltip("4 frame eItem (frame1..frame4) trong swapitem1 > PanelPart3")]
	public GameObject[] frameEItems; // 0x120
	[Tooltip("txtcount trong m\u1ED7i frame \u2014 hi\u1EC3n th\u1ECB \'hi\u1EC7n c\u00F3 / 4\'")]
	public UnityEngine.UI.Text[] txtEItemCounts; // 0x128
	[Tooltip("4 Text trong PanelCurrent \u2014 s\u1ED1 eItem \u0111ang c\u00F3")]
	public UnityEngine.UI.Text[] txtCurrentEItems; // 0x130
	private PagedMegaAwakeningResponse awakeningData; // 0x138
	private MegaAwakeningDetailDTO currentDetail; // 0x140
	private int userId; // 0x148
	private long selectedPetId; // 0x150
	private int currentPage; // 0x158
	private int totalPages; // 0x15C
	private const int PAGE_SIZE = 8; // Metadata: 0x0064D544
	private const int EITEM_COST = 4; // Metadata: 0x0064D545
	private List<GameObject> petButtons; // 0x160
	private int pendingCoreIndex; // 0x168
	private static readonly string[] CORE_NAMES; // 0x00
	private const float PET_FIT_W = 380f; // Metadata: 0x0064D546
	private const float PET_FIT_H = 250f; // Metadata: 0x0064D54A

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1247
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<int, bool> __9__57_0; // 0x08
		public static Func<RequiredPetDTO, string> __9__62_0; // 0x10
		public static Func<RequiredPetDTO, string> __9__62_1; // 0x18
		public static Func<RequiredPetDTO, bool> __9__63_0; // 0x20
		public static Func<RequiredPetDTO, string> __9__63_1; // 0x28

		// Constructors
		static __c(); // 0x00000001804EAB50-0x00000001804EABC0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _OpenDoiItemPanel_b__57_0(int have); // 0x00000001804EA460-0x00000001804EA470
		internal string _DisplayConditionPets_b__62_0(RequiredPetDTO p); // 0x00000001804EA1C0-0x00000001804EA300
		internal string _DisplayConditionPets_b__62_1(RequiredPetDTO p); // 0x00000001804EA300-0x00000001804EA440
		internal bool _DisplayStatus_b__63_0(RequiredPetDTO p); // 0x000000018038C8E0-0x000000018038C900
		internal string _DisplayStatus_b__63_1(RequiredPetDTO p); // 0x00000001804EA440-0x00000001804EA460
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass52_0 // TypeDefIndex: 1248
	{
		// Fields
		public long capturedId; // 0x10
		public ManagerThueTinh __4__this; // 0x18

		// Constructors
		public __c__DisplayClass52_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _DisplayPets_b__0(); // 0x00000001804EAA80-0x00000001804EAAB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass56_0 // TypeDefIndex: 1249
	{
		// Fields
		public int captured; // 0x10
		public ManagerThueTinh __4__this; // 0x18

		// Constructors
		public __c__DisplayClass56_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _DisplayCores_b__0(); // 0x00000001804EAAB0-0x00000001804EAAE0
	}

	[CompilerGenerated]
	private sealed class _RefreshAfterAwaken_d__66 : IEnumerator<object> // TypeDefIndex: 1250
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerThueTinh __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RefreshAfterAwaken_d__66(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804E5FD0-0x00000001804E60A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804E60A0-0x00000001804E60E0
	}

	// Constructors
	public ManagerThueTinh(); // 0x00000001804E17F0-0x00000001804E1990
	static ManagerThueTinh(); // 0x00000001804E15F0-0x00000001804E17F0

	// Methods
	private void Awake(); // 0x00000001804DD110-0x00000001804DD270
	private void BindButtons(); // 0x00000001804DD3F0-0x00000001804DD760
	public void OpenPanel(); // 0x00000001804E0280-0x00000001804E0310
	public void ClosePanel(); // 0x00000001804DD890-0x00000001804DD9F0
	private void LoadAwakeningPets(); // 0x00000001804DF5B0-0x00000001804DF710
	private void DisplayPets(List<MegaAwakeningPetDTO> pets); // 0x00000001804DE9F0-0x00000001804DF000
	private void SelectPet(long petId); // 0x00000001804E0630-0x00000001804E0640
	private void LoadPetDetail(long petId); // 0x00000001804DF710-0x00000001804DF860
	private void DisplayDetail(MegaAwakeningDetailDTO d); // 0x00000001804DE4E0-0x00000001804DE9F0
	private void DisplayCores(MegaAwakeningDetailDTO d); // 0x00000001804DDD50-0x00000001804DE4E0
	private void OpenDoiItemPanel(int coreIndex); // 0x00000001804DFB00-0x00000001804E0280
	private void OnBtnDoiClick(); // 0x00000001804DF880-0x00000001804DFA50
	private void CloseDoiItemPanel(); // 0x00000001804DD800-0x00000001804DD890
	private void PatchDetailAfterSwap(SwapItemResultDTO result); // 0x00000001804E0310-0x00000001804E05A0
	private bool CheckCanAwakenLocal(); // 0x00000001804DD760-0x00000001804DD800
	private void DisplayConditionPets(MegaAwakeningDetailDTO d); // 0x00000001804DD9F0-0x00000001804DDD50
	private void DisplayStatus(MegaAwakeningDetailDTO d); // 0x00000001804DF000-0x00000001804DF3E0
	private void SetStatus(string msg, bool showBtn); // 0x00000001804E0640-0x00000001804E0720
	private void AwakenPet(); // 0x00000001804DD270-0x00000001804DD3F0
	[IteratorStateMachine(typeof(_RefreshAfterAwaken_d__66))]
	private IEnumerator RefreshAfterAwaken(); // 0x00000001804E05C0-0x00000001804E0630
	private void PreviousPage(); // 0x00000001804E05A0-0x00000001804E05C0
	private void NextPage(); // 0x00000001804DF860-0x00000001804DF880
	private void UpdatePagination(); // 0x00000001804E1490-0x00000001804E15F0
	private void ShowLoading(); // 0x00000001804E0720-0x00000001804E07A0
	private void HideLoading(); // 0x00000001804DF500-0x00000001804DF5B0
	private bool TrySetupPetAnimation(Animator petAnimator, string petID); // 0x00000001804E07A0-0x00000001804E0C90
	private PetImageFit EnsurePetFit(Image img); // 0x00000001804DF3E0-0x00000001804DF500
	private void OnDestroy(); // 0x00000001804DFA50-0x00000001804DFB00
	[CompilerGenerated]
	private void _LoadAwakeningPets_b__51_0(PagedMegaAwakeningResponse data); // 0x00000001804E0F80-0x00000001804E1160
	[CompilerGenerated]
	private void _LoadAwakeningPets_b__51_1(string error); // 0x00000001804E1160-0x00000001804E11E0
	[CompilerGenerated]
	private void _LoadPetDetail_b__54_0(MegaAwakeningDetailDTO detail); // 0x00000001804E11E0-0x00000001804E1230
	[CompilerGenerated]
	private void _LoadPetDetail_b__54_1(string error); // 0x00000001804E1230-0x00000001804E12B0
	[CompilerGenerated]
	private void _OnBtnDoiClick_b__58_0(SwapItemResultDTO result); // 0x00000001804E12B0-0x00000001804E1410
	[CompilerGenerated]
	private void _OnBtnDoiClick_b__58_1(string error); // 0x00000001804E1410-0x00000001804E1490
	[CompilerGenerated]
	private void _AwakenPet_b__65_0(MegaAwakeningResultDTO result); // 0x00000001804E0C90-0x00000001804E0E20
	[CompilerGenerated]
	private void _AwakenPet_b__65_1(string error); // 0x00000001804E0E20-0x00000001804E0F80
}

