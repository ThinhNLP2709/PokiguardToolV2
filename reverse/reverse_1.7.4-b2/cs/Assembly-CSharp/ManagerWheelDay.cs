/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EasyUI.PickerWheelUI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerWheelDay : MonoBehaviour // TypeDefIndex: 893
{
	// Fields
	public const string PANEL_KEY = "PanelWheelDay"; // Metadata: 0x0068BED7
	public static ManagerWheelDay Instance; // 0x00
	[Header("Panel References")]
	public GameObject panelWheelDay; // 0x20
	public GameObject panelNoticeResult; // 0x28
	public Button btnBack; // 0x30
	[Header("Picker Wheel Reference")]
	public PickerWheel pickerWheel; // 0x38
	[Header("Buttons")]
	public Button btnRun; // 0x40
	public Button btnRunMany; // 0x48
	public UnityEngine.UI.Text txtBtnRun; // 0x50
	public UnityEngine.UI.Text txtBtnRunMany; // 0x58
	public UnityEngine.UI.Text txtCountWheel; // 0x60
	[Header("Reward Display - Trong boardReward")]
	public Transform listPanel; // 0x68
	[Header("Notice Result")]
	public Transform listReward; // 0x70
	public Button btnGet; // 0x78
	public UnityEngine.UI.Text txtMessage; // 0x80
	[Header("Reward Prefabs")]
	public GameObject rewardPetPrefab; // 0x88
	public GameObject rewardAvatarPrefab; // 0x90
	public GameObject rewardGoldPrefab; // 0x98
	public GameObject rewardRubyPrefab; // 0xA0
	public GameObject rewardEnergyPrefab; // 0xA8
	public GameObject rewardStonePrefab; // 0xB0
	[Header("Reward Prefabs \u2014 lo\u1EA1i qu\u00E0 m\u1EDBi (\u0111\u1EC3 tr\u1ED1ng s\u1EBD t\u1EF1 m\u01B0\u1EE3n prefab Pet)")]
	public GameObject rewardShardPrefab; // 0xB8
	public GameObject rewardWeaponPrefab; // 0xC0
	public GameObject rewardWeaponPiecePrefab; // 0xC8
	[Header("FX k\u1EBFt qu\u1EA3 (tu\u1EF3 ch\u1ECDn \u2014 \u0111\u1EC3 tr\u1ED1ng l\u00E0 b\u1ECF qua, kh\u00F4ng l\u1ED7i)")]
	public Image imgResultGlow; // 0xD0
	public RectTransform pointerTransform; // 0xD8
	public AudioSource fxAudioSource; // 0xE0
	public AudioClip sfxWinCommon; // 0xE8
	public AudioClip sfxWinRare; // 0xF0
	[Header("Stone Sprites - 5 H\u1EC7, m\u1ED7i h\u1EC7 7 Level")]
	public Sprite[] stoneFire; // 0xF8
	public Sprite[] stoneWater; // 0x100
	public Sprite[] stoneWood; // 0x108
	public Sprite[] stoneEarth; // 0x110
	public Sprite[] stoneMetal; // 0x118
	[Header("Default Icons")]
	public Sprite iconGold; // 0x120
	public Sprite iconRuby; // 0x128
	public Sprite iconEnergy; // 0x130
	[Header("Settings")]
	public int spinCost; // 0x138
	public int duplicateCompensation; // 0x13C
	[Header("V\u00F2ng quay g\u1ED9p (30/08) \u2014 \u0111\u1EC3 tr\u1ED1ng s\u1EBD t\u1EF1 t\u00ECm theo t\u00EAn node \u00A72.4")]
	public WheelTabSwitcher tabs; // 0x140
	public GachaResultGridView resultGrid; // 0x148
	public GachaRatesView ratesView; // 0x150
	public GachaHistoryView historyView; // 0x158
	public Image wheelFlash; // 0x160
	[Header("Notice Confirm")]
	public GameObject panelNoticeConfirm; // 0x168
	public UnityEngine.UI.Text txtConfirmMessage; // 0x170
	public Button btnConfirmYes; // 0x178
	public Button btnConfirmNo; // 0x180
	private readonly Dictionary<WheelKind, IWheelSource> _sources; // 0x188
	private WheelHubView _view; // 0x190
	private WheelSpinEngine _engine; // 0x198
	private IWheelSource _source; // 0x1A0
	private WheelBoardVM _board; // 0x1A8
	private WheelKind _kind; // 0x1B0
	private int _userId; // 0x1B4
	private bool _wired; // 0x1B8
	private bool _busy; // 0x1B9
	private bool _spinning; // 0x1BA
	private int _pendingSpinCount; // 0x1BC
	private Coroutine _loadRoutine; // 0x1C0
	private Coroutine _waitToast; // 0x1C8
	private readonly List<WheelResultVM> _currentRewards; // 0x1D0
	private readonly List<WeaponDropDTO> pendingWeaponDrops; // 0x1D8
	private Func<bool> _tipBlocked; // 0x1E0
	private int _closeTweenId; // 0x1E8
	private int _shakeTweenId; // 0x1EC
	private int _flashTweenId; // 0x1F0
	private const int MAX_LABEL_CHARS = 12; // Metadata: 0x0068BEE5
	private static Sprite _weaponPieceSprite; // 0x08
	private static bool _weaponPieceLoaded; // 0x10
	private static readonly string[] IconNodeNames; // 0x18

	// Properties
	public bool IsSpinning { get; } // 0x00000001804BCF40-0x00000001804BCF50 
	public bool IsBusy { get; } // 0x00000001804BCE30-0x00000001804BCF40 
	public WheelKind CurrentKind { get; } // 0x00000001804BCE20-0x00000001804BCE30 
	private int BulkCount { get; } // 0x00000001804BCDF0-0x00000001804BCE20 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass112_0 // TypeDefIndex: 894
	{
		// Fields
		public ManagerWheelDay __4__this; // 0x10
		public WheelKind kind; // 0x18

		// Constructors
		public __c__DisplayClass112_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BeginSpin_b__0(WheelSpinOutcome o); // 0x00000001804E1460-0x00000001804E1490
		internal void _BeginSpin_b__1(string e); // 0x00000001804E1490-0x00000001804E14C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass114_0 // TypeDefIndex: 895
	{
		// Fields
		public ManagerWheelDay __4__this; // 0x10
		public WheelSpinOutcome outcome; // 0x18

		// Constructors
		public __c__DisplayClass114_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnSpinOk_b__0(); // 0x00000001804E14C0-0x00000001804E14F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass121_0 // TypeDefIndex: 896
	{
		// Fields
		public ManagerWheelDay __4__this; // 0x10
		public int again; // 0x18

		// Constructors
		public __c__DisplayClass121_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ShowResults_b__0(); // 0x00000001804E14F0-0x00000001804E1520
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass133_0 // TypeDefIndex: 897
	{
		// Fields
		public Image img; // 0x10
		public ManagerWheelDay __4__this; // 0x18

		// Constructors
		public __c__DisplayClass133_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayFlash_b__0(float v); // 0x00000001804E1520-0x00000001804E1610
		internal void _PlayFlash_b__1(); // 0x00000001804E1610-0x00000001804E16B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass134_0 // TypeDefIndex: 898
	{
		// Fields
		public GameObject go; // 0x10
		public Transform glow; // 0x18

		// Constructors
		public __c__DisplayClass134_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlaySlotGlow_b__0(); // 0x00000001804E16B0-0x00000001804E1780
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass139_0 // TypeDefIndex: 899
	{
		// Fields
		public Transform t; // 0x10
		public Vector3 basePos; // 0x18
		public ManagerWheelDay __4__this; // 0x28

		// Constructors
		public __c__DisplayClass139_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ShakePanel_b__0(); // 0x00000001804E1780-0x00000001804E17D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass140_0 // TypeDefIndex: 900
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 basePos; // 0x18

		// Constructors
		public __c__DisplayClass140_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ShakeButton_b__0(float t); // 0x00000001804E17D0-0x00000001804E18A0
		internal void _ShakeButton_b__1(); // 0x00000001804E18A0-0x00000001804E1930
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass91_0 // TypeDefIndex: 901
	{
		// Fields
		public WheelKind kind; // 0x10
		public ManagerWheelDay __4__this; // 0x18

		// Constructors
		public __c__DisplayClass91_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadRoutine_b__0(WheelBoardVM vm); // 0x00000001804E1A70-0x00000001804E1AB0
		internal void _LoadRoutine_b__1(string e); // 0x00000001804E1AB0-0x00000001804E1AF0
	}

	[CompilerGenerated]
	private sealed class _LoadRoutine_d__91 : IEnumerator<object> // TypeDefIndex: 902
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WheelKind kind; // 0x20
		public ManagerWheelDay __4__this; // 0x28
		public IWheelSource source; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoutine_d__91(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804DE4E0-0x00000001804DE700
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804DE700-0x00000001804DE740
	}

	[CompilerGenerated]
	private sealed class _ScrollInfoNextFrame_d__83 : IEnumerator<object> // TypeDefIndex: 903
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerWheelDay __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ScrollInfoNextFrame_d__83(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804DEF20-0x00000001804DF000
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804DF000-0x00000001804DF040
	}

	[CompilerGenerated]
	private sealed class _ShowResultsAfter_d__120 : IEnumerator<object> // TypeDefIndex: 904
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerWheelDay __4__this; // 0x20
		public WheelSpinOutcome outcome; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShowResultsAfter_d__120(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804DF040-0x00000001804DF0F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804DF0F0-0x00000001804DF130
	}

	[CompilerGenerated]
	private sealed class _WaitToastRoutine_d__113 : IEnumerator<object> // TypeDefIndex: 905
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerWheelDay __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitToastRoutine_d__113(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804E1AF0-0x00000001804E1C50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804E1C50-0x00000001804E1C90
	}

	// Constructors
	public ManagerWheelDay(); // 0x00000001804BCBD0-0x00000001804BCDF0
	static ManagerWheelDay(); // 0x00000001804BCA20-0x00000001804BCBD0

	// Methods
	private void Awake(); // 0x00000001804B3110-0x00000001804B3200
	private void Start(); // 0x00000001804BBC60-0x00000001804BBD10
	private void OnDisable(); // 0x00000001804B7230-0x00000001804B7370
	private void OnDestroy(); // 0x00000001804B7170-0x00000001804B7230
	private void Update(); // 0x00000001804BC8A0-0x00000001804BC910
	private void EnsureWired(); // 0x00000001804B4B80-0x00000001804B5360
	private void RescueEmbeddedSubViews(); // 0x00000001804B8FD0-0x00000001804B92C0
	private void DisableLegacyGalaxyEmbed(); // 0x00000001804B4AB0-0x00000001804B4B80
	private void InitializeButtons(); // 0x00000001804B6050-0x00000001804B6830
	private void OpenWheelInfo(); // 0x00000001804B7EF0-0x00000001804B7F90
	[IteratorStateMachine(typeof(_ScrollInfoNextFrame_d__83))]
	private IEnumerator ScrollInfoNextFrame(); // 0x00000001804B9590-0x00000001804B9600
	private void CloseWheelInfo(); // 0x00000001804B4910-0x00000001804B4930
	private static void Wire(Button b, UnityAction action); // 0x00000001804BC980-0x00000001804BCA20
	public void OpenWheelPanel(); // 0x00000001804B7F90-0x00000001804B8260
	public void SwitchKind(WheelKind kind, bool force); // 0x00000001804BBF30-0x00000001804BC1B0
	private void Reload(); // 0x00000001804B8E90-0x00000001804B8FD0
	[IteratorStateMachine(typeof(_LoadRoutine_d__91))]
	private IEnumerator LoadRoutine(IWheelSource source, WheelKind kind); // 0x00000001804B6A90-0x00000001804B6B30
	private void OnBoard(WheelBoardVM vm); // 0x00000001804B6B30-0x00000001804B6DD0
	private void OnLoadError(string error); // 0x00000001804B7370-0x00000001804B74B0
	private void UpdateLegacyLabels(WheelBoardVM vm); // 0x00000001804BC790-0x00000001804BC8A0
	private void ClearAllUI(); // 0x00000001804B4070-0x00000001804B41D0
	private void HideSubViews(); // 0x00000001804B5F40-0x00000001804B6050
	private void ShowPanelWithAnimation(); // 0x00000001804BA330-0x00000001804BA4B0
	public void ClosePanel(); // 0x00000001804B4630-0x00000001804B4910
	private void BuildWheel(WheelBoardVM vm); // 0x00000001804B3C30-0x00000001804B4070
	private void BindPieceTooltips(WheelBoardVM vm); // 0x00000001804B37D0-0x00000001804B3A00
	private static void HidePieceTooltip(); // 0x00000001804B5EF0-0x00000001804B5F40
	private static string SlotLabelText(WheelSlotVM s); // 0x00000001804BAA50-0x00000001804BAD10
	private static string StripAmountSuffix(string name); // 0x00000001804BBDE0-0x00000001804BBF30
	private Sprite SlotSprite(WheelSlotVM s); // 0x00000001804BAD10-0x00000001804BB4B0
	private Sprite FallbackIcon(); // 0x00000001804B5360-0x00000001804B5470
	private Sprite GetWeaponPieceSprite(); // 0x00000001804B5E20-0x00000001804B5EF0
	private Sprite GetStoneSprite(string elementType, int level); // 0x00000001804B5C60-0x00000001804B5E20
	private void StartSpin(int count); // 0x00000001804BB960-0x00000001804BBC60
	private void BeginSpin(int count); // 0x00000001804B3200-0x00000001804B37D0
	[IteratorStateMachine(typeof(_WaitToastRoutine_d__113))]
	private IEnumerator WaitToastRoutine(); // 0x00000001804BC910-0x00000001804BC980
	private void OnSpinOk(WheelSpinOutcome outcome, WheelKind kind); // 0x00000001804B7660-0x00000001804B79B0
	private void OnSpinError(string error, WheelKind kind); // 0x00000001804B7560-0x00000001804B7660
	private void AbortSpin(string message); // 0x00000001804B27B0-0x00000001804B28A0
	private void ApplyOutcomeToBoard(WheelSpinOutcome outcome); // 0x00000001804B2BE0-0x00000001804B2E70
	private void SyncHubWallet(WheelBoardVM vm); // 0x00000001804BC1B0-0x00000001804BC2D0
	private void OnWheelStopped(WheelSpinOutcome outcome); // 0x00000001804B79B0-0x00000001804B7CB0
	[IteratorStateMachine(typeof(_ShowResultsAfter_d__120))]
	private IEnumerator ShowResultsAfter(WheelSpinOutcome outcome); // 0x00000001804BA4B0-0x00000001804BA540
	private void ShowResults(WheelSpinOutcome outcome); // 0x00000001804BA540-0x00000001804BAA50
	private void OnResultGridClosed(); // 0x00000001804B74B0-0x00000001804B7560
	private static GachaRollItemDTO ItemOf(WheelResultVM r); // 0x00000001804B6910-0x00000001804B6A90
	private void ShowConfirmSpin(int spinCount); // 0x00000001804B9B70-0x00000001804B9EA0
	private void OnConfirmYes(); // 0x00000001804B7130-0x00000001804B7170
	private void OnConfirmNo(); // 0x00000001804B7110-0x00000001804B7130
	private void CloseConfirmPanel(); // 0x00000001804B4370-0x00000001804B44D0
	private void OnClickBonus(TreasureWheelBonusView view); // 0x00000001804B6DD0-0x00000001804B7110
	private void OpenRates(); // 0x00000001804B7D80-0x00000001804B7EF0
	private void OpenHistory(); // 0x00000001804B7CB0-0x00000001804B7D80
	private void PlayPointerTick(); // 0x00000001804B8590-0x00000001804B8770
	private void PlayPressFx(Button b); // 0x00000001804B8770-0x00000001804B8900
	private void PlayFlash(); // 0x00000001804B8260-0x00000001804B8590
	private void PlaySlotGlow(int slotIndex); // 0x00000001804B8B60-0x00000001804B8E90
	private bool IsRareResult(WheelResultVM r); // 0x00000001804B6830-0x00000001804B68A0
	private void PlayResultFx(WheelSpinOutcome outcome); // 0x00000001804B8900-0x00000001804B8B60
	private void StartResultGlow(string rarity); // 0x00000001804BB680-0x00000001804BB960
	private void StopResultGlow(); // 0x00000001804BBD10-0x00000001804BBDE0
	private void ShakePanel(); // 0x00000001804B9920-0x00000001804B9B70
	private static void ShakeButton(Button b); // 0x00000001804B96D0-0x00000001804B9920
	private void ClearListPanel(); // 0x00000001804B41D0-0x00000001804B42A0
	private void ClearListReward(); // 0x00000001804B42A0-0x00000001804B4370
	private void AddRewardToListPanel(WheelResultVM reward); // 0x00000001804B28A0-0x00000001804B2A00
	private GameObject SpawnRewardCell(Transform parent, WheelResultVM reward); // 0x00000001804BB4B0-0x00000001804BB680
	public static string FormatVND(long amount); // 0x00000001804B5840-0x00000001804B58C0
	private GameObject GetRewardPrefab(string prizeType); // 0x00000001804B58C0-0x00000001804B5C60
	private void ApplyRewardVisual(GameObject rewardObj, WheelResultVM reward); // 0x00000001804B2E70-0x00000001804B3110
	private static Image ResolveIconImage(GameObject rewardObj); // 0x00000001804B92C0-0x00000001804B9590
	private Sprite DailyRewardSprite(WheelResultVM reward); // 0x00000001804B4930-0x00000001804B4AB0
	private static bool IsShardType(string prizeType); // 0x00000001804B68A0-0x00000001804B6910
	private string BuildRewardCountLabel(WheelResultVM reward); // 0x00000001804B3A00-0x00000001804B3C30
	private void ShowNoticeResult(List<WheelResultVM> rewards); // 0x00000001804BA0E0-0x00000001804BA330
	private void ShowErrorMessage(string message); // 0x00000001804B9EA0-0x00000001804BA0E0
	private void AddRewardToNoticeResult(WheelResultVM reward); // 0x00000001804B2A00-0x00000001804B2BE0
	private void CloseNoticeResult(); // 0x00000001804B44D0-0x00000001804B4630
	private void FlushWeaponDropPopups(); // 0x00000001804B5720-0x00000001804B5840
	private void SetSpinInteractable(bool on); // 0x00000001804B9600-0x00000001804B96D0
	private static Transform FindDeep(Transform root, string nodeName); // 0x00000001804B5470-0x00000001804B5580
	private static UnityEngine.UI.Text FindText(Transform root, string nodeName); // 0x00000001804B5650-0x00000001804B5720
	private static Image FindImage(Transform root, string nodeName); // 0x00000001804B5580-0x00000001804B5650
	[CompilerGenerated]
	private void _InitializeButtons_b__81_0(); // 0x00000001804BC6B0-0x00000001804BC6C0
	[CompilerGenerated]
	private void _InitializeButtons_b__81_1(); // 0x00000001804BC6C0-0x00000001804BC6F0
	[CompilerGenerated]
	private void _ClosePanel_b__98_0(); // 0x00000001804BC500-0x00000001804BC6B0
	[CompilerGenerated]
	private bool _BindPieceTooltips_b__100_0(); // 0x00000001804BC2D0-0x00000001804BC3B0
	[CompilerGenerated]
	private void _CloseConfirmPanel_b__127_0(); // 0x00000001804BC3B0-0x00000001804BC430
	[CompilerGenerated]
	private void _OnClickBonus_b__128_0(string _); // 0x00000001804BC6F0-0x00000001804BC700
	[CompilerGenerated]
	private void _OnClickBonus_b__128_1(string e); // 0x00000001804BC700-0x00000001804BC790
	[CompilerGenerated]
	private void _CloseNoticeResult_b__156_0(); // 0x00000001804BC430-0x00000001804BC500
}

