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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerEventFest : MonoBehaviour // TypeDefIndex: 1202
{
	// Fields
	public const string PANEL_KEY = "PanelEventFest"; // Metadata: 0x0068CC47
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
	private sealed class __c // TypeDefIndex: 1203
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__63_1; // 0x08

		// Constructors
		static __c(); // 0x00000001805A6520-0x00000001805A6590
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadState_b__63_1(string err); // 0x00000001805A56F0-0x00000001805A5760
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass73_0 // TypeDefIndex: 1204
	{
		// Fields
		public ManagerEventFest __4__this; // 0x10
		public EventFestMilestoneDTO captured; // 0x18

		// Constructors
		public __c__DisplayClass73_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BindSlot_b__0(); // 0x00000001805A5810-0x00000001805A5840
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass87_0 // TypeDefIndex: 1205
	{
		// Fields
		public ManagerEventFest __4__this; // 0x10
		public int index; // 0x18

		// Constructors
		public __c__DisplayClass87_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FlipCoroutine_b__0(EventFestStateDTO state); // 0x00000001805A5A30-0x00000001805A5C50
		internal void _FlipCoroutine_b__1(string err); // 0x00000001805A5C50-0x00000001805A5CF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass87_1 // TypeDefIndex: 1206
	{
		// Fields
		public EventFestStateDTO state; // 0x10
		public __c__DisplayClass87_0 CS___8__locals1; // 0x18

		// Constructors
		public __c__DisplayClass87_1(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FlipCoroutine_b__2(); // 0x00000001805A5F10-0x00000001805A5F80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass88_0 // TypeDefIndex: 1207
	{
		// Fields
		public Image img; // 0x10
		public ManagerEventFest __4__this; // 0x18
		public string type; // 0x20
		public UnityEngine.UI.Text txt; // 0x28
		public int amount; // 0x30
		public Action onDone; // 0x38

		// Constructors
		public __c__DisplayClass88_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RevealCard_b__0(); // 0x00000001805A6270-0x00000001805A6460
		internal void _RevealCard_b__1(); // 0x00000001805A6460-0x00000001805A6480
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass90_0 // TypeDefIndex: 1208
	{
		// Fields
		public int idx; // 0x10
		public ManagerEventFest __4__this; // 0x18

		// Constructors
		public __c__DisplayClass90_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BuildFlipPopup_b__0(); // 0x00000001805A6480-0x00000001805A64B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass92_0 // TypeDefIndex: 1209
	{
		// Fields
		public int idx; // 0x10
		public ManagerEventFest __4__this; // 0x18

		// Constructors
		public __c__DisplayClass92_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _WireRefs_b__0(); // 0x00000001805A6480-0x00000001805A64B0
	}

	[CompilerGenerated]
	private sealed class _ClaimCoroutine_d__65 : IEnumerator<object> // TypeDefIndex: 1210
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerEventFest __4__this; // 0x20
		public long milestoneId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClaimCoroutine_d__65(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805A2F60-0x00000001805A3150
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A3150-0x00000001805A3190
	}

	[CompilerGenerated]
	private sealed class _FlipCoroutine_d__87 : IEnumerator<object> // TypeDefIndex: 1211
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerEventFest __4__this; // 0x20
		public int index; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FlipCoroutine_d__87(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805A3560-0x00000001805A3790
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A3790-0x00000001805A37D0
	}

	[CompilerGenerated]
	private sealed class _LoadState_d__63 : IEnumerator<object> // TypeDefIndex: 1212
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerEventFest __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadState_d__63(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805A3F50-0x00000001805A4180
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A4180-0x00000001805A41C0
	}

	// Constructors
	public ManagerEventFest(); // 0x0000000180583900-0x0000000180583A40
	static ManagerEventFest(); // 0x0000000180583770-0x0000000180583900

	// Methods
	private Sprite GetRewardSprite(string type); // 0x000000018057E920-0x000000018057F0D0
	private static Color RewardColor(string type); // 0x0000000180581390-0x0000000180581910
	private static string RewardLabel(EventFestMilestoneDTO m); // 0x0000000180581910-0x0000000180581F90
	private void OnDisable(); // 0x000000018057F480-0x000000018057F490
	private void Start(); // 0x0000000180582340-0x0000000180582450
	public void OpenPanel(); // 0x000000018057FA00-0x000000018057FC70
	public void ClosePanel(); // 0x000000018057E040-0x000000018057E1B0
	[IteratorStateMachine(typeof(_LoadState_d__63))]
	private IEnumerator LoadState(); // 0x000000018057F0D0-0x000000018057F140
	private void OnClickClaim(EventFestMilestoneDTO m); // 0x000000018057F390-0x000000018057F480
	[IteratorStateMachine(typeof(_ClaimCoroutine_d__65))]
	private IEnumerator ClaimCoroutine(long milestoneId); // 0x000000018057DF30-0x000000018057DFB0
	private void SafeReloadState(); // 0x0000000180581F90-0x0000000180581FD0
	private void RefreshHubResources(); // 0x000000018057FDA0-0x000000018057FF30
	private void ApplyState(EventFestStateDTO s); // 0x0000000180578AA0-0x0000000180578F30
	private void RefreshMiniGame(); // 0x000000018057FF30-0x0000000180580250
	private void RefreshProgressBar(); // 0x0000000180580B40-0x0000000180580E90
	private void RefreshMissions(); // 0x0000000180580250-0x0000000180580B40
	private void RefreshTrack(); // 0x0000000180580E90-0x0000000180581110
	private void BindSlot(GameObject slot, EventFestMilestoneDTO m); // 0x0000000180579040-0x0000000180579980
	private void ShowRewardPopup(EventFestStateDTO s); // 0x0000000180581FD0-0x0000000180582340
	private void CloseRewardPopup(); // 0x000000018057E1B0-0x000000018057E320
	public void PrebuildSlots(int count); // 0x000000018057FC70-0x000000018057FDA0
	[ContextMenu("Tao UI")]
	public void BuildUI(); // 0x000000018057DA40-0x000000018057DF30
	private void BuildBanner(Transform p); // 0x0000000180579980-0x000000018057A050
	private void BuildPointsSection(Transform p); // 0x000000018057C160-0x000000018057C930
	private void BuildMissionSection(Transform p); // 0x000000018057B9E0-0x000000018057C160
	private void BuildTrackSection(Transform p); // 0x000000018057D200-0x000000018057DA40
	private GameObject BuildMilestoneSlot(int index); // 0x000000018057B130-0x000000018057B9E0
	private void BuildCloseButton(Transform p); // 0x000000018057A050-0x000000018057A350
	public void OpenFlipPopup(); // 0x000000018057F490-0x000000018057FA00
	private void CloseFlipPopup(); // 0x000000018057DFB0-0x000000018057E040
	private void OnClickChest(int index); // 0x000000018057F280-0x000000018057F390
	[IteratorStateMachine(typeof(_FlipCoroutine_d__87))]
	private IEnumerator FlipCoroutine(int index); // 0x000000018057E8A0-0x000000018057E920
	private void RevealCard(GameObject card, string type, int amount, Action onDone); // 0x0000000180581110-0x0000000180581390
	private static string FlipCardLabel(string type, int amount); // 0x000000018057E320-0x000000018057E8A0
	private void BuildFlipPopup(Transform p); // 0x000000018057A350-0x000000018057B130
	private void BuildRewardPopup(Transform p); // 0x000000018057C930-0x000000018057D200
	private void WireRefs(); // 0x0000000180582780-0x0000000180583770
	private static GameObject NewGO(string name, Transform parent); // 0x000000018057F140-0x000000018057F280
	private static void Stretch(GameObject go, float l = 0f /* Metadata: 0x0068CC07 */, float r = 0f /* Metadata: 0x0068CC0B */, float t = 0f /* Metadata: 0x0068CC0F */, float b = 0f /* Metadata: 0x0068CC13 */); // 0x00000001805824C0-0x00000001805825E0
	private static GameObject Stretch(GameObject go); // 0x0000000180582450-0x00000001805824C0
	private static void Band(GameObject go, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x0068CC17 */, float padR = 0f /* Metadata: 0x0068CC1B */, float padT = 0f /* Metadata: 0x0068CC1F */, float padB = 0f /* Metadata: 0x0068CC23 */); // 0x0000000180578F30-0x0000000180579040
	private GameObject AddText(GameObject parent, string name, string text, int size, FontStyle style, Color color, TextAnchor align, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x0068CC27 */, float padR = 0f /* Metadata: 0x0068CC2B */, float padT = 0f /* Metadata: 0x0068CC2F */, float padB = 0f /* Metadata: 0x0068CC33 */); // 0x00000001805788C0-0x0000000180578AA0
	private GameObject AddText(Transform parent, string name, string text, int size, FontStyle style, Color color, TextAnchor align, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x0068CC37 */, float padR = 0f /* Metadata: 0x0068CC3B */, float padT = 0f /* Metadata: 0x0068CC3F */, float padB = 0f /* Metadata: 0x0068CC43 */); // 0x0000000180578790-0x00000001805788C0
	[CompilerGenerated]
	private void _ClosePanel_b__62_0(); // 0x0000000180582710-0x0000000180582740
	[CompilerGenerated]
	private void _LoadState_b__63_0(EventFestStateDTO state); // 0x0000000180582770-0x0000000180582780
	[CompilerGenerated]
	private void _ClaimCoroutine_b__65_0(EventFestStateDTO state); // 0x00000001805825E0-0x0000000180582670
	[CompilerGenerated]
	private void _ClaimCoroutine_b__65_1(string err); // 0x0000000180582670-0x0000000180582710
	[CompilerGenerated]
	private void _CloseRewardPopup_b__75_0(); // 0x0000000180582740-0x0000000180582770
}

