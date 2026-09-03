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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerWheelDay : MonoBehaviour // TypeDefIndex: 704
{
	// Fields
	public const string PANEL_KEY = "PanelWheelDay"; // Metadata: 0x0064C817
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
	private int _closeTweenId; // 0x1E0
	private int _shakeTweenId; // 0x1E4
	private int _flashTweenId; // 0x1E8
	private const int MAX_LABEL_CHARS = 12; // Metadata: 0x0064C825
	private static Sprite _weaponPieceSprite; // 0x08
	private static bool _weaponPieceLoaded; // 0x10
	private static readonly string[] IconNodeNames; // 0x18

	// Properties
	public bool IsSpinning { get; } // 0x00000001803DFF30-0x00000001803DFF40 
	public bool IsBusy { get; } // 0x00000001803DFE20-0x00000001803DFF30 
	public WheelKind CurrentKind { get; } // 0x000000018033D650-0x000000018033D660 
	private int BulkCount { get; } // 0x00000001803DFDF0-0x00000001803DFE20 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass106_0 // TypeDefIndex: 705
	{
		// Fields
		public ManagerWheelDay __4__this; // 0x10
		public WheelKind kind; // 0x18

		// Constructors
		public __c__DisplayClass106_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _BeginSpin_b__0(WheelSpinOutcome o); // 0x00000001803EF2B0-0x00000001803EF2E0
		internal void _BeginSpin_b__1(string e); // 0x00000001803EF2E0-0x00000001803EF3F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass108_0 // TypeDefIndex: 706
	{
		// Fields
		public ManagerWheelDay __4__this; // 0x10
		public WheelSpinOutcome outcome; // 0x18

		// Constructors
		public __c__DisplayClass108_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OnSpinOk_b__0(); // 0x00000001803EF3F0-0x00000001803EF420
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass115_0 // TypeDefIndex: 707
	{
		// Fields
		public ManagerWheelDay __4__this; // 0x10
		public int again; // 0x18

		// Constructors
		public __c__DisplayClass115_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ShowResults_b__0(); // 0x00000001803EF420-0x00000001803EF450
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass127_0 // TypeDefIndex: 708
	{
		// Fields
		public Image img; // 0x10
		public ManagerWheelDay __4__this; // 0x18

		// Constructors
		public __c__DisplayClass127_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayFlash_b__0(float v); // 0x00000001803EF450-0x00000001803EF540
		internal void _PlayFlash_b__1(); // 0x00000001803EF540-0x00000001803EF5E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass128_0 // TypeDefIndex: 709
	{
		// Fields
		public GameObject go; // 0x10
		public Transform glow; // 0x18

		// Constructors
		public __c__DisplayClass128_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlaySlotGlow_b__0(); // 0x00000001803EF5E0-0x00000001803EF6B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass133_0 // TypeDefIndex: 710
	{
		// Fields
		public Transform t; // 0x10
		public Vector3 basePos; // 0x18
		public ManagerWheelDay __4__this; // 0x28

		// Constructors
		public __c__DisplayClass133_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ShakePanel_b__0(); // 0x00000001803EF6B0-0x00000001803EF700
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass134_0 // TypeDefIndex: 711
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 basePos; // 0x18

		// Constructors
		public __c__DisplayClass134_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ShakeButton_b__0(float t); // 0x00000001803EF700-0x00000001803EF7D0
		internal void _ShakeButton_b__1(); // 0x00000001803EF7D0-0x00000001803EF860
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass87_0 // TypeDefIndex: 712
	{
		// Fields
		public WheelKind kind; // 0x10
		public ManagerWheelDay __4__this; // 0x18

		// Constructors
		public __c__DisplayClass87_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadRoutine_b__0(WheelBoardVM vm); // 0x00000001803EFDC0-0x00000001803EFE00
		internal void _LoadRoutine_b__1(string e); // 0x00000001803EFE00-0x00000001803EFF50
	}

	[CompilerGenerated]
	private sealed class _LoadRoutine_d__87 : IEnumerator<object> // TypeDefIndex: 713
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public WheelKind kind; // 0x20
		public ManagerWheelDay __4__this; // 0x28
		public IWheelSource source; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoutine_d__87(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803EE780-0x00000001803EE9A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803EE9A0-0x00000001803EE9E0
	}

	[CompilerGenerated]
	private sealed class _ShowResultsAfter_d__114 : IEnumerator<object> // TypeDefIndex: 714
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerWheelDay __4__this; // 0x20
		public WheelSpinOutcome outcome; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ShowResultsAfter_d__114(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803EE9E0-0x00000001803EEA90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803EEA90-0x00000001803EEAD0
	}

	[CompilerGenerated]
	private sealed class _WaitToastRoutine_d__107 : IEnumerator<object> // TypeDefIndex: 715
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerWheelDay __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitToastRoutine_d__107(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803F02A0-0x00000001803F0400
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803F0400-0x00000001803F0520
	}

	// Constructors
	public ManagerWheelDay(); // 0x00000001803DFBD0-0x00000001803DFDF0
	static ManagerWheelDay(); // 0x00000001803DFA20-0x00000001803DFBD0

	// Methods
	private void Awake(); // 0x00000001803D6AD0-0x00000001803D6BC0
	private void Start(); // 0x00000001803DEDC0-0x00000001803DEE70
	private void OnDisable(); // 0x00000001803DA5D0-0x00000001803DA6B0
	private void OnDestroy(); // 0x00000001803DA510-0x00000001803DA5D0
	private void Update(); // 0x00000001803DF8A0-0x00000001803DF910
	private void EnsureWired(); // 0x00000001803D81B0-0x00000001803D8990
	private void RescueEmbeddedSubViews(); // 0x00000001803DC1F0-0x00000001803DC4E0
	private void DisableLegacyGalaxyEmbed(); // 0x00000001803D80E0-0x00000001803D81B0
	private void InitializeButtons(); // 0x00000001803D9610-0x00000001803D9C60
	private static void Wire(Button b, UnityAction action); // 0x00000001803DF980-0x00000001803DFA20
	public void OpenWheelPanel(); // 0x00000001803DB1C0-0x00000001803DB490
	public void SwitchKind(WheelKind kind, bool force); // 0x00000001803DF090-0x00000001803DF290
	private void Reload(); // 0x00000001803DC0C0-0x00000001803DC1F0
	[IteratorStateMachine(typeof(_LoadRoutine_d__87))]
	private IEnumerator LoadRoutine(IWheelSource source, WheelKind kind); // 0x00000001803D9E90-0x00000001803D9F30
	private void OnBoard(WheelBoardVM vm); // 0x00000001803D9F30-0x00000001803DA170
	private void OnLoadError(string error); // 0x00000001803DA6B0-0x00000001803DA7E0
	private void UpdateLegacyLabels(WheelBoardVM vm); // 0x00000001803DF790-0x00000001803DF8A0
	private void ClearAllUI(); // 0x00000001803D7780-0x00000001803D78E0
	private void HideSubViews(); // 0x00000001803D9500-0x00000001803D9610
	private void ShowPanelWithAnimation(); // 0x00000001803DD4E0-0x00000001803DD660
	public void ClosePanel(); // 0x00000001803D7D40-0x00000001803D7F60
	private void BuildWheel(WheelBoardVM vm); // 0x00000001803D7350-0x00000001803D7780
	private static string SlotLabelText(WheelSlotVM s); // 0x00000001803DDBD0-0x00000001803DDE90
	private static string StripAmountSuffix(string name); // 0x00000001803DEF40-0x00000001803DF090
	private Sprite SlotSprite(WheelSlotVM s); // 0x00000001803DDE90-0x00000001803DE620
	private Sprite FallbackIcon(); // 0x00000001803D8990-0x00000001803D8AA0
	private Sprite GetWeaponPieceSprite(); // 0x00000001803D9430-0x00000001803D9500
	private Sprite GetStoneSprite(string elementType, int level); // 0x00000001803D9270-0x00000001803D9430
	private void StartSpin(int count); // 0x00000001803DEAD0-0x00000001803DEDC0
	private void BeginSpin(int count); // 0x00000001803D6BC0-0x00000001803D7120
	[IteratorStateMachine(typeof(_WaitToastRoutine_d__107))]
	private IEnumerator WaitToastRoutine(); // 0x00000001803DF910-0x00000001803DF980
	private void OnSpinOk(WheelSpinOutcome outcome, WheelKind kind); // 0x00000001803DA990-0x00000001803DACE0
	private void OnSpinError(string error, WheelKind kind); // 0x00000001803DA890-0x00000001803DA990
	private void AbortSpin(string message); // 0x00000001803D61C0-0x00000001803D62B0
	private void ApplyOutcomeToBoard(WheelSpinOutcome outcome); // 0x00000001803D65F0-0x00000001803D6830
	private void SyncHubWallet(WheelBoardVM vm); // 0x00000001803DF290-0x00000001803DF3B0
	private void OnWheelStopped(WheelSpinOutcome outcome); // 0x00000001803DACE0-0x00000001803DAF80
	[IteratorStateMachine(typeof(_ShowResultsAfter_d__114))]
	private IEnumerator ShowResultsAfter(WheelSpinOutcome outcome); // 0x00000001803DD660-0x00000001803DD6F0
	private void ShowResults(WheelSpinOutcome outcome); // 0x00000001803DD6F0-0x00000001803DDBD0
	private void OnResultGridClosed(); // 0x00000001803DA7E0-0x00000001803DA890
	private static GachaRollItemDTO ItemOf(WheelResultVM r); // 0x00000001803D9D40-0x00000001803D9E90
	private void ShowConfirmSpin(int spinCount); // 0x00000001803DCD20-0x00000001803DD050
	private void OnConfirmYes(); // 0x00000001803DA4D0-0x00000001803DA510
	private void OnConfirmNo(); // 0x00000001803DA4B0-0x00000001803DA4D0
	private void CloseConfirmPanel(); // 0x00000001803D7A80-0x00000001803D7BE0
	private void OnClickBonus(TreasureWheelBonusView view); // 0x00000001803DA170-0x00000001803DA4B0
	private void OpenRates(); // 0x00000001803DB050-0x00000001803DB1C0
	private void OpenHistory(); // 0x00000001803DAF80-0x00000001803DB050
	private void PlayPointerTick(); // 0x00000001803DB7C0-0x00000001803DB9A0
	private void PlayPressFx(Button b); // 0x00000001803DB9A0-0x00000001803DBB30
	private void PlayFlash(); // 0x00000001803DB490-0x00000001803DB7C0
	private void PlaySlotGlow(int slotIndex); // 0x00000001803DBD90-0x00000001803DC0C0
	private bool IsRareResult(WheelResultVM r); // 0x00000001803D9C60-0x00000001803D9CD0
	private void PlayResultFx(WheelSpinOutcome outcome); // 0x00000001803DBB30-0x00000001803DBD90
	private void StartResultGlow(string rarity); // 0x00000001803DE7F0-0x00000001803DEAD0
	private void StopResultGlow(); // 0x00000001803DEE70-0x00000001803DEF40
	private void ShakePanel(); // 0x00000001803DCAD0-0x00000001803DCD20
	private static void ShakeButton(Button b); // 0x00000001803DC880-0x00000001803DCAD0
	private void ClearListPanel(); // 0x00000001803D78E0-0x00000001803D79B0
	private void ClearListReward(); // 0x00000001803D79B0-0x00000001803D7A80
	private void AddRewardToListPanel(WheelResultVM reward); // 0x00000001803D62B0-0x00000001803D6410
	private GameObject SpawnRewardCell(Transform parent, WheelResultVM reward); // 0x00000001803DE620-0x00000001803DE7F0
	public static string FormatVND(long amount); // 0x00000001803D8E70-0x00000001803D8EF0
	private GameObject GetRewardPrefab(string prizeType); // 0x00000001803D8EF0-0x00000001803D9270
	private void ApplyRewardVisual(GameObject rewardObj, WheelResultVM reward); // 0x00000001803D6830-0x00000001803D6AD0
	private static Image ResolveIconImage(GameObject rewardObj); // 0x00000001803DC4E0-0x00000001803DC7B0
	private Sprite DailyRewardSprite(WheelResultVM reward); // 0x00000001803D7F60-0x00000001803D80E0
	private static bool IsShardType(string prizeType); // 0x00000001803D9CD0-0x00000001803D9D40
	private string BuildRewardCountLabel(WheelResultVM reward); // 0x00000001803D7120-0x00000001803D7350
	private void ShowNoticeResult(List<WheelResultVM> rewards); // 0x00000001803DD290-0x00000001803DD4E0
	private void ShowErrorMessage(string message); // 0x00000001803DD050-0x00000001803DD290
	private void AddRewardToNoticeResult(WheelResultVM reward); // 0x00000001803D6410-0x00000001803D65F0
	private void CloseNoticeResult(); // 0x00000001803D7BE0-0x00000001803D7D40
	private void FlushWeaponDropPopups(); // 0x00000001803D8D50-0x00000001803D8E70
	private void SetSpinInteractable(bool on); // 0x00000001803DC7B0-0x00000001803DC880
	private static Transform FindDeep(Transform root, string nodeName); // 0x00000001803D8AA0-0x00000001803D8BB0
	private static UnityEngine.UI.Text FindText(Transform root, string nodeName); // 0x00000001803D8C80-0x00000001803D8D50
	private static Image FindImage(Transform root, string nodeName); // 0x00000001803D8BB0-0x00000001803D8C80
	[CompilerGenerated]
	private void _InitializeButtons_b__80_0(); // 0x00000001803DF6B0-0x00000001803DF6C0
	[CompilerGenerated]
	private void _InitializeButtons_b__80_1(); // 0x00000001803DF6C0-0x00000001803DF6F0
	[CompilerGenerated]
	private void _ClosePanel_b__94_0(); // 0x00000001803DF500-0x00000001803DF6B0
	[CompilerGenerated]
	private void _CloseConfirmPanel_b__121_0(); // 0x00000001803DF3B0-0x00000001803DF430
	[CompilerGenerated]
	private void _OnClickBonus_b__122_0(string _); // 0x00000001803DF6F0-0x00000001803DF700
	[CompilerGenerated]
	private void _OnClickBonus_b__122_1(string e); // 0x00000001803DF700-0x00000001803DF790
	[CompilerGenerated]
	private void _CloseNoticeResult_b__150_0(); // 0x00000001803DF430-0x00000001803DF500
}

