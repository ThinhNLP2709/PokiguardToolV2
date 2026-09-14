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

public class MidAutumnPanelController : MonoBehaviour, IPokyEventPanel // TypeDefIndex: 1118
{
	// Fields
	public const string PANEL_KEY = "PanelMidAutumn"; // Metadata: 0x005F07EB
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
	private const int MILESTONE_GRID_MAX = 6; // Metadata: 0x005F07FA

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 1119
	{
		// Fields
		public int idx; // 0x10
		public MidAutumnPanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass47_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _WireFlipCards_b__0(); // 0x00000001806910A0-0x00000001806910E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass49_0 // TypeDefIndex: 1120
	{
		// Fields
		public MidAutumnPanelController __4__this; // 0x10
		public bool showLoginToast; // 0x18

		// Constructors
		public __c__DisplayClass49_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadStateCo_b__0(MidAutumnState data); // 0x00000001806910E0-0x0000000180691260
		internal void _LoadStateCo_b__1(string err); // 0x0000000180691260-0x0000000180691330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass55_0 // TypeDefIndex: 1121
	{
		// Fields
		public long msId; // 0x10
		public MidAutumnPanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass55_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RenderMilestones_b__0(); // 0x0000000180691330-0x0000000180691360
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass59_0 // TypeDefIndex: 1122
	{
		// Fields
		public MidAutumnPanelController __4__this; // 0x10
		public long milestoneId; // 0x18

		// Constructors
		public __c__DisplayClass59_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DoClaim_b__0(MidAutumnState data); // 0x0000000180691360-0x0000000180691480
		internal void _DoClaim_b__1(string err); // 0x0000000180691480-0x0000000180691520
	}

	[CompilerGenerated]
	private sealed class _CountUp_d__53 : IEnumerator<object> // TypeDefIndex: 1123
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180691520-0x0000000180691980
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180691980-0x00000001806919C0
	}

	[CompilerGenerated]
	private sealed class _Flash_d__66 : IEnumerator<object> // TypeDefIndex: 1124
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001806919C0-0x0000000180691D30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180691D30-0x0000000180691D70
	}

	[CompilerGenerated]
	private sealed class _FlipCard_d__65 : IEnumerator<object> // TypeDefIndex: 1125
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180691D70-0x0000000180692230
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180692230-0x0000000180692270
	}

