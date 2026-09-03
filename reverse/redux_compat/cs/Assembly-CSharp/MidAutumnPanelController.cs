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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class MidAutumnPanelController : MonoBehaviour, IPokyEventPanel // TypeDefIndex: 665
{
	// Fields
	public const string PANEL_KEY = "PanelMidAutumn"; // Metadata: 0x0064C743
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
	private const int MILESTONE_GRID_MAX = 6; // Metadata: 0x0064C752

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 666
	{
		// Fields
		public int idx; // 0x10
		public MidAutumnPanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass47_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _WireFlipCards_b__0(); // 0x00000001803D4A70-0x00000001803D4AB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass49_0 // TypeDefIndex: 667
	{
		// Fields
		public MidAutumnPanelController __4__this; // 0x10
		public bool showLoginToast; // 0x18

		// Constructors
		public __c__DisplayClass49_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadStateCo_b__0(MidAutumnState data); // 0x00000001803D4AB0-0x00000001803D4BF0
		internal void _LoadStateCo_b__1(string err); // 0x00000001803D4BF0-0x00000001803D4CA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass55_0 // TypeDefIndex: 668
	{
		// Fields
		public long msId; // 0x10
		public MidAutumnPanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass55_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RenderMilestones_b__0(); // 0x00000001803D4CA0-0x00000001803D4CD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass59_0 // TypeDefIndex: 669
	{
		// Fields
		public MidAutumnPanelController __4__this; // 0x10
		public long milestoneId; // 0x18

		// Constructors
		public __c__DisplayClass59_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _DoClaim_b__0(MidAutumnState data); // 0x00000001803D4CD0-0x00000001803D4DA0
		internal void _DoClaim_b__1(string err); // 0x00000001803D4DA0-0x00000001803D4E40
	}

	[CompilerGenerated]
	private sealed class _CountUp_d__53 : IEnumerator<object> // TypeDefIndex: 670
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int from; // 0x20
		public int to; // 0x24
		public MidAutumnPanelController __4__this; // 0x28
		private float _t_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CountUp_d__53(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803CFB90-0x00000001803CFE50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803CFE50-0x00000001803CFE90
	}

	[CompilerGenerated]
	private sealed class _Flash_d__66 : IEnumerator<object> // TypeDefIndex: 671
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Flash_d__66(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803D1940-0x00000001803D1B50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D1B50-0x00000001803D1B90
	}

	[CompilerGenerated]
	private sealed class _FlipCard_d__65 : IEnumerator<object> // TypeDefIndex: 672
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Transform card; // 0x20
		private Vector3 _s0_5__2; // 0x28
		private float _t_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FlipCard_d__65(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803D1B90-0x00000001803D1DC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D1DC0-0x00000001803D1E00
	}

	[CompilerGenerated]
	private sealed class _LoadStateCo_d__49 : IEnumerator<object> // TypeDefIndex: 673
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MidAutumnPanelController __4__this; // 0x20
		public bool showLoginToast; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadStateCo_d__49(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803D2D30-0x00000001803D2F00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D2F00-0x00000001803D2F40
	}

	[CompilerGenerated]
	private sealed class _PlayFlip_d__64 : IEnumerator<object> // TypeDefIndex: 674
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MidAutumnPanelController __4__this; // 0x20
		public MidAutumnFlipResult res; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlayFlip_d__64(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803D3450-0x00000001803D3800
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D3800-0x00000001803D3840
	}

	[CompilerGenerated]
	private sealed class _PopIn_d__68 : IEnumerator<object> // TypeDefIndex: 675
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PopIn_d__68(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803D3840-0x00000001803D3A20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D3A20-0x00000001803D3A60
	}

	[CompilerGenerated]
	private sealed class _TickTimer_d__75 : IEnumerator<object> // TypeDefIndex: 676
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MidAutumnPanelController __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _TickTimer_d__75(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001803D4860-0x00000001803D4A30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D4A30-0x00000001803D4A70
	}

	// Constructors
	public MidAutumnPanelController(); // 0x00000001803C9FA0-0x00000001803CA0D0

	// Methods
	private void Awake(); // 0x00000001803C3B40-0x00000001803C3B50
	public void OpenPanel(); // 0x00000001803C6040-0x00000001803C6100
	public void ClosePanel(); // 0x00000001803C40C0-0x00000001803C4260
	private void OnDisable(); // 0x00000001803C5FF0-0x00000001803C6040
	private void Wire(); // 0x00000001803C9270-0x00000001803C9FA0
	private void CaptureTemplates(); // 0x00000001803C3FA0-0x00000001803C4040
	private GameObject FirstChildTemplate(Transform parent, List<GameObject> pool); // 0x00000001803C5300-0x00000001803C54B0
	private void WireFlipCards(); // 0x00000001803C8FF0-0x00000001803C9270
	private void LoadState(bool showLoginToast); // 0x00000001803C5DA0-0x00000001803C5E40
	[IteratorStateMachine(typeof(_LoadStateCo_d__49))]
	private IEnumerator LoadStateCo(bool showLoginToast); // 0x00000001803C5D20-0x00000001803C5DA0
	private void Render(); // 0x00000001803C76A0-0x00000001803C7820
	private void RenderPoints(); // 0x00000001803C7460-0x00000001803C76A0
	private int NextMilestonePoints(); // 0x00000001803C5EA0-0x00000001803C5FF0
	[IteratorStateMachine(typeof(_CountUp_d__53))]
	private IEnumerator CountUp(int from, int to); // 0x00000001803C43F0-0x00000001803C4480
	private void RenderMissions(); // 0x00000001803C6DC0-0x00000001803C70E0
	private void RenderMilestones(); // 0x00000001803C6370-0x00000001803C6A20
	private void RenderMinigame(); // 0x00000001803C6A20-0x00000001803C6DC0
	private void ResetFlipCards(); // 0x00000001803C7820-0x00000001803C7A90
	private void RenderPieces(); // 0x00000001803C70E0-0x00000001803C7460
	private void DoClaim(long milestoneId); // 0x00000001803C4480-0x00000001803C4720
	private void DoFlip(bool paid); // 0x00000001803C4980-0x00000001803C4C80
	private void DoCraft(); // 0x00000001803C4720-0x00000001803C4980
	private static string NewNonce(); // 0x00000001803C5E40-0x00000001803C5EA0
	private MidAutumnMilestone FindMilestone(long id); // 0x00000001803C51F0-0x00000001803C5300
	[IteratorStateMachine(typeof(_PlayFlip_d__64))]
	private IEnumerator PlayFlip(MidAutumnFlipResult res); // 0x00000001803C6260-0x00000001803C62F0
	[IteratorStateMachine(typeof(_FlipCard_d__65))]
	private IEnumerator FlipCard(Transform card); // 0x00000001803C5540-0x00000001803C55B0
	[IteratorStateMachine(typeof(_Flash_d__66))]
	private IEnumerator Flash(float peak, float dur); // 0x00000001803C54B0-0x00000001803C5540
	private void ShowReward(string title, List<MidAutumnRewardIcon> icons, bool big); // 0x00000001803C8720-0x00000001803C8AB0
	[IteratorStateMachine(typeof(_PopIn_d__68))]
	private IEnumerator PopIn(Transform t, bool big); // 0x00000001803C62F0-0x00000001803C6370
	public void ShowInfo(); // 0x00000001803C8560-0x00000001803C8680
	public void CloseInfo(); // 0x00000001803C4040-0x00000001803C40C0
	private string BuildDescription(); // 0x00000001803C3B50-0x00000001803C3FA0
	public void CloseRewardPopup(); // 0x00000001803C4260-0x00000001803C42F0
	private void StartTimer(); // 0x00000001803C8B30-0x00000001803C8BF0
	private void StopTimer(); // 0x00000001803C8BF0-0x00000001803C8C40
	[IteratorStateMachine(typeof(_TickTimer_d__75))]
	private IEnumerator TickTimer(); // 0x00000001803C8C40-0x00000001803C8CB0
	private static string FormatDuration(long sec); // 0x00000001803C55B0-0x00000001803C57A0
	private static List<MidAutumnRewardIcon> HeadlineFirst(List<MidAutumnRewardIcon> icons); // 0x00000001803C5A50-0x00000001803C5D20
	private static void FillRewardGrid(Transform grid, List<MidAutumnRewardIcon> icons); // 0x00000001803C4E30-0x00000001803C50E0
	private static string CompactAmount(int n); // 0x00000001803C42F0-0x00000001803C43F0
	private static string TrimZero(float v); // 0x00000001803C8D70-0x00000001803C8DD0
	private static void AttachMilestoneTooltip(GameObject host, MidAutumnMilestone m, List<MidAutumnRewardIcon> icons); // 0x00000001803C37E0-0x00000001803C3B40
	private static Sprite SpriteFor(MidAutumnRewardIcon ic); // 0x00000001803C8AB0-0x00000001803C8B30
	private void EnsurePool(List<GameObject> pool, GameObject tpl, Transform parent, int need); // 0x00000001803C4C80-0x00000001803C4E30
	private static bool ApplyRewardIcon(Image img, MidAutumnRewardIcon ic); // 0x00000001803C36A0-0x00000001803C37E0
	private static string OtaPathOf(MidAutumnRewardIcon ic); // 0x00000001803C6100-0x00000001803C6260
	private static Sprite RewardSprite(MidAutumnRewardIcon ic); // 0x00000001803C7A90-0x00000001803C7C90
	private static string ServerTypeToClient(string t); // 0x00000001803C7C90-0x00000001803C7FC0
	private void SetInteractable(bool on); // 0x00000001803C8150-0x00000001803C8490
	private static string FriendlyError(string raw, string fallback); // 0x00000001803C57A0-0x00000001803C5A50
	private void ShowMessage(string msg); // 0x00000001803C8680-0x00000001803C8720
	private void Toast(string msg); // 0x00000001803C8CB0-0x00000001803C8D70
	private static void SetText(Transform parent, string node, string value); // 0x00000001803C8490-0x00000001803C8560
	private static void SetActiveNode(Transform parent, string node, bool on); // 0x00000001803C7FC0-0x00000001803C8070
	private static void SetAlpha(Graphic g, float a); // 0x00000001803C8070-0x00000001803C8150
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001803C50E0-0x00000001803C51F0
	[CompilerGenerated]
	private void _Wire_b__44_0(); // 0x00000001803C8FE0-0x00000001803C8FF0
	[CompilerGenerated]
	private void _DoFlip_b__60_0(MidAutumnFlipResult res); // 0x00000001803C8EC0-0x00000001803C8F70
	[CompilerGenerated]
	private void _DoFlip_b__60_1(string err); // 0x00000001803C8F70-0x00000001803C8FE0
	[CompilerGenerated]
	private void _DoCraft_b__61_0(MidAutumnCraftResult res); // 0x00000001803C8DD0-0x00000001803C8E50
	[CompilerGenerated]
	private void _DoCraft_b__61_1(string err); // 0x00000001803C8E50-0x00000001803C8EC0
}

