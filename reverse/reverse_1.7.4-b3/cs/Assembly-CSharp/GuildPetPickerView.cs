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
public class GuildPetPickerView : MonoBehaviour // TypeDefIndex: 880
{
	// Fields
	public const int COLS = 4; // Metadata: 0x005EEB9D
	public const int ROWS = 2; // Metadata: 0x005EEB9E
	public const int PER_PAGE = 8; // Metadata: 0x005EEB9F
	private const float BOX_W = 560f; // Metadata: 0x005EEBA0
	private const float BOX_H = 430f; // Metadata: 0x005EEBA4
	private const float CELL = 110f; // Metadata: 0x005EEBA8
	private const float CELL_GAP_X = 20f; // Metadata: 0x005EEBAC
	private const float CELL_GAP_Y = 16f; // Metadata: 0x005EEBB0
	private const float RING = 3f; // Metadata: 0x005EEBB4
	private const float ICON_PAD = 12f; // Metadata: 0x005EEBB8
	private const float CLOSE_SIZE = 48f; // Metadata: 0x005EEBBC
	private const float ARROW_SIZE = 52f; // Metadata: 0x005EEBC0
	private static readonly Color DIM; // 0x00
	private static readonly Color BOX_FALLBACK; // 0x10
	private static readonly Color CELL_BG; // 0x20
	private static readonly Color RING_OFF; // 0x30
	private static readonly Color RING_ON; // 0x40
	private static readonly Color TEXT; // 0x50
	private static GuildPetPickerView _instance; // 0x60
	private RectTransform _box; // 0x20
	private UnityEngine.UI.Text _title; // 0x28
	private UnityEngine.UI.Text _pageLabel; // 0x30
	private Button _btnPrev; // 0x38
	private Button _btnNext; // 0x40
	private readonly Image[] _rings; // 0x48
	private readonly Transform[] _icons; // 0x50
	private readonly Button[] _cells; // 0x58
	private List<int> _pets; // 0x60
	private int _page; // 0x68
	private int _selected; // 0x6C
	private Action<int> _onPick; // 0x70
	private int _tweenId; // 0x78

	// Properties
	public static bool IsOpen { get; } // 0x000000018055C170-0x000000018055C300 
	private int PageCount { get; } // 0x000000018055CCC0-0x000000018055CCF0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass41_0 // TypeDefIndex: 881
	{
		// Fields
		public int captured; // 0x10
		public GuildPetPickerView __4__this; // 0x18

		// Constructors
		public __c__DisplayClass41_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Refresh_b__0(); // 0x0000000180561D10-0x0000000180561D70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 882
	{
		// Fields
		public GuildPetPickerView __4__this; // 0x10
		public int dir; // 0x18

		// Constructors
		public __c__DisplayClass47_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildNav_b__0(); // 0x0000000180561D70-0x0000000180561DE0
	}

	// Constructors
	public GuildPetPickerView(); // 0x0000000180561A70-0x0000000180561C40
	static GuildPetPickerView(); // 0x0000000180561C40-0x0000000180561D10

	// Methods
	public static void Open(Component context, List<int> pets, int selectedPetId, Action<int> onPick); // 0x000000018055C300-0x000000018055C670
	public void Close(); // 0x000000018055C670-0x000000018055C7C0
	public static void CloseIfOpen(); // 0x000000018055C7C0-0x000000018055C900
	private void PlayOpenFx(); // 0x000000018055C900-0x000000018055CCC0
	private void Step(int d); // 0x000000018055CCF0-0x000000018055CD40
	private void Refresh(); // 0x000000018055CD40-0x000000018055D5B0
	private void Pick(int petId); // 0x000000018055D5B0-0x000000018055D5F0
	private static GuildPetPickerView Ensure(Component context); // 0x000000018055D5F0-0x000000018055DBE0
	private static Transform RootCanvas(Component c); // 0x000000018055DBE0-0x000000018055DE60
	private void Build(Component context); // 0x000000018055DE60-0x000000018055F6D0
	private void BuildCell(int i, RectTransform grid); // 0x000000018055F6D0-0x000000018055FB10
	private Button BuildNav(RectTransform nav, Sprite arrowSprite, Font font, string arrow, int dir, Vector2 anchor, Vector2 offset); // 0x000000018055FB10-0x000000018055FD90
	private static RectTransform NewNode(string name, Transform parent); // 0x000000018055FD90-0x0000000180560000
	private static void Stretch(RectTransform rt, float pad = 0f /* Metadata: 0x005EEB98 */); // 0x0000000180560000-0x00000001805601A0
	private static Button PaintButton(RectTransform rt, Sprite sprite, float size, bool flipX, string glyph, Font font, int glyphSize); // 0x00000001805601A0-0x0000000180560630
	private static Vector2 FitIn(Sprite s, float size); // 0x0000000180560630-0x0000000180560760
	private static UnityEngine.UI.Text NewText(string name, Transform parent, Font font, int size, TextAnchor align); // 0x0000000180560760-0x00000001805609F0
	private static Transform PanelRootOf(Component context); // 0x00000001805609F0-0x0000000180560BB0
	private static Sprite BorrowFrameSprite(Transform panel); // 0x0000000180560BB0-0x0000000180560DD0
	private static Sprite BorrowCloseSprite(Transform panel); // 0x0000000180560DD0-0x0000000180560F30
	private static Sprite BorrowArrowSprite(Transform panel); // 0x0000000180560F30-0x00000001805610C0
	private static Sprite FirstSprite(Transform panel, string[] names, bool preferSliced = true /* Metadata: 0x005EEB9C */); // 0x00000001805610C0-0x00000001805615A0
	private static Font BorrowFont(Transform panel); // 0x00000001805615A0-0x0000000180561A70
}

