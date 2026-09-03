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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyTooltipView : MonoBehaviour // TypeDefIndex: 1955
	{
		// Fields
		public const string PREFAB_PATH = "Prefabs/UI/PokyTooltip"; // Metadata: 0x0064E0C9
		public const float PANEL_WIDTH = 288f; // Metadata: 0x0064E0E0
		public const float REWARD_CELL = 44f; // Metadata: 0x0064E0E4
		public const int REWARD_COLS = 5; // Metadata: 0x0064E0E8
		public const int PAD_X = 16; // Metadata: 0x0064E0E9
		public const int PAD_Y = 14; // Metadata: 0x0064E0EA
		public const int SPACING = 7; // Metadata: 0x0064E0EB
		public const int ICON_SIZE = 60; // Metadata: 0x0064E0EC
		public const int FONT_TITLE = 19; // Metadata: 0x0064E0ED
		public const int FONT_BODY = 15; // Metadata: 0x0064E0EE
		public const int LINE_H = 2; // Metadata: 0x0064E0EF
		public const int GRID_SPACING = 6; // Metadata: 0x0064E0F0
		public const int REWARD_MAX = 10; // Metadata: 0x0064E0F1
		public const int NAME_LINE_MAX = 4; // Metadata: 0x0064E0F2
		private const float GAP = 14f; // Metadata: 0x0064E0F3
		private const float MARGIN = 10f; // Metadata: 0x0064E0F7
		public RectTransform panel; // 0x20
		public Button btnBlocker; // 0x28
		public Image imgIcon; // 0x30
		public UnityEngine.UI.Text txtTitle; // 0x38
		public UnityEngine.UI.Text txtBody; // 0x40
		public GameObject header; // 0x48
		public RectTransform rewardGrid; // 0x50
		private static PokyTooltipView _instance; // 0x00
		private static readonly List<RewardDisplayHelper.Entry> _empty; // 0x08
		private static readonly List<RewardDisplayHelper.Entry> _trim; // 0x10
		private static readonly StringBuilder _sb; // 0x18
		private CanvasGroup _group; // 0x58
		private bool _wired; // 0x60
		private Ctx _current; // 0x68
		private Ctx _back; // 0x70
		private Action<int> _rewardClick; // 0x78
	
		// Properties
		public static bool IsShowing { get; } // 0x0000000180669F10-0x0000000180669FD0 
	
		// Nested types
		private sealed class Ctx // TypeDefIndex: 1956
		{
			// Fields
			public RectTransform anchor; // 0x10
			public string title; // 0x18
			public string body; // 0x20
			public Sprite icon; // 0x28
			public List<RewardDisplayHelper.Entry> rewards; // 0x30
	
			// Constructors
			public Ctx(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass50_0 // TypeDefIndex: 1957
		{
			// Fields
			public Action<int> handler; // 0x10
			public int index; // 0x18
	
			// Constructors
			public __c__DisplayClass50_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _WireRewardCellClicks_b__0(); // 0x00000001806702F0-0x0000000180670310
		}
	
		[CompilerGenerated]
		private sealed class _ReclampNextFrame_d__46 : IEnumerator<object> // TypeDefIndex: 1958
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyTooltipView __4__this; // 0x20
			public RectTransform anchor; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _ReclampNextFrame_d__46(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x000000018066F1F0-0x000000018066F330
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018066F330-0x000000018066F370
		}
	
		// Constructors
		public PokyTooltipView(); // 0x00000001802E7A70-0x00000001802E7BC0
		static PokyTooltipView(); // 0x0000000180669DF0-0x0000000180669F10
	
		// Methods
		public static void Show(RectTransform anchor, string title, string body, Sprite icon); // 0x00000001806698A0-0x0000000180669960
		public static void Show(RectTransform anchor, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards); // 0x0000000180669960-0x00000001806699F0
		public static void Show(RectTransform anchor, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards, Action<int> onRewardClick); // 0x00000001806699F0-0x0000000180669AF0
		public static void PushShow(RectTransform anchor, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards = null); // 0x0000000180669420-0x00000001806695D0
		public static void Hide(); // 0x0000000180668880-0x0000000180668960
		private static PokyTooltipView Resolve(); // 0x0000000180669660-0x00000001806698A0
		private void Awake(); // 0x00000001806674E0-0x00000001806675A0
		private void OnDestroy(); // 0x0000000180668960-0x0000000180668A20
		private void OnDisable(); // 0x0000000180668A20-0x0000000180668AD0
		private void EnsureWired(); // 0x0000000180667EF0-0x0000000180668430
		private void Present(RectTransform anchor, string title, string body, Sprite icon, List<RewardDisplayHelper.Entry> rewards); // 0x0000000180668FE0-0x0000000180669420
		[IteratorStateMachine(typeof(_ReclampNextFrame_d__46))]
		private IEnumerator ReclampNextFrame(RectTransform anchor); // 0x00000001806695D0-0x0000000180669660
		private void EnsureFits(); // 0x0000000180667A60-0x0000000180667EF0
		private static string BuildBody(string title, string body, List<RewardDisplayHelper.Entry> rewards); // 0x0000000180667620-0x00000001806678C0
		private void FillRewardGrid(List<RewardDisplayHelper.Entry> rewards); // 0x0000000180668430-0x0000000180668770
		private void WireRewardCellClicks(); // 0x0000000180669B70-0x0000000180669DF0
		private static int CountActiveChildren(Transform t); // 0x00000001806679D0-0x0000000180667A60
		private void BackOrClose(); // 0x00000001806675A0-0x0000000180667620
		private void ClosePanel(); // 0x00000001806678C0-0x00000001806679D0
		private void PositionNear(RectTransform anchor); // 0x0000000180668AD0-0x0000000180668FE0
		private static Transform FindDeep(Transform root, string nodeName); // 0x0000000180668770-0x0000000180668880
		private static T FindDeep<T>(Transform root, string nodeName)
			where T : Component;
		[CompilerGenerated]
		private void _ClosePanel_b__53_0(); // 0x0000000180669AF0-0x0000000180669B70
	}
}
