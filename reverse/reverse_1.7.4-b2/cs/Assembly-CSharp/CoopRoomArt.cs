/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class CoopRoomArt // TypeDefIndex: 11
{
	// Fields
	public static readonly Color Dim; // 0x00
	public static readonly Color StripCyan; // 0x10
	public static readonly Color OutlineBlue; // 0x20
	public static readonly Color OutlineGold; // 0x30
	public static readonly Color OutlineBoss; // 0x40
	public static readonly Color BossYellow; // 0x50
	public static readonly Color OwnerGray; // 0x60
	public static readonly Color TextDark; // 0x70
	public static readonly Color SeatFree; // 0x80
	public static readonly Color SeatFull; // 0x90
	public static readonly Color StateJoin; // 0xA0
	public static readonly Color StateFull; // 0xB0
	public static readonly Color StateInMatch; // 0xC0
	public static readonly Color StateHere; // 0xD0
	public static readonly Color CardMuted; // 0xE0
	private const string PATH_POPUP_BG = "Image/petK/bgPopupAlert"; // Metadata: 0x0068A772
	private const string PATH_CARD_BG = "Image/petK/userBG"; // Metadata: 0x0068A78A
	private const string PATH_STRIP = "Image/petK/ww@3x"; // Metadata: 0x0068A79C
	private const string PATH_CLOSE = "Image/petK/btnClose"; // Metadata: 0x0068A7AD
	private const string PATH_JOIN = "Image/petK/btnFight"; // Metadata: 0x0068A7C1
	private const string PATH_CHIP = "GuildUI2/btn_chip"; // Metadata: 0x0068A7D5
	private const string PATH_ARROW = "Image/Common/btnNextPet0001"; // Metadata: 0x0068A7E7
	private static readonly Dictionary<string, Sprite> _subCache; // 0xF0
	private static readonly Dictionary<string, Sprite> _slicedCache; // 0xF8

	// Properties
	public static Font Font { get; } // 0x00000001802EEED0-0x00000001802EEEE0 

	// Constructors
	static CoopRoomArt(); // 0x00000001802EEC50-0x00000001802EEED0

	// Methods
	public static Sprite PopupBg(); // 0x00000001802EE4D0-0x00000001802EE540
	public static Sprite CardBg(); // 0x00000001802EDAF0-0x00000001802EDB60
	public static Sprite StateBar(); // 0x00000001802EEAA0-0x00000001802EEB10
	public static Sprite Chip(); // 0x00000001802EDB60-0x00000001802EDBD0
	public static Sprite Strip(); // 0x00000001802EEBF0-0x00000001802EEC50
	public static Sprite Close(); // 0x00000001802EDBD0-0x00000001802EDC30
	public static Sprite Arrow(); // 0x00000001802EDA90-0x00000001802EDAF0
	public static Sprite First(string resourcePath); // 0x00000001802EDC30-0x00000001802EDF90
	public static Sprite Sliced(string resourcePath, Vector4 border); // 0x00000001802EE6F0-0x00000001802EEAA0
	public static void Apply(Image img, Sprite sprite, Color tint, Color flatFallback); // 0x00000001802ED950-0x00000001802EDA90
	public static RectTransform Rect(string name, Transform parent); // 0x00000001802EE540-0x00000001802EE6F0
	public static void Stretch(RectTransform rt, float left = 0f /* Metadata: 0x0068A760 */, float bottom = 0f /* Metadata: 0x0068A764 */, float right = 0f /* Metadata: 0x0068A768 */, float top = 0f /* Metadata: 0x0068A76C */); // 0x00000001802EEB10-0x00000001802EEBF0
	public static void Place(RectTransform rt, Vector2 anchor, Vector2 pos, Vector2 size); // 0x00000001802EE430-0x00000001802EE4D0
	public static Image Img(string name, Transform parent, Sprite sprite, Color tint, Color flatFallback, bool raycast = false /* Metadata: 0x0068A770 */); // 0x00000001802EDF90-0x00000001802EE0B0
	public static UnityEngine.UI.Text Label(string name, Transform parent, string content, int size, TextAnchor anchor, Color color, Color? outline, bool bold = false /* Metadata: 0x0068A771 */); // 0x00000001802EE0B0-0x00000001802EE2D0
	public static Button MakeButton(Image graphic, UnityAction onClick); // 0x00000001802EE2D0-0x00000001802EE430
}

