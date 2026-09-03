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

public class ManagerEquipment : MonoBehaviour // TypeDefIndex: 471
{
	// Fields
	public const string PANEL_KEY = "PanelAvtPet"; // Metadata: 0x0064C4BC
	[Header("Main Panel")]
	public GameObject panelEquipment; // 0x20
	public Button btnClose; // 0x28
	[Header("Tab Buttons")]
	public Button btnPet; // 0x30
	public Button btnAvt; // 0x38
	public Button btnUserInfo; // 0x40
	public Button btnWeapon; // 0x48
	public Button btnShard; // 0x50
	[Header("Content Panels")]
	public GameObject bgPet; // 0x58
	public GameObject ListAvt; // 0x60
	public GameObject panelUserInfo; // 0x68
	public GameObject panelWeapon; // 0x70
	public GameObject panelShard; // 0x78
	[Header("Pet Star")]
	public PetShardTabController shardTab; // 0x80
	[Header("Weapon")]
	public WeaponTabController weaponTab; // 0x88
	public WeaponBadgeUI weaponBadgeUserInfo; // 0x90
	[Header("Pet List")]
	public Transform ListPet; // 0x98
	public GameObject PET; // 0xA0
	[Header("Avatar List")]
	public GameObject AVTPET; // 0xA8
	[Header("Navigation")]
	public Button btnLeft; // 0xB0
	public Button btnRight; // 0xB8
	public UnityEngine.UI.Text txtPageInfo; // 0xC0
	[Header("Stats Display - Panel ch\u00EDnh")]
	public UnityEngine.UI.Text txtDame; // 0xC8
	public UnityEngine.UI.Text txtMana; // 0xD0
	public UnityEngine.UI.Text txtMau; // 0xD8
	[Header("User Info Tab - Basic Info")]
	public Image imgUserInfoAvatar; // 0xE0
	public UnityEngine.UI.Text txtUserInfoName; // 0xE8
	public UnityEngine.UI.Text txtUserTop; // 0xF0
	public Image imgUserInfoLevel; // 0xF8
	public Animator anmtUserInfoPet; // 0x100
	[Header("User Info Tab - Current Pet Stats")]
	public UnityEngine.UI.Text txtUserInfoAttack; // 0x108
	public UnityEngine.UI.Text txtUserInfoHP; // 0x110
	public UnityEngine.UI.Text txtUserInfoMana; // 0x118
	public UnityEngine.UI.Text txtTotalCombatPowerUserInfo; // 0x120
	[Header("User Info Tab - Pet List")]
	public Transform userInfoPetListContent; // 0x128
	public GameObject userInfoPetItemPrefab; // 0x130
	[Header("User Info Tab - Stone List")]
	public Transform userInfoStoneListContent; // 0x138
	public GameObject userInfoStoneItemPrefab; // 0x140
	private int userId; // 0x148
	private int currentPage; // 0x14C
	private int totalPages; // 0x150
	private int currentTab; // 0x154
	private List<PetEquipmentDTO> allPets; // 0x158
	private List<AvatarEquipmentDTO> allAvatars; // 0x160
	private long currentEquippedPetId; // 0x168
	private long currentEquippedAvatarId; // 0x170
	private readonly Dictionary<long, int> petStars; // 0x178
	private int petStarMax; // 0x180
	private bool petStarsLoaded; // 0x184
	private const int PETS_PER_PAGE = 10; // Metadata: 0x0064C4C8
	private const int AVATARS_PER_PAGE_LEGACY = 3; // Metadata: 0x0064C4C9
	private const int AVATARS_FETCH_ALL = 300; // Metadata: 0x0064C4CA
	private List<AvatarEquipmentDTO> allAvatarsFull; // 0x188
	private bool avatarsFetched; // 0x190
	private CanvasGroup panelCanvasGroup; // 0x198
	private Dictionary<int, Sprite> stoneDictionary; // 0x1A0
	public GameObject panelSettings; // 0x1A8
	public GameObject panelChangeName; // 0x1B0
	public Button btnOpenSettings; // 0x1B8
	public Button btnOpenChangeName; // 0x1C0
	private SettingsManager settingsManager; // 0x1C8
	public static ManagerEquipment Instance; // 0x00

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 472
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__73_1; // 0x08
		public static Action<string> __9__81_1; // 0x10
		public static Action<string> __9__100_1; // 0x18
		public static Action<string> __9__103_1; // 0x20

