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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ManagerEventFest : MonoBehaviour // TypeDefIndex: 1603
{
	// Fields
	public const string PANEL_KEY = "PanelEventFest"; // Metadata: 0x005EFEE2
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
	private sealed class __c // TypeDefIndex: 1604
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__63_1; // 0x08

		// Constructors
		static __c(); // 0x00000001808935A0-0x0000000180893640
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadState_b__63_1(string err); // 0x0000000180893640-0x00000001808936C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass73_0 // TypeDefIndex: 1605
	{
		// Fields
		public ManagerEventFest __4__this; // 0x10
		public EventFestMilestoneDTO captured; // 0x18

		// Constructors
		public __c__DisplayClass73_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BindSlot_b__0(); // 0x00000001808936C0-0x00000001808937E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass87_0 // TypeDefIndex: 1606
	{
		// Fields
		public ManagerEventFest __4__this; // 0x10
		public int index; // 0x18

		// Constructors
		public __c__DisplayClass87_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FlipCoroutine_b__0(EventFestStateDTO state); // 0x00000001808937E0-0x0000000180893AD0
		internal void _FlipCoroutine_b__1(string err); // 0x0000000180893AD0-0x0000000180893BA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass87_1 // TypeDefIndex: 1607
	{
		// Fields
		public EventFestStateDTO state; // 0x10
		public __c__DisplayClass87_0 CS___8__locals1; // 0x18

		// Constructors
		public __c__DisplayClass87_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FlipCoroutine_b__2(); // 0x0000000180893BA0-0x0000000180893C10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass88_0 // TypeDefIndex: 1608
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
		internal void _RevealCard_b__0(); // 0x0000000180893C10-0x0000000180893EC0
		internal void _RevealCard_b__1(); // 0x0000000180893EC0-0x0000000180893EE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass90_0 // TypeDefIndex: 1609
	{
		// Fields
		public int idx; // 0x10
		public ManagerEventFest __4__this; // 0x18

		// Constructors
		public __c__DisplayClass90_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildFlipPopup_b__0(); // 0x0000000180893EE0-0x0000000180893F10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass92_0 // TypeDefIndex: 1610
	{
		// Fields
		public int idx; // 0x10
		public ManagerEventFest __4__this; // 0x18

		// Constructors
		public __c__DisplayClass92_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _WireRefs_b__0(); // 0x0000000180893EE0-0x0000000180893F10
	}

	[CompilerGenerated]
	private sealed class _ClaimCoroutine_d__65 : IEnumerator<object> // TypeDefIndex: 1611
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180893F10-0x00000001808941E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808941E0-0x0000000180894220
	}

	[CompilerGenerated]
	private sealed class _FlipCoroutine_d__87 : IEnumerator<object> // TypeDefIndex: 1612
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180894220-0x0000000180894590
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180894590-0x00000001808945D0
	}

	[CompilerGenerated]
	private sealed class _LoadState_d__63 : IEnumerator<object> // TypeDefIndex: 1613
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001808945D0-0x0000000180894920
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180894920-0x0000000180894960
	}

	// Constructors
	public ManagerEventFest(); // 0x0000000180892E80-0x0000000180893160
	static ManagerEventFest(); // 0x0000000180893160-0x00000001808932F0

	// Methods
	private Sprite GetRewardSprite(string type); // 0x0000000180883080-0x0000000180883BA0
	private static Color RewardColor(string type); // 0x0000000180883BA0-0x0000000180884390
	private static string RewardLabel(EventFestMilestoneDTO m); // 0x0000000180884390-0x0000000180884CC0
	private void OnDisable(); // 0x0000000180884CC0-0x0000000180884CD0
	private void Start(); // 0x0000000180884CD0-0x0000000180885010
	public void OpenPanel(); // 0x0000000180885010-0x0000000180885610
	public void ClosePanel(); // 0x0000000180885610-0x0000000180885980
	[IteratorStateMachine(typeof(_LoadState_d__63))]
	private IEnumerator LoadState(); // 0x0000000180885980-0x0000000180885A20
	private void OnClickClaim(EventFestMilestoneDTO m); // 0x0000000180885A20-0x0000000180885B40
	[IteratorStateMachine(typeof(_ClaimCoroutine_d__65))]
	private IEnumerator ClaimCoroutine(long milestoneId); // 0x0000000180885B40-0x0000000180885C00
	private void SafeReloadState(); // 0x0000000180885C00-0x0000000180885C40
	private void RefreshHubResources(); // 0x0000000180885C40-0x0000000180885EE0
	private void ApplyState(EventFestStateDTO s); // 0x0000000180885EE0-0x00000001808863C0
	private void RefreshMiniGame(); // 0x00000001808863C0-0x0000000180886790
	private void RefreshProgressBar(); // 0x0000000180886790-0x0000000180886B90
	private void RefreshMissions(); // 0x0000000180886B90-0x0000000180887770
	private void RefreshTrack(); // 0x0000000180887770-0x0000000180887B40
	private void BindSlot(GameObject slot, EventFestMilestoneDTO m); // 0x0000000180887B40-0x0000000180888950
	private void ShowRewardPopup(EventFestStateDTO s); // 0x0000000180888950-0x0000000180888FB0
	private void CloseRewardPopup(); // 0x0000000180888FB0-0x0000000180889320
	public void PrebuildSlots(int count); // 0x0000000180889320-0x00000001808894C0
	[ContextMenu("Tao UI")]
	public void BuildUI(); // 0x00000001808894C0-0x0000000180889BE0
	private void BuildBanner(Transform p); // 0x0000000180889BE0-0x000000018088A2A0
	private void BuildPointsSection(Transform p); // 0x000000018088A2A0-0x000000018088AB30
	private void BuildMissionSection(Transform p); // 0x000000018088AB30-0x000000018088B330
	private void BuildTrackSection(Transform p); // 0x000000018088B330-0x000000018088BC30
	private GameObject BuildMilestoneSlot(int index); // 0x000000018088BC30-0x000000018088C500
	private void BuildCloseButton(Transform p); // 0x000000018088C500-0x000000018088C880
	public void OpenFlipPopup(); // 0x000000018088C880-0x000000018088D4E0
	private void CloseFlipPopup(); // 0x000000018088D4E0-0x000000018088D640
	private void OnClickChest(int index); // 0x000000018088D640-0x000000018088D780
	[IteratorStateMachine(typeof(_FlipCoroutine_d__87))]
	private IEnumerator FlipCoroutine(int index); // 0x000000018088D780-0x000000018088D830
	private void RevealCard(GameObject card, string type, int amount, Action onDone); // 0x000000018088D830-0x000000018088DDC0
	private static string FlipCardLabel(string type, int amount); // 0x000000018088DDC0-0x000000018088E650
	private void BuildFlipPopup(Transform p); // 0x000000018088E650-0x000000018088F930
	private void BuildRewardPopup(Transform p); // 0x000000018088F930-0x0000000180890330
	private void WireRefs(); // 0x0000000180890330-0x0000000180892660
	private static GameObject NewGO(string name, Transform parent); // 0x0000000180892660-0x0000000180892820
	private static void Stretch(GameObject go, float l = 0f /* Metadata: 0x005EFEA2 */, float r = 0f /* Metadata: 0x005EFEA6 */, float t = 0f /* Metadata: 0x005EFEAA */, float b = 0f /* Metadata: 0x005EFEAE */); // 0x0000000180892820-0x0000000180892940
	private static GameObject Stretch(GameObject go); // 0x0000000180892940-0x00000001808929B0
	private static void Band(GameObject go, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x005EFEB2 */, float padR = 0f /* Metadata: 0x005EFEB6 */, float padT = 0f /* Metadata: 0x005EFEBA */, float padB = 0f /* Metadata: 0x005EFEBE */); // 0x00000001808929B0-0x0000000180892AC0
	private GameObject AddText(GameObject parent, string name, string text, int size, FontStyle style, Color color, TextAnchor align, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x005EFEC2 */, float padR = 0f /* Metadata: 0x005EFEC6 */, float padT = 0f /* Metadata: 0x005EFECA */, float padB = 0f /* Metadata: 0x005EFECE */); // 0x0000000180892AC0-0x0000000180892D50
	private GameObject AddText(Transform parent, string name, string text, int size, FontStyle style, Color color, TextAnchor align, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x005EFED2 */, float padR = 0f /* Metadata: 0x005EFED6 */, float padT = 0f /* Metadata: 0x005EFEDA */, float padB = 0f /* Metadata: 0x005EFEDE */); // 0x0000000180892D50-0x0000000180892E80
	[CompilerGenerated]
	private void _ClosePanel_b__62_0(); // 0x00000001808932F0-0x0000000180893370
	[CompilerGenerated]
	private void _LoadState_b__63_0(EventFestStateDTO state); // 0x0000000180893370-0x0000000180893380
	[CompilerGenerated]
	private void _ClaimCoroutine_b__65_0(EventFestStateDTO state); // 0x0000000180893380-0x0000000180893410
	[CompilerGenerated]
	private void _ClaimCoroutine_b__65_1(string err); // 0x0000000180893410-0x00000001808934C0
	[CompilerGenerated]
	private void _CloseRewardPopup_b__75_0(); // 0x00000001808934C0-0x00000001808935A0
}

