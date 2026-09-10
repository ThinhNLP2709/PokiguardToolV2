/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class GuildPetPickerView : MonoBehaviour // TypeDefIndex: 770
{
	// Fields
	public const int COLS = 4; // Metadata: 0x0068BAF8
	public const int ROWS = 2; // Metadata: 0x0068BAF9
	public const int PER_PAGE = 8; // Metadata: 0x0068BAFA
	private const float BOX_W = 560f; // Metadata: 0x0068BAFB
	private const float BOX_H = 430f; // Metadata: 0x0068BAFF
	private const float CELL = 110f; // Metadata: 0x0068BB03
	private const float CELL_GAP_X = 20f; // Metadata: 0x0068BB07
	private const float CELL_GAP_Y = 16f; // Metadata: 0x0068BB0B
	private const float RING = 3f; // Metadata: 0x0068BB0F
	private const float ICON_PAD = 12f; // Metadata: 0x0068BB13
	private const float CLOSE_SIZE = 48f; // Metadata: 0x0068BB17
	private const float ARROW_SIZE = 52f; // Metadata: 0x0068BB1B
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
	public static bool IsOpen { get; } // 0x000000018047CE70-0x000000018047CF30 
	private int PageCount { get; } // 0x000000018047CF30-0x000000018047CF60 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass41_0 // TypeDefIndex: 771
	{
		// Fields
		public int captured; // 0x10
		public GuildPetPickerView __4__this; // 0x18

		// Constructors
		public __c__DisplayClass41_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Refresh_b__0(); // 0x000000018047EDD0-0x000000018047EE70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 772
	{
		// Fields
		public GuildPetPickerView __4__this; // 0x10
		public int dir; // 0x18

		// Constructors
		public __c__DisplayClass47_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BuildNav_b__0(); // 0x000000018047EF50-0x000000018047EFC0
	}

	// Constructors
	public GuildPetPickerView(); // 0x000000018047CDB0-0x000000018047CE70
	static GuildPetPickerView(); // 0x000000018047CCF0-0x000000018047CDB0

	// Methods
	public static void Open(Component context, List<int> pets, int selectedPetId, Action<int> onPick); // 0x000000018047BBF0-0x000000018047BE00
	public void Close(); // 0x000000018047B190-0x000000018047B200
	public static void CloseIfOpen(); // 0x000000018047B090-0x000000018047B190
	private void PlayOpenFx(); // 0x000000018047C2C0-0x000000018047C510
	private void Step(int d); // 0x000000018047CB80-0x000000018047CBD0
	private void Refresh(); // 0x000000018047C510-0x000000018047CA80
	private void Pick(int petId); // 0x000000018047C220-0x000000018047C2C0
	private static GuildPetPickerView Ensure(Component context); // 0x000000018047B200-0x000000018047B5F0
	private static Transform RootCanvas(Component c); // 0x000000018047CA80-0x000000018047CB80
	private void Build(Component context); // 0x000000018047A1E0-0x000000018047B090
	private void BuildCell(int i, RectTransform grid); // 0x0000000180479C10-0x0000000180479FC0
	private Button BuildNav(RectTransform nav, Sprite arrowSprite, Font font, string arrow, int dir, Vector2 anchor, Vector2 offset); // 0x0000000180479FC0-0x000000018047A1E0
	private static RectTransform NewNode(string name, Transform parent); // 0x000000018047B8E0-0x000000018047BA80
	private static void Stretch(RectTransform rt, float pad = 0f /* Metadata: 0x0068BAF3 */); // 0x000000018047CBD0-0x000000018047CCF0
	private static Button PaintButton(RectTransform rt, Sprite sprite, float size, bool flipX, string glyph, Font font, int glyphSize); // 0x000000018047BE00-0x000000018047C150
	private static Vector2 FitIn(Sprite s, float size); // 0x000000018047B810-0x000000018047B8E0
	private static UnityEngine.UI.Text NewText(string name, Transform parent, Font font, int size, TextAnchor align); // 0x000000018047BA80-0x000000018047BBF0
	private static Transform PanelRootOf(Component context); // 0x000000018047C150-0x000000018047C220
	private static Sprite BorrowFrameSprite(Transform panel); // 0x00000001804799E0-0x0000000180479C10
	private static Sprite BorrowCloseSprite(Transform panel); // 0x0000000180479670-0x00000001804797D0
	private static Sprite BorrowArrowSprite(Transform panel); // 0x00000001804794F0-0x0000000180479670
	private static Sprite FirstSprite(Transform panel, string[] names, bool preferSliced = true /* Metadata: 0x0068BAF7 */); // 0x000000018047B5F0-0x000000018047B810
	private static Font BorrowFont(Transform panel); // 0x00000001804797D0-0x00000001804799E0
}

