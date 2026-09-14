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

[DisallowMultipleComponent]
public class ManagerMailbox : MonoBehaviour // TypeDefIndex: 1628
{
	// Fields
	public const string PANEL_KEY = "PanelMailbox"; // Metadata: 0x005F12BE
	public const int CLAIMED_CAP = 50; // Metadata: 0x005F12CB
	[CompilerGenerated]
	private static ManagerMailbox _Instance_k__BackingField; // 0x00
	[Header("Khung")]
	public GameObject panelRoot; // 0x20
	public UnityEngine.UI.Text txtTitle; // 0x28
	public Button btnClose; // 0x30
	[Header("Hai tab")]
	public Button btnTabPending; // 0x38
	public UnityEngine.UI.Text txtTabPending; // 0x40
	public Button btnTabClaimed; // 0x48
	public UnityEngine.UI.Text txtTabClaimed; // 0x50
	[Header("C\u1ED9t tr\u00E1i \u2014 danh s\u00E1ch th\u01B0")]
	public RectTransform listContent; // 0x58
	public ScrollRect listScroll; // 0x60
	public GameObject emptyLabel; // 0x68
	[Tooltip("Prefab ASSET m\u1EABu d\u00F2ng (PokyMailboxItem) \u2014 KH\u00D4NG bao gi\u1EDD SetActive l\u00EAn n\u00F3.")]
	public GameObject rowTemplate; // 0x70
	[Header("Khung ph\u1EA3i \u2014 n\u1ED9i dung th\u01B0")]
	public GameObject detailRoot; // 0x78
	public UnityEngine.UI.Text detailTitle; // 0x80
	public UnityEngine.UI.Text detailContent; // 0x88
	public UnityEngine.UI.Text detailSign; // 0x90
	public ScrollRect detailScroll; // 0x98
	[Tooltip("Content (HorizontalLayoutGroup) c\u1EE7a ListGift \u2014 l\u01B0\u1EDBi qu\u00E0.")]
	public RectTransform giftContent; // 0xA0
	[Header("N\u00FAt")]
	public Button btnReceive; // 0xA8
	public UnityEngine.UI.Text btnReceiveLabel; // 0xB0
	public Button btnReceiveAll; // 0xB8
	public UnityEngine.UI.Text btnReceiveAllLabel; // 0xC0
	[Header("\u1EA2nh")]
	public Sprite rowBgNormal; // 0xC8
	public Sprite rowBgSelected; // 0xD0
	public Sprite iconMailDefault; // 0xD8
	private const string K_TITLE = "hub_mailbox"; // Metadata: 0x005F12CC
	private const string K_TAB_PENDING = "hub_mailbox_tab_pending"; // Metadata: 0x005F12D8
	private const string K_TAB_CLAIMED = "hub_mailbox_tab_claimed"; // Metadata: 0x005F12F0
	private const string K_EMPTY_PENDING = "hub_mailbox_empty_pending"; // Metadata: 0x005F1308
	private const string K_EMPTY_CLAIMED = "hub_mailbox_empty_claimed"; // Metadata: 0x005F1322
	private const string K_BTN_RECEIVE = "hub_mailbox_receive"; // Metadata: 0x005F133C
	private const string K_BTN_RECEIVE_ALL = "hub_mailbox_receive_all"; // Metadata: 0x005F1350
	private const string K_REWARDS = "hub_mailbox_rewards"; // Metadata: 0x005F1368
	private const string K_NO_REWARD = "hub_mailbox_no_reward"; // Metadata: 0x005F137C
	private const string K_EXPIRE = "hub_mailbox_expire"; // Metadata: 0x005F1392
	private const string K_CLAIMED_AT = "hub_mailbox_claimed_at"; // Metadata: 0x005F13A5
	private const string K_CLAIMING = "hub_mailbox_claiming"; // Metadata: 0x005F13BC
	private const string K_LOADING = "hub_mailbox_loading"; // Metadata: 0x005F13D1
	private const string K_FAIL = "hub_mailbox_fail"; // Metadata: 0x005F13E5
	private const string K_ERR_EXPIRED = "hub_mailbox_err_expired"; // Metadata: 0x005F13F6
	private const string K_ERR_CLAIMED = "hub_mailbox_err_claimed"; // Metadata: 0x005F140E
	private const string K_ERR_NOT_YOURS = "hub_mailbox_err_not_yours"; // Metadata: 0x005F1426
	private const string K_DONE = "hub_mailbox_done"; // Metadata: 0x005F1440
	private const string K_SUMMARY = "hub_mailbox_summary"; // Metadata: 0x005F1451
	private const string K_EXTRA_SHARD = "hub_mailbox_extra_shard"; // Metadata: 0x005F1465
	private const string K_EXTRA_WEAPON = "hub_mailbox_extra_weapon"; // Metadata: 0x005F147D
	private static readonly Color ColUnread; // 0x08
	private static readonly Color ColRead; // 0x18
	private static readonly Color ColDate; // 0x28
	private readonly List<Row> _rows; // 0xE0
	private readonly List<GiftDTO> _claimed; // 0xE8
	private int _tab; // 0xF0
	private int _selected; // 0xF4
	private int _wantGiftId; // 0xF8
	private bool _loadingPending; // 0xFC
	private bool _loadingClaimed; // 0xFD
	private bool _claiming; // 0xFE
	private bool _wired; // 0xFF
	private bool _masksTrimmed; // 0x100

