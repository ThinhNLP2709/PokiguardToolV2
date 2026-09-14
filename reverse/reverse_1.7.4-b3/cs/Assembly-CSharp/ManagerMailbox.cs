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

[DisallowMultipleComponent]
public class ManagerMailbox : MonoBehaviour // TypeDefIndex: 1626
{
	// Fields
	public const string PANEL_KEY = "PanelMailbox"; // Metadata: 0x005EFEF1
	public const int CLAIMED_CAP = 50; // Metadata: 0x005EFEFE
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
	private const string K_TITLE = "hub_mailbox"; // Metadata: 0x005EFEFF
	private const string K_TAB_PENDING = "hub_mailbox_tab_pending"; // Metadata: 0x005EFF0B
	private const string K_TAB_CLAIMED = "hub_mailbox_tab_claimed"; // Metadata: 0x005EFF23
	private const string K_EMPTY_PENDING = "hub_mailbox_empty_pending"; // Metadata: 0x005EFF3B
	private const string K_EMPTY_CLAIMED = "hub_mailbox_empty_claimed"; // Metadata: 0x005EFF55
	private const string K_BTN_RECEIVE = "hub_mailbox_receive"; // Metadata: 0x005EFF6F
	private const string K_BTN_RECEIVE_ALL = "hub_mailbox_receive_all"; // Metadata: 0x005EFF83
	private const string K_REWARDS = "hub_mailbox_rewards"; // Metadata: 0x005EFF9B
	private const string K_NO_REWARD = "hub_mailbox_no_reward"; // Metadata: 0x005EFFAF
	private const string K_EXPIRE = "hub_mailbox_expire"; // Metadata: 0x005EFFC5
	private const string K_CLAIMED_AT = "hub_mailbox_claimed_at"; // Metadata: 0x005EFFD8
	private const string K_CLAIMING = "hub_mailbox_claiming"; // Metadata: 0x005EFFEF
	private const string K_LOADING = "hub_mailbox_loading"; // Metadata: 0x005F0004
	private const string K_FAIL = "hub_mailbox_fail"; // Metadata: 0x005F0018
	private const string K_ERR_EXPIRED = "hub_mailbox_err_expired"; // Metadata: 0x005F0029
	private const string K_ERR_CLAIMED = "hub_mailbox_err_claimed"; // Metadata: 0x005F0041
	private const string K_ERR_NOT_YOURS = "hub_mailbox_err_not_yours"; // Metadata: 0x005F0059
	private const string K_DONE = "hub_mailbox_done"; // Metadata: 0x005F0073
	private const string K_SUMMARY = "hub_mailbox_summary"; // Metadata: 0x005F0084
	private const string K_EXTRA_SHARD = "hub_mailbox_extra_shard"; // Metadata: 0x005F0098
	private const string K_EXTRA_WEAPON = "hub_mailbox_extra_weapon"; // Metadata: 0x005F00B0
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
	public static ManagerMailbox Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180898980-0x00000001808989E0 0x00000001808989E0-0x0000000180898A90

	// Nested types
	private class Row // TypeDefIndex: 1627
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
	private sealed class __c // TypeDefIndex: 1628
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<GiftDTO> __9__75_0; // 0x08
		public static Action<string> __9__77_1; // 0x10
		public static Comparison<GiftDTO> __9__77_2; // 0x18

