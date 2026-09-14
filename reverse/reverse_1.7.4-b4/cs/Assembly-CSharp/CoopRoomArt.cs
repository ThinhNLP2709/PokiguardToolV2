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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class CoopRoomArt // TypeDefIndex: 12
{
	// Fields
	public static readonly Color OutlineBlue; // 0x00
	private static readonly Dictionary<string, Sprite> _subCache; // 0x10
	private static readonly Dictionary<string, Sprite> _slicedCache; // 0x18

	// Properties
	public static Font Font { get; } // 0x0000000180293280-0x0000000180293290 

	// Constructors
	static CoopRoomArt(); // 0x0000000180294C40-0x0000000180294DE0

	// Methods
	public static Sprite Chip(); // 0x0000000180293200-0x0000000180293280
	public static Sprite First(string resourcePath); // 0x0000000180293290-0x0000000180293860
	public static Sprite Sliced(string resourcePath, Vector4 border); // 0x0000000180293860-0x0000000180293F90
	public static void Apply(Image img, Sprite sprite, Color tint, Color flatFallback); // 0x0000000180293F90-0x0000000180294220
	public static RectTransform Rect(string name, Transform parent); // 0x0000000180294220-0x00000001802944F0
	public static void Stretch(RectTransform rt, float left = 0f /* Metadata: 0x005EE604 */, float bottom = 0f /* Metadata: 0x005EE608 */, float right = 0f /* Metadata: 0x005EE60C */, float top = 0f /* Metadata: 0x005EE610 */); // 0x00000001802944F0-0x00000001802945D0
	public static void Place(RectTransform rt, Vector2 anchor, Vector2 pos, Vector2 size); // 0x00000001802945D0-0x0000000180294670
	public static UnityEngine.UI.Text Label(string name, Transform parent, string content, int size, TextAnchor anchor, Color color, Color? outline, bool bold = false /* Metadata: 0x005EE614 */); // 0x0000000180294670-0x00000001802949F0
	public static Button MakeButton(Image graphic, UnityAction onClick); // 0x00000001802949F0-0x0000000180294C40
}