	[CompilerGenerated]
	private sealed class _LoadStateCo_d__49 : IEnumerator<object> // TypeDefIndex: 1126
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180692270-0x0000000180692610
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180692610-0x0000000180692650
	}

	[CompilerGenerated]
	private sealed class _PlayFlip_d__64 : IEnumerator<object> // TypeDefIndex: 1127
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180692650-0x0000000180692D20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180692D20-0x0000000180692D60
	}

	[CompilerGenerated]
	private sealed class _PopIn_d__68 : IEnumerator<object> // TypeDefIndex: 1128
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180692D60-0x0000000180693070
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180693070-0x00000001806930B0
	}

	[CompilerGenerated]
	private sealed class _TickTimer_d__75 : IEnumerator<object> // TypeDefIndex: 1129
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
		private bool MoveNext(); // 0x00000001806930B0-0x0000000180693390
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180693390-0x00000001806933D0
	}

	// Constructors
	public MidAutumnPanelController(); // 0x0000000180690B10-0x0000000180690D80

	// Methods
	private void Awake(); // 0x0000000180686020-0x0000000180686030
	public void OpenPanel(); // 0x0000000180686030-0x00000001806861C0
	public void ClosePanel(); // 0x00000001806861C0-0x00000001806863D0
	private void OnDisable(); // 0x00000001806863D0-0x00000001806863E0
	private void Wire(); // 0x00000001806863E0-0x0000000180687690
	private void CaptureTemplates(); // 0x0000000180687690-0x0000000180687800
	private GameObject FirstChildTemplate(Transform parent, List<GameObject> pool); // 0x0000000180687800-0x0000000180687C70
	private void WireFlipCards(); // 0x0000000180687C70-0x0000000180688180
	private void LoadState(bool showLoginToast); // 0x0000000180688180-0x0000000180688250
	[IteratorStateMachine(typeof(_LoadStateCo_d__49))]
	private IEnumerator LoadStateCo(bool showLoginToast); // 0x0000000180688250-0x0000000180688300
	private void Render(); // 0x0000000180688300-0x0000000180688560
	private void RenderPoints(); // 0x0000000180688560-0x0000000180688970
	private int NextMilestonePoints(); // 0x0000000180688970-0x0000000180688AE0
	[IteratorStateMachine(typeof(_CountUp_d__53))]
	private IEnumerator CountUp(int from, int to); // 0x0000000180688AE0-0x0000000180688BA0
	private void RenderMissions(); // 0x0000000180688BA0-0x0000000180689060
	private void RenderMilestones(); // 0x0000000180689060-0x0000000180689AA0
	private void RenderMinigame(); // 0x0000000180689AA0-0x000000018068A1F0
	private void ResetFlipCards(); // 0x000000018068A1F0-0x000000018068A600
	private void RenderPieces(); // 0x000000018068A600-0x000000018068AC70
	private void DoClaim(long milestoneId); // 0x000000018068AC70-0x000000018068B110
	private void DoFlip(bool paid); // 0x000000018068B110-0x000000018068B5E0
	private void DoCraft(); // 0x000000018068B5E0-0x000000018068B980
	private static string NewNonce(); // 0x000000018068B980-0x000000018068BA20
	private MidAutumnMilestone FindMilestone(long id); // 0x000000018068BA20-0x000000018068BB50
	[IteratorStateMachine(typeof(_PlayFlip_d__64))]
	private IEnumerator PlayFlip(MidAutumnFlipResult res); // 0x000000018068BB50-0x000000018068BC60
	[IteratorStateMachine(typeof(_FlipCard_d__65))]
	private IEnumerator FlipCard(Transform card); // 0x000000018068BC60-0x000000018068BD00
	[IteratorStateMachine(typeof(_Flash_d__66))]
	private IEnumerator Flash(float peak, float dur); // 0x000000018068BD00-0x000000018068BDC0
	private void ShowReward(string title, List<MidAutumnRewardIcon> icons, bool big); // 0x000000018068BDC0-0x000000018068C590
	[IteratorStateMachine(typeof(_PopIn_d__68))]
	private IEnumerator PopIn(Transform t, bool big); // 0x000000018068C590-0x000000018068C640
	public void ShowInfo(); // 0x000000018068C640-0x000000018068C910
	public void CloseInfo(); // 0x000000018068C910-0x000000018068CA60
	private string BuildDescription(); // 0x000000018068CA60-0x000000018068CFC0
	public void CloseRewardPopup(); // 0x000000018068CFC0-0x000000018068D120
	private void StartTimer(); // 0x000000018068D120-0x000000018068D240
	private void StopTimer(); // 0x000000018068D240-0x000000018068D2C0
	[IteratorStateMachine(typeof(_TickTimer_d__75))]
	private IEnumerator TickTimer(); // 0x000000018068D2C0-0x000000018068D360
	private static string FormatDuration(long sec); // 0x000000018068D360-0x000000018068D5E0
	private static List<MidAutumnRewardIcon> HeadlineFirst(List<MidAutumnRewardIcon> icons); // 0x000000018068D5E0-0x000000018068DA20
	private static void FillRewardGrid(Transform grid, List<MidAutumnRewardIcon> icons); // 0x000000018068DA20-0x000000018068E0A0
	private static string CompactAmount(int n); // 0x000000018068E0A0-0x000000018068E1B0
	private static string TrimZero(float v); // 0x000000018068E1B0-0x000000018068E2A0
	private static void AttachMilestoneTooltip(GameObject host, MidAutumnMilestone m, List<MidAutumnRewardIcon> icons); // 0x000000018068E2A0-0x000000018068E7A0
	private static Sprite SpriteFor(MidAutumnRewardIcon ic); // 0x000000018068E7A0-0x000000018068E820
	private void EnsurePool(List<GameObject> pool, GameObject tpl, Transform parent, int need); // 0x000000018068E820-0x000000018068EB20
	private static bool ApplyRewardIcon(Image img, MidAutumnRewardIcon ic); // 0x000000018068EB20-0x000000018068EE60
	private static string OtaPathOf(MidAutumnRewardIcon ic); // 0x000000018068EE60-0x000000018068F1B0
	private static Sprite RewardSprite(MidAutumnRewardIcon ic); // 0x000000018068F1B0-0x000000018068F520
	private static string ServerTypeToClient(string t); // 0x000000018068F520-0x000000018068FA50
	private void SetInteractable(bool on); // 0x000000018068FA50-0x000000018068FF90
	private static string FriendlyError(string raw, string fallback); // 0x000000018068FF90-0x00000001806902B0
	private void ShowMessage(string msg); // 0x00000001806902B0-0x00000001806903D0
	private void Toast(string msg); // 0x00000001806903D0-0x00000001806904A0
	private static void SetText(Transform parent, string node, string value); // 0x00000001806904A0-0x00000001806905F0
	private static void SetActiveNode(Transform parent, string node, bool on); // 0x00000001806905F0-0x0000000180690760
	private static void SetAlpha(Graphic g, float a); // 0x0000000180690760-0x00000001806908B0
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001806908B0-0x0000000180690B10
	[CompilerGenerated]
	private void _Wire_b__44_0(); // 0x0000000180690D80-0x0000000180690D90
	[CompilerGenerated]
	private void _DoFlip_b__60_0(MidAutumnFlipResult res); // 0x0000000180690D90-0x0000000180690ED0
	[CompilerGenerated]
	private void _DoFlip_b__60_1(string err); // 0x0000000180690ED0-0x0000000180690F50
	[CompilerGenerated]
	private void _DoCraft_b__61_0(MidAutumnCraftResult res); // 0x0000000180690F50-0x0000000180691020
	[CompilerGenerated]
	private void _DoCraft_b__61_1(string err); // 0x0000000180691020-0x00000001806910A0
}

