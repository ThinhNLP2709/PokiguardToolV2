/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class EventTrackArt // TypeDefIndex: 606
{
	// Fields
	public static readonly Color OUTLINE; // 0x00
	public static readonly Color PRIMARY_FALLBACK; // 0x10
	public static readonly Color ACCENT_FALLBACK; // 0x20
	private static readonly Regex PREFIX_RE; // 0x30
	private static readonly Dictionary<string, Sprite> _cache; // 0x38
	private static readonly Color CHEST_1; // 0x40
	private static readonly Color CHEST_2; // 0x50
	private static readonly Color CHEST_3; // 0x60

	// Constructors
	static EventTrackArt(); // 0x0000000180432090-0x0000000180432600

	// Methods
	public static string Prefix(EventTrackTheme t); // 0x000000018042DF90-0x000000018042E100
	public static string PathOf(EventTrackTheme t, string name); // 0x000000018042E100-0x000000018042E1B0
	public static string ChestName(int tier); // 0x000000018042E1B0-0x000000018042E270
	public static Sprite Load(EventTrackTheme t, string name); // 0x000000018042E270-0x000000018042E320
	public static Sprite LoadReal(EventTrackTheme t, string name); // 0x000000018042E320-0x000000018042E500
	public static void Bind(MonoBehaviour host, Image img, EventTrackTheme t, string name, Sprite fallback, Color tint); // 0x000000018042E500-0x000000018042E920
	public static bool BindKit(MonoBehaviour host, Image img, EventTrackTheme t, string name, string kitName, Image.Type type, Color waiting, Color ready, bool preserveAspect = false /* Metadata: 0x005EE437 */); // 0x000000018042E920-0x000000018042EDC0
	public static Color ParseColor(string hex, Color fallback); // 0x000000018042EDC0-0x000000018042EF00
	public static void SafeDestroy(UnityEngine.Object target); // 0x000000018042EF00-0x000000018042F060
	public static Sprite Procedural(string name, Color primary); // 0x000000018042F060-0x000000018042F3F0
	private static Sprite Build(string name, Color primary, string key); // 0x000000018042F3F0-0x000000018042FAD0
	private static Sprite Drop(int size, Color primary, string key); // 0x000000018042FAD0-0x000000018042FE40
	private static Sprite Disc(int size, string key); // 0x000000018042FE40-0x00000001804300C0
	public static Color ChestColor(int tier); // 0x00000001804300C0-0x00000001804301A0
	private static Sprite Chest(int size, int tier, string key); // 0x00000001804301A0-0x00000001804306D0
	private static Sprite Glow(int size, string key); // 0x00000001804306D0-0x0000000180430900
	private static Sprite Streak(int w, int h, string key); // 0x0000000180430900-0x0000000180430B90
	private static Sprite Splash(int size, string key); // 0x0000000180430B90-0x0000000180430E60
	private static Sprite HubIcon(int size, Color primary, string key); // 0x0000000180430E60-0x00000001804313F0
	private static bool Disc(float x, float y, float cx, float cy, float r); // 0x0000000180328130-0x0000000180328160
	private static Sprite Banner(int w, int h, Color primary, string key); // 0x00000001804313F0-0x0000000180431750
	private static Color32[] Paint(bool[] inside, int w, int h, Color fill, Color outline, Vector3 highlight); // 0x0000000180431750-0x0000000180431CD0
	private static Sprite Rasterize(bool[] inside, int w, int h, Color fill, Color outline, string name, Vector3 highlight); // 0x0000000180431CD0-0x0000000180431DC0
	private static bool IsEdge(bool[] inside, int w, int h, int x, int y); // 0x00000001803287E0-0x0000000180328890
	private static Sprite Finish(Color32[] px, int w, int h, string name); // 0x0000000180431DC0-0x0000000180432090
}

