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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ManagerEventFest : MonoBehaviour // TypeDefIndex: 1605
{
	// Fields
	public const string PANEL_KEY = "PanelEventFest"; // Metadata: 0x005F12AF
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
	private sealed class __c // TypeDefIndex: 1606
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__63_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180895A40-0x0000000180895AE0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadState_b__63_1(string err); // 0x0000000180895AE0-0x0000000180895B60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass73_0 // TypeDefIndex: 1607
	{
		// Fields
		public ManagerEventFest __4__this; // 0x10
		public EventFestMilestoneDTO captured; // 0x18

		// Constructors
		public __c__DisplayClass73_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BindSlot_b__0(); // 0x0000000180895B60-0x0000000180895CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass87_0 // TypeDefIndex: 1608
	{
		// Fields
		public ManagerEventFest __4__this; // 0x10
		public int index; // 0x18

		// Constructors
		public __c__DisplayClass87_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FlipCoroutine_b__0(EventFestStateDTO state); // 0x0000000180895CC0-0x0000000180895FC0
		internal void _FlipCoroutine_b__1(string err); // 0x0000000180895FC0-0x0000000180896070
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass87_1 // TypeDefIndex: 1609
	{
		// Fields
		public EventFestStateDTO state; // 0x10
		public __c__DisplayClass87_0 CS___8__locals1; // 0x18

		// Constructors
		public __c__DisplayClass87_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FlipCoroutine_b__2(); // 0x0000000180896070-0x00000001808960E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass88_0 // TypeDefIndex: 1610
	{
		// Fields
		public Image img; // 0x10
		public ManagerEventFest __4__this; // 0x18
		public string type; // 0x20
		public UnityEngine.UI.Text txt; // 0x28
		public int amount; // 0x30
		public Action onDone; // 0x38

		// Constructors
		public __c__DisplayClass88_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RevealCard_b__0(); // 0x00000001808960E0-0x0000000180896390
		internal void _RevealCard_b__1(); // 0x0000000180896390-0x00000001808963B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass90_0 // TypeDefIndex: 1611
	{
		// Fields
		public int idx; // 0x10
		public ManagerEventFest __4__this; // 0x18

		// Constructors
		public __c__DisplayClass90_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildFlipPopup_b__0(); // 0x00000001808963B0-0x00000001808963E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass92_0 // TypeDefIndex: 1612
	{
		// Fields
		public int idx; // 0x10
		public ManagerEventFest __4__this; // 0x18

		// Constructors
		public __c__DisplayClass92_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _WireRefs_b__0(); // 0x00000001808963B0-0x00000001808963E0
	}

	[CompilerGenerated]
	private sealed class _ClaimCoroutine_d__65 : IEnumerator<object> // TypeDefIndex: 1613
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerEventFest __4__this; // 0x20
		public long milestoneId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClaimCoroutine_d__65(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808963E0-0x00000001808966E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808966E0-0x0000000180896720
	}

	[CompilerGenerated]
	private sealed class _FlipCoroutine_d__87 : IEnumerator<object> // TypeDefIndex: 1614
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerEventFest __4__this; // 0x20
		public int index; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FlipCoroutine_d__87(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180896720-0x0000000180896AC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180896AC0-0x0000000180896B00
	}

	[CompilerGenerated]
	private sealed class _LoadState_d__63 : IEnumerator<object> // TypeDefIndex: 1615
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerEventFest __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadState_d__63(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180896B00-0x0000000180896E70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180896E70-0x0000000180896EB0
	}

	// Constructors
	public ManagerEventFest(); // 0x0000000180895320-0x0000000180895600
	static ManagerEventFest(); // 0x0000000180895600-0x0000000180895790

	// Methods
	private Sprite GetRewardSprite(string type); // 0x0000000180885470-0x0000000180885F90
	private static Color RewardColor(string type); // 0x0000000180885F90-0x0000000180886780
	private static string RewardLabel(EventFestMilestoneDTO m); // 0x0000000180886780-0x00000001808870B0
	private void OnDisable(); // 0x00000001808870B0-0x00000001808870C0
	private void Start(); // 0x00000001808870C0-0x0000000180887400
	public void OpenPanel(); // 0x0000000180887400-0x0000000180887A00
	public void ClosePanel(); // 0x0000000180887A00-0x0000000180887D70
	[IteratorStateMachine(typeof(_LoadState_d__63))]
	private IEnumerator LoadState(); // 0x0000000180887D70-0x0000000180887E10
	private void OnClickClaim(EventFestMilestoneDTO m); // 0x0000000180887E10-0x0000000180887F60
	[IteratorStateMachine(typeof(_ClaimCoroutine_d__65))]
	private IEnumerator ClaimCoroutine(long milestoneId); // 0x0000000180887F60-0x0000000180888020
	private void SafeReloadState(); // 0x0000000180888020-0x00000001808880A0
	private void RefreshHubResources(); // 0x00000001808880A0-0x0000000180888340
	private void ApplyState(EventFestStateDTO s); // 0x0000000180888340-0x0000000180888820
	private void RefreshMiniGame(); // 0x0000000180888820-0x0000000180888BF0
	private void RefreshProgressBar(); // 0x0000000180888BF0-0x0000000180888FF0
	private void RefreshMissions(); // 0x0000000180888FF0-0x0000000180889BD0
	private void RefreshTrack(); // 0x0000000180889BD0-0x0000000180889FA0
	private void BindSlot(GameObject slot, EventFestMilestoneDTO m); // 0x0000000180889FA0-0x000000018088ADB0
	private void ShowRewardPopup(EventFestStateDTO s); // 0x000000018088ADB0-0x000000018088B410
	private void CloseRewardPopup(); // 0x000000018088B410-0x000000018088B780
	public void PrebuildSlots(int count); // 0x000000018088B780-0x000000018088B920
	[ContextMenu("Tao UI")]
	public void BuildUI(); // 0x000000018088B920-0x000000018088C040
	private void BuildBanner(Transform p); // 0x000000018088C040-0x000000018088C700
	private void BuildPointsSection(Transform p); // 0x000000018088C700-0x000000018088CF90
	private void BuildMissionSection(Transform p); // 0x000000018088CF90-0x000000018088D790
	private void BuildTrackSection(Transform p); // 0x000000018088D790-0x000000018088E090
	private GameObject BuildMilestoneSlot(int index); // 0x000000018088E090-0x000000018088E960
	private void BuildCloseButton(Transform p); // 0x000000018088E960-0x000000018088ECE0
	public void OpenFlipPopup(); // 0x000000018088ECE0-0x000000018088F940
	private void CloseFlipPopup(); // 0x000000018088F940-0x000000018088FAA0
	private void OnClickChest(int index); // 0x000000018088FAA0-0x000000018088FC20
	[IteratorStateMachine(typeof(_FlipCoroutine_d__87))]
	private IEnumerator FlipCoroutine(int index); // 0x000000018088FC20-0x000000018088FCD0
	private void RevealCard(GameObject card, string type, int amount, Action onDone); // 0x000000018088FCD0-0x0000000180890260
	private static string FlipCardLabel(string type, int amount); // 0x0000000180890260-0x0000000180890AF0
	private void BuildFlipPopup(Transform p); // 0x0000000180890AF0-0x0000000180891DD0
	private void BuildRewardPopup(Transform p); // 0x0000000180891DD0-0x00000001808927D0
	private void WireRefs(); // 0x00000001808927D0-0x0000000180894B00
	private static GameObject NewGO(string name, Transform parent); // 0x0000000180894B00-0x0000000180894CC0
	private static void Stretch(GameObject go, float l = 0f /* Metadata: 0x005F126F */, float r = 0f /* Metadata: 0x005F1273 */, float t = 0f /* Metadata: 0x005F1277 */, float b = 0f /* Metadata: 0x005F127B */); // 0x0000000180894CC0-0x0000000180894DE0
	private static GameObject Stretch(GameObject go); // 0x0000000180894DE0-0x0000000180894E50
	private static void Band(GameObject go, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x005F127F */, float padR = 0f /* Metadata: 0x005F1283 */, float padT = 0f /* Metadata: 0x005F1287 */, float padB = 0f /* Metadata: 0x005F128B */); // 0x0000000180894E50-0x0000000180894F60
	private GameObject AddText(GameObject parent, string name, string text, int size, FontStyle style, Color color, TextAnchor align, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x005F128F */, float padR = 0f /* Metadata: 0x005F1293 */, float padT = 0f /* Metadata: 0x005F1297 */, float padB = 0f /* Metadata: 0x005F129B */); // 0x0000000180894F60-0x00000001808951F0
	private GameObject AddText(Transform parent, string name, string text, int size, FontStyle style, Color color, TextAnchor align, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x005F129F */, float padR = 0f /* Metadata: 0x005F12A3 */, float padT = 0f /* Metadata: 0x005F12A7 */, float padB = 0f /* Metadata: 0x005F12AB */); // 0x00000001808951F0-0x0000000180895320
	[CompilerGenerated]
	private void _ClosePanel_b__62_0(); // 0x0000000180895790-0x0000000180895810
	[CompilerGenerated]
	private void _LoadState_b__63_0(EventFestStateDTO state); // 0x0000000180895810-0x0000000180895820
	[CompilerGenerated]
	private void _ClaimCoroutine_b__65_0(EventFestStateDTO state); // 0x0000000180895820-0x00000001808958D0
	[CompilerGenerated]
	private void _ClaimCoroutine_b__65_1(string err); // 0x00000001808958D0-0x0000000180895960
	[CompilerGenerated]
	private void _CloseRewardPopup_b__75_0(); // 0x0000000180895960-0x0000000180895A40
}

