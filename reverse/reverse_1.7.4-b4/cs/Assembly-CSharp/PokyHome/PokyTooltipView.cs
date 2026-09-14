/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyTooltipView : MonoBehaviour // TypeDefIndex: 2724
	{
		// Fields
		public const string PREFAB_PATH = "Prefabs/UI/PokyTooltip"; // Metadata: 0x005F29B6
		public const float PANEL_WIDTH = 288f; // Metadata: 0x005F29CD
		public const float REWARD_CELL = 44f; // Metadata: 0x005F29D1
		public const int REWARD_COLS = 5; // Metadata: 0x005F29D5
		public const int PAD_X = 16; // Metadata: 0x005F29D6
		public const int PAD_Y = 14; // Metadata: 0x005F29D7
		public const int SPACING = 7; // Metadata: 0x005F29D8
		public const int ICON_SIZE = 60; // Metadata: 0x005F29D9
		public const int FONT_TITLE = 19; // Metadata: 0x005F29DA
		public const int FONT_BODY = 15; // Metadata: 0x005F29DB
		public const int LINE_H = 2; // Metadata: 0x005F29DC
		public const int GRID_SPACING = 6; // Metadata: 0x005F29DD
		public const int REWARD_MAX = 20; // Metadata: 0x005F29DE
		public const int NAME_LINE_MAX = 8; // Metadata: 0x005F29DF
		private const float GAP = 14f; // Metadata: 0x005F29E0
		private const float MARGIN = 10f; // Metadata: 0x005F29E4
		private const float MIN_VIEW_H = 60f; // Metadata: 0x005F29E8
		public RectTransform panel; // 0x20
		public Button btnBlocker; // 0x28
		public Image imgIcon; // 0x30
		public UnityEngine.UI.Text txtTitle; // 0x38
		public UnityEngine.UI.Text txtBody; // 0x40
		public GameObject header; // 0x48
		public RectTransform rewardGrid; // 0x50
		public ScrollRect scroll; // 0x58
		private static PokyTooltipView _instance; // 0x00
		private static readonly List<RewardDisplayHelper.Entry> _empty; // 0x08
		private static readonly List<RewardDisplayHelper.Entry> _trim; // 0x10
		private static readonly StringBuilder _sb; // 0x18
		private CanvasGroup _group; // 0x60
		private bool _wired; // 0x68
		private Ctx _current; // 0x70
		private Ctx _back; // 0x78
		private Action<int> _rewardClick; // 0x80
	
		// Properties
		public static bool IsShowing { get; } // 0x0000000180C6B870-0x0000000180C6BA00 
	
		// Nested types
		private sealed class Ctx // TypeDefIndex: 2725
		{
			// Fields
			public RectTransform anchor; // 0x10
			public string title; // 0x18
			public string body; // 0x20
			public Sprite icon; // 0x28
			public List<RewardDisplayHelper.Entry> rewards; // 0x30
	
			// Constructors
			public Ctx(); // 0x000000018028A320-0x000000018028A330
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass53_0 // TypeDefIndex: 2726
		{
			// Fields
			public Action<int> handler; // 0x10
			public int index; // 0x18
	
			// Constructors
			public __c__DisplayClass53_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _WireRewardCellClicks_b__0(); // 0x0000000180C70DE0-0x0000000180C70E00
		}
	
		[CompilerGenerated]
		private sealed class _ReclampNextFrame_d__49 : IEnumerator<object> // TypeDefIndex: 2727
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyTooltipView __4__this; // 0x20
			public RectTransform anchor; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _ReclampNextFrame_d__49(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
			private bool MoveNext(); // 0x0000000180C70E00-0x0000000180C71190
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C71190-0x0000000180C711D0
		}
	
		// Constructors
		public PokyTooltipView(); // 0x000000018028A560-0x000000018028A5B0
		static PokyTooltipView(); // 0x0000000180C70A30-0x0000000180C70C90
	
		// Methods
		public static void Show(RectTransform anchor, string title, string body, Sprite icon); // 0x0000000180C6B200-0x0000000180C6B290
		public static void Show(RectTransform anchor, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards); // 0x0000000180C6B290-0x0000000180C6B330
		public static void Show(RectTransform anchor, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards, Action<int> onRewardClick); // 0x0000000180C6B330-0x0000000180C6B500
		public static void PushShow(RectTransform anchor, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards = null); // 0x0000000180C6B500-0x0000000180C6B6D0
		public static void Hide(); // 0x0000000180C6B6D0-0x0000000180C6B870
		private static PokyTooltipView Resolve(); // 0x0000000180C6BA00-0x0000000180C6BE30
		private void Awake(); // 0x0000000180C6BE30-0x0000000180C6BFC0
		private void OnDestroy(); // 0x0000000180C6BFC0-0x0000000180C6C190
		private void OnDisable(); // 0x0000000180C6C190-0x0000000180C6C310
		private void EnsureWired(); // 0x0000000180C6C310-0x0000000180C6CF20
		private void EnsureScrollRig(); // 0x0000000180C6CF20-0x0000000180C6D6C0
		private void Present(RectTransform anchor, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards); // 0x0000000180C6D6C0-0x0000000180C6DCD0
		[IteratorStateMachine(typeof(_ReclampNextFrame_d__49))]
		private IEnumerator ReclampNextFrame(RectTransform anchor); // 0x0000000180C6DCD0-0x0000000180C6DDE0
		private void EnsureFits(); // 0x0000000180C6DDE0-0x0000000180C6EB10
		private static string BuildBody(string title, string body, List<RewardDisplayHelper.Entry> rewards); // 0x0000000180C6EB10-0x0000000180C6EE00
		private void FillRewardGrid(List<RewardDisplayHelper.Entry> rewards); // 0x0000000180C6EE00-0x0000000180C6F4C0
		private void WireRewardCellClicks(); // 0x0000000180C6F4C0-0x0000000180C6FA10
		private static int CountActiveChildren(Transform t); // 0x0000000180C6FA10-0x0000000180C6FC60
		private void BackOrClose(); // 0x0000000180C6FC60-0x0000000180C6FD10
		private void ClosePanel(); // 0x0000000180C6FD10-0x0000000180C6FEB0
		private void PositionNear(RectTransform anchor); // 0x0000000180C6FEB0-0x0000000180C707D0
		private static Transform FindDeep(Transform root, string nodeName); // 0x0000000180C707D0-0x0000000180C70A30
		private static T FindDeep<T>(Transform root, string nodeName)
			where T : Component;
		[CompilerGenerated]
		private void _ClosePanel_b__56_0(); // 0x0000000180C70C90-0x0000000180C70DE0
	}
}
