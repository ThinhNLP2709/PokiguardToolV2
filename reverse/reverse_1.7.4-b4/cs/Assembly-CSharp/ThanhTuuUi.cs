/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

internal static class ThanhTuuUi // TypeDefIndex: 1269
{
	// Fields
	private static readonly Vector3[] _corners; // 0x00

	// Constructors
	static ThanhTuuUi(); // 0x0000000180712410-0x00000001807124D0

	// Methods
	public static float FontOf(string key, float raw); // 0x00000001807103E0-0x00000001807106E0
	public static Vector4 R(string key, float x, float y, float w, float h); // 0x00000001807106E0-0x00000001807108B0
	public static Color C(string key, Color def); // 0x00000001807108B0-0x0000000180710A10
	public static RectTransform TL(Transform parent, string name, Vector4 r); // 0x0000000180710A10-0x0000000180710AC0
	public static void Place(RectTransform rt, float x, float y, float w, float h); // 0x0000000180710AC0-0x0000000180710C00
	public static Image Img(Transform parent, string name, Vector4 r, bool raycast); // 0x0000000180710C00-0x0000000180710D50
	public static Image Solid(Transform parent, string name, Color color, bool raycast); // 0x0000000180710D50-0x0000000180710EA0
	public static UnityEngine.UI.Text Txt(Transform parent, string name, Vector4 r, string value, string fontKey, float raw, Color color, TextAnchor align, Color outline, bool bold = false /* Metadata: 0x005F0A0E */, float outlineDist = 2f /* Metadata: 0x005F0A0F */); // 0x0000000180710EA0-0x0000000180711200
	public static void SetOutline(UnityEngine.UI.Text t, Color c, float dist); // 0x0000000180711200-0x00000001807113E0
	public static Image Hit(RectTransform button, float w, float h); // 0x00000001807113E0-0x00000001807115F0
	public static void Skin(MonoBehaviour host, Image img, string name); // 0x00000001807115F0-0x00000001807118C0
	public static void FitSlice(Image img); // 0x00000001807118C0-0x0000000180711CE0
	public static string Num(long v); // 0x0000000180711CE0-0x0000000180711D30
	public static string Sanitize(string s); // 0x0000000180711D30-0x0000000180711E20
	public static string Hex(Color c); // 0x0000000180711E20-0x0000000180711E80
	public static Rect RectIn(RectTransform space, RectTransform target); // 0x0000000180711E80-0x0000000180712290
	public static void Notice(string message); // 0x0000000180712290-0x0000000180712410
}

