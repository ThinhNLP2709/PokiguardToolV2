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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ManagerWheelDay : MonoBehaviour // TypeDefIndex: 1153
{
	// Fields
	public const string PANEL_KEY = "PanelWheelDay"; // Metadata: 0x005EF4F0
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
	private const int MAX_LABEL_CHARS = 12; // Metadata: 0x005EF4FE
	private static Sprite _weaponPieceSprite; // 0x08
	private static bool _weaponPieceLoaded; // 0x10
	private static readonly string[] IconNodeNames; // 0x18

	// Properties
	public bool IsSpinning { get; } // 0x00000001806A9AB0-0x00000001806A9AC0 
	public bool IsBusy { get; } // 0x00000001806A9AC0-0x00000001806A9CF0 
	public WheelKind CurrentKind { get; } // 0x00000001806A9CF0-0x00000001806A9D00 
	private int BulkCount { get; } // 0x00000001806AC770-0x00000001806AC7A0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass112_0 // TypeDefIndex: 1154
	{
		// Fields
		public ManagerWheelDay __4__this; // 0x10
		public WheelKind kind; // 0x18

		// Constructors
		public __c__DisplayClass112_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BeginSpin_b__0(WheelSpinOutcome o); // 0x00000001806BAEB0-0x00000001806BAEE0
		internal void _BeginSpin_b__1(string e); // 0x00000001806BAEE0-0x00000001806BB0A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass114_0 // TypeDefIndex: 1155
	{
		// Fields
		public ManagerWheelDay __4__this; // 0x10
		public WheelSpinOutcome outcome; // 0x18

		// Constructors
		public __c__DisplayClass114_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnSpinOk_b__0(); // 0x00000001806BB0A0-0x00000001806BB0D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass121_0 // TypeDefIndex: 1156
	{
		// Fields
		public ManagerWheelDay __4__this; // 0x10
		public int again; // 0x18

		// Constructors
		public __c__DisplayClass121_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShowResults_b__0(); // 0x00000001806BB0D0-0x00000001806BB100
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass133_0 // TypeDefIndex: 1157
	{
		// Fields
		public Image img; // 0x10
		public ManagerWheelDay __4__this; // 0x18

		// Constructors
		public __c__DisplayClass133_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayFlash_b__0(float v); // 0x00000001806BB100-0x00000001806BB280
		internal void _PlayFlash_b__1(); // 0x00000001806BB280-0x00000001806BB3F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass134_0 // TypeDefIndex: 1158
	{
		// Fields
		public GameObject go; // 0x10
		public Transform glow; // 0x18

		// Constructors
		public __c__DisplayClass134_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlaySlotGlow_b__0(); // 0x00000001806BB3F0-0x00000001806BB670
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass139_0 // TypeDefIndex: 1159
	{
		// Fields
		public Transform t; // 0x10
		public Vector3 basePos; // 0x18
		public ManagerWheelDay __4__this; // 0x28

		// Constructors
		public __c__DisplayClass139_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShakePanel_b__0(); // 0x00000001806BB670-0x00000001806BB720
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass140_0 // TypeDefIndex: 1160
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 basePos; // 0x18

		// Constructors
		public __c__DisplayClass140_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShakeButton_b__0(float t); // 0x00000001806BB720-0x00000001806BB870
		internal void _ShakeButton_b__1(); // 0x00000001806BB870-0x00000001806BB980
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass91_0 // TypeDefIndex: 1161
	{
		// Fields
		public WheelKind kind; // 0x10
		public ManagerWheelDay __4__this; // 0x18

		// Constructors
		public __c__DisplayClass91_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadRoutine_b__0(WheelBoardVM vm); // 0x00000001806BB980-0x00000001806BB9C0
		internal void _LoadRoutine_b__1(string e); // 0x00000001806BB9C0-0x00000001806BBA00
	}

	[CompilerGenerated]
	private sealed class _LoadRoutine_d__91 : IEnumerator<object> // TypeDefIndex: 1162
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WheelKind kind; // 0x20
		public ManagerWheelDay __4__this; // 0x28
		public IWheelSource source; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoutine_d__91(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001806BBA00-0x00000001806BBD30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806BBD30-0x00000001806BBD70
	}

	[CompilerGenerated]
	private sealed class _ScrollInfoNextFrame_d__83 : IEnumerator<object> // TypeDefIndex: 1163
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerWheelDay __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ScrollInfoNextFrame_d__83(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001806BBD70-0x00000001806BBF10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806BBF10-0x00000001806BBF50
	}

	[CompilerGenerated]
	private sealed class _ShowResultsAfter_d__120 : IEnumerator<object> // TypeDefIndex: 1164
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerWheelDay __4__this; // 0x20
		public WheelSpinOutcome outcome; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowResultsAfter_d__120(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001806BBF50-0x00000001806BC030
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806BC030-0x00000001806BC070
	}

	[CompilerGenerated]
	private sealed class _WaitToastRoutine_d__113 : IEnumerator<object> // TypeDefIndex: 1165
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerWheelDay __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitToastRoutine_d__113(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001806BC070-0x00000001806BC2F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806BC2F0-0x00000001806BC330
	}

	// Constructors
	public ManagerWheelDay(); // 0x00000001806B9F30-0x00000001806BA490
	static ManagerWheelDay(); // 0x00000001806BA490-0x00000001806BA670

	// Methods
	private void Awake(); // 0x00000001806A9D00-0x00000001806A9FA0
	private void Start(); // 0x00000001806A9FA0-0x00000001806AA1F0
	private void OnDisable(); // 0x00000001806AA1F0-0x00000001806AA450
	private void OnDestroy(); // 0x00000001806AA450-0x00000001806AA620
	private void Update(); // 0x00000001806AA620-0x00000001806AA850
	private void EnsureWired(); // 0x00000001806AA850-0x00000001806AB8E0
	private void RescueEmbeddedSubViews(); // 0x00000001806AB8E0-0x00000001806ABE90
	private void DisableLegacyGalaxyEmbed(); // 0x00000001806ABE90-0x00000001806AC0E0
	private void InitializeButtons(); // 0x00000001806AC0E0-0x00000001806AC4D0
	private void OpenWheelInfo(); // 0x00000001806AC4D0-0x00000001806AC5A0
	[IteratorStateMachine(typeof(_ScrollInfoNextFrame_d__83))]
	private IEnumerator ScrollInfoNextFrame(); // 0x00000001806AC5A0-0x00000001806AC640
	private void CloseWheelInfo(); // 0x00000001806AC640-0x00000001806AC660
	private static void Wire(Button b, UnityAction action); // 0x00000001806AC660-0x00000001806AC770
	public void OpenWheelPanel(); // 0x00000001806AC7A0-0x00000001806ACA10
	public void SwitchKind(WheelKind kind, bool force); // 0x00000001806ACA10-0x00000001806ACE90
	private void Reload(); // 0x00000001806ACE90-0x00000001806AD0C0
	[IteratorStateMachine(typeof(_LoadRoutine_d__91))]
	private IEnumerator LoadRoutine(IWheelSource source, WheelKind kind); // 0x00000001806AD0C0-0x00000001806AD1D0
	private void OnBoard(WheelBoardVM vm); // 0x00000001806AD1D0-0x00000001806AD420
	private void OnLoadError(string error); // 0x00000001806AD420-0x00000001806AD640
	private void UpdateLegacyLabels(WheelBoardVM vm); // 0x00000001806AD640-0x00000001806AD860
	private void ClearAllUI(); // 0x00000001806AD860-0x00000001806ADC00
	private void HideSubViews(); // 0x00000001806ADC00-0x00000001806ADF50
	private void ShowPanelWithAnimation(); // 0x00000001806ADF50-0x00000001806AE180
	public void ClosePanel(); // 0x00000001806AE180-0x00000001806AE580
	private void BuildWheel(WheelBoardVM vm); // 0x00000001806AE580-0x00000001806AEA20
	private void BindPieceTooltips(WheelBoardVM vm); // 0x00000001806AEA20-0x00000001806AED70
	private static void HidePieceTooltip(); // 0x00000001806AED70-0x00000001806AEDD0
	private static string SlotLabelText(WheelSlotVM s); // 0x00000001806AEDD0-0x00000001806AF090
	private static string StripAmountSuffix(string name); // 0x00000001806AF090-0x00000001806AF270
	private Sprite SlotSprite(WheelSlotVM s); // 0x00000001806AF270-0x00000001806AFF20
	private Sprite FallbackIcon(); // 0x00000001806AFF20-0x00000001806B0140
	private Sprite GetWeaponPieceSprite(); // 0x00000001806B0140-0x00000001806B0270
	private Sprite GetStoneSprite(string elementType, int level); // 0x00000001806B0270-0x00000001806B0520
	private void StartSpin(int count); // 0x00000001806B0520-0x00000001806B0850
	private void BeginSpin(int count); // 0x00000001806B0850-0x00000001806B0ED0
	[IteratorStateMachine(typeof(_WaitToastRoutine_d__113))]
	private IEnumerator WaitToastRoutine(); // 0x00000001806B0ED0-0x00000001806B0F70
	private void OnSpinOk(WheelSpinOutcome outcome, WheelKind kind); // 0x00000001806B0F70-0x00000001806B1540
	private void OnSpinError(string error, WheelKind kind); // 0x00000001806B1540-0x00000001806B1700
	private void AbortSpin(string message); // 0x00000001806B1700-0x00000001806B1A50
	private void ApplyOutcomeToBoard(WheelSpinOutcome outcome); // 0x00000001806B1A50-0x00000001806B1FE0
	private void SyncHubWallet(WheelBoardVM vm); // 0x00000001806B1FE0-0x00000001806B21D0
	private void OnWheelStopped(WheelSpinOutcome outcome); // 0x00000001806B21D0-0x00000001806B24E0
	[IteratorStateMachine(typeof(_ShowResultsAfter_d__120))]
	private IEnumerator ShowResultsAfter(WheelSpinOutcome outcome); // 0x00000001806B24E0-0x00000001806B25F0
	private void ShowResults(WheelSpinOutcome outcome); // 0x00000001806B25F0-0x00000001806B2BB0
	private void OnResultGridClosed(); // 0x00000001806B2BB0-0x00000001806B2CE0
	private static GachaRollItemDTO ItemOf(WheelResultVM r); // 0x00000001806B2CE0-0x00000001806B2F50
	private void ShowConfirmSpin(int spinCount); // 0x00000001806B2F50-0x00000001806B34A0
	private void OnConfirmYes(); // 0x00000001806B34A0-0x00000001806B34E0
	private void OnConfirmNo(); // 0x00000001806B34E0-0x00000001806B3500
	private void CloseConfirmPanel(); // 0x00000001806B3500-0x00000001806B36F0
	private void OnClickBonus(TreasureWheelBonusView view); // 0x00000001806B36F0-0x00000001806B3BB0
	private void OpenRates(); // 0x00000001806B3BB0-0x00000001806B3DC0
	private void OpenHistory(); // 0x00000001806B3DC0-0x00000001806B3F20
	private void PlayPointerTick(); // 0x00000001806B3F20-0x00000001806B4280
	private void PlayPressFx(Button b); // 0x00000001806B4280-0x00000001806B4530
	private void PlayFlash(); // 0x00000001806B4530-0x00000001806B49E0
	private void PlaySlotGlow(int slotIndex); // 0x00000001806B49E0-0x00000001806B50C0
	private bool IsRareResult(WheelResultVM r); // 0x00000001806B50C0-0x00000001806B5140
	private void PlayResultFx(WheelSpinOutcome outcome); // 0x00000001806B5140-0x00000001806B5640
	private void StartResultGlow(string rarity); // 0x00000001806B5640-0x00000001806B5B10
	private void StopResultGlow(); // 0x00000001806B5B10-0x00000001806B5D10
	private void ShakePanel(); // 0x00000001806B5D10-0x00000001806B60D0
	private static void ShakeButton(Button b); // 0x00000001806B60D0-0x00000001806B6450
	private void ClearListPanel(); // 0x00000001806B6450-0x00000001806B6710
	private void ClearListReward(); // 0x00000001806B6710-0x00000001806B69D0
	private void AddRewardToListPanel(WheelResultVM reward); // 0x00000001806B69D0-0x00000001806B6C00
	private GameObject SpawnRewardCell(Transform parent, WheelResultVM reward); // 0x00000001806B6C00-0x00000001806B7030
	public static string FormatVND(long amount); // 0x00000001806B7030-0x00000001806B7140
	private GameObject GetRewardPrefab(string prizeType); // 0x00000001806B7140-0x00000001806B7810
	private void ApplyRewardVisual(GameObject rewardObj, WheelResultVM reward); // 0x00000001806B7810-0x00000001806B7A20
	private static Image ResolveIconImage(GameObject rewardObj); // 0x00000001806B7A20-0x00000001806B7F90
	private Sprite DailyRewardSprite(WheelResultVM reward); // 0x00000001806B7F90-0x00000001806B8250
	private static bool IsShardType(string prizeType); // 0x00000001806B8250-0x00000001806B8320
	private string BuildRewardCountLabel(WheelResultVM reward); // 0x00000001806B8320-0x00000001806B8610
	private void ShowNoticeResult(List<WheelResultVM> rewards); // 0x00000001806B8610-0x00000001806B8BF0
	private void ShowErrorMessage(string message); // 0x00000001806B8BF0-0x00000001806B9040
	private void AddRewardToNoticeResult(WheelResultVM reward); // 0x00000001806B9040-0x00000001806B93C0
	private void CloseNoticeResult(); // 0x00000001806B93C0-0x00000001806B95B0
	private void FlushWeaponDropPopups(); // 0x00000001806B95B0-0x00000001806B9710
	private void SetSpinInteractable(bool on); // 0x00000001806B9710-0x00000001806B9A30
	private static Transform FindDeep(Transform root, string nodeName); // 0x00000001806B9A30-0x00000001806B9C90
	private static UnityEngine.UI.Text FindText(Transform root, string nodeName); // 0x00000001806B9C90-0x00000001806B9DE0
	private static Image FindImage(Transform root, string nodeName); // 0x00000001806B9DE0-0x00000001806B9F30
	[CompilerGenerated]
	private void _InitializeButtons_b__81_0(); // 0x00000001806BA670-0x00000001806BA680
	[CompilerGenerated]
	private void _InitializeButtons_b__81_1(); // 0x00000001806BA680-0x00000001806BA6B0
	[CompilerGenerated]
	private void _ClosePanel_b__98_0(); // 0x00000001806BA6B0-0x00000001806BA9B0
	[CompilerGenerated]
	private bool _BindPieceTooltips_b__100_0(); // 0x00000001806BA9B0-0x00000001806BAB10
	[CompilerGenerated]
	private void _CloseConfirmPanel_b__127_0(); // 0x00000001806BAB10-0x00000001806BAC60
	[CompilerGenerated]
	private void _OnClickBonus_b__128_0(string _); // 0x00000001806BAC60-0x00000001806BAC70
	[CompilerGenerated]
	private void _OnClickBonus_b__128_1(string e); // 0x00000001806BAC70-0x00000001806BAD10
	[CompilerGenerated]
	private void _CloseNoticeResult_b__156_0(); // 0x00000001806BAD10-0x00000001806BAEB0
}

