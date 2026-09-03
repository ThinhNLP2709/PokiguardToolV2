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

public class ManagerEventFest : MonoBehaviour // TypeDefIndex: 1004
{
	// Fields
	public const string PANEL_KEY = "PanelEventFest"; // Metadata: 0x0064D0F0
	[Header("Font (de trong = dung mac dinh)")]
	public Font customFont; // 0x20
	[Header("Icon qua \u2014 SET 1 CHO DUY NHAT, tu load vao moc thuong + ruong + popup.\nDe trong = tu tim Resources/Image/EventFest/{TEN_LOAI_QUA}.png")]
	public Sprite icGold; // 0x28
	public Sprite icEnergy; // 0x30
	public Sprite icRuby; // 0x38
	public Sprite icCrystal; // 0x40
	public Sprite icItem1; // 0x48
	public Sprite icItem2; // 0x50
	public Sprite icItem3; // 0x58
	public Sprite icItem4; // 0x60
	public Sprite icStoneCard; // 0x68
	public Sprite icStarWhite; // 0x70
	public Sprite icStarBlue; // 0x78
	public Sprite icStarRed; // 0x80
	[Header("Loi Mega 1..9 (phan tu 0 = M_CORE1 ... phan tu 8 = M_CORE9)")]
	public Sprite[] icMCore; // 0x88
	private static readonly Color COL_OVERLAY; // 0x00
	private static readonly Color COL_BOX; // 0x10
	private static readonly Color COL_BANNER; // 0x20
	private static readonly Color COL_SAND; // 0x30
	private static readonly Color COL_CORAL; // 0x40
	private static readonly Color COL_CARD; // 0x50
	private static readonly Color COL_CARD_DONE; // 0x60
	private static readonly Color COL_SLOT; // 0x70
	private static readonly Color COL_SLOT_DONE; // 0x80
	private static readonly Color COL_BTN_CLAIM; // 0x90
	private static readonly Color COL_BTN_LOCK; // 0xA0
	private static readonly Color COL_BTN_DONE; // 0xB0
	private static readonly Color COL_BAR_FILL; // 0xC0
	private EventFestStateDTO _state; // 0x90
	private bool _isLoading; // 0x98
	private bool _isClaiming; // 0x99
	private bool _openedOnce; // 0x9A
	[SerializeField]
	private GameObject _panel; // 0xA0
	[SerializeField]
	private UnityEngine.UI.Text _txtTitle; // 0xA8
	[SerializeField]
	private UnityEngine.UI.Text _txtDesc; // 0xB0
	[SerializeField]
	private UnityEngine.UI.Text _txtTimer; // 0xB8
	[SerializeField]
	private UnityEngine.UI.Text _txtPoints; // 0xC0
	[SerializeField]
	private UnityEngine.UI.Text _txtProgress; // 0xC8
	[SerializeField]
	private UnityEngine.UI.Text _txtDailyPoints; // 0xD0
	[SerializeField]
	private Image _barFill; // 0xD8
	[SerializeField]
	private Transform _missionRow; // 0xE0
	[SerializeField]
	private Transform _trackContent; // 0xE8
	[SerializeField]
	private GameObject _rewardPopup; // 0xF0
	[SerializeField]
	private Image _popupIcon; // 0xF8
	[SerializeField]
	private UnityEngine.UI.Text _popupMsg; // 0x100
	[SerializeField]
	private Button _btnMiniGame; // 0x108
	[SerializeField]
	private UnityEngine.UI.Text _txtMiniGameBtn; // 0x110
	[SerializeField]
	private GameObject _flipPopup; // 0x118
	[SerializeField]
	private UnityEngine.UI.Text _txtFlipsLeft; // 0x120
	[SerializeField]
	private UnityEngine.UI.Text _txtFlipHint; // 0x128
	private readonly List<GameObject> _flipCards; // 0x130
	private readonly bool[] _flipCardUsed; // 0x138
	private readonly Sprite[] _chestOrigSprites; // 0x140
	private bool _chestSpritesCaptured; // 0x148
	private bool _flipping; // 0x149
	private readonly List<GameObject> _slotPool; // 0x150

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1005
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__63_1; // 0x08

