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
public class GuildPetPickerView : MonoBehaviour // TypeDefIndex: 882
{
	// Fields
	public const int COLS = 4; // Metadata: 0x005EFF6B
	public const int ROWS = 2; // Metadata: 0x005EFF6C
	public const int PER_PAGE = 8; // Metadata: 0x005EFF6D
	private const float BOX_W = 560f; // Metadata: 0x005EFF6E
	private const float BOX_H = 430f; // Metadata: 0x005EFF72
	private const float CELL = 110f; // Metadata: 0x005EFF76
	private const float CELL_GAP_X = 20f; // Metadata: 0x005EFF7A
	private const float CELL_GAP_Y = 16f; // Metadata: 0x005EFF7E
	private const float RING = 3f; // Metadata: 0x005EFF82
	private const float ICON_PAD = 12f; // Metadata: 0x005EFF86
	private const float CLOSE_SIZE = 48f; // Metadata: 0x005EFF8A
	private const float ARROW_SIZE = 52f; // Metadata: 0x005EFF8E
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
	public static bool IsOpen { get; } // 0x000000018055DAA0-0x000000018055DC30 
	private int PageCount { get; } // 0x000000018055E5F0-0x000000018055E620 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass41_0 // TypeDefIndex: 883
	{
		// Fields
		public int captured; // 0x10
		public GuildPetPickerView __4__this; // 0x18

		// Constructors
		public __c__DisplayClass41_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Refresh_b__0(); // 0x0000000180563640-0x00000001805636A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 884
	{
		// Fields
		public GuildPetPickerView __4__this; // 0x10
		public int dir; // 0x18

		// Constructors
		public __c__DisplayClass47_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildNav_b__0(); // 0x00000001805636A0-0x0000000180563710
	}

	// Constructors
	public GuildPetPickerView(); // 0x00000001805633A0-0x0000000180563570
	static GuildPetPickerView(); // 0x0000000180563570-0x0000000180563640

	// Methods
	public static void Open(Component context, List<int> pets, int selectedPetId, Action<int> onPick); // 0x000000018055DC30-0x000000018055DFA0
	public void Close(); // 0x000000018055DFA0-0x000000018055E0F0
	public static void CloseIfOpen(); // 0x000000018055E0F0-0x000000018055E230
	private void PlayOpenFx(); // 0x000000018055E230-0x000000018055E5F0
	private void Step(int d); // 0x000000018055E620-0x000000018055E670
	private void Refresh(); // 0x000000018055E670-0x000000018055EEE0
	private void Pick(int petId); // 0x000000018055EEE0-0x000000018055EF20
	private static GuildPetPickerView Ensure(Component context); // 0x000000018055EF20-0x000000018055F510
	private static Transform RootCanvas(Component c); // 0x000000018055F510-0x000000018055F790
	private void Build(Component context); // 0x000000018055F790-0x0000000180561000
	private void BuildCell(int i, RectTransform grid); // 0x0000000180561000-0x0000000180561440
	private Button BuildNav(RectTransform nav, Sprite arrowSprite, Font font, string arrow, int dir, Vector2 anchor, Vector2 offset); // 0x0000000180561440-0x00000001805616C0
	private static RectTransform NewNode(string name, Transform parent); // 0x00000001805616C0-0x0000000180561930
	private static void Stretch(RectTransform rt, float pad = 0f /* Metadata: 0x005EFF66 */); // 0x0000000180561930-0x0000000180561AD0
	private static Button PaintButton(RectTransform rt, Sprite sprite, float size, bool flipX, string glyph, Font font, int glyphSize); // 0x0000000180561AD0-0x0000000180561F60
	private static Vector2 FitIn(Sprite s, float size); // 0x0000000180561F60-0x0000000180562090
	private static UnityEngine.UI.Text NewText(string name, Transform parent, Font font, int size, TextAnchor align); // 0x0000000180562090-0x0000000180562320
	private static Transform PanelRootOf(Component context); // 0x0000000180562320-0x00000001805624E0
	private static Sprite BorrowFrameSprite(Transform panel); // 0x00000001805624E0-0x0000000180562700
	private static Sprite BorrowCloseSprite(Transform panel); // 0x0000000180562700-0x0000000180562860
	private static Sprite BorrowArrowSprite(Transform panel); // 0x0000000180562860-0x00000001805629F0
	private static Sprite FirstSprite(Transform panel, string[] names, bool preferSliced = true /* Metadata: 0x005EFF6A */); // 0x00000001805629F0-0x0000000180562ED0
	private static Font BorrowFont(Transform panel); // 0x0000000180562ED0-0x00000001805633A0
}

