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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class RechargeEventPanelController : MonoBehaviour, IPokyEventPanel // TypeDefIndex: 1184
{
	// Fields
	public const string PANEL_KEY = "PanelRechargeEvent"; // Metadata: 0x005F08FA
	public const int TAB_COUNT = 3; // Metadata: 0x005F090D
	private const int TAB_DAILY = 0; // Metadata: 0x005F090E
	private const int TAB_ACCUMULATE = 1; // Metadata: 0x005F090F
	private const int TAB_REVOLVE = 2; // Metadata: 0x005F0910
	private static readonly string[] TAB_TYPE; // 0x00
	private static readonly string[] TAB_KEY; // 0x08
	private static readonly string[] TAB_TEXT; // 0x10
	private const float TICK_SEC = 1f; // Metadata: 0x005F0911
	private const float WS_RELOAD_GAP_SEC = 1.5f; // Metadata: 0x005F0915
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
	public const string PREVIEW_PREF = "RechargeEventPreview"; // Metadata: 0x005F0919

	// Nested types
	[Serializable]
	public class TabRefs // TypeDefIndex: 1185
	{
		// Fields
		public Toggle toggle; // 0x10
		public UnityEngine.UI.Text label; // 0x18
		public GameObject notify; // 0x20

		// Constructors
		public TabRefs(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	public class LayoutRefs // TypeDefIndex: 1186
	{
		// Fields
		public GameObject root; // 0x10
		public UnityEngine.UI.Text title; // 0x18
		public RectTransform content; // 0x20
		public UnityEngine.UI.Text txtTimer; // 0x28
		public GameObject rowPrefab; // 0x30
		public UnityEngine.UI.Text txtExtra; // 0x38

		// Constructors
		public LayoutRefs(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass38_0 // TypeDefIndex: 1187
	{
		// Fields
		public int idx; // 0x10
		public RechargeEventPanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass38_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _EnsureWired_b__0(bool on); // 0x00000001806C9FE0-0x00000001806CA060
	}

	[CompilerGenerated]
	private sealed class _LoadStatus_d__43 : IEnumerator<object> // TypeDefIndex: 1188
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RechargeEventPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadStatus_d__43(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001806CA060-0x00000001806CA300
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806CA300-0x00000001806CA340
	}

	// Constructors
	public RechargeEventPanelController(); // 0x00000001806C99B0-0x00000001806C9C90
	static RechargeEventPanelController(); // 0x00000001806C9C90-0x00000001806C9FE0

	// Methods
	private void Awake(); // 0x00000001806C2810-0x00000001806C2820
	private void Start(); // 0x00000001806C2820-0x00000001806C2830
	public void OpenPanel(); // 0x00000001806C2830-0x00000001806C2DC0
	private void OnEnable(); // 0x00000001806C2DC0-0x00000001806C2DD0
	private void OnDisable(); // 0x00000001806C2DD0-0x00000001806C2EC0
	private void Subscribe(); // 0x00000001806C2EC0-0x00000001806C2FA0
	private void Unsubscribe(); // 0x00000001806C2FA0-0x00000001806C3080
	private void Update(); // 0x00000001806C3080-0x00000001806C3150
	private void EnsureWired(); // 0x00000001806C3150-0x00000001806C4800
	private static T[] Grow<T>(T[] src)
		where T : new();
	private static void Wire(Button b, UnityAction action); // 0x00000001806C4800-0x00000001806C4990
	private void SetPlaceholders(); // 0x00000001806C4990-0x00000001806C4EF0
	private void ClosePanel(); // 0x00000001806C4EF0-0x00000001806C5100
	[IteratorStateMachine(typeof(_LoadStatus_d__43))]
	private IEnumerator LoadStatus(); // 0x00000001806C5100-0x00000001806C51A0
	private void OnStatusOk(RechargeEventStatusData d); // 0x00000001806C51A0-0x00000001806C5270
	private void ApplyStatus(RechargeEventStatusData d); // 0x00000001806C5270-0x00000001806C5600
	private void OnStatusErr(string err); // 0x00000001806C5600-0x00000001806C5710
	private static int TabOf(RechargeEventDTO e); // 0x00000001806C5710-0x00000001806C58B0
	private void RenderAll(); // 0x00000001806C58B0-0x00000001806C6070
	private void SelectTab(int index); // 0x00000001806C6070-0x00000001806C6460
	private void OnSelectTab(int index); // 0x00000001806C6460-0x00000001806C64C0
	private void RenderLayout(int index); // 0x00000001806C64C0-0x00000001806C6720
	private void RenderExtra(int index, RechargeEventDTO ev); // 0x00000001806C6720-0x00000001806C6CF0
	private void RenderRows(int index, RechargeEventDTO ev); // 0x00000001806C6CF0-0x00000001806C7450
	private void ClearRows(int index); // 0x00000001806C7450-0x00000001806C75F0
	private static string TitleOf(int index, RechargeMilestoneDTO m); // 0x00000001806C75F0-0x00000001806C78B0
	private static string ProgressOf(RechargeEventDTO ev, RechargeMilestoneDTO m); // 0x00000001806C78B0-0x00000001806C7970
	private static RechargeMilestoneStatus StatusOf(RechargeMilestoneDTO m); // 0x00000001806C7970-0x00000001806C7B40
	private void RenderTimer(int index); // 0x00000001806C7B40-0x00000001806C7E90
	private void OnClickClaim(long milestoneId); // 0x00000001806C7E90-0x00000001806C8330
	private void OnClaimOk(RechargeEventClaimData d); // 0x00000001806C8330-0x00000001806C8800
	private void OnClaimErr(string err); // 0x00000001806C8800-0x00000001806C88F0
	private void SyncButtons(); // 0x00000001806C88F0-0x00000001806C8BB0
	private void OpenRecharge(); // 0x00000001806C8BB0-0x00000001806C8CC0
	private void UpdateWallet(RechargeEventWallet w); // 0x00000001806C8CC0-0x00000001806C8DF0
	private void OnWsProgress(); // 0x00000001806C8DF0-0x00000001806C8F30
	private void OnRechargeOk(int safiaAdded, int newBalance); // 0x00000001806C8F30-0x00000001806C8FD0
	private void CancelFx(); // 0x00000001806C8FD0-0x00000001806C9130
	private static long NowLocalMs(); // 0x00000001806C9130-0x00000001806C9230
	private long ServerNowMs(); // 0x00000001806C9230-0x00000001806C9290
	private static string FormatRemain(long ms); // 0x00000001806C9290-0x00000001806C9510
	private static string FormatVnd(long amount); // 0x00000001806C9510-0x00000001806C9600
	private static string ShortVnd(long amount); // 0x00000001806C9600-0x00000001806C9750
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001806C9750-0x00000001806C99B0
}