		// Constructors
		static __c(); // 0x00000001808A2C60-0x00000001808A2D00
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal int _BuildPendingRows_b__75_0(GiftDTO a, GiftDTO b); // 0x00000001808A2D00-0x00000001808A2D90
		internal void _LoadClaimedCo_b__77_1(string e); // 0x00000001808A2D90-0x00000001808A2E10
		internal int _LoadClaimedCo_b__77_2(GiftDTO a, GiftDTO b); // 0x00000001808A2E10-0x00000001808A2EA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass77_0 // TypeDefIndex: 1629
	{
		// Fields
		public List<GiftDTO> data; // 0x10

		// Constructors
		public __c__DisplayClass77_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadClaimedCo_b__0(List<GiftDTO> g); // 0x00000001802D8A80-0x00000001802D8AE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass83_0 // TypeDefIndex: 1630
	{
		// Fields
		public ManagerMailbox __4__this; // 0x10
		public int index; // 0x18

		// Constructors
		public __c__DisplayClass83_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AddRow_b__0(); // 0x00000001808A2EA0-0x00000001808A2ED0
		internal void _AddRow_b__1(); // 0x00000001808A2EA0-0x00000001808A2ED0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass87_0 // TypeDefIndex: 1631
	{
		// Fields
		public ManagerMailbox __4__this; // 0x10
		public ManagerQuangTruong qt; // 0x18
		public GiftDTO gift; // 0x20

		// Constructors
		public __c__DisplayClass87_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickReceive_b__0(bool ok, GiftDTO result); // 0x00000001808A2ED0-0x00000001808A30A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass88_0 // TypeDefIndex: 1632
	{
		// Fields
		public List<GiftDTO> claimed; // 0x10
		public ManagerMailbox __4__this; // 0x18
		public ManagerQuangTruong qt; // 0x20

		// Constructors
		public __c__DisplayClass88_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickReceiveAll_b__0(GiftDTO g); // 0x00000001808A30A0-0x00000001808A3100
		internal void _OnClickReceiveAll_b__1(int okCount, int failCount); // 0x00000001808A3100-0x00000001808A3340
	}

	[CompilerGenerated]
	private sealed class _LoadClaimedCo_d__77 : IEnumerator<object> // TypeDefIndex: 1633
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
		private bool MoveNext(); // 0x00000001808A3340-0x00000001808A3A40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808A3A40-0x00000001808A3A80
	}

	// Constructors
	public ManagerMailbox(); // 0x00000001808A29C0-0x00000001808A2B70
	static ManagerMailbox(); // 0x00000001808A2B70-0x00000001808A2BF0

	// Methods
	private void OnEnable(); // 0x0000000180898A90-0x0000000180898AE0
	private void OnDisable(); // 0x0000000180898AE0-0x0000000180898CB0
	private void OnDestroy(); // 0x0000000180898CB0-0x0000000180898E70
	public void OpenPanel(); // 0x0000000180898E70-0x0000000180899080
	public void ClosePanel(); // 0x0000000180899080-0x00000001808992F0
	private void Wire(); // 0x00000001808992F0-0x0000000180899880
	private void TrimMasks(); // 0x0000000180899880-0x0000000180899C10
	private void Dress(); // 0x0000000180899C10-0x000000018089A180
	private void ShowTab(int tab, bool force); // 0x000000018089A180-0x000000018089A680
	private void LoadPending(); // 0x000000018089A680-0x000000018089A9B0
	private void BuildPendingRows(List<GiftDTO> list); // 0x000000018089A9B0-0x000000018089AEA0
	private void LoadClaimed(); // 0x000000018089AEA0-0x000000018089B030
	[IteratorStateMachine(typeof(_LoadClaimedCo_d__77))]
	private IEnumerator LoadClaimedCo(int userId); // 0x000000018089B030-0x000000018089B0E0
	private static string Key(GiftDTO g); // 0x000000018089B0E0-0x000000018089B1F0
	private void AfterBuild(string emptyText); // 0x000000018089B1F0-0x000000018089B880
	private int PickDefault(); // 0x000000018089B880-0x000000018089B980
	private void ClearRowHandlers(); // 0x000000018089B980-0x000000018089BBE0
	private void ClearRows(); // 0x000000018089BBE0-0x000000018089BEE0
	private void AddRow(GiftDTO gift, bool unread); // 0x000000018089BEE0-0x000000018089CDA0
	public void Select(int index); // 0x000000018089CDA0-0x000000018089D0C0
	private void ShowDetail(GiftDTO gift); // 0x000000018089D0C0-0x000000018089DBE0
	private void ClearDetail(); // 0x000000018089DBE0-0x000000018089E3E0
	private void OnClickReceive(); // 0x000000018089E3E0-0x000000018089E720
	private void OnClickReceiveAll(); // 0x000000018089E720-0x000000018089EB80
	private static string ClaimErrorText(string raw); // 0x000000018089EB80-0x000000018089F250
	private void SetBusy(bool busy); // 0x000000018089F250-0x000000018089F5E0
	private void ToastRewards(List<GiftDTO> gifts); // 0x000000018089F5E0-0x000000018089FAC0
	public static List<RewardDisplayHelper.Entry> BuildEntries(GiftDTO g); // 0x000000018089FAC0-0x00000001808A0160
	private static List<RewardDisplayHelper.Entry> EntriesForClaimed(GiftDTO g); // 0x00000001808A0160-0x00000001808A0900
	private static List<RewardDisplayHelper.Entry> Merge(List<GiftDTO> gifts); // 0x00000001808A0900-0x00000001808A10E0
	private static Sprite RewardIcon(GiftDTO g); // 0x00000001808A10E0-0x00000001808A1850
	private static string ExtraText(GiftDTO g); // 0x00000001808A1850-0x00000001808A1C30
	public static void RefreshIfOpen(); // 0x00000001808A1C30-0x00000001808A1DF0
	private void ShowEmpty(string text); // 0x00000001808A1DF0-0x00000001808A2010
	private void HideEmpty(); // 0x00000001808A2010-0x00000001808A2150
	private static string ShortDate(string iso); // 0x00000001808A2150-0x00000001808A23A0
	private static string LongDate(string iso); // 0x00000001808A23A0-0x00000001808A2550
	private static UnityEngine.UI.Text Txt(Transform root, string path); // 0x00000001808A2550-0x00000001808A26D0
	private static Image Img(Transform root, string path); // 0x00000001808A26D0-0x00000001808A2850
	private static GameObject Go(Transform root, string path); // 0x00000001808A2850-0x00000001808A29C0
	[CompilerGenerated]
	private void _Wire_b__70_0(); // 0x00000001808A2BF0-0x00000001808A2C00
	[CompilerGenerated]
	private void _Wire_b__70_1(); // 0x00000001808A2C00-0x00000001808A2C10
	[CompilerGenerated]
	private void _LoadPending_b__74_0(List<GiftDTO> list); // 0x00000001808A2C10-0x00000001808A2C60
}

