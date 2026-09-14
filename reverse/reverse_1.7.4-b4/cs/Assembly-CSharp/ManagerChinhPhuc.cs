/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ManagerChinhPhuc : MonoBehaviour // TypeDefIndex: 1951
{
	// Fields
	public GameObject LoadingPanel; // 0x20
	public GameObject[] panels; // 0x28
	public Button[] buttons; // 0x30
	public GameObject panelMain; // 0x38
	public GameObject backBtn; // 0x40
	public UnityEngine.UI.Text txtVang; // 0x48
	public UnityEngine.UI.Text txtCt; // 0x50
	public UnityEngine.UI.Text txtNl; // 0x58
	public GameObject notice; // 0x60
	public Button cancleNotice; // 0x68
	[Header("UI")]
	[SerializeField]
	private Material grayscaleUIMaterial; // 0x70
	[Header("Animation Settings")]
	[SerializeField]
	private float buttonPopDelay; // 0x78
	[SerializeField]
	private float panelSlideSpeed; // 0x7C
	[SerializeField]
	private bool enableParticleEffects; // 0x80
	private Material _runtimeGrayMat; // 0x88
	private bool isDataLoaded; // 0x90
	private List<GroupDTO> cachedPetData; // 0x98
	[Header("Close Button")]
	public Button btnClose; // 0xA0
	private bool _subscribedToService; // 0xA8
	private const float IslandPopTime = 0.16f; // Metadata: 0x005F16DC
	private const float IslandStaggerTotal = 0.12f; // Metadata: 0x005F16E0
	private const float PanelEnterTime = 0.12f; // Metadata: 0x005F16E4
	private readonly Dictionary<int, bool> _lastLockedByPetId; // 0xB0
	[Header("Transition")]
	public GameObject fadeOverlay; // 0xB8
	private const float BackFadeOutTime = 0.12f; // Metadata: 0x005F16E8
	private const float BackFadeInTime = 0.16f; // Metadata: 0x005F16EC
	private static bool _grayShaderWarned; // 0x00
	private const string NODE_BADGE_LAYER = "huntBadgeLayer"; // Metadata: 0x005F16F0
	private const string NODE_BADGE_HOST = "cell"; // Metadata: 0x005F16FF
	private Sprite _huntBadgeBg; // 0xC0
	private Sprite[] _huntDigitSprites; // 0xC8
	private const string NODE_ORDER_TAP = "tapInfo"; // Metadata: 0x005F1704
	private const float ORDER_TAP_PAD = 1f; // Metadata: 0x005F170C
	private const string NODE_SWEEP = "btnSweep"; // Metadata: 0x005F1710
	private const string SWEEP_BADGE_SPRITE = "Image/FriendUI/btnHelp"; // Metadata: 0x005F1719
	private const float SWEEP_BADGE_TAP = 48f; // Metadata: 0x005F1730
	private const float SWEEP_BADGE_ICON = 42f; // Metadata: 0x005F1734
	private const float SWEEP_BADGE_X = 16f; // Metadata: 0x005F1738
	private const float SWEEP_BADGE_Y = -66f; // Metadata: 0x005F173C
	private static readonly string[] SWEEP_TIERS; // 0x08
	private static readonly long[] SWEEP_ITEM_IDS; // 0x10
	private const string NODE_SWEEP_HUD = "sweepTicketHud"; // Metadata: 0x005F1740
	private const string SWEEP_HUD_PLATE_SPRITE = "Image/item/sweep_plate"; // Metadata: 0x005F174F
	private const float SWEEP_HUD_W = 360f; // Metadata: 0x005F1766
	private const float SWEEP_HUD_H = 56f; // Metadata: 0x005F176A
	private const float SWEEP_HUD_OFFSET_X = 50f; // Metadata: 0x005F176E
	private const float SWEEP_HUD_MARGIN_Y = 8f; // Metadata: 0x005F1772
	private const float SWEEP_HUD_ICON = 48f; // Metadata: 0x005F1776
	private const int SWEEP_HUD_FS_NUM = 32; // Metadata: 0x005F177A
	private int _sweepFirstUnlockedPetId; // 0xD0
	private int _sweepHudAskedForPetId; // 0xD4
	private RectTransform _sweepHud; // 0xD8
	private readonly UnityEngine.UI.Text[] _sweepHudCounts; // 0xE0
	private readonly Image[] _sweepHudIcons; // 0xE8
	private bool _sweepEventsBound; // 0xF0
	private const string IslandLockBadgeName = "islandLockBadge"; // Metadata: 0x005F177B

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass110_0 // TypeDefIndex: 1952
	{
		// Fields
		public int tierIndex; // 0x10
		public RectTransform iconRect; // 0x18

		// Constructors
		public __c__DisplayClass110_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _EnsureSweepHud_b__0(); // 0x000000018097D210-0x000000018097D280
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 1953
	{
		// Fields
		public int index; // 0x10
		public ManagerChinhPhuc __4__this; // 0x18

		// Constructors
		public __c__DisplayClass19_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Start_b__0(); // 0x000000018097D280-0x000000018097D2B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 1954
	{
		// Fields
		public GameObject mainPanel; // 0x10

		// Constructors
		public __c__DisplayClass26_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ClosePanel_b__0(); // 0x000000018097D2B0-0x000000018097D3D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass29_0 // TypeDefIndex: 1955
	{
		// Fields
		public GameObject panel; // 0x10

		// Constructors
		public __c__DisplayClass29_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayPanelEnter_b__0(); // 0x000000018097D3D0-0x000000018097D550
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass32_0 // TypeDefIndex: 1956
	{
		// Fields
		public List<GroupDTO> loadedData; // 0x10
		public bool apiCompleted; // 0x18
		public string errorMessage; // 0x20

		// Constructors
		public __c__DisplayClass32_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadDataCoroutine_b__0(List<GroupDTO> data); // 0x000000018076F420-0x000000018076F480
		internal void _LoadDataCoroutine_b__1(string error); // 0x000000018097D550-0x000000018097D630
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass39_0 // TypeDefIndex: 1957
	{
		// Fields
		public UnityEngine.UI.Text text; // 0x10
		public Color originalColor; // 0x18

		// Constructors
		public __c__DisplayClass39_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AnimateTextFadeIn_b__0(float val); // 0x000000018097D630-0x000000018097D6A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 1958
	{
		// Fields
		public GameObject buttonObj; // 0x10

		// Constructors
		public __c__DisplayClass40_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AddButtonHoverEffect_b__0(BaseEventData data); // 0x000000018097D6A0-0x000000018097D7C0
		internal void _AddButtonHoverEffect_b__1(BaseEventData data); // 0x000000018097D7C0-0x000000018097D8C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass41_0 // TypeDefIndex: 1959
	{
		// Fields
		public bool lockedForClick; // 0x10
		public string islandLockMsg; // 0x18
		public int lockedOrderForClick; // 0x20
		public int requiredAttack; // 0x24
		public int petId; // 0x28
		public string reA; // 0x30
		public ManagerChinhPhuc __4__this; // 0x38

		// Constructors
		public __c__DisplayClass41_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnReceived_b__0(); // 0x000000018097D8C0-0x000000018097D9F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass44_0 // TypeDefIndex: 1960
	{
		// Fields
		public GameObject btnObj; // 0x10

		// Constructors
		public __c__DisplayClass44_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayUnlockPunch_b__0(); // 0x000000018097D9F0-0x000000018097DB70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 1961
	{
		// Fields
		public int petId; // 0x10
		public Func<PetEnemyDTO, bool> __9__0; // 0x18

		// Constructors
		public __c__DisplayClass47_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _OpenRoomWithPetRoutine_b__0(PetEnemyDTO p); // 0x000000018097DB70-0x000000018097DB90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass48_0 // TypeDefIndex: 1962
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10

		// Constructors
		public __c__DisplayClass48_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AnimateNumberCount_b__0(float val); // 0x000000018097DB90-0x000000018097DC40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass49_0 // TypeDefIndex: 1963
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10
		public Vector3 originalScale; // 0x18

		// Constructors
		public __c__DisplayClass49_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AnimateTextPulse_b__0(); // 0x000000018097DC40-0x000000018097DCF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass78_0 // TypeDefIndex: 1964
	{
		// Fields
		public RectTransform anchorRt; // 0x10
		public PetEnemyDTO pet; // 0x18
		public int order; // 0x20
		public Image icon; // 0x28
		public HuntBossInfoTip.State st; // 0x30

		// Constructors
		public __c__DisplayClass78_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _EnsureOrderBadgeTap_b__0(); // 0x000000018097DCF0-0x000000018097DF50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass85_0 // TypeDefIndex: 1965
	{
		// Fields
		public int petId; // 0x10
		public string petName; // 0x18
		public int lv; // 0x20
		public RectTransform anchorRt; // 0x28

		// Constructors
		public __c__DisplayClass85_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _EnsureSweepBadge_b__0(); // 0x000000018097DF50-0x000000018097E190
	}

	[CompilerGenerated]
	private sealed class _AnimatePanelContent_d__56 : IEnumerator<object> // TypeDefIndex: 1966
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject panel; // 0x20
		public ManagerChinhPhuc __4__this; // 0x28
		private Button[] _panelButtons_5__2; // 0x30
		private int _i_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AnimatePanelContent_d__56(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x000000018097E190-0x000000018097E570
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018097E570-0x000000018097E5B0
	}

	[CompilerGenerated]
	private sealed class _BackSceneWithFade_d__53 : IEnumerator<object> // TypeDefIndex: 1967
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerChinhPhuc __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _BackSceneWithFade_d__53(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018097E5B0-0x000000018097EF20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018097EF20-0x000000018097EF60
	}

	[CompilerGenerated]
	private sealed class _FetchSweepHud_d__107 : IEnumerator<object> // TypeDefIndex: 1968
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerChinhPhuc __4__this; // 0x20
		public int petId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FetchSweepHud_d__107(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018097EF60-0x000000018097F240
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018097F240-0x000000018097F280
	}

	[CompilerGenerated]
	private sealed class _LoadDataCoroutine_d__32 : IEnumerator<object> // TypeDefIndex: 1969
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerChinhPhuc __4__this; // 0x20
		public Action onComplete; // 0x28
		private __c__DisplayClass32_0 __8__1; // 0x30
		private bool _isRestoring_5__2; // 0x38
		private ChinhPhucDataService _svc_5__3; // 0x40
		private float _deadline_5__4; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadDataCoroutine_d__32(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803E1CC0-0x00000001803E1D80
		private bool MoveNext(); // 0x000000018097F280-0x0000000180980010
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180980010-0x0000000180980050
	}

	[CompilerGenerated]
	private sealed class _OpenRoomWithPetRoutine_d__47 : IEnumerator<object> // TypeDefIndex: 1970
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int petId; // 0x20
		private __c__DisplayClass47_0 __8__1; // 0x28
		public ManagerChinhPhuc __4__this; // 0x30
		public ManagerRoom flow; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _OpenRoomWithPetRoutine_d__47(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180980050-0x0000000180980520
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180980520-0x0000000180980560
	}

	// Constructors
	public ManagerChinhPhuc(); // 0x00000001809583C0-0x0000000180958650
	static ManagerChinhPhuc(); // 0x0000000180958650-0x0000000180958860

	// Methods
	private void Start(); // 0x0000000180945590-0x0000000180945C80
	private void OnEnable(); // 0x0000000180945C80-0x0000000180945D40
	private void RebindIfServiceDataChanged(); // 0x0000000180945D40-0x0000000180945E10
	private void OnDisable(); // 0x0000000180945E10-0x0000000180945FA0
	private void SubscribeServiceEvents(); // 0x0000000180945FA0-0x0000000180946200
	private void UnsubscribeServiceEvents(); // 0x0000000180946200-0x0000000180946460
	private void HandleServiceDataChanged(); // 0x0000000180946460-0x00000001809465F0
	public void ClosePanel(); // 0x00000001809465F0-0x0000000180946800
	public void RestoreState(int panelIndex); // 0x0000000180946800-0x0000000180946FB0
	public void ShowPanel(int index, bool withAnimation = true /* Metadata: 0x005F16DA */); // 0x0000000180946FB0-0x0000000180947770
	private void PlayPanelEnter(GameObject panel); // 0x0000000180947770-0x0000000180947AF0
	public void InitializeAndLoadData(Action onComplete = null); // 0x0000000180947AF0-0x0000000180947C10
	public void InvalidateCache(); // 0x0000000180947C10-0x0000000180947CC0
	[IteratorStateMachine(typeof(_LoadDataCoroutine_d__32))]
	private IEnumerator LoadDataCoroutine(Action onComplete); // 0x0000000180947CC0-0x0000000180947DD0
	private void ShowLoadingPanel(); // 0x0000000180947DD0-0x00000001809480C0
	private void HideLoadingPanel(); // 0x00000001809480C0-0x0000000180948310
	private void AnimateInitialUI(); // 0x0000000180948310-0x00000001809488E0
	private void AnimateTextFadeIn(UnityEngine.UI.Text text, float delay); // 0x00000001809488E0-0x0000000180948BD0
	private void AddButtonHoverEffect(GameObject buttonObj); // 0x0000000180948BD0-0x0000000180949040
	public void OnReceived(List<GroupDTO> petE); // 0x0000000180949040-0x000000018094AFA0
	private static bool HasServerLockFlags(GroupDTO group); // 0x000000018094AFA0-0x000000018094B010
	private void PlayUnlockPunch(GameObject btnObj); // 0x000000018094B010-0x000000018094B380
	private void AddPetButtonAnimation(GameObject btnObj); // 0x000000018094B380-0x000000018094B530
	private void OpenRoomWithPet(int petId, string reA); // 0x000000018094B530-0x000000018094B7A0
	[IteratorStateMachine(typeof(_OpenRoomWithPetRoutine_d__47))]
	private IEnumerator OpenRoomWithPetRoutine(int petId, string reA, ManagerRoom flow); // 0x000000018094B7A0-0x000000018094B8B0
	private void AnimateNumberCount(UnityEngine.UI.Text textComponent, int targetValue); // 0x000000018094B8B0-0x000000018094BBD0
	private void AnimateTextPulse(UnityEngine.UI.Text textComponent); // 0x000000018094BBD0-0x000000018094BF00
	private void OnError(string error); // 0x000000018094BF00-0x000000018094C080
	public void BackScene(); // 0x000000018094C080-0x000000018094C130
	[IteratorStateMachine(typeof(_BackSceneWithFade_d__53))]
	private IEnumerator BackSceneWithFade(); // 0x000000018094C130-0x000000018094C1D0
	[IteratorStateMachine(typeof(_AnimatePanelContent_d__56))]
	private IEnumerator AnimatePanelContent(GameObject panel); // 0x000000018094C1D0-0x000000018094C2E0
	public void HideAllPanels(); // 0x000000018094C2E0-0x000000018094C5E0
	private void ToggleNotice(); // 0x000000018094C5E0-0x000000018094C890
	private void ShowNoticeWithAnimation(string message = "" /* Metadata: 0x005F16DB */); // 0x000000018094C890-0x000000018094CCC0
	private void HideNoticeWithAnimation(); // 0x000000018094CCC0-0x000000018094CE00
	private void EnsureGrayMaterial(); // 0x000000018094CE00-0x000000018094D110
	private RectTransform EnsureBadgeLayer(GameObject panel, Button[] cells); // 0x000000018094D110-0x000000018094DBD0
	private RectTransform EnsureBadgeHost(RectTransform layer, Transform cell, int cellIndex); // 0x000000018094DBD0-0x000000018094E180
	private static void SetBadgeHostActive(RectTransform layer, int cellIndex, bool active); // 0x000000018094E180-0x000000018094E4E0
	private static void MirrorCellRect(RectTransform host, RectTransform cell, RectTransform layer); // 0x000000018094E4E0-0x000000018094EA20
	private static void RetireLegacyCellBadges(Transform cell); // 0x000000018094EA20-0x000000018094ECC0
	private Transform BadgeHostOf(int panelIndex, int cellIndex); // 0x000000018094ECC0-0x000000018094EEC0
	private void EnsureElementReqBadge(Transform badgeHost, string[] elements, bool locked); // 0x000000018094EEC0-0x000000018094FC00
	private void EnsureHuntOrderBadge(Transform badgeHost, int orderNumber, bool locked, bool cleared); // 0x000000018094FC00-0x0000000180950690
	private void BuildHuntOrderDigits(Transform badgeT, int orderNumber, bool locked); // 0x0000000180950690-0x00000001809513F0
	private void EnsureOrderBadgeTap(Transform badgeHost, PetEnemyDTO petEnemy, int orderNumber, Image avatarIcon, bool enabled, HuntBossInfoTip.State state); // 0x00000001809513F0-0x0000000180951D50
	private void EnsureSweepBadge(Transform badgeHost, PetEnemyDTO petEnemy, bool locked); // 0x0000000180951D50-0x0000000180952F90
	private void SubscribeSweepEvents(); // 0x0000000180952F90-0x00000001809532C0
	private void UnsubscribeSweepEvents(); // 0x00000001809532C0-0x00000001809535F0
	private void OnSweepInfoLoaded(BossSweepInfoDTO d); // 0x00000001809535F0-0x0000000180953610
	private void OnSweepTicketUsed(string tier, int ticketsLeft); // 0x0000000180953610-0x00000001809539C0
	private void RefreshSweepHud(); // 0x00000001809539C0-0x0000000180953B70
	[IteratorStateMachine(typeof(_FetchSweepHud_d__107))]
	private IEnumerator FetchSweepHud(int petId); // 0x0000000180953B70-0x0000000180953C20
	private void ApplySweepHud(BossSweepInfoDTO d); // 0x0000000180953C20-0x0000000180954390
	private void HideSweepHud(); // 0x0000000180954390-0x00000001809544F0
	private void EnsureSweepHud(); // 0x00000001809544F0-0x0000000180955F10
	private static void MakeHudBorder(RectTransform parent, float thickness, Color color); // 0x0000000180955F10-0x0000000180956DD0
	private static UnityEngine.UI.Text MakeHudText(RectTransform parent, string name, Vector2 pos, Vector2 size, string value, int fontSize, Color color, FontStyle style, TextAnchor align); // 0x0000000180956DD0-0x0000000180957490
	private void SetImageGrayscale(Image img, bool enable); // 0x0000000180957490-0x0000000180957700
	private void ApplyIslandButtonLock(int index, GroupDTO data); // 0x0000000180957700-0x0000000180957E00
	private void OnDestroy(); // 0x0000000180957E00-0x00000001809583C0
	[CompilerGenerated]
	private void _HideLoadingPanel_b__34_0(); // 0x0000000180958860-0x0000000180958980
	[CompilerGenerated]
	private void _BackSceneWithFade_b__53_0(); // 0x0000000180958980-0x0000000180958A00
	[CompilerGenerated]
	private void _ShowNoticeWithAnimation_b__59_0(); // 0x0000000180958A00-0x0000000180958AB0
	[CompilerGenerated]
	private void _FetchSweepHud_b__107_0(BossSweepInfoDTO d); // 0x0000000180958AB0-0x0000000180958AE0
	[CompilerGenerated]
	private void _FetchSweepHud_b__107_1(string err); // 0x0000000180958AE0-0x0000000180958B50
}

