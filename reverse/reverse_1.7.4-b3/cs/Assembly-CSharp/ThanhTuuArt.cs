/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class ThanhTuuArt // TypeDefIndex: 1238
{
	// Fields
	public static readonly string[] ALL_NAMES; // 0x00
	public static readonly Color NAVY_DEEP; // 0x08
	public static readonly Color NAVY; // 0x18
	public static readonly Color GLASS; // 0x28
	public static readonly Color CYAN; // 0x38
	public static readonly Color GOLD; // 0x48
	public static readonly Color BRONZE; // 0x58
	public static readonly Color ORANGE; // 0x68
	public static readonly Color PINK; // 0x78
	public static readonly Color RED; // 0x88
	public static readonly Color GREEN; // 0x98
	public static readonly Color SILVER; // 0xA8
	private static readonly Regex PREFIX_RE; // 0xB8
	private static readonly Regex NAME_RE; // 0xC0
	private static readonly Regex FULL_PATH_RE; // 0xC8
	private static string _prefixSrc; // 0xD0
	private static string _prefixOut; // 0xD8
	private static readonly Dictionary<Image, ArtWait> _waits; // 0xE0
	private static readonly Dictionary<string, Sprite> _cache; // 0xE8

	// Properties
	public static string CurrentPrefix { get; } // 0x00000001806F36A0-0x00000001806F3930 

	// Nested types
	private sealed class ArtWait // TypeDefIndex: 1239
	{
		// Fields
		public Image target; // 0x10
		public Image proxy; // 0x18
		public UnityAction onDirty; // 0x20

		// Constructors
		public ArtWait(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass80_0 // TypeDefIndex: 1240
	{
		// Fields
		public ArtWait w; // 0x10

		// Constructors
		public __c__DisplayClass80_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _WatchSelf_b__0(); // 0x00000001806FF8D0-0x00000001806FFAA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass81_0 // TypeDefIndex: 1241
	{
		// Fields
		public ArtWait w; // 0x10

		// Constructors
		public __c__DisplayClass81_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _WatchProxy_b__0(); // 0x00000001806FFAA0-0x00000001806FFB00
	}

	// Constructors
	static ThanhTuuArt(); // 0x00000001806FE730-0x00000001806FF8D0

	// Methods
	public static string Prefix(string p); // 0x00000001806F3460-0x00000001806F36A0
	public static string PathOf(string name); // 0x00000001806F3930-0x00000001806F3AB0
	public static string TabFor(string style); // 0x00000001806F3AB0-0x00000001806F3C80
	public static Vector4 Border9(string name); // 0x00000001806F3C80-0x00000001806F46E0
	private static Vector4 All(float b); // 0x00000001806F46E0-0x00000001806F46F0
	private static Vector4 Caps(float b); // 0x00000001806F46F0-0x00000001806F4710
	public static void Bind(MonoBehaviour host, Image img, string name, Vector4 border9 = default); // 0x00000001806F4710-0x00000001806F4850
	public static void BindFallback(Image img, string name, Sprite fallback, Vector4 border9 = default); // 0x00000001806F4850-0x00000001806F4F00
	private static void WatchSelf(Image img); // 0x00000001806F4F00-0x00000001806F5150
	private static void WatchProxy(Image img, string path); // 0x00000001806F5150-0x00000001806F5880
	private static void OnSelfDirty(ArtWait w); // 0x00000001806F5880-0x00000001806F5A10
	private static void OnProxyDirty(ArtWait w); // 0x00000001806F5A10-0x00000001806F5CA0
	private static bool IsReal(Sprite s); // 0x00000001806F5CA0-0x00000001806F5ED0
	private static void Remember(Image img, ArtWait w); // 0x00000001806F5ED0-0x00000001806F5FB0
	private static void StopWait(Image img); // 0x00000001806F5FB0-0x00000001806F6400
	private static void Forget(ArtWait w); // 0x00000001806F6400-0x00000001806F64D0
	private static void Detach(ArtWait w); // 0x00000001806F64D0-0x00000001806F6840
	private static void Prune(); // 0x00000001806F6840-0x00000001806F6F20
	public static void SafeDestroy(UnityEngine.Object target); // 0x00000001806F6F20-0x00000001806F7080
	public static Sprite Procedural(string name); // 0x00000001806F7080-0x00000001806F73E0
	private static Sprite Build(string name); // 0x00000001806F73E0-0x00000001806F8ED0
	private static Vector4 AllB(float b); // 0x00000001806F46E0-0x00000001806F46F0
	private static Color WithAlpha(Color c, float a); // 0x00000001806F8ED0-0x00000001806F8EF0
	private static bool[] RoundedMask(int w, int h, float radiusFrac, float inset); // 0x00000001806F8EF0-0x00000001806F9170
	private static Sprite Box(int w, int h, float radiusFrac, Color fill, Color outline, int edge, Vector4 border, string key); // 0x00000001806F9170-0x00000001806F92D0
	private static Sprite Pill(int w, int h, Color fill, Color outline, Color fillRight, string key); // 0x00000001806F92D0-0x00000001806F9470
	private static Sprite Frame(int w, int h, float radiusFrac, Color color, int thickness, Vector4 border, string key); // 0x00000001806F9470-0x00000001806F9640
	private static Sprite Disc(int size, Color fill, Color outline, string key); // 0x00000001806F9640-0x00000001806F97A0
	private static bool[] MaskDisc(int size, float r); // 0x00000001806F97A0-0x00000001806F9940
	private static Sprite Gradient(int w, int h, Color top, Color bottom, string key); // 0x00000001806F9940-0x00000001806F9BE0
	private static Sprite Cube(int size, bool xSlot, string key); // 0x00000001806F9BE0-0x00000001806FA0D0
	private static Sprite Check(int size, string key); // 0x00000001806FA0D0-0x00000001806FA360
	private static Sprite Stamp(int w, int h, string key); // 0x00000001806FA360-0x00000001806FA710
	private static Sprite Hexagon(int size, string key); // 0x00000001806FA710-0x00000001806FAA70
	private static Sprite HomeButton(int size, string key); // 0x00000001806FAA70-0x00000001806FAFE0
	private static Sprite CrossBox(int w, int h, string key); // 0x00000001806FAFE0-0x00000001806FB2A0
	private static Sprite Trophy(int size, string key); // 0x00000001806FB2A0-0x00000001806FBB10
	private static Sprite Badge(int size, string key); // 0x00000001806FBB10-0x00000001806FBC80
	private static Sprite HelpBadge(int size, string key); // 0x00000001806FBC80-0x00000001806FBDF0
	private static void DrawBang(Color32[] px, int size); // 0x00000001806FBDF0-0x00000001806FC060
	private static Sprite Arc(int size, Color tint, string key); // 0x00000001806FC060-0x00000001806FC450
	private static Sprite Glow(int size, Color tint, string key); // 0x00000001806FC450-0x00000001806FC870
	private static Sprite StarOutline(int size, Color tint, string key); // 0x00000001806FC870-0x00000001806FCDB0
	private static Sprite Crescent(int size, string key); // 0x00000001806FCDB0-0x00000001806FD120
	private static Sprite Sparkle(int size, string key); // 0x00000001806FD120-0x00000001806FD600
	private static bool InDisc(float x, float y, float cx, float cy, float r); // 0x0000000180328130-0x0000000180328160
	private static float Dist(float x, float y, float cx, float cy); // 0x00000001806FD600-0x00000001806FD630
	private static float SegDist(float px, float py, float ax, float ay, float bx, float by); // 0x00000001806FD630-0x00000001806FD790
	private static bool InTriangle(float px, float py, float ax, float ay, float bx, float by, float cx, float cy); // 0x00000001806FD790-0x00000001806FD8C0
	private static float Band(float v, float lo, float hi, float soft); // 0x00000001806FD8C0-0x00000001806FD920
	private static byte ToByte(float v); // 0x00000001806FD920-0x00000001806FD950
	private static void DrawSegment(Color32[] px, int w, int h, float ax, float ay, float bx, float by, float halfThick, Color32 color, bool[] clip); // 0x00000001806FD950-0x00000001806FDD40
	private static Color32[] Paint(bool[] inside, int w, int h, Color fill, Color fillRight, Color outline, int edge, Vector3 highlight); // 0x00000001806FDD40-0x00000001806FE380
	private static bool IsEdge(bool[] inside, int w, int h, int x, int y, int e); // 0x00000001806FE380-0x00000001806FE450
	private static Sprite Finish(Color32[] px, int w, int h, string name, Vector4 border); // 0x00000001806FE450-0x00000001806FE730
}

