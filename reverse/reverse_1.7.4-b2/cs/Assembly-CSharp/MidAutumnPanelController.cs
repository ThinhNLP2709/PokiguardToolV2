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

public class MidAutumnPanelController : MonoBehaviour, IPokyEventPanel // TypeDefIndex: 861
{
	// Fields
	public const string PANEL_KEY = "PanelMidAutumn"; // Metadata: 0x0068BDA7
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
	private const int MILESTONE_GRID_MAX = 6; // Metadata: 0x0068BDB6

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 862
	{
		// Fields
		public int idx; // 0x10
		public MidAutumnPanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass47_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _WireFlipCards_b__0(); // 0x00000001804C7B90-0x00000001804C7BD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass49_0 // TypeDefIndex: 863
	{
		// Fields
		public MidAutumnPanelController __4__this; // 0x10
		public bool showLoginToast; // 0x18

		// Constructors
		public __c__DisplayClass49_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadStateCo_b__0(MidAutumnState data); // 0x00000001804C7BD0-0x00000001804C7D10
		internal void _LoadStateCo_b__1(string err); // 0x00000001804C7D10-0x00000001804C7DC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass55_0 // TypeDefIndex: 864
	{
		// Fields
		public long msId; // 0x10
		public MidAutumnPanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass55_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RenderMilestones_b__0(); // 0x00000001804C7DC0-0x00000001804C7DF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass59_0 // TypeDefIndex: 865
	{
		// Fields
		public MidAutumnPanelController __4__this; // 0x10
		public long milestoneId; // 0x18

		// Constructors
		public __c__DisplayClass59_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _DoClaim_b__0(MidAutumnState data); // 0x00000001804C7DF0-0x00000001804C7EC0
		internal void _DoClaim_b__1(string err); // 0x00000001804C7EC0-0x00000001804C7F60
	}

	[CompilerGenerated]
	private sealed class _CountUp_d__53 : IEnumerator<object> // TypeDefIndex: 866
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int from; // 0x20
		public int to; // 0x24
		public MidAutumnPanelController __4__this; // 0x28
		private float _t_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CountUp_d__53(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804C6680-0x00000001804C6940
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C6940-0x00000001804C6980
	}

	[CompilerGenerated]
	private sealed class _Flash_d__66 : IEnumerator<object> // TypeDefIndex: 867
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Flash_d__66(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804C6980-0x00000001804C6B90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C6B90-0x00000001804C6BD0
	}

	[CompilerGenerated]
	private sealed class _FlipCard_d__65 : IEnumerator<object> // TypeDefIndex: 868
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Transform card; // 0x20
		private Vector3 _s0_5__2; // 0x28
		private float _t_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FlipCard_d__65(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804C6BD0-0x00000001804C6E00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C6E00-0x00000001804C6E40
	}

	[CompilerGenerated]
	private sealed class _LoadStateCo_d__49 : IEnumerator<object> // TypeDefIndex: 869
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MidAutumnPanelController __4__this; // 0x20
		public bool showLoginToast; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadStateCo_d__49(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804C70C0-0x00000001804C7290
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C7290-0x00000001804C72D0
	}

	[CompilerGenerated]
	private sealed class _PlayFlip_d__64 : IEnumerator<object> // TypeDefIndex: 870
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MidAutumnPanelController __4__this; // 0x20
		public MidAutumnFlipResult res; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayFlip_d__64(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804C72D0-0x00000001804C7600
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C7600-0x00000001804C7640
	}

	[CompilerGenerated]
	private sealed class _PopIn_d__68 : IEnumerator<object> // TypeDefIndex: 871
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PopIn_d__68(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804C7640-0x00000001804C7820
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C7820-0x00000001804C7860
	}

	[CompilerGenerated]
	private sealed class _TickTimer_d__75 : IEnumerator<object> // TypeDefIndex: 872
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MidAutumnPanelController __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _TickTimer_d__75(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001804C7860-0x00000001804C7A30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C7A30-0x00000001804C7A70
	}

	// Constructors
	public MidAutumnPanelController(); // 0x00000001804A8F90-0x00000001804A90C0

	// Methods
	private void Awake(); // 0x00000001804A25B0-0x00000001804A25C0
	public void OpenPanel(); // 0x00000001804A4C60-0x00000001804A4DB0
	public void ClosePanel(); // 0x00000001804A2CD0-0x00000001804A2E70
	private void OnDisable(); // 0x00000001804A4C10-0x00000001804A4C60
	private void Wire(); // 0x00000001804A81A0-0x00000001804A8F90
	private void CaptureTemplates(); // 0x00000001804A2BB0-0x00000001804A2C50
	private GameObject FirstChildTemplate(Transform parent, List<GameObject> pool); // 0x00000001804A3F10-0x00000001804A40C0
	private void WireFlipCards(); // 0x00000001804A7F20-0x00000001804A81A0
	private void LoadState(bool showLoginToast); // 0x00000001804A49C0-0x00000001804A4A60
	[IteratorStateMachine(typeof(_LoadStateCo_d__49))]
	private IEnumerator LoadStateCo(bool showLoginToast); // 0x00000001804A4940-0x00000001804A49C0
	private void Render(); // 0x00000001804A6430-0x00000001804A65B0
	private void RenderPoints(); // 0x00000001804A61F0-0x00000001804A6430
	private int NextMilestonePoints(); // 0x00000001804A4AC0-0x00000001804A4C10
	[IteratorStateMachine(typeof(_CountUp_d__53))]
	private IEnumerator CountUp(int from, int to); // 0x00000001804A3000-0x00000001804A3090
	private void RenderMissions(); // 0x00000001804A5B50-0x00000001804A5E70
	private void RenderMilestones(); // 0x00000001804A5100-0x00000001804A57B0
	private void RenderMinigame(); // 0x00000001804A57B0-0x00000001804A5B50
	private void ResetFlipCards(); // 0x00000001804A65B0-0x00000001804A6820
	private void RenderPieces(); // 0x00000001804A5E70-0x00000001804A61F0
	private void DoClaim(long milestoneId); // 0x00000001804A3090-0x00000001804A3330
	private void DoFlip(bool paid); // 0x00000001804A3590-0x00000001804A3890
	private void DoCraft(); // 0x00000001804A3330-0x00000001804A3590
	private static string NewNonce(); // 0x00000001804A4A60-0x00000001804A4AC0
	private MidAutumnMilestone FindMilestone(long id); // 0x00000001804A3E00-0x00000001804A3F10
	[IteratorStateMachine(typeof(_PlayFlip_d__64))]
	private IEnumerator PlayFlip(MidAutumnFlipResult res); // 0x00000001804A4FF0-0x00000001804A5080
	[IteratorStateMachine(typeof(_FlipCard_d__65))]
	private IEnumerator FlipCard(Transform card); // 0x00000001804A4160-0x00000001804A41D0
	[IteratorStateMachine(typeof(_Flash_d__66))]
	private IEnumerator Flash(float peak, float dur); // 0x00000001804A40C0-0x00000001804A4160
	private void ShowReward(string title, List<MidAutumnRewardIcon> icons, bool big); // 0x00000001804A74D0-0x00000001804A7860
	[IteratorStateMachine(typeof(_PopIn_d__68))]
	private IEnumerator PopIn(Transform t, bool big); // 0x00000001804A5080-0x00000001804A5100
	public void ShowInfo(); // 0x00000001804A7310-0x00000001804A7430
	public void CloseInfo(); // 0x00000001804A2C50-0x00000001804A2CD0
	private string BuildDescription(); // 0x00000001804A25C0-0x00000001804A2BB0
	public void CloseRewardPopup(); // 0x00000001804A2E70-0x00000001804A2F00
	private void StartTimer(); // 0x00000001804A78E0-0x00000001804A79A0
	private void StopTimer(); // 0x00000001804A79A0-0x00000001804A79F0
	[IteratorStateMachine(typeof(_TickTimer_d__75))]
	private IEnumerator TickTimer(); // 0x00000001804A79F0-0x00000001804A7A60
	private static string FormatDuration(long sec); // 0x00000001804A41D0-0x00000001804A43C0
	private static List<MidAutumnRewardIcon> HeadlineFirst(List<MidAutumnRewardIcon> icons); // 0x00000001804A4670-0x00000001804A4940
	private static void FillRewardGrid(Transform grid, List<MidAutumnRewardIcon> icons); // 0x00000001804A3A40-0x00000001804A3CF0
	private static string CompactAmount(int n); // 0x00000001804A2F00-0x00000001804A3000
	private static string TrimZero(float v); // 0x00000001804A7B20-0x00000001804A7B80
	private static void AttachMilestoneTooltip(GameObject host, MidAutumnMilestone m, List<MidAutumnRewardIcon> icons); // 0x00000001804A2210-0x00000001804A25B0
	private static Sprite SpriteFor(MidAutumnRewardIcon ic); // 0x00000001804A7860-0x00000001804A78E0
	private void EnsurePool(List<GameObject> pool, GameObject tpl, Transform parent, int need); // 0x00000001804A3890-0x00000001804A3A40
	private static bool ApplyRewardIcon(Image img, MidAutumnRewardIcon ic); // 0x00000001804A20D0-0x00000001804A2210
	private static string OtaPathOf(MidAutumnRewardIcon ic); // 0x00000001804A4DB0-0x00000001804A4FF0
	private static Sprite RewardSprite(MidAutumnRewardIcon ic); // 0x00000001804A6820-0x00000001804A6A40
	private static string ServerTypeToClient(string t); // 0x00000001804A6A40-0x00000001804A6D70
	private void SetInteractable(bool on); // 0x00000001804A6F00-0x00000001804A7240
	private static string FriendlyError(string raw, string fallback); // 0x00000001804A43C0-0x00000001804A4670
	private void ShowMessage(string msg); // 0x00000001804A7430-0x00000001804A74D0
	private void Toast(string msg); // 0x00000001804A7A60-0x00000001804A7B20
	private static void SetText(Transform parent, string node, string value); // 0x00000001804A7240-0x00000001804A7310
	private static void SetActiveNode(Transform parent, string node, bool on); // 0x00000001804A6D70-0x00000001804A6E20
	private static void SetAlpha(Graphic g, float a); // 0x00000001804A6E20-0x00000001804A6F00
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001804A3CF0-0x00000001804A3E00
	[CompilerGenerated]
	private void _Wire_b__44_0(); // 0x00000001804A7F10-0x00000001804A7F20
	[CompilerGenerated]
	private void _DoFlip_b__60_0(MidAutumnFlipResult res); // 0x00000001804A7DE0-0x00000001804A7EA0
	[CompilerGenerated]
	private void _DoFlip_b__60_1(string err); // 0x00000001804A7EA0-0x00000001804A7F10
	[CompilerGenerated]
	private void _DoCraft_b__61_0(MidAutumnCraftResult res); // 0x00000001804A7B80-0x00000001804A7D70
	[CompilerGenerated]
	private void _DoCraft_b__61_1(string err); // 0x00000001804A7D70-0x00000001804A7DE0
}