	// Properties
	public static ManagerMailbox Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018089AF70-0x000000018089AFD0 0x000000018089AFD0-0x000000018089B080

	// Nested types
	private class Row // TypeDefIndex: 1629
	{
		// Fields
		public GameObject go; // 0x10
		public Image bg; // 0x18
		public Image icon; // 0x20
		public UnityEngine.UI.Text label; // 0x28
		public UnityEngine.UI.Text date; // 0x30
		public GameObject point; // 0x38
		public HomePressScale press; // 0x40
		public Button button; // 0x48
		public Action handler; // 0x50
		public GiftDTO gift; // 0x58

		// Constructors
		public Row(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1630
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<GiftDTO> __9__75_0; // 0x08
		public static Action<string> __9__77_1; // 0x10
		public static Comparison<GiftDTO> __9__77_2; // 0x18

		// Constructors
		static __c(); // 0x00000001808A5280-0x00000001808A5320
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal int _BuildPendingRows_b__75_0(GiftDTO a, GiftDTO b); // 0x00000001808A5320-0x00000001808A53B0
		internal void _LoadClaimedCo_b__77_1(string e); // 0x00000001808A53B0-0x00000001808A5430
		internal int _LoadClaimedCo_b__77_2(GiftDTO a, GiftDTO b); // 0x00000001808A5430-0x00000001808A54C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass77_0 // TypeDefIndex: 1631
	{
		// Fields
		public List<GiftDTO> data; // 0x10

		// Constructors
		public __c__DisplayClass77_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadClaimedCo_b__0(List<GiftDTO> g); // 0x00000001802D8AB0-0x00000001802D8B10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass83_0 // TypeDefIndex: 1632
	{
		// Fields
		public ManagerMailbox __4__this; // 0x10
		public int index; // 0x18

		// Constructors
		public __c__DisplayClass83_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AddRow_b__0(); // 0x00000001808A54C0-0x00000001808A54F0
		internal void _AddRow_b__1(); // 0x00000001808A54C0-0x00000001808A54F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass87_0 // TypeDefIndex: 1633
	{
		// Fields
		public ManagerMailbox __4__this; // 0x10
		public ManagerQuangTruong qt; // 0x18
		public GiftDTO gift; // 0x20

		// Constructors
		public __c__DisplayClass87_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickReceive_b__0(bool ok, GiftDTO result); // 0x00000001808A54F0-0x00000001808A56F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass88_0 // TypeDefIndex: 1634
	{
		// Fields
		public List<GiftDTO> claimed; // 0x10
		public ManagerMailbox __4__this; // 0x18
		public ManagerQuangTruong qt; // 0x20

		// Constructors
		public __c__DisplayClass88_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickReceiveAll_b__0(GiftDTO g); // 0x00000001808A56F0-0x00000001808A5750
		internal void _OnClickReceiveAll_b__1(int okCount, int failCount); // 0x00000001808A5750-0x00000001808A59C0
	}

	[CompilerGenerated]
	private sealed class _LoadClaimedCo_d__77 : IEnumerator<object> // TypeDefIndex: 1635
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ManagerMailbox __4__this; // 0x28
		private __c__DisplayClass77_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadClaimedCo_d__77(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x00000001808A59C0-0x00000001808A6200
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808A6200-0x00000001808A6240
	}

	// Constructors
	public ManagerMailbox(); // 0x00000001808A4FB0-0x00000001808A5160
	static ManagerMailbox(); // 0x00000001808A5160-0x00000001808A51E0

	// Methods
	private void OnEnable(); // 0x000000018089B080-0x000000018089B0D0
	private void OnDisable(); // 0x000000018089B0D0-0x000000018089B2A0
	private void OnDestroy(); // 0x000000018089B2A0-0x000000018089B460
	public void OpenPanel(); // 0x000000018089B460-0x000000018089B670
	public void ClosePanel(); // 0x000000018089B670-0x000000018089B8E0
	private void Wire(); // 0x000000018089B8E0-0x000000018089BE70
	private void TrimMasks(); // 0x000000018089BE70-0x000000018089C200
	private void Dress(); // 0x000000018089C200-0x000000018089C770
	private void ShowTab(int tab, bool force); // 0x000000018089C770-0x000000018089CC70
	private void LoadPending(); // 0x000000018089CC70-0x000000018089CFA0
	private void BuildPendingRows(List<GiftDTO> list); // 0x000000018089CFA0-0x000000018089D490
	private void LoadClaimed(); // 0x000000018089D490-0x000000018089D620
	[IteratorStateMachine(typeof(_LoadClaimedCo_d__77))]
	private IEnumerator LoadClaimedCo(int userId); // 0x000000018089D620-0x000000018089D6D0
	private static string Key(GiftDTO g); // 0x000000018089D6D0-0x000000018089D7E0
	private void AfterBuild(string emptyText); // 0x000000018089D7E0-0x000000018089DE70
	private int PickDefault(); // 0x000000018089DE70-0x000000018089DF70
	private void ClearRowHandlers(); // 0x000000018089DF70-0x000000018089E1D0
	private void ClearRows(); // 0x000000018089E1D0-0x000000018089E4D0
	private void AddRow(GiftDTO gift, bool unread); // 0x000000018089E4D0-0x000000018089F390
	public void Select(int index); // 0x000000018089F390-0x000000018089F6B0
	private void ShowDetail(GiftDTO gift); // 0x000000018089F6B0-0x00000001808A01D0
	private void ClearDetail(); // 0x00000001808A01D0-0x00000001808A09D0
	private void OnClickReceive(); // 0x00000001808A09D0-0x00000001808A0D10
	private void OnClickReceiveAll(); // 0x00000001808A0D10-0x00000001808A1170
	private static string ClaimErrorText(string raw); // 0x00000001808A1170-0x00000001808A1840
	private void SetBusy(bool busy); // 0x00000001808A1840-0x00000001808A1BD0
	private void ToastRewards(List<GiftDTO> gifts); // 0x00000001808A1BD0-0x00000001808A20B0
	public static List<RewardDisplayHelper.Entry> BuildEntries(GiftDTO g); // 0x00000001808A20B0-0x00000001808A2750
	private static List<RewardDisplayHelper.Entry> EntriesForClaimed(GiftDTO g); // 0x00000001808A2750-0x00000001808A2EF0
	private static List<RewardDisplayHelper.Entry> Merge(List<GiftDTO> gifts); // 0x00000001808A2EF0-0x00000001808A36D0
	private static Sprite RewardIcon(GiftDTO g); // 0x00000001808A36D0-0x00000001808A3E40
	private static string ExtraText(GiftDTO g); // 0x00000001808A3E40-0x00000001808A4220
	public static void RefreshIfOpen(); // 0x00000001808A4220-0x00000001808A43E0
	private void ShowEmpty(string text); // 0x00000001808A43E0-0x00000001808A4600
	private void HideEmpty(); // 0x00000001808A4600-0x00000001808A4740
	private static string ShortDate(string iso); // 0x00000001808A4740-0x00000001808A4990
	private static string LongDate(string iso); // 0x00000001808A4990-0x00000001808A4B40
	private static UnityEngine.UI.Text Txt(Transform root, string path); // 0x00000001808A4B40-0x00000001808A4CC0
	private static Image Img(Transform root, string path); // 0x00000001808A4CC0-0x00000001808A4E40
	private static GameObject Go(Transform root, string path); // 0x00000001808A4E40-0x00000001808A4FB0
	[CompilerGenerated]
	private void _Wire_b__70_0(); // 0x00000001808A51E0-0x00000001808A51F0
	[CompilerGenerated]
	private void _Wire_b__70_1(); // 0x00000001808A51F0-0x00000001808A5200
	[CompilerGenerated]
	private void _LoadPending_b__74_0(List<GiftDTO> list); // 0x00000001808A5200-0x00000001808A5280
}

