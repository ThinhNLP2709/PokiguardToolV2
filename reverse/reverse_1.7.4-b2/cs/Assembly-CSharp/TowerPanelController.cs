/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class TowerPanelController : MonoBehaviour, IPokyEventPanel // TypeDefIndex: 974
{
	// Fields
	public const string PANEL_KEY = "PanelTower"; // Metadata: 0x0068BFE1
	public const string PREF_JUST_CLEARED = "TowerJustCleared"; // Metadata: 0x0068BFEC
	private const string PET_ADDR_PREFIX = "Pets/"; // Metadata: 0x0068BFFD
	public const int FLOOR_SLOTS = 5; // Metadata: 0x0068C003
	public const int FLOOR_ANIM_MAX = 5; // Metadata: 0x0068C004
	private const float FLOOR_ANIM_STAGGER = 0.08f; // Metadata: 0x0068C005
	[Header("Khung")]
	[SerializeField]
	private GameObject frame; // 0x20
	[SerializeField]
	private Button btnClose; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtTitle; // 0x30
	[SerializeField]
	private RawImage bgTower; // 0x38
	[Header("\u1EA2i hi\u1EC7n t\u1EA1i")]
	[SerializeField]
	private GameObject floorBox; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtFloor; // 0x48
	[SerializeField]
	private GameObject maxFloor; // 0x50
	[Header("Boss t\u1EA7ng")]
	[SerializeField]
	private RectTransform bossAnchor; // 0x58
	[SerializeField]
	private Animator bossAnimator; // 0x60
	[SerializeField]
	private Image bossImage; // 0x68
	[SerializeField]
	private Image glowFloor; // 0x70
	[Header("Kh\u1ED1i qu\u00E0")]
	[SerializeField]
	private GameObject rewardOne; // 0x78
	[SerializeField]
	private Transform rewardOneContainer; // 0x80
	[SerializeField]
	private GameObject rewardTwo; // 0x88
	[SerializeField]
	private Transform rewardTwoVictory; // 0x90
	[SerializeField]
	private Transform rewardTwoPass; // 0x98
	[SerializeField]
	private GameObject receivedSpecial; // 0xA0
	[Header("B\u1EAFt \u0111\u1EA7u")]
	[SerializeField]
	private Button btnStart; // 0xA8
	[SerializeField]
	private UnityEngine.UI.Text txtStart; // 0xB0
	[SerializeField]
	private GameObject decoStart; // 0xB8
	[Header("Pet ra tr\u1EADn (02/09/2026)")]
	[SerializeField]
	private GameObject petBox; // 0xC0
	[SerializeField]
	private Button btnPet; // 0xC8
	[SerializeField]
	private Image imgPetIcon; // 0xD0
	[SerializeField]
	private Image imgPetElement; // 0xD8
	[SerializeField]
	private UnityEngine.UI.Text txtPetLv; // 0xE0
	[SerializeField]
	private TowerPetPicker petPicker; // 0xE8
	[Header("M\u1ED1c r\u01B0\u01A1ng (c\u1ED9t tr\u00E1i)")]
	[SerializeField]
	private GameObject infoFloor; // 0xF0
	[SerializeField]
	private TowerFloorItem[] floorItems; // 0xF8
	[SerializeField]
	private Button maskGiftFloor; // 0x100
	[SerializeField]
	private GameObject rewardFloor; // 0x108
	[SerializeField]
	private Transform rewardFloorContainer; // 0x110
	[Header("L\u00E0m m\u1EDBi m\u00F9a")]
	[SerializeField]
	private GameObject infoReset; // 0x118
	[SerializeField]
	private UnityEngine.UI.Text txtResetTime; // 0x120
	[SerializeField]
	private TowerResetPopup resetPopup; // 0x128
	[Header("N\u0103ng l\u01B0\u1EE3ng th\u00E1p")]
	[SerializeField]
	private GameObject powerBox; // 0x130
	[SerializeField]
	private UnityEngine.UI.Text txtPower; // 0x138
	[SerializeField]
	private UnityEngine.UI.Text txtNextPower; // 0x140
	[SerializeField]
	private Button btnBuyPower; // 0x148
	[Header("B\u1EA3ng x\u1EBFp h\u1EA1ng")]
	[SerializeField]
	private Button btnTop; // 0x150
	[SerializeField]
	private GameObject topLayout; // 0x158
	[SerializeField]
	private RectTransform topMain; // 0x160
	[SerializeField]
	private Button topMask; // 0x168
	[SerializeField]
	private ScrollRect topScroll; // 0x170
	[SerializeField]
	private RectTransform topContent; // 0x178
	[SerializeField]
	private UnityEngine.UI.Text txtTopTitle; // 0x180
	[SerializeField]
	private GameObject topItemPrefab; // 0x188
	[Header("H\u1ED9p x\u00E1c nh\u1EADn (C\u00F3 / Hu\u1EF7)")]
	[SerializeField]
	private GameObject confirmDim; // 0x190
	[SerializeField]
	private UnityEngine.UI.Text txtConfirm; // 0x198
	[SerializeField]
	private Button btnConfirmYes; // 0x1A0
	[SerializeField]
	private Button btnConfirmNo; // 0x1A8
	private readonly List<TowerTopItem> _topPool; // 0x1B0
	private readonly List<int> _tweens; // 0x1B8
	private TowerInfoData _info; // 0x1C0
	private int _userId; // 0x1C8
	private bool _wired; // 0x1CC
	private bool _busy; // 0x1CD
	private bool _topOpen; // 0x1CE
	private int _bossPetShown; // 0x1D0
	private CanvasGroup _frameGroup; // 0x1D8
	private Coroutine _resetTimerCo; // 0x1E0
	private Coroutine _powerTimerCo; // 0x1E8
	private Coroutine _topFillCo; // 0x1F0
	private Action _confirmYes; // 0x1F8
	private Coroutine _floorAnimCo; // 0x200

	// Properties
	public bool IsBusy { get; } // 0x00000001804EE600-0x00000001804EE610 
	private static bool Live { get; } // 0x00000001804EE610-0x00000001804EE650 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass103_0 // TypeDefIndex: 975
	{
		// Fields
		public TowerPanelController __4__this; // 0x10
		public int requested; // 0x18

		// Constructors
		public __c__DisplayClass103_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ShowBoss_b__0(AnimationClip[] clips); // 0x00000001804F81C0-0x00000001804F83C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass112_0 // TypeDefIndex: 976
	{
		// Fields
		public TowerPanelController __4__this; // 0x10
		public Vector2 dest; // 0x18

		// Constructors
		public __c__DisplayClass112_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnClickTop_b__0(float y); // 0x00000001804F83C0-0x00000001804F8470
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass113_0 // TypeDefIndex: 977
	{
		// Fields
		public TowerPanelController __4__this; // 0x10
		public float x; // 0x18

		// Constructors
		public __c__DisplayClass113_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _CloseTop_b__0(float y); // 0x00000001804F8470-0x00000001804F8520
		internal void _CloseTop_b__1(); // 0x00000001804F8520-0x00000001804F85C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass115_0 // TypeDefIndex: 978
	{
		// Fields
		public TowerPanelController __4__this; // 0x10
		public TowerResetPackage pkg; // 0x18

		// Constructors
		public __c__DisplayClass115_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnClaimResetPackage_b__0(); // 0x00000001804F85C0-0x00000001804F8670
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass125_0 // TypeDefIndex: 979
	{
		// Fields
		public bool ready; // 0x10
		public bool failed; // 0x11
		public string failReason; // 0x18
		public bool started; // 0x20
		public bool startFailed; // 0x21
		public string startReason; // 0x28

		// Constructors
		public __c__DisplayClass125_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _StartTowerBattle_b__0(); // 0x000000018034AB40-0x000000018034AB50
		internal void _StartTowerBattle_b__1(string r); // 0x000000018034AB50-0x000000018034AB70
		internal void _StartTowerBattle_b__2(ChatMessageDTO _); // 0x00000001804F8670-0x00000001804F8680
		internal void _StartTowerBattle_b__3(ChatMessageDTO m); // 0x00000001804F8680-0x00000001804F86B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass132_0 // TypeDefIndex: 980
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 dest; // 0x18

		// Constructors
		public __c__DisplayClass132_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayOpenFx_b__0(float y); // 0x00000001804F86B0-0x00000001804F8740
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass133_0 // TypeDefIndex: 981
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 dest; // 0x18

		// Constructors
		public __c__DisplayClass133_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayFloorListFx_b__0(float x); // 0x00000001804F8740-0x00000001804F87D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass136_0 // TypeDefIndex: 982
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass136_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayFloorClearedFx_b__0(float a); // 0x00000001804F87D0-0x00000001804F88C0
		internal void _PlayFloorClearedFx_b__1(); // 0x00000001804F88C0-0x00000001804F8950
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass137_0 // TypeDefIndex: 983
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 basePos; // 0x18

		// Constructors
		public __c__DisplayClass137_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ShakePowerBox_b__0(float k); // 0x00000001804F8950-0x00000001804F8A20
		internal void _ShakePowerBox_b__1(); // 0x00000001804F8A20-0x00000001804F8AB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass99_0 // TypeDefIndex: 984
	{
		// Fields
		public AnimationClip[] got; // 0x10
		public bool ready; // 0x18

		// Constructors
		public __c__DisplayClass99_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadFloorAnimators_b__0(AnimationClip[] clips); // 0x00000001804F8C00-0x00000001804F8C20
	}

	[CompilerGenerated]
	private sealed class _FillTop_d__110 : IEnumerator<object> // TypeDefIndex: 985
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerInfoData info; // 0x20
		public TowerPanelController __4__this; // 0x28
		private List<TowerTopRow> _rows_5__2; // 0x30
		private int _n_5__3; // 0x38
		private int _i_5__4; // 0x3C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FillTop_d__110(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x00000001804F4FE0-0x00000001804F5460
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804F5460-0x00000001804F54A0
	}

	[CompilerGenerated]
	private sealed class _LoadFloorAnimators_d__99 : IEnumerator<object> // TypeDefIndex: 986
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPanelController __4__this; // 0x20
		private __c__DisplayClass99_0 __8__1; // 0x28
		private WaitForSecondsRealtime _wait_5__2; // 0x30
		private Dictionary<int, AnimationClip[]> _done_5__3; // 0x38
		private int _animated_5__4; // 0x40
		private int _i_5__5; // 0x44
		private TowerFloorItem _item_5__6; // 0x48
		private int _petId_5__7; // 0x50
		private float _deadline_5__8; // 0x54

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadFloorAnimators_d__99(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804F59C0-0x00000001804F5A20
		private bool MoveNext(); // 0x00000001804F54A0-0x00000001804F5980
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804F5980-0x00000001804F59C0
	}

	[CompilerGenerated]
	private sealed class _LoadInfo_d__90 : IEnumerator<object> // TypeDefIndex: 987
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadInfo_d__90(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804F5A20-0x00000001804F5BE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804F5BE0-0x00000001804F5C20
	}

	[CompilerGenerated]
	private sealed class _PostBuyPower_d__119 : IEnumerator<object> // TypeDefIndex: 988
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PostBuyPower_d__119(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804F6060-0x00000001804F6360
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804F6360-0x00000001804F63A0
	}

	[CompilerGenerated]
	private sealed class _PostResetClaim_d__116 : IEnumerator<object> // TypeDefIndex: 989
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPanelController __4__this; // 0x20
		public TowerResetPackage pkg; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PostResetClaim_d__116(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804F63A0-0x00000001804F66A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804F66A0-0x00000001804F66E0
	}

	[CompilerGenerated]
	private sealed class _PowerTimerLoop_d__128 : IEnumerator<object> // TypeDefIndex: 990
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int seconds; // 0x20
		public TowerPanelController __4__this; // 0x28
		private WaitForSecondsRealtime _wait_5__2; // 0x30
		private int _left_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PowerTimerLoop_d__128(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x00000001804F66E0-0x00000001804F6950
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804F6950-0x00000001804F6990
	}

	[CompilerGenerated]
	private sealed class _ResetTimerLoop_d__127 : IEnumerator<object> // TypeDefIndex: 991
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long seconds; // 0x20
		public TowerPanelController __4__this; // 0x28
		private WaitForSecondsRealtime _wait_5__2; // 0x30
		private long _left_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ResetTimerLoop_d__127(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x00000001804F6E40-0x00000001804F7080
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804F7080-0x00000001804F70C0
	}

	[CompilerGenerated]
	private sealed class _StartTowerBattle_d__125 : IEnumerator<object> // TypeDefIndex: 992
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPanelController __4__this; // 0x20
		private __c__DisplayClass125_0 __8__1; // 0x28
		private float _tWs_5__2; // 0x30
		private TowerBattleBridge _bridge_5__3; // 0x38
		private Action _onReady_5__4; // 0x40
		private Action<string> _onFailed_5__5; // 0x48
		private float _t_5__6; // 0x50
		private Action<ChatMessageDTO> _onStarting_5__7; // 0x58
		private Action<ChatMessageDTO> _onStartFailed_5__8; // 0x60
		private float _tStart_5__9; // 0x68

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _StartTowerBattle_d__125(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804F8140-0x00000001804F81C0
		private bool MoveNext(); // 0x00000001804F70C0-0x00000001804F8100
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804F8100-0x00000001804F8140
	}

	// Constructors
	public TowerPanelController(); // 0x00000001804EE500-0x00000001804EE600

	// Methods
	private void RenderGifts(Transform container, TowerGiftBundle gift, float cell); // 0x00000001804EB5A0-0x00000001804EB660
	private void RenderEntries(Transform container, List<RewardDisplayHelper.Entry> entries, float cell); // 0x00000001804EB110-0x00000001804EB240
	private static void Notice(string msg, float sec); // 0x00000001804E7320-0x00000001804E7410
	private void Awake(); // 0x00000001804E4720-0x00000001804E4730
	public void OpenPanel(); // 0x00000001804E8B90-0x00000001804E8E80
	private void OnDisable(); // 0x00000001804E8580-0x00000001804E8710
	private void EnsureWired(); // 0x00000001804E5490-0x00000001804E6BD0
	private void OnClickPet(); // 0x00000001804E7F50-0x00000001804E8030
	private void HandlePetChosen(int petId); // 0x00000001804E6EC0-0x00000001804E6F70
	private void RefreshPetBox(); // 0x00000001804EAA30-0x00000001804EAE60
	private void CollectFloorItems(Transform root); // 0x00000001804E4F30-0x00000001804E5280
	private static void Wire(Button b, UnityAction action); // 0x00000001804EE460-0x00000001804EE500
	public void ClosePanel(); // 0x00000001804E4A80-0x00000001804E4C90
	private void HideSubViews(); // 0x00000001804E70D0-0x00000001804E7240
	private void SetPlaceholders(); // 0x00000001804ECB50-0x00000001804ED280
	private void SetStartInteractable(bool on); // 0x00000001804ED280-0x00000001804ED360
	private void SetLoading(bool on); // 0x00000001804EC9C0-0x00000001804ECB50
	[IteratorStateMachine(typeof(_LoadInfo_d__90))]
	private IEnumerator LoadInfo(); // 0x00000001804E72B0-0x00000001804E7320
	private void OnInfo(TowerInfoData d); // 0x00000001804E8810-0x00000001804E88F0
	private void OnInfoErr(string err); // 0x00000001804E8710-0x00000001804E8810
	private void ShowLoadError(string msg); // 0x00000001804EDCF0-0x00000001804EE020
	public void Render(TowerInfoData info); // 0x00000001804EC1F0-0x00000001804EC940
	private void RenderRewards(TowerFloorInfo f, bool atMax); // 0x00000001804EBD20-0x00000001804EC010
	private void RenderPower(TowerInfoData info); // 0x00000001804EB660-0x00000001804EBB30
	private void RenderFloorList(TowerInfoData info, bool atMax); // 0x00000001804EB240-0x00000001804EB5A0
	[IteratorStateMachine(typeof(_LoadFloorAnimators_d__99))]
	private IEnumerator LoadFloorAnimators(); // 0x00000001804E7240-0x00000001804E72B0
	private void StopFloorAnimLoader(); // 0x00000001804EE1B0-0x00000001804EE200
	private void ReleaseFloorAnims(); // 0x00000001804EAFC0-0x00000001804EB110
	private void RenderResetTimer(TowerInfoData info); // 0x00000001804EBB30-0x00000001804EBD20
	private void ShowBoss(int petId); // 0x00000001804ED620-0x00000001804ED8F0
	private void ApplyBossStaticIcon(int petId); // 0x00000001804E4560-0x00000001804E4720
	private void ReleaseBoss(); // 0x00000001804EAE60-0x00000001804EAFC0
	public void ShowGiftFloor(RectTransform anchor, TowerFloorInfo data); // 0x00000001804EDA80-0x00000001804EDCF0
	private void PlaceTooltipNear(RectTransform anchor); // 0x00000001804E8E80-0x00000001804E9110
	public void HideGiftFloor(); // 0x00000001804E7010-0x00000001804E70D0
	private void RenderTop(TowerInfoData info); // 0x00000001804EC010-0x00000001804EC1F0
	[IteratorStateMachine(typeof(_FillTop_d__110))]
	private IEnumerator FillTop(TowerInfoData info); // 0x00000001804E6C90-0x00000001804E6D20
	private TowerTopItem EnsureTopRow(int index); // 0x00000001804E5280-0x00000001804E5490
	public void OnClickTop(); // 0x00000001804E8260-0x00000001804E8580
	public void CloseTop(); // 0x00000001804E4C90-0x00000001804E4F30
	private void ShowResetPopup(TowerResetOffer offer); // 0x00000001804EE020-0x00000001804EE140
	private void OnClaimResetPackage(string packageType); // 0x00000001804E7690-0x00000001804E7BD0
	[IteratorStateMachine(typeof(_PostResetClaim_d__116))]
	private IEnumerator PostResetClaim(TowerResetPackage pkg); // 0x00000001804EA920-0x00000001804EA9B0
	private void OnResetClaimOk(TowerResetClaimData d); // 0x00000001804E88F0-0x00000001804E8B90
	public void OnClickBuyPower(); // 0x00000001804E7BD0-0x00000001804E7F50
	[IteratorStateMachine(typeof(_PostBuyPower_d__119))]
	private IEnumerator PostBuyPower(); // 0x00000001804EA8B0-0x00000001804EA920
	private void OnBuyPowerOk(TowerBuyPowerData d); // 0x00000001804E74E0-0x00000001804E7690
	private void OnActionErr(string err); // 0x00000001804E7410-0x00000001804E74E0
	private void ShowConfirm(string message, Action onYes); // 0x00000001804ED8F0-0x00000001804EDA80
	private void HideConfirm(); // 0x00000001804E6F70-0x00000001804E7010
	public void OnClickStart(); // 0x00000001804E8030-0x00000001804E8260
	[IteratorStateMachine(typeof(_StartTowerBattle_d__125))]
	private IEnumerator StartTowerBattle(); // 0x00000001804EE140-0x00000001804EE1B0
	private void FailStart(string msg); // 0x00000001804E6BD0-0x00000001804E6C90
	[IteratorStateMachine(typeof(_ResetTimerLoop_d__127))]
	private IEnumerator ResetTimerLoop(long seconds); // 0x00000001804EC940-0x00000001804EC9C0
	[IteratorStateMachine(typeof(_PowerTimerLoop_d__128))]
	private IEnumerator PowerTimerLoop(int seconds); // 0x00000001804EA9B0-0x00000001804EAA30
	private void StopTimers(); // 0x00000001804EE240-0x00000001804EE300
	private void StopTimer(ref Coroutine co); // 0x00000001804EE200-0x00000001804EE240
	private void Track(int id); // 0x00000001804EE300-0x00000001804EE3A0
	private void PlayOpenFx(); // 0x00000001804E9F00-0x00000001804EA4B0
	private void PlayFloorListFx(); // 0x00000001804E9AC0-0x00000001804E9F00
	private void PlayBossPopIn(); // 0x00000001804E9310-0x00000001804E9540
	private void PlayBossBreath(); // 0x00000001804E9110-0x00000001804E9310
	private void PlayFloorClearedFx(); // 0x00000001804E9540-0x00000001804E9AC0
	private void ShakePowerBox(); // 0x00000001804ED360-0x00000001804ED620
	private void PlayPowerGainFx(); // 0x00000001804EA4B0-0x00000001804EA6B0
	private void PlayPressFx(Button b); // 0x00000001804EA6B0-0x00000001804EA8B0
	private void CancelFx(); // 0x00000001804E4730-0x00000001804E4A80
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001804E6D20-0x00000001804E6E30
	private static GameObject FindGo(Transform root, string nodeName); // 0x00000001804E6E30-0x00000001804E6EC0
	[CompilerGenerated]
	private void _EnsureWired_b__79_0(); // 0x00000001804EE3A0-0x00000001804EE3E0
	[CompilerGenerated]
	private void _OnClickBuyPower_b__118_0(); // 0x00000001804EE3E0-0x00000001804EE460
}

