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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyTooltipView : MonoBehaviour // TypeDefIndex: 2281
	{
		// Fields
		public const string PREFAB_PATH = "Prefabs/UI/PokyTooltip"; // Metadata: 0x0068E549
		public const float PANEL_WIDTH = 288f; // Metadata: 0x0068E560
		public const float REWARD_CELL = 44f; // Metadata: 0x0068E564
		public const int REWARD_COLS = 5; // Metadata: 0x0068E568
		public const int PAD_X = 16; // Metadata: 0x0068E569
		public const int PAD_Y = 14; // Metadata: 0x0068E56A
		public const int SPACING = 7; // Metadata: 0x0068E56B
		public const int ICON_SIZE = 60; // Metadata: 0x0068E56C
		public const int FONT_TITLE = 19; // Metadata: 0x0068E56D
		public const int FONT_BODY = 15; // Metadata: 0x0068E56E
		public const int LINE_H = 2; // Metadata: 0x0068E56F
		public const int GRID_SPACING = 6; // Metadata: 0x0068E570
		public const int REWARD_MAX = 20; // Metadata: 0x0068E571
		public const int NAME_LINE_MAX = 8; // Metadata: 0x0068E572
		private const float GAP = 14f; // Metadata: 0x0068E573
		private const float MARGIN = 10f; // Metadata: 0x0068E577
		private const float MIN_VIEW_H = 60f; // Metadata: 0x0068E57B
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
		public static bool IsShowing { get; } // 0x00000001807A74B0-0x00000001807A7570 
	
		// Nested types
		private sealed class Ctx // TypeDefIndex: 2282
		{
			// Fields
			public RectTransform anchor; // 0x10
			public string title; // 0x18
			public string body; // 0x20
			public Sprite icon; // 0x28
			public List<RewardDisplayHelper.Entry> rewards; // 0x30
	
			// Constructors
			public Ctx(); // 0x00000001802E9CB0-0x00000001802E9CC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass53_0 // TypeDefIndex: 2283
		{
			// Fields
			public Action<int> handler; // 0x10
			public int index; // 0x18
	
			// Constructors
			public __c__DisplayClass53_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _WireRewardCellClicks_b__0(); // 0x00000001807AEB80-0x00000001807AEBA0
		}
	
		[CompilerGenerated]
		private sealed class _ReclampNextFrame_d__49 : IEnumerator<object> // TypeDefIndex: 2284
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyTooltipView __4__this; // 0x20
			public RectTransform anchor; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _ReclampNextFrame_d__49(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x00000001807AD1C0-0x00000001807AD390
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807AD390-0x00000001807AD3D0
		}
	
		// Constructors
		public PokyTooltipView(); // 0x00000001802EBA70-0x00000001802EBAF0
		static PokyTooltipView(); // 0x00000001807A7390-0x00000001807A74B0
	
		// Methods
		public static void Show(RectTransform anchor, string title, string body, Sprite icon); // 0x00000001807A6E40-0x00000001807A6F00
		public static void Show(RectTransform anchor, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards); // 0x00000001807A6F00-0x00000001807A6F90
		public static void Show(RectTransform anchor, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards, Action<int> onRewardClick); // 0x00000001807A6F90-0x00000001807A7090
		public static void PushShow(RectTransform anchor, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards = null); // 0x00000001807A69C0-0x00000001807A6B70
		public static void Hide(); // 0x00000001807A5D50-0x00000001807A5E30
		private static PokyTooltipView Resolve(); // 0x00000001807A6C00-0x00000001807A6E40
		private void Awake(); // 0x00000001807A45E0-0x00000001807A46A0
		private void OnDestroy(); // 0x00000001807A5E30-0x00000001807A5EF0
		private void OnDisable(); // 0x00000001807A5EF0-0x00000001807A5FA0
		private void EnsureWired(); // 0x00000001807A5390-0x00000001807A58E0
		private void EnsureScrollRig(); // 0x00000001807A5150-0x00000001807A5390
		private void Present(RectTransform anchor, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards); // 0x00000001807A64B0-0x00000001807A69C0
		[IteratorStateMachine(typeof(_ReclampNextFrame_d__49))]
		private IEnumerator ReclampNextFrame(RectTransform anchor); // 0x00000001807A6B70-0x00000001807A6C00
		private void EnsureFits(); // 0x00000001807A4B60-0x00000001807A5150
		private static string BuildBody(string title, string body, List<RewardDisplayHelper.Entry> rewards); // 0x00000001807A4720-0x00000001807A49C0
		private void FillRewardGrid(List<RewardDisplayHelper.Entry> rewards); // 0x00000001807A58E0-0x00000001807A5C40
		private void WireRewardCellClicks(); // 0x00000001807A7110-0x00000001807A7390
		private static int CountActiveChildren(Transform t); // 0x00000001807A4AD0-0x00000001807A4B60
		private void BackOrClose(); // 0x00000001807A46A0-0x00000001807A4720
		private void ClosePanel(); // 0x00000001807A49C0-0x00000001807A4AD0
		private void PositionNear(RectTransform anchor); // 0x00000001807A5FA0-0x00000001807A64B0
		private static Transform FindDeep(Transform root, string nodeName); // 0x00000001807A5C40-0x00000001807A5D50
		private static T FindDeep<T>(Transform root, string nodeName)
			where T : Component;
		[CompilerGenerated]
		private void _ClosePanel_b__56_0(); // 0x00000001807A7090-0x00000001807A7110
	}
}
