/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public sealed class ThanhTuuTabList : MonoBehaviour // TypeDefIndex: 1307
{
	// Fields
	public const float CAT_X = 4f; // Metadata: 0x005EF8D5
	public const float CAT_W = 224f; // Metadata: 0x005EF8D9
	public const float CAT_H = 62f; // Metadata: 0x005EF8DD
	public const float CAT_TEXT_X = 58f; // Metadata: 0x005EF8E1
	public const float CAT_FONT = 22f; // Metadata: 0x005EF8E5
	public const float CAT_MIN = 16f; // Metadata: 0x005EF8E9
	public const float TAB_X = 20f; // Metadata: 0x005EF8ED
	public const float TAB_W = 208f; // Metadata: 0x005EF8F1
	public const float TAB_H = 56f; // Metadata: 0x005EF8F5
	public const float TAB_STEP = 62f; // Metadata: 0x005EF8F9
	public const float TAB_FONT = 22f; // Metadata: 0x005EF8FD
	public const float TAB_MIN = 16f; // Metadata: 0x005EF901
	public const float BADGE = 28f; // Metadata: 0x005EF905
	public const float BADGE_X = 196f; // Metadata: 0x005EF909
	public const float BADGE_Y = -4f; // Metadata: 0x005EF90D
	public const float CAT_BADGE_X = 200f; // Metadata: 0x005EF911
	public const float CAT_BADGE_Y = -2f; // Metadata: 0x005EF915
	public const float STAMP_X = 112f; // Metadata: 0x005EF919
	public const float STAMP_Y = -2f; // Metadata: 0x005EF91D
	public const float STAMP_W = 96f; // Metadata: 0x005EF921
	public const float STAMP_H = 60f; // Metadata: 0x005EF925
	public const float STAMP_FONT = 18f; // Metadata: 0x005EF929
	public const float STAMP_ANGLE = 18f; // Metadata: 0x005EF92D
	public const float SELECT_X = -8f; // Metadata: 0x005EF931
	public const float SELECT_Y = -6f; // Metadata: 0x005EF935
	public const float SELECT_W = 224f; // Metadata: 0x005EF939
	public const float SELECT_H = 68f; // Metadata: 0x005EF93D
	public const float ARROW_X = -20f; // Metadata: 0x005EF941
	public const float ARROW_Y = 18f; // Metadata: 0x005EF945
	public const float ARROW_W = 16f; // Metadata: 0x005EF949
	public const float ARROW_H = 20f; // Metadata: 0x005EF94D
	public const float TOP_PAD = 8f; // Metadata: 0x005EF951
	public const float HEADER_GAP = 0f; // Metadata: 0x005EF955
	public const float CAT_GAP = 0f; // Metadata: 0x005EF959
	public const float BOTTOM_PAD = 12f; // Metadata: 0x005EF95D
	public const float KNOB = 18f; // Metadata: 0x005EF961
	public const float TRACK_W = 2f; // Metadata: 0x005EF965
	public const float MASK_BLEED_RIGHT = 16f; // Metadata: 0x005EF969
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
	public int Selected { get; } // 0x00000001803C6390-0x00000001803C63A0 
	public RectTransform Content { get; } // 0x00000001802B4AE0-0x00000001802B4AF0 

	// Nested types
	private sealed class CatItem // TypeDefIndex: 1308
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

	private sealed class TabItem // TypeDefIndex: 1309
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
	private sealed class __c__DisplayClass77_0 // TypeDefIndex: 1310
	{
		// Fields
		public TabItem captured; // 0x10
		public ThanhTuuTabList __4__this; // 0x18

		// Constructors
		public __c__DisplayClass77_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _EnsureTab_b__0(); // 0x00000001807464A0-0x0000000180746500
	}

	// Constructors
	public ThanhTuuTabList(); // 0x0000000180746040-0x0000000180746350
	static ThanhTuuTabList(); // 0x0000000180746350-0x00000001807464A0

	// Methods
	public static ThanhTuuTabList Build(MonoBehaviour host, RectTransform panelLeft, Vector4 svLocal, float knobX, Action<int> onTap); // 0x00000001807416E0-0x0000000180741980
	private void BuildBody(RectTransform panel, Vector4 sv); // 0x0000000180741980-0x0000000180742520
	public void Rebind(); // 0x0000000180742520-0x0000000180742960
	public void Render(ThanhTuuCategory[] cats, ThanhTuuStrings str); // 0x0000000180742960-0x0000000180743350
	private CatItem EnsureCat(int i); // 0x0000000180743350-0x0000000180743A20
	private void BindCat(CatItem c, ThanhTuuCategory cat); // 0x0000000180743A20-0x0000000180743D40
	private TabItem EnsureTab(int i); // 0x0000000180743D40-0x0000000180744C20
	private void BindTab(TabItem t, ThanhTuuGroup g); // 0x0000000180744C20-0x0000000180745090
	public void SetSelected(int groupId, bool animate); // 0x0000000180745090-0x0000000180745390
	public void EnsureVisible(int groupId, bool animate); // 0x0000000180745390-0x0000000180745800
	public void Slam(int groupId); // 0x0000000180745800-0x00000001807458E0
	public RectTransform TabRect(int groupId); // 0x00000001807458E0-0x0000000180745900
	private TabItem Find(int groupId); // 0x0000000180745900-0x0000000180745A20
	private void OnScroll(Vector2 _); // 0x0000000180745A20-0x0000000180745A30
	private void UpdateKnob(); // 0x0000000180745A30-0x0000000180745E00
	private void OnDisable(); // 0x0000000180745E00-0x0000000180745E70
	private static void SetOn(Component c, bool on); // 0x0000000180745E70-0x0000000180746040
}

