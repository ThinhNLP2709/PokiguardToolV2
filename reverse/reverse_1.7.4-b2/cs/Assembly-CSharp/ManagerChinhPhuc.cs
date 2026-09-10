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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerChinhPhuc : MonoBehaviour // TypeDefIndex: 1565
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
	private const float IslandPopTime = 0.16f; // Metadata: 0x0068D46E
	private const float IslandStaggerTotal = 0.12f; // Metadata: 0x0068D472
	private const float PanelEnterTime = 0.12f; // Metadata: 0x0068D476
	private readonly Dictionary<int, bool> _lastLockedByPetId; // 0xB0
	[Header("Transition")]
	public GameObject fadeOverlay; // 0xB8
	private const float BackFadeOutTime = 0.12f; // Metadata: 0x0068D47A
	private const float BackFadeInTime = 0.16f; // Metadata: 0x0068D47E
	private static bool _grayShaderWarned; // 0x00
	private const string NODE_BADGE_LAYER = "huntBadgeLayer"; // Metadata: 0x0068D482
	private const string NODE_BADGE_HOST = "cell"; // Metadata: 0x0068D491
	private Sprite _huntBadgeBg; // 0xC0
	private Sprite[] _huntDigitSprites; // 0xC8
	private const string NODE_ORDER_TAP = "tapInfo"; // Metadata: 0x0068D496
	private const float ORDER_TAP_PAD = 1f; // Metadata: 0x0068D49E
	private const string NODE_SWEEP = "btnSweep"; // Metadata: 0x0068D4A2
	private const string SWEEP_BADGE_SPRITE = "Image/FriendUI/btnHelp"; // Metadata: 0x0068D4AB
	private const float SWEEP_BADGE_TAP = 48f; // Metadata: 0x0068D4C2
	private const float SWEEP_BADGE_ICON = 42f; // Metadata: 0x0068D4C6
	private const float SWEEP_BADGE_X = 16f; // Metadata: 0x0068D4CA
	private const float SWEEP_BADGE_Y = -66f; // Metadata: 0x0068D4CE
	private static readonly string[] SWEEP_TIERS; // 0x08
	private static readonly long[] SWEEP_ITEM_IDS; // 0x10
	private const string NODE_SWEEP_HUD = "sweepTicketHud"; // Metadata: 0x0068D4D2
	private const string SWEEP_HUD_PLATE_SPRITE = "Image/item/sweep_plate"; // Metadata: 0x0068D4E1
	private const float SWEEP_HUD_W = 360f; // Metadata: 0x0068D4F8
	private const float SWEEP_HUD_H = 56f; // Metadata: 0x0068D4FC
	private const float SWEEP_HUD_OFFSET_X = 50f; // Metadata: 0x0068D500
	private const float SWEEP_HUD_MARGIN_Y = 8f; // Metadata: 0x0068D504
	private const float SWEEP_HUD_ICON = 48f; // Metadata: 0x0068D508
	private const int SWEEP_HUD_FS_NUM = 32; // Metadata: 0x0068D50C
	private int _sweepFirstUnlockedPetId; // 0xD0
	private int _sweepHudAskedForPetId; // 0xD4
	private RectTransform _sweepHud; // 0xD8
	private readonly UnityEngine.UI.Text[] _sweepHudCounts; // 0xE0
	private readonly Image[] _sweepHudIcons; // 0xE8
	private bool _sweepEventsBound; // 0xF0

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass110_0 // TypeDefIndex: 1566
	{
		// Fields
		public int tierIndex; // 0x10
		public RectTransform iconRect; // 0x18

		// Constructors
		public __c__DisplayClass110_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _EnsureSweepHud_b__0(); // 0x0000000180620830-0x0000000180620890
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 1567
	{
		// Fields
		public int index; // 0x10
		public ManagerChinhPhuc __4__this; // 0x18

		// Constructors
		public __c__DisplayClass19_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Start_b__0(); // 0x0000000180620C20-0x0000000180620C50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 1568
	{
		// Fields
		public GameObject mainPanel; // 0x10

		// Constructors
		public __c__DisplayClass26_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ClosePanel_b__0(); // 0x0000000180620C50-0x0000000180620CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass29_0 // TypeDefIndex: 1569
	{
		// Fields
		public GameObject panel; // 0x10

		// Constructors
		public __c__DisplayClass29_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayPanelEnter_b__0(); // 0x0000000180620CC0-0x0000000180620D70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass32_0 // TypeDefIndex: 1570
	{
		// Fields
		public List<GroupDTO> loadedData; // 0x10
		public bool apiCompleted; // 0x18
		public string errorMessage; // 0x20

		// Constructors
		public __c__DisplayClass32_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadDataCoroutine_b__0(List<GroupDTO> data); // 0x00000001804F8C00-0x00000001804F8C20
		internal void _LoadDataCoroutine_b__1(string error); // 0x0000000180620D70-0x0000000180620E00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass39_0 // TypeDefIndex: 1571
	{
		// Fields
		public UnityEngine.UI.Text text; // 0x10
		public Color originalColor; // 0x18

		// Constructors
		public __c__DisplayClass39_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AnimateTextFadeIn_b__0(float val); // 0x0000000180620E00-0x0000000180620E70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 1572
	{
		// Fields
		public GameObject buttonObj; // 0x10

		// Constructors
		public __c__DisplayClass40_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AddButtonHoverEffect_b__0(BaseEventData data); // 0x0000000180620E70-0x0000000180620F40
		internal void _AddButtonHoverEffect_b__1(BaseEventData data); // 0x0000000180620F40-0x0000000180620FF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass41_0 // TypeDefIndex: 1573
	{
		// Fields
		public bool lockedForClick; // 0x10
		public int lockedOrderForClick; // 0x14
		public int requiredAttack; // 0x18
		public int petId; // 0x1C
		public string reA; // 0x20
		public ManagerChinhPhuc __4__this; // 0x28

		// Constructors
		public __c__DisplayClass41_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnReceived_b__0(); // 0x0000000180620FF0-0x0000000180621100
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass44_0 // TypeDefIndex: 1574
	{
		// Fields
		public GameObject btnObj; // 0x10

		// Constructors
		public __c__DisplayClass44_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayUnlockPunch_b__0(); // 0x0000000180621100-0x0000000180621200
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 1575
	{
		// Fields
		public int petId; // 0x10
		public Func<PetEnemyDTO, bool> __9__0; // 0x18

		// Constructors
		public __c__DisplayClass47_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal bool _OpenRoomWithPetRoutine_b__0(PetEnemyDTO p); // 0x0000000180621200-0x0000000180621220
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass48_0 // TypeDefIndex: 1576
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10

		// Constructors
		public __c__DisplayClass48_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AnimateNumberCount_b__0(float val); // 0x0000000180621220-0x0000000180621280
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass49_0 // TypeDefIndex: 1577
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10
		public Vector3 originalScale; // 0x18

		// Constructors
		public __c__DisplayClass49_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AnimateTextPulse_b__0(); // 0x0000000180621280-0x0000000180621330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass78_0 // TypeDefIndex: 1578
	{
		// Fields
		public RectTransform anchorRt; // 0x10
		public PetEnemyDTO pet; // 0x18
		public int order; // 0x20
		public Image icon; // 0x28
		public HuntBossInfoTip.State st; // 0x30

		// Constructors
		public __c__DisplayClass78_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _EnsureOrderBadgeTap_b__0(); // 0x0000000180621330-0x0000000180621470
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass85_0 // TypeDefIndex: 1579
	{
		// Fields
		public int petId; // 0x10
		public string petName; // 0x18
		public int lv; // 0x20
		public RectTransform anchorRt; // 0x28

		// Constructors
		public __c__DisplayClass85_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _EnsureSweepBadge_b__0(); // 0x0000000180621470-0x0000000180621500
	}

	[CompilerGenerated]
	private sealed class _AnimatePanelContent_d__56 : IEnumerator<object> // TypeDefIndex: 1580
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject panel; // 0x20
		public ManagerChinhPhuc __4__this; // 0x28
		private Button[] _panelButtons_5__2; // 0x30
		private int _i_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AnimatePanelContent_d__56(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x000000018061F020-0x000000018061F2F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018061F2F0-0x000000018061F330
	}

	[CompilerGenerated]
	private sealed class _BackSceneWithFade_d__53 : IEnumerator<object> // TypeDefIndex: 1581
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerChinhPhuc __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _BackSceneWithFade_d__53(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018061F330-0x000000018061F7F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018061F7F0-0x000000018061F830
	}

	[CompilerGenerated]
	private sealed class _FetchSweepHud_d__107 : IEnumerator<object> // TypeDefIndex: 1582
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerChinhPhuc __4__this; // 0x20
		public int petId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FetchSweepHud_d__107(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018061F830-0x000000018061FA20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018061FA20-0x000000018061FA60
	}

	[CompilerGenerated]
	private sealed class _LoadDataCoroutine_d__32 : IEnumerator<object> // TypeDefIndex: 1583
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadDataCoroutine_d__32(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803BCBB0-0x00000001803BCBF0
		private bool MoveNext(); // 0x000000018061FA60-0x0000000180620100
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180620100-0x0000000180620140
	}

	[CompilerGenerated]
	private sealed class _OpenRoomWithPetRoutine_d__47 : IEnumerator<object> // TypeDefIndex: 1584
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int petId; // 0x20
		private __c__DisplayClass47_0 __8__1; // 0x28
		public ManagerChinhPhuc __4__this; // 0x30
		public ManagerRoom flow; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _OpenRoomWithPetRoutine_d__47(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180620370-0x0000000180620720
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180620720-0x0000000180620760
	}

	// Constructors
	public ManagerChinhPhuc(); // 0x00000001806042D0-0x00000001806043D0
	static ManagerChinhPhuc(); // 0x0000000180604150-0x00000001806042D0

	// Methods
	private void Start(); // 0x0000000180603490-0x0000000180603800
	private void OnEnable(); // 0x0000000180600070-0x00000001806000F0
	private void RebindIfServiceDataChanged(); // 0x0000000180602370-0x0000000180602440
	private void OnDisable(); // 0x00000001805FFF30-0x0000000180600070
	private void SubscribeServiceEvents(); // 0x0000000180603800-0x0000000180603900
	private void UnsubscribeServiceEvents(); // 0x0000000180603DD0-0x0000000180603ED0
	private void HandleServiceDataChanged(); // 0x00000001805FE860-0x00000001805FE930
	public void ClosePanel(); // 0x00000001805FAE40-0x00000001805FAFD0
	public void RestoreState(int panelIndex); // 0x0000000180602570-0x0000000180602840
	public void ShowPanel(int index, bool withAnimation = true /* Metadata: 0x0068D46C */); // 0x0000000180603100-0x0000000180603490
	private void PlayPanelEnter(GameObject panel); // 0x0000000180601F50-0x0000000180602160
	public void InitializeAndLoadData(Action onComplete = null); // 0x00000001805FED30-0x00000001805FEDD0
	public void InvalidateCache(); // 0x00000001805FEDD0-0x00000001805FEE40
	[IteratorStateMachine(typeof(_LoadDataCoroutine_d__32))]
	private IEnumerator LoadDataCoroutine(Action onComplete); // 0x00000001805FEE40-0x00000001805FEED0
	private void ShowLoadingPanel(); // 0x0000000180602D00-0x0000000180602EA0
	private void HideLoadingPanel(); // 0x00000001805FEAB0-0x00000001805FEC20
	private void AnimateInitialUI(); // 0x00000001805F95C0-0x00000001805F9920
	private void AnimateTextFadeIn(UnityEngine.UI.Text text, float delay); // 0x00000001805F9B80-0x00000001805F9DB0
	private void AddButtonHoverEffect(GameObject buttonObj); // 0x00000001805F9190-0x00000001805F94A0
	public void OnReceived(List<GroupDTO> petE); // 0x00000001806001E0-0x0000000180601B30
	private static bool HasServerLockFlags(GroupDTO group); // 0x00000001805FE930-0x00000001805FE9A0
	private void PlayUnlockPunch(GameObject btnObj); // 0x0000000180602160-0x0000000180602370
	private void AddPetButtonAnimation(GameObject btnObj); // 0x00000001805F94A0-0x00000001805F95C0
	private void OpenRoomWithPet(int petId, string reA); // 0x0000000180601DD0-0x0000000180601F50
	[IteratorStateMachine(typeof(_OpenRoomWithPetRoutine_d__47))]
	private IEnumerator OpenRoomWithPetRoutine(int petId, string reA, ManagerRoom flow); // 0x0000000180601D30-0x0000000180601DD0
	private void AnimateNumberCount(UnityEngine.UI.Text textComponent, int targetValue); // 0x00000001805F9920-0x00000001805F9AF0
	private void AnimateTextPulse(UnityEngine.UI.Text textComponent); // 0x00000001805F9DB0-0x00000001805F9FB0
	private void OnError(string error); // 0x00000001806000F0-0x00000001806001E0
	public void BackScene(); // 0x00000001805FA4B0-0x00000001805FA530
	[IteratorStateMachine(typeof(_BackSceneWithFade_d__53))]
	private IEnumerator BackSceneWithFade(); // 0x00000001805FA440-0x00000001805FA4B0
	[IteratorStateMachine(typeof(_AnimatePanelContent_d__56))]
	private IEnumerator AnimatePanelContent(GameObject panel); // 0x00000001805F9AF0-0x00000001805F9B80
	public void HideAllPanels(); // 0x00000001805FE9A0-0x00000001805FEAB0
	private void ToggleNotice(); // 0x0000000180603B80-0x0000000180603C80
	private void ShowNoticeWithAnimation(string message = "" /* Metadata: 0x0068D46D */); // 0x0000000180602EA0-0x0000000180603100
	private void HideNoticeWithAnimation(); // 0x00000001805FEC20-0x00000001805FECA0
	private void EnsureGrayMaterial(); // 0x00000001805FBFB0-0x00000001805FC130
	private RectTransform EnsureBadgeLayer(GameObject panel, Button[] cells); // 0x00000001805FB3E0-0x00000001805FB860
	private RectTransform EnsureBadgeHost(RectTransform layer, Transform cell, int cellIndex); // 0x00000001805FAFD0-0x00000001805FB3E0
	private static void SetBadgeHostActive(RectTransform layer, int cellIndex, bool active); // 0x0000000180602990-0x0000000180602A90
	private static void MirrorCellRect(RectTransform host, RectTransform cell, RectTransform layer); // 0x00000001805FFA50-0x00000001805FFD70
	private static void RetireLegacyCellBadges(Transform cell); // 0x0000000180602840-0x0000000180602990
	private Transform BadgeHostOf(int panelIndex, int cellIndex); // 0x00000001805FA530-0x00000001805FA640
	private void EnsureElementReqBadge(Transform badgeHost, string[] elements, bool locked); // 0x00000001805FB860-0x00000001805FBFB0
	private void EnsureHuntOrderBadge(Transform badgeHost, int orderNumber, bool locked, bool cleared); // 0x00000001805FC130-0x00000001805FC700
	private void BuildHuntOrderDigits(Transform badgeT, int orderNumber, bool locked); // 0x00000001805FA640-0x00000001805FAE40
	private void EnsureOrderBadgeTap(Transform badgeHost, PetEnemyDTO petEnemy, int orderNumber, Image avatarIcon, bool enabled, HuntBossInfoTip.State state); // 0x00000001805FC700-0x00000001805FCD10
	private void EnsureSweepBadge(Transform badgeHost, PetEnemyDTO petEnemy, bool locked); // 0x00000001805FCD10-0x00000001805FD860
	private void SubscribeSweepEvents(); // 0x0000000180603900-0x0000000180603B80
	private void UnsubscribeSweepEvents(); // 0x0000000180603ED0-0x0000000180604150
	private void OnSweepInfoLoaded(BossSweepInfoDTO d); // 0x0000000180601B30-0x0000000180601B70
	private void OnSweepTicketUsed(string tier, int ticketsLeft); // 0x0000000180601B70-0x0000000180601D30
	private void RefreshSweepHud(); // 0x0000000180602440-0x0000000180602570
	[IteratorStateMachine(typeof(_FetchSweepHud_d__107))]
	private IEnumerator FetchSweepHud(int petId); // 0x00000001805FE7E0-0x00000001805FE860
	private void ApplySweepHud(BossSweepInfoDTO d); // 0x00000001805F9FB0-0x00000001805FA440
	private void HideSweepHud(); // 0x00000001805FECA0-0x00000001805FED30
	private void EnsureSweepHud(); // 0x00000001805FD860-0x00000001805FE7E0
	private static void MakeHudBorder(RectTransform parent, float thickness, Color color); // 0x00000001805FEED0-0x00000001805FF600
	private static UnityEngine.UI.Text MakeHudText(RectTransform parent, string name, Vector2 pos, Vector2 size, string value, int fontSize, Color color, FontStyle style, TextAnchor align); // 0x00000001805FF600-0x00000001805FFA50
	private void SetImageGrayscale(Image img, bool enable); // 0x0000000180602A90-0x0000000180602D00
	private void OnDestroy(); // 0x00000001805FFD70-0x00000001805FFF30
	[CompilerGenerated]
	private void _HideLoadingPanel_b__34_0(); // 0x0000000180603D10-0x0000000180603D80
	[CompilerGenerated]
	private void _BackSceneWithFade_b__53_0(); // 0x0000000180603C80-0x0000000180603CB0
	[CompilerGenerated]
	private void _ShowNoticeWithAnimation_b__59_0(); // 0x0000000180603D80-0x0000000180603DD0
	[CompilerGenerated]
	private void _FetchSweepHud_b__107_0(BossSweepInfoDTO d); // 0x0000000180603CB0-0x0000000180603D00
	[CompilerGenerated]
	private void _FetchSweepHud_b__107_1(string err); // 0x0000000180603D00-0x0000000180603D10
}

