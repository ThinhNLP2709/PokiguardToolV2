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

public static class GuildSkin // TypeDefIndex: 791
{
	// Fields
	private const string DIR = "GuildUI2/"; // Metadata: 0x0068BB3C
	public const string POPUP_BG = "popup_bg"; // Metadata: 0x0068BB46
	public const string BTN_CTA = "btn_cta"; // Metadata: 0x0068BB4F
	public const string BTN_CHIP = "btn_chip"; // Metadata: 0x0068BB57
	public const string CHIP_PANEL = "chip_panel"; // Metadata: 0x0068BB60
	public const string BTN_PLUS = "btn_plus"; // Metadata: 0x0068BB6B
	public const string BAR_BG = "bar_bg"; // Metadata: 0x0068BB74
	public const string BAR_FILL = "bar_fill"; // Metadata: 0x0068BB7B
	public const string ICON_GOLD = "icon_gold"; // Metadata: 0x0068BB84
	public static readonly Color TITLE; // 0x00
	public static readonly Color GOLD_NUM; // 0x10
	public static readonly Color EXP_CYAN; // 0x20
	public static readonly Color LABEL; // 0x30
	public static readonly Color WARN; // 0x40
	public static readonly Color OUTLINE; // 0x50
	public static readonly Color POOL_FILL; // 0x60
	public static readonly Color EXP_FILL; // 0x70
	public static readonly Color POPUP_TINT; // 0x80
	public const int FS_TITLE = 56; // Metadata: 0x0068BB8E
	public const int FS_MAIN = 42; // Metadata: 0x0068BB8F
	public const int FS_BTN = 40; // Metadata: 0x0068BB90
	public const int FS_SUB = 34; // Metadata: 0x0068BB91
	private static readonly Dictionary<string, Sprite> _cache; // 0x90
	private static bool _warned; // 0x98
	private const string FFRAME_ATLAS = "Image/petK/fframe"; // Metadata: 0x0068BB92
	private const string FFRAME_TRACK = "fframe_4"; // Metadata: 0x0068BBA4
	private const string POKY_FRAME = "Image/Common/endless_img_1"; // Metadata: 0x0068BBAD
	private static Sprite[] _fframe; // 0xA0
	private static bool _fframeTried; // 0xA8
	private static Sprite _pokyBtn; // 0xB0
	private static bool _pokyBtnTried; // 0xB8

	// Properties
	public static bool Ready { get; } // 0x00000001804888C0-0x0000000180488950 

	// Constructors
	static GuildSkin(); // 0x0000000180488740-0x00000001804888C0

	// Methods
	public static Sprite Get(string name); // 0x0000000180487AF0-0x0000000180487CE0
	public static Sprite PokyBarTrack(); // 0x0000000180488140-0x0000000180488340
	public static Sprite PokyFrame(); // 0x0000000180488680-0x00000001804886E0
	public static Sprite PokyGold(); // 0x00000001804886E0-0x0000000180488740
	public static Sprite PokyButton(Transform anyNodeInPanel); // 0x0000000180488340-0x0000000180488680
	public static bool ApplyButton(Image img, Transform anyNodeInPanel, Color tint); // 0x0000000180487570-0x00000001804876D0
	public static bool ApplyBarTrack(Image img); // 0x0000000180487430-0x0000000180487570
	public static bool ApplyFrame(Image img, Color tint); // 0x00000001804876D0-0x0000000180487890
	public static bool Apply(Image img, string name, Color tint, Image.Type type = Image.Type.Sliced /* Metadata: 0x0068BB33 */); // 0x0000000180487890-0x00000001804879A0
	public static void AddOutline(UnityEngine.UI.Text t, float dist = 2f /* Metadata: 0x0068BB34 */); // 0x00000001804872D0-0x0000000180487430
	public static Image MakeGoldIcon(Transform parent, Vector2 pos, float side = 36f /* Metadata: 0x0068BB38 */); // 0x0000000180487CE0-0x0000000180488140
	public static void EnsureRaycaster(Transform node); // 0x00000001804879A0-0x0000000180487AF0
}