		// Constructors
		static __c(); // 0x000000018036E310-0x000000018036E380
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadPetStars_b__73_1(string err); // 0x000000018036DFF0-0x000000018036E060
		internal void _LoadEquipmentCount_b__81_1(string error); // 0x000000018036DF80-0x000000018036DFF0
		internal void _EquipPetCoroutine_b__100_1(string error); // 0x000000018036DF10-0x000000018036DF80
		internal void _EquipAvatarCoroutine_b__103_1(string error); // 0x000000018036DEA0-0x000000018036DF10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass100_0 // TypeDefIndex: 473
	{
		// Fields
		public ManagerEquipment __4__this; // 0x10
		public PetEquipmentDTO pet; // 0x18
		public GameObject petObj; // 0x20

		// Constructors
		public __c__DisplayClass100_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _EquipPetCoroutine_b__0(EquipResponse response); // 0x000000018036E060-0x000000018036E130
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass103_0 // TypeDefIndex: 474
	{
		// Fields
		public ManagerEquipment __4__this; // 0x10
		public AvatarEquipmentDTO avatar; // 0x18
		public GameObject avtObj; // 0x20

		// Constructors
		public __c__DisplayClass103_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _EquipAvatarCoroutine_b__0(EquipResponse response); // 0x000000018036E130-0x000000018036E200
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass84_0 // TypeDefIndex: 475
	{
		// Fields
		public ManagerEquipment __4__this; // 0x10
		public PetEquipmentDTO pet; // 0x18
		public GameObject petObj; // 0x20

		// Constructors
		public __c__DisplayClass84_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupPetItem_b__0(); // 0x000000018036E200-0x000000018036E2E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass87_0 // TypeDefIndex: 476
	{
		// Fields
		public ManagerEquipment __4__this; // 0x10
		public AvatarEquipmentDTO avatar; // 0x18
		public GameObject avtObj; // 0x20

		// Constructors
		public __c__DisplayClass87_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupAvatarItem_b__0(); // 0x000000018036E2E0-0x000000018036E310
	}

	[CompilerGenerated]
	private sealed class _EquipAvatarCoroutine_d__103 : IEnumerator<object> // TypeDefIndex: 477
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerEquipment __4__this; // 0x20
		public AvatarEquipmentDTO avatar; // 0x28
		public GameObject avtObj; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _EquipAvatarCoroutine_d__103(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018036CE30-0x000000018036D0D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018036D0D0-0x000000018036D110
	}

	[CompilerGenerated]
	private sealed class _EquipPetCoroutine_d__100 : IEnumerator<object> // TypeDefIndex: 478
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerEquipment __4__this; // 0x20
		public PetEquipmentDTO pet; // 0x28
		public GameObject petObj; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _EquipPetCoroutine_d__100(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018036D110-0x000000018036D3B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018036D3B0-0x000000018036D3F0
	}

	[CompilerGenerated]
	private sealed class _LoadAvatarsData_d__76 : IEnumerator<object> // TypeDefIndex: 479
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerEquipment __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadAvatarsData_d__76(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018036D3F0-0x000000018036D5A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018036D5A0-0x000000018036D5E0
	}

	[CompilerGenerated]
	private sealed class _LoadEquipmentCount_d__81 : IEnumerator<object> // TypeDefIndex: 480
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerEquipment __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadEquipmentCount_d__81(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018036D5E0-0x000000018036D7D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018036D7D0-0x000000018036D810
	}

	[CompilerGenerated]
	private sealed class _LoadPetStars_d__73 : IEnumerator<object> // TypeDefIndex: 481
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerEquipment __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetStars_d__73(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018036D810-0x000000018036DA40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018036DA40-0x000000018036DA80
	}

	[CompilerGenerated]
	private sealed class _LoadPetsData_d__72 : IEnumerator<object> // TypeDefIndex: 482
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerEquipment __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetsData_d__72(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018036DA80-0x000000018036DCA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018036DCA0-0x000000018036DCE0
	}

	[CompilerGenerated]
	private sealed class _LoadUserInfoData_d__79 : IEnumerator<object> // TypeDefIndex: 483
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerEquipment __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadUserInfoData_d__79(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018036DCE0-0x000000018036DE60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018036DE60-0x000000018036DEA0
	}

	// Constructors
	public ManagerEquipment(); // 0x0000000180365030-0x00000001803651B0

	// Methods
	private int AvatarsPerPage(); // 0x000000018035E2E0-0x000000018035E4F0
	private void Awake(); // 0x000000018035E4F0-0x000000018035E840
	private void InitializeUI(); // 0x0000000180360990-0x0000000180360EC0
	private void InitializeStoneDictionary(); // 0x0000000180360380-0x0000000180360990
	private Sprite GetStoneSprite(long stoneId); // 0x0000000180360010-0x0000000180360110
	public void OpenEquipmentPanel(); // 0x0000000180361C90-0x0000000180361DE0
	private void ClosePanel(); // 0x000000018035E840-0x000000018035EA20
	private void SwitchTab(int tabIndex); // 0x0000000180363910-0x00000001803643C0
	private void HighlightButton(Button activeBtn, Button[] inactiveBtns); // 0x0000000180360110-0x0000000180360380
	private void ShowNavigation(bool show); // 0x00000001803637F0-0x0000000180363910
	[IteratorStateMachine(typeof(_LoadPetsData_d__72))]
	private IEnumerator LoadPetsData(); // 0x0000000180361460-0x00000001803614D0
	[IteratorStateMachine(typeof(_LoadPetStars_d__73))]
	private IEnumerator LoadPetStars(); // 0x00000001803613F0-0x0000000180361460
	private int GetPetStar(long petId); // 0x000000018035FF90-0x0000000180360010
	private void OnPetsLoaded(List<PetEquipmentDTO> pets); // 0x0000000180361830-0x00000001803619C0
	[IteratorStateMachine(typeof(_LoadAvatarsData_d__76))]
	private IEnumerator LoadAvatarsData(); // 0x0000000180361310-0x0000000180361380
	private void OnAvatarsLoaded(List<AvatarEquipmentDTO> avatars); // 0x0000000180361660-0x0000000180361700
	private void ApplyAvatarPage(); // 0x000000018035DFA0-0x000000018035E200
	[IteratorStateMachine(typeof(_LoadUserInfoData_d__79))]
	private IEnumerator LoadUserInfoData(); // 0x00000001803614D0-0x0000000180361540
	private void OnUserInfoLoaded(UserDetailData userDetail); // 0x0000000180361C80-0x0000000180361C90
	[IteratorStateMachine(typeof(_LoadEquipmentCount_d__81))]
	private IEnumerator LoadEquipmentCount(); // 0x0000000180361380-0x00000001803613F0
	private void OnLoadError(string error); // 0x0000000180361700-0x0000000180361770
	private void DisplayPets(); // 0x000000018035EDF0-0x000000018035F1A0
	private void SetupPetItem(GameObject petObj, PetEquipmentDTO pet); // 0x0000000180362A50-0x0000000180363130
	private void ReplaceAnimations(Animator animator, AnimationClip[] newClips); // 0x00000001803620E0-0x0000000180362330
	private void DisplayAvatars(); // 0x000000018035EA20-0x000000018035EDF0
	private void SetupAvatarItem(GameObject avtObj, AvatarEquipmentDTO avatar); // 0x0000000180362330-0x0000000180362980
	private void LayoutAvatarCell(GameObject avtObj, Image avtImage); // 0x0000000180360EC0-0x0000000180361310
	private void PlaceCell(GameObject cellObj, string childName, Vector2 pos, Vector2 size, int fontSize = 0 /* Metadata: 0x0064C4BA */, TextAnchor align = TextAnchor.MiddleCenter /* Metadata: 0x0064C4BB */); // 0x0000000180361DE0-0x0000000180361FF0
	private void SetupImgLevel(int level, Image imgLv); // 0x0000000180362980-0x0000000180362A50
	private void DisplayUserInfo(UserDetailData userDetail); // 0x000000018035F980-0x000000018035FE30
	public void RefreshWeaponBadge(int imageId, string rarity, int star); // 0x0000000180362050-0x00000001803620E0
	private void ApplyWeaponBadge(int imageId, string rarity, int star, long ownerUserId); // 0x000000018035E200-0x000000018035E2E0
	private void DisplayUserInfoPetList(List<UserPetInfo> pets); // 0x000000018035F1A0-0x000000018035F590
	private void SetupUserInfoPetItem(GameObject item, UserPetInfo pet); // 0x0000000180363130-0x0000000180363500
	private void DisplayUserInfoStoneList(List<StoneInfo> stones); // 0x000000018035F590-0x000000018035F980
	private void SetupUserInfoStoneItem(GameObject item, StoneInfo stone); // 0x0000000180363500-0x00000001803637F0
	private bool TrySetupPetAnimation(Animator petAnimator, string petID); // 0x00000001803643C0-0x00000001803649D0
	private void OnSelectPet(PetEquipmentDTO pet, GameObject petObj); // 0x0000000180361BB0-0x0000000180361C80
	[IteratorStateMachine(typeof(_EquipPetCoroutine_d__100))]
	private IEnumerator EquipPetCoroutine(PetEquipmentDTO pet, GameObject petObj); // 0x000000018035FEE0-0x000000018035FF90
	private void OnPetEquipped(EquipResponse response, PetEquipmentDTO pet, GameObject petObj); // 0x0000000180361770-0x0000000180361830
	private void OnSelectAvatar(AvatarEquipmentDTO avatar, GameObject avtObj); // 0x00000001803619C0-0x0000000180361BB0
	[IteratorStateMachine(typeof(_EquipAvatarCoroutine_d__103))]
	private IEnumerator EquipAvatarCoroutine(AvatarEquipmentDTO avatar, GameObject avtObj); // 0x000000018035FE30-0x000000018035FEE0
	private void OnAvatarEquipped(EquipResponse response, AvatarEquipmentDTO avatar, GameObject avtObj); // 0x00000001803615A0-0x0000000180361660
	private void UpdateStatsDisplay(int attack, int mana, int hp); // 0x0000000180364EF0-0x0000000180365030
	private void PreviousPage(); // 0x0000000180361FF0-0x0000000180362050
	private void NextPage(); // 0x0000000180361540-0x00000001803615A0
	private void UpdatePageInfo(); // 0x0000000180364DF0-0x0000000180364EF0
	private void UpdateNavigationButtons(); // 0x0000000180364D30-0x0000000180364DF0
	[CompilerGenerated]
	private void _InitializeUI_b__64_0(); // 0x0000000180364B20-0x0000000180364B30
	[CompilerGenerated]
	private void _InitializeUI_b__64_1(); // 0x0000000180364B30-0x0000000180364B40
	[CompilerGenerated]
	private void _InitializeUI_b__64_2(); // 0x0000000180364B40-0x0000000180364B50
	[CompilerGenerated]
	private void _InitializeUI_b__64_3(); // 0x0000000180364B50-0x0000000180364B60
	[CompilerGenerated]
	private void _InitializeUI_b__64_4(); // 0x0000000180364B60-0x0000000180364B70
	[CompilerGenerated]
	private void _InitializeUI_b__64_5(); // 0x0000000180364B70-0x0000000180364C00
	[CompilerGenerated]
	private void _ClosePanel_b__68_0(); // 0x00000001803649D0-0x0000000180364B20
	[CompilerGenerated]
	private void _LoadPetStars_b__73_0(PetStarListResponse resp); // 0x0000000180364C40-0x0000000180364D30
	[CompilerGenerated]
	private void _LoadEquipmentCount_b__81_0(EquipmentCountDTO count); // 0x0000000180364C00-0x0000000180364C40
}

