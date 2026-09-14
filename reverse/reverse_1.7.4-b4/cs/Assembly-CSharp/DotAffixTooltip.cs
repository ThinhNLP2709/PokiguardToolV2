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

public class DotAffixTooltip : MonoBehaviour // TypeDefIndex: 2194
{
	// Fields
	public const string NODE_NAME = "DotAffixTooltip"; // Metadata: 0x005F1B95
	public const int SORTING_ORDER = 895; // Metadata: 0x005F1BA5
	public const float WIDTH = 196f; // Metadata: 0x005F1BA7
	public const float WIDTH_MAX = 270f; // Metadata: 0x005F1BAB
	public const float PAD = 7f; // Metadata: 0x005F1BAF
	public const float ICON = 20f; // Metadata: 0x005F1BB3
	public const float ICON_GAP = 6f; // Metadata: 0x005F1BB7
	public const float VALUE_W = 34f; // Metadata: 0x005F1BBB
	public const float LABEL_H = 13f; // Metadata: 0x005F1BBF
	public const float ROW_GAP = 6f; // Metadata: 0x005F1BC3
	public const int FONT_TITLE = 11; // Metadata: 0x005F1BC7
	public const int FONT_LABEL = 10; // Metadata: 0x005F1BC8
	public const int FONT_DESC = 9; // Metadata: 0x005F1BC9
	public const int FONT_NOTE = 8; // Metadata: 0x005F1BCA
	public const float GAP = 4f; // Metadata: 0x005F1BCB
	public const float MIN_SCALE = 0.55f; // Metadata: 0x005F1BCF
	private const float FADE_SEC = 0.12f; // Metadata: 0x005F1BD3
	private static readonly Color PLATE; // 0x00
	private static readonly Color FRAME; // 0x10
	private static readonly Color LINE; // 0x20
	private static readonly Color DESC; // 0x30
	private static readonly Color NOTE; // 0x40
	private static readonly Vector2[] _cand; // 0x50
	private static DotAffixTooltip _instance; // 0x58
	private Canvas _canvas; // 0x20
	private CanvasGroup _cg; // 0x28
	private RectTransform _panel; // 0x30
	private UnityEngine.UI.Text _title; // 0x38
	private Image _line; // 0x40
	private UnityEngine.UI.Text _note; // 0x48
	private readonly List<RowView> _rows; // 0x50
	private readonly List<RowSpec> _specs; // 0x58
	private readonly int[] _pct; // 0x60
	private DotAffixHudView _owner; // 0x68
	private int _builtVersion; // 0x70
	private float _width; // 0x74
	private Vector2 _size; // 0x78
	private Placement _placement; // 0x80
	private int _placeHash; // 0x98
	private float _alpha; // 0x9C

	// Properties
	public static bool IsOpen { get; } // 0x0000000180A54BB0-0x0000000180A54E00 
	public static DotAffixHudView Owner { get; } // 0x0000000180A54E00-0x0000000180A54E80 
	public static RectTransform PanelRect { get; } // 0x0000000180A54E80-0x0000000180A54FC0 
	public static int RowCount { get; } // 0x0000000180A54FC0-0x0000000180A55040 
	public static float Alpha { get; } // 0x0000000180A55040-0x0000000180A551F0 
	public static Placement LastPlacement { get; } // 0x0000000180A551F0-0x0000000180A55370 

	// Nested types
	public struct RowSpec // TypeDefIndex: 2195
	{
		// Fields
		public int tagIndex; // 0x00
		public bool luck; // 0x04
		public string label; // 0x08
		public string value; // 0x10
		public string desc; // 0x18
	}

	public struct Placement // TypeDefIndex: 2196
	{
		// Fields
		public Rect rect; // 0x00
		public float scale; // 0x10
		public bool overBoard; // 0x14
		public bool overBadge; // 0x15
	}

