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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ManagerWheelDay : MonoBehaviour // TypeDefIndex: 1155
{
	// Fields
	public const string PANEL_KEY = "PanelWheelDay"; // Metadata: 0x005F08BD
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
	private const int MAX_LABEL_CHARS = 12; // Metadata: 0x005F08CB
	private static Sprite _weaponPieceSprite; // 0x08
	private static bool _weaponPieceLoaded; // 0x10
	private static readonly string[] IconNodeNames; // 0x18

	// Properties
	public bool IsSpinning { get; } // 0x00000001806AB590-0x00000001806AB5A0 
	public bool IsBusy { get; } // 0x00000001806AB5A0-0x00000001806AB7D0 
	public WheelKind CurrentKind { get; } // 0x00000001806AB7D0-0x00000001806AB7E0 
	private int BulkCount { get; } // 0x00000001806AE250-0x00000001806AE280 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass112_0 // TypeDefIndex: 1156
	{
		// Fields
		public ManagerWheelDay __4__this; // 0x10
		public WheelKind kind; // 0x18

		// Constructors
		public __c__DisplayClass112_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BeginSpin_b__0(WheelSpinOutcome o); // 0x00000001806BC9B0-0x00000001806BC9E0
		internal void _BeginSpin_b__1(string e); // 0x00000001806BC9E0-0x00000001806BCBA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass114_0 // TypeDefIndex: 1157
	{
		// Fields
		public ManagerWheelDay __4__this; // 0x10
		public WheelSpinOutcome outcome; // 0x18

		// Constructors
		public __c__DisplayClass114_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnSpinOk_b__0(); // 0x00000001806BCBA0-0x00000001806BCBD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass121_0 // TypeDefIndex: 1158
	{
		// Fields
		public ManagerWheelDay __4__this; // 0x10
		public int again; // 0x18

		// Constructors
		public __c__DisplayClass121_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShowResults_b__0(); // 0x00000001806BCBD0-0x00000001806BCC00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass133_0 // TypeDefIndex: 1159
	{
		// Fields
		public Image img; // 0x10
		public ManagerWheelDay __4__this; // 0x18

		// Constructors
		public __c__DisplayClass133_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayFlash_b__0(float v); // 0x00000001806BCC00-0x00000001806BCD80
		internal void _PlayFlash_b__1(); // 0x00000001806BCD80-0x00000001806BCEF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass134_0 // TypeDefIndex: 1160
	{
		// Fields
		public GameObject go; // 0x10
		public Transform glow; // 0x18

		// Constructors
		public __c__DisplayClass134_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlaySlotGlow_b__0(); // 0x00000001806BCEF0-0x00000001806BD170
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass139_0 // TypeDefIndex: 1161
	{
		// Fields
		public Transform t; // 0x10
		public Vector3 basePos; // 0x18
		public ManagerWheelDay __4__this; // 0x28

		// Constructors
		public __c__DisplayClass139_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShakePanel_b__0(); // 0x00000001806BD170-0x00000001806BD220
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass140_0 // TypeDefIndex: 1162
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 basePos; // 0x18

		// Constructors
		public __c__DisplayClass140_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShakeButton_b__0(float t); // 0x00000001806BD220-0x00000001806BD370
		internal void _ShakeButton_b__1(); // 0x00000001806BD370-0x00000001806BD480
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass91_0 // TypeDefIndex: 1163
	{
		// Fields
		public WheelKind kind; // 0x10
		public ManagerWheelDay __4__this; // 0x18

		// Constructors
		public __c__DisplayClass91_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadRoutine_b__0(WheelBoardVM vm); // 0x00000001806BD480-0x00000001806BD4C0
		internal void _LoadRoutine_b__1(string e); // 0x00000001806BD4C0-0x00000001806BD500
	}

	[CompilerGenerated]
	private sealed class _LoadRoutine_d__91 : IEnumerator<object> // TypeDefIndex: 1164
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001806BD500-0x00000001806BD830
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806BD830-0x00000001806BD870
	}

	[CompilerGenerated]
	private sealed class _ScrollInfoNextFrame_d__83 : IEnumerator<object> // TypeDefIndex: 1165
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001806BD870-0x00000001806BDA10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806BDA10-0x00000001806BDA50
	}

	[CompilerGenerated]
	private sealed class _ShowResultsAfter_d__120 : IEnumerator<object> // TypeDefIndex: 1166
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001806BDA50-0x00000001806BDB30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806BDB30-0x00000001806BDB70
	}

	[CompilerGenerated]
	private sealed class _WaitToastRoutine_d__113 : IEnumerator<object> // TypeDefIndex: 1167
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001806BDB70-0x00000001806BDDF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806BDDF0-0x00000001806BDE30
	}

	// Constructors
	public ManagerWheelDay(); // 0x00000001806BBA30-0x00000001806BBF90
	static ManagerWheelDay(); // 0x00000001806BBF90-0x00000001806BC170

	// Methods
	private void Awake(); // 0x00000001806AB7E0-0x00000001806ABA80
	private void Start(); // 0x00000001806ABA80-0x00000001806ABCD0
	private void OnDisable(); // 0x00000001806ABCD0-0x00000001806ABF30
	private void OnDestroy(); // 0x00000001806ABF30-0x00000001806AC100
	private void Update(); // 0x00000001806AC100-0x00000001806AC330
	private void EnsureWired(); // 0x00000001806AC330-0x00000001806AD3C0
	private void RescueEmbeddedSubViews(); // 0x00000001806AD3C0-0x00000001806AD970
	private void DisableLegacyGalaxyEmbed(); // 0x00000001806AD970-0x00000001806ADBC0
	private void InitializeButtons(); // 0x00000001806ADBC0-0x00000001806ADFB0
	private void OpenWheelInfo(); // 0x00000001806ADFB0-0x00000001806AE080
	[IteratorStateMachine(typeof(_ScrollInfoNextFrame_d__83))]
	private IEnumerator ScrollInfoNextFrame(); // 0x00000001806AE080-0x00000001806AE120
	private void CloseWheelInfo(); // 0x00000001806AE120-0x00000001806AE140
	private static void Wire(Button b, UnityAction action); // 0x00000001806AE140-0x00000001806AE250
	public void OpenWheelPanel(); // 0x00000001806AE280-0x00000001806AE4F0
	public void SwitchKind(WheelKind kind, bool force); // 0x00000001806AE4F0-0x00000001806AE970
	private void Reload(); // 0x00000001806AE970-0x00000001806AEBA0
	[IteratorStateMachine(typeof(_LoadRoutine_d__91))]
	private IEnumerator LoadRoutine(IWheelSource source, WheelKind kind); // 0x00000001806AEBA0-0x00000001806AECB0
	private void OnBoard(WheelBoardVM vm); // 0x00000001806AECB0-0x00000001806AEF00
	private void OnLoadError(string error); // 0x00000001806AEF00-0x00000001806AF120
	private void UpdateLegacyLabels(WheelBoardVM vm); // 0x00000001806AF120-0x00000001806AF340
	private void ClearAllUI(); // 0x00000001806AF340-0x00000001806AF6E0
	private void HideSubViews(); // 0x00000001806AF6E0-0x00000001806AFA30
	private void ShowPanelWithAnimation(); // 0x00000001806AFA30-0x00000001806AFC60
	public void ClosePanel(); // 0x00000001806AFC60-0x00000001806B0060
	private void BuildWheel(WheelBoardVM vm); // 0x00000001806B0060-0x00000001806B0500
	private void BindPieceTooltips(WheelBoardVM vm); // 0x00000001806B0500-0x00000001806B0850
	private static void HidePieceTooltip(); // 0x00000001806B0850-0x00000001806B08B0
	private static string SlotLabelText(WheelSlotVM s); // 0x00000001806B08B0-0x00000001806B0B70
	private static string StripAmountSuffix(string name); // 0x00000001806B0B70-0x00000001806B0D50
	private Sprite SlotSprite(WheelSlotVM s); // 0x00000001806B0D50-0x00000001806B1A00
	private Sprite FallbackIcon(); // 0x00000001806B1A00-0x00000001806B1C20
	private Sprite GetWeaponPieceSprite(); // 0x00000001806B1C20-0x00000001806B1D50
	private Sprite GetStoneSprite(string elementType, int level); // 0x00000001806B1D50-0x00000001806B2000
	private void StartSpin(int count); // 0x00000001806B2000-0x00000001806B2330
	private void BeginSpin(int count); // 0x00000001806B2330-0x00000001806B29D0
	[IteratorStateMachine(typeof(_WaitToastRoutine_d__113))]
	private IEnumerator WaitToastRoutine(); // 0x00000001806B29D0-0x00000001806B2A70
	private void OnSpinOk(WheelSpinOutcome outcome, WheelKind kind); // 0x00000001806B2A70-0x00000001806B3040
	private void OnSpinError(string error, WheelKind kind); // 0x00000001806B3040-0x00000001806B3200
	private void AbortSpin(string message); // 0x00000001806B3200-0x00000001806B3550
	private void ApplyOutcomeToBoard(WheelSpinOutcome outcome); // 0x00000001806B3550-0x00000001806B3AE0
	private void SyncHubWallet(WheelBoardVM vm); // 0x00000001806B3AE0-0x00000001806B3CD0
	private void OnWheelStopped(WheelSpinOutcome outcome); // 0x00000001806B3CD0-0x00000001806B3FE0
	[IteratorStateMachine(typeof(_ShowResultsAfter_d__120))]
	private IEnumerator ShowResultsAfter(WheelSpinOutcome outcome); // 0x00000001806B3FE0-0x00000001806B40F0
	private void ShowResults(WheelSpinOutcome outcome); // 0x00000001806B40F0-0x00000001806B46B0
	private void OnResultGridClosed(); // 0x00000001806B46B0-0x00000001806B47E0
	private static GachaRollItemDTO ItemOf(WheelResultVM r); // 0x00000001806B47E0-0x00000001806B4A50
	private void ShowConfirmSpin(int spinCount); // 0x00000001806B4A50-0x00000001806B4FA0
	private void OnConfirmYes(); // 0x00000001806B4FA0-0x00000001806B4FE0
	private void OnConfirmNo(); // 0x00000001806B4FE0-0x00000001806B5000
	private void CloseConfirmPanel(); // 0x00000001806B5000-0x00000001806B51F0
	private void OnClickBonus(TreasureWheelBonusView view); // 0x00000001806B51F0-0x00000001806B56B0
	private void OpenRates(); // 0x00000001806B56B0-0x00000001806B58C0
	private void OpenHistory(); // 0x00000001806B58C0-0x00000001806B5A20
	private void PlayPointerTick(); // 0x00000001806B5A20-0x00000001806B5D80
	private void PlayPressFx(Button b); // 0x00000001806B5D80-0x00000001806B6030
	private void PlayFlash(); // 0x00000001806B6030-0x00000001806B64E0
	private void PlaySlotGlow(int slotIndex); // 0x00000001806B64E0-0x00000001806B6BC0
	private bool IsRareResult(WheelResultVM r); // 0x00000001806B6BC0-0x00000001806B6C40
	private void PlayResultFx(WheelSpinOutcome outcome); // 0x00000001806B6C40-0x00000001806B7140
	private void StartResultGlow(string rarity); // 0x00000001806B7140-0x00000001806B7610
	private void StopResultGlow(); // 0x00000001806B7610-0x00000001806B7810
	private void ShakePanel(); // 0x00000001806B7810-0x00000001806B7BD0
	private static void ShakeButton(Button b); // 0x00000001806B7BD0-0x00000001806B7F50
	private void ClearListPanel(); // 0x00000001806B7F50-0x00000001806B8210
	private void ClearListReward(); // 0x00000001806B8210-0x00000001806B84D0
	private void AddRewardToListPanel(WheelResultVM reward); // 0x00000001806B84D0-0x00000001806B8700
	private GameObject SpawnRewardCell(Transform parent, WheelResultVM reward); // 0x00000001806B8700-0x00000001806B8B30
	public static string FormatVND(long amount); // 0x00000001806B8B30-0x00000001806B8C40
	private GameObject GetRewardPrefab(string prizeType); // 0x00000001806B8C40-0x00000001806B9310
	private void ApplyRewardVisual(GameObject rewardObj, WheelResultVM reward); // 0x00000001806B9310-0x00000001806B9520
	private static Image ResolveIconImage(GameObject rewardObj); // 0x00000001806B9520-0x00000001806B9A90
	private Sprite DailyRewardSprite(WheelResultVM reward); // 0x00000001806B9A90-0x00000001806B9D50
	private static bool IsShardType(string prizeType); // 0x00000001806B9D50-0x00000001806B9E20
	private string BuildRewardCountLabel(WheelResultVM reward); // 0x00000001806B9E20-0x00000001806BA110
	private void ShowNoticeResult(List<WheelResultVM> rewards); // 0x00000001806BA110-0x00000001806BA6F0
	private void ShowErrorMessage(string message); // 0x00000001806BA6F0-0x00000001806BAB40
	private void AddRewardToNoticeResult(WheelResultVM reward); // 0x00000001806BAB40-0x00000001806BAEC0
	private void CloseNoticeResult(); // 0x00000001806BAEC0-0x00000001806BB0B0
	private void FlushWeaponDropPopups(); // 0x00000001806BB0B0-0x00000001806BB210
	private void SetSpinInteractable(bool on); // 0x00000001806BB210-0x00000001806BB530
	private static Transform FindDeep(Transform root, string nodeName); // 0x00000001806BB530-0x00000001806BB790
	private static UnityEngine.UI.Text FindText(Transform root, string nodeName); // 0x00000001806BB790-0x00000001806BB8E0
	private static Image FindImage(Transform root, string nodeName); // 0x00000001806BB8E0-0x00000001806BBA30
	[CompilerGenerated]
	private void _InitializeButtons_b__81_0(); // 0x00000001806BC170-0x00000001806BC180
	[CompilerGenerated]
	private void _InitializeButtons_b__81_1(); // 0x00000001806BC180-0x00000001806BC1B0
	[CompilerGenerated]
	private void _ClosePanel_b__98_0(); // 0x00000001806BC1B0-0x00000001806BC4B0
	[CompilerGenerated]
	private bool _BindPieceTooltips_b__100_0(); // 0x00000001806BC4B0-0x00000001806BC610
	[CompilerGenerated]
	private void _CloseConfirmPanel_b__127_0(); // 0x00000001806BC610-0x00000001806BC760
	[CompilerGenerated]
	private void _OnClickBonus_b__128_0(string _); // 0x00000001806BC760-0x00000001806BC770
	[CompilerGenerated]
	private void _OnClickBonus_b__128_1(string e); // 0x00000001806BC770-0x00000001806BC810
	[CompilerGenerated]
	private void _CloseNoticeResult_b__156_0(); // 0x00000001806BC810-0x00000001806BC9B0
}