		// Constructors
		static __c(); // 0x00000001804945C0-0x0000000180494630
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadState_b__63_1(string err); // 0x0000000180493E10-0x0000000180493E80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass73_0 // TypeDefIndex: 1006
	{
		// Fields
		public ManagerEventFest __4__this; // 0x10
		public EventFestMilestoneDTO captured; // 0x18

		// Constructors
		public __c__DisplayClass73_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _BindSlot_b__0(); // 0x0000000180493F60-0x0000000180494050
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass87_0 // TypeDefIndex: 1007
	{
		// Fields
		public ManagerEventFest __4__this; // 0x10
		public int index; // 0x18

		// Constructors
		public __c__DisplayClass87_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _FlipCoroutine_b__0(EventFestStateDTO state); // 0x0000000180494050-0x0000000180494270
		internal void _FlipCoroutine_b__1(string err); // 0x0000000180494270-0x0000000180494310
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass87_1 // TypeDefIndex: 1008
	{
		// Fields
		public EventFestStateDTO state; // 0x10
		public __c__DisplayClass87_0 CS___8__locals1; // 0x18

		// Constructors
		public __c__DisplayClass87_1(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _FlipCoroutine_b__2(); // 0x0000000180494310-0x0000000180494380
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass88_0 // TypeDefIndex: 1009
	{
		// Fields
		public Image img; // 0x10
		public ManagerEventFest __4__this; // 0x18
		public string type; // 0x20
		public UnityEngine.UI.Text txt; // 0x28
		public int amount; // 0x30
		public Action onDone; // 0x38

		// Constructors
		public __c__DisplayClass88_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RevealCard_b__0(); // 0x0000000180494380-0x0000000180494570
		internal void _RevealCard_b__1(); // 0x0000000180494570-0x0000000180494590
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass90_0 // TypeDefIndex: 1010
	{
		// Fields
		public int idx; // 0x10
		public ManagerEventFest __4__this; // 0x18

		// Constructors
		public __c__DisplayClass90_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _BuildFlipPopup_b__0(); // 0x0000000180494590-0x00000001804945C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass92_0 // TypeDefIndex: 1011
	{
		// Fields
		public int idx; // 0x10
		public ManagerEventFest __4__this; // 0x18

		// Constructors
		public __c__DisplayClass92_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _WireRefs_b__0(); // 0x0000000180494590-0x00000001804945C0
	}

	[CompilerGenerated]
	private sealed class _ClaimCoroutine_d__65 : IEnumerator<object> // TypeDefIndex: 1012
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerEventFest __4__this; // 0x20
		public long milestoneId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClaimCoroutine_d__65(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180492F90-0x0000000180493180
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180493180-0x00000001804931C0
	}

	[CompilerGenerated]
	private sealed class _FlipCoroutine_d__87 : IEnumerator<object> // TypeDefIndex: 1013
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerEventFest __4__this; // 0x20
		public int index; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FlipCoroutine_d__87(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180493690-0x00000001804938C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804938C0-0x0000000180493900
	}

	[CompilerGenerated]
	private sealed class _LoadState_d__63 : IEnumerator<object> // TypeDefIndex: 1014
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerEventFest __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadState_d__63(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180493B30-0x0000000180493D60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180493D60-0x0000000180493DA0
	}

	// Constructors
	public ManagerEventFest(); // 0x000000018048F780-0x000000018048F8C0
	static ManagerEventFest(); // 0x000000018048F5F0-0x000000018048F780

	// Methods
	private Sprite GetRewardSprite(string type); // 0x000000018048A790-0x000000018048AF40
	private static Color RewardColor(string type); // 0x000000018048D200-0x000000018048D780
	private static string RewardLabel(EventFestMilestoneDTO m); // 0x000000018048D780-0x000000018048DE00
	private void OnDisable(); // 0x000000018048B2F0-0x000000018048B300
	private void Start(); // 0x000000018048E1F0-0x000000018048E300
	public void OpenPanel(); // 0x000000018048B870-0x000000018048BAE0
	public void ClosePanel(); // 0x0000000180489EB0-0x000000018048A020
	[IteratorStateMachine(typeof(_LoadState_d__63))]
	private IEnumerator LoadState(); // 0x000000018048AF40-0x000000018048AFB0
	private void OnClickClaim(EventFestMilestoneDTO m); // 0x000000018048B200-0x000000018048B2F0
	[IteratorStateMachine(typeof(_ClaimCoroutine_d__65))]
	private IEnumerator ClaimCoroutine(long milestoneId); // 0x0000000180489DA0-0x0000000180489E20
	private void SafeReloadState(); // 0x000000018048DE00-0x000000018048DE80
	private void RefreshHubResources(); // 0x000000018048BC10-0x000000018048BDA0
	private void ApplyState(EventFestStateDTO s); // 0x0000000180484910-0x0000000180484DA0
	private void RefreshMiniGame(); // 0x000000018048BDA0-0x000000018048C0C0
	private void RefreshProgressBar(); // 0x000000018048C9B0-0x000000018048CD00
	private void RefreshMissions(); // 0x000000018048C0C0-0x000000018048C9B0
	private void RefreshTrack(); // 0x000000018048CD00-0x000000018048CF80
	private void BindSlot(GameObject slot, EventFestMilestoneDTO m); // 0x0000000180484EB0-0x00000001804857F0
	private void ShowRewardPopup(EventFestStateDTO s); // 0x000000018048DE80-0x000000018048E1F0
	private void CloseRewardPopup(); // 0x000000018048A020-0x000000018048A190
	public void PrebuildSlots(int count); // 0x000000018048BAE0-0x000000018048BC10
	[ContextMenu("Tao UI")]
	public void BuildUI(); // 0x00000001804898B0-0x0000000180489DA0
	private void BuildBanner(Transform p); // 0x00000001804857F0-0x0000000180485EC0
	private void BuildPointsSection(Transform p); // 0x0000000180487FD0-0x00000001804887A0
	private void BuildMissionSection(Transform p); // 0x0000000180487850-0x0000000180487FD0
	private void BuildTrackSection(Transform p); // 0x0000000180489070-0x00000001804898B0
	private GameObject BuildMilestoneSlot(int index); // 0x0000000180486FA0-0x0000000180487850
	private void BuildCloseButton(Transform p); // 0x0000000180485EC0-0x00000001804861C0
	public void OpenFlipPopup(); // 0x000000018048B300-0x000000018048B870
	private void CloseFlipPopup(); // 0x0000000180489E20-0x0000000180489EB0
	private void OnClickChest(int index); // 0x000000018048B0F0-0x000000018048B200
	[IteratorStateMachine(typeof(_FlipCoroutine_d__87))]
	private IEnumerator FlipCoroutine(int index); // 0x000000018048A710-0x000000018048A790
	private void RevealCard(GameObject card, string type, int amount, Action onDone); // 0x000000018048CF80-0x000000018048D200
	private static string FlipCardLabel(string type, int amount); // 0x000000018048A190-0x000000018048A710
	private void BuildFlipPopup(Transform p); // 0x00000001804861C0-0x0000000180486FA0
	private void BuildRewardPopup(Transform p); // 0x00000001804887A0-0x0000000180489070
	private void WireRefs(); // 0x000000018048E600-0x000000018048F5F0
	private static GameObject NewGO(string name, Transform parent); // 0x000000018048AFB0-0x000000018048B0F0
	private static void Stretch(GameObject go, float l = 0f /* Metadata: 0x0064D0B0 */, float r = 0f /* Metadata: 0x0064D0B4 */, float t = 0f /* Metadata: 0x0064D0B8 */, float b = 0f /* Metadata: 0x0064D0BC */); // 0x000000018048E370-0x000000018048E490
	private static GameObject Stretch(GameObject go); // 0x000000018048E300-0x000000018048E370
	private static void Band(GameObject go, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x0064D0C0 */, float padR = 0f /* Metadata: 0x0064D0C4 */, float padT = 0f /* Metadata: 0x0064D0C8 */, float padB = 0f /* Metadata: 0x0064D0CC */); // 0x0000000180484DA0-0x0000000180484EB0
	private GameObject AddText(GameObject parent, string name, string text, int size, FontStyle style, Color color, TextAnchor align, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x0064D0D0 */, float padR = 0f /* Metadata: 0x0064D0D4 */, float padT = 0f /* Metadata: 0x0064D0D8 */, float padB = 0f /* Metadata: 0x0064D0DC */); // 0x0000000180484730-0x0000000180484910
	private GameObject AddText(Transform parent, string name, string text, int size, FontStyle style, Color color, TextAnchor align, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x0064D0E0 */, float padR = 0f /* Metadata: 0x0064D0E4 */, float padT = 0f /* Metadata: 0x0064D0E8 */, float padB = 0f /* Metadata: 0x0064D0EC */); // 0x0000000180484600-0x0000000180484730
	[CompilerGenerated]
	private void _ClosePanel_b__62_0(); // 0x000000018048E590-0x000000018048E5C0
	[CompilerGenerated]
	private void _LoadState_b__63_0(EventFestStateDTO state); // 0x000000018048E5F0-0x000000018048E600
	[CompilerGenerated]
	private void _ClaimCoroutine_b__65_0(EventFestStateDTO state); // 0x000000018048E490-0x000000018048E510
	[CompilerGenerated]
	private void _ClaimCoroutine_b__65_1(string err); // 0x000000018048E510-0x000000018048E590
	[CompilerGenerated]
	private void _CloseRewardPopup_b__75_0(); // 0x000000018048E5C0-0x000000018048E5F0
}