	private sealed class RowView // TypeDefIndex: 2197
	{
		// Fields
		public RectTransform root; // 0x10
		public Image icon; // 0x18
		public Image star; // 0x20
		public UnityEngine.UI.Text label; // 0x28
		public UnityEngine.UI.Text value; // 0x30
		public UnityEngine.UI.Text desc; // 0x38

		// Constructors
		public RowView(); // 0x000000018028A320-0x000000018028A330
	}

	// Constructors
	public DotAffixTooltip(); // 0x0000000180A5A500-0x0000000180A5A7E0
	static DotAffixTooltip(); // 0x0000000180A5A7E0-0x0000000180A5AA00

	// Methods
	public static void BuildRows(int[] pct, int luckIndex, int luck, List<RowSpec> into); // 0x0000000180A534F0-0x0000000180A53E10
	public static string TitleFor(string ownerName); // 0x0000000180A53E10-0x0000000180A53F60
	public static Rect LaneFor(Rect badge, Rect screen, Rect board, bool hasBoard); // 0x0000000180A53F60-0x0000000180A540C0
	public static Placement Place(Rect badge, Vector2 size, Rect screen, Rect board, bool hasBoard, float gap); // 0x0000000180A540C0-0x0000000180A54960
	private static Rect ClampInto(Rect r, Rect region); // 0x0000000180A54960-0x0000000180A54A40
	private static float Overlap(Rect a, Rect b); // 0x0000000180A54A40-0x0000000180A54AF0
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStatics(); // 0x0000000180A54AF0-0x0000000180A54BB0
	internal static void Toggle(DotAffixHudView view); // 0x0000000180A55370-0x0000000180A55560
	public static void Open(DotAffixHudView view); // 0x0000000180A55560-0x0000000180A55820
	public static void Close(); // 0x0000000180A55820-0x0000000180A55AB0
	internal static void CloseFor(DotAffixHudView view); // 0x0000000180A55AB0-0x0000000180A55BF0
	public static void NotifyPress(Vector2 screenPos); // 0x0000000180A55BF0-0x0000000180A55F10
	private static DotAffixTooltip Create(DotAffixHudView view); // 0x0000000180A55F10-0x0000000180A56380
	private void BuildShell(); // 0x0000000180A56380-0x0000000180A56AC0
	private void Bind(DotAffixHudView view); // 0x0000000180A56AC0-0x0000000180A56D30
	private void Update(); // 0x0000000180A56D30-0x0000000180A57320
	private void Rebuild(); // 0x0000000180A57320-0x0000000180A57BD0
	private RowView BuildRow(int index); // 0x0000000180A57BD0-0x0000000180A58260
	private float FillRow(RowView row, RowSpec spec, float y, float inner); // 0x0000000180A58260-0x0000000180A58AF0
	private static float PlaceText(UnityEngine.UI.Text t, float x, float y, float width); // 0x0000000180A58AF0-0x0000000180A58CC0
	private float DesiredWidth(); // 0x0000000180A58CC0-0x0000000180A58FF0
	private void Reposition(bool force); // 0x0000000180A58FF0-0x0000000180A596E0
	private static int Q(float v); // 0x0000000180A4E620-0x0000000180A4E630
	private void OnDestroy(); // 0x0000000180A596E0-0x0000000180A598C0
	private static RectTransform NewRect(Transform parent, string name); // 0x0000000180A598C0-0x0000000180A59B30
	private static Image NewImage(Transform parent, string name); // 0x0000000180A59B30-0x0000000180A59ED0
	private static UnityEngine.UI.Text NewText(Transform parent, string name, int fontSize, Color color, TextAnchor anchor, bool bold); // 0x0000000180A59ED0-0x0000000180A5A480
	private static void TopLeft(RectTransform rt); // 0x0000000180A5A480-0x0000000180A5A500
	private static void Stretch(RectTransform rt); // 0x000000018079BBB0-0x000000018079BCA0
}

