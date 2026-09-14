/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public sealed class ThanhTuuTabList : MonoBehaviour // TypeDefIndex: 1309
{
	// Fields
	public const float CAT_X = 4f; // Metadata: 0x005F0CA2
	public const float CAT_W = 224f; // Metadata: 0x005F0CA6
	public const float CAT_H = 62f; // Metadata: 0x005F0CAA
	public const float CAT_TEXT_X = 58f; // Metadata: 0x005F0CAE
	public const float CAT_FONT = 22f; // Metadata: 0x005F0CB2
	public const float CAT_MIN = 16f; // Metadata: 0x005F0CB6
	public const float TAB_X = 20f; // Metadata: 0x005F0CBA
	public const float TAB_W = 208f; // Metadata: 0x005F0CBE
	public const float TAB_H = 56f; // Metadata: 0x005F0CC2
	public const float TAB_STEP = 62f; // Metadata: 0x005F0CC6
	public const float TAB_FONT = 22f; // Metadata: 0x005F0CCA
	public const float TAB_MIN = 16f; // Metadata: 0x005F0CCE
	public const float BADGE = 28f; // Metadata: 0x005F0CD2
	public const float BADGE_X = 196f; // Metadata: 0x005F0CD6
	public const float BADGE_Y = -4f; // Metadata: 0x005F0CDA
	public const float CAT_BADGE_X = 200f; // Metadata: 0x005F0CDE
	public const float CAT_BADGE_Y = -2f; // Metadata: 0x005F0CE2
	public const float STAMP_X = 112f; // Metadata: 0x005F0CE6
	public const float STAMP_Y = -2f; // Metadata: 0x005F0CEA
	public const float STAMP_W = 96f; // Metadata: 0x005F0CEE
	public const float STAMP_H = 60f; // Metadata: 0x005F0CF2
	public const float STAMP_FONT = 18f; // Metadata: 0x005F0CF6
	public const float STAMP_ANGLE = 18f; // Metadata: 0x005F0CFA
	public const float SELECT_X = -8f; // Metadata: 0x005F0CFE
	public const float SELECT_Y = -6f; // Metadata: 0x005F0D02
	public const float SELECT_W = 224f; // Metadata: 0x005F0D06
	public const float SELECT_H = 68f; // Metadata: 0x005F0D0A
	public const float ARROW_X = -20f; // Metadata: 0x005F0D0E
	public const float ARROW_Y = 18f; // Metadata: 0x005F0D12
	public const float ARROW_W = 16f; // Metadata: 0x005F0D16
	public const float ARROW_H = 20f; // Metadata: 0x005F0D1A
	public const float TOP_PAD = 8f; // Metadata: 0x005F0D1E
	public const float HEADER_GAP = 0f; // Metadata: 0x005F0D22
	public const float CAT_GAP = 0f; // Metadata: 0x005F0D26
	public const float BOTTOM_PAD = 12f; // Metadata: 0x005F0D2A
	public const float KNOB = 18f; // Metadata: 0x005F0D2E
	public const float TRACK_W = 2f; // Metadata: 0x005F0D32
	public const float MASK_BLEED_RIGHT = 16f; // Metadata: 0x005F0D36
	public static readonly Color TEXT_OUTLINE; // 0x00
	public static readonly Color STAMP_COLOR; // 0x10
	public static readonly Color TRACK_COLOR; // 0x20
	private MonoBehaviour _host; // 0x20
	private RectTransform _view; // 0x28
	private RectTransform _content; // 0x30
	private RectTransform _select; // 0x38
	private RectTransform _track; // 0x40
	private RectTransform _knob; // 0x48
	private Image _selectImg; // 0x50
	private Image _arrowImg; // 0x58
	private Image _knobImg; // 0x60
	private Image _trackImg; // 0x68
	private Image _viewCatcher; // 0x70
	private ScrollRect _scroll; // 0x78
	private readonly List<CatItem> _cats; // 0x80
	private readonly List<TabItem> _tabs; // 0x88
	private ThanhTuuCategory[] _data; // 0x90
	private ThanhTuuStrings _str; // 0x98
	private Action<int> _onTap; // 0xA0
	private int _selected; // 0xA8
	private int _selectId; // 0xAC
	private int _scrollId; // 0xB0
	private int _stampId; // 0xB4
	private float _knobX; // 0xB8
	private float _trackTop; // 0xBC
	private float _trackH; // 0xC0

	// Properties
	public int Selected { get; } // 0x00000001803C7060-0x00000001803C7070 
	public RectTransform Content { get; } // 0x00000001802B4AE0-0x00000001802B4AF0 

	// Nested types
	private sealed class CatItem // TypeDefIndex: 1310
	{
		// Fields
		public RectTransform rt; // 0x10
		public Image bg; // 0x18
		public Image badge; // 0x20
		public UnityEngine.UI.Text txt; // 0x28
		public string art; // 0x30

		// Constructors
		public CatItem(); // 0x000000018028A320-0x000000018028A330
	}

	private sealed class TabItem // TypeDefIndex: 1311
	{
		// Fields
		public int groupId; // 0x10
		public RectTransform rt; // 0x18
		public RectTransform stamp; // 0x20
		public Image bg; // 0x28
		public Image badge; // 0x30
		public Image stampImg; // 0x38
		public UnityEngine.UI.Text txt; // 0x40
		public UnityEngine.UI.Text stampTxt; // 0x48
		public string art; // 0x50
		public float y; // 0x58

		// Constructors
		public TabItem(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass77_0 // TypeDefIndex: 1312
	{
		// Fields
		public TabItem captured; // 0x10
		public ThanhTuuTabList __4__this; // 0x18

		// Constructors
		public __c__DisplayClass77_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _EnsureTab_b__0(); // 0x0000000180748250-0x00000001807482B0
	}

	// Constructors
	public ThanhTuuTabList(); // 0x0000000180747DF0-0x0000000180748100
	static ThanhTuuTabList(); // 0x0000000180748100-0x0000000180748250

	// Methods
	public static ThanhTuuTabList Build(MonoBehaviour host, RectTransform panelLeft, Vector4 svLocal, float knobX, Action<int> onTap); // 0x0000000180743490-0x0000000180743730
	private void BuildBody(RectTransform panel, Vector4 sv); // 0x0000000180743730-0x00000001807442D0
	public void Rebind(); // 0x00000001807442D0-0x0000000180744710
	public void Render(ThanhTuuCategory[] cats, ThanhTuuStrings str); // 0x0000000180744710-0x0000000180745100
	private CatItem EnsureCat(int i); // 0x0000000180745100-0x00000001807457D0
	private void BindCat(CatItem c, ThanhTuuCategory cat); // 0x00000001807457D0-0x0000000180745AF0
	private TabItem EnsureTab(int i); // 0x0000000180745AF0-0x00000001807469D0
	private void BindTab(TabItem t, ThanhTuuGroup g); // 0x00000001807469D0-0x0000000180746E40
	public void SetSelected(int groupId, bool animate); // 0x0000000180746E40-0x0000000180747140
	public void EnsureVisible(int groupId, bool animate); // 0x0000000180747140-0x00000001807475B0
	public void Slam(int groupId); // 0x00000001807475B0-0x0000000180747690
	public RectTransform TabRect(int groupId); // 0x0000000180747690-0x00000001807476B0
	private TabItem Find(int groupId); // 0x00000001807476B0-0x00000001807477D0
	private void OnScroll(Vector2 _); // 0x00000001807477D0-0x00000001807477E0
	private void UpdateKnob(); // 0x00000001807477E0-0x0000000180747BB0
	private void OnDisable(); // 0x0000000180747BB0-0x0000000180747C20
	private static void SetOn(Component c, bool on); // 0x0000000180747C20-0x0000000180747DF0
}

