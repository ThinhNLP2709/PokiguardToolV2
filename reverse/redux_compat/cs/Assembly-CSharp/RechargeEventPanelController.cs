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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class RechargeEventPanelController : MonoBehaviour, IPokyEventPanel // TypeDefIndex: 733
{
	// Fields
	public const string PANEL_KEY = "PanelRechargeEvent"; // Metadata: 0x0064C881
	public const int TAB_COUNT = 3; // Metadata: 0x0064C894
	private const int TAB_DAILY = 0; // Metadata: 0x0064C895
	private const int TAB_ACCUMULATE = 1; // Metadata: 0x0064C896
	private const int TAB_REVOLVE = 2; // Metadata: 0x0064C897
	private static readonly string[] TAB_TYPE; // 0x00
	private static readonly string[] TAB_KEY; // 0x08
	private static readonly string[] TAB_TEXT; // 0x10
	private const float TICK_SEC = 1f; // Metadata: 0x0064C898
	private const float WS_RELOAD_GAP_SEC = 1.5f; // Metadata: 0x0064C89C
	[Header("Khung")]
	[SerializeField]
	private GameObject frame; // 0x20
	[SerializeField]
	private Button btnClose; // 0x28
	[Header("3 th\u1EBB tab b\u00EAn tr\u00E1i")]
	[SerializeField]
	private TabRefs[] tabs; // 0x30
	[Header("3 trang n\u1ED9i dung")]
	[SerializeField]
	private LayoutRefs[] layouts; // 0x38
	private readonly RechargeEventDTO[] _events; // 0x40
	private readonly List<RechargeEventItemView>[] _rows; // 0x48
	private int _userId; // 0x50
	private int _selected; // 0x54
	private bool _busy; // 0x58
	private bool _wired; // 0x59
	private bool _subscribed; // 0x5A
	private bool _openedOnce; // 0x5B
	private bool _suppressToggle; // 0x5C
	private long _serverOffsetMs; // 0x60
	private bool _hasServerTime; // 0x68
	private float _nextTick; // 0x6C
	private float _nextWsReload; // 0x70
	private readonly List<int> _tweenIds; // 0x78
	public const string PREVIEW_PREF = "RechargeEventPreview"; // Metadata: 0x0064C8A0

	// Nested types
	[Serializable]
	public class TabRefs // TypeDefIndex: 734
	{
		// Fields
		public Toggle toggle; // 0x10
		public UnityEngine.UI.Text label; // 0x18
		public GameObject notify; // 0x20

		// Constructors
		public TabRefs(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class LayoutRefs // TypeDefIndex: 735
	{
		// Fields
		public GameObject root; // 0x10
		public UnityEngine.UI.Text title; // 0x18
		public RectTransform content; // 0x20
		public UnityEngine.UI.Text txtTimer; // 0x28
		public GameObject rowPrefab; // 0x30
		public UnityEngine.UI.Text txtExtra; // 0x38

		// Constructors
		public LayoutRefs(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass38_0 // TypeDefIndex: 736
	{
		// Fields
		public int idx; // 0x10
		public RechargeEventPanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass38_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _EnsureWired_b__0(bool on); // 0x000000018040B330-0x000000018040B360
	}

	[CompilerGenerated]
	private sealed class _LoadStatus_d__43 : IEnumerator<object> // TypeDefIndex: 737
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RechargeEventPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadStatus_d__43(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804087D0-0x00000001804089D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804089D0-0x0000000180408A10
	}

	// Constructors
	public RechargeEventPanelController(); // 0x00000001803ED700-0x00000001803ED840
	static RechargeEventPanelController(); // 0x00000001803ED470-0x00000001803ED700

	// Methods
	private void Awake(); // 0x00000001803E8750-0x00000001803E8760
	private void Start(); // 0x00000001803ECAF0-0x00000001803ECB00
	public void OpenPanel(); // 0x00000001803EAAC0-0x00000001803EACC0
	private void OnEnable(); // 0x00000001803EA840-0x00000001803EA850
	private void OnDisable(); // 0x00000001803EA770-0x00000001803EA840
	private void Subscribe(); // 0x00000001803ECBA0-0x00000001803ECC60
	private void Unsubscribe(); // 0x00000001803ED1C0-0x00000001803ED280
	private void Update(); // 0x00000001803ED340-0x00000001803ED3A0
	private void EnsureWired(); // 0x00000001803E8A90-0x00000001803E9BE0
	private static T[] Grow<T>(T[] src)
		where T : new();
	private static void Wire(Button b, UnityAction action); // 0x00000001803ED3A0-0x00000001803ED470
	private void SetPlaceholders(); // 0x00000001803EC620-0x00000001803EC9B0
	private void ClosePanel(); // 0x00000001803E8920-0x00000001803E8A90
	[IteratorStateMachine(typeof(_LoadStatus_d__43))]
	private IEnumerator LoadStatus(); // 0x00000001803E9F10-0x00000001803E9F80
	private void OnStatusOk(RechargeEventStatusData d); // 0x00000001803EA9C0-0x00000001803EAA60
	private void ApplyStatus(RechargeEventStatusData d); // 0x00000001803E84B0-0x00000001803E8750
	private void OnStatusErr(string err); // 0x00000001803EA8F0-0x00000001803EA9C0
	private static int TabOf(RechargeEventDTO e); // 0x00000001803ECEA0-0x00000001803ECFA0
	private void RenderAll(); // 0x00000001803EAEA0-0x00000001803EB3C0
	private void SelectTab(int index); // 0x00000001803EC2E0-0x00000001803EC5D0
	private void OnSelectTab(int index); // 0x00000001803EA890-0x00000001803EA8F0
	private void RenderLayout(int index); // 0x00000001803EB830-0x00000001803EBA00
	private void RenderExtra(int index, RechargeEventDTO ev); // 0x00000001803EB3C0-0x00000001803EB830
	private void RenderRows(int index, RechargeEventDTO ev); // 0x00000001803EBA00-0x00000001803EBEB0
	private void ClearRows(int index); // 0x00000001803E8820-0x00000001803E8920
	private static string TitleOf(int index, RechargeMilestoneDTO m); // 0x00000001803ECFA0-0x00000001803ED1C0
	private static string ProgressOf(RechargeEventDTO ev, RechargeMilestoneDTO m); // 0x00000001803EAD50-0x00000001803EAEA0
	private static RechargeMilestoneStatus StatusOf(RechargeMilestoneDTO m); // 0x00000001803ECB00-0x00000001803ECBA0
	private void RenderTimer(int index); // 0x00000001803EBEB0-0x00000001803EC2E0
	private void OnClickClaim(long milestoneId); // 0x00000001803EA440-0x00000001803EA770
	private void OnClaimOk(RechargeEventClaimData d); // 0x00000001803EA120-0x00000001803EA440
	private void OnClaimErr(string err); // 0x00000001803EA060-0x00000001803EA120
	private void SyncButtons(); // 0x00000001803ECC60-0x00000001803ECEA0
	private void OpenRecharge(); // 0x00000001803EACC0-0x00000001803EAD50
	private void UpdateWallet(RechargeEventWallet w); // 0x00000001803ED280-0x00000001803ED340
	private void OnWsProgress(); // 0x00000001803EAA60-0x00000001803EAAC0
	private void OnRechargeOk(int safiaAdded, int newBalance); // 0x00000001803EA850-0x00000001803EA890
	private void CancelFx(); // 0x00000001803E8760-0x00000001803E8820
	private static long NowLocalMs(); // 0x00000001803E9F80-0x00000001803EA060
	private long ServerNowMs(); // 0x00000001803EC5D0-0x00000001803EC620
	private static string FormatRemain(long ms); // 0x00000001803E9CF0-0x00000001803E9EB0
	private static string FormatVnd(long amount); // 0x00000001803E9EB0-0x00000001803E9F10
	private static string ShortVnd(long amount); // 0x00000001803EC9B0-0x00000001803ECAF0
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001803E9BE0-0x00000001803E9CF0
}

