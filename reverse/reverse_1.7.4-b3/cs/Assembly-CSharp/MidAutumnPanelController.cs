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

public class MidAutumnPanelController : MonoBehaviour, IPokyEventPanel // TypeDefIndex: 1116
{
	// Fields
	public const string PANEL_KEY = "PanelMidAutumn"; // Metadata: 0x005EF41E
	[SerializeField]
	private Transform root; // 0x20
	[SerializeField]
	private Button btnClose; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtTitle; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtTimer; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtPoints; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtDaily; // 0x48
	[SerializeField]
	private Image barFill; // 0x50
	[SerializeField]
	private Transform missionContent; // 0x58
	[SerializeField]
	private Transform milestoneContent; // 0x60
	[SerializeField]
	private Transform flipGrid; // 0x68
	[SerializeField]
	private UnityEngine.UI.Text txtFlipsLeft; // 0x70
	[SerializeField]
	private Button btnBuyFlip; // 0x78
	[SerializeField]
	private UnityEngine.UI.Text txtBuyPrice; // 0x80
	[SerializeField]
	private Transform pieceRow; // 0x88
	[SerializeField]
	private Button btnCraft; // 0x90
	[SerializeField]
	private UnityEngine.UI.Text txtCraftInfo; // 0x98
	[SerializeField]
	private GameObject rewardPopup; // 0xA0
	[SerializeField]
	private UnityEngine.UI.Text txtRewardTitle; // 0xA8
	[SerializeField]
	private Transform rewardIconRow; // 0xB0
	[SerializeField]
	private GameObject infoPopup; // 0xB8
	[SerializeField]
	private UnityEngine.UI.Text txtInfoBody; // 0xC0
	[SerializeField]
	private Image flashOverlay; // 0xC8
	[SerializeField]
	private ParticleSystem jackpotFx; // 0xD0
	private MidAutumnState _state; // 0xD8
	private int _userId; // 0xE0
	private bool _loading; // 0xE4
	private bool _busy; // 0xE5
	private bool _wired; // 0xE6
	private Coroutine _timerCo; // 0xE8
	private Coroutine _countUpCo; // 0xF0
	private int _shownPoints; // 0xF8
	private int _tappedCard; // 0xFC
	private readonly List<GameObject> _missionPool; // 0x100
	private readonly List<GameObject> _milestonePool; // 0x108
	private readonly List<GameObject> _flipPool; // 0x110
	private readonly List<GameObject> _iconPool; // 0x118
	private GameObject _missionTpl; // 0x120
	private GameObject _milestoneTpl; // 0x128
	private GameObject _iconTpl; // 0x130
	private const int MILESTONE_GRID_MAX = 6; // Metadata: 0x005EF42D

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 1117
	{
		// Fields
		public int idx; // 0x10
		public MidAutumnPanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass47_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _WireFlipCards_b__0(); // 0x000000018068F6F0-0x000000018068F730
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass49_0 // TypeDefIndex: 1118
	{
		// Fields
		public MidAutumnPanelController __4__this; // 0x10
		public bool showLoginToast; // 0x18

		// Constructors
		public __c__DisplayClass49_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadStateCo_b__0(MidAutumnState data); // 0x000000018068F730-0x000000018068F8B0
		internal void _LoadStateCo_b__1(string err); // 0x000000018068F8B0-0x000000018068F980
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass55_0 // TypeDefIndex: 1119
	{
		// Fields
		public long msId; // 0x10
		public MidAutumnPanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass55_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RenderMilestones_b__0(); // 0x000000018068F980-0x000000018068F9B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass59_0 // TypeDefIndex: 1120
	{
		// Fields
		public MidAutumnPanelController __4__this; // 0x10
		public long milestoneId; // 0x18

		// Constructors
		public __c__DisplayClass59_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DoClaim_b__0(MidAutumnState data); // 0x000000018068F9B0-0x000000018068FAD0
		internal void _DoClaim_b__1(string err); // 0x000000018068FAD0-0x000000018068FB70
	}

	[CompilerGenerated]
	private sealed class _CountUp_d__53 : IEnumerator<object> // TypeDefIndex: 1121
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int from; // 0x20
		public int to; // 0x24
		public MidAutumnPanelController __4__this; // 0x28
		private float _t_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CountUp_d__53(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018068FB70-0x000000018068FFD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018068FFD0-0x0000000180690010
	}

	[CompilerGenerated]
	private sealed class _Flash_d__66 : IEnumerator<object> // TypeDefIndex: 1122
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MidAutumnPanelController __4__this; // 0x20
		public float dur; // 0x28
		public float peak; // 0x2C
		private float _half_5__2; // 0x30
		private float _t_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Flash_d__66(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180690010-0x0000000180690380
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180690380-0x00000001806903C0
	}

	[CompilerGenerated]
	private sealed class _FlipCard_d__65 : IEnumerator<object> // TypeDefIndex: 1123
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Transform card; // 0x20
		private Vector3 _s0_5__2; // 0x28
		private float _t_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FlipCard_d__65(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001806903C0-0x0000000180690880
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180690880-0x00000001806908C0
	}

	[CompilerGenerated]
	private sealed class _LoadStateCo_d__49 : IEnumerator<object> // TypeDefIndex: 1124
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MidAutumnPanelController __4__this; // 0x20
		public bool showLoginToast; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadStateCo_d__49(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001806908C0-0x0000000180690C30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180690C30-0x0000000180690C70
	}

	[CompilerGenerated]
	private sealed class _PlayFlip_d__64 : IEnumerator<object> // TypeDefIndex: 1125
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MidAutumnPanelController __4__this; // 0x20
		public MidAutumnFlipResult res; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayFlip_d__64(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180690C70-0x0000000180691340
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180691340-0x0000000180691380
	}

	[CompilerGenerated]
	private sealed class _PopIn_d__68 : IEnumerator<object> // TypeDefIndex: 1126
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public bool big; // 0x20
		public Transform t; // 0x28
		private float _target_5__2; // 0x30
		private float _over_5__3; // 0x34
		private float _e_5__4; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PopIn_d__68(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180691380-0x0000000180691690
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180691690-0x00000001806916D0
	}

	[CompilerGenerated]
	private sealed class _TickTimer_d__75 : IEnumerator<object> // TypeDefIndex: 1127
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MidAutumnPanelController __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _TickTimer_d__75(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001806916D0-0x00000001806919B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806919B0-0x00000001806919F0
	}

	// Constructors
	public MidAutumnPanelController(); // 0x000000018068F160-0x000000018068F3D0

	// Methods
	private void Awake(); // 0x00000001806846F0-0x0000000180684700
	public void OpenPanel(); // 0x0000000180684700-0x0000000180684890
	public void ClosePanel(); // 0x0000000180684890-0x0000000180684AA0
	private void OnDisable(); // 0x0000000180684AA0-0x0000000180684AB0
	private void Wire(); // 0x0000000180684AB0-0x0000000180685D60
	private void CaptureTemplates(); // 0x0000000180685D60-0x0000000180685ED0
	private GameObject FirstChildTemplate(Transform parent, List<GameObject> pool); // 0x0000000180685ED0-0x0000000180686340
	private void WireFlipCards(); // 0x0000000180686340-0x0000000180686850
	private void LoadState(bool showLoginToast); // 0x0000000180686850-0x0000000180686920
	[IteratorStateMachine(typeof(_LoadStateCo_d__49))]
	private IEnumerator LoadStateCo(bool showLoginToast); // 0x0000000180686920-0x00000001806869D0
	private void Render(); // 0x00000001806869D0-0x0000000180686C30
	private void RenderPoints(); // 0x0000000180686C30-0x0000000180687040
	private int NextMilestonePoints(); // 0x0000000180687040-0x00000001806871B0
	[IteratorStateMachine(typeof(_CountUp_d__53))]
	private IEnumerator CountUp(int from, int to); // 0x00000001806871B0-0x0000000180687270
	private void RenderMissions(); // 0x0000000180687270-0x0000000180687730
	private void RenderMilestones(); // 0x0000000180687730-0x0000000180688170
	private void RenderMinigame(); // 0x0000000180688170-0x00000001806888C0
	private void ResetFlipCards(); // 0x00000001806888C0-0x0000000180688CD0
	private void RenderPieces(); // 0x0000000180688CD0-0x0000000180689340
	private void DoClaim(long milestoneId); // 0x0000000180689340-0x00000001806897B0
	private void DoFlip(bool paid); // 0x00000001806897B0-0x0000000180689C60
	private void DoCraft(); // 0x0000000180689C60-0x0000000180689FD0
	private static string NewNonce(); // 0x0000000180689FD0-0x000000018068A070
	private MidAutumnMilestone FindMilestone(long id); // 0x000000018068A070-0x000000018068A1A0
	[IteratorStateMachine(typeof(_PlayFlip_d__64))]
	private IEnumerator PlayFlip(MidAutumnFlipResult res); // 0x000000018068A1A0-0x000000018068A2B0
	[IteratorStateMachine(typeof(_FlipCard_d__65))]
	private IEnumerator FlipCard(Transform card); // 0x000000018068A2B0-0x000000018068A350
	[IteratorStateMachine(typeof(_Flash_d__66))]
	private IEnumerator Flash(float peak, float dur); // 0x000000018068A350-0x000000018068A410
	private void ShowReward(string title, List<MidAutumnRewardIcon> icons, bool big); // 0x000000018068A410-0x000000018068ABE0
	[IteratorStateMachine(typeof(_PopIn_d__68))]
	private IEnumerator PopIn(Transform t, bool big); // 0x000000018068ABE0-0x000000018068AC90
	public void ShowInfo(); // 0x000000018068AC90-0x000000018068AF60
	public void CloseInfo(); // 0x000000018068AF60-0x000000018068B0B0
	private string BuildDescription(); // 0x000000018068B0B0-0x000000018068B610
	public void CloseRewardPopup(); // 0x000000018068B610-0x000000018068B770
	private void StartTimer(); // 0x000000018068B770-0x000000018068B890
	private void StopTimer(); // 0x000000018068B890-0x000000018068B910
	[IteratorStateMachine(typeof(_TickTimer_d__75))]
	private IEnumerator TickTimer(); // 0x000000018068B910-0x000000018068B9B0
	private static string FormatDuration(long sec); // 0x000000018068B9B0-0x000000018068BC30
	private static List<MidAutumnRewardIcon> HeadlineFirst(List<MidAutumnRewardIcon> icons); // 0x000000018068BC30-0x000000018068C070
	private static void FillRewardGrid(Transform grid, List<MidAutumnRewardIcon> icons); // 0x000000018068C070-0x000000018068C6F0
	private static string CompactAmount(int n); // 0x000000018068C6F0-0x000000018068C800
	private static string TrimZero(float v); // 0x000000018068C800-0x000000018068C8F0
	private static void AttachMilestoneTooltip(GameObject host, MidAutumnMilestone m, List<MidAutumnRewardIcon> icons); // 0x000000018068C8F0-0x000000018068CDF0
	private static Sprite SpriteFor(MidAutumnRewardIcon ic); // 0x000000018068CDF0-0x000000018068CE70
	private void EnsurePool(List<GameObject> pool, GameObject tpl, Transform parent, int need); // 0x000000018068CE70-0x000000018068D170
	private static bool ApplyRewardIcon(Image img, MidAutumnRewardIcon ic); // 0x000000018068D170-0x000000018068D4B0
	private static string OtaPathOf(MidAutumnRewardIcon ic); // 0x000000018068D4B0-0x000000018068D800
	private static Sprite RewardSprite(MidAutumnRewardIcon ic); // 0x000000018068D800-0x000000018068DB70
	private static string ServerTypeToClient(string t); // 0x000000018068DB70-0x000000018068E0A0
	private void SetInteractable(bool on); // 0x000000018068E0A0-0x000000018068E5E0
	private static string FriendlyError(string raw, string fallback); // 0x000000018068E5E0-0x000000018068E900
	private void ShowMessage(string msg); // 0x000000018068E900-0x000000018068EA20
	private void Toast(string msg); // 0x000000018068EA20-0x000000018068EAF0
	private static void SetText(Transform parent, string node, string value); // 0x000000018068EAF0-0x000000018068EC40
	private static void SetActiveNode(Transform parent, string node, bool on); // 0x000000018068EC40-0x000000018068EDB0
	private static void SetAlpha(Graphic g, float a); // 0x000000018068EDB0-0x000000018068EF00
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x000000018068EF00-0x000000018068F160
	[CompilerGenerated]
	private void _Wire_b__44_0(); // 0x000000018068F3D0-0x000000018068F3E0
	[CompilerGenerated]
	private void _DoFlip_b__60_0(MidAutumnFlipResult res); // 0x000000018068F3E0-0x000000018068F520
	[CompilerGenerated]
	private void _DoFlip_b__60_1(string err); // 0x000000018068F520-0x000000018068F5A0
	[CompilerGenerated]
	private void _DoCraft_b__61_0(MidAutumnCraftResult res); // 0x000000018068F5A0-0x000000018068F670
	[CompilerGenerated]
	private void _DoCraft_b__61_1(string err); // 0x000000018068F670-0x000000018068F6F0
}

