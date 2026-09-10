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
public class RechargeEventPanelController : MonoBehaviour, IPokyEventPanel // TypeDefIndex: 923
{
	// Fields
	public const string PANEL_KEY = "PanelRechargeEvent"; // Metadata: 0x0068BF41
	public const int TAB_COUNT = 3; // Metadata: 0x0068BF54
	private const int TAB_DAILY = 0; // Metadata: 0x0068BF55
	private const int TAB_ACCUMULATE = 1; // Metadata: 0x0068BF56
	private const int TAB_REVOLVE = 2; // Metadata: 0x0068BF57
	private static readonly string[] TAB_TYPE; // 0x00
	private static readonly string[] TAB_KEY; // 0x08
	private static readonly string[] TAB_TEXT; // 0x10
	private const float TICK_SEC = 1f; // Metadata: 0x0068BF58
	private const float WS_RELOAD_GAP_SEC = 1.5f; // Metadata: 0x0068BF5C
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
	public const string PREVIEW_PREF = "RechargeEventPreview"; // Metadata: 0x0068BF60

	// Nested types
	[Serializable]
	public class TabRefs // TypeDefIndex: 924
	{
		// Fields
		public Toggle toggle; // 0x10
		public UnityEngine.UI.Text label; // 0x18
		public GameObject notify; // 0x20

		// Constructors
		public TabRefs(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class LayoutRefs // TypeDefIndex: 925
	{
		// Fields
		public GameObject root; // 0x10
		public UnityEngine.UI.Text title; // 0x18
		public RectTransform content; // 0x20
		public UnityEngine.UI.Text txtTimer; // 0x28
		public GameObject rowPrefab; // 0x30
		public UnityEngine.UI.Text txtExtra; // 0x38

		// Constructors
		public LayoutRefs(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass38_0 // TypeDefIndex: 926
	{
		// Fields
		public int idx; // 0x10
		public RechargeEventPanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass38_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _EnsureWired_b__0(bool on); // 0x00000001804E19F0-0x00000001804E1A70
	}

	[CompilerGenerated]
	private sealed class _LoadStatus_d__43 : IEnumerator<object> // TypeDefIndex: 927
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RechargeEventPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadStatus_d__43(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804DE740-0x00000001804DE940
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804DE940-0x00000001804DE980
	}

	// Constructors
	public RechargeEventPanelController(); // 0x00000001804DB590-0x00000001804DB6D0
	static RechargeEventPanelController(); // 0x00000001804DB300-0x00000001804DB590

	// Methods
	private void Awake(); // 0x00000001804D6570-0x00000001804D6580
	private void Start(); // 0x00000001804DA980-0x00000001804DA990
	public void OpenPanel(); // 0x00000001804D8960-0x00000001804D8B50
	private void OnEnable(); // 0x00000001804D86A0-0x00000001804D86B0
	private void OnDisable(); // 0x00000001804D85D0-0x00000001804D86A0
	private void Subscribe(); // 0x00000001804DAA30-0x00000001804DAAF0
	private void Unsubscribe(); // 0x00000001804DB050-0x00000001804DB110
	private void Update(); // 0x00000001804DB1D0-0x00000001804DB230
	private void EnsureWired(); // 0x00000001804D68B0-0x00000001804D7A00
	private static T[] Grow<T>(T[] src)
		where T : new();
	private static void Wire(Button b, UnityAction action); // 0x00000001804DB230-0x00000001804DB300
	private void SetPlaceholders(); // 0x00000001804DA4B0-0x00000001804DA840
	private void ClosePanel(); // 0x00000001804D6740-0x00000001804D68B0
	[IteratorStateMachine(typeof(_LoadStatus_d__43))]
	private IEnumerator LoadStatus(); // 0x00000001804D7D30-0x00000001804D7DA0
	private void OnStatusOk(RechargeEventStatusData d); // 0x00000001804D8860-0x00000001804D8900
	private void ApplyStatus(RechargeEventStatusData d); // 0x00000001804D62D0-0x00000001804D6570
	private void OnStatusErr(string err); // 0x00000001804D8790-0x00000001804D8860
	private static int TabOf(RechargeEventDTO e); // 0x00000001804DAD30-0x00000001804DAE30
	private void RenderAll(); // 0x00000001804D8D30-0x00000001804D9250
	private void SelectTab(int index); // 0x00000001804DA170-0x00000001804DA460
	private void OnSelectTab(int index); // 0x00000001804D8730-0x00000001804D8790
	private void RenderLayout(int index); // 0x00000001804D96C0-0x00000001804D9890
	private void RenderExtra(int index, RechargeEventDTO ev); // 0x00000001804D9250-0x00000001804D96C0
	private void RenderRows(int index, RechargeEventDTO ev); // 0x00000001804D9890-0x00000001804D9D40
	private void ClearRows(int index); // 0x00000001804D6640-0x00000001804D6740
	private static string TitleOf(int index, RechargeMilestoneDTO m); // 0x00000001804DAE30-0x00000001804DB050
	private static string ProgressOf(RechargeEventDTO ev, RechargeMilestoneDTO m); // 0x00000001804D8BE0-0x00000001804D8D30
	private static RechargeMilestoneStatus StatusOf(RechargeMilestoneDTO m); // 0x00000001804DA990-0x00000001804DAA30
	private void RenderTimer(int index); // 0x00000001804D9D40-0x00000001804DA170
	private void OnClickClaim(long milestoneId); // 0x00000001804D82A0-0x00000001804D85D0
	private void OnClaimOk(RechargeEventClaimData d); // 0x00000001804D7F80-0x00000001804D82A0
	private void OnClaimErr(string err); // 0x00000001804D7E80-0x00000001804D7F80
	private void SyncButtons(); // 0x00000001804DAAF0-0x00000001804DAD30
	private void OpenRecharge(); // 0x00000001804D8B50-0x00000001804D8BE0
	private void UpdateWallet(RechargeEventWallet w); // 0x00000001804DB110-0x00000001804DB1D0
	private void OnWsProgress(); // 0x00000001804D8900-0x00000001804D8960
	private void OnRechargeOk(int safiaAdded, int newBalance); // 0x00000001804D86B0-0x00000001804D8730
	private void CancelFx(); // 0x00000001804D6580-0x00000001804D6640
	private static long NowLocalMs(); // 0x00000001804D7DA0-0x00000001804D7E80
	private long ServerNowMs(); // 0x00000001804DA460-0x00000001804DA4B0
	private static string FormatRemain(long ms); // 0x00000001804D7B10-0x00000001804D7CD0
	private static string FormatVnd(long amount); // 0x00000001804D7CD0-0x00000001804D7D30
	private static string ShortVnd(long amount); // 0x00000001804DA840-0x00000001804DA980
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001804D7A00-0x00000001804D7B10
}

