/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

internal static class ThanhTuuUi // TypeDefIndex: 1267
{
	// Fields
	private static readonly Vector3[] _corners; // 0x00

	// Constructors
	static ThanhTuuUi(); // 0x0000000180710660-0x0000000180710720

	// Methods
	public static float FontOf(string key, float raw); // 0x000000018070E630-0x000000018070E930
	public static Vector4 R(string key, float x, float y, float w, float h); // 0x000000018070E930-0x000000018070EB00
	public static Color C(string key, Color def); // 0x000000018070EB00-0x000000018070EC60
	public static RectTransform TL(Transform parent, string name, Vector4 r); // 0x000000018070EC60-0x000000018070ED10
	public static void Place(RectTransform rt, float x, float y, float w, float h); // 0x000000018070ED10-0x000000018070EE50
	public static Image Img(Transform parent, string name, Vector4 r, bool raycast); // 0x000000018070EE50-0x000000018070EFA0
	public static Image Solid(Transform parent, string name, Color color, bool raycast); // 0x000000018070EFA0-0x000000018070F0F0
	public static UnityEngine.UI.Text Txt(Transform parent, string name, Vector4 r, string value, string fontKey, float raw, Color color, TextAnchor align, Color outline, bool bold = false /* Metadata: 0x005EF641 */, float outlineDist = 2f /* Metadata: 0x005EF642 */); // 0x000000018070F0F0-0x000000018070F450
	public static void SetOutline(UnityEngine.UI.Text t, Color c, float dist); // 0x000000018070F450-0x000000018070F630
	public static Image Hit(RectTransform button, float w, float h); // 0x000000018070F630-0x000000018070F840
	public static void Skin(MonoBehaviour host, Image img, string name); // 0x000000018070F840-0x000000018070FB10
	public static void FitSlice(Image img); // 0x000000018070FB10-0x000000018070FF30
	public static string Num(long v); // 0x000000018070FF30-0x000000018070FF80
	public static string Sanitize(string s); // 0x000000018070FF80-0x0000000180710070
	public static string Hex(Color c); // 0x0000000180710070-0x00000001807100D0
	public static Rect RectIn(RectTransform space, RectTransform target); // 0x00000001807100D0-0x00000001807104E0
	public static void Notice(string message); // 0x00000001807104E0-0x0000000180710660
}

