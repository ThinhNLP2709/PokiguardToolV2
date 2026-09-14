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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyTooltipView : MonoBehaviour // TypeDefIndex: 2717
	{
		// Fields
		public const string PREFAB_PATH = "Prefabs/UI/PokyTooltip"; // Metadata: 0x005F159F
		public const float PANEL_WIDTH = 288f; // Metadata: 0x005F15B6
		public const float REWARD_CELL = 44f; // Metadata: 0x005F15BA
		public const int REWARD_COLS = 5; // Metadata: 0x005F15BE
		public const int PAD_X = 16; // Metadata: 0x005F15BF
		public const int PAD_Y = 14; // Metadata: 0x005F15C0
		public const int SPACING = 7; // Metadata: 0x005F15C1
		public const int ICON_SIZE = 60; // Metadata: 0x005F15C2
		public const int FONT_TITLE = 19; // Metadata: 0x005F15C3
		public const int FONT_BODY = 15; // Metadata: 0x005F15C4
		public const int LINE_H = 2; // Metadata: 0x005F15C5
		public const int GRID_SPACING = 6; // Metadata: 0x005F15C6
		public const int REWARD_MAX = 20; // Metadata: 0x005F15C7
		public const int NAME_LINE_MAX = 8; // Metadata: 0x005F15C8
		private const float GAP = 14f; // Metadata: 0x005F15C9
		private const float MARGIN = 10f; // Metadata: 0x005F15CD
		private const float MIN_VIEW_H = 60f; // Metadata: 0x005F15D1
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
		public static bool IsShowing { get; } // 0x0000000180C5E2B0-0x0000000180C5E440 
	
		// Nested types
		private sealed class Ctx // TypeDefIndex: 2718
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
		private sealed class __c__DisplayClass53_0 // TypeDefIndex: 2719
		{
			// Fields
			public Action<int> handler; // 0x10
			public int index; // 0x18
	
			// Constructors
			public __c__DisplayClass53_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _WireRewardCellClicks_b__0(); // 0x0000000180C63820-0x0000000180C63840
		}
	
		[CompilerGenerated]
		private sealed class _ReclampNextFrame_d__49 : IEnumerator<object> // TypeDefIndex: 2720
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
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180C63840-0x0000000180C63BD0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C63BD0-0x0000000180C63C10
		}
	
		// Constructors
		public PokyTooltipView(); // 0x000000018028A560-0x000000018028A5B0
		static PokyTooltipView(); // 0x0000000180C63470-0x0000000180C636D0
	
		// Methods
		public static void Show(RectTransform anchor, string title, string body, Sprite icon); // 0x0000000180C5DC40-0x0000000180C5DCD0
		public static void Show(RectTransform anchor, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards); // 0x0000000180C5DCD0-0x0000000180C5DD70
		public static void Show(RectTransform anchor, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards, Action<int> onRewardClick); // 0x0000000180C5DD70-0x0000000180C5DF40
		public static void PushShow(RectTransform anchor, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards = null); // 0x0000000180C5DF40-0x0000000180C5E110
		public static void Hide(); // 0x0000000180C5E110-0x0000000180C5E2B0
		private static PokyTooltipView Resolve(); // 0x0000000180C5E440-0x0000000180C5E870
		private void Awake(); // 0x0000000180C5E870-0x0000000180C5EA00
		private void OnDestroy(); // 0x0000000180C5EA00-0x0000000180C5EBD0
		private void OnDisable(); // 0x0000000180C5EBD0-0x0000000180C5ED50
		private void EnsureWired(); // 0x0000000180C5ED50-0x0000000180C5F960
		private void EnsureScrollRig(); // 0x0000000180C5F960-0x0000000180C60100
		private void Present(RectTransform anchor, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards); // 0x0000000180C60100-0x0000000180C60710
		[IteratorStateMachine(typeof(_ReclampNextFrame_d__49))]
		private IEnumerator ReclampNextFrame(RectTransform anchor); // 0x0000000180C60710-0x0000000180C60820
		private void EnsureFits(); // 0x0000000180C60820-0x0000000180C61550
		private static string BuildBody(string title, string body, List<RewardDisplayHelper.Entry> rewards); // 0x0000000180C61550-0x0000000180C61840
		private void FillRewardGrid(List<RewardDisplayHelper.Entry> rewards); // 0x0000000180C61840-0x0000000180C61F00
		private void WireRewardCellClicks(); // 0x0000000180C61F00-0x0000000180C62450
		private static int CountActiveChildren(Transform t); // 0x0000000180C62450-0x0000000180C626A0
		private void BackOrClose(); // 0x0000000180C626A0-0x0000000180C62750
		private void ClosePanel(); // 0x0000000180C62750-0x0000000180C628F0
		private void PositionNear(RectTransform anchor); // 0x0000000180C628F0-0x0000000180C63210
		private static Transform FindDeep(Transform root, string nodeName); // 0x0000000180C63210-0x0000000180C63470
		private static T FindDeep<T>(Transform root, string nodeName)
			where T : Component;
		[CompilerGenerated]
		private void _ClosePanel_b__56_0(); // 0x0000000180C636D0-0x0000000180C63820
	}
}
