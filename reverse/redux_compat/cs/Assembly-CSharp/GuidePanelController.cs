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

public class GuidePanelController : MonoBehaviour // TypeDefIndex: 595
{
	// Fields
	public const string PANEL_KEY = "PanelHuongDan"; // Metadata: 0x0064C5A4
	[Header("Ti\u00EAu \u0111\u1EC1")]
	public UnityEngine.UI.Text titleText; // 0x20
	public UnityEngine.UI.Text headingText; // 0x28
	[Header("N\u1ED9i dung")]
	[Tooltip("C\u00E1c kh\u1ED1i Text trong Content c\u1EE7a ScrollRect. N\u1ED9i dung ch\u01B0\u01A1ng d\u00E0i \u0111\u01B0\u1EE3c chia \u0111\u1EC1u v\u00E0o \u0111\u00E2y v\u00EC m\u1ED9t Text legacy kh\u00F4ng hi\u1EC3n th\u1ECB n\u1ED5i qu\u00E1 ~16.000 k\u00FD t\u1EF1 (tr\u1EA7n vertex c\u1EE7a mesh).")]
	public UnityEngine.UI.Text[] bodyBlocks; // 0x30
	public ScrollRect scrollRect; // 0x38
	[Header("Danh m\u1EE5c (c\u1ED9t tr\u00E1i)")]
	[Tooltip("Node cha c\u1EE7a c\u00E1c n\u00FAt danh m\u1EE5c \u2014 c\u00F3 VerticalLayoutGroup + ContentSizeFitter.")]
	public RectTransform tabRoot; // 0x40
	[Tooltip("N\u00FAt danh m\u1EE5c M\u1EAAU, lu\u00F4n inactive trong prefab. M\u1ED7i ch\u01B0\u01A1ng nh\u00E2n b\u1EA3n m\u1ED9t c\u00E1i.")]
	public GameObject tabTemplate; // 0x48
	public ScrollRect tabScroll; // 0x50
	[Header("N\u00FAt")]
	public Button btnClose; // 0x58
	[Header("Hi\u1EC7u \u1EE9ng \u2014 T\u00D9Y CH\u1ECCN")]
	public CanvasGroup canvasGroup; // 0x60
	[Header("M\u00E0u n\u00FAt danh m\u1EE5c")]
	[Tooltip("\u1EA2nh n\u1EC1n n\u00FAt danh m\u1EE5c \u0110ANG CH\u1ECCN (tab_active).")]
	public Sprite tabActiveSprite; // 0x68
	[Tooltip("\u1EA2nh n\u1EC1n n\u00FAt danh m\u1EE5c KH\u00D4NG ch\u1ECDn (tab_inactive).")]
	public Sprite tabInactiveSprite; // 0x70
	public Color tabActiveTextColor; // 0x78
	public Color tabInactiveTextColor; // 0x88
	private const int VERTEX_CAP = 65000; // Metadata: 0x0064C5B2
	private const int VERTS_PER_CHAR = 4; // Metadata: 0x0064C5B6
	private const float SAFETY = 0.55f; // Metadata: 0x0064C5B7
	private const string HEADING_COLOR = "#FFDD84"; // Metadata: 0x0064C5BB
	private readonly List<Button> _tabButtons; // 0x98
	private int _maxCharsPerBlock; // 0xA0
	private int _current; // 0xA4
	private bool _built; // 0xA8

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 596
	{
		// Fields
		public int idx; // 0x10
		public GuidePanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass25_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _BuildTabsOnce_b__0(); // 0x00000001803BE910-0x00000001803BE940
	}

	[CompilerGenerated]
	private sealed class _ScrollToTop_d__28 : IEnumerator<object> // TypeDefIndex: 597
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuidePanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ScrollToTop_d__28(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803BE690-0x00000001803BE7A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803BE7A0-0x00000001803BE7E0
	}

	// Constructors
	public GuidePanelController(); // 0x00000001803ACDD0-0x00000001803ACE80

	// Methods
	private void Awake(); // 0x00000001803AB6E0-0x00000001803AB830
	public void Open(); // 0x00000001803AC3E0-0x00000001803AC500
	public void Close(); // 0x00000001803ABB70-0x00000001803ABCD0
	private void BuildTabsOnce(); // 0x00000001803AB830-0x00000001803ABB70
	private static UnityEngine.UI.Text FindLabel(GameObject tab); // 0x00000001803AC040-0x00000001803AC140
	public void SelectChapter(int index, bool force); // 0x00000001803AC970-0x00000001803ACB10
	[IteratorStateMachine(typeof(_ScrollToTop_d__28))]
	private IEnumerator ScrollToTop(); // 0x00000001803AC900-0x00000001803AC970
	private void RebuildContent(); // 0x00000001803AC720-0x00000001803AC900
	private void PaintTabs(int active); // 0x00000001803AC500-0x00000001803AC720
	private static string Format(string body); // 0x00000001803AC140-0x00000001803AC3E0
	private static bool EndsWithBlankLine(StringBuilder sb); // 0x00000001803ABD00-0x00000001803ABD90
	private void ComputeMaxCharsPerBlock(); // 0x00000001803ABCD0-0x00000001803ABD00
	private void FillBlocks(string text); // 0x00000001803ABD90-0x00000001803AC040
	private static List<string> SplitByLines(string text, int maxChars, int maxParts); // 0x00000001803ACB10-0x00000001803ACDD0
}

